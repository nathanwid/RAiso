<%@ Page Title="Transaction | RAiso" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="RAiso.Views.Home.TransactionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-md-5 mt-5">
        <div class="card">
            <div class="card-header">
                <h3>Transaction(s)</h3>
            </div>
            <div class="card-body">
                <%if (transactions.Any())
                  {%>
                    <table class="table table-striped" border="1">
                        <tr>
                            <th>ID</th>
                            <th>Date</th>
                            <th>User ID</th>
                            <th>Grand Total</th>
                            <th>Action</th>
                        </tr>

                        <%foreach (var details in transactions)
                        {%>
                        <tr>
                            <td><%= details.TransactionID %></td>
                            <td><%= details.TransactionDate %></td>
                            <td><%= details.UserID %></td>
                            <td>Rp<%= details.TransactionDetails.Sum(x => x.MsStationery.StationeryPrice * x.Quantity) %></td>
                            <td><% string url = String.Format("TransactionDetails.aspx?Id={0}", details.TransactionID); %>
                                <a href="<%= url %>">Details</a>
                            </td>
                        </tr>
                        <%}%>
                    </table>
                <%}%>
                <%else
                  {%>
                    <h5>Customer(s) haven't done any transaction(s)</h5>
                <%}%>
            </div>
        </div>
    </div>
</asp:Content>
