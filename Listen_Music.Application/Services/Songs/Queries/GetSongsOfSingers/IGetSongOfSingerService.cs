using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetSongsOfSingers
{
    public interface IGetSongOfSingerService
    {
        ResultDTO<SongForSingertDTO_List> GetExecute(long SingerId, int page, int pageSize);
    }

    public class GetSongOfSingerService : IGetSongOfSingerService
    {
        private readonly IDataBaseContext _context;
        public GetSongOfSingerService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<SongForSingertDTO_List> GetExecute(long SingerId, int page, int pageSize)
        {
            int totalRow = 0;
            var songs = _context.Songs.OrderByDescending(s => s.Id)
                .Where(s => s.SingerId == SingerId)
                .Include(s => s.ImageFile)
                .Include(s => s.Singer).Include(s => s.Genre).Include(s => s.PlayList)
                .ToPaged(page, pageSize, out totalRow).AsQueryable();
            var singerName = _context.Singers.Find(SingerId);

            return new ResultDTO<SongForSingertDTO_List>()
            {
                Data = new SongForSingertDTO_List
                {
                    TotalRow = totalRow,
                    singerName = singerName.FullName,
                    SingerId = singerName.Id,
                    Songs = songs.Select(s => new SongForSingertDTO()
                    {
                        Id = s.Id,
                        ArtistName = s.Singer.FullName,
                        ImageSrc = s.ImageFile.ImageSrc,
                        Title = s.Name
                    }).ToList(),
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class SongForSingertDTO_List
    {
        public List<SongForSingertDTO> Songs { get; set; }
        public int TotalRow { get; set; }
        public string singerName { get; set; }
        public long SingerId { get; set; }
    }

    public class SongForSingertDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public string ArtistName { get; set; }
    }
}
