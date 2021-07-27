using Listen_Music.Domain.Entities.Commons;
using Listen_Music.Domain.Entities.Songs;
using Listen_Music.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Domain.Entities.UserProfiles
{
    public class UserSingerFollow : BaseEntity
    {
        public User User { get; set; }
        public long? UserId { get; set; }

        public Guid BrowserId { get; set; }
        public ICollection<SingerFollowItem> singerFollowItems { get; set; }
    }
    public class SingerFollowItem : BaseEntity
    {
        public virtual Singers Singers { get; set; }
        public long SingersId { get; set; }
        public string SingerName { get; set;}
        public virtual UserSingerFollow UserSingerFollow { get; set; }
        public virtual long UserSingerFollowId { get; set; }

    }
}
