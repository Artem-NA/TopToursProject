<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="toptours1.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
            <br />
            <br />
            Security Check</div>
        <p>
            Email<br />
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            </p>
        <p>
            Update Your Personal Data</p>
        <p>
            Select what data you want to update</p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">Password</asp:ListItem>
                <asp:ListItem Value="2">Email</asp:ListItem>
                <asp:ListItem Value="3">Username</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Type the new content<br />
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update" />
        </p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        Account Deletion <p>
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
