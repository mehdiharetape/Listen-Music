using Listen_Music.Application.Services.Songs.Queries.GetPlayListForSite;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetPlayListOtherPages : ViewComponent
    {
        private readonly IGetPlayListForSiteService _getAllPlayListsService;
        public GetPlayListOtherPages(IGetPlayListForSiteService getAllPlayListsService)
        {
            _getAllPlayListsService = getAllPlayListsService;
        }

        public IViewComponentResult Invoke()
        {
            var playlists = _getAllPlayListsService.Execute();
            return View(viewName: "GetPlayListOtherPages", playlists.Data);
        }
    }
}
