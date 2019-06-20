<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="NewWebApp.TransferSec.Transfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="../../js/disableprint.js" type="text/javascript" language="javascript">
</script>
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton2" runat="server" 
                            onclick="LinkButton2_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 297px;" valign="top">
    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #661700;
            font-family: Arial; height: 1px; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" style=" width: 100%; color: #ffff99;
                text-align: left; height: 18px; background-color: #661700;">
                <span style="font-size: 10pt;">&nbsp; Medical Section / P2 / Transfer
                    <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                    <asp:Label
                        ID="Fnamet" runat="server" Visible="False"></asp:Label></span></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 12px; width: 100%; height: 24px; background-color: burlywood;
                text-align: center">
                <span>
                                Transfer
                    Order No:<asp:DropDownList ID="JORDERDD" runat="server" Width="60%" AutoPostBack="True" OnSelectedIndexChanged="JORDERDD_SelectedIndexChanged">
                                </asp:DropDownList></span></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 14px; width: 100%; height: 24px; background-color: white;
                text-align: center">
                <asp:Label ID="TrLabel" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 14px; width: 100%; color: maroon; text-align: center">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td align="left" style="width: 25%;  text-align: right;">
                                Transfer
                                From&nbsp; :</td>
                            <td align="left" style="width: 25%;  border-right-style: solid; border-right-color: #660000;">
                            </td>
                            <td align="left" style="width: 25%; text-align: right;">
                                Transfer
                                To:</td>
                            <td align="left" style="width: 25%; ">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #ffffff; border-right-style: solid; height: 20px; border-right-color: #ffffff;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #ffffff; border-right-style: solid; height: 20px; border-right-color: #ffffff;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #ffffff; border-right-style: solid; height: 20px; border-right-color: #ffffff;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #ffffff; border-right-style: solid; height: 20px; border-right-color: #ffffff;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            Seniority Number</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; border-right-style: solid; border-right-color: #660000;">
                        <asp:Label ID="sen" runat="server" ForeColor="Blue"></asp:Label></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="DDesign" runat="server" Width="200px" Visible="False">
                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            Name
                            </td>
                            <td align="left" style="width: 25%; border-right-style: solid;  border-right-color: #660000;">
                <asp:Label ID="name" runat="server"
                        ForeColor="Blue"></asp:Label></td>
                            <td align="left" style="width: 25%">
                                Post</td>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="DPOST" runat="server" Width="200px">
                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                Post</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; border-right-style: solid; border-right-color: #660000;">
                    <asp:Label ID="post" runat="server" ForeColor="Blue"></asp:Label></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                Transfer District</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="DDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList>
                            <asp:TextBox ID="Orbyt" runat="server" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                                Place Of Posting</td>
                            <td align="left" style="width: 25%; border-right-style: solid;  border-right-color: #660000;">
                    <asp:Label ID="plpost" runat="server" ForeColor="Blue"></asp:Label></td>
                            <td align="left" style="width: 25%">
                                Transfer Place</td>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="Dplace" runat="server" OnSelectedIndexChanged="Dplace_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; border-right-style: solid; border-right-color: #660000;">
                                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox></td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label><asp:Label ID="curdate" runat="server" Visible="False"></asp:Label><asp:Label ID="oid" runat="server" Visible="False"></asp:Label></td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                &nbsp;<asp:LinkButton ID="fLink" runat="server" Visible="False" OnClick="fLink_Click">Check Factsheet</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 20px; text-align: center;" colspan="4">
                                </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:Button class="btn btn-success" ID="BSAVE" runat="server" Text="Save" OnClick="BSAVE_Click" Width="80px" /></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; height: 16px; background-color: #ffffff;
                                text-align: center">
                    <asp:Label ID="mesg" runat="server"></asp:Label>
                                <asp:LinkButton ID="LinkButton1" runat="server" Visible="False" OnClick="LinkButton1_Click"></asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; height: 25px; background-color: #fff8dc;
                                text-align: right">
                    </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="background-color: #661700; text-align: center; color: #ffff99; width: 100%; height: 25px;">
                    </td>
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
