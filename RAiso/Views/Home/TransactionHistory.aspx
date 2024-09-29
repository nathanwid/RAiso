<%@ Page Title="Transaction | RAiso" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="RAiso.Views.Home.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-md-5 mt-5">
        <div class="card">
            <div class="card-header">
                <h3>Your Transaction(s)</h3>
            </div>
            <div class="card-body">
                <%if (transactions.Any())
                  {%>
                    <asp:GridView ID="GVTransaction" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="TransactionID" HeaderText="ID" SortExpression="TransactionID"></asp:BoundField>
                            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate"></asp:BoundField>
                            <asp:BoundField DataField="MsUser.UserName" HeaderText="Customer" SortExpression="MsUser.UserName"></asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="TransactionID" DataNavigateUrlFormatString="TransactionDetails.aspx?Id={0}" Text="Details" HeaderText="Action"></asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                <%}%>
                <%else
                  {%>
                    <h5>You haven't done any transaction(s)</h5>
                <%}%>
            </div>
        </div>
    </div>
</asp:Content>
