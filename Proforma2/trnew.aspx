<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="trnew.aspx.cs" Inherits="NewWebApp.Proforma2.trnew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:ImageButton ID="BACK" runat="server" Height="24px" ImageUrl="~/images/images1.jpg"
                            OnClick="BACK_Click" Width="64px" /></td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 20px; background-color: #661700; text-align: left"
                        valign="top">
                        <span style="font-weight: bold; font-size: 12pt; color: #ffffff; background-color: #661700">
                            &nbsp;Departmental Add Training/Enquiry <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                            <asp:Label
                            ID="Fnamet" runat="server" Visible="False"></asp:Label></span></td>
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
            <table class="table table-responsive-sm" style="width: 100%; height: 35px; font-weight: bold; color: #661700; font-family: Arial; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 50%; color: #661700; background-color: #fffbd6; height: 25px;">
                        &nbsp;</td>
                    <td style="width: 50%; color: #661700; background-color: #fffbd6; height: 25px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>               
           
                </tr>
                <tr>
                    <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; color: #661700;
                        text-align: center">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td align="left" style="width: 32%; height: 25px;">
                                        &nbsp;</td>
                                    <td style="height: 25px; text-align: left; background-color: #DFAA09;">
                        <span style="color: #661700"><span style="font-weight: normal"><strong><%--Seniority Number:</span>
                        <asp:Label ID="sen" runat="server" ForeColor="#C00000"></asp:Label>--%>
                                        <span style="color: #661700; text-align: left;">&nbsp;</span> (Idno : <asp:Label ID="idno" runat="server" ForeColor="#C00000"></asp:Label>
                                        &nbsp;)&nbsp; </strong></span></td>
                                    <td style="height: 25px; text-align: left; background-color: #DFAA09;">
                        <span style="color: #661700"><span style="font-weight: normal"><strong>
                                        <span style="color: #661700; text-align: left;">Name :</span><asp:Label ID="name" runat="server" ForeColor="#C00000"></asp:Label>
                
                
                                        &nbsp;</strong></span></td>
                                    <td align="left" style="width: 25%; height: 25px;" colspan="2">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 32%; height: 25px; background-color: #FFFBD6;">
                                        &nbsp;</td>
                                    <td style="width: 15%; height: 25px; text-align: left; background-color: #FFFBD6;">
                                        <span style="color: #661700; text-align: left;">
                                        <span style="font-weight: normal"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></span></span></td>
                                    <td align="left" style="width: 19%; height: 25px; background-color: #FFFBD6;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #FFFBD6;" 
                                        colspan="2">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 32%; height: 25px;">
                                        &nbsp;</td>
                                    <td style="width: 15%; height: 25px; " >
                                        <span style="font-weight: normal"><strong  style="color: #661700">&nbsp; Training Type</strong></span></td>
                                    <td align="left" style="width: 19%; height: 25px;" >
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 25%; height: 25px;" colspan="2">
                                        &nbsp;</td>
                                   <%-- <td align="left" style="width: 25%; height: 25px;">
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 32%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                    <td style="width: 15%; height: 25px; background-color: #fffbd6; " 
                                        bgcolor="Black">
                                        <span style="font-weight: normal"><strong style="color: #661700">&nbsp;Training Place</strong></span></td>
                                    <td align="left" style="width: 19%; height: 25px; background-color: #fffbd6;">
                                        <asp:TextBox ID="trplace" runat="server" Height="24px" Width="159px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" 
                                        colspan="2">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                    </td>
                                </tr>
                                <tr>
                                        <td align="left" style="width: 32%";  >
                                        
                                        </td>
                                    <td style="width: 15%; ">
                                        <span style="font-weight: normal"><strong style="color: #661700; height: 25px;">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From Date</strong></span></td>
                                    <td align="left" style="width: 19%;">


                                        <asp:DropDownList ID="fdd" runat="server" Height="22px" Width="73px">
                                         <asp:ListItem>--Date--</asp:ListItem>
                                          <asp:ListItem>1</asp:ListItem>
                                           <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                             <asp:ListItem>4</asp:ListItem>
                                              <asp:ListItem>5</asp:ListItem>
                                               <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                 <asp:ListItem>8</asp:ListItem>
                                                  <asp:ListItem>9</asp:ListItem>
                                                   <asp:ListItem>10</asp:ListItem>
                                                   <asp:ListItem>11</asp:ListItem>
                                           <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                             <asp:ListItem>14</asp:ListItem>
                                              <asp:ListItem>15</asp:ListItem>
                                               <asp:ListItem>16</asp:ListItem>
                                                <asp:ListItem>17</asp:ListItem>
                                                 <asp:ListItem>18</asp:ListItem>
                                                  <asp:ListItem>19</asp:ListItem>
                                                   <asp:ListItem>20</asp:ListItem>
                                                   <asp:ListItem>21</asp:ListItem>
                                           <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                             <asp:ListItem>24</asp:ListItem>
                                              <asp:ListItem>25</asp:ListItem>
                                               <asp:ListItem>26</asp:ListItem>
                                                <asp:ListItem>27</asp:ListItem>
                                                 <asp:ListItem>28</asp:ListItem>
                                                  <asp:ListItem>29</asp:ListItem>
                                                   <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>31</asp:ListItem>
 
                                                                                         
                                         </asp:DropDownList>
                                        <asp:DropDownList ID="fmm" runat="server" Height="22px" Width="73px">
                                        <asp:ListItem>--Month--</asp:ListItem>
                                        <asp:ListItem>Jan</asp:ListItem>
                                           <asp:ListItem>Feb</asp:ListItem>
                                            <asp:ListItem>March</asp:ListItem>
                                             <asp:ListItem>April</asp:ListItem>
                                              <asp:ListItem>May</asp:ListItem>
                                               <asp:ListItem>June</asp:ListItem>
                                                <asp:ListItem>July</asp:ListItem>
                                                 <asp:ListItem>August</asp:ListItem>
                                                  <asp:ListItem>September</asp:ListItem>
                                                   <asp:ListItem>October</asp:ListItem>
                                                   <asp:ListItem>November</asp:ListItem>
                                                   <asp:ListItem>December</asp:ListItem>

                                        </asp:DropDownList>
                                        <asp:DropDownList ID="fyy" runat="server" Height="22px" Width="73px">
                                        <asp:ListItem>--Year--</asp:ListItem>
                                        <asp:ListItem>2000</asp:ListItem>
                                        <asp:ListItem>2001</asp:ListItem>
                                         <asp:ListItem>2002</asp:ListItem>
                                         <asp:ListItem>2003</asp:ListItem>
                                         <asp:ListItem>2004</asp:ListItem>
                                       <asp:ListItem>2005</asp:ListItem>
                                       <asp:ListItem>2006</asp:ListItem>
                                         <asp:ListItem>2007</asp:ListItem>
                                          <asp:ListItem>2008</asp:ListItem>
                                             <asp:ListItem>2009</asp:ListItem>
                                          <asp:ListItem>2010</asp:ListItem>
                                          <asp:ListItem>2011</asp:ListItem>
                                          <asp:ListItem>2012</asp:ListItem>
                                           <asp:ListItem>2013</asp:ListItem>
                                            <asp:ListItem>2014</asp:ListItem>
                                             <asp:ListItem>2015</asp:ListItem>
                                              <asp:ListItem>2016</asp:ListItem>
                                               <asp:ListItem>2017</asp:ListItem>
                                                <asp:ListItem>2018</asp:ListItem>
                                                 <asp:ListItem>2019</asp:ListItem>
                                                  <asp:ListItem>2020</asp:ListItem>
                                                   <asp:ListItem>2021</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 25%;"  colspan="2">


                                        &nbsp;</td><td align="left" style="width: 25%;" bgcolor="#FFFFCC"></td>
                                  </tr>
                                <tr>
                                    <td align="left" style="width: 32%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                    <td style="width: 15%; height: 25px; background-color: #fffbd6; " 
                                        bgcolor="Black">
                                        <span style="font-weight: normal"><strong style="color: #661700">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To Date</strong></span></td>
                                    <td align="left" style="width: 19%; height: 25px; background-color: #fffbd6;">
                                        <asp:DropDownList ID="todd" runat="server" style="height: 22px">
                                        
                                        <asp:ListItem>--Date--</asp:ListItem>
                                          <asp:ListItem>1</asp:ListItem>
                                           <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                             <asp:ListItem>4</asp:ListItem>
                                              <asp:ListItem>5</asp:ListItem>
                                               <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                 <asp:ListItem>8</asp:ListItem>
                                                  <asp:ListItem>9</asp:ListItem>
                                                   <asp:ListItem>10</asp:ListItem>
                                                   <asp:ListItem>11</asp:ListItem>
                                           <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                             <asp:ListItem>14</asp:ListItem>
                                              <asp:ListItem>15</asp:ListItem>
                                               <asp:ListItem>16</asp:ListItem>
                                                <asp:ListItem>17</asp:ListItem>
                                                 <asp:ListItem>18</asp:ListItem>
                                                  <asp:ListItem>19</asp:ListItem>
                                                   <asp:ListItem>20</asp:ListItem>
                                                   <asp:ListItem>21</asp:ListItem>
                                           <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                             <asp:ListItem>24</asp:ListItem>
                                              <asp:ListItem>25</asp:ListItem>
                                               <asp:ListItem>26</asp:ListItem>
                                                <asp:ListItem>27</asp:ListItem>
                                                 <asp:ListItem>28</asp:ListItem>
                                                  <asp:ListItem>29</asp:ListItem>
                                                   <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>31</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                        <asp:DropDownList ID="tomm" runat="server" Height="22px" Width="73px">
                                                    <asp:ListItem>--Month--</asp:ListItem>
                                        <asp:ListItem>Jan</asp:ListItem>
                                           <asp:ListItem>Feb</asp:ListItem>
                                            <asp:ListItem>March</asp:ListItem>
                                             <asp:ListItem>April</asp:ListItem>
                                              <asp:ListItem>May</asp:ListItem>
                                               <asp:ListItem>June</asp:ListItem>
                                                <asp:ListItem>July</asp:ListItem>
                                                 <asp:ListItem>August</asp:ListItem>
                                                  <asp:ListItem>September</asp:ListItem>
                                                   <asp:ListItem>October</asp:ListItem>
                                                   <asp:ListItem>November</asp:ListItem>
                                                   <asp:ListItem>December</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="toyy" runat="server" Height="22px" Width="73px">
                                        <asp:ListItem>--Year--</asp:ListItem>
                                         <asp:ListItem>2000</asp:ListItem>
                                        <asp:ListItem>2001</asp:ListItem>
                                         <asp:ListItem>2002</asp:ListItem>
                                         <asp:ListItem>2003</asp:ListItem>
                                         <asp:ListItem>2004</asp:ListItem>
                                       <asp:ListItem>2005</asp:ListItem>
                                       <asp:ListItem>2006</asp:ListItem>
                                         <asp:ListItem>2007</asp:ListItem>
                                          <asp:ListItem>2008</asp:ListItem>
                                             <asp:ListItem>2009</asp:ListItem>
                                          <asp:ListItem>2010</asp:ListItem>
                                          <asp:ListItem>2011</asp:ListItem>
                                          <asp:ListItem>2012</asp:ListItem>
                                           <asp:ListItem>2013</asp:ListItem>
                                            <asp:ListItem>2014</asp:ListItem>
                                             <asp:ListItem>2015</asp:ListItem>
                                              <asp:ListItem>2016</asp:ListItem>
                                               <asp:ListItem>2017</asp:ListItem>
                                                <asp:ListItem>2018</asp:ListItem>
                                                 <asp:ListItem>2019</asp:ListItem>
                                                  <asp:ListItem>2020</asp:ListItem>
                                                   <asp:ListItem>2021</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>


                                    
                                    </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" 
                                        colspan="2">
                                        &nbsp;</td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 32%; height: 25px;">
                                        &nbsp;</td>
                                    <td >
                                        </td>
                                    <td align="left" >
                                        &nbsp;</td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;">
                                    <asp:Button ID="FSheet" runat="server" OnClick="FSheet_Click" Text="Fact Sheet"
                            Width="96px" Font-Size="X-Small" /></td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;">
                                        &nbsp;</td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </div>
                   
                
                <tr>
                    <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; 
                        text-align: center; background-color: #FFFBD6;">
                        <asp:Button ID="SAVE" runat="server" Text="Save" OnClick="SAVE_Click" /><asp:Label ID="mesg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; color: #fffbd6;
                        text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 12px; color: #ffffff; text-align: left">
                        <ul>
                            <li>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                            DataKeyNames="trid" Height="50%" Width="100%" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged" style="text-align: center">
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="trid" HeaderText="Training Id" SortExpression="trid"  />
                                        <asp:BoundField DataField="trplace" HeaderText="Training Place" SortExpression="trplace" />
                                        
                                        <asp:CommandField ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </li>
                        </ul>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
                            SelectCommand="SELECT trid,  trplace FROM trainingdetail WHERE (idno = @idno)" DeleteCommand="delete from trainingdetail WHERE (trid = @trid)">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:ControlParameter ControlID="Gridview1" Name="trid" PropertyName="SelectedValue"  />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 12px; color: #661700; background-color: #661700; text-align: center">
                        </td>
                            </tr>
            </table>
       </td>
                </tr>
            </table>
        </div>
       
       
  
</asp:Content>
