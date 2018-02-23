<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="SuperDevStore.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>Checkout</h2>
    <div class="row">
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">
            <!-- Shipping Address -->
            <div class="form-group" runat="server">
                <label for="txtShippingAddress">Shipping Address</label>
                <asp:TextBox CssClass="form-control" ID="txtShippingAddress" placeholder="Shipping Address" runat="server"></asp:TextBox>
            </div>
            <!-- Shipping Method -->
            <% foreach (SuperDevStore.ShippingMethod method in SuperDevStore.ShippingMethod.AllActive()) { %>
            
            <% } %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
