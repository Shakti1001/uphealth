<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="usercharge6.aspx.cs" Inherits="NewWebApp.WebSite.usercharge6" %>
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
<td>9.</td>
<td>X-ray Chest (Per plate)</td>
<td>26.00</td>
<td>53.00</td>
<td>80.00</td>
</tr>
<tr>
<td>10.</td>
<td>X-ray Abdomen(Per plate)</td>
<td>26.00</td>
<td>53.00</td>
<td>80.00</td>
</tr>
<tr>
<td>11.</td>
<td>X-ray Spine A.P.</td>
<td>26.00</td>
<td>53.00</td>
<td>80.00</td>
</tr>
<tr>
<td>12.</td>
<td>X-raySkull  A.P/Laleral each</td>
<td>26.00</td>
<td>53.00</td>
<td>80.00</td>
</tr>
<tr>
<td>13.</td>
<td>X-ray other Parts of body</td>
<td>26.00</td>
<td>53.00</td>
<td>80.00</td>
</tr>
 <tr>
<th colspan="5" style="text-align:center;">B. Specialized Technique</th>
</tr>
<tr>
<td>1.</td>
<td>I.V.P. (Excluding Dye)</td>
<td>160.00 for four plate or 40.00 per plate</td>
<td>266.00 for four plate or53.00 per plate</td>
<td>399.00 for plate or 80.00per plate</td>
</tr>
<tr>
<td>2.</td>
<td>Cholecystography/(Excluding Dye)</td>
<td>80.00</td>
<td>133.00</td>
<td>200.00</td>
</tr>
<tr>
<td>3.</td>
<td>Berium Meal/Enem(Excluding Dye)</td>
<td>80.00</td>
<td>133.00</td>
<td>200.00</td>
</tr>
<tr>
<td>4.</td>
<td>Histrosalphingography (Excluding Dye)</td>
<td>80.00</td>
<td>133.00</td>
<td>200.00</td>
</tr>
<tr>
<td>5.</td>
<td>Angio-graphy (Other than coronary)</td>
<td>80.00</td>
<td>133.00</td>
<td>200.00</td>
</tr>
<tr>
<td>6.</td>
<td>Myelography</td>
<td>80.00</td>
<td>133.00</td>
<td>200.00</td>
</tr>
<tr>
<td>7.</td>
<td>Ventriculography(without contrest)</td>
<td>80.00</td>
<td>133.00</td>
<td>200.00</td>
</tr>
<tr>
<td>8.</td>
<td>Cellography</td>
<td>80.00</td>
<td>133.00</td>
<td>200.00</td>
</tr>
<tr>
<td>9.</td>
<td>Bronchography (without contrast media)</td>
<td>80.00</td>
<td>133.00</td>
<td>200.00</td>
</tr>
<tr>
<th colspan="5" style="text-align:center;">C. Radiation Therapy</th>
</tr>
<tr>
<td>1.</td>
<td>Diathermy/Infread/Ultraviolet</td>
<td>6.00</td>
<td>8.00</td>
<td>13.00</td>
</tr>
<tr>
<td>2.</td>
<td>Radiotheraphy</td>
<td>34.00</td>
<td>67.00</td>
<td>100.00</td>
</tr>
<tr>
<td>3.</td>
<td>Radium/CS/Cobalt Needle or tissue
Inveensation</td>
<td>34.00</td>
<td>67.00</td>
<td>100.00</td>
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
