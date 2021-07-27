using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Songs.Queries.GetSongsOfPlayList;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Controllers
{
    public class PlayListController : Controller
    {
        private readonly ISongFacade _songFacade;
        public PlayListController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }
        public IActionResult Index(long Id, int page=1, int pageSize=12)
        {
            return View(_songFacade.GetSongsOfPlayListService.GetExecute(Id,page,pageSize).Data);
        }


    }
}
