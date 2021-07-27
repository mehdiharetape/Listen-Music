using Listen_Music.Application.Services.Common.Queries.GetMemuItems;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetGenreMenuOtherPages : ViewComponent
    {
        private readonly IGetMemuItemService _getMemuItemService;
        public GetGenreMenuOtherPages(IGetMemuItemService getMemuItemService)
        {
            _getMemuItemService = getMemuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var genres = _getMemuItemService.Genre_Execute();
            return View(viewName: "GetGenreMenuOtherPages", genres.Data);
        }
    }
}
