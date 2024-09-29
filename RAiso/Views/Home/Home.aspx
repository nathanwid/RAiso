<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RAiso.Views.Home.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container pt-5">
        <div class="row">
            <asp:Repeater ID="RptStationery" runat="server" OnItemCommand="RptStationery_ItemCommand">
                <itemtemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("StationeryName") %></h5>
                                <p class="card-text">Price: <%# Eval("StationeryPrice") %></p>
                                <asp:LinkButton ID="BtnDetail" runat="server" CssClass="btn btn-primary" CommandName="ViewDetails" CommandArgument='<%# Eval("StationeryID") %>'>View Details</asp:LinkButton>
                                <asp:LinkButton ID="BtnEdit" runat="server" CssClass="btn btn-warning" CommandName="Edit" CommandArgument='<%# Eval("StationeryID") %>'>Edit</asp:LinkButton>
                                <asp:LinkButton ID="BtnDelete" runat="server" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%# Eval("StationeryID") %>'>Delete</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </itemtemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="container">
        <asp:Button ID="BtnInsert" CssClass="btn btn-primary" runat="server" Text="Insert Stationery" OnClick="BtnInsert_Click" />
    </div>
</asp:Content>
