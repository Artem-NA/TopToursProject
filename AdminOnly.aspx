<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminOnly.aspx.cs" Inherits="toptours1.AdminOnly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome Admin</h1>
            <br />
            Select the type of content you would like to delete<br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">User</asp:ListItem>
                <asp:ListItem Value="2">Place</asp:ListItem>
                <asp:ListItem Value="3">Route</asp:ListItem>
                <asp:ListItem Value="4">Review</asp:ListItem>
            </asp:DropDownList>
            <br />
            Enter the name of the selected value
            <br />
            <asp:TextBox ID="SearchTB" runat="server"></asp:TextBox>
            <br/>
            <asp:Button ID="Search" runat="server" Text="Show Info" OnClick="Search_Click" />
            <br />
            <asp:BulletedList ID="ListOfValues" runat="server"></asp:BulletedList>
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
