<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMap.aspx.cs" Inherits="toptours1.ShowMap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Map</title>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet"/>
    <script src='https://api.tiles.mapbox.com/mapbox-gl-js/v2.8.1/mapbox-gl.js'></script>
    <link href='https://api.tiles.mapbox.com/mapbox-gl-js/v2.8.1/mapbox-gl.css' rel='stylesheet' />
    <link href="StyleSheets/SSMap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     
       <h1>My API Map</h1>  

            <div id='map'></div>








      
    </form>


    <script>

        mapboxgl.accessToken = 'pk.eyJ1IjoiYXJ0ZW0wNCIsImEiOiJjbDBqZWptMTAwYnJnM2ltcm5iZ3hnYnhtIn0.a9TmhlV1Y7TISvmU67EEDA';

     const map = new mapboxgl.Map({
     container: 'map',
         style: 'mapbox://styles/artem04/cl2t4kak6003a14o9w5x6ll87',
     center: [-96, 37.8],
     zoom: 3
     });

        const geojson = {
            type: 'FeatureCollection',
            features: [
                {
                    type: 'Feature',
                    geometry: {
                        type: 'Point',
                        coordinates: [-77.032, 38.913]
                    },
                    properties: {
                        title: 'Mapbox',
                        description: 'Washington, D.C.'
                    }
                },
                {
                    type: 'Feature',
                    geometry: {
                        type: 'Point',
                        coordinates: [-122.414, 37.776]
                    },
                    properties: {
                        title: 'Mapbox',
                        description: 'San Francisco, California'
                    }
                }
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
