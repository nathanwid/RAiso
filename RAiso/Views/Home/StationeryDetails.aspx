<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="StationeryDetails.aspx.cs" Inherits="RAiso.Views.Home.StationeryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mx-auto mt-5" style="width: 350px;">
        <div class="card-body">
            <div class="col">
                <h3 class="card-title text-center">Stationery Details</h3>
            </div>
            <hr />
            <div class="row">
                <div class="col">
                    <h5 class="card-title">Name</h5>
                    <p class="card-text">
                        <asp:Label ID="StationeryName" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div class="col">
                    <h5 class="card-title">Price</h5>
                    <p class="card-text">
                        Rp<asp:Label ID="StationeryPrice" runat="server" Text=""></asp:Label>
                    </p>
                </div>
            </div>

            <% if (Session["user"] != null) { 
                var user = (RAiso.Model.MsUser)Session["user"];
                if (user.UserRole == "Customer") { %>
                    <div class="col my-2">
                        <asp:TextBox ID="TBQuantity" class="form-control" placeholder="Quantity" runat="server"></asp:TextBox>
                    </div>
                    <div class="col my-2">
                        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col">
                        <asp:Button ID="BtnAddtoCart" runat="server" Text="Add to Cart" OnClick="BtnAddtoCart_Click" CssClass="btn btn-primary" />
                    </div>
            <% } } %>
        </div>
    </div>
</asp:Content>
