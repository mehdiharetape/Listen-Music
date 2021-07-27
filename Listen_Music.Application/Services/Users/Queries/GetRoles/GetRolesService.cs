using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Listen_Music.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<RolesDTO>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new RolesDTO
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDTO<List<RolesDTO>> ()
            {
                Data = roles,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
