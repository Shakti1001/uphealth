<%@ Page Title="::Personal Section::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Option.aspx.cs" Inherits="NewWebApp.Proforma2.Option" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right;" valign="top" colspan="2">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; text-align: center" valign="top">
                        <table class="table table-responsive-sm" style="width: 100%; height: 100%">
                            <tr>
                                <td colspan="2" style="height: 0px; text-align: center" valign="top">
                                    <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                                        <tr>
                                            <td class="hindiW">
                                                <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="5%">
                                                            <div align="center" class="englishb">
                                                            </div>
                                                        </td>
                                                        <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f; text-align: left" width="55%">
                                                            &nbsp;Medical Section / Proforma-2 (P2) Option</td>
                                                        <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f" width="28%">
                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Ename" runat="server" Visible="False"></asp:Label></td>
                                                        <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="12%">
                        <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="Addpers" runat="server" Font-Bold="True" Font-Size="Medium"
                            OnClick="Addpers_Click" Width="152px" ForeColor="#74211F">Add Personnel Details</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" 
                                                            style="background-color: #fff8dc; ">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" 
                                                            style="background-color: #fff8dc; text-align: left; height: 19px;">
                        <asp:LinkButton ID="Editpers" runat="server" Font-Bold="True" OnClick="Editpers_Click" Font-Size="Medium" Width="160px" ForeColor="#74211F">Edit Personnel Details(new)</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="EditQ" runat="server" Font-Bold="True" ForeColor="#74211F"
                        OnClick="EditQ_Click" Width="208px">Add/Edit Qualification  Details</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="EditPost" runat="server" Font-Bold="True" OnClick="EditPost_Click" Font-Size="Medium" Width="168px" ForeColor="#74211F">Add/Edit Posting Details</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="EditEQN" runat="server" Font-Bold="True" Font-Size="Medium"
                        OnClick="EditEQN_Click" Width="320px" ForeColor="#74211F">Add/Edit  Departmental Enquiry/ Proceedings</asp:LinkButton></td>
                                                    </tr>
                                                     
                                                    <tr>
                                                        <%--<td style="height: 10px">
                                                            &nbsp;</td>--%>
                                                        <td colspan="2" style="height: 10px">
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" 
                                                            style="background-color: #fff8dc; text-align: left" >
                                                            <asp:LinkButton ID="TRNG" runat="server" onclick="TRNG_Click1"  
                                                                Font-Bold="True" Font-Size="Medium" ForeColor="Maroon">Add/Edit Training Details  </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                     
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" 
                                                            style="background-color: #fff8dc; text-align: left" >
                                                            <asp:LinkButton ID="ACR" runat="server" onclick="ACR_Click1"  
                                                                Font-Bold="True" Font-Size="Medium" ForeColor="Maroon">ACR Detail Entry  </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                     
                                                    <tr>
                                                        <%--<td style="height: 5px">
                                                            &nbsp;</td>--%>
                                                        <td colspan="2" style="height: 10px">
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                                            &nbsp;<asp:LinkButton ID="JR" runat="server" Font-Bold="True" Font-Size="Medium"
                                                                ForeColor="#74211F" OnClick="JR_Click" Width="176px"> Join And Relieve  Section </asp:LinkButton></td>
                                                    </tr>
                                                   
                                                    
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="Rsec" runat="server" Font-Bold="True" Font-Size="Medium" OnClick="Rsec_Click"
                        Width="104px" ForeColor="#74211F">Reports</asp:LinkButton></td>
                                                    </tr>
                                                   
                                                   
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    
                                              <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                                            <asp:LinkButton ID="lnkApprove" runat="server" Font-Bold="True" Font-Size="Medium"
                                                                ForeColor="#74211F"  Width="128px" onclick="lnkApprove_Click">Approve Edited Personaldetail</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                    </tr>       
                                                   <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>  
                                                    
                                                    
                                                                                                  <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                                            <asp:LinkButton ID="Trans" runat="server" Font-Bold="True" Font-Size="Medium"
                                                                ForeColor="#74211F" OnClick="Trans_Click" Width="128px" Visible="False">Transfer Section</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                    </tr>          
                                                </table>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#fe8631">
                                            <td bgcolor="#fe8631" height="30" style="background-color: #74211f">
                        <asp:Label ID="mess" runat="server" ForeColor="#FFFF99" Font-Bold="True"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        </div>

</asp:Content>
