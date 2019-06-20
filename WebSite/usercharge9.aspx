<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="usercharge9.aspx.cs" Inherits="NewWebApp.WebSite.usercharge9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../CssFile/paging.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="row">
<div class="col-sm-12 text-justify">
<ul class="breadcrumb">
<li class="breadcrumb-item"><a href="index.aspx" title="Home">Home</a></li>
<!--<li class="breadcrumb-item"><a href="norms.aspx" title="Home">Government Norms</a></li>-->
<li class="breadcrumb-item">User Charge</li>
</ul>
<div class="h3"><center>User Charge</center></div>
<div>
<table class="table table-responsive-sm">
<tr>
 <th colspan="5" style="text-align:center;">Operation Fee</th></tr>
<tr>
<th>Sr. No.</th>
<th>Testing Report</th>
<th colspan="3" style="text-align:center;">Rate</th>
</tr>
<tr>
<th colspan="2" ></th>
<th>OPD</th>
<th>Paying Ward</th>
<th>Private Ward</th>
</tr>
<tr>
<th colspan="5" style="text-align:center;">A. List of Medium Operation</th>
</tr>
<tr>
<td>1.</td>
<td>Abdominal Laprotomy</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>2.</td>
<td>Supra Pubic Cystomy</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>3.</td>
<td>Cysto-Liathotomy</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>4.</td>
<td>Removal of Stone from Urethra</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>5.</td>
<td>Hydrocoel/ Hemetocoel</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>6.</td>
<td>Varicocoel</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>7.</td>
<td>Varicose vein operation</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>8.</td>
<td>Fissure in ano</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>9.</td>
<td>Vas reunion</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>10.</td>
<td>Four body anal region</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>11.</td>
<td>Testicular biopsy</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>12.</td>
<td>Intercostal drivainage</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>13.</td>
<td>Retrograde Uretreric catherisation</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>14.</td>
<td>Gynaecomastia</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<th colspan="5" style="text-align:center;">B. Gynocological Operation</th>
</tr>
<tr>
<td>1.</td>
<td>Dilatation and curretage</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>2.</td>
<td>Ligation</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>3.</td>
<td>Bootheline Gland removal</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>4.</td>
<td>Varinal cyst removal</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>5.</td>
<td>Induction of Labour</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>6.</td>
<td>Application of foceps</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>7.</td>
<td>Delivery with  or without episiotomy</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>8.</td>
<td>Mannual removal of Placenta</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<th colspan="5" style="text-align:center;">C. Plastic Surgery</th>
</tr>
<tr>
<td>1.</td>
<td>Operation on tendon</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>2.</td>
<td>Skin grafting</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>
<tr>
<td>3.</td>
<td>Medium plastic surgery</td>
<td>266.00</td>
<td>399.00</td>
<td>666.00</td>
</tr>

</table>



</div>


  </div>
</div>
<center>
<div class="pagination">

  <a href="usercharge.aspx">&laquo;</a>
  <a href="usercharge1.aspx">1</a> 
  <a href="usercharge2.aspx">2</a> 
  <a href="usercharge3.aspx">3</a> 
  <a href="usercharge4.aspx">4</a> 
  <a href="usercharge5.aspx">5</a> 
  <a href="usercharge6.aspx">6</a> 
  <a href="usercharge7.aspx">7</a> 
  <a href="usercharge8.aspx">8</a> 
  <a href="usercharge9.aspx">9</a> 
  <a href="usercharge10.aspx">10</a> 
  <a href="usercharge11.aspx">11</a> 
  <a href="usercharge12.aspx">&raquo;</a>
 
</div>
 </center>
</div>
</asp:Content>
