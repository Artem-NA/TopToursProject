using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class EditPlace2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Place p = Place.GetPlace(GetNameFromUrl());
            longitude.Value = Convert.ToString(p.Longitude);
            latitude.Value = Convert.ToString(p.Latitude);
            Name.Value = p.PlaceName;
            Info.Value = p.PlaceInfo;
            if (!p.IsPrivate)
            {
                RadioButton2.Checked = true;
            }
        }
        public static string GetNameFromUrl()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            return query.Get("name");
        }


        protected void EditBtn_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            bool isPrivate = false;
            string placeName = Name.Value;
            string placeInfo = Info.Value;
            string longitudeSt = longitude.Value;
            string latitudeSt = latitude.Value;
            Place p = Place.GetPlace(GetNameFromUrl());
            int place_id = p.PlaceID;
            if (RadioButton1.Checked)
                isPrivate = true;
            if (!IsValidInput(placeName) || !IsValidInput(placeInfo) || !IsValidInput(longitudeSt) || !IsValidInput(latitudeSt))
            {
                Response.Write("<script>alert('Invaild Data');</script>");
                return;
            }
            Place.UpdatePlaceInfo(placeInfo,place_id,cust.CustomerID);
            Place.UpdatePlaceName(placeName, place_id, cust.CustomerID);
            Place.UpdateIsPrivate(isPrivate, place_id, cust.CustomerID);
            Response.Write("<script>alert('Place updated successfully');</script>");
            
        }
        public static bool IsValidInput(string str)
        {
            //set min length and max length to input
            return (str.Length > 1 && str.Length < 10000);

        }
    }
}