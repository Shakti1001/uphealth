<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="PMDP2alpha.aspx.cs" Inherits="NewWebApp.paramedicalstaff.PMDP2alpha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td colspan="2" style="width: 100%; height: 4px; text-align: right" valign="top">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
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
                                        background-color: #661700; text-align: left;" colspan="2">
                                        Paramedical Staff / P2 / Factsheet Search (Click On First Letter Of Name)
                                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label><asp:Label ID="Ename"
                                            runat="server" Visible="False"></asp:Label></td>
                                    <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                        width="12%">
                                        <asp:Label ID="Fnamet" runat="server" ForeColor="#FFFF99"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#376fbc" colspan="4" height="30" style="background-color: #fff8dc">
                                        <table class="table table-responsive-sm" style="border-top-width: thin; border-left-width: thin; border-left-color: #990000;
                                            border-bottom-width: thin; border-bottom-color: #990000; width: 100%; color: #003366;
                                            border-top-color: #990000; font-family: Georgia; border-right-width: thin; border-right-color: #990000">
                                            <tr>
                                                <td style="width: 100%">
                                                    <asp:LinkButton ID="A" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="A_Click">A</asp:LinkButton>
                                                    <asp:LinkButton ID="B" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="B_Click">B</asp:LinkButton>
                                                    <asp:LinkButton ID="C" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="C_Click">C</asp:LinkButton>
                                                    <asp:LinkButton ID="D" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="D_Click">D</asp:LinkButton>
                                                    <asp:LinkButton ID="E" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="E_Click">E</asp:LinkButton>
                                                    <asp:LinkButton ID="F" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="F_Click">F</asp:LinkButton>
                                                    <asp:LinkButton ID="G" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="G_Click">G</asp:LinkButton>
                                                    <asp:LinkButton ID="H" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="H_Click">H</asp:LinkButton>
                                                    <asp:LinkButton ID="I" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="I_Click">I</asp:LinkButton>
                                                    <asp:LinkButton ID="J" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="J_Click">J</asp:LinkButton>
                                                    <asp:LinkButton ID="K" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="K_Click">K</asp:LinkButton>
                                                    <asp:LinkButton ID="L" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="L_Click">L</asp:LinkButton>
                                                    <asp:LinkButton ID="M" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="M_Click">M</asp:LinkButton>
                                                    <asp:LinkButton ID="N" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="N_Click">N</asp:LinkButton>
                                                    <asp:LinkButton ID="O" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="O_Click">O</asp:LinkButton>
                                                    <asp:LinkButton ID="P" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="P_Click">P</asp:LinkButton>
                                                    <asp:LinkButton ID="Q" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="Q_Click">Q</asp:LinkButton>
                                                    <asp:LinkButton ID="R" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="R_Click">R</asp:LinkButton>
                                                    <asp:LinkButton ID="S" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="S_Click">S</asp:LinkButton>
                                                    <asp:LinkButton ID="T" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="T_Click">T</asp:LinkButton>
                                                    <asp:LinkButton ID="U" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="U_Click">U</asp:LinkButton>
                                                    <asp:LinkButton ID="V" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="V_Click">V</asp:LinkButton>
                                                    <asp:LinkButton ID="W" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="W_Click">W</asp:LinkButton>
                                                    <asp:LinkButton ID="X" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="X_Click">X</asp:LinkButton>
                                                    <asp:LinkButton ID="Y" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="Y_Click">Y</asp:LinkButton>
                                                    <asp:LinkButton ID="Z" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="Z_Click">Z</asp:LinkButton>&nbsp;
                                                    <asp:TextBox ID="VALT" runat="server" AutoPostBack="True" OnTextChanged="VALT_TextChanged"
                                                        Visible="False" Width="32px"></asp:TextBox>
                                                    <asp:Label ID="Ctot" runat="server" ForeColor="#C00000" Visible="False"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 11px; background-image: url(../images/tab.jpg); width: 100%;
                                                    font-family: Arial; text-align: left">
                                                    <asp:Table ID="Table2" runat="server" CellPadding="1" CellSpacing="1" Font-Bold="True"
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
                            <asp:Label ID="mess" runat="server" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
