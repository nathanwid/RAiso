<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateStationery.aspx.cs" Inherits="RAiso.Views.Home.UpdateStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-md-3 mt-5">
        <div class="form-container">
            <div class="row justify-content-center">
                <div class="card card-body">
                    <h3 class="card-title text-center">Update Stationery</h3>
                    <hr />
                    <div class="mb-3">
                        <asp:Label ID="LblStationeryName" runat="server" CssClass="form-label" Text="Name"></asp:Label>
                        <asp:TextBox ID="TBStationeryName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="LblStationeryPrice" runat="server" CssClass="form-label" Text="Price"></asp:Label>
                        <asp:TextBox ID="TBPrice" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-2">
                        <asp:Label ID="LblError" runat="server" Text="" CssClass="error"></asp:Label>
                    </div>

                    <asp:Button ID="UpdateStationeryBtn" runat="server" Text="Update" OnClick="UpdateStationeryBtn_Click" CssClass="btn btn-primary mb-2" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
