<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="SuperDevStore.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <h2><% Response.Write(SuperDevStore.UserAuth.Instance.User().name); %></h2>

    <h4 style="margin-top: 50px;">Your Pending Orders</h4>
    <% if (SuperDevStore.UserAuth.Instance.User().PendingOrders().Count > 0) { %>
        <div class="table-responsive">
            <asp:GridView runat="server" ID="gvPendingOrders" CssClass="table table-striped table-sm" GridLines="None" AllowPaging="true"></asp:GridView>
        </div>
    <% } else { %>
        <div class="alert alert-primary" style="margin-top: 25px;">
            You don't have any pending orders!
        </div>
    <% } %>

    <h4 style="margin-top: 50px;">Your Finished Orders</h4>
    <% if (SuperDevStore.UserAuth.Instance.User().FinishedOrders().Count > 0) { %>
        <div class="table-responsive">
            <asp:GridView runat="server" ID="gvFinishedOrders" CssClass="table table-striped table-sm" GridLines="None" AllowPaging="true"></asp:GridView>
        </div>
    <% } else { %>
        <div class="alert alert-primary" style="margin-top: 25px;">
            You don't have any finished orders!
        </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
