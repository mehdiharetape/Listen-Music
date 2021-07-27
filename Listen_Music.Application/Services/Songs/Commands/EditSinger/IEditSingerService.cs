using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.EditSinger
{
    public interface IEditSingerService
    {
        ResultDTO Execute(RequestEditSingerDTO request);
    }

    public class EditSingerService : IEditSingerService
    {
        private readonly IDataBaseContext _context;
        public EditSingerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(RequestEditSingerDTO request)
        {
            var singer = _context.Singers.Find(request.Id);
            if (singer == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "هنرمند یافت نشد"
                };
            }

            singer.FullName = request.Name;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "هنرمند ویرایش شد"
            };
        }
    }

    public class RequestEditSingerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
