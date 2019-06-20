<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="DATAMANIPULATION.aspx.cs" Inherits="NewWebApp.Administrator.DATAMANIPULATION" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="table table-responsive-sm" style="width: 80%; height: 80%">
        <tr>
            <td colspan="2" style="font-weight: bold; font-size: 18px; width: 100%; color: #ffcc00;
                background-color: #000033">
                DATABASE Activities</td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; width: 100%; color: #ffffff; background-color: #660000">
                Database Connection Change in Web Config</td>
        </tr>
        <tr>
            <td style="width: 50%">
                Connection String(CS)</td>
            <td style="width: 50%; text-align: left">
                <asp:TextBox ID="txtConnectionString" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 50%">
                mK V</td>
            <td style="width: 50%; text-align: left">
                <asp:TextBox ID="txtmyKey" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 50%; text-align: right">
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Check/Use/Conform Value" /></td>
            <td style="width: 50%; text-align: left">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                <asp:Button ID="Button3" runat="server" ForeColor="Black" OnClick="Button3_Click"
                    Text="Change value of webconfig" /></td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #660000">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="color: #000033; background-color: #000033">
                .&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #660000">
                &nbsp;Database Details</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="DATAD" runat="server" OnClick="DATAD_Click" Text="Click Here To See Database Details"
                    Width="256px" />
                <asp:Button ID="HD" runat="server" OnClick="HD_Click" Text="Hide Details" /></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 10px" valign="top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                    Visible="False">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="xtype" HeaderText="xtype" SortExpression="xtype" />
                        <asp:BoundField DataField="uid" HeaderText="uid" SortExpression="uid" />
                        <asp:BoundField DataField="info" HeaderText="info" SortExpression="info" />
                        <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                        <asp:BoundField DataField="base_schema_ver" HeaderText="base_schema_ver" SortExpression="base_schema_ver" />
                        <asp:BoundField DataField="replinfo" HeaderText="replinfo" SortExpression="replinfo" />
                        <asp:BoundField DataField="parent_obj" HeaderText="parent_obj" SortExpression="parent_obj" />
                        <asp:BoundField DataField="crdate" HeaderText="crdate" SortExpression="crdate" />
                        <asp:BoundField DataField="ftcatid" HeaderText="ftcatid" SortExpression="ftcatid" />
                        <asp:BoundField DataField="schema_ver" HeaderText="schema_ver" ReadOnly="True" SortExpression="schema_ver" />
                        <asp:BoundField DataField="stats_schema_ver" HeaderText="stats_schema_ver" ReadOnly="True"
                            SortExpression="stats_schema_ver" />
                        <asp:BoundField DataField="type" HeaderText="type" ReadOnly="True" SortExpression="type" />
                        <asp:BoundField DataField="userstat" HeaderText="userstat" ReadOnly="True" SortExpression="userstat" />
                        <asp:BoundField DataField="sysstat" HeaderText="sysstat" ReadOnly="True" SortExpression="sysstat" />
                        <asp:BoundField DataField="indexdel" HeaderText="indexdel" ReadOnly="True" SortExpression="indexdel" />
                        <asp:BoundField DataField="refdate" HeaderText="refdate" ReadOnly="True" SortExpression="refdate" />
                        <asp:BoundField DataField="version" HeaderText="version" ReadOnly="True" SortExpression="version" />
                        <asp:BoundField DataField="deltrig" HeaderText="deltrig" ReadOnly="True" SortExpression="deltrig" />
                        <asp:BoundField DataField="instrig" HeaderText="instrig" ReadOnly="True" SortExpression="instrig" />
                        <asp:BoundField DataField="updtrig" HeaderText="updtrig" ReadOnly="True" SortExpression="updtrig" />
                        <asp:BoundField DataField="seltrig" HeaderText="seltrig" ReadOnly="True" SortExpression="seltrig" />
                        <asp:BoundField DataField="category" HeaderText="category" ReadOnly="True" SortExpression="category" />
                        <asp:BoundField DataField="cache" HeaderText="cache" ReadOnly="True" SortExpression="cache" />
                    </Columns>
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#660000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>"
                    SelectCommand="SELECT * from sysobjects where xtype='u' and uid=1"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #660000">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="color: #000033; height: 28px; background-color: #000033">
                .</td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #660000">
                Database Change Owner</td>
        </tr>
        <tr>
            <td style="width: 50%; text-align: right">
                <asp:Button ID="SELTAB" runat="server" OnClick="SELTAB_Click" Text="Select Users Tables " /></td>
            <td style="width: 50%; text-align: left">
                <asp:DropDownList ID="dd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dd_SelectedIndexChanged"
                    Width="240px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 50%; text-align: right">
                <asp:Button ID="SELUSR" runat="server" OnClick="SELUSR_Click" Text="Select Users" />
            </td>
            <td style="width: 50%; text-align: left">
                <asp:DropDownList ID="ddu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddu_SelectedIndexChanged"
                    Width="240px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%; text-align: center">
                <asp:Label ID="TANDUMES" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 50%; text-align: right">
            </td>
            <td style="width: 50%; text-align: left">
                <asp:Button ID="CHOW" runat="server" OnClick="CHOW_Click" Text="Change Owner" Width="200px" />
                <asp:Label ID="LCHOW" runat="server" Font-Bold="True" ForeColor="#404040"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #660000">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="color: #000033; background-color: #000033">
                .</td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #660000">
                Database Backup</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 12px">
            </td>
            <td style="width: 100px; height: 12px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 25px">
            </td>
            <td style="width: 100px; height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>

</asp:Content>
