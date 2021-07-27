using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Users.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDTO<ResultUserloginDto> Execute(string email, string password);
    }

    public class UserLoginService : IUserLoginService
    {
        private readonly IDataBaseContext _context;
        public UserLoginService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<ResultUserloginDto> Execute(string email, string password)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return new ResultDTO<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto
                    {

                    },
                    IsSuccess = false,
                    Message = " ایمیل و رمز عبور را وارد کنید"
                };
            }

            var user = _context.Users.Include(p => p.userInRoles).ThenInclude(p => p.Role)
                .Where(p => p.Email.Equals(email)).FirstOrDefault();

            if (user == null)
            {
                return new ResultDTO<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "کاربری با این ایمیل در سایت  ثبت نام نکرده است",
                };
            }


            if (password != user.Password)
            {
                return new ResultDTO<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "رمز وارد شده اشتباه است!",
                };
            }

            var roles = "";
            foreach(var item in user.userInRoles)
            {
                roles += $"{item.Role.Name}";
            }

            return new ResultDTO<ResultUserloginDto>()
            {
                Data = new ResultUserloginDto
                {
                    Roles = roles,
                    UserId = user.Id,
                    Name = user.UserName
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد"
            };
        }
    }

    public class ResultUserloginDto
    {
        public long UserId { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }
    }
}
