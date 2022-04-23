<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="toptours1.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheets/LoginSS.css" rel="stylesheet" />
    <title>Login To TopTours</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="square"> 
            <h1>Login</h1>
            <div id="line">
                Email/Username</div>
            <input type="text" class="email" id="eu"/>
            
            <div id="line2">
                Password</div>
            <input type="password" class="pass" id="p" />
            <div id="line3">  </div>  <asp:Button ID="LoginB" class="btn" runat="server" Text="Login" OnClick="LoginB_Click" />
            <div id="line4"><a href="SignUp.aspx"  class="link">Sign Up Now!</a></div>
        </div>
    </form>
</body>
</html>
