<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="pmdPayRopt.aspx.cs" Inherits="NewWebApp.pmdpayrole.pmdPayRopt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    // <!CDATA[

    function TABLE1_onclick() {

    }

    // ]]>
</script>
<div class="container">

    <table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 98%">
        <tr>
            <td style="width: 100%; height: 1px; text-align: right">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 14px; width: 100%; color: #ffff99; height: 20px;
                background-color: #661700; text-align: center;">
                Report Option&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
                <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" style="font-weight: bold; font-size: 14px;
                    width: 100%; color: maroon; background-color: #fff8dc">
                    <tr style="font-size: 10pt; color: #800000">
                        <td colspan="4" style="width: 100%; height: 20px; text-align: center; background-color: #e8cd76;">
                                        </td>
                    </tr>
                    <tr style="font-size: 10pt; color: #800000">
                        <td colspan="4" style="width: 100%; height: 25px; text-align: left; background-color: #e8cd76;">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td colspan="2" style="width: 100%; height: 25px; background-color: burlywood; text-align: center; font-weight: bold; color: maroon; font-size: 13pt;">
                                        &nbsp; &nbsp; &nbsp;DDO Name &nbsp;
                                        <asp:TextBox ID="DDOText" runat="server" Width="30%" ForeColor="#C00000" ReadOnly="True"></asp:TextBox>
                            <asp:Label ID="DDOIDLab" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font-weight: bold; font-size: 13pt; width: 100%; color: maroon;
                                        height: 25px; background-color: #e8cd76; text-align: center">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; height: 25px; text-align: center; background-color: #e8cd76;">
                                        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;
                                            text-align: left" id="TABLE1" onclick="return TABLE1_onclick()">
                                            <tr>
                                                <td style="width: 25%; background-color: #fff8dc; height: 25px;">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="paybill_link" runat="server" OnClick="paybill_link_Click" style="font-weight: bold; color: maroon" Font-Size="Medium">Paybill</asp:LinkButton></td>
                                                <td style="width: 25%; background-color: #fff8dc; height: 25px; text-align: right;">
                                                    <asp:LinkButton ID="GVRSch_link" runat="server" OnClick="GVRSch_link_Click" style="font-weight: bold; color: maroon" Font-Size="Medium">GVR Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; background-color: #fff8dc; height: 25px;">
                                        </td>
                                                <td style="width: 25%; background-color: burlywood; height: 25px;">
                                        </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="GPFSch_link" runat="server" OnClick="GPFSch_link_Click" style="font-weight: bold; color: maroon" Font-Size="Medium">GPF Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    <asp:LinkButton ID="prs" runat="server" OnClick="prs_Click" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium">PRAN Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="GISSch_link" runat="server" OnClick="GISSch_link_Click" style="font-weight: bold; color: maroon" Font-Size="Medium">G.I.S. Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    <asp:LinkButton ID="HRRSch_link" runat="server" OnClick="HRRSch_link_Click" style="font-weight: bold; color: maroon" Font-Size="Medium">HRR Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="Incometax_link" runat="server" OnClick="Incometax_link_Click" style="font-weight: bold; color: maroon" Font-Size="Medium">Income Tax Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    <asp:LinkButton ID="BankStatment_link" runat="server" OnClick="BankStatment_link_Click" style="color: maroon" Font-Size="Medium">Bank Statement</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76; text-align: right">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="hbashdl" runat="server" OnClick="hbashdl_Click" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium">HBA Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    <asp:LinkButton ID="HBAinst" runat="server" OnClick="HBAinst_Click" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium">HBA Interest Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76; text-align: right">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="vehsdl" runat="server" OnClick="vehsdl_Click" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium">Vehicle Advance Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    <asp:LinkButton ID="vinst" runat="server" OnClick="vinst_Click" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium">Vehicle Advance Interest Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76; text-align: right">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="gpf4schedul" runat="server" OnClick="gpf4schedul_Click" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium">GPF Class iv Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    <asp:LinkButton ID="licsdl" runat="server" OnClick="licsdl_Click" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium">LIC Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76; text-align: right">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="ElecBillSch_link" runat="server" OnClick="ElecBillSch_link_Click" style="font-weight: bold; color: maroon" Font-Size="Medium">ElecBill Schedule</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76; text-align: right">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    <asp:LinkButton ID="vehsdl1" runat="server" OnClick="vehsdl1_Click" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium" 
                                                        Visible="False">Society Deduction</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    <asp:LinkButton ID="vehsdl0" runat="server" 
                                                        style="font-weight: bold; color: maroon" Font-Size="Medium" 
                                                        Visible="False">RD Deduction</asp:LinkButton></td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76; text-align: right">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                </td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #fff8dc">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76; text-align: right">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: #e8cd76">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px; background-color: burlywood">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                                    <asp:DropDownList ID="DDO" runat="server" Width="90%" Visible="False">
                                                                  </asp:DropDownList></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 25px; background-color: burlywood;">
                            <asp:Label ID="MSGLabel" runat="server" Text=""></asp:Label>
                                                    </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; color: #661700; background-color: #661700" valign="top">
                .<asp:Label ID="ME" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
    </div>
</asp:Content>
