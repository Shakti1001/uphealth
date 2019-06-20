<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="parap2enquiry.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap2enquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 20px; background-color: #661700; text-align: left"
                        valign="top">
                        <span style="font-weight: bold; font-size: 12pt; color: #ffffff; background-color: #661700">
                            &nbsp;Departmental Proceedings/Enquiry Entry<asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                            <asp:Label
                            ID="Fnamet" runat="server" Visible="False"></asp:Label></span></td>
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
            <table class="table table-responsive-sm" style="width: 100%; height: 35px; font-weight: bold; color: #661700; font-family: Arial; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 50%; color: #661700; background-color: #fffbd6; height: 25px;">
                        <span style="color: #661700">GPF Number:</span>
                        <asp:Label ID="sen" runat="server" ForeColor="#C00000"></asp:Label></td>
                    <td style="width: 50%; color: #661700; background-color: #fffbd6; height: 25px;">
                        <span style="color: #661700">Name:</span><asp:Label ID="name" runat="server" ForeColor="#C00000"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; color: #661700;
                        text-align: center">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;">
                                    </td>
                                    <td align="left" style="width: 25%; height: 25px;">
                        Dept. Proceedings Type</td>
                                    <td align="left" style="width: 25%; height: 25px;">
                        <asp:DropDownList ID="DET" runat="server" Width="160px" OnSelectedIndexChanged="DET_SelectedIndexChanged">
                            <asp:ListItem>--select--</asp:ListItem>
                            <asp:ListItem>Administrative</asp:ListItem>
                            <asp:ListItem>Complained</asp:ListItem>
                            <asp:ListItem>Disciplinary</asp:ListItem>
                        </asp:DropDownList></td>
                                    <td align="left" style="width: 25%; height: 25px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                    </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        Proceedings Status</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                        <asp:DropDownList ID="DES" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="DES_SelectedIndexChanged">
                            <asp:ListItem>--select--</asp:ListItem>
                            <asp:ListItem>Imposed Panishment</asp:ListItem>
                            <asp:ListItem>Under Investigation</asp:ListItem>
                        </asp:DropDownList></td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%;">
                                    </td>
                                    <td align="left" style="width: 25%;">
                        <asp:Label ID="Eqr" runat="server" Text="Proceedings Result" Width="144px"></asp:Label>
                                        <asp:Label ID="Comp" runat="server" Font-Size="Smaller" ForeColor="Red" Text="(If Complete)"></asp:Label></td>
                                    <td align="left" style="width: 25%;">
                        <asp:TextBox ID="EResult" runat="server" Width="160px"></asp:TextBox></td>
                                    <td align="left" style="width: 25%;">
                        <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                    </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                    </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                        <asp:Button ID="SAVE" runat="server" Text="Save" OnClick="SAVE_Click" /></td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                    <asp:Button ID="FSheet" runat="server" OnClick="FSheet_Click" Text="Fact Sheet"
                            Width="96px" Font-Size="X-Small" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 12px; color: #ffffff; text-align: left">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" DataKeyNames="enqid" Height="50%" Width="100%">
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="enqtype" HeaderText="Enquiry Type" SortExpression="enqtype" />
                                <asp:BoundField DataField="enqstatus" HeaderText="Enquiry Status" SortExpression="enqstatus" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS%>"
                            SelectCommand="SELECT enqid, enqtype, enqstatus FROM PMDEnquiry WHERE (idno = @idno)" DeleteCommand="delete from PMDEnquiry WHERE (enqid = @enqid)">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:ControlParameter ControlID="Gridview1" Name="enqid" PropertyName="SelectedValue" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 12px; color: #661700; background-color: #661700;
                        text-align: center">
                        .</td>
                </tr>
            </table>
       </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
