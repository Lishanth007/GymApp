<%@ Page Title="Enroll" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Enroll.aspx.cs" Inherits="GymApp.Enroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Enroll / Renew Membership</h3>

    <p>
        Member Full Name: 
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </p>

    <p>
        Select Plan: 
        <asp:DropDownList ID="ddlPlans" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPlans_SelectedIndexChanged"></asp:DropDownList>
    </p>

    <p>
        Joining / Start Date: 
        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
    </p>

    <p>
        Duration: <asp:Label ID="lblDuration" runat="server" Text="0"></asp:Label> Months
    </p>

    <p>
        Total Fee: Rs. <asp:Label ID="lblFee" runat="server" Text="0.00"></asp:Label>
    </p>

    <asp:Button ID="btnProceed" runat="server" Text="Proceed to Fee Summary" OnClick="btnProceed_Click" />
</asp:Content>