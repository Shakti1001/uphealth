<%@ Page Title="::Add Hospital::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Hospitaladd.aspx.cs" Inherits="NewWebApp.proforma.Hospitaladd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:LinkButton ID="LinkButton2" class="btn btn-danger" runat="server" 
                            onclick="LinkButton2_Click"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton> </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center" valign="top">
                        <div style="text-align: center">
                                    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #74211f;
            font-family: Georgia; text-align: center; border-right: #2c2713 thin solid; border-top: #2c2713 thin solid; border-left: #2c2713 thin solid; border-bottom: #2c2713 thin solid;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; color: maroon;
                                                text-align: center">
                                                <div style="text-align: center">
                                                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                                        <tr>
                                                            <td align="left" style="font-weight: bold; width: 25%;  height: 17px;
                                                                background-color: #661700; text-align: left; color: #ffff99;">
                                                                &nbsp;Add &nbsp;&nbsp;Hospital
                                                            </td>
                                                            <td align="left" style="font-weight: bold; width: 25%;  height: 17px;
                                                                background-color: #661700">
                    </td>
                                                            <td align="left" style="font-weight: bold; width: 25%;  height: 17px;
                                                                background-color: #661700">
                                                                <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
                                                            <td align="left" style="font-weight: bold; width: 25%;  height: 17px;
                                                                background-color: #661700">
                                                                <asp:Label ID="Uidt" runat="server"
                        Visible="False"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    Division</td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:DropDownList ID="DDiv" runat="server" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="DDiv_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%">
                                                            </td>
                                                            <td align="left" style="width: 25%">
                    District</td>
                                                            <td align="left" style="width: 25%">
                    <asp:DropDownList ID="DDist" runat="server" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="DDist_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    Tehshil</td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:DropDownList ID="DTEH" runat="server" AutoPostBack="True" Width="85%" OnSelectedIndexChanged="DTEH_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%">
                                                            </td>
                                                            <td align="left" style="width: 25%">
                    Block</td>
                                                            <td align="left" style="width: 25%">
                    <asp:DropDownList ID="DBLK" runat="server" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="DBLK_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    Hospital Type</td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:DropDownList ID="DHT" runat="server" Width="85%">
                    </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%">
                                                            </td>
                                                            <td align="left" style="width: 25%">
                    Hospital Name</td>
                                                            <td align="left" style="width: 25%">
                    <asp:TextBox ID="HosN" runat="server" 
                        Width="80%"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="HosN"
                                                                    ErrorMessage="Hospital Name" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$">*</asp:RegularExpressionValidator></td>
                                                            <td align="left" style="width: 25%">
                                                                <asp:TextBox ID="maxid" runat="server" AutoPostBack="True" OnTextChanged="maxid_TextChanged"
                        Visible="False" Width="8px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                <asp:Label ID="DDOIDLBL" runat="server" Text="" Visible="false"></asp:Label></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                Beds Capacity</td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:TextBox ID="NOBText" runat="server" Width="80%">0</asp:TextBox></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                <asp:ValidationSummary ID="valSum" runat="server" Font-Names="verdana" Font-Size="Small"
                                                                    HeaderText="Please  enter correct  value in following  fields:" Height="72px"
                                                                    Width="100%" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #e8cd76">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 25%; background-color: #e8cd76">
                                                                FRU Status <span style="font-size: small; font-weight: normal">(0-Non 
                                                                FRU,1-Sanctioned,2-Functioning)</span></td>
                                                            <td align="left" style="width: 25%; background-color: #e8cd76">
                    <asp:TextBox ID="FRU" runat="server" Width="80%">0</asp:TextBox></td>
                                                            <td align="left" style="width: 25%; background-color: #e8cd76">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                Building Status<span style="font-weight: normal">(0-Govt.,1-Pvt.)</span></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:TextBox ID="building" runat="server" Width="80%">0</asp:TextBox></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%">
                                                            </td>
                                                            <td align="left" style="width: 25%">
                                                            </td>
                                                            <td align="left" style="width: 25%">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="80px" /></td>
                                                            <td align="left" style="width: 25%">
                                                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="#74211F"
                                                                    OnClick="LinkButton1_Click">Existing Hospitals</asp:LinkButton></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="4" style="width: 100%; text-align: left; font-size: 12px;">
                                                                <asp:Table ID="Table1" class="table table-responsive" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="4" style="width: 100%; background-color: #661700; text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="#FFFFC0" Width="100%" Height="18px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
        </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
