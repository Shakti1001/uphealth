<%@ Page Title="::Administration Page::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Ad1.aspx.cs" Inherits="NewWebApp.Administrator.Ad1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 100%; width: 100%">
                <tr>
                    <td style="width: 100%; height: 0px; text-align:right;" valign="top">
                 &nbsp;<asp:LinkButton ID="LinkButton5" runat="server" 
                            class="btn btn-danger" onclick="LinkButton5_Click"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton>
               </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 0px; text-align: center" valign="top">
                        <table class="table table-responsive-sm" style="width: 100%; height: 100%;">
                            <tr>
                                <td colspan="2" style="height: 0px; text-align: center" valign="top">
                                    <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
                                        <tr>
                                            <td class="hindiW">
                                                <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: """
                                                            width="5%">
                                                            <div align="center" class="englishb">
                                                            </div>
                                                        </td>
                                                        <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                            background-color: #ffb366; text-align: left" width="55%">
                                                            &nbsp;
                        Welcome User::
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                                                        <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                                            background-color: #ffb366" width="28%">
                                                        </td>
                                                        <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #ffb366"
                                                            width="12%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="Medium"
                            ForeColor="#74211F" Width="120px" OnClick="LinkButton2_Click">User Creation</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Medium"
                            ForeColor="#74211F" Width="200px" OnClick="LinkButton1_Click">Edit/Delete User Details</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:10px">
                                                        </td>
                                                        <td colspan="2" style="height:10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                                            <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="#74211F" PostBackUrl="~/XXXXX.aspx" OnClick="LinkButton3_Click">User Login Details</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" Font-Size="Medium"
                            ForeColor="#74211F" Width="250px" OnClick="LinkButton4_Click">Change Status Join & Relieve</asp:LinkButton></td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    </table>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#fe8631">
                                            <td bgcolor="#fe8631" height="30" style="background-color: #661700">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
