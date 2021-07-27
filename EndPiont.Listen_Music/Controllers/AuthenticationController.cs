using EndPiont.Listen_Music.Models.Viewmodels.AuthenticationViewModel;
using Listen_Music.Application.Services.Users.Commands.Register;
using Listen_Music.Application.Services.Users.Commands.UserLogin;
using Listen_Music.Common.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace EndPiont.Listen_Music.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IUserLoginService _userLoginService;

        public AuthenticationController(IRegisterUserService registerUserService, IUserLoginService userLoginService)
        {
            _registerUserService = registerUserService;
            _userLoginService = userLoginService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {
            //start signup
            if(string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Username)
                || string.IsNullOrWhiteSpace(request.Password) || string.IsNullOrWhiteSpace(request.RePassword))
            {
                return Json(new ResultDTO { IsSuccess=false, Message="تمامی موارد را وارد کنید"});
            }
            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDTO { IsSuccess = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید" });
            }
            if (request.Password != request.RePassword)
            {
                return Json(new ResultDTO { IsSuccess = false, Message = "رمز عبور و تکرار آن برابر نیست" });
            }
            if (request.Password.Length < 8)
            {
                return Json(new ResultDTO { IsSuccess = false, Message = "رمز عبور باید حداقل 8 کاراکتر باشد" });
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDTO { IsSuccess = true, Message = "ایمیل خودرا به درستی وارد نمایید" });
            }

            var signupResult = _registerUserService.Execute(new RequestRegisterUserDTO 
            {
                Email = request.Email,
                UserName = request.Username,
                Password = request.Password,
                Repassword = request.RePassword,
                roles = new List<RolesInRegisterUserDTO>()
                {
                    new RolesInRegisterUserDTO {Id = 2}
                }
            });
            //end signup

            //start login
            if(signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email,request.Email),
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim(ClaimTypes.Role, "User")
                };
                var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(Identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(signupResult);
        }

        [HttpGet]
        public IActionResult SignIn(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string Email, string Password, string url="/")
        {
            var signinResult = _userLoginService.Execute(Email, Password);
            if(signinResult.IsSuccess == true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,signinResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email,Email),
                    new Claim(ClaimTypes.Name, signinResult.Data.Name),
                    new Claim(ClaimTypes.Role, signinResult.Data.Roles),
                };
                var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(Identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5)
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(signinResult);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
    }
}
