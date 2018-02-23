<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="SuperDevStore.AllProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>All Products</h2>

    <div class="row">
        <% foreach (SuperDevStore.Product product in SuperDevStore.Product.AllActive()) { %>
            <div class="col-xl-3 col-lg-3 col-md-3 col-sm-12 col-12" style="margin-top: 20px;">
                <div class="card">
                    <img class="card-img-top" src="img/products/<% Response.Write(product.Images()[0].image); %>">
                    <div class="card-body">
                        <h5 class="card-title"><% Response.Write(product.name); %></h5>
                        <p class="card-text"><% Response.Write(string.Format("{0:C}", product.price)); %></p>
                        <a href="ProductDetails.aspx?id=<% Response.Write(product.id); %>">Read More</a>
                        <a class="btn btn-primary btn-sm float-right" href="AddToCart.aspx?id=<% Response.Write(product.id); %>&url=<% Response.Write(HttpContext.Current.Request.Url); %>"><i class="fas fa-cart-plus"></i> Add To Cart</a>
                    </div>
                </div>
            </div>
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
