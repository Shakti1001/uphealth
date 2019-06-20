<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="SalaryMPRreport.aspx.cs" Inherits="NewWebApp.payrole.SalaryMPRreport" %>
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
                <strong>DDO Id::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlddo" runat="server" Height="28px" Width="223px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlddo">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong>Month::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlmonth" runat="server" Height="28px" Width="223px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlmonth">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong>Year::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlyear" runat="server" Height="28px" Width="223px">
                    <asp:ListItem>Select</asp:ListItem>
                    <%--<asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>--%>
                    <asp:ListItem>2016</asp:ListItem>
                     <asp:ListItem>2017</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlyear">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                <strong>
                <asp:Button ID="Button1" runat="server" Height="34px" onclick="Button1_Click" 
                    style="font-weight: bold" Text="Submit" Width="154px" />
                </strong>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 24px">
                </td>
            <td align="left" style="height: 24px">
                <asp:Label ID="lblmess" runat="server" Font-Bold="True" style="color: #FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" 
                    
                    SelectCommand="SELECT t1.Smonth, t1.salaryrecord, t2.mprrecord, t2.i1, Ucreate.username FROM (SELECT ddoid, Smonth, COUNT(idno) AS salaryrecord FROM calulatedsalary WHERE (Smonth = '11') GROUP BY ddoid, Smonth) AS t1 INNER JOIN Ucreate ON t1.ddoid = Ucreate.iduser LEFT OUTER JOIN (SELECT ddoid AS i1, COUNT(DISTINCT ISNULL(compid, '0')) AS mprrecord FROM mpr GROUP BY ddoid) AS t2 ON t1.ddoid = t2.i1">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                <Columns>
                 <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="smonth" HeaderText="Month" />
                <asp:BoundField DataField="username" HeaderText="Username" />
                    <asp:BoundField DataField="salaryrecord" HeaderText="Salary Record" />
                        <asp:BoundField DataField="mprrecord" HeaderText="MPR Record" />
                          <%--  <asp:BoundField DataField="i1" HeaderText="Id" />--%>

                </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
