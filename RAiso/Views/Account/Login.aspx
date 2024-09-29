<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Account/AccountMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RAiso.Views.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card login-container">
                    <div class="card-body">
                        <h3 class="card-title text-center">Login</h3>
                        <hr />
                        <div class="mb-3">
                            <asp:Label ID="LblUsername" runat="server" CssClass="label">Username</asp:Label>
                            <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="LblPassword" runat="server" CssClass="label" >Password</asp:Label>
                            <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>

                        <div class="mb-3 form-check">
                            <asp:CheckBox ID="CBRememberMe" runat="server" CssClass="form-check-input" />
                            <asp:Label ID="LblRememberMe" for="CBRememberMe" runat="server" CssClass="form-check-label">Remember Me</asp:Label>
                        </div>

                        <div class="mb-3 text-danger">
                            <asp:Label ID="LblError" runat="server" CssClass="error" Text=""></asp:Label>
                        </div>

                        <div class="mb-3">
                            <asp:Button ID="BtnSubmit" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="BtnSubmit_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
