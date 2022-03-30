<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlacesPage.aspx.cs" Inherits="toptours1.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="direction: ltr">
            <br />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Home" />
            <br />
            <br />
            My Places:<br />
            <br />
        <asp:BulletedList ID="BulletedList1" runat="server">
            
        </asp:BulletedList>
            <br />
            <br />
            <br />
            <br />
            No Places? Create a place right now<br />
        <div>
            place name<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            place info<br />
            <asp:TextBox ID="TextBox3" runat="server" Height="16px" Width="525px"></asp:TextBox>
            <br />
            longitude<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            latitude<br />
            <asp:TextBox ID="TextBox5" runat="server" Height="22px"></asp:TextBox>
            <br />
            Is private?<br />
            <asp:RadioButton GroupName="gi" ID="RadioButton1" runat="server" Checked="true" Text="Yes" />
            <br />
            <asp:RadioButton GroupName="gi" ID="RadioButton2" runat="server" Checked="false" Text="No" />
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" Text="+" OnClick="Button1_Click" style="height: 26px" />
            <br />
        </div>
        <p>
            <br />
            Search Place<br />
            <asp:TextBox ID="SearchTB" runat="server"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click1" Text="🔎" />
            </p>
        <asp:BulletedList ID="BulletedList2" runat="server">
        </asp:BulletedList>
        <p>
            <br />
            </p>
        <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
