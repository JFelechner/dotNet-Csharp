#pragma checksum "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/Home/Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "315ba921249c8e1127baba19705d447da0eb1ae0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Success), @"mvc.1.0.view", @"/Views/Home/Success.cshtml")]
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
#line 1 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/_ViewImports.cshtml"
using form_submission;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/_ViewImports.cshtml"
using form_submission.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"315ba921249c8e1127baba19705d447da0eb1ae0", @"/Views/Home/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d104392b084733e1b618485596508f5ff84f84ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
#nullable restore
#line 3 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/Home/Success.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral(@"
<div class=""text-center"">
    <div class=""container px-4"">
        <div class=""row gx-5"">
            <div class=""col"">
                <div class=""p-3 border bg-light"">

                    <h1>Successfully Registered!</h1>

                        <div class=""mb-3"">
                            <label for=""userFirstName"" class=""form-label"">First Name:  ");
#nullable restore
#line 18 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/Home/Success.cshtml"
                                                                                  Write(Model.userFirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n\n                        </div>\n                        <div class=\"mb-3\">\n                            <label for=\"userLastName\" class=\"form-label\">Last Name:  ");
#nullable restore
#line 22 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/Home/Success.cshtml"
                                                                                Write(Model.userLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n\n                        </div>\n                        <div class=\"mb-3\">\n                            <label for=\"userAge\" class=\"form-label\">Age:  ");
#nullable restore
#line 26 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/Home/Success.cshtml"
                                                                     Write(Model.userAge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n\n                        </div>\n\n                        <div class=\"mb-3\">\n                            <label for=\"userEmail\" class=\"form-label\">Email Address:  ");
#nullable restore
#line 31 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/Home/Success.cshtml"
                                                                                 Write(Model.userEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n\n                        </div>\n                        <div class=\"mb-3\">\n                            <label for=\"userPassword\" class=\"form-label\">Password  ");
#nullable restore
#line 35 "/Users/jfelechner/Personal Douments/Schooling/Coding Dojo/dojo_assignments/c#/asp_dotNet_core/asp_mvc2/form_submission/Views/Home/Success.cshtml"
                                                                              Write(Model.userPassword);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n\n                        </div>\n\n                </div>\n            </div>\n        </div>\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591