using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Songs.Commands.EditGenre;
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
    public class GenreController : Controller
    {
        private readonly ISongFacade _songFacade;
        public GenreController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }
        public IActionResult Index(string SearchKey ,int page = 1, int pageSize = 10)
        {
            return View(_songFacade.GetGenresService.Execute(SearchKey,page, pageSize).Data);
        }

        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGenre(string Name)
        {
            var result = _songFacade.AddNewGenreService.Execute(Name);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_songFacade.RemoveGenreService.Execute(Id));
        }

        [HttpPost]
        public IActionResult Edit(long Id,string Name)
        {
            return Json(_songFacade.EditGenreService.Execute(new RequestEditGenreDTO {
                Id = Id,
                Name = Name
            }));
        }
    }
}
