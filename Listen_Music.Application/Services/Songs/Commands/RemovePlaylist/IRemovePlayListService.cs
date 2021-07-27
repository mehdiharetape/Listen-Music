using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.RemovePlaylist
{
    public interface IRemovePlayListService
    {
        ResultDTO Execute(long Id);
    }

    public class RemovePlayListService : IRemovePlayListService
    {
        private readonly IDataBaseContext _context;
        public RemovePlayListService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(long Id)
        {
            var playlist = _context.PlayLists.Find(Id);
            if(playlist == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "لیست پخش یافت نشد"
                };
            }

            playlist.RemoveTime = DateTime.Now;
            playlist.IsRemoved = true;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "لیست پخش حذف شد"
            };
        }
    }

}
