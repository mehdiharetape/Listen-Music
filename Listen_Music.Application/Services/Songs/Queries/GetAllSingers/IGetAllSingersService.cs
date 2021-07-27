using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetAllSingers
{
    public interface IGetAllSingersService
    {
        ResultDTO<List<AllSingerDTO>> Execute();
    }

    public class GetAllSingers : IGetAllSingersService
    {
        private readonly IDataBaseContext _context;
        public GetAllSingers(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<AllSingerDTO>> Execute()
        {
            var singers = _context.Singers.ToList().Select(p => new AllSingerDTO
            {
                Id = p.Id,
                Name = p.FullName
            }).ToList();

            return new ResultDTO<List<AllSingerDTO>>
            {
                Data = singers,
                IsSuccess = true,
                Message = ""
            };
        }
    }


    public class AllSingerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
