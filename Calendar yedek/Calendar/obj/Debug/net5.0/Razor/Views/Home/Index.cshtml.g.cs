#pragma checksum "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e34f15960da23a045370a182c0f00dcd98d524ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 4 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
using Calendar;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e34f15960da23a045370a182c0f00dcd98d524ea", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Google.Apis.Calendar.v3.Data.Event>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e34f15960da23a045370a182c0f00dcd98d524ea3160", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Index</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e34f15960da23a045370a182c0f00dcd98d524ea4219", async() => {
                WriteLiteral(@"
    <form method=""post"" enctype=""multipart/form-data"" asp-controller=""Home"" asp-action=""Index"">
        <table>
            <tr>
                <td>Toplantı Adı: </td>
                <td><input type=""text"" id=""toplantiAdi"" name=""toplantiAdi"" /></td>
            </tr>
            <tr>
                <td>Toplanti Açıklaması: </td>
                <td><input type=""text"" id=""aciklama"" name=""aciklama"" /></td>
            </tr>
            <tr>
                <td>Başlangıç Tarihi: </td>
                <td><input type=""datetime-local"" id=""baslangicTarihi"" name=""baslangicTarihi"" /></td>
            </tr>
            <tr>
                <td>Bitiş Tarihi: </td>
                <td><input type=""datetime-local"" id=""bitisTarihi"" name=""bitisTarihi"" /></td>
            </tr>
            <tr>
                <td></td>
                <td><input type=""submit"" name=""submitButton"" value=""Toplantı Oluştur"" /></td>
            </tr>
        </table>
        <hr />
        ");
#nullable restore
#line 42 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
   Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <hr />\r\n        <input type=\"submit\" name=\"submitButton\" value=\"Toplantı Listele\" />\r\n    </form>\r\n    \r\n");
#nullable restore
#line 47 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
     if(Model != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <table class=""table"">
        <tr>
            <th>
                Toplantı Adı
            </th>
            <th>
               Açıklama
            </th>
            <th>
                Başlangıç Tarihi
            </th>
            <th>
                Bitiş Tarihi
            </th>
        </tr>
");
#nullable restore
#line 64 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 68 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
           Write(item.Summary);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 71 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
           Write(item.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 74 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
           Write(item.Start.DateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 77 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
           Write(item.End.DateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 80 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </table>\r\n");
#nullable restore
#line 82 "C:\Users\mehme\source\repos\Calendar\Calendar\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Google.Apis.Calendar.v3.Data.Event>> Html { get; private set; }
    }
}
#pragma warning restore 1591
