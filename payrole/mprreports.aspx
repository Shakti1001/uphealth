<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="mprreports.aspx.cs" Inherits="NewWebApp.payrole.mprreports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td colspan="2" style="text-decoration: underline; font-size: large">
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-decoration: underline; font-size: large">
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-decoration: underline; font-size: large">
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-decoration: underline; font-size: large">
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-decoration: underline; font-size: large">
                &nbsp;<strong><asp:LinkButton ID="LinkButton3" runat="server" 
                    onclick="LinkButton3_Click">Monthly MPR(Multiple Choice)</asp:LinkButton>
                </strong>
                </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    onclick="LinkButton1_Click">DDO Wise Monthly Dairy</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" 
                    onclick="LinkButton2_Click">Monthly MPR Including Name and Qualification</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>
                <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">Diary and Pay Record Combined</asp:LinkButton>
                </strong></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
