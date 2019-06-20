<%@ Page Title="::Administrator Home Page::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="NewWebApp.Administrator.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="width: 100%; height: 100%;">
                
                <tr>
                    <td colspan="2" style="height: 0px; text-align: center" valign="top">
                        <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                            <tr>
                                <td class="hindiW">
                                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color:#ffb366;"
                                                width="5%">
                                                <div align="center" class="englishb">
                                                </div>
                                            </td>
                                            <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                background-color: #ffb366; text-align: left;" width="55%">
                                                UP Govt. Medical Service Book Options</td>
                                            <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffffff;
                                                background-color: #ffb366; text-align: right;" colspan="2">
                                                &nbsp;User::
                        <asp:Label ID="Fnamet" runat="server" ForeColor="#FFFF80"></asp:Label>
                                                &nbsp;
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                &nbsp;</td>
                                            <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="ADMIN" runat="server" Font-Bold="True" OnClick="ADMIN_Click" Font-Size="Medium" Width="152px" ForeColor="#74211F"> Administration</asp:LinkButton>&nbsp;</td>
                                        </tr>
                                                                              
                                        
                                        
                                       
                                        <tr>
                                            <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                &nbsp;</td>
                                            <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="medicalsection" runat="server" Font-Bold="True" Font-Size="Medium"
                            OnClick="medicalsection_Click" Width="200px" ForeColor="#74211F">Medical (Doctors) Section</asp:LinkButton></td>
                                        </tr>
                                        
                                        
                                        <tr>
                                            <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                &nbsp;</td>
                                            <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="Paramedical" runat="server" Font-Bold="True" OnClick="Paramedical_Click" Font-Size="Medium" Width="176px" ForeColor="#74211F">Paramedical Section</asp:LinkButton>&nbsp;&nbsp;</td>
                                        </tr>
                                         
                                        <tr>
                                            <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                &nbsp;</td>
                                            <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left; color: blue;">
                                                <strong>
                                                <asp:LinkButton ID="repost" runat="server" ForeColor="#74211F" 
                                                    onclick="LinkButton1_Click">Paramedical Data Entry Status</asp:LinkButton>
                                                </strong>&nbsp;(For
                                                Monitoring Purpose)&nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                &nbsp;</td>
                                            <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Medium" 
                                                    ForeColor="#74211F" Font-Bold="True" onclick="LinkButton1_Click1">Upload Orders</asp:LinkButton>
                                            </td>
                                        </tr>
                                        
                                        
                                       
                                        <tr>
                                            <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                &nbsp;</td>
                                            <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                                &nbsp;<asp:LinkButton ID="ucp" runat="server" Font-Size="Medium" ForeColor="#74211F" OnClick="ucp_Click" Font-Bold="True">Change Password</asp:LinkButton>
                                            </td>
                                        </tr>
                                       
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#fe8631">
                                <td bgcolor="#fe8631" height="30" style="background-color: #661700">
                                    <asp:Label ID="Lmsg" runat="server" Font-Bold="True" ForeColor="#FFFF99" Visible="False"></asp:Label>
                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                <td colspan="2" style="width: 100%; text-align: center; height: 16px;" valign="top">
                        <div style="text-align: center">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%;" valign="top">
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
