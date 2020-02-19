<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
    <link href="../CSS/login.css" rel="stylesheet" />
</head>
<body>
    <%--<div class="login">
    <input type="text" placeholder="Username" id="username">  
  <input type="password" placeholder="password" id="password">  
  <%--<a href="#" class="forgot">forgot password?</a>
  <input type="submit" value="Sign In">
</div>
<div class="shadow"></div>--%>

    <form runat="server">
  <h1>Employer Log in</h1>
  <div class="inset">
  <p>
    <label for="email">EMAIL ADDRESS</label>
      <%--<input type="text" name="email" id="email">--%>
      <asp:TextBox ID="txtEmail" runat="server" name="UserName" ></asp:TextBox>
  </p>
  <p>
    <label for="password">PASSWORD</label>    <%--<input type="password" name="password" id="password">--%>
      <asp:TextBox ID="txtPass" runat="server" name="Password" ></asp:TextBox>
  </p>
  <p>
      <%--<input type="checkbox" name="remember" id="remember">--%>
      <asp:CheckBox ID="CheckBox1" runat="server" name="remember"/>
    <label for="remember">Remember me for 14 days</label>
  </p>
  </div>
  <p class="p-container">
    <span>Forgot password ?</span>
      <%--<input type="submit" name="go" id="go" value="Log in">--%>
      <asp:Button ID="Button1" runat="server" Text="Log in" OnClick="Button1_Click" />
  </p>
</form>

</body>
</html>
