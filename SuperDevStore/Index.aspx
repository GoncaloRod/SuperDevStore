<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SuperDevStore.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <%
        List<SuperDevStore.Product> products = SuperDevStore.Product.All();

        SuperDevStore.Product[] sugentions;

        if (products.Count > 4)
        {
            sugentions = new SuperDevStore.Product[4];

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                sugentions[i] = products[random.Next(0, products.Count - 1)];
                products.Remove(products[i]);
            }
        }
        else
        {
            sugentions = new SuperDevStore.Product[products.Count];

            for (int i = 0; i < products.Count; i++)
            {
                sugentions[i] = products[i];
            }
        }
    %>

    <h2>Sugestions</h2>
    <div class="row">
        <% foreach (SuperDevStore.Product product in sugentions) { %>
            <div class="col-xl-3 col-lg-3 col-md-3 col-sm-12 col-12" style="margin-top: 20px;">
                <div class="card">
                    <img class="card-img-top" src="img/products/<% Response.Write(product.Images()[0].image); %>">
                    <div class="card-body">
                        <h5 class="card-title"><% Response.Write(product.name); %></h5>
                        <p class="card-text"><% Response.Write(string.Format("{0:C}", product.price)); %></p>
                        <% if (product.stock > 4) { %>
                            <small style="color: green;">Available</small>
                        <% } else if (product.stock > 0 ) { %>
                            <small style="color: orange;">Few Units</small>
                        <% } else { %>
                            <small style="color: red;">Out of Stock</small>
                        <% } %>
                        <br/>
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
