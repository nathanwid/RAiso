<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="InsertStationery.aspx.cs" Inherits="RAiso.Views.Home.InsertStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-md-3 mt-5">
        <div class="form-container">
            <div class="row justify-content-center">
                <div class="card card-body">
                    <h3 class="card-title text-center">Insert Stationery</h3>
                    <hr />
                    <div class="mb-3">
                        <asp:Label ID="LblName" runat="server" CssClass="form-label" Text="Name"></asp:Label>
                        <asp:TextBox ID="TBName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="LblPrice" runat="server" CssClass="form-label" Text="Price"></asp:Label>
                        <asp:TextBox ID="TBPrice" runat="server" CssClass="form-control" placeholder="Price"></asp:TextBox>
                    </div>

                    <div class="mb-2">
                        <asp:Label ID="LblError" runat="server" Text="" CssClass="error"></asp:Label>
                    </div>

                    <asp:Button ID="BtnInsertStationery" runat="server" Text="Insert" OnClick="BtnInsertStationery_Click" CssClass="btn btn-primary mb-2" />

                    <h2>Stationery List</h2>
                    <asp:GridView ID="GVStationery" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="StationeryID" HeaderText="ID" SortExpression="StationeryID"></asp:BoundField>
                            <asp:BoundField DataField="StationeryName" HeaderText="Name" SortExpression="StationeryName"></asp:BoundField>
                            <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="StationeryPrice"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <asp:Button ID="BacktoHome" runat="server" Text="Back to Home" OnClick="BacktoHome_Click" CssClass="btn btn-primary"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
