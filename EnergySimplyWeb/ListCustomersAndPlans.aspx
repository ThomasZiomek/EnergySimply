<%@ Page Title="Energy Simply - Customers and Plans" Language="C#" MasterPageFile="~/EnergySimplyMaster.Master" 
    AutoEventWireup="true" CodeBehind="ListCustomersAndPlans.aspx.cs" Inherits="EnergySimplyWeb.ListCustomersAndPlans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Here are the current customers and associated plans:
    </p>
    <asp:GridView ID="GridViewCustomersAndPlans" runat="server" CellPadding="4" AutoGenerateColumns=false
         ItemType=EnergySimplyWeb.CustomersAndPlans SelectMethod=GridViewCustomersAndPlans_GetData
         EmptyDataText="There are no records to display." ForeColor="#333333" GridLines=Both>
        <Columns>
            <asp:BoundField DataField="CustID" HeaderText="CustID" ReadOnly="true" SortExpression="CustID" />
            <asp:BoundField DataField="CustName" HeaderText="CustName" SortExpression="CustName" />
            <asp:BoundField DataField="CustEmail" HeaderText="CustEmail" SortExpression="CustEmail" />
            <asp:BoundField DataField="PlanName" HeaderText="PlanName" SortExpression="PlanName" />
            <asp:BoundField DataField="PlanFixedCost" HeaderText="PlanFixedCost" SortExpression="PlanFixedCost" />
            <asp:BoundField DataField="PlanVarCost" HeaderText="PlanVarCost" SortExpression="PlanVarCost" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:HyperLink ID="linkAddCustomer" runat="server" Text="Add Customer" NavigateUrl="~/AddCustomer.aspx"></asp:HyperLink>&nbsp;|&nbsp;
    <asp:HyperLink ID="linkAddPlan" runat="server" Text="Add Plan" NavigateUrl="~/AddPlan.aspx"></asp:HyperLink>
</asp:Content>
