<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Routes2.aspx.cs" Inherits="toptours1.Routes1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Routes</title>
    <link href="StyleSheets/SSHome.css" rel="stylesheet" />
    <link href="StyleSheets/SSPlace.css" rel="stylesheet" />
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
                    <asp:BulletedList ID="BulletedList2"  runat="server"></asp:BulletedList>
                       <asp:Button ID="IsLogged" runat="server" class="btnlog" Text="" OnClick="IsLogged_Click" />
                </ul>
            </div>
        </nav>
  
        <h1>Routes</h1>

     </section>

     <section class="addPlace">
            <div class="row">

                <div class="comment-col">
                    
                    <h3>Add Route</h3>

                    <div class="comment-form">

                        <input type="text" autocomplete="off" id="Name" runat="server" placeholder="Enter route name" />
                           <input type="text" autocomplete="off" id="Title" runat="server" placeholder="Enter route title" />
                          <textarea rows="6" autocomplete="off" id="Info" runat="server" placeholder="Enter route info"></textarea>
                         

            </div>
                         <asp:Button ID="AddBtn" runat="server" Text="Post" class="visit-btn" OnClick="AddBtn_Click" style="background:black; color:white;" />


                    </div>

                </div>
            


        </section>

        <section class="placesPage" >
            <h1>My Routes</h1>

            <div class="myPlaces">
                   
                           <% if (lst != null)
                           {  %>
                              <% for (int i = 0; i < lst.Count; i++)
                                  { %>
                                         <a href="RouteUpdate.aspx?name=<%=lst[i].RouteName %>"><%=lst[i].RouteName %></a>

                              <% } %>

                          <% } %>

             </div>
        </section>
         <section class="placesPage" >
            <h1>My Favorite Routes</h1>

            <div class="myPlaces">
                   
                           <% if (lst != null)
                           {  %>
                              <% for (int i = 0; i < lstFav.Count; i++)
                                  { %>
                                         <a href="RouteUpdate.aspx?name=<%=lstFav[i] %>"><%=lstFav[i] %></a>

                              <% } %>

                          <% } %>

             </div>
        </section>


        <section>
            <div class="example">
            <h1>Search Routes</h1>
            <input type="text" id="searchValue" autocomplete="off" runat="server" placeholder="Search.." name="search"/>
            <asp:Button ID="SearchBtn"  class="btnSearch" runat="server" Text="🔎" OnClick="SearchBtn_Click" /><br />
                <div >
                    <br />
                    <asp:BulletedList ID="BulletedList1" class="resultBL" runat="server"></asp:BulletedList>

                </div>
            </div>
        </section>


      <section class="footer"> 
          <h3>All credits to Top-Tours.</h3>
      </section>

    </form>
</body>
</html>
