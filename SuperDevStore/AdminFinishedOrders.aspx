<%@ Page Title="" Language="C#" MasterPageFile="~/AdminApp.Master" AutoEventWireup="true" CodeBehind="AdminFinishedOrders.aspx.cs" Inherits="SuperDevStore.AdminFinishedOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2>Finished Orders</h2>
    <div class="table-responsive">
        <asp:GridView runat="server" ID="gvOrders" CssClass="table table-striped table-sm" GridLines="None" AllowPaging="true"></asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
