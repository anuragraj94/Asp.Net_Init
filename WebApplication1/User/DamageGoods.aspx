<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="DamageGoods.aspx.cs" Inherits="WebApplication1.User.DamageGoods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Damaged Goods</h2>
    <br />
    Order ID : <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <br /><br />
    Note : <asp:TextBox ID="TextBox1" runat="server" Height="43px" TextMode="MultiLine"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Submit" />
    <br /><br />
</asp:Content>
