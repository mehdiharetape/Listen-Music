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
    public interface IPlayListFollowService
    {
        ResultDTO FollowPlayList(long PlayListId, long UserId);
        ResultDTO UnFollowPlayList(long PlayListId, long UserId);
        ResultDTO<UserPlayListFollowDTO> GetPlayListFollowed(long UserId);
    }

    public class PlayListFollowService : IPlayListFollowService
    {
        private readonly IDataBaseContext _context;
        public PlayListFollowService(IDataBaseContext context)
        {
            _context = context;
        }
        //-----------------------------------
        public ResultDTO FollowPlayList(long PlayListId, long UserId)
        {
            var playlistFollow = _context.UserPlayListFollows.Where(p => p.UserId == UserId).FirstOrDefault();
            if(playlistFollow == null)
            {
                UserPlayListFollow newUserPlayList = new UserPlayListFollow()
                {
                     UserId = UserId
                };
                _context.UserPlayListFollows.Add(newUserPlayList);
                _context.SaveChanges();
                playlistFollow = newUserPlayList;
            }

            var playlist = _context.PlayLists.Find(PlayListId);
            var playlistItem = _context.PlayListFollowItems
                .Where(p => p.PlayListsId == PlayListId && p.UserPlayListFollowId == playlistFollow.Id);

            PlayListFollowItem playListFollowItem = new PlayListFollowItem()
            {
                UserPlayListFollow = playlistFollow,
                PlayListName = playlist.ListName,
                PlayLists = playlist,
            };
            _context.PlayListFollowItems.Add(playListFollowItem);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = $"{playlist.ListName} دنبال شد"
            };

        }
        //-----------------------------------
        public ResultDTO<UserPlayListFollowDTO> GetPlayListFollowed(long UserId)
        {
            var user = _context.Users.Find(UserId);
            var userFollow = _context.UserPlayListFollows.Where(u => u.UserId == user.Id).FirstOrDefault();

            if(userFollow == null)
            {
                UserPlayListFollow userPlayListFollow = new UserPlayListFollow()
                {
                    User = user,
                    UserId = user.Id
                };
                _context.UserPlayListFollows.Add(userPlayListFollow);
                _context.SaveChanges();
            }

            var playlistFollow = _context.UserPlayListFollows
                .Include(u => u.PlayListFollowItems)
                .ThenInclude(u => u.PlayLists)
                .Where(u => u.UserId == UserId).OrderByDescending(u => u.Id).FirstOrDefault();

            return new ResultDTO<UserPlayListFollowDTO>()
            {
                Data = new UserPlayListFollowDTO()
                {
                    playListFollowItems = playlistFollow.PlayListFollowItems.Select(p => new PlayListFollowItemDTO
                    {
                         PlayListName = p.PlayLists.ListName,
                         PlayListid = p.PlayLists.Id
                    }).ToList(),
                },
                IsSuccess = true,
                Message = ""
            };
        }
        //-----------------------------------
        public ResultDTO UnFollowPlayList(long PlayListId, long UserId)
        {
            var playlistItem = _context.PlayListFollowItems
                .Where(p => p.UserPlayListFollow.UserId == UserId && p.PlayListsId == PlayListId).FirstOrDefault();

            if(playlistItem != null)
            {
                playlistItem.IsRemoved = true;
                playlistItem.RemoveTime = DateTime.Now;
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

    public class UserPlayListFollowDTO
    {
        public List<PlayListFollowItemDTO> playListFollowItems { get; set; }
    }

    public class PlayListFollowItemDTO
    {
        public string PlayListName { get; set; }
        public long PlayListid { get; set; }
    }
}
