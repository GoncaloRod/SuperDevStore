﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminApp.Master" AutoEventWireup="true" CodeBehind="AdminProducts.aspx.cs" Inherits="SuperDevStore.AdminProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>Products</h2>

    <a class="btn btn-primary btn-sm" href="AdminCreateProduct.aspx"><i class="fas fa-plus"></i> New</a>

    <div class="table-responsive">
        <asp:GridView runat="server" ID="gvProducts" CssClass="table table-striped table-sm" GridLines="None" AllowSorting="true"></asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
