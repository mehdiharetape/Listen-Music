#pragma checksum "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e898e8a7c4e9fd02c4cf84ff1082563504694d7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Report_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Report/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
using Listen_Music.Application.Services.Common.Queries.GetReport;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e898e8a7c4e9fd02c4cf84ff1082563504694d7c", @"/Areas/Admin/Views/Report/Index.cshtml")]
    public class Areas_Admin_Views_Report_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReportDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"singer-list-container\" class=\"singer-genre-list-contaier\">\r\n    <h1>آمار سایت</h1>\r\n\r\n    <table id=\"report-list\" class=\"table-genre-singer\">\r\n        <tr>\r\n            <td>تعداد کل کاربران</td>\r\n            <td>");
#nullable restore
#line 13 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
           Write(Model.UserCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>تعداد کاربران ادمین</td>\r\n            <td>");
#nullable restore
#line 18 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
           Write(Model.AdminUserCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>تعداد کاربران عادی</td>\r\n            <td>");
#nullable restore
#line 23 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
           Write(Model.NormalUserCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>تعداد کاربران هنرمند</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
           Write(Model.ArtistsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>تعداد کل آهنگ ها</td>\r\n            <td>");
#nullable restore
#line 33 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
           Write(Model.SongsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>تعداد خوانندگان</td>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
           Write(Model.SingersCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>تعداد سبک ها</td>\r\n            <td>");
#nullable restore
#line 43 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
           Write(Model.GenresCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>تعداد لیست پخش ها</td>\r\n            <td>");
#nullable restore
#line 48 "C:\Users\daya\source\repos\Listen_Music\EndPiont.Listen_Music\Areas\Admin\Views\Report\Index.cshtml"
           Write(Model.playListsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n    </table>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReportDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
