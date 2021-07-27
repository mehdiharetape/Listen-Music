using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.EditPlaylist
{
    public interface IEditPlayListService
    {
        ResultDTO Execute(RequestEditPlaylistDTO request);
    }

    public class EditPlayListService : IEditPlayListService
    {
        private readonly IDataBaseContext _context;
        public EditPlayListService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(RequestEditPlaylistDTO request)
        {
            var playlist = _context.PlayLists.Find(request.Id);
            if (playlist == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "لیست پخش یافت نشد"
                };
            }

            playlist.ListName = request.Name;
            _context.SaveChanges();


            return new ResultDTO
            {
                IsSuccess = true,
                Message = "لیست پخش ویرایش شد"
            };

        }
    }

    public class RequestEditPlaylistDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
