<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="totaltimeinhospital.aspx.cs" Inherits="NewWebApp.Proforma2.totaltimeinhospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="table table-responsive-sm table-active" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm" style="width: 100%">
                <tr>
                    <td colspan="2" style="width: 100%; height: 4px; text-align: right" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" 
                            runat="server" onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
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
                                                background-color: #661700; text-align: left;" colspan="3">
                                                Medical Section / P2 / Number Of Year Completed By Currently Posted Doctors Search
                                                <asp:Label ID="Fnamet" runat="server" ForeColor="#FFFF99" Visible="False"></asp:Label><asp:Label ID="count" runat="server" Visible="False"></asp:Label><asp:Label ID="Divs"
                                                    runat="server" Visible="False"></asp:Label><asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label><asp:Label
                                                        ID="Ename" runat="server" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" bgcolor="#376fbc" colspan="4" height="30" style="background-color: #fff8dc">
                                                <table class="table table-responsive-sm" style="border-top-width: thin; border-left-width: thin; border-left-color: #990000;
                                                    border-bottom-width: thin; border-bottom-color: #990000; width: 100%; color: #003366;
                                                    border-top-color: #990000; font-family: Georgia; border-right-width: thin; border-right-color: #990000">
                                                    <tr>
                                                        <td style="width: 100%; background-color: #e8cd76">
                                                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="font-weight: bold; width: 100%;
                                                                color: maroon; height: 100%">
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        <asp:Label ID="DL" runat="server" Text="Division" Width="100%"></asp:Label></td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        <asp:DropDownList ID="DDiv" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDiv_SelectedIndexChanged"
                                                                            Width="95%">
                                                                        </asp:DropDownList></td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                        District</td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        <asp:DropDownList ID="DDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged"
                                                                            Width="95%">
                                                                        </asp:DropDownList></td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        Hospital Type</td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        <asp:DropDownList ID="DDType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDType_SelectedIndexChanged"
                                                                            Width="95%">
                                                                        </asp:DropDownList></td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        Hospital Name</td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        <asp:DropDownList ID="DHname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DHname_SelectedIndexChanged"
                                                                            Width="95%">
                                                                        </asp:DropDownList></td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        Post</td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        <asp:DropDownList ID="Dpost" runat="server" OnSelectedIndexChanged="Dpost_SelectedIndexChanged"
                                                                            Width="95%">
                                                                        </asp:DropDownList></td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        Cadre</td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        <asp:DropDownList ID="DCadre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DCadre_SelectedIndexChanged"
                                                                            Width="95%">
                                                                        </asp:DropDownList></td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        Level</td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        <asp:DropDownList ID="Dlevel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Dlevel_SelectedIndexChanged"
                                                                            Width="95%">
                                                                        </asp:DropDownList></td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        Years Completed</td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        <asp:TextBox ID="Nytext" runat="server"></asp:TextBox></td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        Date(as on)</td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                        <asp:TextBox ID="Dateontext" runat="server">31/03/2015</asp:TextBox>(dd/mm/yyyy)</td>
                                                                    <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        <asp:Button ID="Refresh" runat="server" OnClick="Refresh_Click" Text="Refresh" Visible="False" /></td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        </td>
                                                                    <td align="left" style="width: 25%; height: 25px">
                                                                        </td>
                                                                    <td align="left" style="width: 25%; height: 25px; text-align: center;">
                                                                        <asp:LinkButton ID="AllPrintLink" runat="server" OnClick="AllPrintLink_Click" Visible="False">All</asp:LinkButton>&nbsp;
                                                                        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit " /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" colspan="4" style="width: 100%; color: black; height: 25px; background-color: #fff8dc;
                                                                        text-align: center; font-family: Arial;">
                                                                        Note:<span style="color: blue"><asp:Label ID="input" runat="server" Font-Size="Small"
                                                                            ForeColor="#0000C0">For Full Report Just Click On Submit else  Select Choice Then Submit</asp:Label></span></td>
                                                                </tr>
                                                            </table>
                                                                        <asp:Label ID="strq" runat="server" Font-Size="Small" ForeColor="Red" Visible="False" Font-Bold="True">There  Is No Data According To Your Choice Please Change Your  Selection </asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 11px; width: 100%;
                                                            font-family: Arial; text-align: left">
                                                            <asp:Table class="table table-responsive-sm" ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                                                Height="100%" HorizontalAlign="Center" Width="100%">
                                                            </asp:Table><asp:Table ID="Table2" class="table table-responsive-sm" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                                                Height="100%" HorizontalAlign="Center" Width="100%">
                                                            </asp:Table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                        </table>
                                </td>
                            </tr>
                            <tr bgcolor="#fe8631">
                                <td bgcolor="#fe8631" height="30" style="background-color: #661700">
                                    <asp:Label ID="mess" runat="server" ForeColor="#FFFFC0"></asp:Label>
                                    <asp:Label ID="distsublbl" runat="server" Visible="False"></asp:Label></td>
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
    <br />
    <br />
</asp:Content>
