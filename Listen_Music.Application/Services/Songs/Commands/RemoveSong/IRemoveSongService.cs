
using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Listen_Music.Application.Services.Songs.Commands.RemoveSong
{
    public interface IRemoveSongService
    {
        ResultDTO Execute(long Id);
    }

    public class RemoveSongService : IRemoveSongService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public RemoveSongService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ResultDTO Execute(long Id)
        {
            var song = _context.Songs.Find(Id);
            var imageFile = _context.ImageFiles.Where(p => p.SongId == Id).FirstOrDefault();
            var songFile = _context.SongFiles.Where(p => p.SongId == Id).FirstOrDefault();

            if(song == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "آهنگ یافت نشد"
                };
            }

            DeleteFile(songFile.SongSrc, imageFile.ImageSrc);

            _context.Songs.Remove(song);
            _context.SongFiles.Remove(songFile);
            _context.ImageFiles.Remove(imageFile);

            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "آهنگ حذف شد"
            };
        }
       
        public void DeleteFile(string SongPath, string ImagePath)
        {
            string songDir = Path.Combine(_environment.WebRootPath, SongPath);
            string imageDir = Path.Combine(_environment.WebRootPath, ImagePath);

            if(File.Exists(songDir) && File.Exists(imageDir))
            {
                File.Delete(songDir);
                File.Delete(imageDir);
            }
        }
    }
}
