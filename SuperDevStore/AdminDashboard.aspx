<%@ Page Title="" Language="C#" MasterPageFile="~/AdminApp.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="SuperDevStore.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row justify-content-around">
        <!-- Pending orders number -->
        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-12" style="padding: 10px;">
            <div class="card text-white bg-success mb-3">
                <div class="card-header">Pending Orders</div>
                <div class="card-body">
                    <h2 class="card-title"><% Response.Write(SuperDevStore.Order.PendingOrders().Count); %> Pending Orders</h2>
                    <a class="float-right" href="AdminOrders.aspx" style="color: white;">Read More</a>
                </div>
            </div>
        </div>
        <!-- Low stock products -->
        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-12" style="padding: 10px;">
            <div class="card text-white bg-danger mb-3">
                <div class="card-header">Low Stock Products</div>
                <div class="card-body">
                    <h2 class="card-title"><% Response.Write(SuperDevStore.Product.LowStock().Count); %> Low Stock Products</h2>
                    <a class="float-right" href="AdminLowStockProducts.aspx" style="color: white;">Read More</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
