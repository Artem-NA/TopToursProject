<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="toptours1.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account</title>
    <link href="StyleSheets/ProfileSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div id="square"> <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" class="btn"  />
            <br />
            <br />
            Security Check</div>
        <p>
            Email<br />
            <asp:TextBox ID="TextBox9" runat="server" class="tb" ></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="TextBox10" runat="server" class="tb"></asp:TextBox>
            </p>
        <p>
            Update Your Personal Data</p>
        <p>
            Select what data you want to update</p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" class="tb">
                <asp:ListItem Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">Password</asp:ListItem>
                <asp:ListItem Value="2">Email</asp:ListItem>
                <asp:ListItem Value="3">Username</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Type the new content<br />
            <asp:TextBox ID="TextBox12" runat="server" class="tb"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update" class="btn" />
        </p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        Account Deletion <p>
        Email<br />
            <asp:TextBox ID="TextBox13" runat="server" class="tb"></asp:TextBox>
            <br />
            Password<br />
            <input type="password" id="pass" runat="server" class="tb" name="pass"/>
        </p>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Delete" class="btn" />
        </div>
       </form>
</body>
</html>
