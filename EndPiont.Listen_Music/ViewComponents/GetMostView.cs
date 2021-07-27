using Listen_Music.Application.Services.Songs.Queries.GetMostView;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetMostView : ViewComponent
    {
        private readonly IGetMostViewService _getMostViewService;
        public GetMostView(IGetMostViewService getMostViewService)
        {
            _getMostViewService = getMostViewService;
        }

        public IViewComponentResult Invoke()
        {
            var mosview = _getMostViewService.Execute();
            return View(viewName: "GetMostView", mosview.Data);
        }
    }
}
