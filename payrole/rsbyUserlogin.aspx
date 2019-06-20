<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="rsbyUserlogin.aspx.cs" Inherits="NewWebApp.payrole.rsbyUserlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 225px;
        }
        .style4
        {
            width: 705px;
            text-align: center;
        }
        .style5
        {
            width: 424px;
        }
        .style6
        {
            width: 225px;
            height: 25px;
        }
        .style7
        {
            width: 424px;
            height: 25px;
        }
        .style8
        {
            height: 25px;
        }
        .style9
        {
            height: 28px;
        }
        .style10
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" class="style2">
        <tr>
            <td class="style6">
                </td>
            <td class="style7">
                </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
               <div class="login">
                    &nbsp;
                        <table class="table table-responsive-sm" cellpadding="1" cellspacing="1"  class="style1">
                            <tr>
                                <td align="right" class="style9">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblusername" runat="server" Text="User Id" 
                                        style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="style9">
                                    <strong>:</strong></td>
                                <td class="style9">
                                    <asp:TextBox ID="txtuserid" runat="server" 
                                        MaxLength="10" CssClass="round" 
                                        Height="25px" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblpass" runat="server" Text="Password" style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <strong>:</strong></td>
                                <td>
                                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password" 
                                         CssClass="input" MaxLength="15" 
                                        Height="25px" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style10">
                                    </td>
                                <td class="style10">
                                    </td>
                                <td class="style10">
                                    </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnlogin" runat="server" OnClick="btnlogin_click"
                                        Text="Login" style="font-weight: 700; " Width="89px" CssClass="button" 
                                        Height="28px" BackColor="#333399" ForeColor="White" />
&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style4" colspan="3">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                                                        
                           
                        </table>
                        
                     
                      </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</div>
</asp:Content>
