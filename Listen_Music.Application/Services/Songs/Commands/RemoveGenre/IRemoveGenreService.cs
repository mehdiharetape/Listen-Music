using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.RemoveGenre
{
    public interface IRemoveGenreService
    {
        ResultDTO Execute(long Id);
    }

    public class RemoveGenreService : IRemoveGenreService
    {
        private readonly IDataBaseContext _context;
        public RemoveGenreService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(long Id)
        {
            var genre = _context.Genres.Find(Id);
            if(genre == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "سبک یافت نشد"
                };
            }

            genre.RemoveTime = DateTime.Now;
            genre.IsRemoved = true;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "سبک حذف شد"
            };
        }
    }
}
