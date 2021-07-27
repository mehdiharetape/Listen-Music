using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Listen_Music.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Users.Commands.Register
{
    public interface IRegisterUserService
    {
        ResultDTO<ResultRegisterUserDTO> Execute(RequestRegisterUserDTO request);
    }

    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;
        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultRegisterUserDTO> Execute(RequestRegisterUserDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "ایمیل را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.UserName))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "نام را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد کنید"
                    };
                }

                if (request.Password != request.Repassword)
                {
                    return new ResultDTO<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = " تکرار رمز عبور را درست وارد کنید "
                    };
                }

                User user = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                };

                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = user,
                        UserId = user.Id
                    });
                }

                user.userInRoles = userInRoles;
                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDTO<ResultRegisterUserDTO>()
                {
                    Data = new ResultRegisterUserDTO()
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد"
                };
            }
            catch (Exception)
            {
                return new ResultDTO<ResultRegisterUserDTO>()
                {
                    Data = new ResultRegisterUserDTO()
                    {
                        UserId = 0
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد"
                };
            }
        }
    }

    public class RequestRegisterUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
        public List<RolesInRegisterUserDTO> roles { get; set; }
    }

    public class RolesInRegisterUserDTO
    {
        public long Id { get; set; }
    }

    public class ResultRegisterUserDTO
    {
        public long UserId { get; set; }
    }
}
