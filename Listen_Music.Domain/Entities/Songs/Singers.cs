using Listen_Music.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Domain.Entities.Songs
{
    public class Singers : BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
