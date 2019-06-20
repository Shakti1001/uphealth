<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="RepOption.aspx.cs" Inherits="NewWebApp.Proforma2.RepOption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right; height: 4px;" valign="top" colspan="2">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton2" runat="server" 
                            onclick="LinkButton2_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
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
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="Linkalpha" runat="server" Font-Bold="True" OnClick="Linkalpha_Click" Font-Size="Small" Width="312px" ForeColor="#74211F" Font-Names="Arial">Fact Sheet (Search On Alphabets)</asp:LinkButton></td>
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
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Size="Small" Width="87%" OnClick="LinkButton3_Click" ForeColor="#74211F" Font-Names="Arial">Number of Years Completed by a Doctor at Currently Posted Districts (Search On Criteria)</asp:LinkButton></td>
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
                                                            <asp:LinkButton ID="Rtdue" runat="server" Font-Bold="True" Font-Names="Arial"
                                                                Font-Size="Small" ForeColor="#74211F" OnClick="Rtdue_Click" Width="296px">Doctor's List Whose Retirement is Due  </asp:LinkButton></td>
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
                        <asp:LinkButton ID="DyQ" runat="server" Font-Bold="True" OnClick="DyQ_Click" Font-Size="Small" Width="296px" ForeColor="#74211F" Font-Names="Arial">Dynamic Query</asp:LinkButton></td>
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
                       <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#74211F" OnClick="click1" Font-Names="Arial" Width="296px">Eligibility List for Transfer (Policy 2013)</asp:LinkButton>
                        
                                                            </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>








                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="seniority" runat="server" Font-Bold="True" ForeColor="#74211F"
                        OnClick="seniority_Click" Width="312px" Font-Names="Arial" Font-Size="Small">Seniority List(Search On Criteria)</asp:LinkButton>
                        
                                                            </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="Dashboard" runat="server" Font-Bold="True" ForeColor="#74211F"
                        OnClick="Dashboard_Click" Width="312px" Font-Names="Arial" Font-Size="Small">DashBoard</asp:LinkButton>
                        
                                                            </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td height="10">
                                                            &nbsp;</td>
                                                        <td height="10">
                                                            &nbsp;</td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="CurrentL0" runat="server" Font-Bold="True" ForeColor="#74211F"
                        OnClick="CurrentL0_Click" Width="312px" Font-Names="Arial" Font-Size="Small">Search Old P2</asp:LinkButton></td>
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
    <br />
    <br />
    <br />
</asp:Content>
