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
    public class UserPlayListFollow : BaseEntity
    {
        public User User { get; set; }
        public long UserId { get; set; }

        public ICollection<PlayListFollowItem> PlayListFollowItems { get; set; }
    }

    public class PlayListFollowItem : BaseEntity
    {
        public virtual PlayLists PlayLists { get; set; }
        public long PlayListsId { get; set; }
        public string PlayListName { get; set; }
        public virtual UserPlayListFollow UserPlayListFollow { get; set; }
        public virtual long UserPlayListFollowId { get; set; }
    }
}
