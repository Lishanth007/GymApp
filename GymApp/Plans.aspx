<%@ Page Title="Plans" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Plans.aspx.cs" Inherits="GymApp.Plans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Available Membership Plans</h3>
    <asp:GridView ID="gvPlans" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPlans_RowCommand">
        <Columns>
            <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
            <asp:BoundField DataField="DurationMonths" HeaderText="Duration (Months)" />
            <asp:BoundField DataField="FeeAmount" HeaderText="Fee (Rs)" />
            <asp:BoundField DataField="Description" HeaderText="Features" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnSelect" runat="server" Text="Choose Plan" 
                        CommandName="ChoosePlan" 
                        CommandArgument='<%# Eval("PlanID") + ";" + Eval("PlanName") + ";" + Eval("DurationMonths") + ";" + Eval("FeeAmount") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>