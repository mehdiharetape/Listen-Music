using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Songs.Commands.AddNewComment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongFacade _songFacade;
        public SongController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }

        public IActionResult Index(long Id)
        {
            return View(_songFacade.GetSongDetailForSiteService.Execute(Id).Data);
        }


        public IActionResult AddNewComment(RequestAddNewCommentDTO request)
        {
            var comment = _songFacade.AddNewCommentService.AddNewComment(new RequestAddNewCommentDTO
            {
                Id = request.Id,
                CommentText = request.CommentText,
                Email = request.Email,
                UserName = request.UserName,
                InserTime = DateTime.Now
            });

            return View("GetComments");
        }


    }
}
