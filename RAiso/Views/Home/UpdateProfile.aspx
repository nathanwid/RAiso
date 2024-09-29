<%@ Page Title="Profile | RAiso" Language="C#" MasterPageFile="~/Views/Home/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="RAiso.Views.Home.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card form-container">
                    <div class="card-body">
                        <h3 class="card-title text-center">Update Profile</h3>
                        <hr />
                        <div class="mb-3">
                            <asp:Label ID="LblUsername" CssClass="label" runat="server">Username</asp:Label>
                            <asp:TextBox ID="TBUsername" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <div class="gender-group">
                                <span class="gender-label">Gender:</span>
                                <asp:RadioButton ID="RBMale" runat="server" Text="Male" GroupName="gender" CssClass="form-check-input" />
                                <asp:RadioButton ID="RBFemale" runat="server" Text="Female" GroupName="gender" CssClass="form-check-input" />
                            </div>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="LblDOB" CssClass="label" runat="server">DOB</asp:Label>
                            <asp:TextBox ID="DOBButton" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="LblPhone" CssClass="label" runat="server">Phone</asp:Label>
                            <asp:TextBox ID="TBPhone" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="LblAddress" CssClass="label" runat="server">Address</asp:Label>
                            <asp:TextBox ID="TBAddress" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="LblPassword" CssClass="label" runat="server">New/Old Password</asp:Label>
                            <asp:TextBox ID="TBPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3 text-danger">
                            <asp:Label ID="LblError" CssClass="error" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="mb-3">
                            <asp:Button ID="UpdateProfileBtn" OnClick="UpdateProfileBtn_Click" runat="server" Text="Update" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
