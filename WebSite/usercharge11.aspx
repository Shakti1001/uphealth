<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="usercharge11.aspx.cs" Inherits="NewWebApp.WebSite.usercharge11" %>
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
<td>3.</td>
<td>Gastric Perforation</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>4.</td>
<td>Gastroscopy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>5.</td>
<td>Anastomosis operation</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>6.</td>
<td>Vagotomy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<th colspan="5" style="text-align:center;">B. Operation Of Intestine</th>
</tr>
<tr>
<td>1.</td>
<td>Shunt and anastomosis of all type</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>2.</td>
<td>Bowl resection</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>3.</td>
<td>Colostomies</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>4.</td>
<td>Sigmedoscopy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>5.</td>
<td>Interssuception</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<th colspan="5" style="text-align:center;">C. Operation of Gallblander, Liver and spleen</th>
</tr>
<tr>
<td>1.</td>
<td>Chole Cystectomy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>2.</td>
<td>Chole Cystojejeumostomy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>3.</td>
<td>Valid jejumostomy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>4.</td>
<td>Pancrecatomy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>5.</td>
<td>Repair of liver</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>6.</td>
<td>Splinorenal anastomosis</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>7.</td>
<td>Splinectomy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>8.</td>
<td>Hydatoid cystexcision</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>

<tr>
<th colspan="5" style="text-align:center;">D. Operation Of Kidney and Usetor</th>
</tr>
<tr>
<td>1.</td>
<td>Renal stone removal</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>2.</td>
<td>Nephrectomy/Dialysis</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>3.</td>
<td>ustises stone removal</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>4.</td>
<td>uteric Implatation</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>5.</td>
<td>rinnary bladeysurgery</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<th colspan="5" style="text-align:center;">E. Operation of lower abdominal Region</th>
</tr>
<tr>
<td>1.</td>
<td>Hernia of all type</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
</tr>
<tr>
<td>2.</td>
<td>Appendesectomy</td>
<td>399.00</td>
<td>666.00</td>
<td>1066.00</td>
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
