<%@ Page Title="::Add/Edit Hospital Record::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="LHospitalopration.aspx.cs" Inherits="NewWebApp.proforma.LHospitalopration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton></td>
                </tr>
                <tr>
                    <td style="width: 1000px;" valign="top">
    
    <table class="table table-responsive-sm" style="font-weight: normal; width: 100%; color: #003366;
        font-family: Georgia; height: 32px">
        <tr>
            <td style="font-weight: bold; width: 100%;
                color: #ffffc0; font-family: Arial; background-color: #661700; text-align: left;">
                Medical Section&nbsp;Add / Edit P1 Records<asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="DDOIDLBL" runat="server" Text="" Visible="false"></asp:Label></td>
        </tr>

       <tr><td>
       </td></tr>

       <tr><td>
           <asp:Label ID="Label1" runat="server" Text="District Name:" Visible="False"></asp:Label>
           <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
           </asp:DropDownList>
       </td></tr>

       <tr><td>
           <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
               Visible="False" Width="74px" />
       </td></tr>
        <tr>
            <td style="width: 100%; font-size: 12px; text-align: left;">
                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Size="Small" Width="100%">
                </asp:Table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; font-size: 13px; text-align: left;">
                <asp:Table ID="Table2" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
                </asp:Table>
                </td>
        </tr>
        <tr>
            <td style="font-weight: bold; width: 100%;
                color: #661700; text-align: center; background-color: #661700;">
                <asp:Label ID="mess" runat="server" ForeColor="White"></asp:Label>.</td>
        </tr>
    </table>
    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
