<%@ Page Title="Cart | RAiso" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateCart.aspx.cs" Inherits="RAiso.Views.Home.UpdateCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-md-3 mt-5">
        <div class="form-container">
            <div class="row justify-content-center">
                <div class="card card-body">
                    <h3 class="card-title text-center">Update Cart</h3>
                    <hr />
                    <div class="mb-3">
                        <asp:Label ID="LblStationeryName" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="TBStationeryName" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="LblQuantity" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="TBQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-2">
                        <asp:Label ID="LblError" runat="server" Text="" CssClass="error"></asp:Label>
                    </div>

                    <div>
                        <asp:Button ID="BtnUpdate" OnClick="BtnUpdate_Click" runat="server" Text="Update" CssClass="btn btn-primary mb-2" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
