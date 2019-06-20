<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="pmdDDOcrosscheck.aspx.cs" Inherits="NewWebApp.pmdpayrole.pmdDDOcrosscheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td style="width: 100%; height: 292px;" valign="top">
                <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="width: 100%; text-align: right">
                            <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                                onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
                    </tr>
                    <tr>
                         
            <td style="font-weight: bold; font-size: 14px; width: 100%; color: #ffff99; height: 25px;
                background-color: #661700">
                Cross Check Salary Detail </td>
           
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:Label ID="Fnamet" runat="server" Text=""></asp:Label><asp:Label ID="Uidt"
                                runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:Label ID="Label1"
                    runat="server" Font-Bold="True" ForeColor="Maroon">DDO Name</asp:Label>
                            ::
                            <asp:TextBox ID="DDOText" runat="server" ForeColor="#C00000" ReadOnly="True" Width="35%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Arial" Font-Size="Small">
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="MSGLabel" runat="server"></asp:Label>
                <asp:Label ID="DDOIDLab" runat="server" Visible="False"></asp:Label></td>
        </tr>
    </table>
    </div>
</asp:Content>
