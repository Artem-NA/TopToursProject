<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewsPage.aspx.cs" Inherits="toptours1.ReviewsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Home" />
            <br />
            <br />
            WELCOME To Reviews!!</div>
        <p>
            Caption
        </p>
        <p>
            <asp:TextBox ID="TextBox4" runat="server" Height="22px"></asp:TextBox>
        </p>
        <p>
            Rating</p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            Content</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            Route Name</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Review" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete " />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Get Review Data" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="All comments"></asp:Label>
        </p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
