using EndPiont.Listen_Music.Models;
using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Songs.Queries.GetSongForSite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISongFacade _songFacade;

        public HomeController(ILogger<HomeController> logger, ISongFacade songFacade)
        {
            _logger = logger;
            _songFacade = songFacade;
        }

        public IActionResult Index(string searchKey, int pagesize = 12,int page=1)
        {
            return View(_songFacade.GetSongForSiteService.Execute(searchKey,pagesize, page).Data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
