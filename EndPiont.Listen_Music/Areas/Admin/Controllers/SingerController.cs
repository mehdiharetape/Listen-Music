using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Songs.Commands.AddNewSinger;
using Listen_Music.Application.Services.Songs.Commands.EditSinger;
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
    public class SingerController : Controller
    {
        private readonly ISongFacade _songFacade;
        public SingerController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }
        public IActionResult Index(string SearchKey, int page=1,int pageSize=10)
        {
            return View(_songFacade.GetSingersService.Execute(SearchKey,page, pageSize).Data);
        }

        [HttpGet]
        public IActionResult AddSinger()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSinger(string FullName)
        {
            var result = _songFacade.AddNewSingerService.Execute(FullName);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_songFacade.RemoveSingerService.Execute(Id));
        }

        [HttpPost]
        public IActionResult Edit(long Id, string Name)
        {
            return Json(_songFacade.EditSingerService.Execute(new RequestEditSingerDTO 
            {
                Id = Id,
                Name = Name
            }));
        }
    }
}
