using EndPiont.Listen_Music.Utilities;
using Listen_Music.Application.Services.UserProfiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Controllers
{
    public class FollowController : Controller
    {
        private readonly ISingerFollowService _singerFollow;
        private readonly IGenreFollowService _genreFollow;
        private readonly IPlayListFollowService _playListFollow;
        CoockieManager _coockieManager;
        public FollowController(ISingerFollowService singerFollow, IGenreFollowService genreFollow,
            IPlayListFollowService playListFollow)
        {
            _singerFollow = singerFollow;
            _genreFollow = genreFollow;
            _playListFollow = playListFollow;
            _coockieManager = new CoockieManager();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        //---------------singer-----------------------

        public IActionResult FollowSinger(long SingerId)
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            var result = _singerFollow.FollowSinger(SingerId, userId);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveSinger(long SingerId)
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            _singerFollow.UnFollowSinger(SingerId, userId);
            return RedirectToAction("Index");
        }

        //------------genre-------------------------------
        public IActionResult FollowGenre(long GenreId)
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            var result = _genreFollow.FollowGenre(GenreId, userId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveGenre(long GenreId)
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            _genreFollow.UnFollowGenre(GenreId, userId);
            return RedirectToAction("Index");
        }

        //--------------------playlist--------------------
        public IActionResult FollowPlayList(long PlayListId)
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            var result = _playListFollow.FollowPlayList(PlayListId, userId);
            return RedirectToAction("Index");
        }

        public IActionResult RemovePlayList(long PlayListId)
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            var result = _playListFollow.UnFollowPlayList(PlayListId, userId);
            return RedirectToAction("Index");
        }
    }
}
