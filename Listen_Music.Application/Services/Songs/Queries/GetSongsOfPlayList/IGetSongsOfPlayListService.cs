using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetSongsOfPlayList
{
    public interface IGetSongsOfPlayListService
    {
        ResultDTO<SongForPlayListDTO_List> GetExecute(long PlayListId, int page, int pageSize);
    }

    public class GetSongsOfPlayListService : IGetSongsOfPlayListService
    {
        private readonly IDataBaseContext _context;
        public GetSongsOfPlayListService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<SongForPlayListDTO_List> GetExecute(long PlayListId, int page, int pageSize)
        {
            int totalRow = 0;
            var songs = _context.Songs.OrderByDescending(s => s.Id)
                .Where(s => s.PlayListId == PlayListId)
                .Include(s => s.ImageFile)
                .Include(s => s.Singer).Include(s => s.Genre).Include(s => s.PlayList)
                .ToPaged(page, pageSize, out totalRow).AsQueryable();
            var playlistName = _context.PlayLists.Find(PlayListId);

            return new ResultDTO<SongForPlayListDTO_List>()
            {
                Data = new SongForPlayListDTO_List
                {
                    TotalRow = totalRow,
                    PlayListName = playlistName.ListName,
                    PlayListId = playlistName.Id,
                    Songs = songs.Select(s => new SongForPlayListDTO()
                    {
                        Id = s.Id,
                        ArtistName = s.Singer.FullName,
                        ImageSrc = s.ImageFile.ImageSrc,
                        Title = s.Name,
                    }).ToList(),
                },
                IsSuccess = true,
                Message = ""
            };
        }

    }

    public class SongForPlayListDTO_List
    {
        public List<SongForPlayListDTO> Songs { get; set; }
        public int TotalRow { get; set; }
        public string PlayListName { get; set; }
        public long PlayListId { get; set; }
    }

    public class SongForPlayListDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public string ArtistName { get; set; }
    }
}
