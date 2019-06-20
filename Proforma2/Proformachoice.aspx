<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Proformachoice.aspx.cs" Inherits="NewWebApp.Proforma2.Proformachoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" width: 100%; table-layout:fixed;">
                <tr>
                    <td style="width: 100%; text-align: right; height: 4px;" valign="top" colspan="2">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; height: 4px; text-align: center" valign="top">
                        <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%" style="table-layout:fixed;">
                            <tr>
                                <td class="hindiW">
                                    <table style="table-layout:fixed;" class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                                width="5%">
                                                <div align="center" class="englishb">
                                                </div>
                                            </td>
                                            <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                background-color: #661700; text-align: left;" width="55%">
                                                Medical Section / P2 / Factsheet Search
                        <asp:Label ID="Fnamet" runat="server" ForeColor="#FFFF99" Visible="False"></asp:Label></td>
                                            <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                                background-color: #661700" width="28%">
        <asp:Label ID="count" runat="server" Visible="False"></asp:Label><asp:Label
            ID="Divs" runat="server" Visible="False">%</asp:Label><asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label><asp:Label ID="Ename" runat="server" Visible="False"></asp:Label></td>
                                            <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                                width="12%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" bgcolor="#376fbc" colspan="4" height="30" style="background-color: #fff8dc">
                                                <table style="border-top-width: thin; table-layout:fixed; border-left-width: thin; border-left-color: #990000;
                                                    border-bottom-width: thin; border-bottom-color: #990000; width: 100%; color: #003366;
                                                    border-top-color: #990000; font-family: Georgia; border-right-width: thin; border-right-color: #990000">
                                                    <tr>
                                                        <td style="width: 100%; background-color: #e8cd76;">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; table-layout:fixed; height: 100%; font-weight: bold; color: maroon;">
                            <tr>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                                    Name</td>
                                <td align="left" style="width: 25%; height: 25px">
                    <asp:TextBox class="form-control" ID="name" runat="server" AutoPostBack="True" OnTextChanged="name_TextChanged"></asp:TextBox></td>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                            </tr>

                             <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    Fathers Name</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:TextBox class="form-control" ID="fname" runat="server" AutoPostBack="True" OnTextChanged="fname_TextChanged"></asp:TextBox></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>
                             <tr>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                    Computer No.</td>
                                <td align="left" style="width: 25%; height: 25px">
                    <asp:TextBox class="form-control" ID="cmpuno" runat="server"></asp:TextBox></td>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    Seniority No.</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:TextBox class="form-control" ID="Sen" runat="server" AutoPostBack="True" OnTextChanged="Sen_TextChanged"></asp:TextBox></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>

                             <tr>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                    Cadre</td>
                                <td align="left" style="width: 25%; height: 25px">
                    <asp:DropDownList class="form-control" ID="DCadre" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DCadre_SelectedIndexChanged">
                </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                            </tr>
                             <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc" >
                    Feeding Cadre</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:DropDownList class="form-control" ID="fcadreddl" runat="server" Width="90%" 
                                        AutoPostBack="True" onselectedindexchanged="fcadreddl_SelectedIndexChanged" >
                </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:Label ID="DL" runat="server" Text="Division"></asp:Label></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:DropDownList ID="DDiv" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDiv_SelectedIndexChanged"
                        Width="90%">
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
                    <asp:DropDownList class="form-control" ID="DDistrict" runat="server" AutoPostBack="True" Width="90%" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    Hospital Name</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:DropDownList class="form-control" ID="DHname" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DHname_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>
                           
                           
                           
                            <tr>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                    Designation</td>
                                <td align="left" style="width: 25%; height: 25px">
                    <asp:DropDownList class="form-control" ID="DDesign" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DDesign_SelectedIndexChanged">
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
                    <asp:DropDownList class="form-control" ID="Dpost" runat="server" Width="90%" OnSelectedIndexChanged="Dpost_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="left" style="width: 25%; height: 25px;">
                    <asp:Button class="btn btn-default" ID="Refresh" runat="server" OnClick="Refresh_Click" Text="Refresh" Visible="False" /></td>
                                <td align="left" style="width: 25%; height: 25px;">
                    Level</td>
                                <td align="left" style="width: 25%; height: 25px;">
                    <asp:DropDownList class="form-control" ID="Dlevel" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="Dlevel_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px;">
                                </td>
                            </tr>

                  <!--           <tr>
                                <td align="left" style="width: 25%; height: 25px;">
                    <asp:Button class="btn btn-default" ID="Button1" runat="server" OnClick="Refresh_Click" Text="Refresh" Visible="False" /></td>
                                <td align="left" style="width: 25%; height: 25px;">
                   Specialization</td>
                                <td align="left" style="width: 25%; height: 25px;">
                    <asp:DropDownList class="form-control" ID="splsearch" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="Dlevel_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px;">
                                </td>
                            </tr>-->
                            <tr>
                                <td align="left" style="width: 100%; color: black; height: 25px; text-align: center;" colspan="4">
                                    Note:
                                    <asp:Label ID="input" runat="server" Font-Size="Small" ForeColor="#0000C0">For Full Report Just Click On Submit else  Select Choice Then Submit</asp:Label>&nbsp;
                    <asp:Button class="btn btn-success" ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" /></td>
                            </tr>
                        </table>
                <asp:Label ID="strq" runat="server" Font-Size="Small" Visible="False" ForeColor="Red"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 11px; background-image: url(../images/tab.jpg); width: 100%;
                                                            font-family: Arial; text-align: left">
                                                            <asp:Table style="table-layout:fixed;" class="table table-responsive-sm" ID="Table1" runat="server" CellPadding="1" CellSpacing="1" Font-Bold="True"
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
</asp:Content>
