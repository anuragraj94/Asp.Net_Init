<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ShiftOrder.aspx.cs" Inherits="WebApplication1.Admin.ShiftOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Shift Cargo</h2>
    <br />
    Order ID : <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
    <br /><br />
    Place : <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br /><br />
    Quantity Ordered : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br /><br />
    Shift To : <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <br /><br />
    Capacity : <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br /><br />
    Quantity in Warehouse : <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Shift" />
    <br /><br />
</asp:Content>
