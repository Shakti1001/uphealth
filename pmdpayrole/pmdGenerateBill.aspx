<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="pmdGenerateBill.aspx.cs" Inherits="NewWebApp.pmdpayrole.pmdGenerateBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 98%">
        <tr>
            <td style="width: 100%; height: 1px; text-align: right">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 14px; width: 100%; color: #ffff99; height: 25px;
                background-color: #661700; text-align: center;">
                &nbsp;Bill Processing/Calculation Activity &nbsp;for 
                ParaMedical Staff</td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
                <table cellpadding="0" cellspacing="0" style="font-weight: bold; font-size: 14px;
                    width: 100%; color: maroon; background-color: #fff8dc">
                    <tr style="font-size: 10pt; color: #800000">
                        <td colspan="4" style="font-weight: bold; width: 100%; color: #0033cc; height: 25px; text-align: center; font-family: Arial;">
                            </td>
                    </tr>
                    <tr style="font-size: 10pt; color: #800000">
                        <td colspan="4" style="width: 100%; height: 25px; text-align: left">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td colspan="2" style="width: 100%; height: 25px; text-align: center">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;
                                            text-align: left">
                                            <tr>
                                                <td style="width: 25%; height: 7px">
                                                </td>
                                                <td style="width: 25%; height: 7px; font-weight: bold; color: maroon; text-align: center;">
                                        DDO Name&nbsp;</td>
                                                <td style="width: 25%; height: 7px">
                                        <asp:TextBox ID="DDOText" runat="server" ForeColor="#C00000" ReadOnly="True" Width="95%" 
                                                        ontextchanged="DDOText_TextChanged"></asp:TextBox></td>
                                                <td style="width: 25%; height: 7px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 22px">
                                                </td>
                                                <td style="width: 25%; height: 22px; text-align: center;" >
                                                    <span style="font-size: 12pt; color: maroon; font-weight: bold;">
                                        Year</span></td>
                                                <td style="width: 25%; height: 22px">
                                        <asp:DropDownList ID="year" runat="server" Width="66%" 
                                                        onselectedindexchanged="year_SelectedIndexChanged">
                                            
                                        </asp:DropDownList></td>
                                                <td style="width: 25%; height: 22px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px">
                                                </td>
                                                <td style="width: 25%; height: 25px; color: #990000; text-align: center;" >
                                                    <span style="font-size: 12pt; color: maroon; font-weight: bold;">
                                        Month
                                        </span></td>
                                                <td style="width: 25%; height: 25px">
                                        <asp:DropDownList ID="Month" runat="server" Width="66%" 
                                                        onselectedindexchanged="Month_SelectedIndexChanged">                                            
                                        </asp:DropDownList></td>
                                                <td style="width: 25%; height: 25px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 28px">
                                                </td>
                                                <td style="width: 25%; height: 28px; color: #990000;">
                                                    <p class="MsoNormal" 
                                                        style="margin: 0in 0in 0pt; text-align: center; font-size: medium;">
                                                        Unit Name</p>
                                                </td>
                                                <td style="width: 25%; height: 28px">
                                                    <asp:DropDownList ID="hname" runat="server" Width="66%">
                                                    </asp:DropDownList>
                                                    </td>
                                                <td style="width: 25%; height: 28px">
                                                    <asp:Label ID="Label3" runat="server" Text="By(Computer Id only if left)" Visible="False"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px">
                                                    <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="width: 25%; color: #990000; height: 25px">
                                                </td>
                                                <td style="width: 25%; height: 25px">
                                                    <strong>
                                        <asp:Button ID="save" runat="server" OnClick="save_Click" Text="Submit " 
                                                        style="font-weight: bold" /></strong></td>
                                                <td style="width: 25%; height: 25px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px">
                            <asp:Label ID="DDOIDLab" runat="server" Visible="False"></asp:Label></td>
                                                <td style="width: 25%; color: #990000; height: 25px">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; height: 25px; text-align: center">
                                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Are you sure that All Doctors who are under transfer has been releaved and Basic Pay Detail entries of all Doctors has been modified .....?"
                                            Visible="False" Width="624px" Font-Size="Medium"></asp:Label>&nbsp;
                                        <asp:ImageButton ID="Image" runat="server" Width="50px" Height="20px" ImageUrl="~/images/continue.gif"
                                            Visible="False" OnClick="Image_Click1" />&nbsp
                                        <strong>
                                        <asp:Button ID="cancel" runat="server" BackColor="#E0E0E0" Height="25px" OnClick="cancel_Click"
                                            Style="left: 4px; position: relative; top: -10px; font-weight: bold;" 
                                            Text="Return" Visible="False"
                                            Width="55px" /></strong></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 25px">
                            <asp:Label ID="MSGLabel" runat="server" Text=""></asp:Label></td>
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
