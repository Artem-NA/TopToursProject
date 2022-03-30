<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Places.aspx.cs" Inherits="toptours1.Routes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Places<br />
        <br />
        firstname<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        lastname<br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        username<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        password<br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        email<br />
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        date<br />
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </div>
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <p>
            <asp:Button ID="Button3" runat="server" Text="Button" />
        </p>
    </form>
</body>
</html>
