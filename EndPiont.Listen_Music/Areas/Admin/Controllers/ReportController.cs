using Listen_Music.Application.Services.Common.Queries.GetReport;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IGetReportForAdmin _reportForAdmin;
        public ReportController(IGetReportForAdmin reportForAdmin)
        {
            _reportForAdmin = reportForAdmin;
        }
        public IActionResult Index()
        {
            return View(_reportForAdmin.Execute().Data);
        }
    }
}
