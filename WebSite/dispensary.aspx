<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="dispensary.aspx.cs" Inherits="NewWebApp.WebSite.dispensary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="row">
<div class="col-sm-12">
<ul class="breadcrumb">
<li class="breadcrumb-item"><a href="index.aspx" title="Home">Home</a></li>
<li class="breadcrumb-item"><a href="norms.aspx" title="Home">Government Norms</a></li>
<li class="breadcrumb-item">Dispensary Additional PHC</li>
</ul>
<div class="h3"><center>Dispensary Additional PHC</center></div>



<div>
<table class="table table-responsive-sm">
<tr>
<th> Sr. No.</th>
<th> Conditions</th>
<th>Dispensary Additional PHC</th>
</tr>
<tr>
<td>1.</td>
<td>	
Accidents & Injuries</td>
<td>Treat minor injuries refer for fractures, head injuries internal injuries to SDH (100)/DH</td>
</tr>
<tr>
<td>2.</td>
<td>Animal Bites</td>
<td>Treat snake bites, dog bites and scorpion bites refer for complications to SDH</td>
</tr>
<tr>
<td>3.</td>
<td>Burns</td>
<td>Treat up to 10% burns refer to CHC for 20% burns and SDH (100) for all burns above 20%</td>
</tr>
<tr>
<td>4.</td>
<td>	Poisoning</td>
<td>Preliminary Treatment Refer to SDH</td>
</tr>

</table>

</div>

</div>
</div>
</div>
</asp:Content>
