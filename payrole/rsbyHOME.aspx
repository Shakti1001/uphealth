<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="rsbyHOME.aspx.cs" Inherits="NewWebApp.payrole.rsbyHOME" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            text-align: right;
        }
        .style4
        {
            font-weight: bold;
        }
    .style5
    {
        text-align: center;
    }
    .style6
    {
        height: 30px;
        width: 451px;
    }
    .style7
    {
        text-align: right;
        height: 30px;
    }
    .style8
    {
        text-align: left;
    }
    .style9
    {
        text-align: right;
        height: 26px;
        width: 451px;
    }
    .style10
    {
        text-align: left;
        height: 26px;
    }
    .style11
    {
        text-align: right;
        width: 451px;
    }
    .style12
    {
        width: 451px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">   
    <table class="style2 table table-responsive-sm table-active">
    <tr>
        <td class="style6">
            </td>
        <td class="style7">
            <strong>
            <asp:Button ID="Button2" runat="server" CssClass="style4" 
                onclick="Button2_Click" Text="Logout" />
            </strong></td>
    </tr>
    <tr>
        <td class="style11">
            <strong>Question::</strong></td>
        <td class="style8">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style9">
            <strong>Type Answer to Register Attendence::</strong></td>
        <td class="style10">
            <strong>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </strong></td>
    </tr>
    <tr>
        <td class="style12">
            &nbsp;</td>
        <td class="style8">
            <strong>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
                Text="Submit" CssClass="style4" />
            </strong></td>
    </tr>
    <tr>
        <td class="style3" colspan="2">
            <asp:Label ID="Label2" runat="server" Enabled="False" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style5" colspan="2">
            <strong>
            <asp:Label ID="Label3" runat="server"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td class="style5" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5" colspan="2">
            &nbsp;</td>
    </tr>
</table>
    </div>
</asp:Content>
