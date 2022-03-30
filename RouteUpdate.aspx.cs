using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class RouteUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // display all info about the chosen place
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Route r = Route.GetRoute(GetNameFromUrl());
            Label1.Text = r.ToString();
            //Label2.Text = Review.GetAllReview();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Update route's info
           // Customer cust = (Customer)Session["customer"];
            string routeName = GetNameFromUrl();
            string routeInfo = TextBox2.Text;
            //////check if new route info is vaild
            Route r = Route.GetRoute(routeName);
            if(r != null)
            {
                r.UpdateRouteInfo(routeInfo);
               Label1.Text ="route updated";
                return;
            }
            Label1.Text = "Empty field(new route info)";


        }
        public static string GetNameFromUrl()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            return query.Get("name");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Add place to route
            //add place to route
            string routeName = GetNameFromUrl();
            Customer cust = (Customer)Session["customer"];
            string placeName = TextBox2.Text;
            Place p = Place.GetPlace(placeName);
            if(p == null)
            {
                Label1.Text = "wrong place name ";
                return;
            }
            Route r = Route.GetRoute(routeName);
            if (r == null)
            {
                Response.Write("<script>alert('You did not create a route with that name');</script>");
                return;
            }
            if (r.AddPlaceToRoute(p, cust) == null)
            {
                Response.Write("<script>alert('Place already in route');</script>");
                return;
            }
            Response.Write("<script>alert('Place added to route');</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //delete route
            Customer cust = (Customer)Session["customer"];
            string routeName = GetNameFromUrl();
            Route r = Route.GetRoute(routeName);
            if (r != null && r.DeleteRoute(routeName, cust.CustomerID))
            {
                Response.Write("<script>alert('Route Deleted Successfully');</script>");
                return;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //set route as favorite route
            string routeName = GetNameFromUrl();
            Route r = Route.GetRoute(routeName);
            if (r == null)
            {
                Response.Write("<script>alert('Route is not created!');</script>");
                return;
            }
            r.DoFavoriteRoute();
            Response.Write("<script>alert('Route added to favorite routes');</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //go to reviews
           // Response.Redirect("ReviewsPage.aspx");

        }
    }
}