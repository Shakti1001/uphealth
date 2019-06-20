<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="parap2opr.aspx.cs" Inherits="NewWebApp.payrole.parap2opr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="table table-responsive-sm table-active" style=" width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        &nbsp;
                        <asp:Button
                            ID="Button1" runat="server" OnClick="Button1_Click" Text="By Part of name" Width="104px" Visible="False" />
                        <asp:TextBox ID="TextBox2" runat="server" Visible="False" Width="16px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="ImageButton3" runat="server" Height="24px" Width="64px" ImageUrl="~/images/images1.jpg" OnClick="ImageButton3_Click" /></td>
               
                </tr>
                <tr>
                    <td style="width: 100%;  text-align: center" valign="top">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="3">
                                  
                                        <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                                            <tr>
                                                <td class="hindiW">
                                                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                                                width="5%">
                                                                <div align="center" class="englishb">
                                                                </div>
                                                            </td>
                                                            <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                                background-color: #661700; text-align: left;" width="55%">
                                                                &nbsp; Paramedical Staff/Edit/Delete Option Of P2
                        <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
                                                            <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                                                background-color: #661700" width="28%">
                        <asp:Label ID="Ename" runat="server" Visible="False" ForeColor="#FFFFC0"></asp:Label></td>
                                                            <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                                                width="12%">
                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" bgcolor="#376fbc" colspan="4" height="30" style="background-color: #fff8dc">
                                                                <table class="table table-responsive-sm" style="border-top-width: thin; border-left-width: thin; border-left-color: #990000;
                                                                    border-bottom-width: thin; border-bottom-color: #990000; width: 100%; color: #003366;
                                                                    border-top-color: #990000; font-family: Georgia; border-right-width: thin; border-right-color: #990000">
                                                                    <tr>
                                                                        <td style="width: 100%">
                                                                            <asp:LinkButton ID="A" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="A_Click">A</asp:LinkButton>
                                                                            <asp:LinkButton ID="B" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="B_Click">B</asp:LinkButton>
                                                                            <asp:LinkButton ID="C" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="C_Click">C</asp:LinkButton>
                                                                            <asp:LinkButton ID="D" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="D_Click">D</asp:LinkButton>
                                                                            <asp:LinkButton ID="E" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="E_Click">E</asp:LinkButton>
                                                                            <asp:LinkButton ID="F" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="F_Click">F</asp:LinkButton>
                                                                            <asp:LinkButton ID="G" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="G_Click">G</asp:LinkButton>
                                                                            <asp:LinkButton ID="H" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="H_Click">H</asp:LinkButton>
                                                                            <asp:LinkButton ID="I" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="I_Click">I</asp:LinkButton>
                                                                            <asp:LinkButton ID="J" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="J_Click">J</asp:LinkButton>
                                                                            <asp:LinkButton ID="K" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="K_Click">K</asp:LinkButton>
                                                                            <asp:LinkButton ID="L" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="L_Click">L</asp:LinkButton>
                                                                            <asp:LinkButton ID="M" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="M_Click">M</asp:LinkButton>
                                                                            <asp:LinkButton ID="N" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="N_Click">N</asp:LinkButton>
                                                                            <asp:LinkButton ID="O" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="O_Click">O</asp:LinkButton>
                                                                            <asp:LinkButton ID="P" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="P_Click">P</asp:LinkButton>
                                                                            <asp:LinkButton ID="Q" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="Q_Click">Q</asp:LinkButton>
                                                                            <asp:LinkButton ID="R" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="R_Click">R</asp:LinkButton>
                                                                            <asp:LinkButton ID="S" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="S_Click">S</asp:LinkButton>
                                                                            <asp:LinkButton ID="T" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="T_Click">T</asp:LinkButton>
                                                                            <asp:LinkButton ID="U" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="U_Click">U</asp:LinkButton>
                                                                            <asp:LinkButton ID="V" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="V_Click">V</asp:LinkButton>
                                                                            <asp:LinkButton ID="W" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="W_Click">W</asp:LinkButton>
                                                                            <asp:LinkButton ID="X" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="X_Click">X</asp:LinkButton>
                                                                            <asp:LinkButton ID="Y" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="Y_Click">Y</asp:LinkButton>
                                                                            <asp:LinkButton ID="Z" runat="server" Font-Bold="True" ForeColor="Maroon" OnClick="Z_Click">Z</asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:Label ID="Ctot" runat="server" ForeColor="#C00000" Visible="False"></asp:Label>
                        <asp:TextBox ID="VALT" runat="server" Width="64px" AutoPostBack="True" OnTextChanged="VALT_TextChanged" Visible="False"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 11px; background-image: url(../images/tab.jpg); width: 100%;
                                                                            font-family: Arial; text-align: left">
                                                                             <asp:Panel ID="Panel1" runat="server" Height="50%" Width="100%" >
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" Height="50%" Width="100%">
            <FooterStyle BackColor="#661700" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" Font-Bold="True" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:TemplateField HeaderText="S.No">
<ItemTemplate ><%# Container.DataItemIndex+1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:TemplateField>
 <asp:TemplateField HeaderText="Computer ID" SortExpression="idno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("idno") %>' NavigateUrl='<%#"parap2edit.aspx?idno=" + Eval("idno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
  <asp:BoundField DataField="gpfno" HeaderText="GPF No" SortExpression="gpfno" />
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
               <%-- <asp:TemplateField HeaderText="GPF No" SortExpression="gpfno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("gpfno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='<%# Eval("gpfno") %>' NavigateUrl='<%# "parap2edit.aspx?idno=" + Eval("idno") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="fathername" HeaderText="Father/Husband" SortExpression="fathername" />
                <asp:BoundField DataField="dob" HeaderText="Date Of Birth" SortExpression="dob" />
                <asp:BoundField DataField="cadrename" HeaderText="Cadre" SortExpression="cadrename" />
                <asp:BoundField DataField="districtname" HeaderText="Home District" SortExpression="districtname" />
            </Columns>
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpcon %>"
            
                                                                                     SelectCommand="SELECT PMDpersonaldetails.idno, PMDpersonaldetails.gpfno, PMDpersonaldetails.name, PMDpersonaldetails.fathername, CONVERT (Char, PMDpersonaldetails.dob, 106) AS dob, hospitaldistrict.districtname, PMDCadre.cadrename FROM PMDpersonaldetails INNER JOIN hospitaldistrict ON PMDpersonaldetails.homedistrictid = hospitaldistrict.districtid INNER JOIN PMDCadre ON PMDpersonaldetails.cadreid = PMDCadre.cadreid INNER JOIN PMDCposted ON PMDpersonaldetails.idno = PMDCposted.idno WHERE (PMDCposted.districtid = @userid) AND (PMDpersonaldetails.name LIKE @name) ORDER BY PMDpersonaldetails.name">
            <SelectParameters>
                <asp:ControlParameter ControlID="Uidt" Name="userid" PropertyName="Text" />
                <asp:ControlParameter ControlID="VALT" Name="name" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
                                
                            </asp:Panel>
                            <asp:Panel ID="Panel2" runat="server" Height="50%" Width="100%">
                            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" Height="50%" Width="100%">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" Font-Bold="True" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:TemplateField HeaderText="S.No">
<ItemTemplate ><%# Container.DataItemIndex+1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:TemplateField>
 <asp:TemplateField HeaderText="Computer ID" SortExpression="idno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("idno") %>' NavigateUrl='<%#"parap2qual.aspx?idno=" + Eval("idno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:BoundField DataField="gpfno" HeaderText="GPF No" SortExpression="gpfno" />
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
               <%-- <asp:TemplateField HeaderText="GPF No" SortExpression="gpfno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("gpfno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("gpfno") %>' NavigateUrl='<%#"parap2qual.aspx?idno=" + Eval("idno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="fathername" HeaderText="Father/Husband" SortExpression="fathername" />
                <asp:BoundField DataField="dob" HeaderText="Date Of Birth" SortExpression="dob" />
                <asp:BoundField DataField="cadrename" HeaderText="Cadre" SortExpression="cadrename" />
                <asp:BoundField DataField="districtname" HeaderText="Home District" SortExpression="districtname" />
            </Columns>
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        </asp:GridView>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;</asp:Panel>
                            <asp:Panel ID="Panel3" runat="server" Height="50%" Width="100%">
                            <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" Height="50%" Width="100%">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" Font-Bold="True" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:TemplateField HeaderText="S.No">
<ItemTemplate ><%# Container.DataItemIndex+1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:TemplateField>
 <asp:TemplateField HeaderText="Computer ID" SortExpression="idno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("idno") %>' NavigateUrl='<%#"parap2Posting.aspx?idno=" + Eval("idno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="gpfno" HeaderText="GPF No" SortExpression="gpfno" />
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <%--<asp:TemplateField HeaderText="GPF No" SortExpression="gpfno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("gpfno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("gpfno") %>' NavigateUrl='<%#"parap2Posting.aspx?idno=" + Eval("idno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="fathername" HeaderText="Father/Husband" SortExpression="fathername" />
                <asp:BoundField DataField="dob" HeaderText="Date Of Birth" SortExpression="dob" />
                <asp:BoundField DataField="cadrename" HeaderText="Cadre" SortExpression="cadrename" />
                <asp:BoundField DataField="districtname" HeaderText="Home District" SortExpression="districtname" />
            </Columns>
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="Panel4" runat="server" Height="50%" Width="100%">
                            <asp:GridView ID="GridView4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" Height="50%" Width="100%">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" Font-Bold="True" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:TemplateField HeaderText="S.No">
<ItemTemplate ><%# Container.DataItemIndex+1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:TemplateField>
 <asp:TemplateField HeaderText="Computer ID" SortExpression="idno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("idno") %>' NavigateUrl='<%#"parap2enquiry.aspx?idno=" + Eval("idno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="gpfno" HeaderText="GPF No" SortExpression="gpfno" />
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <%--<asp:TemplateField HeaderText="GPF No" SortExpression="gpfno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("gpfno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("gpfno") %>' NavigateUrl='<%#"parap2enquiry.aspx?idno=" + Eval("idno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="fathername" HeaderText="Father/Husband" SortExpression="fathername" />
                <asp:BoundField DataField="dob" HeaderText="Date Of Birth" SortExpression="dob" />
                <asp:BoundField DataField="cadrename" HeaderText="Cadre" SortExpression="cadrename" />
                <asp:BoundField DataField="districtname" HeaderText="Home District" SortExpression="districtname" />
            </Columns>
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        </asp:GridView>
                            </asp:Panel>
                        
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                &nbsp;&nbsp;</td>
                                                        </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#fe8631">
                                                <td bgcolor="#fe8631" height="30" style="background-color: #661700">
                        <asp:Label ID="mesg" runat="server" ForeColor="#FFFFC0" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
