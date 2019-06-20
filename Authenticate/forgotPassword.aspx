<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticate/authenticate.Master" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="NewWebApp.Authenticate.forgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JsFile/formlogin.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
            <div class="row">
            <div class="offset-4" ></div>

                <div class="col-sm-4 col-centered">
                <ul class="breadcrumb">
<li class="breadcrumb-item"><a href="/login.aspx" title="Home">Home</a></li>
<li class="breadcrumb-item"><a href="../Authenticate/login.aspx" title="Home">Login</a></li>
<li class="breadcrumb-item">Forgot Password</li>
</ul>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2>Forgot Password</h2>
                        </div>
                    <form action="" method="POST" id="form1">
                    <div class="panel-body">
                     
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="TextBox2" ControlToCompare="email" CssClass="btn-danger" Font-Size="X-Small"></asp:CompareValidator>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user blue"></i></span>
                                <asp:TextBox ID="email" runat="server" type="email" name="InputName" placeholder="Email" class="form-control" autofocus="autofocus" required></asp:TextBox>
                               
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user blue"></i></span>
                                <asp:TextBox ID="TextBox2" runat="server" type="password" name="InputName" placeholder="Confirm Email" class="form-control" autofocus="autofocus" required></asp:TextBox>
                               
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
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Captcha Verify" class="form-control"></asp:TextBox>
                               
                            </div>
                        </div>
                       
                                             
                        <div class="">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Reset"  class="btn btn-info pull-right" Onclick="Button1_Click"/> <span class="glyphicon glyphicon-send"></span>
                            <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green"></asp:Label>
                        </div>
                      </div>
                   
                    </form>
                </div>
            </div>
            <div class="offset-4" ></div>
        </div>
    </div>

</asp:Content>
