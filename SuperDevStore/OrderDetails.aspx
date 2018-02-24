<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="SuperDevStore.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>Order Details</h2>

    <ul>
        <li runat="server" id="shippingAddress">Shipping Address: </li>
        <li runat="server" id="shippingMethod">Shipping Method: </li>
        <li runat="server" id="orderedAt">Ordered At: </li>
        <li runat="server" id="state">Order Stated: </li>
    </ul>

    <h4 style="margin-top: 50px;">Products</h4>
    <div class="table-responsive">
        <asp:GridView runat="server" ID="gvDatails" CssClass="table table-striped table-sm" GridLines="None" AllowPaging="true"></asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
