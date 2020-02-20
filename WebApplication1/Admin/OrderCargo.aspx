<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="OrderCargo.aspx.cs" Inherits="WebApplication1.Admin.OrderCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Cargo</h2>
    <br />
    Order ID : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br /><br />
    Quantity : <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br /><br />
    Warehouse Place : <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Order" />
    <br /><br />
</asp:Content>
