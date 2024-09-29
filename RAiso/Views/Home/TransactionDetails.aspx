<%@ Page Title="Transaction | RAiso" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="RAiso.Views.Home.TransactionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-md-5 mt-5">
        <div class="card">
            <div class="card-header">
                <h3>Transaction Details</h3>
            </div>
            <div class="card-body">
                <table class="table table-striped" border="1">
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                        <th>Quantity</th>
                        <th>Subtotal</th>
                    </tr>

                  <%foreach (var det in transaction.TransactionDetails)
                    {%>
                    <tr>
                        <td><%= det.MsStationery.StationeryName %></td>
                        <td>Rp<%= det.MsStationery.StationeryPrice %></td>
                        <td><%= det.Quantity %></td>
                        <td>Rp<%= det.Quantity * det.MsStationery.StationeryPrice %></td>
                    </tr>
                  <%}%>

                    <tr>
                        <td colspan="3">Total</td>
                        <td colspan="3">Rp<%= transaction.TransactionDetails.Sum(detail => detail.MsStationery.StationeryPrice * detail.Quantity) %></td>
                    </tr>
                </table>

                <asp:Button ID="BackToHistory" runat="server" Text="Back" OnClick="BackToHistory_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
