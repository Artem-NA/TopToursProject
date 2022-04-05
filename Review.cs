using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace toptours1
{
    public class Review
    {
        private int reviewID;
        private string content;
        private int rating;
        private string caption;
        //rating is in  a scale 1 to 5
        public Review(string content, int rating, string caption)
        {

            this.content = content;
            this.rating = rating;
            this.caption = caption;
        }

        public Review(int reviewID, string content, int rating, string caption)
        {
            this.reviewID = reviewID;
            this.content = content;
            this.rating = rating;
            this.caption = caption;
        }

        public int Id { get => reviewID; set => reviewID = value; }
        public string Content { get => content; set => content = value; }
        public int Rating { get => rating; set => rating = value; }
        public string Caption { get => caption; set => caption = value; }
        public int GetCustomerId()
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT user_id
            FROM toptours.reviews 
            WHERE(review_id='{this.reviewID}')";
            int customerId = -1;
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                customerId = r.GetInt32(0);
            }
            // Close Connection
            con.Close();
            return customerId;
        }
        public static Review GetReview(Customer c,string caption)
        {
            //Update User's place info
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select r.content,r.rating,r.review_id
            From toptours.reviews r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.user_id='{c.CustomerID}')And (r.caption='{caption}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            Review review = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //Place In dataBase
                string content = r.GetString(0);
                int rating = r.GetInt32(1);
                int review_id = r.GetInt32(2);
                review = new Review(review_id,content, rating, caption);
                return review;
            }
            // Close Connection
            con.Close();
            return review;
        }
        public static Review GetReview(int review_id)
        {
            //Update User's place info
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"select r.content,r.rating,r.caption
            From toptours.reviews r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.review_id='{review_id}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            Review review = null;
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //review In database
                string caption=r.GetString(2);
                string content = r.GetString(0);
                int rating = r.GetInt32(1);
                review = new Review(review_id, content, rating, caption);
                return review;
            }
            // Close Connection
            con.Close();
            return review;
        }
        public static List<Review> GetAllReviewsOfRoute(Route route)
        {
            List<Review> reviews = new List<Review>();
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"SELECT review_id
            FROM toptours.reviews 
            WHERE(route_id='{route.RouteID}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Review review = GetReview(r.GetInt32(0));
                    reviews.Add(review);
                }
            }
            return reviews;
        }
        public string GetRouteName(Customer c)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if route and place created by the same user
            string sqlQuerty = $@"select r.route_id  
            From toptours.reviews r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.user_id='{c.CustomerID}')And (r.caption='{caption}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                 return Route.GetRouteNameByID(c, r.GetInt32(0));
            }
            // Close Connection
            con.Close();
            return "NO DATA";
        }

        //public static List<Review> SearchReview(string reviewName)
        //{
        //    List<Review> places = new List<Review>();
        //    // Connection
        //    MySqlConnection con = new MySqlConnection(ServerNames.CDB);
        //    //Command which checks if user already signed in by email and password
        //    string sqlQuerty = $@"select place_id
        //    From toptours.places
        //    where placeName like '%{reviewName}%'";
        //    MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
        //    con.Open();
        //    MySqlDataReader r = cmd.ExecuteReader();
        //    if (r.HasRows)
        //    {
        //        while (r.Read())
        //        {
        //            Review p = GetPlace(r.GetInt32(0));
        //            places.Add(p);
        //        }
        //    }
        //    return places;
        //}

        public static Review AddReview(string content, int rating, string caption,Customer c,string routeName)
        {
            //Add new review to the database
            // Connection
            //Check whether route exists
            Route route = Route.GetRoute(routeName);
            if (route== null)
            { return null; }
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            string sqlQuerty = $@"select u.user_id,r.content    
            From toptours.reviews r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.caption='{caption}')";
            Review re = null;
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                con.Close();
                return re;
            }
            // Close Connection
            con.Close();
            con.Open();
            //Command which create new place to the database
            cmd.CommandText = $@"INSERT INTO `toptours`.`reviews` (`content`, `rating`, `user_id`, `route_id`, `caption`) VALUES ('{content}', '{rating}', '{c.CustomerID}', '{route.RouteID}', '{caption}');";
            cmd.ExecuteNonQuery();
            con.Close();
            Review review = new Review(content,rating,caption);
            // Close Connection
            con.Close();
            return review;
        }
        public void UpdateContent(string newContent)
        {
            //Update Review's Content
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"UPDATE `toptours`.`reviews` SET `content` = '{newContent}' WHERE (`review_id` = '{this.reviewID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
        }
        public void UpdateRating(string newRatingST)
        {
            int newRating = Convert.ToInt32(newRatingST);
            //Update Review's Content
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"UPDATE `toptours`.`reviews` SET `rating` = '{newRating}' WHERE (`review_id` = '{reviewID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();

        }
        public void UpdateCaption(string newCaption)
        {
            //Update Review's Content
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"UPDATE `toptours`.`reviews` SET `caption` = '{newCaption}' WHERE (`review_id` = '{reviewID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
        }
        public static int GetID(int userID, string caption)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if route and place created by the same user
            string sqlQuerty = $@"select r.review_id   
            From toptours.reviews r INNER JOIN toptours.users u
            On r.user_id=u.user_id
            Where(r.user_id='{userID}')And (r.caption='{caption}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                //User In dataBase
                return r.GetInt32(0);
            }
            // Close Connection
            con.Close();
            return -1;
        }

        public void DeleteReview()
        {
            //Update Review's Content
            // Connection
            MySqlConnection con = new MySqlConnection(ServerNames.CDB);
            //Command which checks if user already signed in by email and password
            string sqlQuerty = $@"DELETE FROM `toptours`.`reviews` WHERE (`review_id` = '{this.reviewID}');";
            MySqlCommand cmd = new MySqlCommand(sqlQuerty, con);
            con.Open();
            cmd.ExecuteReader();
        }
        public override string ToString()
        {
            //Show all the info about customer
            string s = "<br/>RouteID: " + reviewID.ToString();
            s += "<br/>ReviewCaption: " + caption;
            s += "<br/>ReviewRating: " + rating;
            s += "<br/>ReviewContent: " + content;
            return s;
        }
    }
}