<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="editposting.aspx.cs" Inherits="NewWebApp.paramedicalstaff.editposting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="font-weight: bold; width: 100%; color: #ffff99; height: 25px; background-color: #661700;
                        text-align: left" valign="top">
                        <span style="font-size: 12pt; color: #ffff99; background-color: #661700">Medical Section
                            / P2 / Posting Details</span></td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 275px; font-size: 12px;" valign="top">
    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #661700;
            font-family: Arial; height: 1px; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 50%; height: 17px; text-align: center; color: #661700; background-color: burlywood;">
                    <span style="color: #661700">GPF Number:</span>
                    <asp:Label ID="sen" runat="server" ForeColor="#C00000" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                <td style="width:50%; height: 17px; text-align: center; color: #661700; background-color: burlywood;">
                    Name :<asp:Label ID="name" runat="server"
                        ForeColor="#C00000" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                    <asp:Label
                        ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
            </tr>
        <tr>
            <td colspan="2" style="width: 100%; color: maroon; text-align: center">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    Posting
                    District<br />
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="(In case of other state Select none)"></asp:Label></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    <asp:DropDownList ID="DDistrict" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Other State District Name"
                                    Visible="False"></asp:Label><br />
                    <asp:TextBox ID="OtherDist" runat="server" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 25px;">
                                <asp:Label ID="Lid" runat="server" Visible="False"></asp:Label></td>
                            <td align="left" style="width: 25%; height: 25px;">
                    Place</td>
                            <td align="left" style="width: 25%; height: 25px;">
                    <asp:DropDownList ID="Dplace" runat="server" Width="200px" OnSelectedIndexChanged="Dplace_SelectedIndexChanged">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; height: 25px;">
                                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Other District/Place" Visible="False"></asp:Label>
                                <br />
                    <asp:TextBox ID="OtherPost" runat="server" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    Post</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    <asp:DropDownList ID="DPOST" runat="server" Width="200px">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; height: 25px;">
                                &nbsp;</td>
                            <td align="left" style="width: 25%; height: 25px;">
                                &nbsp;</td>
                            <td align="left" style="width: 25%; height: 25px;">
                    </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                Date of Joining (mm/dd/yyyy)</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                                <asp:TextBox ID="dojs" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 25px">
                            </td>
                            <td align="left" style="width: 25%; height: 25px">
                    Date Of Relieving (mm/dd/yyyy)</td>
                            <td align="left" style="width: 25%; height: 25px">
                                <asp:TextBox ID="doa" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%; height: 25px">
        <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="width: 25%; height: 25px; background-color: #fff8dc;
                                text-align: center">
                                <asp:Label ID="Label4" runat="server" ForeColor="#0000C0" Text="Please enter at least   current posting record  if person is joined"></asp:Label></td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right">
                    <asp:Button ID="BSAVE" runat="server" Text="Update" OnClick="BSAVE_Click" Width="80px" /></td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; height: 25px; text-align: center">
                                &nbsp;&nbsp;
                                <asp:Label ID="Msg" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; background-color: #fff8dc; text-align: center">
                                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
                                </asp:Table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 12px; width: 100%; text-align: left; font-weight: normal; color: #ffffff;">
                
        </td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; font-size: 12px; width: 100%; color: #661700;
                background-color: #661700; text-align: center">
                .</td>
        </tr>
        </table>
                        &nbsp; &nbsp;
        </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
