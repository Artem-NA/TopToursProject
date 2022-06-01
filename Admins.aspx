<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admins.aspx.cs" Inherits="toptours1.OnlyAdmins" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Admins</title>
    <link href="StyleSheets/SSHome.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.15.4/css/fontawesome.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>

    <!--font-family-->
		<link href="https://fonts.googleapis.com/css?family=Rufina:400,700" rel="stylesheet" />

		<link href="https://fonts.googleapis.com/css?family=Poppins:100,200,300,400,500,600,700,800,900" rel="stylesheet" />

	
		<!--font-awesome.min.css-->
		<link rel="stylesheet" href="assets/css/font-awesome.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <section class="sub-header">
        <nav>
            <a herf="Home2.aspx"><img id="logo" src="imgs/logoWhPNG.png" alt="logo"/></a>
            <div class="nav-links" id="navLinks">
                <%-- ul-unordered list --%>
                <ul>
                    <%-- li- list item --%>
                      <asp:BulletedList ID="BulletedList1"  runat="server"></asp:BulletedList>
                       <asp:Button ID="IsLogged" runat="server" class="btnlog" Text="" OnClick="IsLogged_Click" />


                </ul>
            </div>
        </nav>
  
        <h1>Welcome Admin</h1>

        </section>

        <h1>Choose the content you would like to edit or delete</h1>
        <section class="list">
              <asp:DropDownList ID="DropDownList1" runat="server">
                  <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                  <asp:ListItem Value="1">Users</asp:ListItem>
                  <asp:ListItem Value="2">Applications</asp:ListItem>
                  <asp:ListItem Value="3">Reviews</asp:ListItem>
              </asp:DropDownList>
              <br />
              <asp:Button ID="Search" runat="server" CssClass="btn-dark" Text="Submit" OnClick="Search_Click" /> <br />
              <asp:PlaceHolder ID="All" runat="server" Visible="false"></asp:PlaceHolder>
            <asp:PlaceHolder ID="Applications" runat="server" Visible="false"></asp:PlaceHolder>
              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>


             

        </section>







    


      <section class="footer"> 
          <h3>All credits to Top-Tours.</h3>
      </section>

    </form>
</body>
</html>