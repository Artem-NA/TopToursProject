<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tests.aspx.cs" Inherits="toptours1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            TESTS<br />
            FN<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            LN<br />
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
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" style="height: 26px" />
        <br />
        <br />
        Email<br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Login" />
        </p>
        <p>
            Email<br />
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
            new email/password/username</p>
        <p>
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        </p>
        <p>
            write the new content<br />
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update" />
        </p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <p>
        Email<br />
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Delete" />
    </form>
    </body>
</html>
