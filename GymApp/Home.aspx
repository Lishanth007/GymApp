<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GymApp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Welcome to Fitness Point</h3>
    <p>Manage your membership and pay your gym fees online directly.</p>
    <ul>
        <li><a href="Plans.aspx">View Membership Plans & Fees</a></li>
        <li><a href="Enroll.aspx">Enroll or Renew Subscription</a></li>
        <li><a href="PaymentHistory.aspx">Check Payment History & Receipts</a></li>
    </ul>
</asp:Content>