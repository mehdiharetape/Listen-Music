using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Songs.Commands.EditPlaylist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PlayListController : Controller
    {
        private readonly ISongFacade _songFacade;
        public PlayListController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }
        public IActionResult Index(string SearchKey, int page=1, int pageSize=10)
        {
            return View(_songFacade.GetPlayListService.Execute(SearchKey,page, pageSize).Data);
        }

        [HttpGet]
        public IActionResult AddPlayList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayList(string Name)
        {
            var result = _songFacade.AddNewPlayListService.Execute(Name);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_songFacade.RemovePlayListService.Execute(Id));
        }

        public IActionResult Edit(long Id, string Name)
        {
            return Json(_songFacade.EditPlayListService.Execute(new RequestEditPlaylistDTO 
            {
                Id = Id,
                Name = Name
            }));
        }
    }
}
