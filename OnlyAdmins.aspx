<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlyAdmins.aspx.cs" Inherits="toptours1.OnlyAdmins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h1>Welcome Admin!!</h1>
            <br />
            The type of content you would like to search<br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">Users</asp:ListItem>
                <asp:ListItem Value="2">Places</asp:ListItem>
                <asp:ListItem Value="3">Routes</asp:ListItem>
                <asp:ListItem Value="4">Reviews</asp:ListItem>
            </asp:DropDownList>
            <br />
            Enter value of the selected content
            <br />
            <asp:TextBox ID="ValueTB" runat="server"></asp:TextBox>
            <asp:Button ID="SearchB" runat="server" Text="Search" OnClick="SearchB_Click" style="height: 26px" />
            <br/>
            <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
        </div> 
    </form>
</body>
</html>
