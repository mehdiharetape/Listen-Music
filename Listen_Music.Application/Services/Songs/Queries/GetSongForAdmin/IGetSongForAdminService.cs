using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetSongForAdmin
{
    public interface IGetSongForAdminService
    {
        ResultDTO<SongForAdminDTO> Execute(string SearchKey,int page=1,int pageSize=10);
    }

    public class GetSongForAdminService : IGetSongForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetSongForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<SongForAdminDTO> Execute(string SearchKey, int page = 1, int pageSize = 10)
        {
            int rowCount = 0;
            var song = _context.Songs.Include(p => p.Singer).Include(p => p.Genre).Include(p => p.PlayList)
                .ToPaged(page, pageSize, out rowCount).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                song = song.Where(p => p.Name.Contains(SearchKey) || p.Singer.FullName.Contains(SearchKey)
                            || p.Genre.GenreName.Contains(SearchKey) || p.PlayList.ListName.Contains(SearchKey))
                    .AsQueryable();
            }

            return new ResultDTO<SongForAdminDTO>()
            {
                Data = new SongForAdminDTO()
                {
                    Songs = song.Select(p => new SongforAdminList_DTO 
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Duration = p.Duration,
                        Genre = p.Genre.GenreName,
                        PlayList = p.PlayList.ListName,
                        Singer = p.Singer.FullName
                    }
                    ).ToList(),
                    CurrentPage = page,
                    PageSize = pageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class SongForAdminDTO
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<SongforAdminList_DTO> Songs { get; set; }
    }

    public class SongforAdminList_DTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Singer { get; set; }
        public string Genre { get; set; }
        public string PlayList { get; set; }
    }
}
