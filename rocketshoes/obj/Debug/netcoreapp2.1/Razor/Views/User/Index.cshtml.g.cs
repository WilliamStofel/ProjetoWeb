#pragma checksum "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0dab0decd8689a799f9bdf3a82ede53d2b0508e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Index.cshtml", typeof(AspNetCore.Views_User_Index))]
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
#line 1 "E:\rocketshoes-csharp\rocketshoes\Views\_ViewImports.cshtml"
using rocketshoes;

#line default
#line hidden
#line 2 "E:\rocketshoes-csharp\rocketshoes\Views\_ViewImports.cshtml"
using rocketshoes.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0dab0decd8689a799f9bdf3a82ede53d2b0508e1", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2b1914db97f28121d9492ba80d8e4710ef8ce75", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<UserViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(82, 230, true);
            WriteLiteral("\r\n<h2>Listagem de Usuários</h2>\r\n\r\n<a href=\"/user/create\">Novo Registro</a>\r\n<br />\r\n\r\n<table class=\"table table-responsive\">\r\n    <tr>\r\n        <th>Ações</th>\r\n        <th>ID</th>\r\n        <th>Nome</th>\r\n        <th>E-mail</th>\r\n");
            EndContext();
            BeginContext(343, 13, true);
            WriteLiteral("    </tr>\r\n\r\n");
            EndContext();
#line 20 "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml"
     foreach (var user in Model)
    {

#line default
#line hidden
            BeginContext(397, 50, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 447, "\"", 476, 2);
            WriteAttributeValue("", 454, "/user/Edit?id=", 454, 14, true);
#line 24 "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml"
WriteAttributeValue("", 468, user.Id, 468, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(477, 31, true);
            WriteLiteral(">Editar</a>\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 508, "\"", 546, 3);
            WriteAttributeValue("", 515, "javascript:deleteUser(", 515, 22, true);
#line 25 "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml"
WriteAttributeValue("", 537, user.Id, 537, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 545, ")", 545, 1, true);
            EndWriteAttribute();
            BeginContext(547, 48, true);
            WriteLiteral(">Apagar</a>\r\n            </td>\r\n            <td>");
            EndContext();
            BeginContext(596, 7, false);
#line 27 "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml"
           Write(user.Id);

#line default
#line hidden
            EndContext();
            BeginContext(603, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(627, 9, false);
#line 28 "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml"
           Write(user.Name);

#line default
#line hidden
            EndContext();
            BeginContext(636, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(660, 10, false);
#line 29 "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml"
           Write(user.Email);

#line default
#line hidden
            EndContext();
            BeginContext(670, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
            BeginContext(883, 15, true);
            WriteLiteral("        </tr>\r\n");
            EndContext();
#line 39 "E:\rocketshoes-csharp\rocketshoes\Views\User\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(905, 181, true);
            WriteLiteral("</table>\r\n\r\n<script>\r\n    function deleteUser(id) {\r\n        if (confirm(\'Confirma a exclusão do registro?\'))\r\n            location.href = \'/user/Delete?id=\' + id;\r\n    }\r\n</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<UserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
