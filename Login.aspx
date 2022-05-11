<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="toptours1.Login11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TopTours-Login</title>
    <%-- My Css --%>
    <link href="StyleSheets/SSLogin.css" rel="stylesheet" />
</head>
<body>
    <div class="loginBox">
        <img src="/imgs/logo.jpeg" class="logo" />
        <form id="form1" runat="server">
           <h1>Login</h1>
            <h2>Username:</h2>
           <input type="text" autocomplete="off" id="Username" runat="server" placeholder="Enter Username" />
            <h2>Password:</h2>
            <input type="password" autocomplete="off" id="Password" runat="server" placeholder="Enter Username" />
              <br /> 
            <asp:Button ID="LoginB" Text="Login" OnClick="LoginB_Click" runat="server" /> <br />
            <a href="SignUp.aspx">Don't Have An Account?</a> <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </form>
        
        



      
    </div>
</body>
</html>
