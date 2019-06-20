<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top.ascx.cs" Inherits="Admin_Top" %>
<div style="text-align: center">
    <table style="border-top: #990000 thin solid; width: 1016px; border-bottom: #0033cc thin solid; height: 104px;">
        <tr>
            <td style="background-image: url(../images/mybanner.jpg); width: 1016px; height: 101px; text-align: left; font-weight: bold; color: #660000;" valign="bottom">
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

                <asp:Image ID="Image1" runat="server" Height="96px" ImageUrl="~/images/uplogo.gif"
                    Width="104px" /></td>
        </tr>
    </table>
</div>
