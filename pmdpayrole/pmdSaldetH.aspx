<%@ Page Title="::Payrole Section::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="pmdSaldetH.aspx.cs" Inherits="NewWebApp.pmdpayrole.pmdSaldetH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" style="width: 100%; height: 100%">
        <tr>
            <td colspan="2" style="width: 100%; height: 0px; text-align: right" valign="top">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 0px; text-align: center" valign="top">
                <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                    <tr>
                        <td class="hindiW">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 404px">
                                <tr>
                                    <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                        width="5%">
                                        <div align="center" class="englishb">
                                        </div>
                                    </td>
                                    <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                        background-color: #661700; text-align: left;" width="55%">
                                        &nbsp; ParaMedical Section / Payroll &nbsp;<asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
                                    <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                        background-color: #661700" width="28%">
                                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                                    <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #661700"
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
                                    <td align="center" bgcolor="#376fbc" height="30" style="background-color: #ffffff">
                                    </td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #ffffff; text-align: center">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Blue" Text="Please Select DDO for Salary Process"></asp:Label><asp:Label
                                            ID="Label2" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                                        <asp:DropDownList ID="DDONAME" runat="server" Width="30%" OnSelectedIndexChanged="DDONAME_SelectedIndexChanged" AutoPostBack="True" BackColor="Gainsboro" Font-Bold="True" ForeColor="Maroon" Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                    <td colspan="2" style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        &nbsp;<asp:LinkButton ID="SalDet" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F"
                                            OnClick="SalDet_Click" Width="284px">Add/Edit Basic  Salary Details</asp:LinkButton></td>
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
                                        <asp:LinkButton ID="LADD" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F"
                                            OnClick="LADD_Click" Width="184px" style="height: 19px">Add /Edit Loan Entry</asp:LinkButton></td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                               
                              
                                <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="optionern" runat="server" Font-Bold="True" 
                                            Font-Size="Medium" ForeColor="#74211F"
                                            OnClick="optionern_Click" Width="200px">Add /Edit Optional Earning</asp:LinkButton></td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                        &nbsp;</td>
                                    <td style="height: 10px">
                                        &nbsp;</td>
                                </tr>
                               
                              
                                <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="GPayB" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F"
                                            OnClick="GPayB_Click" Width="118px"> Process Salary</asp:LinkButton>
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#C00000" Text="Select this Option After Every Modification in Basic Salary Data"></asp:Label></td>
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
                                        &nbsp;<asp:LinkButton ID="GPayRep" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F"
                                            OnClick="GPayRep_Click" Width="115px">Print Reports </asp:LinkButton><asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#C00000" Text="Select This Option to Print Pay Bill & Schedules After Processing of Salary"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                    <td height="10">
                                    </td>
                                </tr>
                                <%--  <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="CCSal" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" OnClick="CCSal_Click" Width="208px">Cross Check Salary Detail</asp:LinkButton></td>
                                </tr>--%>
                                
                                  <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="statuslink" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" OnClick="statusrep_Click" Width="269px" 
                                            Enabled="False">Status Of Pay Records Data Entry</asp:LinkButton></td>
                                </tr>
                                 <tr>
                                    <td style="height: 10px">
                                    </td>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                                   <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="payslip" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" OnClick="payslip_Click" Width="269px">Pay Slip </asp:LinkButton></td>
                                </tr>
                                 <tr>
                                    <td style="height: 10px">
                                    </td>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="yedreport" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" Width="269px" OnClick="yedreport_Click">YE&D Report</asp:LinkButton></td>
                                </tr>
                                 <tr>
                                    <td style="height: 10px">
                                    </td>
                                    <td style="height: 10px">
                                    </td>
                                </tr>--%><%-- <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="#74211F" OnClick="increment_Click" Width="140px">Apply Increment</asp:LinkButton>
                                        &nbsp; &nbsp; &nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Font-Bold="True"
                                            ForeColor="#C00000" Text="Apply Once in a Year at The Time Of Increment"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="Label3" runat="server" ForeColor="Green" Text="Label" Font-Bold="True"></asp:Label></td>
                                </tr>--%>
                                <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="unitadmin" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" OnClick="unitadmin_Click" Width="269px">Group Hospitals (AdminUnit Wise )</asp:LinkButton></td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                    <td style="height: 10px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" height="30" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="incmnt" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" OnClick="incmnt_Click" Width="269px">Apply Increment</asp:LinkButton></td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                    <td style="height: 10px">
                                        <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                        &nbsp;</td>
                                    <td style="height: 10px">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr bgcolor="#fe8631">
                        <td bgcolor="#fe8631" height="30" style="background-color: #661700">
                            <asp:Label ID="mess" runat="server" Font-Bold="True" ForeColor="White"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%" valign="top">
            </td>
        </tr>
    </table>
</div>
</asp:Content>
