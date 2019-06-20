<%@ Page Title="::Login Page::" Language="C#" MasterPageFile="~/Authenticate/authenticate.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NewWebApp.Authenticate.login" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register Src="~/ltop.ascx" TagName="ltop" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
@media screen and (max-width:768px) {
.container {
    max-width:100%;
    width:100%;
    float:left;
    margin:0;
}
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
            <div class="row">
            <div class="col-sm-8" >
            <div class="row">
           

<div class="col-sm-6">
<a id="A9" runat="server" href="" title="doctor's posting list" style="text-decoration:none; color:White;" onserverclick="Red1">
<div class="card bg-primary" >
<div class="card card-header bg-primary">
<h5><b><center>Posting List</center></b></h5>
</div>
<div class="card card-body bg-info">
   Number Of Doctor's : <asp:Label ID="Doct" runat="server" Text="Label" Font-Size="X-Large" ForeColor="Red" Font-Italic="True"></asp:Label>

   Number Of Paramedical Staff : <asp:Label ID="Pmd" runat="server" Text="Label" Font-Size="X-Large" ForeColor="Red" Font-Italic="True"></asp:Label>

</div>
</div>
</a>
</div>

<div class="col-sm-6">
<a id="A1" href="" runat="server" title="Doctor's Fact Sheet" style="text-decoration:none; color:White;" onserverclick="Red2">
<div class="card bg-primary" >
<div class="card card-header bg-primary">
<h5><b><center>Fact Sheet/P2</center></b></h5>
</div>
<div class="card card-body bg-info"> 
 Number of Hospitals :   <asp:Label ID="hsname" runat="server" Text="Label" Font-Size="X-Large" ForeColor="Red" Font-Italic="True"></asp:Label>
</div>
</div>
</a>
</div>
<div class="col-sm-12">&nbsp;</div>
<div class="col-sm-6">
<a id="A2" href="" runat="server" title="doctor's posting list" style="text-decoration:none; color:White;" onserverclick="Red6">
<div class="card bg-primary" >
<div class="card card-header bg-primary">
<h5><b><center>Salary Ledger</center></b></h5>
</div>
<div class="card card-body bg-info">
 
</div>
</div>
</a>
</div>
<div class="col-sm-6">
<a id="A4" href="" runat="server" title="doctor's posting list" style="text-decoration:none; color:White;" onserverclick="Red4">
<div class="card bg-primary" >
<div class="card card-header bg-primary">
<h5><center><b>Staff Fact Sheet/P2</b></center></h5>
</div>
<div class="card card-body bg-info">
 
</div>
</div>
</a>
</div>

<div class="col-sm-12">&nbsp;</div>




<div class="col-sm-8">&nbsp;</div>



</div>
           
            
            
            
            
            
            </div>
           
                            <div class="col-sm-3 col-centered" style="border-style:solid; border-color:red; padding:4px; width:300px; height:430px;">
                <ul class="breadcrumb" style="width:260px;">
<li class="breadcrumb-item"><a href="../Website/index.aspx" title="Home">Home</a></li>
<li class="breadcrumb-item">Login</li>
</ul>

                    <div class="panel panel-default" style="width:260px;" >
                        <div class="panel-heading" >
                            <h5>Login</h5>
                        </div>
                    <form autocomplete="off" action="" method="POST">
                    <div class="panel-body">
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression='^(?=.*[a-z])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,10}' SetFocusOnError="True" ControlToValidate="pass_wd" ErrorMessage="*Password Must Contain Alphanumeric Characters Including special Symbol" CssClass="btn-danger" Font-Size="X-Small"></asp:RegularExpressionValidator>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user blue"></i></span>
                                <asp:TextBox ID="email" runat="server" type="email/userid" name="InputName" placeholder="Email/UserId" class="form-control" autocomplete="false" autofocus="autofocus"></asp:TextBox>
                               
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">

                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox ID="pass_wd" runat="server" type="password" name="password" 
                                    placeholder="" class="form-control" autofocus="autofocus" required 
                                    CausesValidation="False" TextMode="Password" ></asp:TextBox>
                               
                               
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Image ID="Image1" runat="server" Height="55px" ImageUrl="../Authenticate/Captcha.aspx" Width="186px" /> 
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-phone blue"></i></span>
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Captcha Verify" 
                                    class="form-control"></asp:TextBox>
                               
                            </div>
                        </div>
                        
                       
                                             
                        <div class="">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-success" 
                                onclick="Button1_Click" />
                        <asp:LinkButton ID="LinkButton1" runat="server" type="Reset" name="Reset" 
                                Text="Submit" class="btn btn-secondary btn-search" onclick="LinkButton1_Click">Reset<span aria-hidden="true" class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                           
                            
                        </div>
                        <br />
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="forgotPassword.aspx" title="Forgot Password">Forgot Password ?</a>
                    </div>
                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="True"></asp:Label>
                   <b>Your IP Address Is :-</b> <asp:Label ID="Label1" runat="server" Text="Label" Visible="True" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                    
                    </form>
                </div>
               
            </div>
            
        </div>
    </div>

   



</asp:Content>
