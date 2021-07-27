using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDTO<List<RolesDTO>> Execute();
    }
}
