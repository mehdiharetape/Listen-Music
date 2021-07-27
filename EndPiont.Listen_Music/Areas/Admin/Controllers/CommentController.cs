using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Songs.Queries.GetCommentForAdmin;
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
    public class CommentController : Controller
    {
        private readonly ISongFacade _songFacade;
        public CommentController(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }
        public IActionResult Index(string SearchKey, int page=1, int pageSize=10)
        {
            return View(_songFacade.GetCommentForAdminService.GetComments(SearchKey,page,pageSize).Data);
        }

        [HttpPost]
        public IActionResult Remove(long Id)
        {
            return Json(_songFacade.GetCommentForAdminService.RemoveComment(Id));
        }
    }
}
