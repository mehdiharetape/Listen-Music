using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.RemoveSinger
{
    public interface IRemoveSingerService
    {
        ResultDTO Execute(long Id);
    }

    public class RemoveSingerService : IRemoveSingerService
    {
        private readonly IDataBaseContext _context;
        public RemoveSingerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(long Id)
        {
            var singer = _context.Singers.Find(Id);
            if(singer == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "هنرمند یافت نشد"
                };
            }

            singer.RemoveTime = DateTime.Now;
            singer.IsRemoved = true;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "هنرمند حذف شد"
            };
        }
    }
}
