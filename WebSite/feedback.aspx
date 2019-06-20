<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="NewWebApp.WebSite.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
            <div class="row">
            <div class="offset-3" ></div>

                <div class="col-sm-6 col-centered">
                <ul class="breadcrumb">
<li class="breadcrumb-item"><a href="index.aspx" title="Home">Home</a></li>
<li class="breadcrumb-item">Feedback</li>
</ul>
                    <div class="panel panel-default">
                        <div class="panel-heading" >
                            <h1>Feedback</h1>
                        </div>
                    <form action="" method="POST">
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user blue"></i></span>
                                <input type="text" name="InputName" placeholder="Name" class="form-control" autofocus="autofocus" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-envelope blue"></i></span>
                                <input type="email" name="InputEmail" placeholder="Email" class="form-control" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-phone blue"></i></span>
                                <input type="number" name="InputCno" placeholder="Phone" class="form-control" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-comment blue"></i></span>
                                <textarea name="InputMessage" rows="6" class="form-control" type="text" required></textarea>
                            </div>
                        </div>
                        <div class="">
                        <button type="submit" class="btn btn-info pull-right">Send <span class="glyphicon glyphicon-send"></span></button>
                            <button type="Reset" value="Reset" name="reset" class="btn"><span class="glyphicon glyphicon-refresh"></span></button>
                        </div>
                    </div>
                    </form>
                </div>
            </div>
            <div class="offset-3" ></div>
        </div>
    </div>
</asp:Content>
