<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="toptours1.ContactUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Contact Us</title>
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
                    <li><a href="Home2.aspx">HOME</a></li>
                        <li><a href="Places2.aspx">PLACES</a></li>
                        <li><a href="Routes2.aspx">ROUTES</a></li>
                        <li><a href="AboutUs2.aspx">ABOUT US</a></li>
                        <li><a href="ContactUs2.aspx">ABOUT US</a></li>
                    <%-- If Customer is logged in then the log out text will be shown and new link --%>
                    <% if (Session["customer"] != null)
                             {  %>
                                    <li><a href="Profile2.aspx">PROFILE</a></li>
                                    <li><a href="Admins2.aspx">ADMINS</a></li>
                                     <li><a href="Login.aspx"><%="LOG OUT" %></a></li>

                          <% } %>

                    <% if (Session["customer"] == null)
                             {  %>
                                    
                                     <li><a href="Login.aspx"><%="LOGIN" %></a></li>

                          <% } %>
                     
                                                      





                        


                </ul>
            </div>
        </nav>
  
        <h1>Contact Us</h1>

        



    </section>


    <section class="location">

        <h3>Our Office Location</h3>

        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1679.2873091999995!2d35.24492659453825!3d32.6707622451717!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x151c52995d79ac95%3A0x71a443709ffc6df7!2z15DXldeo15gg16jXldeS15XXlteZ158g157XkteT15wg15TXotee16c!5e0!3m2!1siw!2sil!4v1651937940049!5m2!1siw!2sil" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>


    </section>
       
    <section class="contact-us">

        <div class="row">
            <div class="contact-col">
                
                <div>
                     <i class="fa fa-home"></i>
                
                    <h5>TopTours, Migdal Haemek</h5>
                    
                  
                </div>

                <div>
                     <i class="fa fa-phone"></i>
                
                    <h5>1111 Working 24/7 hours</h5>
                    
                  
                </div>
                 <div>
                     <i class="fa fa-envelope-o"></i>
                
                    <h5>infoTopTours@gmail.com</h5>
                </div>
            </div>


            <div class="contact-col">
                <h3>Write Us A Message</h3>
                <input type="text" placeholder="Enter Your Name" required="" />
                <input type="email" placeholder="Enter Your Email" required="" />
                <input type="text" placeholder="Enter Your Subject" required="" />
                <textarea rows="8" placeholder="Message" required=""></textarea>
                <asp:Button ID="Button1" class="visit-btn" runat="server" Text="SEND" />
               

            </div>

        </div>

    </section>



   


      <section class="footer"> 
          <h3>All credits to Top-Tours.</h3>
      </section>

    </form>
</body>
</html>
