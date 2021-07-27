using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetPlayListForSite
{
    public interface IGetPlayListForSiteService
    {
        ResultDTO<List<RequestPlayListDTO>> Execute();
    }

    public class GetPlayListForSiteService : IGetPlayListForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetPlayListForSiteService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO<List<RequestPlayListDTO>> Execute()
        {
            var playLists = _context.PlayLists.Select(s => new RequestPlayListDTO
            {
                Id = s.Id,
                Name = s.ListName
            }).ToList();

            return new ResultDTO<List<RequestPlayListDTO>>()
            {
                Data = playLists,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class RequestPlayListDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
