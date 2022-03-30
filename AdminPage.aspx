<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="toptours1.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div style="direction: ltr">
            <br />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Home" />
            <br />
            <br />
            Welcome Admin!!<br />
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
            <br />
            Enter username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
            <p>
            &nbsp;<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;</p>
            <p>
                Enter
                <asp:Label ID="Label2" runat="server" Text="Value"></asp:Label>
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </p>
            <p>
               <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Delete" />
            <asp:Button ID="Button7" runat="server" OnClick="Button5_Click" Text="Show Data" />
               sp;
            </p>
        </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </p>
        <p>
           </p>
        <p>
            </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
