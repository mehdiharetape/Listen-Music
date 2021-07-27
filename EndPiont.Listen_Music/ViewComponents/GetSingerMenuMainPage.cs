using Listen_Music.Application.Services.Common.Queries.GetMemuItems;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetSingerMenuMainPage : ViewComponent
    {
        private readonly IGetMemuItemService _getMemuItemService;
        public GetSingerMenuMainPage(IGetMemuItemService getMemuItemService)
        {
            _getMemuItemService = getMemuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var singerItems = _getMemuItemService.Singer_Execute();

            return View(viewName: "GetSingerMenuMainPage", singerItems.Data);
        }
    }
}
