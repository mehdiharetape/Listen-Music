using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.EditGenre
{
    public interface IEditGenreService
    {
        ResultDTO Execute(RequestEditGenreDTO request);
    }

    public class EditGenreService : IEditGenreService
    {
        private readonly IDataBaseContext _context;
        public EditGenreService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(RequestEditGenreDTO request)
        {
            var genre = _context.Genres.Find(request.Id);
            if(genre == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "سبک یافت نشد"
                };
            }

            genre.GenreName = request.Name;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "سبک ویرایش شد"
            };
        }
    }

    public class RequestEditGenreDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
