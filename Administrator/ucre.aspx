<%@ Page Title="::User Creation Page::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="ucre.aspx.cs" Inherits="NewWebApp.Administrator.ucre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="text-align: center" class="container">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton ID="LinkButton2" class="btn btn-danger" runat="server" 
                            onclick="LinkButton2_Click"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton></td>
               
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center" valign="top">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" style="width: 100%; height: 100%">
                                <tr>
                                    <td colspan="3">
        <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #74211f;
            font-family: Georgia; text-align: center; border-right: #2c2713 thin solid; border-top: #2c2713 thin solid; border-left: #2c2713 thin solid; border-bottom: #2c2713 thin solid;" cellpadding="0" cellspacing="0">
            <tr>
            
                <td colspan="2" style="color: #ffffc0;
                    text-align: center; background-color:#6666ff;">
                    Welcome User::
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 100%; color: black; text-align: center">
                    <div style="text-align: center">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td style="width: 25%;" >
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        District :-</td>
                                    <td style="width: 25%;" >
                    <asp:DropDownList ID="DDistrict" runat="server" class="form-control"  Width="88%">
                    </asp:DropDownList></td>
                                    <td style="width: 25%; ">
                                    </td>
                                    
                                </tr>
                               
                                <tr>
                                    <td style="width: 25%">
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        Full Name :-</td>
                                    <td style="width: 25%">
                    <asp:TextBox ID="username" runat="server" class="form-control" MaxLength="190" Width="87%"></asp:TextBox></td>
                                    <td style="width: 25%">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%; ">
                                    </td>
                                    <td style="width: 25%;  text-align: left">
                                        Designation :-</td>
                                    <td style="width: 25%; ">
                    <asp:DropDownList ID="DDesign" class="form-control" runat="server" Width="88%">
                    </asp:DropDownList></td>
                                    <td style="width: 25%; ">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%">
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        User&nbsp; ID :-</td>
                                    <td style="width: 25%">
                    <asp:TextBox ID="userid" runat="server" class="form-control" MaxLength="15" Width="88%"></asp:TextBox></td>
                                    <td style="width: 25%">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%; ">
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        Password :-</td>
                                    <td style="width: 25%; ">
                    <asp:TextBox ID="upass" runat="server" class="form-control" MaxLength="15" TextMode="Password" Width="88%"></asp:TextBox></td>
                                    <td style="width: 25%; ">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%">
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        Level :-</td>
                                    <td style="width: 25%">
                    <asp:DropDownList ID="lavel" runat="server" class="form-control" Width="88%" OnSelectedIndexChanged="lavel_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                    <td style="width: 25%">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%; ">
                                    </td>
                                    <td style="width: 25%; text-align: left">
                    <asp:Label ID="Label5" runat="server" Text="Permission :-"></asp:Label></td>
                                    <td style="width: 25%; text-align: left">
                    <asp:CheckBox ID="A" runat="server" ForeColor="Brown" Text="ADD" /> &nbsp;&nbsp;<asp:CheckBox
                        ID="D" runat="server" ForeColor="Brown" Text="DELETE" />&nbsp;&nbsp;<asp:CheckBox ID="E"
                            runat="server" ForeColor="Brown" Text="EDIT" /></td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;<asp:CheckBox ID="R" runat="server"
                                ForeColor="Brown" Text="READ" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%">
                                    </td>
                                    <td style="width: 25%; text-align: left">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Firebrick"
                        Visible="False" Width="160px"></asp:Label></td>
                                    <td style="width: 25%">
                                        <asp:Button ID="Create" runat="server" Text="Create" OnClick="Create_Click" class="btn btn-success" /></td>
                                    <td style="width: 25%">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="#74211F"
                        OnClick="LinkButton1_Click">Existing User List</asp:LinkButton></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%; background-color: #fff8dc">
                                    </td>
                                    <td style="width: 25%; background-color: #fff8dc">
                                    </td>
                                    <td style="width: 25%; background-color: #fff8dc">
                    <asp:TextBox ID="maxid" runat="server" Visible="False" Width="32px"></asp:TextBox><asp:DropDownList ID="UP" runat="server" Width="80px" Visible="False">
                    </asp:DropDownList></td>
                                    <td style="width: 25%; background-color: #fff8dc">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 100%; text-align: right; color: #2c2713; background-color: #6666ff;">
                    </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 100%; color: #2c2713; text-align: center; background-color: #fff8dc;">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F"
                        Width="100%" Height="18px" Visible="False">Click on userid to change Permission </asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 12px; width: 100%; color: #2c2713; text-align: left">
                    <asp:Table ID="Table1" runat="server" Font-Bold="True" Font-Size="Small" CellPadding="0" CellSpacing="0" Width="100%">
                    </asp:Table>
                </td>
            </tr>
        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataKeyNames="iduser" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                        Width="504px" Visible="False">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="User Name" SortExpression="username" />
                            <asp:BoundField DataField="userid" HeaderText="Login Id" SortExpression="userid" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>"
                        DeleteCommand="Delete from Ucreate where iduser=@iduser" SelectCommand="SELECT username, userid, iduser FROM Ucreate">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="GridView1" Name="newparameter" PropertyName="SelectedValue" />
                        </DeleteParameters>
                    </asp:SqlDataSource>
        </div>
        </div>

</asp:Content>
