using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class Places2 : System.Web.UI.Page
    {
        public List<Place> lst;
        //variable that contains a list of places that customer created
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Customer cust = (Customer)Session["customer"];
            if (!IsPostBack)
            {
                List<Place> lst =null;
                if (Place.GetAllMyPlaces(cust) != null)
                {
                    lst = Place.GetAllMyPlaces(cust);
                }
                this.lst = lst;
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            bool IsPrivate=false;
            string placeName = Name.Value;
            string placeInfo = Info.Value;
            string longitudeSt = longitude.Value;
            string latitudeSt = latitude.Value;
            if (RadioButton1.Checked)
                IsPrivate = true;
            if (!IsValidInput(placeName) || !IsValidInput(placeInfo) || !IsValidInput(longitudeSt) || !IsValidInput(latitudeSt))
            {
                Response.Write("<script>alert('Invaild Data');</script>");
                return;
            }
            Place place = Place.AddPlace(placeName, placeInfo, (float)Convert.ToDouble(longitudeSt), (float)Convert.ToDouble(latitudeSt), IsPrivate, cust.CustomerID);
            if (place == null)
            { Response.Write("<script>alert('Place was not created');</script>"); }
            else
            { Response.Write("<script>alert('Place created successfully');</script>"); }
        }
        public static bool IsValidInput(string str)
        {
            //set min length and max length to input
            return (str.Length > 1 && str.Length < 10000);

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            BulletedList1.Items.Clear();
            BulletedList1.DisplayMode = BulletedListDisplayMode.HyperLink;
            string value = searchValue.Value;
            if (Place.SearchPlace(value) == null)
            {
                ListItem listItem = new ListItem { Text = "No Places found,try again" };
                BulletedList1.Items.Add(listItem);
                return;
            }
            List<Place> places = Place.SearchPlace(value);
            for (int i = 0; i < places.Count; i++)
            {
                Place place = places[i];
                ListItem listItem = new ListItem
                {
                    Text = place.PlaceName,
                    Value = "PlaceShow.aspx?" + "name=" + place.PlaceName
                };
                BulletedList1.Items.Add(listItem);
            }
        }
    }
}