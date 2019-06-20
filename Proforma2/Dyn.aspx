<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Dyn.aspx.cs" Inherits="NewWebApp.Proforma2.Dyn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
            <tr>
                <td style="width: 100%; height: 100%">
                    <div style="text-align: center">
                        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                            <tr>
                                <td style="width: 100%; text-align: right;">
                                    <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                                        onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 100%; color: #ffffff; background-color: #661700">
                                    Dynamic Query</td>
                            </tr>
                            <tr>
                                <td style="font-weight: normal; width: 100%; color: #0033cc; background-color: #ffffff;
                                    text-align: left">
                                    <span style="color: #330000"><strong>Step-1</strong></span> First choose <span style="color: #990000">
                                        field</span> from fields.<br />
                                    <strong><span style="color: #330000">Step-2</span></strong> Then select <span style="color: #990000">
                                        operator</span>---write or select&nbsp; its correspondance <span style="color: #990000">
                                            value</span>---after that click on <span style="color: #990000">select string</span>.
                                    <span style="color: #999999">(The string comes to selected string area)<br />
                                    </span><strong><span style="color: #330000">Step-3</span></strong> &nbsp;Choose
                                    <span style="color: #990000">value</span> form selected string with <span style="color: #990000">
                                        brackets</span> or <span style="color: #990000">query operators</span>. <span style="color: #999999">
                                            (The strings and query operator &nbsp;will appear on the selected criteria)<br />
                                        </span><span style="color: #330000"><strong>Step-4</strong></span> Then click
                                    on <span style="color: #990000">check criteria</span> to check your string rigth
                                    or wrong against the Structured Qurey Language.<br />
                                    <span style="color: #330000"><strong>Step-5</strong></span> Then click on <span style="color: #990000">
                                        view report</span> to find your Dynamic Data based on your query.</td>
                            </tr>
                            <tr>
                                <td style="width: 100%" valign="top">
                                    <table class="table table-responsive-sm" style="width: 99%; border-right: #660000 thin solid; border-top: #660000 thin solid; border-left: #660000 thin solid; border-bottom: #660000 thin solid;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 33%; font-weight: bold; color: maroon; background-color: burlywood;">
                                                Fields</td>
                                            <td style="width: 33%; font-weight: bold; color: maroon; background-color: burlywood;">
                                                Oprators and its value</td>
                                            <td style="width: 33%; font-weight: bold; color: maroon; background-color: burlywood;">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; background-color: #fff8dc;">
                                                &nbsp;<asp:ListBox ID="Selfield" runat="server" OnSelectedIndexChanged="Selfield_SelectedIndexChanged" Width="90%" AutoPostBack="True">
                                                    <asp:ListItem Value="1">name</asp:ListItem>
                                                    <asp:ListItem Value="2">DateofBirth</asp:ListItem>
                                                    <asp:ListItem Value="3">Postname</asp:ListItem>
                                                    <asp:ListItem Value="4">PostingDistrict</asp:ListItem>
                                                    <asp:ListItem Value="5">PostingPlace</asp:ListItem>
                                                    <asp:ListItem Value="6">Homedistrict</asp:ListItem>
                                                    <asp:ListItem Value="7">Qualification</asp:ListItem>
                                                    <asp:ListItem Value="8">Specialization</asp:ListItem>
                                                    <asp:ListItem Value="9">Cadre</asp:ListItem>
                                                     <asp:ListItem Value="10">DateofJoining</asp:ListItem>                                                   
                                                </asp:ListBox></td>
                                            <td style="width: 35%; background-color: #fff8dc;">
                                                <asp:DropDownList ID="Doprat" runat="server" Width="30%">
                                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                                    <asp:ListItem Value="1">=</asp:ListItem>
                                                    <asp:ListItem Value="2">!=</asp:ListItem>
                                                    <asp:ListItem Value="3">like</asp:ListItem>
                                                    <asp:ListItem Value="4">&lt;</asp:ListItem>
                                                    <asp:ListItem Value="5">&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="Text1" runat="server" Visible="False" Width="60%"></asp:TextBox>
                                                <asp:DropDownList ID="Dval" runat="server" Width="60%">
                                                </asp:DropDownList><br />
                                                </td>
                                            <td style="width: 40%; background-color: #fff8dc;">
                                                <asp:Button ID="Select" runat="server" Text="Select String" OnClick="Select_Click" />&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%;font-weight: bold; color: maroon; background-color: burlywood">
                                                Selected String</td>
                                            <td style="width: 35%;font-weight: bold; color: maroon; background-color: burlywood">
                                                Query Oprators</td>
                                            <td style="width: 40%; font-weight: bold; color: maroon;background-color: burlywood">
                                                <asp:Label ID="count" runat="server" Visible="False">0</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; background-color: #fff8dc">
                                                <asp:ListBox ID="stringList" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="stringList_SelectedIndexChanged"></asp:ListBox><br />
                                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Refresh Selected String" /></td>
                                            <td style="width: 70%; background-color: #fff8dc" colspan="2">
                                                <asp:Button ID="open" runat="server" Text="Open Bracket" OnClick="open_Click" />&nbsp;
                                                <asp:Button ID="ButtAnd" runat="server" Text="And" Width="56px" OnClick="ButtAnd_Click" />
                                                /
                                                <asp:Button ID="ButtOR" runat="server" Text="OR" Width="56px" OnClick="ButtOR_Click" />
                                                <asp:Button ID="Bclose" runat="server" Text="Close Bracket" OnClick="Bclose_Click" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-weight: bold; width: 100%; color: maroon; background-color: burlywood;
                                                text-align: center">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; font-weight: bold; color: maroon; background-color: burlywood; text-align: left;" colspan="3">
                                                The Selected Criteria ......</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-weight: bold; width: 100%; color: maroon">
                                    <asp:TextBox ID="StringText" runat="server" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-weight: bold; width: 100%; color: maroon">
                                                <asp:Button ID="BRef" runat="server" Text="Refresh" OnClick="BRef_Click" />
                                                <asp:Label ID="StringLabel" runat="server" Visible="False"></asp:Label>
                                                <asp:Button ID="BCheckCri" runat="server" Text="Check Criteria" OnClick="BCheckCri_Click" />
                                                <asp:Button ID="BViewR" runat="server" Text="View Report" Enabled="False" OnClick="BViewR_Click" />&nbsp;
                                                </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-weight: bold; width: 100%; color: maroon; background-color: #661700">
                                                .</td>
                                        </tr>
                                    </table>
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 100%" valign="top">
                                                <asp:Label ID="errmess" runat="server" Font-Bold="True" ForeColor="#C00000" Visible="False"></asp:Label><br />
                                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 99%">
                                        <tr>
                                            <td style="width: 100%; background-color: #fff8dc; text-align: left">
                                                <asp:Table class="table table-responsive-sm" ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="False"
                                                    Width="100%" Font-Size="Small">
                                                </asp:Table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; color: #e8cd76; background-color: #e8cd76;" valign="top">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
                                    </asp:DropDownList><asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
                                    </asp:DropDownList><asp:DropDownList ID="Dfield" runat="server" Width="10%" AutoPostBack="True" OnSelectedIndexChanged="Dfield_SelectedIndexChanged" Visible="False">
                                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                                    <asp:ListItem Value="1">name</asp:ListItem>
                                                    <asp:ListItem Value="2">DateofBirth</asp:ListItem>
                                                    <asp:ListItem Value="3">Postname</asp:ListItem>
                                                    <asp:ListItem Value="4">PostingDistrict</asp:ListItem>
                                                    <asp:ListItem Value="5">PostingPlace</asp:ListItem>
                                                    <asp:ListItem Value="6">Homedistrict</asp:ListItem>
                                                    <asp:ListItem Value="7">Qualification</asp:ListItem>
                                                    <asp:ListItem Value="8">Specialization</asp:ListItem>
                                                    <asp:ListItem Value="9">Cadre</asp:ListItem>
                                                </asp:DropDownList>.</td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
