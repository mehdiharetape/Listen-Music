using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Songs.Commands.AddNewSong;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Listen_Music.Application.Services.Songs.Commands.EditSong;
using Microsoft.AspNetCore.Authorization;

namespace EndPiont.Listen_Music.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Artist")]
    public class SongController : Controller
    {
        private readonly ISongFacade _songFacade;

        public object HttpPostedFile { get; private set; }

        public SongController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }
        public IActionResult Index(string SearchKey, int page = 1, int pageSize = 10)
        {
            return View(_songFacade.GetSongForAdminService.Execute(SearchKey,page, pageSize).Data);
        }

        [HttpGet]
        public IActionResult AddNewSong()
        {
            ViewBag.Genres = new SelectList(_songFacade.GetAllGenresService.Execute().Data, "Id", "Name");
            ViewBag.PlayLists = new SelectList(_songFacade.GetAllPlayListsService.Execute().Data, "Id", "Name");
            ViewBag.Singers = new SelectList(_songFacade.GetAllSingersService.Execute().Data, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult AddNewSong(RequestAddNewSongDTO request)
        {

            for(int i = 0; i < Request.Form.Files.Count; i++)
            {
                IFormFile hpf = Request.Form.Files[i];
                string filename = hpf.FileName;
                string extension = Path.GetExtension(filename);

                if(extension == ".jpeg" || extension == ".png" || extension == ".jpg")
                {
                    request.ImageSrc = Request.Form.Files[i];
                }
                else
                {
                    request.SongSrc = Request.Form.Files[i];

                }
            }

            return Json(_songFacade.AddNewSongService.Execute(request));
        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_songFacade.RemoveSongService.Execute(Id));
        }

        [HttpPost]
        public IActionResult Edit(long Id, string Name, string Duration)
        {
            return Json(_songFacade.EditSongService.Execute(new RequestEditSongDTO 
            {
                Id = Id,
                Name = Name,
                Duration = Duration
            }));
        }


    }
}
