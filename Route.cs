using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace toptours1
{
    public class Route
    {
        private List<Place> places;
        private int routeID;
        private string routeName;
        private string routeTitle;
        private string routeInfo;
        private bool IsFavorite;
        public Route(List<Place> places, int routeID, string routeName, string routeTitle, string routeInfo)
        {
            this.places = places;
            this.routeID = routeID;
            this.routeName = routeName;
            this.routeTitle = routeTitle;
            this.routeInfo = routeInfo;
        }
        public Route(string routeName, string routeTitle, string routeInfo)
        {
            this.routeName = routeName;
            this.routeTitle = routeTitle;
            this.routeInfo = routeInfo;
        }
        public Route()
        {

        }
        public List<Place> Places { get => places; set => places = value; }
        public int RouteID { get => routeID; set => routeID = value; }
        public string RouteName { get => routeName; set => routeName = value; }
        public string RouteTitle { get => routeTitle; set => routeTitle = value; }
        public string RouteInfo { get => routeInfo; set => routeInfo = value; }
        public bool IsFavorite1 { get => IsFavorite; set => IsFavorite = value; }

        public static Route AddRoute(Customer c, string routeName, string routeTitle, string routeInfo)
        {
            //Add new route to the database
            // Connection
            //There can't be user with the same placeName
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            string sqlQuerty = $@"select r.routeName,u.user_id
            From toptours.routes r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.user_id='{c.CustomerID}')And (r.routeName='{routeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            { return null; }
            // Close Connection
            con.Close();
            con.Open();
            //Command which create new place to the database
            cmd.CommandText = $@"INSERT INTO `toptours`.`routes` (`user_id`, `routeName`, `routeTitle`, `route_info`) VALUES ('{c.CustomerID}', '{routeName}', '{routeTitle}', '{routeInfo}');";
            cmd.ExecuteNonQuery();
            con.Close();
            Route route = new Route(routeName, routeTitle, routeInfo);
            // Close Connection
            con.Close();
            return route;
        }
        public bool AddPlaceToRoute(Place p, Customer c)
        {
            int placeOrderId = 1;
            if (!IsCreatedBySameUser(c, p.PlaceName))
                return false;
            if (PlaceInRoute(p.PlaceID))
                return false;
            if (this.places != null)
                placeOrderId = NextPlaceOrder(this.routeID);
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if route and place created by the same user
            string sqlQuerty = $@"INSERT INTO `toptours`.`routeplace` (`route_id`, `place_id`, `placeOrder`) VALUES ('{routeID}', '{p.PlaceID}', '{placeOrderId}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteNonQuery(); ;
            this.places.Add(p);
            // Close Connection
            con.Close();
            return true;
        }
        public void DoFavoriteRoute()
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if route and place created by the same user
            string sqlQuerty = $@"UPDATE `toptours`.`routes` SET `IsFavorite` = '1' WHERE (`route_id` = '{routeID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            // Close Connection
            con.Close();
            this.IsFavorite = true;
        }
        public static List<Place> GetPlacesLst(int route_id)
        {
            // Connection
            List<Place> places = new List<Place>();
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if route and place created by the same user
            string sqlQuerty = $@"SELECT placeOrder,place_id
            From toptours.routeplace
            Where (route_id='{route_id}')
            order by placeOrder ASC";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                int place_id = r.GetInt32(1);
                Place p = Place.GetPlace(place_id);
                places.Add(p);
            }
            // Close Connection
            con.Close();
            return places;
        }
        public static string GetRouteNameByID(Customer c,int route_id)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if route and place created by the same user
            string sqlQuerty = $@"select r.routeName
            From toptours.routes r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.user_id='{c.CustomerID}')And (r.route_id='{route_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                return r.GetString(0);
            }
            // Close Connection
            con.Close();
            return "NO DATA";
        }
        //public static string GetRouteInfo(int user_id, string routeName)
        //{
        //    // Connection
        //    MySqlConnection con = new MySqlConnection(ServerNames.CDB);
        //    //Command which checks if route and place created by the same user
        //    string sqlQuerty = $@"select r.route_info
        //    From toptours.routes r INNER JOIN toptours.users u
        //    On r.user_id=u.user_id
        //    Where(r.user_id='{user_id}')And (r.routeName='{routeName}')";
        //    MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
        //    con.Open();
        //    MySqlDataReader r = cmd.ExecuteReader();
        //    if (r.Read())
        //    {
        //        //User In dataBase
        //        return r.GetString(0);
        //    }
        //    // Close Connection
        //    con.Close();
        //    return "NO DATA";
        //}
        //public static string GetRouteTitle(int user_id, string routeName)
        //{
        //    // Connection
        //    MySqlConnection con = new MySqlConnection(ServerNames.CDB);
        //    //Command which checks if route and place created by the same user
        //    string sqlQuerty = $@"select r.routeTitle
        //    From toptours.routes r INNER JOIN toptours.users u
        //    On r.user_id=u.user_id
        //    Where(r.user_id='{user_id}')And (r.routeName='{routeName}')";
        //    MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
        //    con.Open();
        //    MySqlDataReader r = cmd.ExecuteReader();
        //    if (r.Read())
        //    {
        //        //User In dataBase
        //        return r.GetString(0);
        //    }
        //    // Close Connection
        //    con.Close();
        //    return "NO DATA";
        //}

        public bool IsCreatedBySameUser(Customer c, string placeName)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if route and place created by the same user
            string sqlQuerty = $@"select p.placeName,u.user_id,r.routeName
            From toptours.places p INNER JOIN toptours.users u INNER JOIN toptours.routes r
            On p.user_id=u.user_id AND r.user_id=u.user_id
            Where(p.user_id='{c.CustomerID}')And (p.placeName='{placeName}') AND (r.user_id='{c.CustomerID}') AND (r.routeName='{this.routeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User created route and place
                return true;
            }
            // Close Connection
            con.Close();
            return false;
        }
        public bool PlaceInRoute(int place_id)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks whether place is in route
            string sqlQuerty = $@"SELECT routeplace_id
            From toptours.routeplace
            Where (route_id='{routeID}') AND (place_id='{place_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                return true;
            }
            // Close Connection
            con.Close();
            return false;
        }
        public static List<Route> SearchRoute(string routeName)
        {
            List<Route> routes = new List<Route>();
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select routeName
            From toptours.routes
            where routeName like '%{routeName}%'";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Route ro=GetRoute(r.GetString(0));
                    routes.Add(ro);
                }
            }
            return routes;
        }
        public static bool IsRouteHasPlaces(int route_id)
        {
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select *
            From toptours.routeplace
            Where (route_id='{route_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                return true;
            }
            // Close Connection
            con.Close();
            //incorrect email/password
            return false;
        }
        public static int NextPlaceOrder(int route_id)
        {
            if (!IsRouteHasPlaces(route_id))
                return 1;
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT max(placeOrder)+1 AS 'nextPlace'
                From toptours.routeplace
                Where (route_id='{route_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                return r.GetInt32(0);
            }
            // Close Connection
            con.Close();
            //incorrect email/password
            return -1;
        }
        public bool DeleteRouteFromPlaces()
        {
            //Delete My Place
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT routeplace_id
            From toptours.routeplace
            Where (route_id='{routeID}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                //User In dataBase
                int routeplaceId = r.GetInt32(0);

                // Close Connection
                con.Close();
                con.Open();
                //Command which delete user from database
                cmd.CommandText = $@"DELETE FROM `toptours`.`routeplace` WHERE (`routeplace_id` = '{routeplaceId}');";
                cmd.ExecuteReader();
                // Close Connection
                con.Close();
                //Place Deleted
                return true;
            }
            // Close Connection
            con.Close();
            //incorrect email/password
            return false;
        }
        public static bool ReviewOnRoutes(int route_id, int user_id)
        {
            //Delete My Place
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select r.review_id    
            From toptours.reviews r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.user_id='{user_id}')And (r.route_id='{route_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
                return true;
            // Close Connection
            con.Close();
            //incorrect email/password
            return false;
        }

        public static bool DeleteRouteFromReviews(int routeId, int userId)
        {
            ////Delete My Place
            //// Connection
            //MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            ////Command which checks if user already signed in by email and password
            //string sqlQuerty = $@"select r.caption  
            //From toptours.reviews r INNER JOIN toptours.users u
            //On r.user_id=u.user_id
            //Where(r.user_id='{userId}')And (r.route_id='{routeId}')";
            //MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            //con.Open();
            //MySqlDataReader r = cmd.ExecuteReader();
            //if (r.Read())
            //{
            //    //User In dataBase
            //    string caption = r.GetString(0);
            //    // Close Connection
            //    con.Close();

            //    //Command which delete user from database
            //    if (Review.DeleteReview(caption,userId))
            //        return true;
            //}
            //// Close Connection
            //con.Close();
            ////incorrect email/password
            //return false;
            return true;
        }
        public static bool InRoutePlaces(int route_id, int userId)
        {
            //Delete My Place
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT routeplace_id
            From toptours.routeplace
            Where (route_id='{route_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                return true;
            }
            // Close Connection
            con.Close();
            //incorrect email/password
            return false;
        }
        public bool DeleteRoute(string routeName, int userId)
        {
            if (!ReviewOnRoutes(routeID, userId) && !DeleteRouteFromReviews(routeID, userId))
                return false;
            if (!InRoutePlaces(routeID, userId) && !DeleteRouteFromPlaces())
                return false;

            //Delete My Place
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select r.routeName,r.user_id
            From toptours.routes r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.user_id='{userId}')And (r.routeName='{routeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                // Close Connection
                con.Close();
                con.Open();
                //Command which delete user from database
                cmd.CommandText = $@"DELETE FROM `toptours`.`routes` WHERE (`route_id` = '{this.RouteID}');";
                cmd.ExecuteReader();
                // Close Connection
                con.Close();
                //Place Deleted
                return true;
            }
            // Close Connection
            con.Close();
            //incorrect email/password
            return false;
        }
        public static List<string> ShowFavorite(Customer c)
        {
           List<string> s= new List<string>();
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select r.routeName
            From toptours.routes r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.IsFavorite='1')AND(r.user_id='{c.CustomerID}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    
                       s.Add( r.GetString(0));
                }
            }
            return s;
        }
        public static List<Route> GetAllRoutes(Customer c)
        {
            List<Route> routes = new List<Route>();
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select r.routeName
            From toptours.routes r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.user_id='{c.CustomerID}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Route route = GetRoute(r.GetString(0));
                    routes.Add(route);
                }
            }
            return routes;
        }
        public static Route GetRoute(string routeName)
        {
            Route route = null;
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select *
            From toptours.routes r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.routeName='{routeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                int routeID = r.GetInt32(0);
                string routeInfo = r.GetString(4);
                string title = r.GetString(3);
                route = new Route(GetPlacesLst(routeID), routeID, routeName, title, routeInfo);
                // Close Connection
                con.Close();
            }
            return route;
        }
        public void UpdateRouteInfo(string newRouteInfo)
        {
            ////Update User's place info
            //// Connection
            //MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            ////Command which checks if user already signed in by email and password
            //string sqlQuerty = $@"select r.route_info
            //From toptours.routes r INNER JOIN toptours.users u
            //On r.user_id=u.user_id
            //Where(r.user_id='{c.CustomerID}')And (r.routeName='{routeName}')";
            //MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            //Route route = null;
            //con.Open();
            //MySqlDataReader r = cmd.ExecuteReader();
            //if (r.Read())
            //{
            //    //Place In dataBase
            //    string routeInfo = r.GetString(0);
            //    con.Close();
            //    con.Open();
            //    //Command which update user's password
            //    cmd.CommandText = $@"UPDATE `toptours`.`routes` SET `route_info` = '{newRouteInfo}' WHERE (`route_id` = '{this.routeID}');";
            //    cmd.ExecuteReader();
            //    route.routeInfo = newRouteInfo;
            //    // Close Connection
            //    con.Close();
            //}
            //// Close Connection
            //con.Close();
            //return route;


            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which delets all user's pictures for good
            string sqlQuerty = $@"UPDATE `toptours`.`routes` SET `route_info` = '{newRouteInfo}' WHERE (`route_id` = '{this.routeID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            RouteInfo = routeInfo;
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        public override string ToString()
        {
            //Show all the info about customer
            string s = "<br/>RouteID: " + routeID.ToString();
            s += "<br/>RouteName: " + RouteName;
            s += "<br/>RouteInfo: " + routeInfo;
            s += "<br/>RouteTitle: " + routeTitle;
            s += "<br/>Is Favorite?: " + IsFavorite;
            s += "<br/>Places In Route: ";
            for (int i = 0; i < places.Count; i++)
                s += places[i].PlaceName;
            return s;
        }
    }
}
