#pragma checksum "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79bb30780414df78cb959c2d7d85d14e2aea4b4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(KN.B2B.Web.Pages.Private.Masterdata.B2BCategories.Pages_Private_Masterdata_B2BCategories_Index), @"mvc.1.0.razor-page", @"/Pages/Private/Masterdata/B2BCategories/Index.cshtml")]
namespace KN.B2B.Web.Pages.Private.Masterdata.B2BCategories
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
#line 1 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\_ViewImports.cshtml"
using KN.B2B.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\_ViewImports.cshtml"
using KN.B2B.Web.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79bb30780414df78cb959c2d7d85d14e2aea4b4b", @"/Pages/Private/Masterdata/B2BCategories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"239a6fcdf56edb1fc3e6c31ec897b80ee1285793", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Private_Masterdata_B2BCategories_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "../Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
  
    ViewData["Title"] = "B2BCategories Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>B2B Categories</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79bb30780414df78cb959c2d7d85d14e2aea4b4b6160", async() => {
                WriteLiteral("\r\n        <i class=\"fa fa-plus\"></i>\r\n        Add new\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79bb30780414df78cb959c2d7d85d14e2aea4b4b7461", async() => {
                WriteLiteral("\r\n        <i class=\"fa fa-list\"></i>\r\n        Main\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.B2BCategories[0].Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.B2BCategories[0].Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.B2BCategories[0].CategoryDK));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Category Group\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 39 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
         foreach (var item in Model.B2BCategories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CategoryDK));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 52 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
                 if (item.CategoryGroup != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
               Write(item.CategoryGroup.CategoryGroup);

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
                                                     ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n\r\n            <td style=\"text-align:right\">\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79bb30780414df78cb959c2d7d85d14e2aea4b4b13117", async() => {
                WriteLiteral("\r\n                    <i class=\"fas fa-info-circle\"></i>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
                                                          WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79bb30780414df78cb959c2d7d85d14e2aea4b4b15565", async() => {
                WriteLiteral("\r\n                    <i class=\"fas fa-trash\"></i>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
                                                            WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 68 "C:\Users\Showroom\OneDrive - B2B Promotion ApS\Dokumenter\arbejde\apps\b2bpromotion-data-access\b2bpromotion-data-access\src\KN.B2B.Web\Pages\Private\Masterdata\B2BCategories\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KN.B2B.Web.Pages.Private.Masterdata.B2BCategories.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KN.B2B.Web.Pages.Private.Masterdata.B2BCategories.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KN.B2B.Web.Pages.Private.Masterdata.B2BCategories.IndexModel>)PageContext?.ViewData;
        public KN.B2B.Web.Pages.Private.Masterdata.B2BCategories.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
