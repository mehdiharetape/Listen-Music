using EndPiont.Listen_Music.Utilities;
using Listen_Music.Application.Services.UserProfiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetPlayListFollow : ViewComponent
    {
        private readonly IPlayListFollowService _playListFollow;
        public GetPlayListFollow(IPlayListFollowService playListFollow)
        {
            _playListFollow = playListFollow;
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            var result = _playListFollow.GetPlayListFollowed(userId);
            return View(viewName: "GetPlayListFollow", result.Data);
        }
    }
}
