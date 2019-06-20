<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Retiredue.aspx.cs" Inherits="NewWebApp.Proforma2.Retiredue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td colspan="2" style="width: 100%; height: 4px; text-align: right" valign="top">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton2" runat="server" 
                    onclick="LinkButton2_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%; height: 4px; text-align: center" valign="top">
                <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                    <tr>
                        <td class="hindiW">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                        width="5%">
                                        <div align="center" class="englishb">
                                        </div>
                                    </td>
                                    <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                        background-color: #661700; text-align: left;" width="55%">
                                        Medical Section / P2 / Retirement Due&nbsp;</td>
                                    <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                        background-color: #661700" width="28%">
                                        <asp:Label ID="Divs"
                                            runat="server" Visible="False">%</asp:Label>
                                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                                    <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                        width="12%">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#376fbc" colspan="4" height="30" style="background-color: #fff8dc">
                                        <table class="table table-responsive-sm" style="border-top-width: thin; border-left-width: thin; border-left-color: #990000;
                                            border-bottom-width: thin; border-bottom-color: #990000; width: 100%; color: #003366;
                                            border-top-color: #990000; font-family: Georgia; border-right-width: thin; border-right-color: #990000">
                                            <tr>
                                                <td style="width: 100%; background-color: #e8cd76; text-align: right;">
                                                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="font-weight: bold; width: 100%;
                                                        color: maroon; height: 100%">
                                                        <tr>
                                                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                            </td>
                                                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                <asp:Label ID="DL" runat="server" Text="Division" Width="100%"></asp:Label></td>
                                                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                <asp:DropDownList ID="DDiv" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDiv_SelectedIndexChanged"
                                                                    Width="90%">
                                                                </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; height: 25px">
                                                            </td>
                                                            <td align="left" style="width: 25%; height: 25px">
                                                                District</td>
                                                            <td align="left" style="width: 25%; height: 25px">
                                                                <asp:DropDownList ID="DDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged"
                                                                    Width="90%">
                                                                </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%; height: 25px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                                                &nbsp;&nbsp;</td>
                                                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                From(month &amp; year)</td>
                                                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: left;">
                                                                <asp:DropDownList ID="DDD" runat="server" Visible="False">
                                                                </asp:DropDownList><asp:DropDownList ID="DMM" runat="server">
                                                                </asp:DropDownList><asp:DropDownList ID="DYYYY" runat="server" >
                                                                </asp:DropDownList>
                                                                </td>
                                                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: center;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; height: 25px; text-align: center">
                                                            </td>
                                                            <td align="left" style="width: 25%; height: 25px; text-align: left">
                                                                To(month &amp; year)</td>
                                                            <td align="left" style="width: 25%; height: 25px; text-align: left">
                                                                <asp:DropDownList ID="DD1" runat="server" Visible="False">
                                                                </asp:DropDownList><asp:DropDownList ID="DM1" runat="server">
                                                                </asp:DropDownList><asp:DropDownList ID="DY1" runat="server">
                                                                </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%; height: 25px; text-align: left">
                                                                <asp:Button class="btn btn-success" ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit" />&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 11px; background-image: url(../images/tab.jpg); width: 100%;
                                                    font-family: Arial; text-align: right">
                                                    <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" Font-Bold="True" OnClick="LinkButton1_Click"
                                                        Width="175px">Already Retired Doctors</asp:LinkButton></td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 11px; background-image: url(../images/tab.jpg); width: 100%;
                                                    font-family: Arial; text-align: left">
                                                    <asp:Table class="table table-responsive-sm" ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                                        Height="100%" HorizontalAlign="Center" Width="100%">
                                                    </asp:Table>
                                                </td>
                                            </tr>
                                        </table>
                                        &nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#376fbc" colspan="4" height="30" style="background-color: #fff8dc">
                            <asp:Label ID="mess" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></td>
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
</div>
</asp:Content>
