using Listen_Music.Application.Interfaces.FacadePatterns;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetComments : ViewComponent
    {
        private readonly ISongFacade _songFacade;
        
        public GetComments(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }

        public IViewComponentResult Invoke(long Id)
        {
            var comment = _songFacade.GetCommetnsService.Execute(Id);
            return View(viewName: "GetComments", comment.Data);
        }
    }
}
