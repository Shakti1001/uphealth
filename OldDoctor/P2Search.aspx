<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="P2Search.aspx.cs" Inherits="NewWebApp.OldDoctor.P2Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
                                            <td align="center" bgcolor="#376fbc" 
                colspan="3" height="30" style="background-color: #fff8dc">
                                                <table class=" table table-responsive-sm" style="border-top-width: thin; border-left-width: thin; border-left-color: #990000;
                                                    border-bottom-width: thin; border-bottom-color: #990000; width: 100%; color: #003366;
                                                    border-top-color: #990000; font-family: Georgia; border-right-width: thin; border-right-color: #990000">
                                                    <tr>
                                                        <td style="width: 100%; background-color: #e8cd76;">
                        <table class=" table table-responsive-sm"  border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; font-weight: bold; color: maroon;">
                            <tr>
                                <td align="left" style="background-color: #661700" height="30px">
                                    &nbsp;</td>
                                <td align="center" style="background-color: #661700; color: #ffff99;" 
                                    colspan="2" height="30px">
                                    Search P2</td>
                                <td align="left" style="background-color: #661700" height="30px">
                                                &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    Computer Id</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                <asp:TextBox ID="compid" runat="server" Width="90%"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                                <asp:Label
            ID="Divs" runat="server" Visible="False">%</asp:Label><asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                                    Name</td>
                                <td align="left" style="width: 25%; height: 25px">
                <asp:TextBox ID="name" runat="server" Width="90%"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    Home District</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    <asp:DropDownList ID="district" runat="server" AutoPostBack="True"
                        Width="90%" onselectedindexchanged="district_SelectedIndexChanged">
                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100%; color: black; height: 25px; text-align: center;" colspan="4">
                                    Note:
                                    <asp:Label ID="input" runat="server" Font-Size="Small" ForeColor="#0000C0">Select One or More  Choice Then Submit</asp:Label>&nbsp;
                                    <strong>
                    <asp:Button ID="Submit" class="btn btn-success" runat="server" Text="Submit" OnClick="Submit_Click" 
                                        style="font-weight: bold" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button class=" btn btn-default" ID="Button1" runat="server" onclick="Button1_Click1" 
                                        style="font-weight: bold" Text="Refresh" />
                                    </strong></td>
                            </tr>
                        </table>
                <asp:Label ID="strq" runat="server" Font-Size="Small" Visible="False" ForeColor="Red"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; background-color: #661700;" height="30px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    </table>
                                                &nbsp;&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="100%" 
                    AutoGenerateColumns="False">
                <Columns>
                <asp:TemplateField HeaderText="S.No">
                <ItemTemplate>
                
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>

                
                
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Computer ID">
    <ItemTemplate>
    <asp:HyperLink ID="idlink" Target="_blank" Text='<%#Eval("idno") %>' NavigateUrl='<%#"P2print.aspx?idno="+Eval("idno") %>' runat="server"></asp:HyperLink>
    
    </ItemTemplate>
    </asp:TemplateField>
      <asp:BoundField DataField="name" HeaderText="Name" />
        <asp:BoundField DataField="fathername" HeaderText="Father Name" />
          <asp:BoundField DataField="dob" HeaderText="Date Of Birth" />
                <asp:BoundField DataField="districtname" HeaderText="Home District" />
                

                    <asp:BoundField DataField="senno" HeaderText="Cadre" />
                    <%--  <asp:BoundField DataField="designame" HeaderText="Post" />
                        <asp:BoundField DataField="hname" HeaderText="Hospitl Name" />--%>
                  

                
                </Columns>

                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
