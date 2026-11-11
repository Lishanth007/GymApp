<%@ Page Title="Payment History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentHistory.aspx.cs" Inherits="GymApp.PaymentHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>My Membership & Payment History</h3>
    <asp:GridView ID="gvHistory" runat="server"></asp:GridView>
</asp:Content>