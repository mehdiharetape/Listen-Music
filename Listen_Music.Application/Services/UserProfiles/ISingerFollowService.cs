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
    public interface ISingerFollowService
    {
        ResultDTO FollowSinger(long SingerId, long UserId);
        ResultDTO UnFollowSinger(long SingerId, long UserId);
        ResultDTO<UserSingerFollowDTO> GetSingersFollowed(long? UserId);
    }

    public class SingerFollowService : ISingerFollowService
    {
        private readonly IDataBaseContext _context;
        public SingerFollowService(IDataBaseContext context)
        {
            _context = context;
        }

        //--------------------------------------------------
        public ResultDTO FollowSinger(long SingerId, long UserId)
        {
            var singerFollow = _context.UserSingerFollows.Where(u => u.UserId == UserId).FirstOrDefault();
            if(singerFollow == null)
            {
                UserSingerFollow newSingerFollow = new UserSingerFollow()
                {
                    UserId = UserId
                };

                _context.UserSingerFollows.Add(newSingerFollow);
                _context.SaveChanges();
                singerFollow = newSingerFollow;
            }

            var singer = _context.Singers.Find(SingerId);
            var singerItem = _context.SingerFollowItems.Include(p => p.IsRemoved).
                Where(p => p.SingersId == SingerId && p.UserSingerFollowId == singerFollow.Id);


            SingerFollowItem singerFollowItem = new SingerFollowItem()
            {
                UserSingerFollow = singerFollow,
                SingerName = singer.FullName,
                Singers = singer
            };
            _context.SingerFollowItems.Add(singerFollowItem);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = $"{singer.FullName} دنبال شد"
            };
        }

        //--------------------------------------------------
        public ResultDTO<UserSingerFollowDTO> GetSingersFollowed(long? UserId)
        {
            //var user = _context.Users.Find(UserId);

            //var singerFollows = _context.UserSingerFollows
            //    .Include(u => u.singerFollowItems)
            //    .ThenInclude(u => u.Singers)
            //    .Where(u => u.UserId == UserId)
            //    .OrderByDescending(u => u.Id).FirstOrDefault();

            var user = _context.Users.Find(UserId);
            var userFollow = _context.UserSingerFollows.Where(u => u.UserId == user.Id).FirstOrDefault();


            if (userFollow == null)
            {
                UserSingerFollow userSinger = new UserSingerFollow()
                {
                    User = user,
                    UserId = user.Id
                };
                _context.UserSingerFollows.Add(userSinger);
                _context.SaveChanges();
            }

            //if (UserId != null)
            //{
            //    var user = _context.Users.Find(UserId);
            //    var userFollow = _context.UserSingerFollows.Find(user.Id);
            //    userFollow.User = user;
            //    _context.SaveChanges();
            //}

            var singerFollows = _context.UserSingerFollows
                    .Include(u => u.singerFollowItems)
                    .ThenInclude(u => u.Singers)
                    .Where(u => u.UserId == UserId)
                    .OrderByDescending(u => u.Id).FirstOrDefault();

            return new ResultDTO<UserSingerFollowDTO>()
            {
                Data = new UserSingerFollowDTO()
                {
                    singerFollows = singerFollows.singerFollowItems.Select(u => new SingerFollowItemDTO
                    {
                        SingerName = u.Singers.FullName,
                        SingerId = u.Singers.Id,
                        IsRemoved = u.IsRemoved

                    }).ToList(),
                },
                IsSuccess = true,
                Message = ""
            };
        }

        //--------------------------------------------------
        public ResultDTO UnFollowSinger(long SingerId, long UserId)
        {
            var singerItem = _context.SingerFollowItems
                .Where(s => s.UserSingerFollow.UserId == UserId && s.SingersId==SingerId).FirstOrDefault();

            if (singerItem != null)
            {
                singerItem.IsRemoved = true;
                singerItem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = $"حذف شد"
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

    public class UserSingerFollowDTO
    {
        public List<SingerFollowItemDTO> singerFollows { get; set; }
    }
    public class SingerFollowItemDTO
    {
        public string Singer { get; set; }
        public string SingerName { get; set; }
        public long SingerId { get; set; }
        public bool IsRemoved { get; set; }
    }
}
