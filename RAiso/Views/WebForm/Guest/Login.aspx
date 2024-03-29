<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/NavigationBar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RAiso.Views.WebForm.Guest.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <h1 class="formTitle">Login</h1>
        <div class="inputGroup">
            <asp:Label ID="nameLbl" CssClass="inputLbl" runat="server" Text="Name" AssociatedControlID="nameTxt"></asp:Label>
            <asp:TextBox ID="nameTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
            <asp:Label ID="nameError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div class="inputGroup">
            <asp:Label ID="passwordLbl" CssClass="inputLbl" runat="server" Text="Password" AssociatedControlID="passwordTxt"></asp:Label>
            <asp:TextBox ID="passwordTxt" CssClass="inputTxt" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="passwordError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <asp:Label ID="loginError" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Button ID="loginBtn" CssClass="authBtn" runat="server" Text="Login" />
    </div>
</asp:Content>
