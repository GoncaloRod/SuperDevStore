<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="SuperDevStore.ShoppingCart1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>Shopping Cart</h2>
    
    <% if (SuperDevStore.ShoppingCart.Instance.Products.Count > 0)
        { %>
        <div class="table-responsive" style="margin-top: 25px;">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th></th>
                        <th>Product</th>
                        <th>Stock</th>
                        <th>Total Price</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < SuperDevStore.ShoppingCart.Instance.Products.Count(); i++)
                        {
                            SuperDevStore.Product product = SuperDevStore.ShoppingCart.Instance.Products[i]; %>
                        <tr>
                            <td style="width: 1px;"><img src="img/products/<% Response.Write(product.Images()[0].image); %>" style="height: 50px;"></td>
                            <td class="align-middle"><% Response.Write(product.name); %></td>
                            <td class="align-middle"><% Response.Write(product.stock); %></td>
                            <td class="align-middle"><% Response.Write(string.Format("{0:C}", product.price)); %></td>
                            <td class="align-middle"><a class="btn btn-danger" href="RemoveFromCart.aspx?index=<% Response.Write(i); %>"><i class="fas fa-trash"></i></a></td>
                        </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
        
        <a class="btn btn-primary btn-sm float-right" href="Checkout.aspx"><i class="fas fa-credit-card"></i> Checkout</a>
    <% } else { %>
        <div class="alert alert-primary" style="margin-top: 25px;">
            Shopping Cart is empty!
        </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
