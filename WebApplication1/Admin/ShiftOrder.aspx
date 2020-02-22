<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ShiftOrder.aspx.cs" Inherits="WebApplication1.Admin.ShiftOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Shift Cargo</h2>
    <br />
    Order ID : <asp:DropDownList ID="ddlID" runat="server"></asp:DropDownList>
    <br /><br />
    Place : <asp:TextBox ID="txtPlace" runat="server"></asp:TextBox>
    <br /><br />
    Quantity Ordered : <asp:TextBox ID="txtQuant" runat="server"></asp:TextBox>
    <br /><br />
    Shift To : <asp:DropDownList ID="ddlPlace" runat="server"></asp:DropDownList>
    <br /><br />
    Capacity : <asp:TextBox ID="txtCapa" runat="server"></asp:TextBox>
    <br /><br />
    Quantity in Warehouse : <asp:TextBox ID="txtQuantInWareh" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Shift" OnClick="Button1_Click" />
    <br /><br />
    <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
    <br /><br />
</asp:Content>
