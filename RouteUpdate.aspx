<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteUpdate.aspx.cs" Inherits="toptours1.RouteUpdate" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="cssSite/stars1.css" rel="stylesheet" />
    <script src="starsfunc.js"></script>
    <script src="bootstrap/js/bootstrap.bundle.min.js"></script>

</head>
<body style="font-style: italic; font-weight: 700; background-color: #6699FF">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="HomeButton" runat="server" Text="Home" OnClick="HomeButton_Click" />
            <br />
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
        <br />
         <button type="button" class="" data-toggle="modal" data-target="#myModal">Add Review</button>
        <br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <br />
        <div class="container">

  <!-- Trigger the modal with a button -->
 

  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Modal Header</h4>
        </div>
        <div class="modal-body">
          <p>Enter title </p>
            <asp:TextBox ID="CaptionTB" runat="server"></asp:TextBox>
            <p>Enter content</p>
            <asp:TextBox ID="ContentTB" runat="server"></asp:TextBox>
            <p>Enter Rating</p>
            <asp:Button BorderStyle="None" ID="Rating1" onmouseover="return Decide(1);" OnClientClick="return Decide(1);"
            Height="20px" Width="20px" CssClass="Empty" runat="server" />
            <asp:Button BorderStyle="None" ID="Rating2" onmouseover="return Decide(2);" OnClientClick="return Decide(2);"
            Height="20px" Width="20px" CssClass="Empty" runat="server" />
            <asp:Button BorderStyle="None" ID="Rating3" onmouseover="return Decide(3);" OnClientClick="return Decide(3);"
            Height="20px" Width="20px" CssClass="Empty" runat="server" />
            <asp:Button BorderStyle="None" ID="Rating4" onmouseover="return Decide(4);" OnClientClick="return Decide(4);"
            Height="20px" Width="20px" CssClass="Empty" runat="server" />
            <asp:Button BorderStyle="None" ID="Rating5" onmouseover="return Decide(5);" OnClientClick="return Decide(5);"
            Height="20px" Width="20px" CssClass="Empty" runat="server" />

        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
  
</div>
    </form>
    </body>
</html>
