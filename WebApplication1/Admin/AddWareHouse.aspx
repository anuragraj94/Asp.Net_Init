<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddWareHouse.aspx.cs" Inherits="WebApplication1.Admin.AddWareHouse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Warehouse</h2>
    <br />
    ID : <asp:TextBox ID="txtId"  runat="server"></asp:TextBox>
    <br /><br />
    Place : <asp:TextBox ID="txtPlace" runat="server"></asp:TextBox>
    <br /><br />
    Supervisor Name : <asp:TextBox ID="txtSName" runat="server"></asp:TextBox>
    <br /><br />
    Capacity : <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
    <br /><br />
    Mobile Number : <asp:TextBox ID="txtMno" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <br /><br />
</asp:Content>
