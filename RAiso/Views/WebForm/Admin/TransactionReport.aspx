<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/NavigationBar.Master" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="RAiso.Views.WebForm.Admin.TransactionReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" />
</asp:Content>
