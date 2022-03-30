<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteUpdate.aspx.cs" Inherits="toptours1.RouteUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="color: #FFFFFF; font-style: italic; font-weight: 700; background-color: #6699FF">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            New route&#39;s info<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
        <br />
        <br />
        Place Name<p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button3" runat="server" Text="Add Place To Route" OnClick="Button3_Click" BorderStyle="Ridge" />
        <br/>
        <asp:Button ID="Button4" runat="server" Text="Delete Route" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="🌟" OnClick="Button5_Click" />
    <p>
        Map:</p>
         <asp:Button ID="Button2" runat="server" Text="Reviews" Height="26px" OnClick="Button2_Click" />
        <p>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
    </body>
</html>
