<%@ Page Title="::Paramedical Report Options::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="parap2ReportOption.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap2ReportOption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right; height: 4px;" valign="top" colspan="2">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton6" runat="server" 
                            onclick="LinkButton6_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; height: 4px; text-align: center" valign="top">
                        <table class="table table-responsive-sm" style="width: 100%; height: 100%">
                            <tr>
                                <td colspan="2" style="height: 0px; text-align: center" valign="top">
                                    <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                                        <tr>
                                            <td class="hindiW">
                                                <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="5%">
                                                            <div align="center" class="englishb">
                                                            </div>
                                                        </td>
                                                        <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f; text-align: left" width="55%">
                                                            &nbsp; Paramedical Section / P2 / Reports Option&nbsp;
                        </td>
                                                        <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f" width="28%">
                                                            <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Ename" runat="server" Visible="False"></asp:Label></td>
                                                        <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="12%">
                        <asp:Label ID="Fnamet" runat="server" ForeColor="#FFFF99"></asp:Label>
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
                        <asp:LinkButton ID="FactSheetCh" runat="server" Font-Bold="True" OnClick="FactSheetCh_Click" Font-Size="Medium" 
                                                                Width="371px" ForeColor="#74211F">Posting List/Fact Sheet (Any Unit of District)</asp:LinkButton></td>
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
                    <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Size="Medium" Width="27%" 
                                                                OnClick="LinkButton3_Click" ForeColor="#74211F">Duration Report(Any Unit of District)</asp:LinkButton></td>
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
                                                            <strong>
                                                            <asp:LinkButton ID="LinkButton5" runat="server" onclick="LinkButton5_Click" 
                                                                style="color: #800000">Search P2 (Entire State)</asp:LinkButton>
                                                            </strong></td>
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
                                                            &nbsp;</td>
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
                        <asp:LinkButton ID="Linkalpha" runat="server" Font-Bold="True" OnClick="Linkalpha_Click" Font-Size="Medium" 
                                                                Width="232px" ForeColor="#74211F" Visible="False">Fact Sheet (Search On Alphabets)</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                            &nbsp;</td>
                                                        <td colspan="2" style="height: 10px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F" Visible="False" PostBackUrl="~/Underpr.aspx">List Of Retirement Details Of Doctors  </asp:LinkButton></td>
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
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F" Visible="False">Cadre and Specialization Wise Doctors Summary </asp:LinkButton></td>
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
                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F" Visible="False">Cader wise report  </asp:LinkButton></td>
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
                        <asp:LinkButton ID="DyQ" runat="server" Font-Bold="True" OnClick="DyQ_Click" Font-Size="Medium" Width="144px" ForeColor="#74211F" Visible="False">Dynamic Query</asp:LinkButton></td>
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
                                            <td bgcolor="#fe8631" height="30" style="background-color: #74211f">
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
</asp:Content>
