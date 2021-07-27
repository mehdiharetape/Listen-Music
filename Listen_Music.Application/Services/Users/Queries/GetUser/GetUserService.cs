using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Listen_Music.Application.Services.Users.Queries.GetUser
{
    public class GetUserService : IGetUserService
    {
        private readonly IDataBaseContext _context;
        public GetUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUserDTO Execute(RequestGetUser request,int pageSize = 10)
        {
            int rowCount = 0;
            var users = _context.Users
                .Include(u => u.userInRoles).ThenInclude(u => u.Role)
                .ToPaged(request.Page = 1, pageSize, out rowCount).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.
                    Where(p => p.UserName.Contains(request.SearchKey) ||
                    p.Email.Contains(request.SearchKey)).AsQueryable();
            }



            return new ResultGetUserDTO
            {
                CurrentPage = request.Page,
                PageSize = pageSize,
                RowCount = rowCount,
                Users = users.Select(p => new GetUsersDTO
                {
                    Id = p.Id,
                    Email = p.Email,
                    UserName = p.UserName,
                    RoleName = p.userInRoles.FirstOrDefault().Role.Name
                    
                }).ToList()
            };
        }
    }
}
