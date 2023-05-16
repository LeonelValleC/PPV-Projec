<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PPV_Projec.Login" Title="Login" %>

<!DOCTYPE html>

<webopt:BundleReference runat="server" Path="~/Content/css" />

<style type="text/css">
    input {
        max-width: 100%;
    }

    body {
        background-image: url('Images/photo-1.jpg');
        background-repeat: round;
        background-attachment: fixed;
        background-size: cover;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <br />
        <br />
        <br />

        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <%--<h3 class="panel-title">Ingrese sus datos</h3>--%>
                            <h3 class="panel-title">Sign in</h3>
                        </div>
                        <div style="text-align: center;">
                            <br />
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo2.png" />
                        </div>
                        <br />
                        <div class="panel-body">
                            <fieldset>
                                <div class="form-group">
                                    <input class="form-control" placeholder="User Name" name="usuario" type="text" autofocus id="txtUsuario" runat="server">
                                </div>
                                <div class="form-group">
                                    <input class="form-control" placeholder="Password" name="password" type="password" id="txtPassword" runat="server">
                                </div>
                                <!-- Change this to a button or input when using this as a form -->
                                <%--<button id="btnIngresar" class="btn btn-lg btn-success btn-block">Login</button>--%>
                                <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-lg btn-success btn-block" OnClick="btnIngresar_Click" />
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
