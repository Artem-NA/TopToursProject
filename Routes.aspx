﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Routes.aspx.cs" Inherits="toptours1.Routes1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-weight: 700; font-style: italic; background-color: #00CCFF">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Home" />
        </div>
        <div style="direction: ltr">
            <br />
            My Routes<br />
            <asp:BulletedList ID="BulletedList1" runat="server">
            </asp:BulletedList>
            <br />
            Don&#39;t find your route? then create one by yourself!<br />
        <div>
            Route name<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Route title<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Route info<br />
            <asp:TextBox ID="TextBox4" runat="server" Width="858px" Height="16px"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" Text="+" OnClick="Button1_Click" style="height: 26px" />
            <br />
        </div>
        <p>
            &nbsp;&nbsp;
            <asp:Button ID="Button10" runat="server" Text="Favorite routes" OnClick="Button10_Click" />
            <br />
            </p>
        <p>
            &nbsp;</p>
        <p>
            Search route<br />
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click1" Text="🔎" />
            <br />
            <br />
            </p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>