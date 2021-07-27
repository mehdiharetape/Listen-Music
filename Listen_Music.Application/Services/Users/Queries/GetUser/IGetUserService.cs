using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Users.Queries.GetUser
{
    public interface IGetUserService
    {
        ResultGetUserDTO Execute(RequestGetUser request, int pageSize=10);
    }
}
