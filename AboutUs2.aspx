<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs2.aspx.cs" Inherits="toptours1.AboutUs2" %>

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
                    <li><a href="home2.aspx">HOME</a></li>
                        <li><a href="PlacesPage.aspx">PLACES</a></li>
                        <li><a href="Routes.aspx">ROUTES</a></li>
                        <li><a href="AboutUs2.aspx">ABOUT US</a></li>
                        <li><a href="admins.aspx">ADMINS</a></li>
                    <li><a href="profile.aspx">PROFILE</a></li>
                    <%-- if logged in then this button will be log out --%>
                    <li><a href="login2.aspx">LOGIN</a></li>


                </ul>
            </div>
        </nav>
  
        <h1>About Us</h1>

        



    </section>


    <section class="about-us">
        <div class="row">

            <div class="about-col">
                <h1>WE ARE HERE TO MAKE YOUR DREAMS COME TRUE</h1>
                <p>ndividual Israel Travel Company guides can accompany you for your whole visit or a number of guides can spend a day or more with you as part of a unique world travel experience.
                  Each of our tours is custom designed and we specialize in matching the most suitable recommended guide to the style, needs and interests of each client.</p>
                <a href="Home.aspx" class="visit-btn">Explore More</a>

            </div>
            <div class="about-col">

                <img src="/images/pic1.jpg" />

            </div>


        </div>

    </section>


      <section class="footer"> 
          <h3>All credits to Top-Tours.</h3>
      </section>

    </form>
</body>
</html>
