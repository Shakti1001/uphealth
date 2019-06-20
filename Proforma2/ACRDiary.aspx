<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="ACRDiary.aspx.cs" Inherits="NewWebApp.Proforma2.ACRDiary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function preventBack() { window.history.forward(); }
    setTimeout("preventBack()", 0);
    window.onunload = function () { null };
</script>
 <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 20px; background-color: #661700; text-align: left"
                        valign="top">
                        <span style="font-weight: bold; font-size: 12pt; color: #ffffff; background-color: #661700; text-align: center;">
                           <center> ACR Detail Entry</center> <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                            <asp:Label
                            ID="Fnamet" runat="server" Visible="False"></asp:Label></span></td>
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
            <table class="table table-responsive-sm" style="width: 100%; height: 35px; font-weight: bold; color: #661700; font-family: Arial; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 50%; color: #661700; background-color: #fffbd6; height: 25px;">
                        <span style="color: #661700">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
                    <td style="width: 50%; color: #661700; background-color: #fffbd6; height: 25px; text-align: left;">
                        &nbsp;</td>
                
           
                </tr>
                <tr>
                    <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; color: #661700;
                        text-align: center">
                        <div style="text-align: center">
                            <table class=" table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td align="left" style="height: 25px">
                                        &nbsp;</td>
                                    <td align="left" colspan="2" 
                                        style="height: 25px; background-color: #C89704;"   >
                                        <span style="color: #661700">&nbsp; </span>
                        <span style="color: #661700; text-align: left;">Name:<span style="color: #661700"><asp:Label ID="name" runat="server" ForeColor="#C00000"></asp:Label>
                
                
                       &nbsp;( Idno&nbsp;&nbsp;
                        <asp:Label ID="idno" runat="server" ForeColor="#C00000"></asp:Label>
                                        </span>)</span></td>



                                    <td align="right" style="height: 25px">
                                    </td>
                                     </tr>
                                <%-- <tr>
                                    <td align="left" style="background-color: #FFFBD6; height: 28px;" >
                                    </td>
                                    <td align="left" style="height: 28px; background-color: #FFFBD6;" >
                                        </td>



                                   
                                    <td align="left" style="background-color: #FFFBD6; height: 28px;" >
                                        </td><td align="right" style="background-color: #FFFBD6; height: 28px;">

                                </tr>--%>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6;" >
                                        &nbsp;</td>
                                    <td align="left" style="height: 25px;background-color: #fffbd6;">
                                        ACR Financial Year :</td>
                                    <td align="left"  
                                        style=" height: 25px; background-color: #fffbd6;">
                                        <asp:TextBox ID="fy1" runat="server" Width="105px"></asp:TextBox>
                                        &nbsp; (YYYY-YYYY)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        Year :&nbsp;&nbsp; <asp:TextBox ID="fy2" runat="server" Width="104px"></asp:TextBox>
                                       </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        (YYYY)</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;" >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        &nbsp;</td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;  ">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        &nbsp;</td>
                                    <td align="left" 
                                        style="width: 25%; height: 25px;  text-decoration: underline; background-color: #fffbd6;" >
                                        Initiating Officer</td>
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6; " >
                                        &nbsp;</td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6; ">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;" >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        Name :</td>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        <asp:TextBox class="form-control" ID="initiatename" runat="server"  Width="159px"></asp:TextBox>
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;  ">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6; " > 
                                        Designation:</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        <asp:DropDownList class="form-control" ID="initiatedeg" runat="server"  Width="163px">
                                        </asp:DropDownList>
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6; ">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;" >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; " > 
                                        District :</td>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        <asp:DropDownList class="form-control" ID="initiatedistrict" runat="server" 
                                            Width="163px">
                                        </asp:DropDownList>
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6;" >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" > 
                                        Place of Posting :</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        <asp:TextBox class="form-control" ID="initiateposting" runat="server"  Width="159px"></asp:TextBox>
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;  background-color: #fffbd6;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;" >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; " > 
                                        Remark&#39;s:</td>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        <asp:TextBox class="form-control" ID="initiateremark" runat="server" Width="474px" ></asp:TextBox>
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;  ">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6;" >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" > 
                                        Grade Awarded:</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        <%--<asp:TextBox ID="initiategrade" runat="server" Height="22px" Width="159px"></asp:TextBox>--%>
                                        <asp:DropDownList class="form-control" ID="initiategrade" runat="server"  Width="163px">
                                        </asp:DropDownList>
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;  background-color: #fffbd6;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;" >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; " > 
                                        Awarded Date:</td>
                                    <td align="left" style="width: 25%; height: 25px; " id="yy" >
                                        <asp:DropDownList class="form-control" ID="dd" runat="server" style="background-color: #FFFFFF" 
                                             Width="105px">
                                        
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
                                        <asp:DropDownList class="form-control" ID="mm" runat="server" style="background-color: #FFFFFF" 
                                             Width="105px">
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
                                        <asp:DropDownList class="form-control" ID="yy" runat="server"  style="background-color: #FFFFFF" 
                                             Width="105px">
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


                                    
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6;" >
                                        </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;  background-color: #fffbd6;">
                                        </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        &nbsp;</td>
                                    <td align="left" 
                                        
                                        
                                        style="width: 25%; height: 25px;  text-align: left; text-decoration: underline;" >
                                        
                                        Review Officer</td>
                                    <td align="left" style="width: 25%; height: 25px; "> 
                                        
                                        &nbsp;</td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 24px; " bgcolor="#fffbd6">
                                    </td>
                                    <td align="left" style="width: 25%; height: 24px; " bgcolor="#fffbd6">Name:</td>
                                    <td align="left" style="width: 25%; height: 24px; " bgcolor="#fffbd6">
                                        <asp:TextBox class="form-control" ID="rviewname" runat="server"  Width="159px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 25%; height: 24px; " bgcolor="#fffbd6">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;" >
                                        </td>
                                    <td align="left" style="width: 25%; height: 25px; " >Designation:</td>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        <asp:DropDownList class="form-control" ID="rviewdeg" runat="server"  Width="163px">
                                        </asp:DropDownList>
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6;" >
                                        </td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                       District :</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;" >
                                        <%--<asp:TextBox ID="rviewdistrict" runat="server" Height="22px" Width="159px"></asp:TextBox>--%>
                                        <asp:DropDownList class="form-control" ID="rviewdistrict" runat="server"  Width="163px">
                                        </asp:DropDownList>
                                        </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px;  background-color: #fffbd6;">
                                        </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 26px; ">
                                    </td>
                                    <td align="left" style="width: 25%; height: 26px; " >
                                       Place of Posting:</td>
                                    <td align="left" style="width: 25%; height: 26px; " >
                                        <asp:TextBox class="form-control" ID="rviewposting" runat="server"  Width="159px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 25%; height: 26px; ">
                                    </td>
                                </tr>
                                <tr style="background-color: #FFFFCC; height: 25px">
                                    <td align="left" style="width: 25%; height: 20px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        Remark&#39;s:</td>
                                    <td align="left" style="width: 25%; height: 20px; background-color: #fffbd6;">
                                        <asp:TextBox class="form-control" ID="rviewremark" runat="server"  Width="475px" 
                                            style="background-color: #FFFFFF"></asp:TextBox>
                                    </td>


                                    
                                    <td align="left" style="width: 25%; height: 20px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 27px; " >
                                        </td>
                                    <td align="left" style="width: 25%; height: 27px; ">
                                         Grade Awarded: </td>
                                    <td align="left" style="width: 25%; height: 27px; ">
                                        <%--<asp:TextBox ID="grade" runat="server" Height="24px" Width="159px" 
                                            ontextchanged="grade_TextChanged"></asp:TextBox>--%><%--<asp:TextBox ID="grade" runat="server" Height="22px" Width="159px"></asp:TextBox>--%>
                                        <asp:DropDownList class="form-control" ID="rviewgrade" runat="server"  Width="163px">
                                        </asp:DropDownList>
                                    </td>


                                    
                                    <td align="left" style="width: 25%; height: 27px; " >
                                        </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        Awarded&nbsp; Date:&nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        <asp:DropDownList class="form-control" ID="rviewdd" runat="server"  style="background-color: #FFFFFF" 
                                             Width="105px">
                                        
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
                                        <asp:DropDownList class="form-control" ID="rviewmm" runat="server"  style="background-color: #FFFFFF" 
                                             Width="105px">
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
                                        <asp:DropDownList class="form-control" ID="rviewyy" runat="server"  style="background-color: #FFFFFF" 
                                             Width="105px">
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


                                    
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        &nbsp;</td>
                                    <td align="left" style="text-decoration: underline" >
                                        
                                        
                                        Accept Officer</td>
                                    <td align="left" >
                                        &nbsp;</td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        Name:</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        <asp:TextBox class="form-control" ID="acpname" runat="server" BackColor="White" 
                                            style="background-color: #FFFFFF"  Width="159px"></asp:TextBox>
                                    </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px;">
                                       
                                        Designation:</td>
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        <asp:DropDownList class="form-control" ID="acpdeg" runat="server"  Width="163px">
                                        </asp:DropDownList>
                                    </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                         District:</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        <%--<asp:TextBox ID="acpdistrict" runat="server" Height="22px" Width="159px"></asp:TextBox>--%>
                                        <asp:DropDownList class="form-control" ID="acpdistrict" runat="server" Width="163px">
                                        </asp:DropDownList>
                                    </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        Place of Posting</td>
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        <asp:TextBox class="form-control" ID="acpposting" runat="server" Width="159px"></asp:TextBox>
                                    </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        &nbsp;</td>
                                </tr>
                                
                                <tr>
                                
                                <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;"></td>
                                <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;"> Remark :</td>
                                <td align="left" style="width: 25%; height: 25px;background-color: #fffbd6;">
                                        <asp:TextBox class="form-control" ID="acpremark" runat="server" Width="475px" 
                                            style="background-color: #FFFFFF" ></asp:TextBox>
                                    </td>
                                 <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;"></td>
                                </tr>
                               
                                <tr>

                                    <td align="left" style="width: 25%; height: 25px; ">
                                        </td>
                                    <td align="left" style="width: 25%; height: 25px;">
                                        Final Grade:</td>
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        <%--<asp:TextBox ID="fgrade" runat="server" Height="22px" Width="159px"></asp:TextBox>--%>
                                        <asp:DropDownList class="form-control" ID="acpgrade" runat="server"  Width="163px">
                                        </asp:DropDownList>
                                    </td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; " >
                                        </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #FFFFCC;">
                                        Awarded Date:</td>
                                    <td align="left" style="width: 25%; height: 25px; background-color: #FFFFCC;">
                                        <asp:DropDownList class="form-control" ID="acpdd" runat="server"  style="background-color: #FFFFFF" 
                                             Width="105px">
                                        
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
                                        <asp:DropDownList class="form-control" ID="acpmm" runat="server"  style="background-color: #FFFFFF" 
                                             Width="105px">
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
                                        <asp:DropDownList class="form-control" ID="acpyy" runat="server"  style="background-color: #FFFFFF" 
                                             Width="105px">
                                        <asp:ListItem>--Year--</asp:ListItem>
                                        <asp:ListItem>1990</asp:ListItem>
                                        <asp:ListItem>1991</asp:ListItem>
                                        <asp:ListItem>1992</asp:ListItem>
                                        <asp:ListItem>1993</asp:ListItem>
                                        <asp:ListItem>1994</asp:ListItem>
                                        <asp:ListItem>1995</asp:ListItem>
                                        <asp:ListItem>1996</asp:ListItem>
                                        <asp:ListItem>1997</asp:ListItem>
                                        <asp:ListItem>1998</asp:ListItem>
                                        <asp:ListItem>1999</asp:ListItem>
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


                                    
                                    <td align="left" style="width: 25%; height: 25px; background-color: #fffbd6;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; height: 25px; ">
                                        &nbsp;</td>
                                    <td align="left" style="height: 25px; background-color: #C89704;" colspan="2">
                                        &nbsp;</td>


                                    
                                    <td align="left" style="width: 25%; height: 25px; " >
                                    <%--<asp:Button ID="FSheet" runat="server" OnClick="FSheet_Click" Text="Fact Sheet"
                            Width="96px" Font-Size="X-Small" />--%></td>
                                </tr>
                            </table>
                        </div>
                        </td>
                        </tr>
                   

                <tr>
                    <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; 
                        text-align: center">
                        <asp:Button class="btn btn-success" ID="SAVE" runat="server" Text="Save" OnClick="SAVE_Click" 
                            style="margin-bottom: 0px" Width="74px" /><asp:Label ID="mesg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 12px; color: #ffffff; text-align: left">
                        <asp:GridView class="form-control" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                            DataKeyNames="fy2" Height="50%" Width="100%" 
                            onselectedindexchanged="Page_Load" style="text-align: center" >
                            
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="Maroon" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="idno" HeaderText="Idno" SortExpression="fy1"    />
                                 <asp:BoundField DataField="fy1" HeaderText=" Financial " SortExpression="fy1" />
                                <asp:BoundField DataField="fy2" HeaderText=" Year " SortExpression="fy2" />
                               <asp:BoundField DataField="initiatename" HeaderText="Initiate Officer " SortExpression="initiatename" />
                                 <asp:BoundField DataField="initiatedeg" HeaderText=" Designation " SortExpression="initiatedeg" />
                                <asp:BoundField DataField="initiategrade" HeaderText=" Grade " SortExpression="grade" />
                                <asp:BoundField DataField="rviewname" HeaderText="Review Officer " SortExpression="rviewname" />
                                 <asp:BoundField DataField="rviewdeg" HeaderText=" Officer Designation " SortExpression="rviewdeg" />
                                <asp:BoundField DataField="grade" HeaderText=" Grade " SortExpression="grade" />
                                <asp:BoundField DataField="acpname" HeaderText="Accepting Officer " SortExpression="acpname" />
                                <asp:BoundField DataField="acpdeg" HeaderText=" Officer Designation " SortExpression="acpwdeg" />
                                <asp:BoundField DataField="fgrade" HeaderText="Final Grade " SortExpression="fgrade" />
                               
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>

                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
                            SelectCommand="SELECT sno,idno,fy1,fy2,initiatename,initiatedeg,initiategrade,rviewname,rviewdeg,rviewdate,rviewremark,grade,acpname,acpdeg,acpdate,fgrade,acpremark  FROM detailACR WHERE (idno = @idno)" DeleteCommand="delete from detailACR WHERE (fy2 = @fy2)">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:ControlParameter ControlID="Gridview1" Name="fy2" PropertyName="SelectedValue"  />
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
       
  

    </div>
</asp:Content>
