using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetSongDetailForSite
{
    public interface IGetSongDetailForSiteService
    {
        ResultDTO<SongDetailForSiteDTO> Execute(long Id);
    }

    public class GetSongDetailForSiteService : IGetSongDetailForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetSongDetailForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<SongDetailForSiteDTO> Execute(long Id)
        {
            var song = _context.Songs.Include(p => p.ImageFile).Include(p => p.Singer)
                .Include(p => p.PlayList).Include(p => p.SongFile).Where(p => p.Id == Id).FirstOrDefault();

            if (song == null)
            {
                throw new Exception("song not found ... ");
            }

            song.ViewConut++;
            _context.SaveChanges();
            return new ResultDTO<SongDetailForSiteDTO>()
            {
                Data = new SongDetailForSiteDTO()
                {
                    Id = song.Id,
                    Title = song.Name,
                    Duration = song.Duration,
                    SingerName = song.Singer.FullName,
                    PlayList = song.PlayList.ListName,
                    PlayListId = song.PlayListId,
                    Image = song.ImageFile.ImageSrc,
                    Song = song.SongFile.SongSrc,
                    ViewCount = song.ViewConut
                }
            };
        }
    }

    public class SongDetailForSiteDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string SingerName { get; set; }
        public string PlayList { get; set; }
        public long PlayListId { get; set; }
        public string Image { get; set; }
        public string Song { get; set; }
        public int ViewCount { get; set; }
    }
}
