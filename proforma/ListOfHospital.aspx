<%@ Page Title="::P1 Report Hospitals::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="ListOfHospital.aspx.cs" Inherits="NewWebApp.proforma.ListOfHospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
                </tr>
                <tr>
                    <td style="width: 1000px;" valign="top">
    
    <table class="table table-responsive-sm" style="font-weight: normal; width: 100%; color: #003366;
        font-family: Georgia; height: 32px">
        <tr>
            <td style="font-weight: bold; width: 100%;
                color: #ffffc0; font-family: Arial; background-color: #661700; text-align: left;">
                Medical Section /
                District Wise Hospitals
            <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100%; font-size: 12px; text-align: left;">
                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Size="Small" Width="100%">
                </asp:Table><asp:Table ID="Table2" runat="server" CellPadding="0" CellSpacing="0" Font-Size="Small" Width="100%">
                </asp:Table>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; width: 100%;
                color: #661700; text-align: center; background-color: #661700;">
                <asp:Label ID="mess" runat="server" ForeColor="#FFFFC0"></asp:Label>.</td>
        </tr>
    </table>
    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
