<%@ Page Title="" Language="C#" MasterPageFile="~/EnergySimplyMaster.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="EnergySimplyWeb.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelAddCustomer" runat=server>
    <asp:Label ID="lblCustomerInstructions" runat="server" Text="Enter the following information for the new Customer:"></asp:Label>
    <p>
        <asp:Label runat=server ID="lblCustomerName" Text="Enter the Customer Name:" Width=200></asp:Label>
        <asp:TextBox ID="txtCustomerName" runat="server" MaxLength="100"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCustomerName" 
            ErrorMessage="Required field!" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblCustomerEmail" runat=server Text="Enter the Customer's Email:" Width=200></asp:Label>
        <asp:TextBox ID="txtCustomerEmail" runat="server" MaxLength="100"></asp:TextBox>
        <asp:RequiredFieldValidator runat=server ControlToValidate="txtCustomerEmail" 
            ErrorMessage="Required field!" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat=server ControlToValidate="txtCustomerEmail" 
            ErrorMessage="Invalid email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblCustomerPlan" runat=server Text="Select a Plan:" Width=200></asp:Label>
        <asp:DropDownList ID="cboPlan" runat=server SelectMethod=GetPlans AppendDataBoundItems=true AutoPostBack=true
             DataTextField="PlanName" DataValueField="PlanName" Width=200>
        </asp:DropDownList>
        <br /><br />
        <asp:Button runat="server" ID="btnAddCustomer" Text="Add Customer" OnClick=btnAddCustomer_Click />
    </p>
    </asp:Panel>
    <br />
    <asp:Panel ID="panelDisplayCustomers" runat=server>
        <asp:Label ID="lblShowCustomers" runat="server"></asp:Label>
        <br /><br />
        <asp:GridView ID="gridViewCustomers" runat="server" CellPadding="4" AutoGenerateColumns=false
             ItemType=EnergySimplyDAL.Models.Customer SelectMethod=gridViewCustomers_GetData
             EmptyDataText="There are no records to display." ForeColor="#333333" GridLines=Both>
            <Columns>
                <asp:BoundField DataField="CustID" HeaderText="CustID" ReadOnly="true" SortExpression="CustID" />
                <asp:BoundField DataField="CustName" HeaderText="CustName" SortExpression="CustName" />
                <asp:BoundField DataField="CustEmail" HeaderText="CustEmail" SortExpression="CustEmail" />
                <asp:BoundField DataField="PlanID" HeaderText="PlanID" SortExpression="PlanID" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:HyperLink ID="linkAddCustomer" runat="server" Text="Add Customer" NavigateUrl="~/AddCustomer.aspx"></asp:HyperLink>&nbsp;|&nbsp;
        <asp:HyperLink ID="linkAddPlan" runat="server" Text="Add Plan" NavigateUrl="~/AddPlan.aspx"></asp:HyperLink>
    </asp:Panel>
</asp:Content>
