using Listen_Music.Application.Services.Users.Commands.EditUser;
using Listen_Music.Application.Services.Users.Commands.Register;
using Listen_Music.Application.Services.Users.Commands.RemoveUser;
using Listen_Music.Application.Services.Users.Queries.GetRoles;
using Listen_Music.Application.Services.Users.Queries.GetUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly IGetUserService _getUserService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IEditUserService _editUserService;
        public UserController(IGetUserService getUserService, IGetRolesService getRolesService,
            IRegisterUserService registerUserService, IRemoveUserService removeUserService, IEditUserService editUserService)
        {
            _getUserService = getUserService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _editUserService = editUserService;
        }

        public IActionResult Index(string SearchKey, int page=1, int pageSize = 10)
        {
            return View(_getUserService.Execute(new RequestGetUser 
            { 
                Page = page,
                SearchKey = SearchKey,
            }, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList( _getRolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string Username, long RoleId, string Password, string Repassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDTO
            {
                Email = Email,
                UserName = Username,
                roles = new List<RolesInRegisterUserDTO>()
                {
                    new RolesInRegisterUserDTO
                    {
                        Id = RoleId
                    }
                },
                Password = Password,
                Repassword = Repassword
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string UserName, string Email)
        {
            return Json(_editUserService.Execute(new RequestEditUserDTO 
            {
                UserId = UserId,
                UserName = UserName,
                Email = Email
            }));
        }
    }
}
