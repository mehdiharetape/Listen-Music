using Listen_Music.Domain.Entities.Comments;
using Listen_Music.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Domain.Entities.Songs
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public int ViewConut { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public virtual Singers Singer { get; set; }
        public long SingerId { get; set; }

        public virtual Genre Genre { get; set; }
        public long GenreId { get; set; }

        public virtual PlayLists PlayList { get; set; }
        public long PlayListId { get; set; }

        public SongFile SongFile { get; set; }

        public ImageFile ImageFile { get; set; }
    }

    public class SongFile : BaseEntity
    {
        public string SongSrc { get; set; }
        public Song Song {get; set;}
        public long SongId { get; set; }
    }

    public class ImageFile : BaseEntity
    {
        public string ImageSrc { get; set; }
        public Song Song { get; set; }
        public long SongId { get; set; }

    }
}
