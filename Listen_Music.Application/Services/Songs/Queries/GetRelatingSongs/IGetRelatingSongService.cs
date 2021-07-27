using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetRelatingSongs
{
    public interface IGetRelatingSongService
    {
        ResultDTO<List<ResultRelatingDTO>> Execute(long PlayListId);
    }

    public class GetRelatingSongService : IGetRelatingSongService
    {
        private readonly IDataBaseContext _context;
        public GetRelatingSongService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<ResultRelatingDTO>> Execute(long PlayListId)
        {
            var songs = _context.Songs.OrderByDescending(s => s.Id)
                .Include(s => s.Singer).Where(s => s.PlayListId == PlayListId)
                .Select(s => new ResultRelatingDTO
                {
                     Id = s.Id,
                     SongName = s.Name,
                     SingerName = s.Singer.FullName
                }).Take(10).ToList();

            return new ResultDTO<List<ResultRelatingDTO>>()
            {
                Data = songs,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class ResultRelatingDTO
    {
        public long Id { get; set; }
        public string SongName { get; set; }
        public string SingerName { get; set; }
    }
}
