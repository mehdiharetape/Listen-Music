using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetGenres
{
    public interface IGetGenresService
    {
        ResultDTO<GenresListDTO> Execute(string SearchKey, int page=1, int pageSize=10);
    }

    public class GetGenresService : IGetGenresService
    {
        private readonly IDataBaseContext _context;
        public GetGenresService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<GenresListDTO> Execute(string SearchKey, int page = 1, int pageSize = 10)
        {
            //var genres = _context.Genres.ToList().Select(p => new GenresDTO
            //{
            //    Id = p.Id,
            //    Name = p.GenreName
            //}).ToList();

            //return new ResultDTO<List<GenresDTO>>()
            //{
            //    Data = genres,
            //    IsSuccess = true,
            //    Message = "لیست با موفقیت برگشت داده شد"
            //};
            int rowCount = 0;
            var genres = _context.Genres.ToPaged(page, pageSize, out rowCount).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                genres = genres.Where(g => g.GenreName.Contains(SearchKey)).AsQueryable();
            }

            return new ResultDTO<GenresListDTO>()
            {
                Data = new GenresListDTO
                {
                    Genres = genres.Select(g => new GenresDTO 
                    {
                        Id = g.Id,
                        Name = g.GenreName
                    }
                    ).ToList(),
                    CurrentPage = page, 
                    PageSize = pageSize, 
                    RowCount = rowCount
                },
                IsSuccess =true, 
                Message = ""
            };
        }
    }

    public class GenresListDTO
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<GenresDTO> Genres { get; set; }
    }

    public class GenresDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
