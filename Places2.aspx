<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Places2.aspx.cs" Inherits="toptours1.Places2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Places</title>
    <%-- Main css --%>
    <link href="StyleSheets/SSHome.css" rel="stylesheet" />
    <%-- Custom css fot this page only --%>
    <link href="StyleSheets/SSPlace.css" rel="stylesheet" />
    <%-- css for the map --%>
    <link href="StyleSheets/SSMap.css" rel="stylesheet" />

    <%-- Mapbox API --%>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet"/>
    <script src='https://api.tiles.mapbox.com/mapbox-gl-js/v2.8.1/mapbox-gl.js'></script>
    <link href='https://api.tiles.mapbox.com/mapbox-gl-js/v2.8.1/mapbox-gl.css' rel='stylesheet' />

    <%-- fontawesome and bootstrap --%>
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
                <ul>
                    <li><a href="home2.aspx">HOME</a></li>
                        <li><a href="PlacesPage.aspx">PLACES</a></li>
                        <li><a href="Routes.aspx">ROUTES</a></li>
                        <li><a href="AboutUs2.aspx">ABOUT US</a></li>
                        <li><a href="admins.aspx">ADMINS</a></li>
                    <li><a href="profile.aspx">PROFILE</a></li>
                    <li><a href="login2.aspx">LOGIN</a></li>
                </ul>
            </div>
        </nav>
  
        <h1>Places</h1>
    </section>
      

        <section class="myMap">

            <div class="row">

            <div id='map'></div>

           </div>


        </section>


        <section class="addPlace">
            <div class="row">

                <div class="comment-col">

                    <h3>Add Place</h3>

                    <div class="comment-form">
                        <input type="text" autocomplete="off" id="longitude" runat="server" placeholder="Longitude" />
                        <input type="text" autocomplete="off" id="latitude" runat="server" placeholder="Latitude" />
                        <input type="text" autocomplete="off" id="Name" runat="server" placeholder="Enter place name" />
                          <textarea rows="6" autocomplete="off" id="Info" runat="server" placeholder="Enter place info"></textarea>
                           <h2>Is private?</h2>
                            
                          <label class="container">Yes
                         <asp:RadioButton GroupName="gi" ID="RadioButton1" runat="server" Checked="true"  />
                         <span class="checkmark"></span>
                          </label>
                         <label class="container">No
                          <asp:RadioButton GroupName="gi" ID="RadioButton2" runat="server" Checked="false" />
                           <span class="checkmark"></span>
                          </label>
                         <asp:Button ID="AddBtn" runat="server" Text="Post" class="visit-btn" OnClick="AddBtn_Click" style="background:black; color:white;" />


                    </div>

                </div>
             </div>


        </section>

        <section class="placesPage" >
            <h1>My Places</h1>
            <div class="myPlaces">
                   
                           <% if (lst != null)
                {  %>
                              <% for (int i = 0; i < lst.Count; i++)
                                  { %>
                               <a href="ShowPlace2.aspx?name=<%=lst[i].PlaceName %>"><%=lst[i].PlaceName %></a>

                              <% } %>

                          <% } %>

            </div>
        </section>


        <section "placesPage2">
            <div class="example">
            <h1>Search Places</h1>
            <input type="text" id="searchValue" autocomplete="off" runat="server" placeholder="Search.." name="search"/>
            <asp:Button ID="SearchBtn"  class="btnSearch" runat="server" Text="🔎" OnClick="SearchBtn_Click" />
                <div class="result">
                <asp:BulletedList ID="BulletedList1" class="resultBL" runat="server"></asp:BulletedList>

                </div>
            </div>
        </section>

   








    


      <section class="footer"> 
          <h3>All credits to Top-Tours.</h3>
      </section>

    </form>
    <%-- Script for the map to work --%>
    <script>

        mapboxgl.accessToken = 'pk.eyJ1IjoiYXJ0ZW0wNCIsImEiOiJjbDBqZWptMTAwYnJnM2ltcm5iZ3hnYnhtIn0.a9TmhlV1Y7TISvmU67EEDA';

     const map = new mapboxgl.Map({
     container: 'map',
         style: 'mapbox://styles/artem04/cl2t4kak6003a14o9w5x6ll87',
         center: [35.03707246726779, 32.79384590789712],
     zoom: 3
     });

        const geojson = {
            type: 'FeatureCollection',
            features: [
                {
                    type: 'Feature',
                    geometry: {
                        type: 'Point',
                        coordinates: [35.03707246726779, 32.79384590789712]
                    },
                    properties: {
                        title: 'Mapbox',
                        description: 'Israel, Haifa Bay central bus station'
                    }
                },
                //{
                //    type: 'Feature',
                //    geometry: {
                //        type: 'Point',
                //        coordinates: [-122.414, 37.776]
                //    },
                //    properties: {
                //        title: 'Mapbox',
                //        description: 'San Francisco, California'
                //    }
                //}
            ]
        };

        // add markers to map
        for (const feature of geojson.features) {
            // create a HTML element for each feature
            const el = document.createElement('div');
            el.className = 'marker';

            // make a marker for each feature and add to the map
            new mapboxgl.Marker(el).setLngLat(feature.geometry.coordinates)
                .setPopup(
                    new mapboxgl.Popup({ offset: 25 }) // add popups
                        .setHTML(
                            `<h3>${feature.properties.title}</h3><p>${feature.properties.description}</p>`
                        )
                )
                .addTo(map);
        }

    </script>







</body>
</html>