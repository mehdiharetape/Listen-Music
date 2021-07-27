using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetPlayList
{
    public interface IGetPlayListService
    {
        ResultDTO<PlayList_ListDTO> Execute(string SearchKey,int page=1, int pageSize=10);
    }

    public class GetPlayListService : IGetPlayListService
    {
        private readonly IDataBaseContext _context;
        public GetPlayListService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<PlayList_ListDTO> Execute(string SearchKey,int page = 1, int pageSize = 10)
        {
            //var playLists = _context.PlayLists.ToList().Select(p => new PlayListsDTO
            //{
            //    Id = p.Id,
            //    Name = p.ListName
            //}).ToList();

            //return new ResultDTO<List<PlayListsDTO>>()
            //{
            //    Data = playLists,
            //    IsSuccess = true,
            //    Message = "لیست با موفقیت برگشت داده شد"
            //};
            int rowCount = 0;
            var playlist = _context.PlayLists.ToPaged(page, pageSize, out rowCount).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                playlist = playlist.Where(p => p.ListName.Contains(SearchKey)).AsQueryable();
            }

            return new ResultDTO<PlayList_ListDTO>
            {
                Data = new PlayList_ListDTO
                {
                    playLists = playlist.Select(p => new PlayListsDTO 
                    {
                        Id = p.Id,
                        Name = p.ListName
                    }).ToList(), 
                    CurrentPage = page,
                    PageSize = pageSize, 
                    RowCount = rowCount
                },
                IsSuccess = true, 
                Message = ""
            };
        }
    }

    public class PlayList_ListDTO
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<PlayListsDTO> playLists { get; set; }
    }

    public class PlayListsDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
