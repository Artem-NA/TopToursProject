<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="toptours1.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Sign Up For Free!<br />
            First Name<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Last Name<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Username<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Email<br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Add Image<br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />

            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
             <a href="Login.aspx">Already have an account? Sign in</a><br />
        
        </p>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
