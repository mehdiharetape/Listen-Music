
using Listen_Music.Application.Interfaces.FacadePatterns;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Controllers
{
    public class GenreController : Controller
    {
        private readonly ISongFacade _songFacade;
        public GenreController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }
        public IActionResult Index(long Id, int page=1, int pageSize=12)
        {
            return View(_songFacade.GetSongOfGenreService.GetExecute(Id,page,pageSize).Data);
        }
    }
}
