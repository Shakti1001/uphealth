<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="namesearch.aspx.cs" Inherits="NewWebApp.Proforma2.namesearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <div class=""> 
    
     <nav aria-label="breadcrumb">     
  <ol class="breadcrumb"> 
    <li class="breadcrumb-item" ><a href="../Authenticate/login.aspx">Home</a></li>   
    <li class="breadcrumb-item disabled" ><a>Factsheet Search</a></li>   
  </ol> 
</nav>
</div>
    
     </div>
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" width: 100%; table-layout:fixed;">
                <tr>
                    <td style="width: 100%; text-align: right; height: 4px;" valign="top" colspan="2">
                        <asp:LinkButton ID="LinkButton1" class="btn btn-danger" OnClick="LinkButton1_Click" runat="server"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; height: 4px; text-align: center" valign="top">
                        <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%" style="table-layout:fixed;">
                            <tr>
                                <td class="hindiW">
                                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed;">
                                        <tr>
                                            <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                                width="5%">
                                                <div align="center" class="englishb">
                                                </div>
                                            </td>
                                            <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                background-color: #661700; text-align: left;" width="55%">
                                               Medical Section / Join And Relieve
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
                                                <table class="table table-responsive-sm" style="border-top-width: thin; table-layout:fixed; border-left-width: thin; border-left-color: #990000;
                                                    border-bottom-width: thin; border-bottom-color: #990000; width: 100%; color: #003366;
                                                    border-top-color: #990000; font-family: Georgia; border-right-width: thin; border-right-color: #990000">
                                                    <tr>
                                                        <td style="width: 100%; background-color: #e8cd76;">
                        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; table-layout:fixed; height: 100%; font-weight: bold; color: maroon;">
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:Label ID="DL" runat="server" Text="Cadre"></asp:Label></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:DropDownList ID="Dcadre" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDiv_SelectedIndexChanged"
                        Width="90%">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                    Feeding Cadre</td>
                                <td align="left" style="width: 25%; height: 25px">
                    <asp:DropDownList ID="Dfcadre" class="form-control" runat="server" AutoPostBack="True" Width="90%" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    Name</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    <asp:TextBox ID="name" runat="server" placeholder="Write First Letter"></asp:TextBox>
                  <!--  <asp:DropDownList ID="DHname" class="form-control" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="DHname_SelectedIndexChanged">
                    </asp:DropDownList></td>-->
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="left" style="width: 100%; color: black; height: 25px; text-align: center;" colspan="4">
                                  
                                  
                    <asp:Button ID="Submit" class="btn btn-success" runat="server" Text="Submit" OnClick="Submit_Click" /></td>
                            </tr>
                        </table>
                <asp:Label ID="strq" runat="server" Font-Size="Small" Visible="False" ForeColor="Red"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 11px; background-image: url(../images/tab.jpg); width: 100%;
                                                            font-family: Arial; text-align: left">
                                                            <asp:Table ID="Table1" class="table table-responsive-sm" runat="server" CellPadding="1" CellSpacing="1" Font-Bold="True"
                                                                Height="100%" HorizontalAlign="Center" style="table-layout:fixed;">
                                                            </asp:Table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
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
