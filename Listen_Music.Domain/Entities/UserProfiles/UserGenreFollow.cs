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
    public class UserGenreFollow : BaseEntity
    {
        public User User { get; set; }
        public long? UserId { get; set; }
        public ICollection<GenreFollowItems> GenreFollowItems { get; set; }
    }
    public class GenreFollowItems : BaseEntity
    {
        public virtual Genre Genre { get; set; }
        public long GenreId { get; set; }
        public string GenreName { get; set; }
        public virtual UserGenreFollow UserGenreFollow { get; set; }
        public virtual long UserGenreFollowId { get; set; }
    }
}
