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
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">
            <!-- Shipping Method -->
            <div class="form-group">
                <label for="ddShippingMethod">Shipping Method</label>
                <asp:DropDownList ID="ddShippingMethod" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
    </div>
    
    <asp:Button CssClass="btn btn-sm btn-primary float-right" ID="btnConfirm" Text="Confirm" runat="server" OnClick="btnConfirm_Click"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
