<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="SuperDevStore.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row justify-content-center">
        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-12">
            <img src="img/products/<% Response.Write(SuperDevStore.Product.Find(int.Parse(Request["id"])).Images()[0].image); %>" id="mainPicture" style="width: inherit;">
            <div class="row" style="margin-top: 10px;">
                <% foreach (SuperDevStore.ProductImage image in SuperDevStore.Product.Find(int.Parse(Request["id"])).Images()) { %>
                    <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 col-4">
                        <img src="img/products/<% Response.Write(image.image); %>" onclick="changePicture('<% Response.Write(image.image); %>');" style="width: inherit; cursor: pointer;">
                    </div>    
                <% } %>
            </div>
        </div>
        <div class="col-xl-8 col-lg-8 col-md-8 col-sm-12 col-12">
            <h3 runat="server" id="productName"></h3>
            <h5 runat="server" id="productPrice"></h5>
            <small runat="server" id="productAvailable"></small>
            <br/>
            <a class="btn btn-primary btn-sm" href="AddToCart.aspx?id=<% Response.Write(SuperDevStore.Product.Find(int.Parse(Request["id"])).id); %>&url=<% Response.Write(HttpContext.Current.Request.Url); %>" style="margin-top: 25px;"><i class="fas fa-cart-plus"></i> Add To Cart</a>
        </div>
    </div>
    <p runat="server" id="productDescriprion" style="margin-top: 50px;"></p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="modals" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script type="text/javascript">
        function changePicture(image) {
            document.getElementById('mainPicture').src = 'img/products/' + image;
        }
    </script>
</asp:Content>
