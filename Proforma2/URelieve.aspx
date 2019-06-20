<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="URelieve.aspx.cs" Inherits="NewWebApp.Proforma2.URelieve" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/disableprint.js" type="text/javascript" language="javascript">
</script>
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%; font-weight: normal; font-size: 12px; font-family: Arial;" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                    
                    <asp:LinkButton ID="LinkButton2" class="btn btn-danger" runat="server" OnClick="LinkButton2_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>    
                    </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 297px;" valign="top">
    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%;
            font-family: Arial; height: 1px; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" style=" width: 100%; color: #ffff99;
                text-align: left; background-color: #661700; height: 25px; font-size: 14px;">
                &nbsp;Medical Section /
                Relieve/Retire P2 Option
                <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                    <asp:Label
                        ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 12pt; width: 100%; height: 24px; background-color: burlywood;
                text-align: center">
                Seniority No:<asp:Label ID="sen" runat="server" ForeColor="Blue"></asp:Label>,Name:<asp:Label ID="name" runat="server"
                        ForeColor="Blue"></asp:Label>, Last Post:<asp:Label ID="post" runat="server" ForeColor="Blue"></asp:Label>,
                Last
                    Place Of Posting:<asp:Label ID="plpost" runat="server" ForeColor="Blue"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 14px; width: 100%; color: maroon; text-align: center">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; font-size: 12pt; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; font-size: 12pt; height: 25px;">
                                Order No:</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; font-size: 12pt; height: 25px;">
                <asp:TextBox class="form-control" ID="Ornot" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; font-size: 12pt; height: 25px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; font-size: 12pt; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; font-size: 12pt; height: 25px;">
                    Order By:</td>
                                              <td align="left" style="width: 25%; background-color: #fff8dc; font-size: 12pt; height: 25px;">
                                <asp:DropDownList class="form-control" ID="JORDERDD" runat="server" Width="80%" OnSelectedIndexChanged="JORDERDD_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; font-size: 12pt; height: 25px;">
                <asp:DropDownList class="form-control" ID="DDD" runat="server" Visible="False">
                </asp:DropDownList><asp:DropDownList class="form-control" ID="DMM" runat="server" Visible="False">
                </asp:DropDownList><asp:DropDownList class="form-control" ID="DYYYY" runat="server" Visible="False">
                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; font-size: 12pt; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; font-size: 12pt; height: 25px;">
                    Order Date:</td>
          
                                
                                <TD style="HEIGHT: 14px; width: 329px; text-align: left;" vAlign="top" align="center">
                                <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajx:ToolkitScriptManager>
										<asp:TextBox class="form-control" ID="OrDate" runat="server" Width="105px" style="background-color: white" ></asp:TextBox>
                   
                                <asp:Image ID="Imagecal" runat="server" ImageUrl="~/Proforma2/calender/cal_img/cal.gif" />
                                <ajx:CalendarExtender ID="Calendar1" PopupButtonID="Imagecal" runat="server" TargetControlID="OrDate"
    Format="dd/MM/yyyy">
</ajx:CalendarExtender>
                                </TD>
                                
                            <td align="left" style="width: 25%; background-color: #fff8dc; font-size: 12pt; height: 25px;">
                                &nbsp;<asp:TextBox class="form-control" ID="Orbyt" runat="server" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; font-size: 12pt; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; font-size: 12pt; height: 25px;">
                                Reliever Name</td>
                            <td align="left" style="width: 25%; font-size: 12pt; height: 25px;">
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%; font-size: 12pt; height: 25px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: left">
            <asp:DropDownList class="form-control" ID="DD1" runat="server" Visible="False">
                </asp:DropDownList><asp:DropDownList class="form-control" ID="DM1" runat="server" Visible="False">
                </asp:DropDownList><asp:DropDownList class="form-control" ID="DY1" runat="server" Visible="False">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: left">
                    Date Of Relieving</td>
                            <TD style="HEIGHT: 14px; width: 329px; text-align: left;" vAlign="top" align="center">
										<asp:TextBox ID="DORtext" class="form-control" runat="server" Width="105px" style="background-color: white" ></asp:TextBox>
                                <asp:Image ID="DORImage" runat="server" ImageUrl="~/Proforma2/calender/cal_img/cal.gif" /><ajx:CalendarExtender ID="CalendarExtender1" PopupButtonID="DORImage" runat="server" TargetControlID="DORtext"
    Format="dd/MM/yyyy">
</ajx:CalendarExtender></TD><td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: left">
                                <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label><asp:Label ID="curdate" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; text-align: left; height: 25px;">
                                <span style="color: #990000">If retire then please</span></td>
                            <td align="left" style="width: 25%; text-align: left; height: 25px;">
                                <span style="color: #990000">click here</span><asp:CheckBox
                        ID="retire" runat="server" Text="Retire" ForeColor="#661700" /></td>
                            <td align="left" style="width: 25%; text-align: left; height: 25px;">
                    <asp:Button ID="BSAVE" class="btn btn-success" runat="server" Text="Save" OnClick="BSAVE_Click" Width="80px" /></td>
                            <td align="left" style="width: 25%; text-align: left; height: 25px;">
                    <asp:Button ID="PFsheet" class="btn btn-default" CssClass="btn btn-danger" runat="server" OnClick="PFsheet_Click" Text="Print Charge Certificate" Width="144px" Visible="False" /></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="color: #ffff99; background-color: #661700; text-align: center; width: 100%; height: 24px;">
                    <asp:Label ID="mesg" runat="server"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="font-size: 12px; text-align: left">
                <asp:Table ID="Table1" runat="server" Visible="False" CellPadding="0" CellSpacing="0" Width="100%">
                </asp:Table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="statussr"
                    DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Visible="False">
                    <Columns>
                    <asp:TemplateField HeaderText="S.No"><ItemTemplate ><%# Container.DataItemIndex+1 %></ItemTemplate><ItemStyle HorizontalAlign="Left" /><HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="orderby" HeaderText="Order By" SortExpression="orderby" />
                <asp:BoundField DataField="orderno" HeaderText="Order No" SortExpression="orderno" />
                <asp:BoundField DataField="orderdate" HeaderText="Order Date" SortExpression="orderdate" />
                <asp:BoundField DataField="currentdate" HeaderText="Issue Date" SortExpression="currentdate" >
                </asp:BoundField>
                       <asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
PostBackUrl='<%#"~/Proforma2/Joinandrelieve/RelOrdprint.aspx?statussr=" + Eval("statussr")%>' Text="Print"></asp:LinkButton>

</ItemTemplate>
</asp:TemplateField>
</Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#661700" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
                    SelectCommand="SELECT statussr,orderby,orderno, Convert(char,orderdate,103) as orderdate,  Convert(char,currentdate,103)as currentdate FROM  status_join_releive where idno=@idno&#13;&#10;&#13;&#10;&#13;&#10;" DeleteCommand="Delete FROM  status_join_releive where statussr=@statussr">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:ControlParameter ControlID="GridView1" Name="statussr" PropertyName="SelectedValue" />
                    </DeleteParameters>
                </asp:SqlDataSource>
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
