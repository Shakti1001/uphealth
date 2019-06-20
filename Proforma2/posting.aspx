<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="posting.aspx.cs" Inherits="NewWebApp.Proforma2.posting" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/disableprint.js" type="text/javascript" language="javascript">
</script>
    <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton ID="LinkButton1" class="btn btn-danger" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
               
                </tr>
                <tr>
                    <td style="font-weight: bold; width: 100%; color: #ffff99; height: 25px; background-color: #661700;
                        text-align: left" valign="top">
                        <span style="font-size: 12pt; color: #ffff99; background-color: #661700">Medical Section
                            / P2 / Posting Details</span></td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 457px; font-size: 12px;" valign="top">
    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #661700;
            font-family: Arial; height: 1px; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 50%; height: 17px; text-align: center; color: #661700; background-color: burlywood;">
                    <span style="color: #661700">Seniority Number:</span>
                    <asp:Label ID="sen" runat="server" ForeColor="#C00000" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                <td style="width:50%; height: 17px; text-align: center; color: #661700; background-color: burlywood;">
                    Name :<asp:Label ID="name" runat="server"
                        ForeColor="#C00000" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                    <asp:Label
                        ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
            </tr>
        <tr>
            <td colspan="2" style="width: 100%; color: maroon; text-align: center">
                <div style="text-align: center">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    Posting
                    District<br />
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="(In case of other state Select none)"></asp:Label></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    <asp:DropDownList ID="DDistrict" class="form-control" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Other State District Name"
                                    Visible="False"></asp:Label><br />
                    <asp:TextBox ID="OtherDist" runat="server" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; height: 25px;">
                    Place</td>
                            <td align="left" style="width: 25%; height: 25px;">
                    <asp:DropDownList ID="Dplace" class="form-control" runat="server" Width="200px" OnSelectedIndexChanged="Dplace_SelectedIndexChanged">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; height: 25px;">
                                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Place" Visible="False"></asp:Label>
                                <br />
                    <asp:TextBox ID="OtherPost" runat="server" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    Post</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    <asp:DropDownList ID="DPOST" class="form-control" runat="server" Width="200px">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    </td>
                        </tr>

                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    Lavel</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    <asp:DropDownList ID="lvl" class="form-control" runat="server" Width="200px">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; height: 25px;">
                    Designation</td>
                            <td align="left" style="width: 25%; height: 25px;">
                    <asp:DropDownList ID="DDesign" class="form-control" runat="server" Width="200px">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; height: 25px;">
                    </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                Date of Joining 
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                <asp:DropDownList ID="DDD" class="form-control" runat="server">
                </asp:DropDownList><asp:DropDownList class="form-control" ID="DMM" runat="server">
                </asp:DropDownList><asp:DropDownList class="form-control" ID="DYYYY" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DYYYY_SelectedIndexChanged">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 25px">
                            </td>
                            <td align="left" style="width: 25%; height: 25px">
                    Date Of Relieving</td>
                            <td align="left" style="width: 25%; height: 25px">
            <asp:DropDownList ID="DD1" class="form-control" runat="server">
                </asp:DropDownList><asp:DropDownList class="form-control" ID="DM1" runat="server">
                </asp:DropDownList><asp:DropDownList class="form-control" ID="DY1" runat="server">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; height: 25px">
        <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label></td>
                        </tr>

                         <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    Order No.</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                                <asp:TextBox ID="ordno" runat="server" class="form-control"></asp:TextBox>  </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    </td>
                        </tr>

                         <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    Order Date</td>
                   
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                                 <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajx:ToolkitScriptManager>
<asp:TextBox ID="orddat" placeholder="dd/mm/yyyy" class="form-control" runat="server" CssClass="disable_past_dates"  required></asp:TextBox>

                                <ajx:CalendarExtender ID="Calendar1" PopupButtonID="Imagecal" runat="server" TargetControlID="orddat"
    Format="dd/MM/yyyy">
</ajx:CalendarExtender> </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            <asp:Image ID="Imagecal" runat="server" ImageUrl="~/Proforma2/calender/cal_img/cal.gif" /> 
                    </td>
                        </tr>

                         <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    Update Reason</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    <asp:DropDownList ID="updreason" class="form-control" runat="server" Width="200px">
                    </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc; height: 25px;">
                    </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="width: 25%; height: 25px; background-color: #fff8dc;
                                text-align: center">
                                <asp:Label ID="Label4" runat="server" ForeColor="#0000C0" Text="Please enter at least   current posting record  if person is joined"></asp:Label></td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right">
                    <asp:Button ID="BSAVE" class="btn btn-success" runat="server" Text="Save" OnClick="BSAVE_Click" Width="80px" /></td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right">
                <asp:Button
                        ID="Enq" runat="server" Text="Enquiry Detail" OnClick="Enq_Click" Width="80px" Font-Size="X-Small" Visible="False" />
                    <asp:Button ID="PFsheet" class="btn btn-default" runat="server" OnClick="PFsheet_Click" Text="Print FactSheet" Width="112px" /></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; height: 25px; text-align: center">
                                &nbsp;&nbsp;
                                <asp:Label ID="Msg" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; background-color: #fff8dc; text-align: center">
                                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
                                </asp:Table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 12px; width: 100%; text-align: left; font-weight: normal; color: #ffffff;">
                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="SqlDataSource5" DataKeyNames="sno" CellPadding="4" ForeColor="#333333" GridLines="None" Height="50%" Width="100%">
            <Columns>
                <asp:BoundField DataField="designame" HeaderText="Designation" />
                <asp:BoundField DataField="newpostname" HeaderText="Post" SortExpression="newpostname" />
                <asp:BoundField DataField="districtname" HeaderText="District" SortExpression="districtname" />
                <asp:BoundField DataField="hname" HeaderText="Hospital" SortExpression="hname" />
                <asp:BoundField DataField="doposting" HeaderText="Posting Date" ReadOnly="True" SortExpression="doposting" />
                <asp:BoundField DataField="dorelieve" HeaderText="Relieve Date" ReadOnly="True" SortExpression="dorelieve" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#661700" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
             SelectCommand="SELECT postingdetails.sno, designation.designame, post.newpostname, hospitaldistrict.districtname, hospitalname.hname, CONVERT (char, postingdetails.doposting, 106) AS doposting, CONVERT (char, postingdetails.dorelieve, 106) AS dorelieve, postingdetails.doposting AS pd, postingdetails.dorelieve AS pr FROM postingdetails INNER JOIN hospitaldistrict ON postingdetails.districtid = hospitaldistrict.districtid INNER JOIN designation ON postingdetails.Desigid = designation.Desigid INNER JOIN post ON postingdetails.postid = post.newpostid LEFT OUTER JOIN hospitalname ON postingdetails.poposting = hospitalname.sno WHERE (postingdetails.idno = @idno) ORDER BY postingdetails.doposting" DeleteCommand="DELETE FROM postingdetails WHERE (sno = @sno)">
            <DeleteParameters>               
                <asp:ControlParameter ControlID="GridView1" Name="sno" PropertyName="SelectedValue" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
            </SelectParameters>
           
        </asp:SqlDataSource>--%>
        
        
        
                               <%-- <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="sno"
                                    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="100%">
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="sno" HeaderText="sno" SortExpression="sno" />
                                        <asp:BoundField DataField="designame" HeaderText="designame" SortExpression="designame" />
                                        <asp:BoundField DataField="newpostname" HeaderText="newpostname" SortExpression="newpostname" />
                                        <asp:BoundField DataField="hname" HeaderText="hname" SortExpression="hname" />
                                        <asp:BoundField DataField="poposting" HeaderText="poposting" SortExpression="poposting" />
                                        <asp:BoundField DataField="districtname" HeaderText="districtname" SortExpression="districtname" />
                                        <asp:BoundField DataField="doposting" HeaderText="doposting" ReadOnly="True" SortExpression="doposting" />
                                        <asp:BoundField DataField="dorelieve" HeaderText="dorelieve" ReadOnly="True" SortExpression="dorelieve" />
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:CommandField ShowDeleteButton="True" />
                                    </Columns>
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#661700" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpcon %>" DeleteCommand="DELETE FROM postingdetails WHERE (sno = @sno)" SelectCommand="SELECT postingdetails.sno, designation.designame, post.newpostname, otherhospitalposting.hname, postingdetails.poposting, hospitaldistrict.districtname, CONVERT (varchar, postingdetails.doposting, 106) AS doposting, CONVERT (varchar, postingdetails.dorelieve, 106) AS dorelieve FROM personaldetails INNER JOIN postingdetails ON personaldetails.idno = postingdetails.idno INNER JOIN otherhospitalposting ON postingdetails.idno = otherhospitalposting.idno INNER JOIN designation ON postingdetails.Desigid = designation.Desigid INNER JOIN post ON postingdetails.postid = post.newpostid LEFT OUTER JOIN hospitaldistrict ON postingdetails.districtid = hospitaldistrict.districtid WHERE (postingdetails.idno = @idno) ORDER BY otherhospitalposting.hname">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                                    </SelectParameters>
                                    <DeleteParameters>
                                        <asp:ControlParameter ControlID="GridView3" Name="sno" PropertyName="SelectedValue" />
                                    </DeleteParameters>
                                </asp:SqlDataSource>--%>
        </td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; font-size: 12px; width: 100%; color: #661700;
                background-color: #661700; text-align: center">
                .</td>
        </tr>
        </table>
                        &nbsp; &nbsp;
        </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
