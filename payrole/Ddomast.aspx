<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Ddomast.aspx.cs" Inherits="NewWebApp.payrole.Ddomast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
    <table class="table table-responsive-sm table-active" style="font-weight: bold; width: 100%; color: #661700">
        <tr>
            <td colspan="2" style="width: 100%; text-align: right" valign="top">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%; text-align: center" valign="top">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td colspan="3" style="color: #ffffff; background-color: #661700">
                                Select Hospital Then&nbsp; Write DDO Name And UnderSupervision Name&nbsp;
                                <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table class="table table-responsive-sm" style="border-right: #333333 thin solid; border-top: #333333 thin solid; font-weight: bold;
                                    border-left: #333333 thin solid; width: 100%; color: #661700; border-bottom: #333333 thin solid;
                                    font-family: Georgia;">
                                    <tr>
                                        <td style="font-weight: normal; width: 100%; font-family: Arial; font-size: 12px; text-align: left; background-color: #fff8dc;">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <Columns>
                                                    <asp:BoundField DataField="divname" HeaderText="Division" SortExpression="divname" />
                                                    <asp:BoundField DataField="districtname" HeaderText="DistrictName" SortExpression="districtname" />
                                                    <asp:BoundField DataField="tehsilname" HeaderText="TehsilName" SortExpression="tehsilname" />
                                                    <asp:BoundField DataField="blockname" HeaderText="BlockName" SortExpression="blockname" />
                                                    <asp:BoundField DataField="htype" HeaderText="Type" SortExpression="htype" />                                                 
                                                    <asp:TemplateField HeaderText="Hospital Name" SortExpression="hname">                                                       
                                                        <ItemTemplate>                                                       
                                                        <asp:CheckBox ID="chkH" runat="server" Text='<%# Bind("hname") %>' />                                                          
                                                        </ItemTemplate>
                                                        <ItemStyle ForeColor="#004000" Font-Bold="True" />
                                                    </asp:TemplateField>  
                                                    <asp:BoundField DataField="h_supw_name" HeaderText="Superwiser"  SortExpression="h_supw_name"/>                                                 
                                                    <asp:BoundField DataField="bedoccupacy" HeaderText="bedoccupacy" SortExpression="bedoccupacy" />
                                                
                                                </Columns>
                                                <HeaderStyle BackColor="BurlyWood" />
                                            </asp:GridView>

                                            
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: normal; font-size: 12px; width: 100%; font-family: Arial;
                                            background-color: #fff8dc; text-align: center">
                                      <table class="table table-responsive-sm" style="width: 100%; background-color: #fff8dc;">
                                          <tr>
                                              <td colspan="2" style="width: 100%; text-align: center; font-weight: bold; color: maroon; background-color: burlywood;">
                                                  Please Enter Following
                                                  <asp:Label ID="maxidw" runat="server"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td style="width: 50%; text-align: center;">
                                                  DDO Name</td>
                                              <td style="width: 50%; text-align: left;">
                                                  <asp:DropDownList ID="DDONAME" runat="server" Width="40%" AutoPostBack="True" OnSelectedIndexChanged="DDONAME_SelectedIndexChanged">
                                                  </asp:DropDownList></td>
                                          </tr>
                                          <tr>
                                              <td style="width: 430px; text-align: center;">
                                                  Hospital Supervisor Name</td>
                                              <td style="width: 430px; text-align: left;">
                                                  <asp:TextBox ID="DAT" runat="server" MaxLength="200"></asp:TextBox>
                                                  <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td style="width: 430px; height: 26px;">
                                                  <asp:Label ID="Label1" runat="server"></asp:Label>
                                                  <asp:TextBox ID="DNT" runat="server" MaxLength="75" Visible="False"></asp:TextBox></td>
                                              <td style="width: 430px; height: 26px;">
                                                  <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" /></td>
                                          </tr>
                                      </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="color: #661700; height: 5%; background-color: #661700">
                                <asp:Label ID="mess" runat="server" Font-Bold="True" ForeColor="White" Visible="False"></asp:Label>.</td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
        </div>
</asp:Content>
