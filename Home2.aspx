<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" Inherits="toptours1.Home2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>TopTours-Home</title>
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
    <section class="header">
        <nav>
            <a herf="Home2.aspx"><img id="logo" src="imgs/logoWhPNG.png" alt="logo"/></a>
            <div class="nav-links" id="navLinks">
           
                <%-- ul-unordered list --%>
                <ul>
                    <%-- li- list item --%>
                    <li><a href="home2.aspx">HOME</a></li>
                        <li><a href="Places2.aspx">PLACES</a></li>
                        <li><a href="Routes.aspx">ROUTES</a></li>
                        <li><a href="AboutUs2.aspx">ABOUT US</a></li>
                        <li><a href="admins.aspx">ADMINS</a></li>
                    <li><a href="profile.aspx">PROFILE</a></li>
                    <%-- if logged in then this button will be log out --%>
                    <li><a href="Login.aspx">LOGIN</a></li>
                    


                </ul>
            </div>
        </nav>
        <div class="text-box">
            <h1>Welcome To Top Tours!!</h1>
            <p>When was the last time you went on a vacation? When did you leave the routine and travel around the world? <br/> Let us help you gain new experiences!</p>
            <a href="places2.aspx" class="visit-btn">Visit Us To Know More</a>


        </div>
            



    </section>
    

    <section class="places">
        <h1>Our Places</h1>
        <p>When was the last time you visited awesome places? <br/> Let us help you gain new experiences!</p>

        <div class="row">
            <div class="places-col">
                <img src="images/LondonStreet.jpg" />
                <div class="layer"> 
                    <h3>LONDON</h3>
                </div>
            </div>
                 <div class="places-col">
                 <img src="images/EiffelTower.jpg" />
                <div class="layer"> 
                    <h3>PARIS</h3>
                </div>
            </div>
                 <div class="places-col">
                <img src="images/BudapestPar.jpg" />
                <div class="layer"> 
                    <h3>BUDAPEST</h3>
                </div> 
            </div>
        </div>
        
    </section>
      
     <section class="secTwo">
         <h1>Our Routes</h1>
         <p>Come with us and we will showw you the best routes ever and you even have the option to create your own routes!</p>
         <div class="row">
             <div class="secTwo-col">
                 <img src="images/pic1.jpg" />
                 <h3>Switzerland Tour</h3>
                 <p>A vacation adventure in Switzerland should be on everyone's list - from the warm hiking trails of the Swiss Alps to the magical snowy Christmas markets in Zürich. On a tour of Switzerland, you can expect to see unbelieveable scenery, pretty mountain villages, and stunning lakes. Travelers often catch the train for a view like no other on Jungfrau, explore the storybook city of Lucerne, admire the many fountains of Bern, or end the day indulging in a classic fondue in Geneva.</p>


             </div>
             <div class="secTwo-col">
                 <img src="images/pic2.jpg" />
                 <h3>The Netherlands Tour</h3>
                 <p>Start and end in Amsterdam! With the In-depth Cultural tour Best of the Netherlands, you have a 7 days tour package taking you through Amsterdam, Netherlands and 10 other destinations in Netherlands. Best of the Netherlands includes accommodation in a hotel as well as an expert guide, meals, transport and more.</p>


             </div>
             <div class="secTwo-col">
                 <img src="images/pic3.jpg" />
                 <h3>Prague Tour</h3>
                 <p>Take a tour of through Central Europe to explore the beautiful landmarks of Czech Republic. Walk the streets of Prague and discover Bohemia's enchanting towns or Moravia with the neoclassical city of Brno. Your adventure will then take you to the beautiful region of Bavaria in Germany, where Munich is known for hosting the annual Oktoberfest beer festival. You will be introduced to Berlin's art scene and get to meet the locals.</p>


             </div>



         </div>


     </section>

      <section class="reviews">

            <h1>Reviews Of Our Customers </h1>
         <p>Come with us and we will showw you the best routes ever and you even have the option to create your own routes!</p>

          <div class="row">

              <div class="reviews-col">
                  <img src="images/sea.jpg" />
                  <div>
                      <h3>Best Site</h3>
                      <p>Come with us and we will showw you the best routes ever and you even have the option to create your own routes!</p>
                      <h3 class="name">LOL</h3>
                      <% for(int i = 0; i < 5; i++) { %>
                               <i class="fa fa-star"></i>
                        <% } %>
                  </div>
              </div>
                <div class="reviews-col">
                  <img src="images/sea.jpg" />
                  <div>
                      <h3>NICE</h3>
                      <p>Come with us and we will showw you the best routes ever and you even have the option to create your own routes!</p>
                      <h3 class="name">LOL2</h3>
                        <% for(int i = 0; i < 4; i++) { %>
                               <i class="fa fa-star"></i>
                        <% } %>
                           <i class="fa fa-star-o"></i>
                          
                          
                     
                      

                  </div>
              </div>

          </div>


      </section>


      <section class="about">
          <h4>About Us</h4>

          <p>We are the company that will make your day, join us to see more</p>

      </section>


      <section class="footer"> 
          <h3>All credits to Top-Tours.</h3>
      </section>


 





    </form>
    
</body>
</html>
