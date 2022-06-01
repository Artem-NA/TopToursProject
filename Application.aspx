<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="toptours1.Application" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>About Us</title>
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
  
        <h1>About Us</h1>

        



    </section>


    <section class="about-us">
             <h4> Unfortunately, you're not an Admin.
             Would you like to have access and be part of the team?
                 If the answer is affirmative then submit application to be promoted and an admin will
             respond within 24 hours with an answer!!
             </h4>
             
            <h3> Write an application message to admin</h3>
             <textarea rows="6" autocomplete="off" id="Info" runat="server" placeholder="Enter place info"></textarea>
             <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Submit Application" CssClass="btn-dark" />
             <br />
             <asp:Label ID="ResponseL" runat="server" Text="" />
      </section>

    </form>
</body>
</html>
