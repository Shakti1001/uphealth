<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="mpr.aspx.cs" Inherits="NewWebApp.payrole.mpr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%; height: 100%">
        <tr>
            <td colspan="2" style="width: 100%; height: 0px; text-align: right" valign="top">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton3" runat="server" 
                    onclick="LinkButton3_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
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
                                        &nbsp; Medical Section / MPR &nbsp;<asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
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
                                    <td align="center" bgcolor="#376fbc" height="10" style="background-color: #ffffff">
                                    </td>
                                    <td bgcolor="#376fbc" colspan="3" height="10" style="background-color: #ffffff; text-align: center">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Blue" 
                                            Text="Please Select DDO for MPR Data Entry"></asp:Label><asp:Label
                                            ID="Label2" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                                        <asp:DropDownList ID="DDONAME" runat="server" Width="30%" OnSelectedIndexChanged="DDONAME_SelectedIndexChanged" AutoPostBack="True" BackColor="Gainsboro" Font-Bold="True" ForeColor="Maroon" Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" height="10" >
                                        &nbsp;</td>
                                    <td colspan="3" height="10"  text-align: left">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#376fbc" height="10" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="10" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="SalDet" runat="server" Font-Bold="True" 
                                            Font-Size="Medium" ForeColor="#74211F"
                                            OnClick="SalDet_Click" Width="50%">Date Wise MPR Entry</asp:LinkButton></td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                        &nbsp;</td>
                                    <td colspan="2" style="height: 10px">
                                        &nbsp;</td>
                                </tr>
                              
                             
                               
                                  <tr>
                                    <td align="center" bgcolor="#376fbc" height="10" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="10" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" OnClick="LinkButton2_Click" Width="190px" 
                                            >Month wise Date Entry </asp:LinkButton>
                                        </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                        &nbsp;</td>
                                    <td colspan="2" style="height: 10px">
                                        &nbsp;</td>
                                </tr>
                              
                             
                               
                                <tr>
                                    <td align="center" bgcolor="#376fbc" height="10" style="background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="10" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" OnClick="report_Click" Width="190px" 
                                            >Monthly Progress Report</asp:LinkButton>
                                        <asp:Label ID="Label3" runat="server" ForeColor="Green" Text="Label" Font-Bold="True"></asp:Label></td>
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
