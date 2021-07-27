using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDTO Execute(RequestEditUserDTO request);
    }

    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;

        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(RequestEditUserDTO request)
        {
            var user = _context.Users.Find(request.UserId);
            if(user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.UserName = request.UserName;
            user.Email = request.Email;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "کاربر ویرایش شد"
            };
        }
    }

    public class RequestEditUserDTO
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
