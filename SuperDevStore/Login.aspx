<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SuperDevStore.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row justify-content-around">
        <!-- Login -->
        <div class="col-xl-5 col-lg-5 col-md-5 col-sm-12 col-12">
            <h2 class="text-center">Login</h2>

            <!-- Email -->
            <div class="form-group" runat="server">
                <label for="txtEmailLoginForm">Email</label>
                <asp:TextBox CssClass="form-control" TextMode="Email" ID="txtEmailLoginForm" placeholder="Email" runat="server"></asp:TextBox>
            </div>
            <!-- Password -->
            <div class="form-group" runat="server">
                <label for="txtPasswordLoginForm">Password</label>
                <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtPasswordLoginForm" placeholder="Password" runat="server"></asp:TextBox>
            </div>

            <asp:Button CssClass="btn btn-sm btn-primary float-right" ID="btnLoginForm" Text="Login" runat="server" OnClick="btnLoginForm_Click"/>
        </div>
        <!-- Register -->
        <div class="col-xl-5 col-lg-5 col-md-5 col-sm-12 col-12">
            <h2 class="text-center">Register</h2>
            <!-- Name -->
            <div class="form-group" runat="server">
                <label for="txtNameRegisterForm">Name</label>
                <asp:TextBox CssClass="form-control" ID="txtNameRegisterForm" placeholder="Name" runat="server"></asp:TextBox>
            </div>
            <!-- Email -->
            <div class="form-group" runat="server">
                <label for="txtEmailRegisterForm">Email</label>
                <asp:TextBox CssClass="form-control" TextMode="Email" ID="txtEmailRegisterForm" placeholder="Email" runat="server"></asp:TextBox>
                <small class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <!-- Password -->
            <div class="form-group" runat="server">
                <label for="txtPasswordRegisterForm">Password</label>
                <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtPasswordRegisterForm" placeholder="Password" runat="server"></asp:TextBox>
            </div>
            <!-- Retry Password -->
            <div class="form-group" runat="server">
                <label for="txtRetryPasswordRegisterForm">Retry Password</label>
                <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtRetryPasswordRegisterForm" placeholder="Retry Password" runat="server"></asp:TextBox>
            </div>
            <!-- Google ReCaptcha -->
            <!--<div class="g-recaptcha" data-sitekey="6LcpEUcUAAAAAD32EEoYWMc03gllJsa6uHBE-IsO"></div>-->

            <asp:Button CssClass="btn btn-sm btn-primary float-right" ID="btnRegisterForm" Text="Register" runat="server" OnClick="btnRegisterForm_Click"/>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
