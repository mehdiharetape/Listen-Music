using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Listen_Music.Domain.Entities.UserProfiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.UserProfiles
{
    public interface IGenreFollowService
    {
        ResultDTO FollowGenre(long GenreId, long UserId);
        ResultDTO UnFollowGenre(long GenreId, long UserId);
        ResultDTO<UserGenreFollowDTO> GetGenreFollowed(long? UserId);
    }
    public class GenreFollowService : IGenreFollowService
    {
        private readonly IDataBaseContext _context;
        public GenreFollowService(IDataBaseContext context)
        {
            _context = context;
        }
        //-----------------------------------
        public ResultDTO FollowGenre(long GenreId, long UserId)
        {
            var genreFollow = _context.UserGenreFollows.Where(u => u.UserId == UserId).FirstOrDefault();
            if(genreFollow == null)
            {
                UserGenreFollow newGenreFollow = new UserGenreFollow()
                {
                    UserId = UserId
                };
                _context.UserGenreFollows.Add(newGenreFollow);
                _context.SaveChanges();
                genreFollow = newGenreFollow;
            }

            var genre = _context.Genres.Find(GenreId);
            var genreItem = _context.GenreFollowItems
                .Where(g => g.GenreId == GenreId && g.UserGenreFollowId == genreFollow.Id);

            GenreFollowItems genreFollowItem = new GenreFollowItems()
            {
                UserGenreFollow = genreFollow,
                GenreName = genre.GenreName,
                Genre = genre
            };
            _context.GenreFollowItems.Add(genreFollowItem);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = $"{genre.GenreName} دنبال شد"
            };
        }
        //-------------------------------------------
        public ResultDTO<UserGenreFollowDTO> GetGenreFollowed(long? UserId)
        {
            var user = _context.Users.Find(UserId);
            var userFollow = _context.UserGenreFollows.Where(u => u.UserId == user.Id).FirstOrDefault();
            if(userFollow == null)
            {
                UserGenreFollow userGenreFollow = new UserGenreFollow()
                {
                    User = user, 
                    UserId = user.Id
                };
                _context.UserGenreFollows.Add(userGenreFollow);
                _context.SaveChanges();
            }

            var genreFollow = _context.UserGenreFollows
                .Include(g => g.GenreFollowItems)
                .ThenInclude(g => g.Genre)
                .Where(g => g.UserId == UserId).OrderByDescending(g => g.Id).FirstOrDefault();

            return new ResultDTO<UserGenreFollowDTO>()
            {
                Data = new UserGenreFollowDTO()
                {
                    GenreFollowItems = genreFollow.GenreFollowItems.Select(s => new GenreFollowItemsDTO
                    {
                        GenreId = s.Genre.Id,
                        GenreName = s.Genre.GenreName
                    }).ToList()
                },
                IsSuccess = true,
                Message = ""
            };
        }
        //-----------------------------------
        public ResultDTO UnFollowGenre(long GenreId, long UserId)
        {
            var genreItem = _context.GenreFollowItems
                .Where(g => g.UserGenreFollow.UserId == UserId && g.GenreId == GenreId).FirstOrDefault();

            if(genreItem != null)
            {
                genreItem.IsRemoved = true;
                genreItem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "حذف شد"
                };
            }
            else
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = $"یافت نشد"
                };
            }
        }
    }
    public class UserGenreFollowDTO
    {
        public List<GenreFollowItemsDTO> GenreFollowItems { get; set; } 
    }
    public class GenreFollowItemsDTO
    {
        public string GenreName { get; set; }
        public long GenreId { get; set; }
    } 
}
