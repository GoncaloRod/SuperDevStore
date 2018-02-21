<%@ Page Title="" Language="C#" MasterPageFile="~/AdminApp.Master" AutoEventWireup="true" CodeBehind="AdminEditProduct.aspx.cs" Inherits="SuperDevStore.AdminEditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>Edit Product</h2>

    <!-- Name -->
    <div class="form-group" runat="server">
        <label for="txtName">Name</label>
        <asp:TextBox CssClass="form-control" ID="txtName" placeholder="Name" runat="server"></asp:TextBox>
    </div>

    <!-- Price -->
    <div class="form-group" runat="server">
        <label for="txtPrice">Price</label>
        <asp:TextBox CssClass="form-control" ID="txtPrice" placeholder="Price" runat="server"></asp:TextBox>
    </div>

    <!-- Description -->
    <div class="form-group" runat="server">
        <label for="txtName">Description</label>
        <asp:TextBox CssClass="form-control" ID="txtDescription" placeholder="Description" runat="server"></asp:TextBox>
    </div>

    <!-- Stock -->
    <div class="form-group" runat="server">
        <label for="txtStock">Stock</label>
        <asp:TextBox CssClass="form-control" ID="txtStock" placeholder="Stock" runat="server"></asp:TextBox>
    </div>

    <asp:Button CssClass="btn btn-sm btn-primary float-right" ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
