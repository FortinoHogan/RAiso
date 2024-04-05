<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/NavigationBar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="RAiso.Views.WebForm.Customer.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <div class="cardData">
            <asp:Label ID="nameLbl" runat="server" Text="Product Name: "></asp:Label>
            <asp:Label ID="nameTxt" CssClass="cardTxt" runat="server" Text=""></asp:Label>
        </div>
        <div class="cardData">
            <asp:Label ID="priceLbl" runat="server" Text="Product Price: "></asp:Label>
            <asp:Label ID="priceTxt" CssClass="cardTxt" runat="server" Text=""></asp:Label>
        </div>
        <div class="cardData">
            <asp:Label ID="quantityLbl" runat="server" Text="Product Quantity: "></asp:Label>
            <asp:Label ID="quantityTxt" CssClass="cardTxt" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
