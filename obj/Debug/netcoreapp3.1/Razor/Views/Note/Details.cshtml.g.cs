#pragma checksum "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cb979752b4c8b68ada9f653b708f9a6fa071d48"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Note_Details), @"mvc.1.0.view", @"/Views/Note/Details.cshtml")]
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
#line 1 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\_ViewImports.cshtml"
using todonote;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\_ViewImports.cshtml"
using todonote.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cb979752b4c8b68ada9f653b708f9a6fa071d48", @"/Views/Note/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6415098cdfcdefceb17e774d29c936cd942ce3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Note_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<todonote.Models.Note>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml"
  
    ViewData["Title"] = "Details Note";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n  <thead class=\"thead-dark\">\r\n    <tr>\r\n      <th>\r\n        ");
#nullable restore
#line 12 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      </th>\r\n      <th>\r\n        ");
#nullable restore
#line 15 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      </th>\r\n      <th>\r\n        ");
#nullable restore
#line 18 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      </th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n      <td>");
#nullable restore
#line 24 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml"
     Write(Model.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 25 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml"
     Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 26 "C:\Users\Pham Trung Truong\source\repos\todonote\Views\Note\Details.cshtml"
     Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n  </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<todonote.Models.Note> Html { get; private set; }
    }
}
#pragma warning restore 1591