using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetMostView
{
    public interface IGetMostViewService
    {
        //ResultDTO<RequestGetMostViewDTO_List> Execute();
        ResultDTO<List<RequestGetMostViewDTO>> Execute();

    }

    public class GetMostViewService : IGetMostViewService
    {
        private readonly IDataBaseContext _context;
        public GetMostViewService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<RequestGetMostViewDTO>> Execute()
        {
            var mostViewSong = _context.Songs.OrderByDescending(s => s.ViewConut)
                .Include(s => s.Singer)
                .Include(s => s.ImageFile).Take(6).Select(s => new RequestGetMostViewDTO
                {
                    SongId = s.Id,
                    SingerName = s.Singer.FullName,
                    ImageSrc = s.ImageFile.ImageSrc,
                    Views = s.ViewConut,
                    SongName = s.Name
                }).ToList();

            //return new ResultDTO<RequestGetMostViewDTO_List>()
            //{
            //    Data = new RequestGetMostViewDTO_List
            //    {
            //        mostViewSongs = mostViewSong.Select(s => new RequestGetMostViewDTO
            //        {
            //            SongId = s.Id,
            //            SongName = s.Name,
            //            ImageSrc = s.ImageFile.ImageSrc,
            //            Views = s.ViewConut,
            //            SingerName = s.Singer.FullName
            //        }).ToList()
            //    },
            //    IsSuccess = true,
            //    Message = ""
            //};

            return new ResultDTO<List<RequestGetMostViewDTO>>()
            {
                Data = mostViewSong,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    //public class RequestGetMostViewDTO_List
    //{
    //    public List<RequestGetMostViewDTO> mostViewSongs { get; set; }
    //}

    public class RequestGetMostViewDTO
    {
        public long SongId { get; set; }
        public string SongName { get; set; }
        public string SingerName { get; set; }
        public int Views { get; set; }
        public string ImageSrc { get; set; }
    }
}
