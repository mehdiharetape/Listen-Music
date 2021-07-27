using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Listen_Music.Domain.Entities.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.AddNewPlayList
{
    public interface IAddNewPlayListService
    {
        ResultDTO Execute(string Name);
    }

    public class AddNewPlayListService : IAddNewPlayListService
    {
        private readonly IDataBaseContext _context;
        public AddNewPlayListService(IDataBaseContext context)
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
                    Message = "لطفا نام لیست پخش را وارد کنید"
                };
            }

            PlayLists playLists = new PlayLists()
            {
                ListName = Name,
            };
            _context.PlayLists.Add(playLists);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "لیست پخش با موفقیت اضافه شد"
            };
        }
    }
}
