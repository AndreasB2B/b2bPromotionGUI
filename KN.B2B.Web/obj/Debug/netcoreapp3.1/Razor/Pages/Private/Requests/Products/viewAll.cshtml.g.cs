#pragma checksum "F:\Github_Repositories\b2bPromotionGUI\KN.B2B.Web\Pages\Private\Requests\Products\viewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f155e96884f777986ad8d0fb7d669ae1fc7c45d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(KN.B2B.Web.Pages.Private.Requests.Products.Pages_Private_Requests_Products_viewAll), @"mvc.1.0.razor-page", @"/Pages/Private/Requests/Products/viewAll.cshtml")]
namespace KN.B2B.Web.Pages.Private.Requests.Products
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
#line 1 "F:\Github_Repositories\b2bPromotionGUI\KN.B2B.Web\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Github_Repositories\b2bPromotionGUI\KN.B2B.Web\Pages\_ViewImports.cshtml"
using KN.B2B.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Github_Repositories\b2bPromotionGUI\KN.B2B.Web\Pages\_ViewImports.cshtml"
using KN.B2B.Web.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f155e96884f777986ad8d0fb7d669ae1fc7c45d", @"/Pages/Private/Requests/Products/viewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"239a6fcdf56edb1fc3e6c31ec897b80ee1285793", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Private_Requests_Products_viewAll : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "F:\Github_Repositories\b2bPromotionGUI\KN.B2B.Web\Pages\Private\Requests\Products\viewAll.cshtml"
  
    ViewData["Title"] = "View All Products";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>All Products</h1>

<table class=""table table-striped"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">First</th>
            <th scope=""col"">Last</th>
            <th scope=""col"">Handle</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <th scope=""row"">1</th>
            <td>Mark</td>
            <td>Otto</td>
            <td>mdo</td>
        </tr>
        <tr>
            <th scope=""row"">2</th>
            <td>Jacob</td>
            <td>Thornton</td>
            <td>fat</td>
        </tr>
        <tr>
            <th scope=""row"">3</th>
            <td>Larry</td>
            <td>the Bird</td>
            <td>twitter</td>
        </tr>
    </tbody>
</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KN.B2B.Web.Pages.Private.Requests.Products.viewAllModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KN.B2B.Web.Pages.Private.Requests.Products.viewAllModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KN.B2B.Web.Pages.Private.Requests.Products.viewAllModel>)PageContext?.ViewData;
        public KN.B2B.Web.Pages.Private.Requests.Products.viewAllModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
