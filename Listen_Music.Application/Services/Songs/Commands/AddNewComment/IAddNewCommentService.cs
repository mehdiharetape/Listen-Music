using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Listen_Music.Domain.Entities.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.AddNewComment
{
    public interface IAddNewCommentService
    {
        ResultDTO AddNewComment(RequestAddNewCommentDTO request);
    }

    public class AddNewCommentService : IAddNewCommentService
    {
        private readonly IDataBaseContext _context;
        public AddNewCommentService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO AddNewComment(RequestAddNewCommentDTO request)
        {
            try
            {
                var song = _context.Songs.Find(request.Id);

                if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.CommentText)
                    || string.IsNullOrWhiteSpace(request.UserName))
                {
                    return new ResultDTO
                    {
                        IsSuccess = false,
                        Message = "تمام مشخصات را وارد کنید"
                    };
                }

                Comment comment = new Comment()
                {
                    Song = song,
                    Email = request.Email,
                    Username = request.UserName,
                    CommentText = request.CommentText,
                    InsertTime = request.InserTime
                };

                _context.Comments.Add(comment);
                _context.SaveChanges();

                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "نظر شما ارسال شد"
                };
            }
            catch(Exception e)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد"
                };
            }
        }
    }

    public class RequestAddNewCommentDTO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string  Email { get; set; }
        public string CommentText { get; set; }
        public DateTime InserTime { get; set; }
    }   
}
