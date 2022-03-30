using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");

            Customer cust = (Customer)Session["customer"];
            //My Places
            if (!IsPostBack)
            {
                BulletedList1.DisplayMode = BulletedListDisplayMode.HyperLink;
                if (Place.GetAllMyPlaces(cust) == null)
                {
                    Label1.Text = "You Don't own places";
                    return;
                }
                List<Place> places = Place.GetAllMyPlaces(cust);
                for (int i = 0; i < places.Count; i++)
                {
                    Place place = places[i];
                    ListItem listItem = new ListItem
                    {
                        Text = place.PlaceName,
                        Value = "PlaceUpdate.aspx?" + "name=" + place.PlaceName
                    };
                    BulletedList1.Items.Add(listItem);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            bool IsPrivate;
            string placeName = TextBox2.Text;
            string placeInfo = TextBox3.Text;
            string longitudeSt = TextBox4.Text;
            string latitudeSt = TextBox5.Text;
            if (RadioButton1.Checked)
                IsPrivate = true;
            else
                IsPrivate = false;
            if (placeName == "" || placeInfo == "" || longitudeSt == "" || latitudeSt == "")
                Label1.Text = "Empty fields";
            else
            {
                Place place = Place.AddPlace(placeName, placeInfo, (float)Convert.ToDouble(longitudeSt), (float)Convert.ToDouble(latitudeSt), IsPrivate,cust.CustomerID);
                if (place == null)
                { Response.Write("<script>alert('Place was not created');</script>"); }
                else
                { Response.Write("<script>alert('Place created successfully');</script>"); }
            }



        }
        protected void Button4_Click1(object sender, EventArgs e)
        {
            BulletedList2.Items.Clear();
            BulletedList2.DisplayMode = BulletedListDisplayMode.HyperLink;
            string placeName = SearchTB.Text;
            if (Place.SearchPlace(placeName) == null)
            {
                Label1.Text = "No places found";
                return;
            }
            List<Place> places = Place.SearchPlace(placeName);
            for (int i = 0; i < places.Count; i++)
            {
                Place place = places[i];
                ListItem listItem = new ListItem
                {
                    Text = place.PlaceName,
                    Value = "PlaceShow.aspx?" + "name=" + place.PlaceName
                };
                BulletedList2.Items.Add(listItem);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}