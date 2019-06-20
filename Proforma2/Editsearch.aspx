<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Editsearch.aspx.cs" Inherits="NewWebApp.Proforma2.Editsearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
               
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
            <table class="table table-responsive-sm" style="width: 100%; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; color: #003366; border-top-color: #990000; font-family: Georgia; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="font-weight: bold; width: 100%;
                        color: #ffff99; background-color: #661700; height: 25px; text-align: left;">
                        <span style="color: #ffff99">Medical Section/ Edit Join &amp; Relieve <span style="background-color: #661700">
                            (Click On First Letter Of Name)</span></span> &nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="VALT" runat="server" AutoPostBack="True" OnTextChanged="VALT_TextChanged"
                            Visible="False" Width="40px"></asp:TextBox>
                        <asp:Label ID="Fnamet" runat="server" ForeColor="#661700"></asp:Label>
                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 25px; background-color: #fffbd6;">
                        <asp:LinkButton ID="A" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="A_Click">A</asp:LinkButton>
                        <asp:LinkButton ID="B" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="B_Click">B</asp:LinkButton>
                        <asp:LinkButton ID="C" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="C_Click">C</asp:LinkButton>
                        <asp:LinkButton ID="D" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="D_Click">D</asp:LinkButton>
                        <asp:LinkButton ID="E" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="E_Click">E</asp:LinkButton>
                        <asp:LinkButton ID="F" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="F_Click">F</asp:LinkButton>
                        <asp:LinkButton ID="G" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="G_Click">G</asp:LinkButton>
                        <asp:LinkButton ID="H" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="H_Click">H</asp:LinkButton>
                        <asp:LinkButton ID="I" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="I_Click">I</asp:LinkButton>
                        <asp:LinkButton ID="J" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="J_Click">J</asp:LinkButton>
                        <asp:LinkButton ID="K" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="K_Click">K</asp:LinkButton>
                        <asp:LinkButton ID="L" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="L_Click">L</asp:LinkButton>
                        <asp:LinkButton ID="M" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="M_Click">M</asp:LinkButton>
                        <asp:LinkButton ID="N" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="N_Click">N</asp:LinkButton>
                        <asp:LinkButton ID="O" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="O_Click">O</asp:LinkButton>
                        <asp:LinkButton ID="P" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="P_Click">P</asp:LinkButton>
                        <asp:LinkButton ID="Q" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="Q_Click">Q</asp:LinkButton>
                        <asp:LinkButton ID="R" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="R_Click">R</asp:LinkButton>
                        <asp:LinkButton ID="S" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="S_Click">S</asp:LinkButton>
                        <asp:LinkButton ID="T" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="T_Click">T</asp:LinkButton>
                        <asp:LinkButton ID="U" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="U_Click">U</asp:LinkButton>
                        <asp:LinkButton ID="V" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="V_Click">V</asp:LinkButton>
                        <asp:LinkButton ID="W" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="W_Click">W</asp:LinkButton>
                        <asp:LinkButton ID="X" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="X_Click">X</asp:LinkButton>
                        <asp:LinkButton ID="Y" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="Y_Click">Y</asp:LinkButton>
                        <asp:LinkButton ID="Z" runat="server" Font-Bold="True" ForeColor="#C00000" OnClick="Z_Click">Z</asp:LinkButton>&nbsp;
                        <asp:Label ID="Ctot" runat="server" ForeColor="#C00000"></asp:Label></td>
                </tr>
                <tr>
                    <td style="background-image: url(../../images/tab.jpg); width: 100%; color: #003366;
                        text-align: left; font-size: 12px; font-family: Arial;">
                        <asp:Table ID="Table1" runat="server" Height="100%" Width="100%" CellPadding="0" CellSpacing="0">
                        </asp:Table>
                        </td>
                </tr>
                <tr>
                    <td style="font-size: 12px; width: 100%; color: #661700; font-family: Arial; background-color: #661700;
                        text-align: center; height: 25px;">
                        <asp:Label ID="mesg" runat="server" ForeColor="#FFFFC0"></asp:Label>.</td>
                </tr>
            </table>
        </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
