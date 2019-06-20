<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="dscombind.aspx.cs" Inherits="NewWebApp.payrole.dscombind" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
        <asp:Label ID="lblddo" runat="server" Visible="false" Font-Bold="true"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlddo" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
        <strong>Month ::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlmonth" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong>Year ::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlyr" runat="server">
                    <asp:ListItem>2013</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="left">
                <asp:Button class="btn btn-success" ID="Button1" runat="server" Font-Bold="True" 
                    onclick="Button1_Click" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="left">
                <asp:Label ID="lblmess" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" CaptionAlign="Left" >
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
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
