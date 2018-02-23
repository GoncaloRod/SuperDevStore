<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="SuperDevStore.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>super dev; store admin</title>

        <!-- Google ReCaptcha -->
        <script src='https://www.google.com/recaptcha/api.js'></script>
        <!-- Bootstrap 4 -->
        <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css">
        <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.4.min.js"></script>
        <script>window.jQuery || document.write('<script src="/js/jquery-1.12.4.min.js">\x3C/script>')</script>
        <script src="js/bootstrap.min.js"></script>
        <!-- Font Awsome -->
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.6/css/all.css">
        <!-- Custom Style -->
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
        <form runat="server">
            <!-- Alerts -->
            <div id="alertsContainer" runat="server" style="width: 50%; margin-left: 25%;">
                <% foreach (var message in SuperDevStore.Alerts.successMessages) { %>
                    <div class="alert alert-success alert-dismissable fade show" style="position: absolute; width: inherit; margin-top: 5px; z-index: 2000;">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <% Response.Write(message); %>
                    </div>
                <% } %>

                <% foreach (var message in SuperDevStore.Alerts.errorMessages) { %>
                    <div class="alert alert-danger alert-dismissable fade show" style="position: absolute; width: inherit; margin-top: 5px; z-index: 2000;">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <% Response.Write(message); %>
                    </div>
                <% } SuperDevStore.Alerts.ClearMessages(); %>
            </div>

            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-xl-4 col-lg-4 col-md-4 col-sm-11 col-11">
                        <div class="text-center"><h1>Admin Login</h1></div>
                        
                        <!-- Email -->
                        <div class="form-group" runat="server">
                            <label for="txtEmailLogin">Email</label>
                            <asp:TextBox CssClass="form-control" TextMode="Email" ID="txtEmailLogin" placeholder="Email" runat="server"></asp:TextBox>
                        </div>
                        <!-- Password -->
                        <div class="form-group" runat="server">
                            <label for="txtPasswordLogin">Password</label>
                            <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtPasswordLogin" placeholder="Password" runat="server"></asp:TextBox>
                        </div>

                        <asp:Button CssClass="btn btn-sm btn-primary float-right" ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click"/>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>
