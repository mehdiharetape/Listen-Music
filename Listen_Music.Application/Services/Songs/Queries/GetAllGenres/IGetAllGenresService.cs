using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetAllGenres
{
    public interface IGetAllGenresService
    {
        ResultDTO<List<AllGenresDTO>> Execute();
    }

    public class GetAllGenresService : IGetAllGenresService
    {
        private readonly IDataBaseContext _context;
        public GetAllGenresService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<AllGenresDTO>> Execute()
        {
            var genres = _context.Genres.ToList().Select(p => new AllGenresDTO
            {
                Id = p.Id,
                Name = p.GenreName
            }).ToList();

            return new ResultDTO<List<AllGenresDTO>>
            {
                Data = genres,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class AllGenresDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
