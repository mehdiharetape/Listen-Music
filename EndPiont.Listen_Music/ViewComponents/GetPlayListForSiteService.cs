using Listen_Music.Application.Services.Songs.Queries.GetAllPlayLists;
using Listen_Music.Application.Services.Songs.Queries.GetPlayListForSite;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetPlayListForSiteService : ViewComponent
    {
        private readonly IGetPlayListForSiteService _getAllPlayListsService;
        public GetPlayListForSiteService(IGetPlayListForSiteService getAllPlayListsService)
        {
            _getAllPlayListsService = getAllPlayListsService;
        }

        public IViewComponentResult Invoke()
        {
            var playLists = _getAllPlayListsService.Execute();
            return View(viewName: "GetPlayListForSiteService", playLists.Data);
        }
    }
}
