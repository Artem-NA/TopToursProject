<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceUpdate.aspx.cs" Inherits="toptours1.PlaceUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            New Place&#39;s Info<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
        <br />
        <br />
        Route Name<p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button3" runat="server" Text="Add Place To Route" OnClick="Button3_Click" />
        <br/>
        <asp:Button ID="Button4" runat="server" Text="Delete Place" OnClick="Button4_Click" />
         <br/>
        <asp:Button ID="Button2" runat="server" Text="Home" OnClick="Button2_Click" />
    </form>
</body>
</html>
