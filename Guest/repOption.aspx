<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/Site1.Master" AutoEventWireup="true" CodeBehind="repOption.aspx.cs" Inherits="NewWebApp.Guest.repOption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="text-align: center">
        <div style="text-align: center">
            <table style=" width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right; height: 4px;" valign="top" colspan="2">
                        <asp:ImageButton ID="Back" runat="server" Height="24px" Width="64px" ImageUrl="~/images/images1.jpg" OnClick="Back_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; height: 4px; text-align: center" valign="top">
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td colspan="2" style="height: 0px; text-align: center" valign="top">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                                        <tr>
                                            <td class="hindiW">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="5%">
                                                            <div align="center" class="englishb">
                                                            </div>
                                                        </td>
                                                        <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f; text-align: left" width="55%">
                                                            Medical Section / P2 Reports Option&nbsp;
                        <asp:Label ID="Fnamet" runat="server" ForeColor="#FFFF99" Visible="False"></asp:Label></td>
                                                        <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f" width="28%">
                                                            <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Ename" runat="server" Visible="False"></asp:Label></td>
                                                        <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="12%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="Linkalpha" runat="server" Font-Bold="True" OnClick="Linkalpha_Click" Font-Size="Small" 
                                                                Width="312px" ForeColor="#74211F" Font-Names="Arial" Visible="False">Fact Sheet (Search On Alphabets)</asp:LinkButton></td>
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
                        <asp:LinkButton ID="FactSheetCh" runat="server" Font-Bold="True" OnClick="FactSheetCh_Click" Font-Size="Small" Width="312px" ForeColor="#74211F" Font-Names="Arial">Fact Sheet (Search On  Criteria)</asp:LinkButton></td>
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
                    <asp:LinkButton ID="CurrentL" runat="server" Font-Bold="True" ForeColor="#74211F"
                        OnClick="CurrentL_Click" Width="312px" Font-Names="Arial" Font-Size="Small">Current Posting List(Search On Criteria)</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    </table>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#fe8631">
                                            <td bgcolor="#fe8631" height="30" 
                                                style="background-color: #74211f; height: 19px;">
                        <asp:Label ID="mess" runat="server" ForeColor="#FFFF99" Font-Bold="True"></asp:Label></td>
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
    <br />
    <br />
    <br />
</asp:Content>
