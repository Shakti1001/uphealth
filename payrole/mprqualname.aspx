<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="mprqualname.aspx.cs" Inherits="NewWebApp.payrole.mprqualname" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <strong>DDO Name::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlddo" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong>Month::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlmonth" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong>Year::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlyear" runat="server" Height="16px" Width="77px">
                    <asp:ListItem>2013</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong></strong>
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                <asp:Button ID="Button1" runat="server" Font-Bold="True" Height="29px" 
                    onclick="Button1_Click" Text="Submit" Width="111px" />
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                <asp:Label ID="lblmess" runat="server" Font-Bold="True" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" 
                    
                    
                    SelectCommand="SELECT  mprfinal1.name + ' , ' + spqual.spqual AS NAME, mprfinal1.month, mprfinal1.year, mprfinal1.post, mprfinal1.hname, mprfinal1.poposting, mprfinal1.opd, mprfinal1.ot, mprfinal1.Postmortem, mprfinal1.vip, mprfinal1.jail, mprfinal1.emergency, mprfinal1.mela, mprfinal1.cl, mprfinal1.court, mprfinal1.el, mprfinal1.Medical, mprfinal1.tour, mprfinal1.gh, mprfinal1.adminwork, mprfinal1.compleave, mprfinal1.compid, mprfinal1.ddoid FROM mprfinal1 INNER JOIN spqual ON mprfinal1.compid = spqual.idno ORDER BY mprfinal1.name">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false">
        <Columns>

        <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
       

<%--        <asp:TemplateField HeaderText="Computer Id">
        <ItemTemplate>
        <asp:HyperLink ID="cid" Target="_blank" Text='<%#Eval("compid") %>' NavigateUrl='<%#"dailyrep.aspx?compid=" +Eval("compid")+ "&month=" +Eval("month") %>' runat="server"></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>--%>
       
        <asp:BoundField HeaderText="Name" DataField="name" />
      <%--   <asp:BoundField HeaderText="Qualification" DataField="spqual" />--%>
          <asp:BoundField HeaderText="Hospital Name" DataField="hname" />
        <asp:BoundField HeaderText="Post" DataField="post" />
        <%--<asp:BoundField HeaderText="Duty" DataField="dutyname" />--%>
        <asp:BoundField HeaderText="OPD cases" DataField="opd" />
        <asp:BoundField HeaderText="OT cases" DataField="ot" />
        <asp:BoundField HeaderText="Postmortem Duty (in days)" DataField="postmortem" />
        <asp:BoundField HeaderText="VIP Duty (in days)" DataField="vip" />
        <asp:BoundField HeaderText="Jail Duty (in days)" DataField="jail" />
        <asp:BoundField HeaderText="Emergency (in days)" DataField="emergency" />
        <asp:BoundField HeaderText="Mela Duty (in days)" DataField="mela" />
        <asp:BoundField HeaderText="Court Duty (in days)" DataField="court" />
        <asp:BoundField HeaderText="Casual Leave (in days)" DataField="cl" />
        <asp:BoundField HeaderText="Earned Leave (in days)" DataField="el" />
        <asp:BoundField HeaderText="Medical Leave (in days)" DataField="medical" />
        <asp:BoundField HeaderText="Tour (in days)" DataField="tour" />
        <asp:BoundField HeaderText="Gazetted Holiday (in days)" DataField="gh" />
        <asp:BoundField HeaderText="Admin Work" DataField="adminwork" />
        <asp:BoundField HeaderText="Compansative Leave" DataField="compleave" />
        <%--<asp:BoundField DataField="month" />--%>

        <%--<asp:BoundField HeaderText="Cases Attended" DataField="cases" />--%>
        
        
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
