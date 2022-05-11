using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class ShowPlace2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Place p = Place.GetPlace(GetNameFromUrl());
            Label1.Text = p.PlaceName;
            Label2.Text = p.PlaceInfo;
            Label3.Text = Convert.ToString(p.Longitude)+","+ Convert.ToString(p.Latitude);
            if(p.IsPrivate)
            {
                Label4.Text = "Place is private";
            }
        }
        public static string GetNameFromUrl()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            return query.Get("name");
        }


        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            //delete place for good
            string placeName = GetNameFromUrl();
            Customer cust = (Customer)Session["customer"];
            Place.DeletePlace(placeName, cust.CustomerID);
            Response.Write("<script>alert('Place deleted');</script>");
            Response.AddHeader("REFRESH", "2;URL=Home2.aspx");
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect($"EditPlace2.aspx?name={GetNameFromUrl()}");
        }
    }
}