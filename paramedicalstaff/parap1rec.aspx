<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="parap1rec.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap1rec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right" valign="top">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td style="width: 50%; text-align: left">
                                        &nbsp;<asp:Label ID="Fnamet" runat="server" ForeColor="#661700" Visible="False"></asp:Label>
                    <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                                    <td style="width: 50%; text-align: right">
                                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
   
    <div style="text-align: center">
        <table class="table table-responsive-sm" style="width: 100%;  font-weight: bold; color: #0066cc; font-family: Arial;" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4" style="color: #ffffc0; font-size: 16px; background-color: #661700;">
                    Paramedical Staff
                    Proforma-1(P1) &nbsp;<asp:Label ID="muid" runat="server"
                        ForeColor="#2C2713"></asp:Label>
                    <asp:Label ID="ltime" runat="server" ForeColor="#2C2713"></asp:Label>
                    <asp:Label ID="hipadd" runat="server" ForeColor="#2C2713"></asp:Label>
                    <asp:TextBox ID="maxid" runat="server" Width="24px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="font-size: 16px;
                    color: #fff8dc; background-color: #fff8dc;">
                    .</td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left; font-size: 14px; color: maroon; background-color: #fff8dc;">
                    &nbsp;
                    Division</td>
                <td style="width: 25%; text-align: left; font-size: 14px; color: maroon; background-color: #fff8dc;">
                    <asp:DropDownList ID="DDiv" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDiv_SelectedIndexChanged"
                        Width="100%" Font-Bold="True" Font-Size="Small" ForeColor="#C00000">
                    </asp:DropDownList></td>
                <td style="width: 25%; text-align: left; font-size: 14px; color: maroon; background-color: #fff8dc;">
                    &nbsp;
                    District</td>
                <td style="width: 25%; text-align: left; font-size: 14px; color: maroon; background-color: #fff8dc;">
                    <asp:DropDownList ID="DDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged"
                        Width="100%" Font-Bold="True" Font-Size="Small" ForeColor="#C00000">
                    </asp:DropDownList></td>
            </tr>
            <%--<tr>
                <td style="width: 25%; text-align: left; font-size: 14px;">
                    Tehsil</td>
                <td style="width: 25%; text-align: left; font-size: 14px;">
                    <asp:DropDownList ID="DTEH" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DTEH_SelectedIndexChanged"
                        Width="200px">
                    </asp:DropDownList></td>
                <td style="width: 25%; text-align: left; font-size: 14px;">
                    Block</td>
                <td style="width: 25%; text-align: left; font-size: 14px;">
                    <asp:DropDownList ID="DBLK" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DBLK_SelectedIndexChanged"
                        Width="200px">
                    </asp:DropDownList></td>
            </tr>--%>
            <tr>
                <td colspan="4" style="font-size: 14px; color: #fff8dc; background-color: #fff8dc;
                    text-align: left">
                    .</td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left; font-size: 14px; color: maroon; background-color: #fff8dc;">
                    &nbsp;
                    Hospital Category</td>
                <td style="width: 25%; text-align: left; font-size: 14px; color: maroon; background-color: #fff8dc;">
                    <asp:DropDownList ID="DHT" runat="server" Width="100%" OnSelectedIndexChanged="DHT_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True" Font-Size="Small" ForeColor="#C00000">
                    </asp:DropDownList></td>
                <td style="width: 25%; text-align: left; font-size: 14px; color: maroon; background-color: #fff8dc;">
                    &nbsp;
                    Hospital Name</td>
                <td style="width: 25%; text-align: left; font-size: 14px; color: maroon; background-color: #fff8dc;">
                    <asp:DropDownList ID="DHNAME" runat="server" Width="100%" Font-Bold="True" Font-Size="Small" ForeColor="#C00000">
                    </asp:DropDownList></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <table class="table table-responsive-sm" style="width: 100%; height: 48px; font-weight: bold; color: #0066cc; font-family: Arial;" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4" style="font-weight: bold; font-size: 14px; width: 100%; color: #660000;
                    background-color: #ffeecc">
                    <div style="text-align: center">
                        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                            <tr>
                                <td colspan="7" style="font-size: 12px; color: #fff8dc; height: 15px; background-color: #fff8dc">
                                    .</td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; width: 16%; color: maroon; background-color: burlywood">
                                    Post
                                    Name</td>
                                <td style="font-size: 12px; width: 16%;; color: maroon;  background-color: burlywood">
                                    Cadre</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                    No. of Sanctioned
                                    Post</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                    Filled Post 
                                    <br />
                                    as &nbsp;Per Cadre
                                </td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                    Filled Post
                                    <br />
                                    Without Cadre</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                    Extra Filled</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                </td>
                            </tr>                            
                            
                            
                            
                            
                            
                            <tr>
                                <td colspan="7" style="font-size: 12px; color: #fff8dc; background-color: #fff8dc">
                                    .</td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; width: 18%; color: maroon; background-color: #fff8dc">
                        <asp:DropDownList ID="DPost" runat="server" Width="100%">
                        </asp:DropDownList></td>
                                <td style="font-size: 12px; width: 16%;; color: maroon;  background-color: #fff8dc">
                    <asp:DropDownList ID="DCadre" runat="server" 
                        Width="80%">
                    </asp:DropDownList></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                    <asp:TextBox ID="TSP" runat="server" Width="80%"></asp:TextBox></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                    <asp:TextBox ID="APCRText" runat="server" Width="80%"></asp:TextBox></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                                    <asp:TextBox ID="WCRText" runat="server" Width="80%"></asp:TextBox></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                                    <asp:TextBox ID="TAtt" runat="server" Width="80%"></asp:TextBox></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                    <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" /></td>
                            </tr>        
                        </table>
                    </div>
                    <asp:Label ID="Label1" runat="server" Width="328px" ForeColor="Maroon"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="font-size: 12px;width: 100%;">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="sno" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Width="100%">
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="designame" HeaderText="Post Name" />
                            <asp:BoundField DataField="posts" HeaderText="Total Sanctioned Post" />
                            <asp:BoundField DataField="withcadre" HeaderText="Filled As Per Cadre Review" />
                            <asp:BoundField DataField="withoutcadre" HeaderText="Filled Without cadre Review" />
                            <asp:BoundField DataField="Extrapost" HeaderText="Filled  Extra" />
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" DeleteCommand="Delete from PMDhospitalrecord where sno=@sno" SelectCommand="SELECT     PMDhospitalrecord.sno, PMDhospitalrecord.hnameid, PMDhospitaldesignation.designame, PMDhospitalrecord.posts, PMDhospitalrecord.withcadre, PMDhospitalrecord.withoutcadre,PMDhospitalrecord.Extrapost FROM         PMDhospitaldesignation INNER JOIN   PMDhospitalrecord ON PMDhospitaldesignation.desigid = PMDhospitalrecord.desigid where hnameid=@hnameid Order by designame" UpdateCommand="update PMDhospitalrecord set posts=@posts,withcadre=@withcadre,withoutcadre=@withoutcadre,Extrapost=@Extrapost,modifieruserid=@userid,lastupdatedtime=@ltime,hostipaddress=@hipadd where sno=@sno">
                                                                                                                                                                                                                     
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="GridView2" Name="sno" PropertyName="SelectedValue" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="GridView2" Name="posts" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="GridView2" Name="withcadre" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="GridView2" Name="withoutcadre" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="GridView2" Name="extrapost" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="muid" Name="userid" PropertyName="Text" />
                            <asp:ControlParameter ControlID="ltime" Name="ltime" PropertyName="Text" />
                            <asp:ControlParameter ControlID="hipadd" Name="hipadd" PropertyName="Text" />
                            <asp:ControlParameter ControlID="GridView2" Name="sno" PropertyName="SelectedValue" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="hnameid" QueryStringField="sno" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="width: 100%;background-image: url(../images/tab.jpg); color: #003366;
                    text-align: center">
                    <asp:DropDownList ID="DDesign" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDesign_SelectedIndexChanged"
                        Width="136px" Visible="False">
                    </asp:DropDownList></td>
            </tr>
        </table>
    </div>
    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
