<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="parap2qual.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap2qual" %>
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
                    <td style="width: 100%; height: 20px; text-align: left; color: #ffffff; background-color: #661700; font-size: 12pt;" valign="top">
                        <div style="text-align: left">
                            <span style="font-weight: bold; font-size: 12pt; color: #ffffff">Information About
                    Qualification
                                <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></span></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 311px;" valign="top">
        <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #3366cc;
            font-family: Arial; height: 35px; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2" style="background-image: url(../images/tab.jpg); width: 100%; color: #ffffff;
                    text-align: center">
                    <span style="font-size: 10px"></span></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 100%; color: #661700; text-align: left">
                    <div style="text-align: center">
                        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                            <tr>
                                <td align="left" colspan="2" style="height: 25px; background-color: #fff8dc; text-align: center">
                                    GPF Number:&nbsp;
                    <asp:Label ID="sen" runat="server" ForeColor="Red"></asp:Label></td>
                                <td align="left" colspan="2" style="height: 25px; background-color: #fff8dc; text-align: center">
                    Name:<asp:Label ID="name" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px;">
                                </td>
                                <td align="left" style="width: 25%; height: 25px;">
                    Degree/Diploma</td>
                                <td align="left" style="width: 25%; height: 25px;">
                                    <asp:DropDownList ID="DEG" runat="server" OnSelectedIndexChanged="DEG_SelectedIndexChanged"
                        Width="160px">
                        
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px;">
                    <asp:TextBox ID="maxid" runat="server" Width="8px" Visible="False" Height="16px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    Subject/Specialization</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:DropDownList ID="DES" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DES_SelectedIndexChanged"
                        Width="160px">                       
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px;">
                                </td>
                                <td align="left" style="width: 25%; height: 25px;">
                <asp:Label ID="Msg" runat="server" Text="Label" Visible="False" ForeColor="#C00000"></asp:Label></td>
                                <td align="left" style="width: 25%; height: 25px;">
                    <asp:Button class="btn btn-success" ID="save" runat="server" OnClick="save_Click" Text="Save" Width="121px" /></td>
                                <td align="left" style="width: 25%; height: 25px;">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 100%; text-align: left; font-size: 12px;" valign="top">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Maroon" GridLines="None" Height="50%" Width="100%" DataKeyNames="qid_serial">
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="QuaName" HeaderText="Degree" SortExpression="QuaName" />
                            <asp:BoundField DataField="spname" HeaderText="Specialization" SortExpression="spname" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS%>"
                        DeleteCommand="delete from PMDqual_det  WHERE (qid_serial = @qid_serial)" SelectCommand="SELECT PMDqual_det.qid_serial, PMDspecialization.spname, PMDQualification.QuaName FROM PMDqual_det INNER JOIN PMDQualification ON PMDqual_det.qid = PMDQualification.QuaId INNER JOIN PMDspecialization ON PMDqual_det.sid = PMDspecialization.spid WHERE (PMDqual_det.idno = @idno) ORDER BY PMDQualification.QuaName">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="Gridview1" Name="qid_serial" PropertyName="SelectedValue" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 12px; width: 100%; color: #661700; background-color: #661700;
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
