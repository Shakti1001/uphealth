<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/Site1.Master" AutoEventWireup="true" CodeBehind="P2Search.aspx.cs" Inherits="NewWebApp.Guest.P2Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width:100%; table-layout:fixed;">
        <tr>
            
                                            <td align="center" bgcolor="#376fbc" 
              colspan="4" height="30" style="background-color: #fff8dc">
                <asp:LinkButton ID="LinkButton1" class="btn btn-danger" runat="server" style="float:right;" OnClick="Back_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
                                                <table class="table table-responsive-sm" style="width:100%; table-layout:fixed;" >
                                                    <tr>
                                                        <td style="width: 100%; background-color: #e8cd76;">
                        <table class="table table-responsive-sm" border="0" cellpadding="1" cellspacing="1" style="width: 100%; table-layout:fixed; height: 100%; font-weight: bold; color: maroon;">
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
                                <td align="left" style="width: 25%; height: 25px; ">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; ">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; ">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; ">
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
                                <td align="left" style="width: 25%; height: 24px">
                                </td>
                                <td align="left" style="width: 25%; height: 24px">
                                    Name <span style="font-size: small; color: red">&nbsp; (Type atleast one letter 
                                    )</span></td>
                                <td align="left" style="width: 25%; height: 24px">
                <asp:TextBox ID="name" runat="server" Width="90%"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 25%; height: 24px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    DOB <span style="font-size: small; color: #FF3300; font-weight: normal"><strong>&nbsp;
                                    (Format-dd/mm/yyyy)</strong></span></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    <asp:TextBox ID="dob" runat="server" Width="90%"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px">
                                </td>
                                <td align="left" style="width: 25%; height: 25px">
                                    Cadre</td>
                                <td align="left" style="width: 25%; height: 25px">
                    <asp:DropDownList ID="cadre" runat="server" Width="90%" AutoPostBack="True">
                    </asp:DropDownList></td>
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
                        Width="90%">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; ">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; ">
                                    Post</td>
                                <td align="left" style="width: 25%; height: 25px; ">
                    <asp:DropDownList ID="post" runat="server" AutoPostBack="True"
                        Width="90%">
                    </asp:DropDownList></td>
                                <td align="left" style="width: 25%; height: 25px; ">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    &nbsp;</td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100%; color: black; height: 25px; text-align: center;" colspan="4">
                                    Note:
                                    <asp:Label ID="input" runat="server" Font-Size="Small" ForeColor="#0000C0">Select One or More  Choice Then Submit</asp:Label>&nbsp;
                                    <strong>
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" 
                                        style="font-weight: bold" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
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
           
        </tr>
        <tr>
            
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
    <asp:HyperLink ID="idlink" Target="_blank" Text='<%#Eval("idno") %>' NavigateUrl='<%#"P2.aspx?idno="+Eval("idno") %>' runat="server"></asp:HyperLink>
    
    </ItemTemplate>
    </asp:TemplateField>
      <asp:BoundField DataField="name" HeaderText="Name" />
        <asp:BoundField DataField="fathername" HeaderText="Father Name" />
          <asp:BoundField DataField="dob" HeaderText="Date Of Birth" />
                <asp:BoundField DataField="districtname" HeaderText="Home District" />
                <asp:BoundField DataField="designame" HeaderText="Post" />

                    <asp:BoundField DataField="senno" HeaderText="Cadre" />
                    <%--  <asp:BoundField DataField="designame" HeaderText="Post" />--%>
                        <asp:BoundField DataField="hname" HeaderText="Hospital Name" />
                  

                
                </Columns>

                </asp:GridView>
            </td>
            
        </tr>
    </table>
  </div>
</asp:Content>
