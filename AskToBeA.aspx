<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskToBeA.aspx.cs" Inherits="toptours1.AskToBeA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Home" />
        </div>
        <p style="direction: ltr">
            <span style="color: rgb(51, 51, 51); font-family: Assistant; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Unfortunately, you&#39;re not an Admin.</span></p>
        <p style="direction: ltr">
            <span style="color: rgb(51, 51, 51); font-family: Assistant; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Would you like to have access and be part of the team?</span></p>
        <p style="direction: ltr">
            if the answer is yes so ask to be promoted and an admin will</p>
        <p style="direction: ltr">
            respond within 24 hours with an answer!!</p>
        <p style="direction: ltr">
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Ask To Become Admin!" />
        </p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
