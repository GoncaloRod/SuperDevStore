<%@ Page Title="" Language="C#" MasterPageFile="~/AdminApp.Master" AutoEventWireup="true" CodeBehind="AdminProductDetails.aspx.cs" Inherits="SuperDevStore.AdminProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>Product Details</h2>

    <a class="btn btn-primary btn-sm" href="AdminEditProduct.aspx?id=<% Response.Write(Request["id"].ToString()); %>"><i class="fas fa-pencil-alt"></i> Edit</a>

    <ul>
        <li runat="server" id="productName">Name: </li>
        <li runat="server" id="productPrice">Price: </li>
        <li runat="server" id="productDescription">Description: </li>
        <li runat="server" id="productStock">Stock: </li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
