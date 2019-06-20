<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/Site1.Master" AutoEventWireup="true" CodeBehind="progressreport.aspx.cs" Inherits="NewWebApp.Guest.progressreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm" style="width: 100%">
        <tr>
            <td colspan="2" style="width: 100%; height: 0px; text-align: right" valign="top">
                <asp:LinkButton ID="LinkButton1" class="btn btn-danger" OnClick="Back_Click" runat="server"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
            </td>
        </tr>
    </table>

    <table class="table table-responsive-sm" style="width: 100%">
        <tr>
            <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                        background-color: #661700; text-align: left;" width="55%">
                                        &nbsp; Medical Section / MPR / Report &nbsp;
            </td>
        </tr>
    </table>
    <table class="table table-responsive-sm" width="100%">
    <tr><td align="right">
        <asp:Label ID="lblddo" runat="server" Visible="false" Font-Bold="true"></asp:Label>
        </td><td align="left">
            <asp:DropDownList ID="ddlddo" runat="server" Visible="false" OnSelectedIndexChanged="ddlddo_indexchanged" AutoPostBack="true">
            </asp:DropDownList>
    </td></tr>
    
    <tr><td align="right">
        <asp:Label ID="lblhname" runat="server" Visible="false" 
            style="font-weight: 700"></asp:Label>
        </td><td align="left">
            <asp:DropDownList ID="ddlhname" runat="server" Visible="false" 
                onselectedindexchanged="ddlhname_SelectedIndexChanged">
            </asp:DropDownList>
    </td></tr>
    
    <tr><td align="right">
        <strong>Month ::</strong></td><td align="left">
        <asp:DropDownList ID="ddlmonth" runat="server">
        </asp:DropDownList>
    </td></tr>
    
    <tr><td align="right"><strong>Year ::</strong></td>
        <td align="left">
            <asp:DropDownList ID="ddlyear" runat="server">
            <%--<asp:ListItem Text="2014" Value="2"></asp:ListItem>--%>
                <asp:ListItem>Select </asp:ListItem>
                
            <asp:ListItem>2015</asp:ListItem>
          <asp:ListItem>2016</asp:ListItem>      <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    
    <tr><td align="right">&nbsp;</td>
        <td align="left">
            <asp:Button ID="btnsubmit" runat="server" onclick="btnsubmit_Click" 
                style="font-weight: 700" Text="Submit" Height="26px" Width="103px" />
        </td>
    </tr>
    
    <tr><td align="right">&nbsp;</td>
        <td align="left">
            <strong>
            <asp:Label ID="lblmess" runat="server" style="color: #FF3300"></asp:Label>
            </strong>
        </td>
    </tr>
    
    
    </table>


    <table class="table table-responsive-sm" width="100%">
    <tr><td align="left" colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Select Computer Id of Doctor to view his MPR" Visible="false"  ></asp:Label>
        </td>
    </tr>
    <tr><td>
        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false">
        <Columns>

        <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField HeaderText="Hospital Name" DataField="hname" />

        <asp:TemplateField HeaderText="Computer Id">
        <ItemTemplate>
        <asp:HyperLink ID="cid" Target="_blank" Text='<%#Eval("compid") %>' NavigateUrl='<%#"dailyrep.aspx?compid=" +Eval("compid")+ "&month=" +Eval("month") + "&year=" +Eval("year") %>' runat="server"></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Name" DataField="name" />
        <asp:BoundField HeaderText="Post" DataField="post" />
        <%--<asp:BoundField HeaderText="Duty" DataField="dutyname" />--%>
        <asp:BoundField HeaderText="OPD cases" DataField="opd" />
        <asp:BoundField HeaderText="OT cases" DataField="ot" />
          <asp:BoundField HeaderText="Normal Delivery" DataField="ndelivery" />
        <asp:BoundField HeaderText="Ceserian Delivery" DataField="cdelivery" />
         <asp:BoundField HeaderText="Emergency (in days)" DataField="emergency" />
             <asp:BoundField HeaderText="Medico Legal(in days)" DataField="medicolegal" />
        <asp:BoundField HeaderText="Postmortem Duty (in days)" DataField="postmortem" />

        <asp:BoundField HeaderText="VIP Duty (in days)" DataField="vip" />
        <asp:BoundField HeaderText="Jail Duty (in days)" DataField="jail" />
       
        <asp:BoundField HeaderText="Mela Duty (in days)" DataField="mela" />
        <asp:BoundField HeaderText="Court Duty (in days)" DataField="court" />
       <asp:BoundField HeaderText="Tour (in days)" DataField="TourStudy" />
       <asp:BoundField HeaderText="Leave/Off(in days)" DataField="leaveOff" />
    
      
      
   <%--     <asp:BoundField HeaderText="Gazetted Holiday (in days)" DataField="gh" />--%>
        <%--<asp:BoundField DataField="month" />--%>

        <%--<asp:BoundField HeaderText="Cases Attended" DataField="cases" />--%>
        
        
        </Columns>
        </asp:GridView>
    </td></tr></table>

    <table class="table table-responsive-sm" style="width: 100%">
        <tr bgcolor="#fe8631">
            <td bgcolor="#fe8631" height="30" style="background-color: #661700">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
