<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="mprmast.aspx.cs" Inherits="NewWebApp.payrole.mprmast" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script src="../js/disableprint.js" type="text/javascript" language="javascript">
</script>
<div class="container" style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 0px; background-color: burlywood; text-align: left; font-weight: bold; font-size: 14px; color: maroon;"
                        valign="top">
                        &nbsp;Monthly Progress Report Entry:-
                        <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label><asp:Label ID="Uidt"
                            runat="server" Visible="False"></asp:Label>
                        --<asp:Label ID="lblname" runat="server" Width="50%" ForeColor="Maroon" 
                            Height="16px" style="font-size: large"></asp:Label>Com  puter Id:-<asp:Label ID="Label2" runat="server"></asp:Label>
                        <asp:Label ID="Label4" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" style="width: 100%; background-color: #fff8dc; font-weight: bold; font-size: 14px; color: maroon; text-align: left;">
                                <tr>
                                    <td style="width: 16%">
                                        &nbsp;</td>
                                    <td style="width: 16%">
                                        &nbsp;</td>
                                    <td>
                                        Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="date_CalendarExtender" runat="server" Enabled="True" 
                    TargetControlID="txtdate">
                </asp:CalendarExtender>
                                        </td>
                                        <td style="width: 16%">
                                            &nbsp;</td>
                                        <td style="width: 16%">
                                            &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 30px;">
                                        <asp:TextBox ID="DT1" runat="server"  Width="27%" Height="23px" Visible="False"></asp:TextBox> 
                                        <asp:Label ID="ddoid" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    <td style="width: 16%; height: 30px;">
                                        </td>
                                    <td style="height: 30px;">
                                        Duty Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        <asp:DropDownList ID="ddlduty" runat="server" 
                                            DataSourceID="SqlDataSource1" DataTextField="dutyname" 
                                            DataValueField="dutyid" AutoPostBack="True">
                                        </asp:DropDownList>
                                        </td>
                                        <td style="width: 16%; height: 30px;">
                                            </td>
                                        <td style="width: 16%; height: 30px;">
                                            </td>
                                </tr>
                                <tr>
                                    <td style="width: 16%">
                                        &nbsp;</td>
                                    <td style="width: 16%">
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Number of Cases"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtcase" runat="server"></asp:TextBox>
                                    </td>
                                        <td style="width: 16%">
                                            &nbsp;</td>
                                        <td style="width: 16%">
                                            &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5" 
                                        style="width: 100%; background-color: #fff8dc; text-align: center">
                                    <asp:Label ID="MD" runat="server"></asp:Label>
                                    <asp:Label ID="ME" runat="server"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" ForeColor="Black"></asp:Label>
                                        <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click1" Font-Bold="True" ForeColor="Red" Width="74px" />&nbsp;
                                        &nbsp;<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" 
                                            SelectCommand="SELECT [dutyid], [dutyname] FROM [dutytype]">
                                        </asp:SqlDataSource>
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="width: 100%; background-color: #815923; text-align:left">
                                        <span style="font-size: large; color: #FFFFFF;">Letest Top 31 Records.........</span></td>
                                </tr>
                                <tr>
                                    <td colspan="5" 
                                        style="width: 100%; background-color: burlywood; text-align: center" 
                                        align="center">
                                        <asp:GridView ID="GridView1" runat="server" Width="100%" 
                                            onrowdeleting="deleting" 
                                            onselectedindexchanged="GridView1_SelectedIndexChanged1" 
                                            DataKeyNames="idno">
                                            <Columns>
                                               <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                              <%-- <asp:BoundField DataField="date" HeaderText="Date" />
                                              <asp:BoundField DataField="dutyname" HeaderText="DutyName" />
                                               <asp:BoundField DataField="cases" HeaderText="Cases" />--%>
                                            <asp:CommandField ShowDeleteButton="true" />
                                            </Columns>
                                        
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    
                    </td>
                </tr>
            </table>
        </div>

</asp:Content>
