<%@ Page Title="::Update Join/Relieve::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="updateJR.aspx.cs" Inherits="NewWebApp.Administrator.updateJR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #661700">
        <tr>
            <td colspan="2" style="width: 100%; text-align: right" valign="top">
                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger" OnClick="Bk_Click"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton>
               
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%; text-align: center" valign="top">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td colspan="3" style="color: #ffffff; background-color: #661700">
                                Change Status Of Join / Relieve
                                <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table class="table table-responsive-sm" style="border-right: #333333 thin solid; border-top: #333333 thin solid; font-weight: bold;
                                    border-left: #333333 thin solid; width: 100%; color: #661700; border-bottom: #333333 thin solid;
                                    font-family: Georgia; height: 100%; background-color: #fffbd6">
                                    <tr>
                                        <td style="font-weight: normal; width: 100%; font-family: Arial; height: 21px">
                                            Enter Computer Id &nbsp;
                                            <asp:TextBox ID="Otext" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: normal; width: 100%; font-family: Arial; height: 21px; background-color: burlywood; text-align: right;">
                                            &nbsp;<asp:Button ID="Button1" runat="server" class="btn btn-success" OnClick="Button1_Click" Text="Set To Joined"
                                                Width="110px" />&nbsp;//
                                            <asp:Button ID="Button2" runat="server" class="btn btn-danger" OnClick="Button2_Click" Text="Set To Relieve" Width="110px" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; text-align: center">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Navy"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="color: #661700; height: 5%; background-color: #661700">
                                <asp:Label ID="mess" runat="server" Font-Bold="True" ForeColor="White" Visible="False"></asp:Label>.</td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
