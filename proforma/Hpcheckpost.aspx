<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Hpcheckpost.aspx.cs" Inherits="NewWebApp.proforma.Hpcheckpost" %>
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
                                        <asp:LinkButton ID="LinkButton1" class="btn btn-danger" runat="server" 
                                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton>
                        </td>
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
                <td colspan="4" style="color: #ffffc0; font-size: 16px; background-color: #661700; text-align: left;">
                    &nbsp; Medical Section /
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
                                    &nbsp;</td>
                                <td style="font-size: 12px; width: 16%;; color: maroon;  background-color: burlywood">
                                    &nbsp;</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                    Post
                                    Name</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                    Speciality</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                    No. of Sanctioned
                                    Post</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                    &nbsp;</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: burlywood">
                                </td>
                            </tr>                            
                            
                            
                            
                            
                            
                            <tr>
                                <td colspan="7" style="font-size: 12px; color: #fff8dc; background-color: #fff8dc">
                                    .</td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; width: 18%; color: maroon; background-color: #fff8dc">
                                    &nbsp;</td>
                                <td style="font-size: 12px; width: 16%;; color: maroon;  background-color: #fff8dc">
                                    &nbsp;</td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                        <asp:DropDownList ID="DPost" runat="server" Width="100%">
                        </asp:DropDownList></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                    <asp:DropDownList ID="DCadre" runat="server" 
                        Width="80%">
                    </asp:DropDownList></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                    <asp:TextBox ID="TSP" runat="server" Width="80%"></asp:TextBox></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" /></td>
                                <td style="font-size: 12px; width: 16%; color: maroon;  background-color: #fff8dc">
                                    &nbsp;</td>
                            </tr>        
                        </table>
                    </div>
                    <asp:Label ID="Label1" runat="server" Width="328px" ForeColor="Maroon"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="font-size: 12px;width: 100%;">
                    &nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        DataSourceID="SqlDataSource1" DataKeyNames="sno" Width="100%" 
                        EnableModelValidation="True" BackColor="#DEBA84" BorderColor="#DEBA84" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <Columns>
                               <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                            <asp:BoundField DataField="newpostname" HeaderText="Post Name" 
                                SortExpression="newpostname"  />

                         
                    
                         
                      
                            <asp:BoundField DataField="spname" HeaderText="Speciality" 
                                SortExpression="spname" />
                       
                            <asp:BoundField DataField="posts" HeaderText="No. of Sanctioned Post" SortExpression="posts" />
                           <%-- <asp:BoundField DataField="speciality" HeaderText="speciality" 
                                SortExpression="speciality" />--%>
                        <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS%>"
                        
                        SelectCommand="SELECT TOP (100) PERCENT hospitalrecord.sno, post.newpostname, specialization.spname, hospitalrecord.posts, hospitalrecord.speciality FROM hospitalrecord INNER JOIN post ON hospitalrecord.postid = post.newpostid INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno INNER JOIN specialization ON hospitalrecord.speciality = specialization.spid WHERE (hospitalrecord.hnameid = @hnameid) ORDER BY post.newpostname" 
                        DeleteCommand="Delete from hospitalrecord where sno=@sno" 
                        
                        UpdateCommand="update hospitalrecord set posts=@posts,withcadre=@withcadre,withoutcadre=@withoutcadre,Extrapost=@Extrapost,modifieruserid=@userid,lastupdatedtime=@ltime,hostipaddress=@hipadd where sno=@sno">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="hnameid" QueryStringField="sno" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="GridView1" Name="sno" PropertyName="SelectedValue" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="GridView1" Name="posts" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="GridView1" Name="withcadre" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="GridView1" Name="withoutcadre" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="GridView1" Name="extrapost" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="muid" Name="userid" PropertyName="Text" />
                            <asp:ControlParameter ControlID="ltime" Name="ltime" PropertyName="Text" />
                            <asp:ControlParameter ControlID="hipadd" Name="hipadd" PropertyName="Text" />
                            <asp:ControlParameter ControlID="GridView1" Name="sno" PropertyName="SelectedValue" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
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
                        &nbsp;
    </td>
                </tr>
            </table>
        </div>
        </div>

</asp:Content>
