<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="parajoin.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parajoin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 297px;" valign="top">
    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #661700;
            font-family: Arial; height: 1px; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" style=" width: 100%; color: #ffff99;
                text-align: left; height: 18px; background-color: #661700;">
                <span style="font-size: 10pt;">&nbsp; Paramedical Section / P2 / Joinning
                    <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                    <asp:Label
                        ID="Fnamet" runat="server" Visible="False"></asp:Label></span></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 12px; width: 100%; height: 24px; background-color: burlywood;
                text-align: center">
                <span>Seniority Number:
                        <asp:Label ID="sen" runat="server" ForeColor="Red"></asp:Label></span> ,&nbsp;
                <span>Name:
                <asp:Label ID="name" runat="server"
                        ForeColor="Red"></asp:Label></span>&nbsp; ,&nbsp; Post :
                <asp:Label ID="post" runat="server" ForeColor="Red"></asp:Label>
                ,&nbsp; Place Of Posting :
                <asp:Label ID="plpost" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 14px; width: 100%; color: maroon; text-align: center">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                Post</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="DPOST" runat="server" Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="DDesign" runat="server" Width="200px" Visible="False">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%">
                Posting District</td>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="DDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                Place</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="Dplace" runat="server" OnSelectedIndexChanged="Dplace_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                                Joinning Order No:</td>
                            <td align="left" style="width: 25%">
                <asp:TextBox ID="Ornot" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                Joinning
                Order Date:</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="DDD" runat="server">
                </asp:DropDownList><asp:DropDownList ID="DMM" runat="server">
                </asp:DropDownList><asp:DropDownList ID="DYYYY" runat="server">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                                Joinning
                    Order By:</td>
                            <td align="left" style="width: 25%">
                    <asp:TextBox ID="Orbyt" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 16px; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; height: 16px; background-color: #fff8dc">
                    Date Of Joinning:</td>
                            <td align="left" style="width: 25%; height: 16px; background-color: #fff8dc">
            <asp:DropDownList ID="DD1" runat="server">
                </asp:DropDownList><asp:DropDownList ID="DM1" runat="server">
                </asp:DropDownList><asp:DropDownList ID="DY1" runat="server">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; height: 16px; background-color: #fff8dc">
                                <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label><asp:Label ID="curdate" runat="server" Visible="False"></asp:Label><asp:Label ID="oid" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                    </td>
                            <td align="left" style="width: 25%">
                    <asp:Button class="btn btn-success" ID="BSAVE" runat="server" Text="Save" OnClick="BSAVE_Click" Width="80px" /></td>
                            <td align="left" style="width: 25%; text-align: right;">
                    <asp:Button ID="PFsheet" runat="server" OnClick="PFsheet_Click" Text="Print Joinning Order" Width="144px" /></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="background-color: #661700; text-align: center; color: #ffff99; width: 100%; height: 25px;">
                    <asp:Label ID="mesg" runat="server"></asp:Label></td>
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
