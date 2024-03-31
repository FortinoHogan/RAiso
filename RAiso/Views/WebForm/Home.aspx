<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/NavigationBar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RAiso.Views.WebForm.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="gridView">
        <asp:GridView ID="stationeryGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="stationeryGV_RowDeleting" OnRowUpdating="stationeryGV_RowUpdating" OnSelectedIndexChanged="stationeryGV_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="StationeryName" HeaderText="Name" SortExpression="StationeryName" />
                <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="StationeryPrice" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True"/>
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" Visible="false"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
