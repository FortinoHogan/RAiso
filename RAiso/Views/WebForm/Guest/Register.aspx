<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/NavigationBar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RAiso.Views.WebForm.Guest.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <h1 class="formTitle">Register</h1>
        <div class="inputGroup">
            <asp:Label ID="nameLbl" CssClass="inputLbl" runat="server" Text="Name" AssociatedControlID="nameTxt"></asp:Label>
            <asp:TextBox ID="nameTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
            <asp:Label ID="nameError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div class="inputGroup">
            <asp:Label ID="dobLbl" CssClass="inputLbl" runat="server" Text="DOB"></asp:Label>
            <asp:Calendar ID="dobCalendar" runat="server"></asp:Calendar>
            <asp:Label ID="dobError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div class="inputGroup">
            <asp:Label ID="gender" CssClass="inputLbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton ID="male" CssClass="maleBtn" runat="server" Text="Male" GroupName="gender" />
            <asp:RadioButton ID="female" CssClass="femaleBtn" runat="server" Text="Female" GroupName="gender" />
            <asp:Label ID="genderError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div class="inputGroup">
            <asp:Label ID="addressLbl" CssClass="inputLbl" runat="server" Text="Address" AssociatedControlID="addressTxt"></asp:Label>
            <asp:TextBox ID="addressTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
            <asp:Label ID="addressError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div class="inputGroup">
            <asp:Label ID="passwordLbl" CssClass="inputLbl" runat="server" Text="Password" AssociatedControlID="passwordTxt"></asp:Label>
            <asp:TextBox ID="passwordTxt" CssClass="inputTxt" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="passwordError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div class="inputGroup">
            <asp:Label ID="phoneLbl" CssClass="inputLbl" runat="server" Text="Phone" AssociatedControlID="phoneTxt"></asp:Label>
            <asp:TextBox ID="phoneTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
            <asp:Label ID="phoneError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <asp:Label ID="registerError" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Button ID="registerBtn" CssClass="authBtn" runat="server" Text="Register" />
    </div>
</asp:Content>
