<%@ Page Title="Fee Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeeSummary.aspx.cs" Inherits="GymApp.FeeSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Fee Summary & Checkout</h3>

    <p><b>Member Name:</b> <asp:Label ID="lblMemberName" runat="server"></asp:Label></p>
    <p><b>Selected Plan:</b> <asp:Label ID="lblPlan" runat="server"></asp:Label></p>
    <p><b>Start Date:</b> <asp:Label ID="lblStart" runat="server"></asp:Label></p>
    <p><b>Expiry / End Date:</b> <asp:Label ID="lblEnd" runat="server"></asp:Label></p>
    <p><b>Total Amount Payable:</b> Rs. <asp:Label ID="lblTotal" runat="server"></asp:Label></p>

    <p>
        Payment Mode:
        <asp:DropDownList ID="ddlPayMode" runat="server">
            <asp:ListItem Text="Online UPI (GPay / PhonePe)" Value="UPI" />
            <asp:ListItem Text="Debit / Credit Card" Value="Card" />
            <asp:ListItem Text="Cash at Gym Counter" Value="Cash" />
        </asp:DropDownList>
    </p>

    <asp:Button ID="btnPayFee" runat="server" Text="Pay Fee & Activate Membership" OnClick="btnPayFee_Click" />
</asp:Content>