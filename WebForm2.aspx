<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="toptours1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Usernamr to add</p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Add New Admin" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Ask To Be Admin" OnClick="Button2_Click" />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>


        </div>
    </form>
</body>
</html>
