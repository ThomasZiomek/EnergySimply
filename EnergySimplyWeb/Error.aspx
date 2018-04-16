<%@ Page Title="" Language="C#" MasterPageFile="~/EnergySimplyMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="EnergySimplyWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        An error occurred while attempting to process your request. Details:</p>
    <br />
    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
</asp:Content>
