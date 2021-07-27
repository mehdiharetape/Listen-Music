using EndPiont.Listen_Music.Utilities;
using Listen_Music.Application.Services.UserProfiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetGenreFollow : ViewComponent
    {
        private readonly IGenreFollowService _genreFollow;
        public GetGenreFollow(IGenreFollowService genreFollow)
        {
            _genreFollow = genreFollow;
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            var result = _genreFollow.GetGenreFollowed(userId);
            return View(viewName: "GetGenreFollow", result.Data);
        }
    }
}
