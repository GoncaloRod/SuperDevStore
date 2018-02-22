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

    <div class="row">
        <% foreach (SuperDevStore.ProductImage image in SuperDevStore.Product.Find(int.Parse(Request["id"])).Images()) { %>
            <div class="col-xl-3 col-lg-3 col-md-3 col-sm-12 col-12">
                <img src="img/products/<% Response.Write(image.image); %>" style="width: inherit;">
            </div>
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
