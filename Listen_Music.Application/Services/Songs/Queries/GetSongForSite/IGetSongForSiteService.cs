using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetSongForSite
{
    public interface IGetSongForSiteService
    {
        ResultDTO<ResultSongForSiteDTO> Execute(string searchKey,int pageSize,int page);
    }

    public class GetSongForSiteService : IGetSongForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetSongForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultSongForSiteDTO> Execute(string searchKey, int pageSize=12, int page=1)
        {
            int totalRow = 0;
            var songs = _context.Songs.OrderByDescending(p => p.Id).Include(p => p.ImageFile)
                .Include(p => p.Singer).Include(p => p.Genre).Include(p => p.PlayList)
                .ToPaged(page, pageSize, out totalRow).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                songs = songs.Where(p => p.Name.Contains(searchKey) || p.Singer.FullName.Contains(searchKey)
                           || p.Genre.GenreName.Contains(searchKey) || 
                           p.PlayList.ListName.Contains(searchKey)).AsQueryable();
            }

            

            return new ResultDTO<ResultSongForSiteDTO>()
            {
                Data = new ResultSongForSiteDTO
                {
                    TotalRow = totalRow,
                    Page = page,
                    PageSize = pageSize,
                    Sogs = songs.Select(p => new SongForSiteDTO
                    {
                        Id = p.Id,
                        Title = p.Name,
                        ImageSrc = p.ImageFile.ImageSrc,
                        ArtistName = p.Singer.FullName
                    }).ToList()
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class ResultSongForSiteDTO
    {
        public List<SongForSiteDTO> Sogs { get; set; }
        public int TotalRow { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class SongForSiteDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public string ArtistName { get; set; }
    }

    
}
