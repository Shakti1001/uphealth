<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="directives.aspx.cs" Inherits="NewWebApp.WebSite.directives" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="col-sm-12">
<div class="row">
<div class="col-sm-3">
<asp:Panel ID="Panel1" runat="server" aria-hidden="true" style="text-align:center;">
<a href="norms.aspx" target="_self" title="Norms">
<img alt="#" src="../Images/norms.png" width="80px" height="34px" />
<h6>Norms</h6></a>

</asp:Panel>
</div>
<div class="col-sm-3">
<asp:Panel ID="Panel2" runat="server" aria-hidden="true" style="text-align:center;">
<a href="purchaserule.aspx" target="_self" title="Purchase Rules">
<img alt="#" src="../Images/purchase.png" width="80px" height="34px" />
<h6>Purchase Rules</h6></a>

</asp:Panel></div>
<div class="col-sm-3">
<asp:Panel ID="Panel3" runat="server" aria-hidden="true" style="text-align:center;">
<a href="servicerule.aspx" target="_self" title="Service Rule">
<img alt="#" src="../Images/service.png" width="80px" height="34px" />
<h6>Service Rule</h6></a>

</asp:Panel></div>
<div class="col-sm-3">
<asp:Panel ID="Panel4" runat="server" aria-hidden="true" style="text-align:center;">
<a href="usercharge.aspx" target="_self" title="User Charges">
<img alt="#" src="../Images/userchages.png" width="80px" height="34px" />
<h6>User Charges</h6></a>

</asp:Panel></div>


</div>

</div>

</div>
</asp:Content>
