using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetSingers
{
    public interface IGetSingersService
    {
        ResultDTO<singerListDTO> Execute(string SearchKey,int page = 1, int pageSize = 10);
    }

    public class GetSingersService : IGetSingersService
    {
        private readonly IDataBaseContext _context;
        public GetSingersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<singerListDTO> Execute(string SearchKey,int page = 1, int pageSize = 10)
        {
            //var singers = _context.Singers.ToList().Select(p => new SingersDTO
            //{
            //    Id = p.Id,
            //    FullName = p.FullName
            //}).ToList();
            int rowCount = 0;

            var singers = _context.Singers.ToPaged(page, pageSize, out rowCount).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                singers = singers.Where(s => s.FullName.Contains(SearchKey)).AsQueryable();
            }

            return new ResultDTO<singerListDTO>()
            {
                Data = new singerListDTO
                {
                    Singers = singers.Select(s => new SingersDTO
                    {
                        Id = s.Id,
                        FullName = s.FullName
                    }).ToList(),
                    PageSize = pageSize,
                    CurrentPage = page,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = ""
            };

            //return new ResultDTO<List<SingersDTO>>()
            //{
            //    Data = singers,
            //    IsSuccess = true,
            //    Message = "لیست با موفقیت برگشت داده شد"
            //};
        }
    }

    public class singerListDTO
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<SingersDTO> Singers {get; set;}
    }

    public class SingersDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }
    }
}
