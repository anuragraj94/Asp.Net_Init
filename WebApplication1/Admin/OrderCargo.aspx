<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="OrderCargo.aspx.cs" Inherits="WebApplication1.Admin.OrderCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Cargo</h2>
    <br />
    Order ID : <asp:TextBox ID="txtOrderId" runat="server"></asp:TextBox>
    <br /><br />
    Quantity : <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
    <br /><br />
    Warehouse Place : <asp:DropDownList ID="ddlPlace" runat="server"></asp:DropDownList>
    <br /><br />
    <asp:Button ID="btnOrder" runat="server" Text="Order" OnClick="btnOrder_Click" />
    <br /><br />
    <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
    <br /><br />
</asp:Content>
