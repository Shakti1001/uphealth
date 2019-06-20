﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="join.aspx.cs" Inherits="NewWebApp.Proforma2.join" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/disableprint.js" type="text/javascript" language="javascript">
</script>
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 297px;" valign="top">
    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #661700;
            font-family: Arial; height: 1px; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" style=" width: 100%; color: #ffff99;
                text-align: left; height: 18px; background-color: #661700;">
                <span style="font-size: 10pt;">&nbsp; Medical Section / P2 / Joining
                    <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                    <asp:Label
                        ID="Fnamet" runat="server" Visible="False"></asp:Label></span></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 14px; width: 100%; height: 24px; background-color: burlywood;
                text-align: center">
                <span>Seniority Number
                        <asp:Label ID="sen" runat="server" ForeColor="Blue"></asp:Label></span> ,<span>Name
                <asp:Label ID="name" runat="server"
                        ForeColor="Blue"></asp:Label></span>&nbsp; ,Post
                    <asp:Label ID="post" runat="server" ForeColor="Blue"></asp:Label>,Place Of Posting
                    <asp:Label ID="plpost" runat="server" ForeColor="Blue"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 14px; width: 100%; color: maroon; text-align: center">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                Designation</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="DDesign" runat="server" Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                Post</td>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="DPOST" runat="server" Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                Posting District</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="DDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>

                         <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                Level</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:DropDownList ID="ddlavel" runat="server" AutoPostBack="True"                    Width="200px" OnSelectedIndexChanged="ddlavel_SelectedIndexChanged">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>

                        <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                    Place of Posting</td>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="Dplace" runat="server" OnSelectedIndexChanged="Dplace_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                Order No:</td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                <asp:TextBox ID="Ornot" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                <asp:DropDownList ID="DDD" runat="server" Visible="False">
                </asp:DropDownList><asp:DropDownList ID="DMM" runat="server" Visible="False">
                </asp:DropDownList><asp:DropDownList ID="DYYYY" runat="server" Visible="False">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%">
                    Order Date:</td>
                            <td align="left" style="width: 25%">
                               <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajx:ToolkitScriptManager>
                                <asp:TextBox ID="OrDate" runat="server" Height="18px" Style="background-color: white"
                                    Width="82px"></asp:TextBox>
                                <asp:Image ID="Imagecal" runat="server" 
                                    ImageUrl="~/Proforma2/calender/cal_img/cal.gif" style="width: 16px" />
                                    <ajx:CalendarExtender ID="Calendar1" PopupButtonID="Imagecal" runat="server" TargetControlID="OrDate"
    Format="dd/MM/yyyy">
</ajx:CalendarExtender>
                                    
                                    </td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 16px; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; height: 16px; background-color: #fff8dc">
                    Order By:</td>
                            <td align="left" style="width: 25%; height: 16px; background-color: #fff8dc">
                                <asp:DropDownList ID="JORDERDD" runat="server" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="JORDERDD_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; height: 16px; background-color: #fff8dc">
                                &nbsp;<asp:TextBox ID="Orbyt" runat="server" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 20px;">
                            </td>
                            <td align="left" style="width: 25%; height: 20px;">
                                Relieving Officer</td>
                            <td align="left" style="width: 25%; height: 20px;">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                            <td align="left" style="width: 25%; height: 20px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 20px; background-color: #fff8dc">
            <asp:DropDownList ID="DD1" runat="server" Visible="False">
                </asp:DropDownList><asp:DropDownList ID="DM1" runat="server" Visible="False">
                </asp:DropDownList><asp:DropDownList ID="DY1" runat="server" Visible="False">
                </asp:DropDownList></td>
                            <td align="left" style="width: 25%; height: 20px; background-color: #fff8dc">
                    Date Of Joinning:</td>
                            <td align="left" style="width: 25%; height: 20px; background-color: #fff8dc">
                                       

                                <asp:TextBox ID="DOJtext" runat="server" Height="18px" Style="background-color: white"
                                    Width="82px"></asp:TextBox><asp:Image ID="DORImage" runat="server" 
                                    ImageUrl="~/Proforma2/calender/cal_img/cal.gif" />
                                     <ajx:CalendarExtender ID="CalendarExtender1" PopupButtonID="DORImage" runat="server" TargetControlID="DOJtext"
    Format="dd/MM/yyyy">
</ajx:CalendarExtender>
                                    
                                    </td>
                            <td align="left" style="width: 25%; height: 20px; background-color: #fff8dc">
                                <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label><asp:Label ID="curdate" runat="server" Visible="False"></asp:Label><asp:Label ID="oid" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:Button ID="BSAVE" class="btn btn-success" runat="server" Text="Save" OnClick="BSAVE_Click" Width="80px" /></td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                <asp:LinkButton ID="fLink" runat="server" Visible="False" OnClick="fLink_Click">Check Factsheet</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; height: 16px; background-color: #ffffff;
                                text-align: center">
                    <asp:Label ID="mesg" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; height: 25px; background-color: #fff8dc;
                                text-align: right">
                    <asp:Button ID="PFsheet" runat="server" class="btn btn-danger" OnClick="PFsheet_Click" Text="Print Charge Certificate" Width="184px" Visible="False" /></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="background-color: #661700; text-align: center; color: #ffff99; width: 100%; height: 25px;">
                    </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        </table>
        </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
