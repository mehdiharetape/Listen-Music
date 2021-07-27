
using Listen_Music.Application.Interfaces.FacadePatterns;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetRelatingSongs : ViewComponent
    {
        private readonly ISongFacade _songFacade;
        public GetRelatingSongs(ISongFacade songFacade)
        {
            _songFacade = songFacade;
        }

        public IViewComponentResult Invoke(long PlayListId)
        {
            var relatingSongs = _songFacade.GetRelatingSongService.Execute(PlayListId);
            return View(viewName: "GetRelatingSongs", relatingSongs.Data);
        }
    }
}
