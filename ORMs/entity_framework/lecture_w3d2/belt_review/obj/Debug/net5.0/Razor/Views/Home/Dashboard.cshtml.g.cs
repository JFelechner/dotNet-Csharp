#pragma checksum "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd6b416e5674518a3920488efca33cfd6644613f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
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
#line 1 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/_ViewImports.cshtml"
using belt_review;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/_ViewImports.cshtml"
using belt_review.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd6b416e5674518a3920488efca33cfd6644613f", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33737a5ab841cb2842b12761c44fe85d40c41f07", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Welcome ");
#nullable restore
#line 1 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
       Write(ViewBag.LoggedInUser.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h1>\n<h2>Your Products</h2>\n<div class=\"d-flex flex-wrap\">\n");
#nullable restore
#line 4 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
      
        foreach (Product p in ViewBag.LoggedInUser.Inventory)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\" style=\"width: 18rem;\">\n                <img");
            BeginWriteAttribute("src", " src=\"", 251, "\"", 267, 1);
#nullable restore
#line 8 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 257, p.Picture, 257, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 289, "\"", 309, 1);
#nullable restore
#line 8 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 295, p.ProductName, 295, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <div class=\"card-body\">\n                    <h5 class=\"card-title\"><a");
            BeginWriteAttribute("href", " href=\"", 397, "\"", 425, 2);
            WriteAttributeValue("", 404, "/Product/", 404, 9, true);
#nullable restore
#line 10 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 413, p.ProductId, 413, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 10 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                                                                      Write(p.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\n                    <p class=\"card-text\">$");
#nullable restore
#line 11 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                                     Write(p.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 12 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                      
                        if (p.Quantity > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"card-text\">In stock: ");
#nullable restore
#line 15 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                                                      Write(p.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 16 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"card-text text-danger\">NO STOCK</p>\n");
#nullable restore
#line 20 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 899, "\"", 932, 2);
            WriteAttributeValue("", 906, "/Product/Edit/", 906, 14, true);
#nullable restore
#line 22 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 920, p.ProductId, 920, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Edit</a>\n                    <a");
            BeginWriteAttribute("href", " href=\"", 986, "\"", 1021, 2);
            WriteAttributeValue("", 993, "/Product/Delete/", 993, 16, true);
#nullable restore
#line 23 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1009, p.ProductId, 1009, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a>\n                </div>\n            </div>\n");
#nullable restore
#line 26 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
        }

    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n<hr>\n<h2>Your Orders</h2>\n<div class=\"d-flex flex-wrap\">\n");
#nullable restore
#line 33 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
      
        foreach (Order p in ViewBag.LoggedInUser.MyOrders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\" style=\"width: 18rem;\">\n                <img");
            BeginWriteAttribute("src", " src=\"", 1329, "\"", 1353, 1);
#nullable restore
#line 37 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1335, p.Product.Picture, 1335, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 1375, "\"", 1403, 1);
#nullable restore
#line 37 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1381, p.Product.ProductName, 1381, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <div class=\"card-body\">\n                    <h5 class=\"card-title\"><a");
            BeginWriteAttribute("href", " href=\"", 1491, "\"", 1519, 2);
            WriteAttributeValue("", 1498, "/Product/", 1498, 9, true);
#nullable restore
#line 39 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1507, p.ProductId, 1507, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 39 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                                                                      Write(p.Product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\n                    <p class=\"card-text\">Order total: $");
#nullable restore
#line 40 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                                                   Write(p.Product.Price*p.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                    <p class=\"card-text\">Ordered: ");
#nullable restore
#line 41 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
                                             Write(p.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                </div>\n            </div>\n");
#nullable restore
#line 44 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/ORMs/entity_framework/lecture_w3d2/belt_review/Views/Home/Dashboard.cshtml"
        }

    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
