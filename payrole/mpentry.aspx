<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="mpentry.aspx.cs" Inherits="NewWebApp.payrole.mpentry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td colspan="2" style="width: 100%; height: 0px; text-align: right" valign="top">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
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

    <table classs="table table-responsive-sm" width="100%"><tr><td align="right"></td><td align="left">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td align="right"><strong>DDO Name ::</strong></td><td align="left">
        <asp:Label ID="lblddo" runat="server"></asp:Label>
        <asp:DropDownList ID="ddlddo" runat="server" OnSelectedIndexChanged="ddlddo_indexchanged" AutoPostBack="true">
        </asp:DropDownList>
        </td><td>&nbsp;</td></tr><tr><td align="right"><strong>Hosital Name ::</strong></td>
        <td align="left">
            <asp:DropDownList ID="ddlhname" runat="server" 
                onselectedindexchanged="ddlhname_SelectedIndexChanged">
            </asp:DropDownList>
        </td><td>&nbsp;</td></tr><tr><td align="right">&nbsp;</td><td align="left">
        <asp:Button ID="btnsubmit" runat="server" Text="Submit" 
            onclick="btnsubmit_Click" />
        <asp:Label ID="lblmess" runat="server" ForeColor="Red"></asp:Label>
        </td><td>&nbsp;</td></tr><tr><td align="right">&nbsp;</td><td align="left">&nbsp;</td><td>&nbsp;</td></tr></table>

        <table class="table table-responsive-sm" width="100%"><tr><td></td></tr><tr><td>
            <asp:GridView ID="GridView1" runat="server" Width="100%" 
                AutoGenerateColumns="false" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
            <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
            <asp:TemplateField HeaderText="Computer Id">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" HeaderText="Computer Id" Text='<%#Eval("idno") %>' NavigateUrl='<%#"mpentry1.aspx?idno="+Eval("idno")%>'></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
            
            <asp:BoundField HeaderText="Seniority No." DataField="senno" />
            <asp:BoundField HeaderText="Doctor's Name" DataField="name" />
            <%--<asp:BoundField HeaderText="Posted At" DataField="hname" />--%>
            <asp:BoundField HeaderText="Post" DataField="post" />
                        
            </Columns>
            </asp:GridView>
            </td></tr></table>
</div>
</asp:Content>
