using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Listen_Music.Domain.Entities.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.AddNewSinger
{
    public interface IAddNewSingerService
    {
        ResultDTO Execute(string FullName);
    }

    public class AddNewSingerService : IAddNewSingerService
    {
        private readonly IDataBaseContext _context;
        public AddNewSingerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(string FullName)
        {
            if (string.IsNullOrEmpty(FullName))
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "لطفا نام هنرمند را وارد کنید"
                };
            }

            Singers singer = new Singers()
            {
                FullName = FullName,
            };
            _context.Singers.Add(singer);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = " هنرمند با موفقیت اضافه شد"
            };
        }
    }
}
