using Listen_Music.Domain.Entities.Commons;
using System.Collections.Generic;

namespace Listen_Music.Domain.Entities.Users
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserInRole> userInRoles { get; set; }
    }
}
