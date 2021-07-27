using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Common.Queries.GetMemuItems
{
    public interface IGetMemuItemService
    {
        ResultDTO<List<SingersMemuItemDTO>> Singer_Execute();
        ResultDTO<List<GenresMemuItemDTO>> Genre_Execute();

    }

    public class GetMemuItemService : IGetMemuItemService
    {
        private readonly IDataBaseContext _context;
        public GetMemuItemService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<List<GenresMemuItemDTO>> Genre_Execute()
        {
            var genres = _context.Genres.ToList().Select(p => new GenresMemuItemDTO
            {
                GenreId = p.Id,
                GenreName = p.GenreName
            }).ToList();

            return new ResultDTO<List<GenresMemuItemDTO>>()
            {
                Data = genres,
                IsSuccess = true,
                Message = ""
            };
        }

        public ResultDTO<List<SingersMemuItemDTO>> Singer_Execute()
        {
            var singers = _context.Singers.ToList().Select(p => new SingersMemuItemDTO
            {
                SingerId = p.Id,
                singerName = p.FullName
            }).ToList();

            return new ResultDTO<List<SingersMemuItemDTO>>()
            {
                Data = singers,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class SingersMemuItemDTO
    {
        public long SingerId { get; set; }
        public string singerName { get; set; }
    }

    public class GenresMemuItemDTO
    {
        public long GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
