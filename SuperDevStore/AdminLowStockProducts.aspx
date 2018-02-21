<%@ Page Title="" Language="C#" MasterPageFile="~/AdminApp.Master" AutoEventWireup="true" CodeBehind="AdminLowStockProducts.aspx.cs" Inherits="SuperDevStore.AdminLowStockProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>Low Stock Products</h2>

    <div class="table-responsive">
        <asp:GridView runat="server" ID="gvProducts" CssClass="table table-striped table-sm" GridLines="None" AllowSorting="true"></asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
