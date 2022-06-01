using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace toptours1
{
    public class Place
    {
        private int placeID;
        private string placeName;
        private string placeInfo;
        private float longitude;
        private float latitude;
        private bool isPrivate;
        private string fileName;
        //I will need url attribute later
        //Get and Set for Class's attributes
        public int PlaceID { get => placeID; set => placeID = value; }
        public string PlaceName { get => placeName; set => placeName = value; }
        public string PlaceInfo { get => placeInfo; set => placeInfo = value; }
        public float Longitude { get => longitude; set => longitude = value; }
        public bool IsPrivate { get => isPrivate; set => isPrivate = value; }
        public float Latitude { get => latitude; set => latitude = value; }
        public string FileNames { get => fileName; set => fileName = value; }
        public Place(string placeName, string placeInfo, float longitude, float latitude, bool isPrivate)
        {
            this.placeName = placeName;
            this.placeInfo = placeInfo;
            this.longitude = longitude;
            this.latitude = latitude;
            this.isPrivate = isPrivate;
        }
        public Place(string placeName, string placeInfo, float longitude, float latitude, bool isPrivate, string fileName)
        {
            this.placeName = placeName;
            this.placeInfo = placeInfo;
            this.longitude = longitude;
            this.latitude = latitude;
            this.isPrivate = isPrivate;
            this.fileName = fileName;
        }
        public Place(int PlaceID, string placeName, string placeInfo, float longitude, float latitude, bool isPrivate)
        {
            this.placeID = PlaceID;
            this.placeName = placeName;
            this.placeInfo = placeInfo;
            this.longitude = longitude;
            this.isPrivate = isPrivate;
            this.latitude = latitude;
        }
        public Place(int PlaceID, string placeName, string placeInfo)
        {
            this.placeID = PlaceID;
            this.placeName = placeName;
            this.placeInfo = placeInfo;
        }
        public Place() { }
        public static Place AddPlace(string placeName, string placeInfo, float longitude, float latitude, bool isPrivate, int userId,string url)
        {

            //Add new place to the database
            // Connection
            //There can't be user with the same placeName
            int num = 0;
            if (isPrivate)
                num = 1;
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            string sqlQuerty = $@"select p.placeInfo,u.user_id
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            { return null; }
            // Close Connection
            con.Close();
            con.Open();
            //Command which create new place to the database
            cmd.CommandText = $@"INSERT INTO `toptours`.`places` (`placeName`, `placeInfo`, `longitude`, `latitude`, `isPrivate`, `user_id`) VALUES ('{placeName}', '{placeInfo}', '{longitude}', '{latitude}', '{num}', '{userId}');";
            cmd.ExecuteNonQuery();
            con.Close();
            AddImageToPlace(placeName, url, userId);
            Place p = new Place(placeName, placeInfo, longitude, latitude, isPrivate,url);
            // Close Connection
            con.Close();
            return p;
        }
        public static void AddImageToPlace(string placeName, string fileName, int userId)
        {
            // Connection
            Place p =GetPlace(placeName);
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which delets all user's pictures for good
            string sqlQuerty = $@"INSERT INTO `toptours`.`images` (`fileName`, `place_id`, `user_id`) VALUES ('{fileName}', '{p.PlaceID}', '{userId}');
";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();





        }
        public static List<Place> GetAllMyPlaces(Customer c)
        {
            List<Place> places = new List<Place>();
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.placeName
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{c.CustomerID}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Place p = GetPlace(r.GetString(0));
                    places.Add(p);
                }
            }
            return places;
        }
        public static void UpdatePlaceInfo( string newPlaceInfo,int place_id, int userId)
        {
            //Update User's place info
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.placeInfo
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.place_id='{place_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                // Close Connection
                con.Close();
                con.Open();
                //Command which update user's password
                cmd.CommandText = $@"UPDATE `toptours`.`places` SET `placeInfo` = '{newPlaceInfo}' WHERE (`place_id` = '{place_id}');";
                cmd.ExecuteReader();
                // Close Connection
                con.Close();
               
            }
            // Close Connection
            con.Close();
           



        }
        public static void UpdateIsPrivate(bool isPrivate, int place_id, int userId)
        {
            //Update User's place info
            int value=0;
            if (isPrivate) { value = 1; }
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.isPrivate
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.place_id='{place_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                // Close Connection
                con.Close();
                con.Open();
                //Command which update user's password
                cmd.CommandText = $@"UPDATE `toptours`.`places` SET `isPrivate` = '{value}' WHERE (`place_id` = '{place_id}');";
                cmd.ExecuteReader();
                // Close Connection
                con.Close();

            }
            // Close Connection
            con.Close();
        }
        public static void UpdatePlaceName(string placeName,int place_id,int userId)
        {
            //Update User's place info
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.placeName
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.place_id='{place_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                // Close Connection
                con.Close();
                con.Open();
                //Command which update user's password
                cmd.CommandText = $@"UPDATE `toptours`.`places` SET `placeName` = '{placeName}' WHERE (`place_id` = '{place_id}');";
                cmd.ExecuteReader();
                // Close Connection
                con.Close();
            }
            // Close Connection
            con.Close();



        }
        public static List<string> GetFileNames(int userId, int placeId)
        {
            // Connection
            List<string> fileNames = new List<string>();
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if route and place created by the same user
            string sqlQuerty = $@"SELECT fileName 
            FROM toptours.images
            Where(place_id='{placeId}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                fileNames.Add(r.GetString(0));
            }
            // Close Connection
            con.Close();
            return fileNames;
        }
        public static string GetPlaceInfo(int userId, string placeName)
        {
            //Show PlaceInfo
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select u.user_id,p.placeInfo
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                string placeInfo = r.GetString(1);
                // Close Connection
                con.Close();
                return placeInfo;
            }
            return "You did not created place with that name";
        }
        public static string GetPlaceLatitude(int userId, string placeName)
        {
            //Show PlaceInfo
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.latitude
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                string latitude = r.GetString(1);
                // Close Connection
                con.Close();
                return latitude;
            }
            return "You did not created place with that name";
        }
        public static bool GetIsPrivate(int userId, string placeName)
        {
            //Show PlaceInfo
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.isPrivate
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                bool isPrivate = r.GetBoolean(0);
                // Close Connection
                con.Close();
                return isPrivate;
            }
            return false;
        }
        public static string GetLongtitude(int userId, string placeName)
        {
            //Show PlaceInfo
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.longtitude
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                string longtitude = r.GetString(1);
                // Close Connection
                con.Close();
                return longtitude;
            }
            return "You did not created place with that name";
        }
        public static int GetPlaceId(int userId, string placeName)
        {
            //Show PlaceInfo
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.place_id
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                int placeID = r.GetInt32(0);
                // Close Connection
                con.Close();
                return placeID;
            }
            return -1;
        }
        public static string GetPlaceImage(int customer_id,int place_id)
        {
            // Connection
            string str = "defualt.png";
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT fileName
            FROM toptours.images
            Where (user_id='{customer_id}') AND (place_id='{place_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                str = r.GetString(0);
            }
            // Close Connection
            con.Close();
            return str;
        }
        public static Place GetPlace(int place_id)
        {
            //Show PlaceInfo
            // Connection
            Place p = null;
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT *
            From toptours.places
            Where (place_id='{place_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                string placeName = r.GetString(1);
                string placeInfo = r.GetString(2);
                float longitude = r.GetFloat(3);
                float latitude = r.GetFloat(4);
                bool isPrivate = r.GetBoolean(5);
                p = new Place(place_id, placeName, placeInfo, longitude, latitude, isPrivate);
                // Close Connection
                con.Close();
                return p;
            }
            return p;
        }
        public static Place GetPlace(string placeName)
        {
            //Show PlaceInfo
            // Connection
            Place p = null;
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT *
            From toptours.places
            Where (placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                int place_id = r.GetInt32(0);
                string placeInfo = r.GetString(2);
                float longitude = r.GetFloat(3);
                float latitude = r.GetFloat(4);
                bool isPrivate = r.GetBoolean(5);
                p = new Place(place_id, placeName, placeInfo, longitude, latitude, isPrivate);
                // Close Connection
                con.Close();
                return p;
            }
            return p;
        }
     
        public static List<Place> SearchPlace(string placeName)
        {
            List<Place> places = new List<Place>();
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select placeName
            From toptours.places
            where placeName like '%{placeName}%'";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Place p = GetPlace(r.GetString(0));
                    places.Add(p);
                }
            }
            return places;
        }
        public static List<Place> SearchMyPlace(string placeName,int user_id)
        {
            List<Place> places = new List<Place>();
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select placeName
            From toptours.places
            where placeName like '%{placeName}%' AND (user_id='{user_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Place p = GetPlace(r.GetString(0));
                    places.Add(p);
                }
            }
            return places;
        }
        public static void DeletePlaceFromRoute(string placeName, int userId)
        {
            int id = GetPlaceId(userId, placeName);
            //Delete My Place
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"DELETE FROM `toptours`.`routeplace` WHERE (place_id='{id}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        public static bool DeletePlace(string placeName, int userId)
        {
            DeletePlaceFromRoute(placeName, userId);
            //Delete My Place
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.place_id
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                int id = r.GetInt32(0);
                // Close Connection
                con.Close();
                con.Open();
                //Command which delete user from database
                cmd.CommandText = $@"DELETE FROM `toptours`.`places` WHERE (`place_id` = '{id}');";
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

        public override string ToString()
        {
            //Show all the info about customer
            string s = "<br/>PlaceID: " + placeID.ToString();
            s += "<br/>PlaceName: " + placeName;
            s += "<br/>PlaceInfo: " + placeInfo;
            s += "<br/>Longitude: " + longitude;
            s += "<br/>Latitude: " + latitude;
            s += "<br/>Is Private?: " + isPrivate;
            return s;

        }


    }
}