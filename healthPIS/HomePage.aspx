<%@ Page Title="" Language="C#" MasterPageFile="~/healthPIS/healthPis.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="NewWebApp.healthPIS.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="row">
<div class="panel panel-heading" style=" width:100%;">
<center><h4>Registration Form</h4></center>
</div>
<div>&nbsp;</div>
<div class="card" style=" width:95%; margin-left:25px; margin-right:25px;">
<div class="card-header">
&nbsp;
</div>
<table class="table table-responsive">
<tr>
<td>Name :</td>
<td> <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Enter Full Name"></asp:TextBox></td>
<td>Father's Name :</td>
<td> <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Enter Father's Name"></asp:TextBox></td>&nbsp;
<td>Gender &nbsp;:&nbsp;</td>
<td>Male&nbsp;<asp:RadioButton ID="RadioButton1" runat="server" />&nbsp;Female&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" /> </td>
</tr>
<tr>
<td>Date Of Birth :</td>
<td> <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="Enter Full Name"></asp:TextBox></td>
<td>Home District :</td>
<td><asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem>-Select-</asp:ListItem>
    </asp:DropDownList>
</td>&nbsp;
<td>Permanent Home District &nbsp;:&nbsp;</td>
<td>   <asp:DropDownList ID="DropDownList2" runat="server">
    <asp:ListItem>-Select-</asp:ListItem>
    </asp:DropDownList> </td>
</tr>
<tr>
<td>Category Id :</td>
<td> <asp:TextBox ID="TextBox4" runat="server" class="form-control" placeholder="Enter Category"></asp:TextBox></td>
<td>Sub Category Id :</td>
<td> <asp:TextBox ID="TextBox5" runat="server" class="form-control" placeholder="Enter Father's Name"></asp:TextBox></td>&nbsp;
<td>Category &nbsp;:&nbsp;</td>
<td>Male&nbsp;<asp:RadioButton ID="RadioButton3" runat="server" />&nbsp;Female&nbsp;<asp:RadioButton ID="RadioButton4" runat="server" /> </td>
</tr>


</table>

<div class="card card-footer">
</div>
</div>


</div>
</div>

</asp:Content>
