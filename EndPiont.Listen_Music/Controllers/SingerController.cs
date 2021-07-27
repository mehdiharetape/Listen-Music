using Listen_Music.Application.Interfaces.FacadePatterns;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Controllers
{
    public class SingerController : Controller
    {
        private readonly ISongFacade _songFacade;
        public SingerController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }
        public IActionResult Index(long Id, int page=1, int pageSize=12)
        {
            return View(_songFacade.GetSongOfSingerService.GetExecute(Id, page,pageSize).Data);
        }

        
    }
}
