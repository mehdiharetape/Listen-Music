using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.EditSong
{
    public interface IEditSongService
    {
        ResultDTO Execute(RequestEditSongDTO request);
    }

    public class EditSongService : IEditSongService
    {
        private readonly IDataBaseContext _context;
        public EditSongService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(RequestEditSongDTO request)
        {
            var song = _context.Songs.Find(request.Id);
            if (song == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "آهنگ یافت نشد"
                };
            }

            song.Name = request.Name;
            song.Duration = request.Duration;

            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "آهنگ ویرایش شد"
            };
        }
    }

    public class RequestEditSongDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
    }
}
