<%@ Page Title="" Language="C#" MasterPageFile="~/healthPIS/healthPis.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NewWebApp.healthPIS.login" %>
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
            <div class="offset-4" ></div>

                <div class="col-sm-4 col-centered">
                <ul class="breadcrumb">
<li class="breadcrumb-item"><a href="../Website/index.aspx" title="Home">Home</a></li>
<li class="breadcrumb-item">Login</li>
</ul>
                    <div class="panel panel-default">
                        <div class="panel-heading" >
                            <h2>Login</h2>
                        </div>
                    <form action="" method="POST">
                    <div class="panel-body">
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression='^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,10}' SetFocusOnError="True" ControlToValidate="pass_wd" ErrorMessage="*Password Must Contain Alphanumeric Characters Including special Symbol" CssClass="btn-danger" Font-Size="X-Small"></asp:RegularExpressionValidator>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user blue"></i></span>
                                <asp:TextBox ID="email" runat="server" type="email" name="InputName" placeholder="Email" class="form-control" autofocus="autofocus" required></asp:TextBox>
                               
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">

                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock blue"></i></span>
                                <asp:TextBox ID="pass_wd" runat="server" type="Password" name="InputPassword" placeholder="" class="form-control" autofocus="autofocus" required CausesValidation="False"></asp:TextBox>
                               
                               
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-phone blue"></i></span>
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Captcha Verify" class="form-control"></asp:TextBox>
                               
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Image ID="Image1" runat="server" Height="55px" ImageUrl="../Authenticate/Captcha.aspx" Width="186px" /> 
                            </div>
                        </div>
                       
                                             
                        <div class="">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Login"  class="btn btn-info pull-right" onclick="Button1_Click"/> <span class="glyphicon glyphicon-send"></span>
                            <button type="reset" value="Reset" name="reset" class="btn">Reset <span class="glyphicon glyphicon-refresh"></span></button>
                            
                        </div>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="forgotPassword.aspx" title="Forgot Password">Forgot Password ?</a>
                    </div>
                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="True"></asp:Label>
                    </form>
                </div>
            </div>
            <div class="offset-4" ></div>
        </div>
    </div>

</asp:Content>
