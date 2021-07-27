using Listen_Music.Application.Services.Common.Queries.GetMemuItems;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.ViewComponents
{
    public class GetSingerMenuOtherPages : ViewComponent
    {
        private readonly IGetMemuItemService _getMemuItemService;
        public GetSingerMenuOtherPages(IGetMemuItemService getMemuItemService)
        {
            _getMemuItemService = getMemuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var singers = _getMemuItemService.Singer_Execute();
            return View(viewName: "GetSingerMenuOtherPages", singers.Data);
        }
    }
}
