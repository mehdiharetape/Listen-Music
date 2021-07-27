using Listen_Music.Application.Services.Common.Queries.GetMemuItems;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetGenreMenuMainPage : ViewComponent
    {
        private readonly IGetMemuItemService _getMemuItemService;
        public GetGenreMenuMainPage(IGetMemuItemService getMemuItemService)
        {
            _getMemuItemService = getMemuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var genreItems = _getMemuItemService.Genre_Execute();

            return View(viewName: "GetGenreMenuMainPage", genreItems.Data);
        }
    }
}
