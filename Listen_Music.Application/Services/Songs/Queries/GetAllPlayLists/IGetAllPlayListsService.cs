using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetAllPlayLists
{
    public interface IGetAllPlayListsService
    {
        ResultDTO<List<AllPlayListDTO>> Execute();

    }

    public class GetAllPlayLists : IGetAllPlayListsService
    {
        private readonly IDataBaseContext _context;
        public GetAllPlayLists(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<List<AllPlayListDTO>> Execute()
        {
            var playlist = _context.PlayLists.ToList().Select(p => new AllPlayListDTO
            {
                Id = p.Id,
                Name = p.ListName
            }).ToList();

            return new ResultDTO<List<AllPlayListDTO>>
            {
                Data = playlist,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class AllPlayListDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
