using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class PlaceUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // display all info about the chosen place
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Place p = Place.GetPlace(GetNameFromUrl());
            Label1.Text = p.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //update place's info
            string placeName = GetNameFromUrl();
            Customer cust = (Customer)Session["customer"];
            Place.UpdatePlaceInfo(placeName, TextBox2.Text, cust.CustomerID);
            Response.Write("<script>alert('place updated successfully');</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //add place to route
            string placeName = GetNameFromUrl();
            Customer cust = (Customer)Session["customer"];
            string routeName = TextBox1.Text;
            Place p = Place.GetPlace(placeName);
            Route r = Route.GetRoute(routeName);
            if (r == null)
            {
                Response.Write("<script>alert('You did not create a route with that name');</script>");
                return;
            }
            if(r.AddPlaceToRoute(p, cust)==null)
            {
                Response.Write("<script>alert('Place already in route');</script>");
                return;
            }
            Response.Write("<script>alert('Place added to route');</script>");
        }

        public static string GetNameFromUrl()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            return query.Get("name");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //delete place for good
            string placeName = GetNameFromUrl();
            Customer cust = (Customer)Session["customer"];
            Place.DeletePlace(placeName, cust.CustomerID);
            Response.Write("<script>alert('Place deleted');</script>");
            Response.AddHeader("REFRESH", "2;URL=HomePage.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("homePage.aspx");
        }
    }
}