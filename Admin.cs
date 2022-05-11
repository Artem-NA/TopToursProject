using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace toptours1
{
    public class Admin : Customer
    {
        //admin have to:
        //control the website
        //requirements :skill - when user was first signed in(time) , honesty
        //add new routes
        // add new user to be admin
        // delete route /review/ user/ place/ picture
        public Admin(string firstName, string lastName, string username, string password, string email,string imgProfile) : base(firstName, lastName, username, password, email,imgProfile)
        {
        }
        public Admin(string firstName, string lastName, string username, string password, string email) : base(firstName, lastName, username, password, email)
        {

        }
        //WORKING PROPERLY
        //public static void AddNewAdmin(string username,string experince)
        //{
        //    // Connection
        //    MySqlConnection con = new MySqlConnection(ServerNames.CDB);
        //    //Command which delets all user's pictures for good
        //    string sqlQuerty = $@"UPDATE `toptours`.`users` SET `IsAdmin` = '1' WHERE (username = '{username}');";
        //    MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
        //    con.Open();
        //    cmd.ExecuteReader();
        //    con.Close();
        //    //incorrect email/password
        //}
        
        public static void RequestToBeAdmin(string username,string applicationMsg)
        { 
            //Adding the application message to the given username in the database and inform admins that this user would like to be admin
            string sqlQuerty = 
            $@"UPDATE `toptours`.`users` SET `IsAdmin` = '0', `aboutUser` = '{applicationMsg}' WHERE (username = '{username}');";
            ConnectionToSql(sqlQuerty);
        }
        public static void NewAdmin(string user_id,bool decision)
        {
            //if admin accepted the application then user is new admin.Otherwise user is not admin
            string sqlQuerty = $@"UPDATE `toptours`.`users` SET `IsAdmin` = '-1' WHERE (user_id = '{user_id}');";
            if(decision)
            {
                sqlQuerty = $@"UPDATE `toptours`.`users` SET `IsAdmin` = '1' WHERE (user_id = '{user_id}');";
                ConnectionToSql(sqlQuerty);
                return;
            }
            ConnectionToSql(sqlQuerty);
        }
        public static void ConnectionToSql(string sqlQuerty)
        {  //Working only for executing sql queries
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }

        public static List<string> Applications()
        {
            //Creating a list which contains information about all the users who submitted application
            string sqlQuerty = $@"SELECT lastName,firstName,username,user_id,aboutUser
            FROM toptours.users
            WHERE (IsAdmin='0')";
            List<string> list = new List<string>();
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string lastName=dr.GetString(0);
                    string  firstName=dr.GetString(1);
                    string username = dr.GetString(2);
                    string user_id = dr.GetString(3);
                    string aboutUser = "Hi!";
                    if (dr.GetString(4) != null)
                    {
                        aboutUser = dr.GetString(4);
                    }
                    string str =$@"<br/>Name:{lastName} {firstName} <br/> Username:{username},id:{user_id} <br/> AboutUser:{aboutUser} <br/>";
                    list.Add(str);
                }
            }
            con.Close();
            return list;
        }
        public static List<string> ApplicationsID()
        {
            // Creating list of users' ids
            string sqlQuerty = $@"SELECT user_id
            FROM toptours.users
            WHERE (IsAdmin='0')";
            List<string> list = new List<string>();
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string user_id = dr.GetString(0);
                    list.Add(user_id);
                }
            }
            con.Close();
            return list;
        }
        public static Customer GetAnyCustomer(string username)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"Select email,password1
            From toptours.users
            where (username='{username}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            Customer cust = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
                cust = Login(r.GetString(0), r.GetString(1));
            // Close Connection
            con.Close();
            return cust;
        }
        public static bool DeleteAnyUser(string username)
        {
            Customer cust =GetAnyCustomer(username);
            if (cust!=null&&cust.DeleteAccount())
                return true;
            return false;
        }
        public static bool DeleteAnyPlace(string placeName,string username)
        { 
            Customer cust = GetAnyCustomer(username);
            if (cust != null && Place.DeletePlace(placeName, cust.CustomerID))
                return true;
            return false;
        }
        public static bool DeleteAnyRoute(string routeName,string username)
        {
            Customer cust = GetAnyCustomer(username);
            Route r = Route.GetRoute(routeName);
            if (cust != null && r.DeleteRoute(routeName, cust.CustomerID))
                return true;
            return false;
        }
        public static bool DeleteAnyReview(string caption,string username)
        {
            //Customer cust = GetAnyCustomer(username);
            //localhost.Review r = localhost.(cust, caption);
            //if (cust != null && r != null)
            //{
            //    r.DeleteReview();
            //    return true;
            //}
            //return false;\
            return true;


        }
    }
}