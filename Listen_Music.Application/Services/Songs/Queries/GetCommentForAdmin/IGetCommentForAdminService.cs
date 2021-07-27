using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Queries.GetCommentForAdmin
{
    public interface IGetCommentForAdminService
    {
        ResultDTO<Comment_ListDTO> GetComments(string SearchKey, int page = 1, int pageSize = 10);
        ResultDTO RemoveComment(long Id);
    }

    public class GetCommentForAdminService : IGetCommentForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetCommentForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<Comment_ListDTO> GetComments(string SearchKey, int page = 1, int pageSize = 10)
        {
            int rowCount = 0;
            var comments = _context.Comments.OrderByDescending(c => c.Id).Include(c => c.Song)
                .ToPaged(page, pageSize, out rowCount).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                comments = comments.Where(c => c.Song.Name.Contains(SearchKey) ||
                                    c.CommentText.Contains(SearchKey)).AsQueryable();
            }

            return new ResultDTO<Comment_ListDTO>()
            {
                Data = new Comment_ListDTO
                {
                    Comments = comments.Select(c => new CommentsDTO 
                    { 
                        Id = c.Id,
                        CommentText = c.CommentText,
                        songName = c.Song.Name
                    }).ToList(),
                    CurrentPage = page,
                    PageSize = pageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = ""
            };
        }

        public ResultDTO RemoveComment(long Id)
        {
            var comment = _context.Comments.Find(Id);

            if(comment == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "نظر یافت نشد"
                };
            }

            comment.RemoveTime = DateTime.Now;
            comment.IsRemoved = true;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "نظر حذف شد"
            };
        }
    }

    public class Comment_ListDTO
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<CommentsDTO> Comments { get; set; }
    }

    public class CommentsDTO
    {
        public long Id { get; set; }
        public string CommentText { get; set; }
        public string songName { get; set; }
    }
}
