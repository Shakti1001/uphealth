<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="GenerateBill.aspx.cs" Inherits="NewWebApp.payrole.GenerateBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 98%">
        <tr>
            <td style="width: 100%; height: 1px; text-align: right">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 14px; width: 100%; color: #ffff99; height: 25px;
                background-color: #661700; text-align: center;">
                &nbsp;Bill Processing/Calculation Activity &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
                <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" style="font-weight: bold; font-size: 14px;
                    width: 100%; color: maroon; background-color: #fff8dc">
                    <tr style="font-size: 10pt; color: #800000">
                        <td colspan="4" style="font-weight: bold; width: 100%; color: #0033cc; height: 25px; text-align: center; font-family: Arial;">
                            </td>
                    </tr>
                    <tr style="font-size: 10pt; color: #800000">
                        <td colspan="4" style="width: 100%; height: 25px; text-align: left">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td colspan="2" style="width: 100%; height: 25px; text-align: center">
                                        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;
                                            text-align: left">
                                            <tr>
                                                <td style="width: 25%; height: 7px">
                                                </td>
                                                <td style="width: 25%; height: 7px; font-weight: bold; color: maroon; text-align: center;">
                                        DDO Name&nbsp;</td>
                                                <td style="width: 25%; height: 7px">
                                                    &nbsp;
                                        <asp:TextBox ID="DDOText" runat="server" ForeColor="#C00000" ReadOnly="True" Width="95%"></asp:TextBox></td>
                                                <td style="width: 25%; height: 7px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px">
                                                </td>
                                                <td style="width: 25%; height: 25px; text-align: center;" >
                                                    <span style="font-size: 12pt; color: maroon; font-weight: bold;">
                                        Year</span></td>
                                                <td style="width: 25%; height: 25px">
                                                    &nbsp;
                                        <asp:DropDownList ID="year" runat="server" Width="66%">
                                            
                                        </asp:DropDownList></td>
                                                <td style="width: 25%; height: 25px">
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
                                                    &nbsp;
                                        <asp:DropDownList ID="Month" runat="server" Width="66%">                                            
                                        </asp:DropDownList></td>
                                                <td style="width: 25%; height: 25px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 19px">
                                                </td>
                                                <td style="width: 25%; height: 19px; color: #990000;">
                                                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                        <span style="font-size: 12pt; color: oldlace">Individual Employee</span></p>
                                                </td>
                                                <td style="width: 25%; height: 19px">
                                                    </td>
                                                <td style="width: 25%; height: 19px">
                                                    <asp:Label ID="Label3" runat="server" Text="By(Computer Id only if left)" Visible="False"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 35px">
                                                </td>
                                                <td style="width: 25%; color: #990000; height: 35px">
                                                </td>
                                                <td style="width: 25%; height: 35px">
                                                    &nbsp;
                                        <asp:Button class="btn btn-success" ID="save" runat="server" OnClick="save_Click" Text="Submit" /></td>
                                                <td style="width: 25%; height: 35px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px">
                            <asp:DropDownList ID="DDO" runat="server" Visible="False" Width="30%">
                            </asp:DropDownList>
                            <asp:Label ID="DDOIDLab" runat="server" Visible="False"></asp:Label></td>
                                                <td style="width: 25%; color: #990000; height: 25px">
                                        <asp:DropDownList ID="Head" runat="server" Width="95%" Visible="False">
                                        </asp:DropDownList></td>
                                                <td style="width: 25%; height: 25px">
                                                    <asp:DropDownList ID="Section" runat="server" AutoPostBack="True" Width="90%" Visible="False">
                                                        <asp:ListItem Value="0">All</asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="width: 25%; height: 25px">
                                                    <asp:TextBox ID="IdnoT" runat="server" ReadOnly="True" Visible="False"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; height: 25px; text-align: center">
                                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Are you sure that All Doctors who are under transfer has been releaved and Basic Pay Detail entries of all Doctors has been modified .....?"
                                            Visible="False" Width="624px" Font-Size="Medium"></asp:Label>&nbsp;
                                        <asp:ImageButton ID="Image" runat="server" Width="105px" ImageUrl="~/Images/continue.gif"
                                            Visible="False" OnClick="Image_Click1" />&nbsp
                                        <asp:Button class="btn btn-danger" ID="cancel" runat="server"   OnClick="cancel_Click"
                                            Style="left: 4px; position: relative; top: -10px" Text="Return" Visible="False"
                                            Width="70px" /></td>
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
