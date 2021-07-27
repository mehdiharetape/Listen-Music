using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetSongsOfGenre
{
    public interface IGetSongOfGenreService
    {
        ResultDTO<SongForGenresDTO_List> GetExecute(long GenreId, int page, int pageSize);
    }

    public class GetSongOfGenreService : IGetSongOfGenreService
    {
        private readonly IDataBaseContext _context;
        public GetSongOfGenreService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<SongForGenresDTO_List> GetExecute(long GenreId, int page, int pageSize)
        {
            int totalRow = 0;
            var songs = _context.Songs.OrderByDescending(s => s.Id)
                .Where(s => s.GenreId == GenreId)
                .Include(s => s.Singer).Include(s => s.ImageFile)
                .Include(s => s.Genre).Include(s => s.PlayList)
                .ToPaged(page, pageSize, out totalRow).AsQueryable();
            var genreName = _context.Genres.Find(GenreId);


            return new ResultDTO<SongForGenresDTO_List>()
            {
                Data = new SongForGenresDTO_List
                {
                    Songs = songs.Select(s => new SongForGenrestDTO()
                    {
                        Id = s.Id,
                        ArtistName = s.Singer.FullName,
                        ImageSrc = s.ImageFile.ImageSrc,
                        Title = s.Name
                    }).ToList(),
                    TotalRow = totalRow,
                    GenreName = genreName.GenreName,
                    GenreId = genreName.Id
                }
            };
        }
    }

    public class SongForGenresDTO_List
    {
        public List<SongForGenrestDTO> Songs { get; set; }
        public int TotalRow { get; set; }
        public string GenreName { get; set; }
        public long GenreId { get; set; }
    }

    public class SongForGenrestDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public string ArtistName { get; set; }
    }
}

