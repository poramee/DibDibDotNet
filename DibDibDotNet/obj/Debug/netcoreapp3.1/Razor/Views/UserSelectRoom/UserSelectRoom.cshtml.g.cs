#pragma checksum "/Users/poramee/Documents/SW Studio Web/DibDibDotNet/DibDibDotNet/Views/UserSelectRoom/UserSelectRoom.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b9d4092fcca44acdc67aa8a2b3dc366ddd8bd32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserSelectRoom_UserSelectRoom), @"mvc.1.0.view", @"/Views/UserSelectRoom/UserSelectRoom.cshtml")]
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
#line 1 "/Users/poramee/Documents/SW Studio Web/DibDibDotNet/DibDibDotNet/Views/_ViewImports.cshtml"
using DibDibDotNet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/poramee/Documents/SW Studio Web/DibDibDotNet/DibDibDotNet/Views/_ViewImports.cshtml"
using DibDibDotNet.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b9d4092fcca44acdc67aa8a2b3dc366ddd8bd32", @"/Views/UserSelectRoom/UserSelectRoom.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f63ecd175b04eb05fc3b9e02dadc91fe111e256", @"/Views/_ViewImports.cshtml")]
    public class Views_UserSelectRoom_UserSelectRoom : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("month-sel"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/action_page.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("BGG unselectable"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/html"">
    <header>
        <title>User</title>
        <link rel=""stylesheet"" href=""https://fonts.googleapis.com/icon?family=Material+Icons"">
        <link href=""https://fonts.googleapis.com/css?family=Prompt"" rel=""stylesheet"">
        <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet'>
        <link rel=""stylesheet"" href=""https://www.w3schools.com/w3css/4/w3.css"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
        <link rel=""stylesheet"" href=""/css/template/Global.css""> <!-- change -> /template/Global.css  -->
        <link rel=""stylesheet"" href=""/css/UserSelectRoom/userSelectRoom.css""> <!-- Edit name for import Css of this document -->
    </header>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b9d4092fcca44acdc67aa8a2b3dc366ddd8bd325629", async() => {
                WriteLiteral(@"
        <div class=""topnav"">
            <div class=""right"">
                <a href=""#""><i class=""material-icons md-20 rc-Muted "">refresh</i></a>
                <a href=""#""><i class=""material-icons md-20 rc-Muted "">add_shopping_cart</i><mark class=""noti-cart Label ENG rc-Bright"">30</mark></a>
                <p class=""ParagraphX2 ENG rc-Muted"" href=""#"">Quota: 4</p>
                <a href=""#""><i class=""material-icons md-20 rc-Success "">account_circle</i></a>
               <!-- <a id=""checkLogout"" onclick=""logout()""class=""ParagraphX2 ENG rc-Muted"" href=""../LoginSignup/Login.html"">Logout</a>-->
            </div>
        </div>
        <div class=""room-name"">
            <div class=""left"">
                <a href=""#""><i class="" icon-back material-icons md-24 rc-Primary "">arrow_back</i></a>
                <p class=""HeadingX6 ENG rc-Primary in-line "" href=""#""><b>ECC-602</b></p>
                <p class=""ParagraphX1 ENG rc-Primary in-line li-hi"" >STM32-nucleo f767zi</p>
            </div>
            
       ");
                WriteLiteral(" </div>\n        <!-- righ -->\n        <div class=\"contain-col-2-history \">\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b9d4092fcca44acdc67aa8a2b3dc366ddd8bd327076", async() => {
                    WriteLiteral(@"
                <input class=""calendar ParagraphX1 ENG rc-Primary"" type=""month"" id=""monthUser"" name=""monthUser"">
                <div class=""right update-text "">
                    <p class=""ParagraphX1 TH rc-Primary a-right"">จำนวนเครื่องทั้งหมด : 50 เครื่อง <br>อัปเดตล่าสุด : 6 / 01 / 2021  10.00น.</p>
                </div>
            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            <div  class=""scroll-table"" >
                <div class=""container-table "">
                    <table class=""w3-table w3-bordered w3-centered""  >
                        <thead class=""hd-table "">
                            <tr >
                                <th><p class=""ParagraphX1 TH rc-Primary in-line"">วัน/เวลา</p></th>
                                <th><p class=""ParagraphX1 TH rc-Primary in-line "">9:00 น</p></th>
                                <th><p class=""ParagraphX1 TH rc-Primary in-line"">10.00 น.</p></th>
                                <th><p class=""ParagraphX1 TH rc-Primary in-line"">11.00 น.</p></th>
                                <th><p class=""ParagraphX1 TH rc-Primary in-line"">12.00 น.</p></th>
                                <th><p class=""ParagraphX1 TH rc-Primary in-line"">13.00 น.</p></th>
                                <th><p class=""ParagraphX1 TH rc-Primary in-line"">14.00 น.</p></th>
                                <th><p class=""ParagraphX1 TH rc-Primary in-line"">15.00 น");
                WriteLiteral(@".</p></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><br><br><p class=""HeadingX6 TH rc-Primary in-line"">1</p></td>
                                <td class=""book ""><br>
                                    <p class=""HeadingX6 TH rc-Success in-line "">จอง 1 เครื่อง</p><br><p class=""Paragraph1 TH rc-Primary in-line"">คงเหลือ <span class=""Paragraph1 TH rc-Error in-line"">4</span> เครื่อง</p><p class=""Label TH rc-Error "">* ไม่สามารถเปลี่ยนแปลงได้ แต่สามารถยกเลิกการจองได้ที่ ""รถเข็น""</p></td>
                                <td  class=""full""><br><p class=""HeadingX6 TH rc-Grey6 in-line"">ยอดจองเต็ม</p><br><i class=""material-icons md-48 rc-Grey6 "">access_time</i></td>
                                <td onclick=""openBook()"" class=""remain""><br><br><p class=""Paragraph1 TH rc-Primary in-line"">คงเหลือ <span class="" HeadingX6 TH rc-Error in-line"">12</span> เครื่อง</p></td>
                            ");
                WriteLiteral(@"    <td onclick=""openBook()"" class=""remain""><br><br><p class=""Paragraph1 TH rc-Primary in-line"">คงเหลือ <span class="" HeadingX6 TH rc-Error in-line"">8</span> เครื่อง</p></td>
                                <td class=""full""><br><p class=""HeadingX6 TH rc-Grey6 in-line"">ยอดจองเต็ม</p><br><i class=""material-icons md-48 rc-Grey6 "">access_time</i></td>
                                <td onclick=""openBook()"" class=""remain""><br><br><p class=""Paragraph1 TH rc-Primary in-line"">คงเหลือ <span class="" HeadingX6 TH rc-Error in-line"">5</span> เครื่อง</p></td>
                                <td onclick=""openBook()"" class=""remain""><br><br><p class=""Paragraph1 TH rc-Primary in-line"">คงเหลือ <span class="" HeadingX6 TH rc-Error in-line"">10</span> เครื่อง</p></td>
                            </tr>
                        </tbody>   
                    </table>
                </div>
            </div> <!-- scroll-->
            <!--  pop up add-->
            <div id=""popUp-book"" class=""modal"">
                <div class=""mod");
                WriteLiteral(@"al-content DS-SS"">
                    <span class=""close-book""> <i class=""material-icons rc-Secondary"">close</i></span>
                    <p class=""HeadingX6 ENG rc-Primary in-line""><b>ECC-602</b></p>
                    <p class=""ParagraphX1 ENG rc-Primary in-line"">STM32-nucleo f767zi</p><br>
                    <br>
                    <p class=""ParagraphX1 ENG rc-Primary in-line""><b>1/02/2021</b></p><p class=""ParagraphX1 ENG rc-Primary in-line"">&nbsp;&nbsp;&nbsp;<b>11:00 - 12:00 </b></p><p class=""ParagraphX1 TH rc-Primary in-line"">&nbsp;น.</p>
                    <div class=""add-remove-text"">
                        <p class=""HeadingX6 TH re-Primary left ""> จองจำนวน</p>
                        <p class=""HeadingX6 TH re-Primary right ""> เครื่อง</p>
                    </div>
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b9d4092fcca44acdc67aa8a2b3dc366ddd8bd3212971", async() => {
                    WriteLiteral(@"
                        <div class=""add-remove"">
                            <div class=""left"">
                                <i onclick=""document.form1.input1.value--"" class=""btn-remove material-icons md-24 rc-Primary  "">remove</i>
                            </div>
                        
                            <input class=""input-num"" name=""input1"" value=""1"" size=10 
                                   onfocus=""buffer=this.value"" 
                                   onchange=""if (isNaN(this.value)) 
                            { this.value=buffer}""
                            >
                            <div class=""right"">
                                <i onclick=""document.form1.input1.value++"" class=""btn-plus material-icons md-24 rc-Primary "">add</i>
                            </div>
                        </div>
                        <br>
                        <p class=""warn-text Label TH rc-Error left ""> *สามารถตรวจสอบรายการจองหรือยกเลิกรายการจองได้จากรถเข็น<br> กรุณาตรวจสอบจำนวน เวลา แ");
                    WriteLiteral("ละวันที่ อีกครั้งก่อนการยืนยัน</p>\n                        <input  class=\"btn-pop-book rc-BG ENG ParagraphX1 right \" type=\"submit\" value=\"Ok\">\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                </div>\n            </div>\n        </div> <!-- col 2-->\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>
<script>
var modalBook = document.getElementById(""popUp-book"");
var spanBook = document.getElementsByClassName(""close-book"")[0];
function openBook() {
    modalBook.style.display = ""block"";
}
spanBook.onclick = function() {
    modalBook.style.display = ""none"";
}

/* date time */
var today = new Date();
var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
var time = today.getHours() + "":"" + today.getMinutes() + "":"" + today.getSeconds();
var dateTime = date+' '+time;
  /*document.getElementById(""datetime"").value = dateTime;*/

function logout(){
    var logout = confirm(""Confirm to Log out"")
    if (!logout){
        document.getElementById(""checkLogout"").href=""./adminSelecteRoom.html""; 
    }
}
</script>
");
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
