#pragma checksum "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "228bd2199cc6e63491db39e90074e3b0ea0a16ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_View), @"mvc.1.0.view", @"/Views/Home/View.cshtml")]
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
#line 1 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/_ViewImports.cshtml"
using crudelicious;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/_ViewImports.cshtml"
using crudelicious.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"228bd2199cc6e63491db39e90074e3b0ea0a16ed", @"/Views/Home/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d1344efeabb6281de7249210f4b4c13df6c6eab", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dish>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral("\n<div class=\"text-center  mt-4\">\n    <div class=\"container px-4\">\n        <h1>");
#nullable restore
#line 9 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml"
       Write(Model.NameOfDish);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n        <h4>");
#nullable restore
#line 10 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml"
       Write(Model.ChefName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
        <div class=""row gx-5"">
            <div class=""col"">
                <h4 class=""d-flex justify-content-between ms-4""><a href=""/"">Home</a></h4>

                <div class=""p-3 border bg-light p-4 d-flex justify-content-start"">
                    <div>
                        <p>");
#nullable restore
#line 17 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml"
                      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                        <br>\n                        <p>Calories: ");
#nullable restore
#line 19 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml"
                                Write(Model.Calories);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                        <p>Tastiness: ");
#nullable restore
#line 20 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml"
                                 Write(Model.Tastiness);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n\n                    </div>\n\n                </div>\n                <div class=\"mt-3\">\n                    <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 777, "\"", 804, 2);
            WriteAttributeValue("", 784, "delete/", 784, 7, true);
#nullable restore
#line 26 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml"
WriteAttributeValue("", 791, Model.DishId, 791, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\n                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;\n                    <a class=\"btn btn-light\"");
            BeginWriteAttribute("href", " href=\"", 923, "\"", 949, 2);
            WriteAttributeValue("", 930, "/edit/", 930, 6, true);
#nullable restore
#line 28 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/crudelicious/Views/Home/View.cshtml"
WriteAttributeValue("", 936, Model.DishId, 936, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\n                </div>\n\n            </div>\n        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dish> Html { get; private set; }
    }
}
#pragma warning restore 1591