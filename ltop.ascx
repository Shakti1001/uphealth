<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ltop.ascx.cs" Inherits="ltop" %>
<script runat="server">

    protected void Llogout_Click(object sender, EventArgs e)
    {
        Session.Remove("fullname");
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("~/login.aspx");
    }
</script>
<div leftmargin="0px" topmargin="0px"   style="text-align: center; background-color: #fff8dc;">
    <table style=" width: 100%; ">
        <tr>
            <td colspan="2" style=" width: 100%;font-weight: bold; color: #660000; text-align: center"
                valign="top">
                <table style="width: 100%; height: 100%;">
                <tr>
                    <td colspan="2" style=" height: 80px;background-image: url(images/kh.jpg);  text-align: left; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/uplogo.gif" Height="80px" Width="96px" /></td>
                </tr>
                        <tr>
                            <td colspan="2" style="border-right: #000000 thin solid; border-top: #000000 thin solid;
                                border-left: #000000 thin solid; border-bottom: #000000 thin solid; background-color: #ffffff;
                                text-align: left" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 45%; text-align: left; font-size: 14px; border-right: #660e00 thin solid; border-top: #660e00 thin solid; font-weight: bold; border-left: #660e00 thin solid; color: #ffffc0; border-bottom: #660e00 thin solid; background-color: #661700;">
                                    <SCRIPT language="Javascript1.2">
<!--

var tags_before_clock = "<b>"
var tags_middle_clock = ","
var tags_after_clock  = "</b>"

if(navigator.appName == "Netscape") {
document.write('<layer id="clock"></layer><br>');
}

if (navigator.appVersion.indexOf("MSIE") != -1){
document.write('<span id="clock"></span>');
}

DaysofWeek = new Array()
  DaysofWeek[0]="Sunday"
  DaysofWeek[1]="Monday"
  DaysofWeek[2]="Tuesday"
  DaysofWeek[3]="Wednesday"
  DaysofWeek[4]="Thursday"
  DaysofWeek[5]="Friday"
  DaysofWeek[6]="Saturday"

Months = new Array()
  Months[0]="Jan"
  Months[1]="Feb"
  Months[2]="March"
  Months[3]="April"
  Months[4]="May"
  Months[5]="June"
  Months[6]="July"
  Months[7]="August"
  Months[8]="Sept"
  Months[9]="Oct"
  Months[10]="Nov"
  Months[11]="Dec"

function upclock(){
var dte = new Date();
var hrs = dte.getHours();
var min = dte.getMinutes();
var sec = dte.getSeconds();
var day = DaysofWeek[dte.getDay()]
var date = dte.getDate()
var month = Months[dte.getMonth()]
var year = dte.getFullYear()

var col = ":";
var spc = " ";
var com = ",";
var apm;

if (date == 1 || date == 21 || date == 31)
  {ender = "<sup>st</sup>"}
else
if (date == 2 || date == 22)
  {ender = "<sup>nd</sup>"}
else
if (date == 3 || date == 23)
  {ender = "<sup>rd</sup>"}

else
  {ender = "<sup>th</sup>"}

if (12 < hrs) {
apm="<font size='-1'>pm</font>";
hrs-=12;
}

else {
apm="<font size='-1'>am</font>";
}

if (hrs == 0) hrs=12;
if (hrs<=9) hrs="0"+hrs;
if (min<=9) min="0"+min;
if (sec<=9) sec="0"+sec;

if(navigator.appName == "Netscape") {
document.clock.document.write(tags_before_clock+hrs+col+min+col+sec+apm+spc+tags_middle_clock+spc+day+com+spc+date+ender+spc+month+com+spc+year+tags_after_clock);
document.clock.document.close();
}

if (navigator.appVersion.indexOf("MSIE") != -1){
clock.innerHTML = tags_before_clock+hrs+col+min+col+sec+apm+spc+tags_middle_clock+spc+day+com+spc+date+ender+spc+month+com+spc+year+tags_after_clock;
}
}

setInterval("upclock()",1000);
//-->
</SCRIPT>
                                    
                                    
                                    
                                    
                                    </td>
                                    <td style="width: 45%; font-weight: bold; font-size: 14px; text-align: left; border-right: #660e00 thin solid; border-top: #660e00 thin solid; border-left: #660e00 thin solid; color: #ffffc0; border-bottom: #660e00 thin solid; background-color: #661700;">
                                        Department Of Medical Health &amp; Family Welfare</td>
                                    <td style="width: 45%; text-align: left; border-right: #660e00 thin solid; border-top: #660e00 thin solid; font-weight: bold; font-size: 14px; border-left: #660e00 thin solid; color: #ffffc0; border-bottom: #660e00 thin solid; background-color: #661700;">
                                        <asp:LinkButton ID="Logout" runat="server" Font-Bold="True" ForeColor="#FFFFC0" OnClick="Llogout_Click">Logout</asp:LinkButton></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
            </table>                
                <%--<a href="#" onClick="history.back()"></a>--%></td>
        </tr>
    </table>
</div>