using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace toptours1
{
    public class bbbbbbb
    {
        private int placeID;
        private string placeName;
        private string placeInfo;
        private float longitude;
        private float latitude;
        private bool isPrivate;
        private List<string> fileNames;
        //I will need url attribute later
        //Get and Set for Class's attributes
        public int PlaceID { get => placeID; set => placeID = value; }
        public string PlaceName { get => placeName; set => placeName = value; }
        public string PlaceInfo { get => placeInfo; set => placeInfo = value; }
        public float Longitude { get => longitude; set => longitude = value; }
        public bool IsPrivate { get => isPrivate; set => isPrivate = value; }
        public float Latitude { get => latitude; set => latitude = value; }
        public List<string> FileNames { get => fileNames; set => fileNames = value; }
        public bbbbbbb(string placeName, string placeInfo, float longitude, float latitude, bool isPrivate)
        {
            this.placeName = placeName;
            this.placeInfo = placeInfo;
            this.longitude = longitude;
            this.latitude = latitude;
            this.isPrivate = isPrivate;
        }
        public bbbbbbb(string placeName, string placeInfo, float longitude, float latitude, bool isPrivate,List<string> fileNames)
        {
            this.placeName = placeName;
            this.placeInfo = placeInfo;
            this.longitude = longitude;
            this.latitude = latitude;
            this.isPrivate = isPrivate;
            this.fileNames = fileNames;
        }
        public bbbbbbb(int PlaceID, string placeName, string placeInfo, float longitude, float latitude, bool isPrivate)
        {
            this.placeID = PlaceID;
            this.placeName = placeName;
            this.placeInfo = placeInfo;
            this.longitude = longitude;
            this.isPrivate = isPrivate;
            this.latitude = latitude;
        }
        public bbbbbbb(int PlaceID, string placeName, string placeInfo)
        {
            this.placeID=PlaceID;
            this.placeName = placeName;
            this.placeInfo = placeInfo;
        }
        public static bbbbbbb AddPlace(string placeName, string placeInfo, float longitude, float latitude, bool isPrivate,int userId)
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
            bbbbbbb p = new bbbbbbb(placeName, placeInfo, longitude, latitude, isPrivate);
            // Close Connection
            con.Close();
            return p;
        }
        public static bbbbbbb AddImageToPlace(string placeName,string url,string fileName,int userId)
        {
            //Add new place to the database
            // Connection
            //There can't be user with the same placeName
            int placeId = bbbbbbb.GetPlaceId(userId, placeName);
            if (placeId == -1)
                return null;
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            string sqlQuerty = $@"SELECT * 
            FROM toptours.images
            Where (fileName={fileName}) AND (user_id='{userId}') AND (place_id='{placeId}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            { return null; }
            // Close Connection
            con.Close();
            con.Open();
            //Command which create new place to the database
            cmd.CommandText = $@"INSERT INTO `toptours`.`images` (`url`, `fileName`, `place_id`, `user_id`) VALUES ('{url}', '{fileName}', '{placeId}', '{userId}');";
            cmd.ExecuteNonQuery();
            con.Close();
            // Close Connection
            List<string> fileNames = bbbbbbb.GetFileNames(userId,placeId);
            fileNames.Add(fileName);
            bbbbbbb p = new bbbbbbb(placeName, bbbbbbb.GetPlaceInfo(userId,placeName), (float)Convert.ToDouble(bbbbbbb.GetLongtitude(userId, placeName)), (float)Convert.ToDouble(bbbbbbb.GetPlaceLatitude(userId, placeName)), bbbbbbb.GetIsPrivate(userId, placeName),fileNames);
            return p;



        }
        public static bbbbbbb UpdatePlaceInfo(string placeName, string newPlaceInfo,int userId)
        {
            //Update User's place info
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select p.place_id,p.placeInfo
            From toptours.places p INNER JOIN toptours.users u
            On p.user_id=u.user_id
            Where(p.user_id='{userId}')And (p.placeName='{placeName}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            bbbbbbb p = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                int id = r.GetInt32(0);
                string placeInfo = r.GetString(1);

                p = new bbbbbbb(id, placeName, placeInfo);
                // Close Connection
                con.Close();
                con.Open();
                //Command which update user's password
                cmd.CommandText = $@"UPDATE `toptours`.`places` SET `placeInfo` = '{newPlaceInfo}' WHERE (`place_id` = '{id}');";
                cmd.ExecuteReader();
                p.placeInfo = newPlaceInfo;
                // Close Connection
                con.Close();
                return p;
            }
            // Close Connection
            con.Close();
            return p;



        }
        public static List<string> GetFileNames(int userId,int placeId)
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
        public static string GetPlaceInfo(int userId,string placeName)
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
        public static bbbbbbb GetPlace(int place_id)
        {
            //Show PlaceInfo
            // Connection
            bbbbbbb p = null;
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
                p = new bbbbbbb(place_id, placeName, placeInfo, longitude, latitude, isPrivate);
                // Close Connection
                con.Close();
                return p;
            }
            return p;
        }
        public static string ShowAllMyPlaces(Customer c)
        {
            string s = "";
            //Show PlaceInfo
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT place_id
            From toptours.places
            Where (user_id='{c.CustomerID}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    bbbbbbb p = GetPlace(r.GetInt32(0));
                    s += p.ToString();
                }
            }
            return s;
        }
        public static List<bbbbbbb> GetAllMyPlaces(Customer c)
        {
            List<bbbbbbb> places =new List<bbbbbbb>();
            //Show PlaceInfo
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT place_id
            From toptours.places
            Where (user_id='{c.CustomerID}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    bbbbbbb p = GetPlace(r.GetInt32(0));
                    places.Add(p);
                }
            }
            return places;
        }
        public static bbbbbbb GetPlace(string placeName)
        {
            //Show PlaceInfo
            // Connection
            bbbbbbb p = null;
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
                p = new bbbbbbb(place_id, placeName, placeInfo, longitude, latitude, isPrivate);
                // Close Connection
                con.Close();
                return p;
            }
            return p;
        }
        public static List<bbbbbbb> SearchPlace(string placeName)
        {
            List<bbbbbbb> places = new List<bbbbbbb>();
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select place_id
            From toptours.places
            where placeName like '%{placeName}%'";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    bbbbbbb p = GetPlacer.GetInt32(0));
                    places.Add(p);
                }
            }
            return places;
        }
        public static void DeletePlaceFromRoute(string placeName,int userId)
        {
            int id=GetPlaceId( userId,placeName);
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
            DeletePlaceFromRoute(placeName,userId);
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
