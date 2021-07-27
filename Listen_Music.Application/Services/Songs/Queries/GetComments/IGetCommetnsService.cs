using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetComments
{
    public interface IGetCommetnsService
    {
        ResultDTO<List<ResultCommentsDTO>> Execute(long Id);
    }

    public class GetCommetnsService : IGetCommetnsService
    {
        private readonly IDataBaseContext _context;
        public GetCommetnsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<ResultCommentsDTO>> Execute(long Id)
        {
            var comments = _context.Comments.OrderByDescending(c => c.Id).Where(c => c.SongId == Id)
                .Select(c => new ResultCommentsDTO 
                {
                    UserName = c.Username,
                    CommentText = c.CommentText,
                    InsertTime = c.InsertTime
                }).ToList();

            return new ResultDTO<List<ResultCommentsDTO>>()
            {
                Data = comments,
                IsSuccess = true,
                Message = ""
            };
        }
    }


    public class ResultCommentsDTO
    {
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
