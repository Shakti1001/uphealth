<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Prof1.aspx.cs" Inherits="NewWebApp.Proforma2.Prof1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
            <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; font-family: Georgia; height: 100%; border-right: #666666 thin solid; border-top: #666666 thin solid; border-left: #666666 thin solid; color: #661700; border-bottom: #666666 thin solid;" id="TABLE1" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style="width:100%; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 10%; border-right-width: thin; border-right-color: #666666; color: #ffffc0; background-color: #661700; font-weight: bold;">
                        (Proforma-1 To Be Filled By Individuals Verified By CMO)</td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;width:100% ; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666; background-image: url(../images/tab.jpg); background-color: #ffffff;">
                        General Information &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        Seniority No:</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        <asp:TextBox ID="Gpfno" class="form-control" runat="server" Width="90%" OnTextChanged="Gpfno_TextChanged" MaxLength="50"></asp:TextBox></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        Name</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        <asp:TextBox ID="Name" class="form-control" runat="server" Width="90%" MaxLength="50" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Fathers/Husband Name&nbsp;</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:TextBox ID="fhname" class="form-control" runat="server" Width="90%"  MaxLength="50"></asp:TextBox></td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Sex</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList class="form-control" ID="Dsex" runat="server" Width="93%">
                            <asp:ListItem Value="0">Male</asp:ListItem>
                            <asp:ListItem Value="1">Female</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        Cadre</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        <asp:DropDownList ID="DCad" class="form-control" runat="server" Width="93%">
                        </asp:DropDownList></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        Cadre Seniority Number</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        <asp:TextBox ID="CSN" class="form-control" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Category&nbsp;
                    </td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList class="form-control" ID="Dcateg" runat="server" Width="93%">
                        </asp:DropDownList></td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Sub Category</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList class="form-control" ID="Dsubcat" runat="server" Width="93%">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666;">
                        Home District</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666;">
                        <asp:DropDownList class="form-control" ID="DhomeD" runat="server" Width="93%"  AutoPostBack="True" OnSelectedIndexChanged="DhomeD_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666;">
                        Previous Home District<br />
                        <asp:Label class="form-control" ID="Label6" runat="server" Font-Size="X-Small" ForeColor="Red" Text="(If  Home district Is changed)"
                            Width="232px" Font-Bold="True" Font-Names="Arial"></asp:Label></td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666;">
                        <asp:DropDownList class="form-control" ID="pDhomeD" runat="server" OnSelectedIndexChanged="pDhomeD_SelectedIndexChanged"
                            Width="93%">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 100%; border-top-color: #666666;
                        background-color: moccasin; text-align: left; border-right-width: thin; border-right-color: #666666">
                        <asp:Label ID="OtSL" class="form-control" runat="server" Font-Size="X-Small" ForeColor="Blue" Text="Please enter State then District"
                            Visible="False"></asp:Label>&nbsp;
                        <asp:TextBox ID="Otherstatetext" class="form-control" runat="server" Visible="False" Width="60%"></asp:TextBox>&nbsp;
                        <asp:Button ID="OTSTATESUBMIT" class="btn btn-success" runat="server" OnClick="OTSTATESUBMIT_Click" Text="Save"
                            Visible="False" /></td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Date Of Birth&nbsp;
                    </td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList ID="DB1" class="form-control" runat="server" Width="50%">
                        </asp:DropDownList><asp:DropDownList class="form-control" ID="DB2" runat="server" Width="50%">
                        </asp:DropDownList><asp:DropDownList class="form-control" ID="DB3" runat="server" Width="50%">
                        </asp:DropDownList><a
                                                    href="javascript:show_calendar('Content1.Dob');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;"></a></td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Date Of Appointment&nbsp;
                    </td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList class="form-control" ID="DA1" runat="server" Width="50%">
                        </asp:DropDownList><asp:DropDownList class="form-control" ID="DA2" runat="server" Width="50%">
                        </asp:DropDownList><asp:DropDownList class="form-control" ID="DA3" runat="server" Width="50%">
                        </asp:DropDownList><a
                                                    href="javascript:show_calendar('Content1.doa');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;"></a></td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666;">
                        Date Of Joining In Services&nbsp;
                    </td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666;">
                        <asp:DropDownList ID="DJ1" class="form-control" runat="server" Width="50%">
                        </asp:DropDownList><asp:DropDownList class="form-control" ID="DJ2" runat="server" Width="50%">
                        </asp:DropDownList><asp:DropDownList class="form-control" ID="DJ3" runat="server" Width="50%">
                        </asp:DropDownList><a
                                                    href="javascript:show_calendar('Content1.dojs');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;"></a></td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666;">
                        Date Of Confirmation&nbsp;
                    </td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666;">
                        <asp:DropDownList ID="DC1" class="form-control" runat="server" Width="50%">
                        </asp:DropDownList><asp:DropDownList class="form-control" ID="DC2" runat="server" Width="50%">
                        </asp:DropDownList><asp:DropDownList class="form-control" ID="DC3" runat="server" Width="50%">
                        </asp:DropDownList><a
                                                    href="javascript:show_calendar('Content1.doc');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;"></a></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 25px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Couple Id<asp:Label class="form-control" ID="Label3" runat="server" Font-Size="X-Small" Text="(In case of Govt. Service)"
                            Width="168px"></asp:Label><br />
                        <asp:Label ID="Label4" class="form-control" runat="server" Text="(Seniority No for Same dept./ 1 for others Dept.)" Font-Size="X-Small" ForeColor="Red" Width="272px" Font-Bold="True" Font-Names="Arial"></asp:Label></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 25px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                                        <asp:TextBox class="form-control" ID="Cgpf" runat="server" Width="90%" MaxLength="50"></asp:TextBox></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 25px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Level</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 25px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList class="form-control" ID="DLavel" runat="server" Width="92%">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        Phone No.</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                                        <asp:TextBox class="form-control" ID="phone" runat="server" Width="90%" 
                            MaxLength="12" ontextchanged="phone_TextChanged"></asp:TextBox></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        Mobile No.</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                                        <asp:TextBox class="form-control" ID="mobile" runat="server" Width="90%" 
                            MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Permanent Address</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        <asp:TextBox class="form-control" ID="padd" runat="server" Width="90%" MaxLength="255" TextMode="MultiLine"></asp:TextBox></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Local Address</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        <asp:TextBox class="form-control" ID="ladd" runat="server" Width="90%" MaxLength="255" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" 
                        style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;
                        height: 20px;width: 100%; text-align: left; border-right-width: thin; border-right-color: #666666; ">
                        Qualification/Specialization &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:DropDownList class="form-control" ID="Dmqual" runat="server" Width="12%" AutoPostBack="True" OnSelectedIndexChanged="Dmqual_SelectedIndexChanged">
                        </asp:DropDownList>/<asp:DropDownList class="form-control" ID="Dmsub" runat="server" Width="12%" AutoPostBack="True">
                        </asp:DropDownList><asp:Button class="btn btn-info" ID="QSsave" runat="server" Text="More" OnClick="QSsave_Click" />
                        <asp:Label ID="Qmes" runat="server" Font-Size="Smaller" ForeColor="Red"
                            Visible="False" Width="32px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;width: 100%; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Remarks &nbsp;<asp:TextBox ID="remark" runat="server" Width="90%" MaxLength="250" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 100%; border-top-color: #666666;
                        text-align: left; border-right-width: thin; border-right-color: #666666">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;
                        height: 3%; width: 100%; background-color: #fff8dc; text-align: left; border-right-width: thin;
                        border-right-color: #666666; font-weight: bold; color: #ffffc0;">
                        <asp:Label ID="docimage" runat="server" Text="Doctor's Image " ForeColor="Maroon"></asp:Label>
                        &nbsp; &nbsp; &nbsp;<asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666;
                        border-top-color: #666666; height: 10%;width: 100%; text-align: center; border-right-width: thin;
                        border-right-color: #666666; background-color: #661700;">
                        <asp:Label ID="maxid"  runat="server" Visible="False"></asp:Label>.<asp:Button ID="s1" class="btn btn-success" runat="server" Text="Submit" OnClick="s1_Click" OnClientClick="return funct()" Width="104px" /><asp:Label ID="err" runat="server" ForeColor="White"></asp:Label></td>
                </tr>
            </table>
        &nbsp;
   </td>
                </tr>
            </table>
        </div>
        </div>
        <script src="../js/disableprint.js" type="text/javascript" language="javascript">
</script>
<script type="text/javascript"  src="../js/date-picker.js">    function ImageButton1_onclick() {
    }

</script>
</asp:Content>
