<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TraceCargo.aspx.cs" Inherits="WebApplication1.Admin.TraceCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Track Cargo</h2>   
    Order Id : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Search" />
    <br /><br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
