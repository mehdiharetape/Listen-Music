using Listen_Music.Domain.Entities.Commons;

namespace Listen_Music.Domain.Entities.Users
{
    public class UserInRole:BaseEntity
    {
        public virtual User User { get; set; }
        public long UserId { get; set; }

        public virtual Role Role { get; set; }
        public long RoleId { get; set; }
    }
}
