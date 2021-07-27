using EndPiont.Listen_Music.Utilities;
using Listen_Music.Application.Services.UserProfiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetSingerFollow : ViewComponent
    {
        private readonly ISingerFollowService _singerFollow;
        CoockieManager _coockieManager;

        public GetSingerFollow(ISingerFollowService singerFollow)
        {
            _singerFollow = singerFollow;
            _coockieManager = new CoockieManager();
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            var result = _singerFollow.GetSingersFollowed(userId);
            return View(viewName: "GetSingerFollow", result.Data);
        }
    }
}
