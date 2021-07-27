using Listen_Music.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listen_Music.Domain.Entities.Songs;
using System.ComponentModel.DataAnnotations;

namespace Listen_Music.Domain.Entities.Comments
{
    public class Comment : BaseEntity
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }

        public Song Song { get; set; }
        public long SongId { get; set; }
    }
}
