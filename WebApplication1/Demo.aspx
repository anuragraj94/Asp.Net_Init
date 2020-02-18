<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="WebApplication1.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server">
                <asp:ListItem>Mumbai</asp:ListItem>
                <asp:ListItem>Bangalore</asp:ListItem>
                <asp:ListItem>Hydrebad</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" />
            <br />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" />
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="C#" />
            <br />
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Asp.Net" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            <br />
        </div>
    </form>
</body>
</html>
