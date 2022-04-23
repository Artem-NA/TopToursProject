<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="toptours1.Application" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Applications</title>
</head>
<body>
    <form id="form1" runat="server">
        
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Home" />
             <h4> Unfortunately, you're not an Admin.
             Would you like to have access and be part of the team?
                 If the answer is affirmative then submit application to be promoted and an admin will
             respond within 24 hours with an answer!!
             </h4>
             
            <h3> Write an application message to admin</h3>
            <asp:TextBox ID="MessageTB" runat="server" />
             <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Submit Application" />
             <br />
             <asp:Label ID="ResponseL" runat="server" Text="" />
       
    </form>
</body>
</html>
