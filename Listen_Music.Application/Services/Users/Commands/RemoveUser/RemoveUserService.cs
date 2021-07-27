using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Linq;

namespace Listen_Music.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;
        public RemoveUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(long UserId)
        {
            var user = _context.Users.Find(UserId);
            if(user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDTO
            {
                IsSuccess = true,
                Message = "کاربر حذف شد"
            };
        }
    }
}
