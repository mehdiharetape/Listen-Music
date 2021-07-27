using Listen_Music.Common.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDTO Execute(long UserId);
    }
}
