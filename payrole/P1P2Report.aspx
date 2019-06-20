<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="P1P2Report.aspx.cs" Inherits="NewWebApp.payrole.P1P2Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <strong>District Name::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddldistrict" runat="server" Height="30px" Width="211px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                <%--<asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="138px">
                </asp:DropDownList>--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <strong><%--Hospital Name::</strong>--%></td>
            <td align="left">
                <%--<asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="138px" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>--%>
                <strong>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    style="font-weight: bold" Text="Submit" Width="120px" />
                </strong>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                <strong>
                <%--<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    style="font-weight: bold" Text="Submit" Width="115px" />--%>
                </strong>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="districtname" HeaderText="District Name" />
               <asp:BoundField DataField="hname" HeaderText="Hospital Name" />
                <asp:BoundField DataField="Sanctioned_post" HeaderText="Sanctioned Post" />
                 <asp:BoundField DataField="Filled_post" HeaderText="Filled Post" />
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
