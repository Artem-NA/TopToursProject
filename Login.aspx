<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="toptours1.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login TopTours</title>
    <link rel="stylesheet" href="log.css"/>
</head>
<body>
    <form class="box" method="post" runat="server" id="form1">
  <h1>Login</h1>
        <asp:TextBox ID="TextBox2" placeholder="Email" runat="server" autocomplete="off" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    <asp:TextBox ID="TextBox1" type="password" placeholder="Password" autocomplete="off" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click1" />
    <asp:Label ID="Label1" runat="server" class="lab"></asp:Label>
    <asp:Button ID="Button2" runat="server" Text="Sign Up" OnClick="Button3_Click1" />
</form>
</body>
</html>
