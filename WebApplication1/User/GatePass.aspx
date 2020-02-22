<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="GatePass.aspx.cs" Inherits="WebApplication1.User.GatePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gate Pass</h2>
    <br />
    Order ID : <asp:DropDownList ID="ddlOId" runat="server"></asp:DropDownList>
    <br /><br />
    Weight : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <br /><br />
</asp:Content>
