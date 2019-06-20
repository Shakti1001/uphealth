﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="paraEditJR.aspx.cs" Inherits="NewWebApp.paramedicalstaff.paraEditJR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%; font-family: Georgia;">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 297px;" valign="top">
    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #661700;
            font-family: Arial; height: 1px; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;">
            <tr>
                <td colspan="2" style="background-image: url(../../images/tab.jpg); width: 100%; color: #661700;
                    text-align: center">
                    <span style="font-size: 10pt; color: #661700">&nbsp;Welcome </span><asp:Label
                        ID="Fnamet" runat="server" ForeColor="#661700"></asp:Label><asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
            </tr>
        <tr>
            <td colspan="2" style="width: 100%; color: #ffffff; background-color: #661700; text-align: center">
                <span style="font-size: 10pt">Edit Joinning / Relieving Of A Person</span></td>
        </tr>
        <tr style="font-size: 12pt">
            <td colspan="2" style=" width: 100%; color: #666666;
                text-align: center; background-color: #ffffff;">
                <span style="font-size: 10pt;"><span>प्रमाणित किया जाता है कि
                    <asp:Label ID="Relievename" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                    &nbsp; </span>
                    <asp:Label ID="Postt" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label><span>,</span><asp:Label ID="placet" runat="server" Font-Bold="True"
                            ForeColor="Blue"></asp:Label><span> &nbsp; के पद &nbsp;का कार्यभार
                            </span>
                    <asp:Label ID="orderbyt" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label><span> &nbsp; उत्तर प्रदेश के &nbsp; &nbsp; आदेश संख्या &nbsp;
                    </span>
                    <asp:Label ID="ordernot" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label><span>&nbsp; दिनाँक &nbsp; </span>
                    <asp:Label ID="orderdatet" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label><span>&nbsp; जैसा कि इसमे बताया गया है कि&nbsp; दिनाँक </span>
                    <asp:Label ID="curdatet" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label><span> कि पुर्वाहन \ अप्राहन मे हस्तान्त्रित किया गया ।<br />
                    </span></span></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 10pt; width: 100%; height: 24px; text-align: center; font-weight: bold; color: #ffffff; background-color: #661700;">
                <span style="color: #ffffff">Please Check Details</span></td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; color: maroon;
                text-align: center">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                Designation</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="DDesign" runat="server" Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                Post</td>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="DPOST" runat="server" Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                Posting District</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="DDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                    Place</td>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="Dplace" runat="server" OnSelectedIndexChanged="Dplace_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                Order No</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:TextBox ID="Ornot" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                                Order Date</td>
                            <td align="left" style="width: 25%">
                    <asp:TextBox ID="ORDText" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                Order By</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:TextBox ID="Orbyt" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                Joinning/Relieving Date</td>
                            <td align="left" style="width: 25%">
                <asp:TextBox ID="JRText" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%">
                                <asp:Label ID="idnoL" runat="server" Visible="False" ForeColor="#661700"></asp:Label><asp:Label ID="curdate" runat="server" ForeColor="#661700" Visible="False"></asp:Label><asp:Label ID="oid" runat="server" ForeColor="#661700" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:Button class="btn btn-success" ID="BSAVE" runat="server" Text="Save" OnClick="BSAVE_Click" Width="80px" /></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:Button class="btn btn-default" ID="PFsheet" runat="server" OnClick="PFsheet_Click" Text="Print Order" Width="112px" /></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="color: #661700; background-color: #661700; text-align: center">
                    <asp:Label ID="mesg" runat="server" ForeColor="White"></asp:Label>.</td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        </table>
        </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
