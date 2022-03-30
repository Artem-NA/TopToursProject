using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace toptours1
{
    public class Customer
    {
        //Customer is user
        //Variables are portected which means Admin can access them without any problem
        protected int customerID;
        protected string firstName;
        protected string lastName;
        protected string username;
        protected string password;
        protected string email;
        protected string profileImage;
        //Gets and Sets
        public int CustomerID { get => customerID; set => customerID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string ProfileImage { get => profileImage; set => profileImage = value; }

        public Customer(string firstName, string lastName, string username, string password, string email,string profileImage)
        {
            //constructor 1
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.email = email;
            this.profileImage=profileImage;
        }
        public Customer(string firstName, string lastName, string username, string password, string email)
        {
            //constructor 1
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        public Customer(int customerID, string username, string password, string email)
        {
            //constructor 2
            this.customerID = customerID;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        public Customer(int customerID, string firstName, string lastName, string username, string password, string email)
        {
            //constructor 3
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.email = email;
            this.customerID = customerID;
        }
        public static Customer SignUp(string firstName, string lastName, string username, string password, string email,string imgUrl,string path)
        {
            //Signup new user if not exists in the database
            // Connection
            if (IsUsernameExist(username))
                return null;
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by that email
            string sqlQuerty = $@"Select user_id,firstName,lastName,username,password1,email
            From toptours.users
            WHERE (email='{email}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            { return null; }
            // Close Connection
            con.Close();
            con.Open();
            //Command which create new user to the database
            cmd.CommandText = $@"INSERT INTO `toptours`.`users` (`firstName`, `lastName`, `username`, `password1`, `email`) VALUES ('{firstName}', '{lastName}', '{username}', '{password}', '{email}');";
            cmd.ExecuteNonQuery();    
            con.Close();
            AddProfileImg(imgUrl,path, email, password);
            Customer cust = new Customer(firstName, lastName, username, password, email,imgUrl);
            // Close Connection
            con.Close();
            return cust;
            
        }
        public static void AddProfileImg(string urlName,string path,string email,string password)
        {

            // Connection
            Customer c = Login(email, password);
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which delets all user's pictures for good
            string sqlQuerty = $@"INSERT INTO `toptours`.`images` (`url`, `fileName`, `user_id`) VALUES ('{path}', '{urlName}', '{c.CustomerID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        public static bool IsUsernameExist(string username)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT *
            FROM toptours.users
            WHERE (username='{username}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            bool check = false;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
                return true;
            // Close Connection
            con.Close();
            return check;
        }
        public static Customer Login(string email,string password)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"Select user_id,firstName,lastName,username,password1,email
            From toptours.users
            where (email='{email}') AND(password1='{password}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            Customer cust = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                int id = r.GetInt32(0);
                string firstN = r.GetString(1);
                string lastN = r.GetString(2);
                string username = r.GetString(3);
                cust = new Customer(id,firstN, lastN, username, password, email);
            }
            // Close Connection
            con.Close();
            return cust;
        }
        
        public static Customer UpdateEmail(string email, string password,string newEmail)
        {
            //Update User's email
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"Select user_id,firstName,lastName,username,password1,email
            From toptours.users
            where (email='{email}') AND(password1='{password}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            Customer cust = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                int id = r.GetInt32(0);
                string username = r.GetString(3);
                cust = new Customer(id, username, password, email);
                // Close Connection
                con.Close();
                con.Open();
                //Command which update user's email
                cmd.CommandText = $@"UPDATE `toptours`.`users` SET `email` = '{newEmail}' WHERE (email='{email}');";
                cmd.ExecuteReader();
                cust.Email=newEmail;
                // Close Connection
                con.Close();
                return cust;
            }
            // Close Connection
            con.Close();
            return cust;

        }
        public static Customer UpdatePassword(string email, string password,string newPassword)
        {
            //Update User's password
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"Select user_id,firstName,lastName,username,password1,email
            From toptours.users
            where (email='{email}') AND(password1='{password}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            Customer cust = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                int id = r.GetInt32(0);
                string username = r.GetString(3);
                cust = new Customer(id, username, password, email);
                // Close Connection
                con.Close();
                con.Open();
                //Command which update user's password
                cmd.CommandText = $@"UPDATE `toptours`.`users` SET `password1` = '{newPassword}' WHERE (email='{email}');";
                cmd.ExecuteReader();
                cust.Password=newPassword;
                // Close Connection
                con.Close();
                return cust;
            }
            // Close Connection
            con.Close();
            return cust;
        }
        public static Customer UpdateUsername(string email, string password,string newUsername)
        {
            //Update User's username
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"Select user_id,firstName,lastName,username,password1,email
            From toptours.users
            where (email='{email}') AND(password1='{password}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            Customer cust = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                int id = r.GetInt32(0);
                string username = r.GetString(3);
                cust = new Customer(id, username, password, email);
                // Close Connection
                con.Close();
                con.Open();
                //Command which update user's username
                cmd.CommandText = $@"UPDATE `toptours`.`users` SET `username` = '{newUsername}' WHERE (email='{email}');";
                cmd.ExecuteReader();
                cust.username = newUsername;
                // Close Connection
                con.Close();
                return cust;
            }
            // Close Connection
            con.Close();
            return cust;
        }
        public void DeleteAllMyImages()
        {   
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which delets all user's pictures for good
            string sqlQuerty = $@"DELETE FROM `toptours`.`images` WHERE (user_id='{this.CustomerID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        public void DeleteAllMyReviews()
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which delets all user's pictures for good
            string sqlQuerty = $@"DELETE FROM toptours.reviews WHERE(user_id='{this.customerID}') ";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();    
        }
        public void DeleteAllMyRoutes()
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which delets all user's pictures for good
            string sqlQuerty = $@"DELETE FROM toptours.routes WHERE(user_id='{this.customerID}') ";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        public void DeleteAllMyPlaces()
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which delets all user's pictures for good
            string sqlQuerty = $@"DELETE FROM toptours.places WHERE(user_id='{this.customerID}') ";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        public bool DeleteAccount()
        {
            //In order to delete user,there is the need to remove user from other tables in that order 1.images,2.reviews,3.routes,4.places,5.users
            DeleteAllMyImages();
            DeleteAllMyReviews();
            DeleteAllMyRoutes();
            DeleteAllMyPlaces();
            //Delete My Account
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"Select user_id,firstName,lastName,username,password1,email
            From toptours.users
            where (email='{this.email}') AND(password1='{this.password}')";
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
                cmd.CommandText = $@"DELETE FROM `toptours`.`users` WHERE (`user_id` = '{id}');";
                cmd.ExecuteReader();
                // Close Connection
                con.Close();
                //Account Deleted
                return true;
            }
            // Close Connection
            con.Close();
            //incorrect email/password
            return false;

        }
        public static Customer UpdateProfile(string email, string password,string fileName,string url)
        {
            //Update User's username
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"Select user_id,username
            From toptours.users
            where (email='{email}') AND(password1='{password}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            Customer cust = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                int id = r.GetInt32(0);
                string username = r.GetString(1);
                cust = new Customer(id, username, password, email);
                // Close Connection
                con.Close();
                con.Open();
                //Command which update user's username
                cmd.CommandText = $@"INSERT INTO `toptours`.`images` (`url`, `fileName`, `user_id`) VALUES ('{url}', '{fileName}', '{id}');";
                cmd.ExecuteReader();
                cust.profileImage = fileName;
                // Close Connection
                con.Close();
                return cust;
            }
            // Close Connection
            con.Close();
            return cust;
        }
        public string GetFullName()
        {
            return this.firstName+" "+this.lastName;
        }
        public Admin IsAdmin()
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"Select user_id,firstName,lastName,username,password1,email
            From toptours.users
            where (email='{this.email}') AND(password1='{this.password}') AND(IsAdmin='1')";
            Admin a=null;
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                string firstN = r.GetString(1);
                string lastN = r.GetString(2);
                string username = r.GetString(3);
                a = new Admin( firstN, lastN, username, password, email);
            }
            // Close Connection
            con.Close();
            return a;
        }

        public void AskToBeAdmin()
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which give the admin to- know that user would like to be admin by adding -1 in isAdmin column in the database
            string sqlQuerty = $@"UPDATE `toptours`.`users` SET `IsAdmin` = '-1' WHERE (`user_id` = '{this.customerID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();        
            // Close Connection
            con.Close();
        }
        public override string ToString()
        {
            //Show all the info about customer
            string s = "<br/>CustomerID: " + CustomerID.ToString();
            s += "<br/>First Name: " + FirstName;
            s += "<br/>LastName: " + LastName;
            s += "<br/>Username: " + Username;
            s += "<br/>Password: " + Password;
            s += "<br/>Email: " + Email;
            return s;
        }
        public static int GetId(Customer c)
        {
            return c.CustomerID;
        }
    }
    //Using Delegate so the program will decide which function to activate
    public delegate Customer Update(string email, string password,string newX);
}