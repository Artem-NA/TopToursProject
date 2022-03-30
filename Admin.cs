using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace toptours1
{
    public class Admin : Customer
    {
        public Admin(string firstName, string lastName, string username, string password, string email,string imgProfile) : base(firstName, lastName, username, password, email,imgProfile)
        {
           
        }
        public Admin(string firstName, string lastName, string username, string password, string email) : base(firstName, lastName, username, password, email)
        {

        }
        public static void AddNewAdmin(string username)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which delets all user's pictures for good
            string sqlQuerty = $@"UPDATE `toptours`.`users` SET `IsAdmin` = '1' WHERE (username = '{username}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            //incorrect email/password
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
                cust =Login(r.GetString(0), r.GetString(1));
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
            Customer cust = GetAnyCustomer(username);
            Review r = Review.GetReview(cust, caption);
            if (cust != null&&r!=null)
            {
                r.DeleteReview();
                return true;
            }
            return false;

        }
    }
}