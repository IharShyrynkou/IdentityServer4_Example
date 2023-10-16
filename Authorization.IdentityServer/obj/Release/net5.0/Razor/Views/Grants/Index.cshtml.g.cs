#pragma checksum "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0ff083b3e55e96878a9aaf10bccd8b94a1cd6b4ea0472da140393ff396202c81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Grants_Index), @"mvc.1.0.view", @"/Views/Grants/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0ff083b3e55e96878a9aaf10bccd8b94a1cd6b4ea0472da140393ff396202c81", @"/Views/Grants/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"bedd53a138b069785550fa10c8b08d3652affa513a594c43af8203f4666e40ff", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Grants_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Authorization.IdentityServer.Grants.GrantsViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Revoke", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"grants-page\">\r\n    <div class=\"lead\">\r\n        <h1>Client Application Permissions</h1>\r\n    </div>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml"
     if (Model.Users.Any() == false)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-sm-8\">\r\n                <div class=\"alert alert-info\">\r\n                    There is no users\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 17 "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml"
    }
    else
    {
        foreach (var user in Model.Users)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\">\r\n                <div class=\"card-header\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-sm-8 card-title\">\r\n                            <strong>Username: ");
#nullable restore
#line 26 "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml"
                                         Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                        </div>\r\n\r\n                        <div class=\"col-sm-2\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ff083b3e55e96878a9aaf10bccd8b94a1cd6b4ea0472da140393ff396202c815029", async() => {
                WriteLiteral("\r\n\t                            <input type=\"hidden\" name=\"clientId\"");
                BeginWriteAttribute("value", " value=\"", 956, "\"", 972, 1);
#nullable restore
#line 31 "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml"
WriteAttributeValue("", 964, user.Id, 964, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <button class=\"btn btn-danger\">Revoke Access</button>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                \r\n                <ul class=\"list-group list-group-flush\">\r\n");
#nullable restore
#line 39 "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml"
                     if (user.UserName != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item\">\r\n                            <label>Is Activated:</label> ");
#nullable restore
#line 42 "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml"
                                                    Write(user.EmailConfirmed);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </li>   \r\n");
#nullable restore
#line 44 "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml"
                    }


#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n");
#nullable restore
#line 81 "C:\Users\Ihar\Documents\Sources\Authorization-Exercises\Exercises\Authorization.IdentityServer\Views\Grants\Index.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Authorization.IdentityServer.Grants.GrantsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591