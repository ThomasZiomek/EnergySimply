<%@ Page Title="" Language="C#" MasterPageFile="~/EnergySimplyMaster.Master" AutoEventWireup="true" 
    CodeBehind="AddPlan.aspx.cs" Inherits="EnergySimplyWeb.AddPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelAddPlan" runat=server>
    <asp:Label ID="lblPlanInstructions" runat="server" Text="Enter the following information for the new Plan:"></asp:Label>
    <p>
        <asp:Label runat="server" ID="lblPlanName" Text="Enter the Plan Name:" Width=170></asp:Label>
        <asp:TextBox ID="txtPlanName" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPlanName"
            ErrorMessage="Required field!" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblPlanFixedCost" runat=server Text="Enter the Fixed Cost:" Width=170></asp:Label>
        <asp:TextBox ID="txtPlanFixedCost" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPlanFixedCost" 
            ErrorMessage="Required field!" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPlanFixedCost" ValidationExpression="\d\.\d{2}" 
            ErrorMessage="Dollar Amount required (format 9.99)." ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblPlanVarCost" runat="server" Text="Enter the Variable Cost:" Width=170></asp:Label>
        <asp:TextBox ID="txtPlanVarCost" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPlanVarCost" ErrorMessage="Required field!" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPlanVarCost" ValidationExpression="\d\.\d{2}" 
            ErrorMessage="Dollar amount required (format 9.99)." ForeColor="Red"></asp:RegularExpressionValidator>
        <br /><br />
        <asp:Button runat="server" ID="btnAddPlan" Text="Add Plan" OnClick=btnAddPlan_Click />
    </p>
    </asp:Panel>
    <br />
    <asp:Panel ID="panelDisplayPlans" runat=server>
        <asp:Label ID="lblShowPlans" runat="server"></asp:Label>
        <br /><br />
        <asp:GridView ID="gridViewPlans" runat="server" CellPadding="4" AutoGenerateColumns=false
             ItemType=EnergySimplyDAL.Models.Plan SelectMethod=GridViewPlans_GetData
             EmptyDataText="There are no records to display." ForeColor="#333333" GridLines=Both>
            <Columns>
                <asp:BoundField DataField="PlanID" HeaderText="PlanID" ReadOnly="true" SortExpression="PlanID" />
                <asp:BoundField DataField="PlanName" HeaderText="PlanName" SortExpression="PlanName" />
                <asp:BoundField DataField="PlanFixedCost" HeaderText="PlanFixedCost" SortExpression="PlanFixedCost" />
                <asp:BoundField DataField="PlanVarCost" HeaderText="PlanVarCost" SortExpression="PlanVarCost" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:HyperLink ID="linkAddCustomer" runat="server" Text="Add Customer" NavigateUrl="~/AddCustomer.aspx"></asp:HyperLink>&nbsp;|&nbsp;
        <asp:HyperLink ID="linkAddPlan" runat="server" Text="Add Plan" NavigateUrl="~/AddPlan.aspx"></asp:HyperLink>
    </asp:Panel>
</asp:Content>
