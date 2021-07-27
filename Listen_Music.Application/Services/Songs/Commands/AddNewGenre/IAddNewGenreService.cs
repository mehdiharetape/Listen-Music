using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Listen_Music.Domain.Entities.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.AddNewGenre
{
    public interface IAddNewGenreService
    {
        ResultDTO Execute(string Name);
    }

    public class AddNewGenreService : IAddNewGenreService
    {
        private readonly IDataBaseContext _context;
        public AddNewGenreService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO Execute(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "لطفا نام سبک را وارد کنید"
                };
            }

            Genre genre = new Genre()
            {
                GenreName = Name,
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = " سبک با موفقیت اضافه شد"
            };
        }
    }
}
