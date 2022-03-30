using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class AdminOnly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            if (cust.IsAdmin() == null)
                Response.Redirect("AskToBeA.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            ListOfValues.Items.Clear();
            ListOfValues.DisplayMode = BulletedListDisplayMode.HyperLink;
            string value = SearchTB.Text;
            if (!string.IsNullOrEmpty(value))
            {
                Label1.Text = "value is empty";
                return;
            }
            if (DropDownList1.SelectedValue == "0")
            {
                Label1.Text = "Please choose what would you like to delete.";
                return;
            }
            if (DropDownList1.SelectedValue == "1")
            {
               addUsers

            }
            if (DropDownList1.SelectedValue == "2")
            {
                AddPlacesToList(value);
            }
            if (DropDownList1.SelectedValue == "3")
            {
                AddRoutesToList(value);
            }
            if (DropDownList1.SelectedValue == "4")
            {
                if ()
                { Label1.Text = "Account deleted successfully"; return; }
                Label1.Text = "Wrong Caption";
            }


        }
        public void AddPlacesToList(string value)
        {
            if (bbbbbbb.SearchPlace(value) == null)
            {
                ListItem noData = new ListItem { Text = "No data found" };
                ListOfValues.Items.Add(noData);
                return;
            }

            List<bbbbbbb> places = bbbbbbb.SearchPlace(value);
            for (int i = 0; i < places.Count; i++)
            {
                bbbbbbb place = places[i];
                ListItem listItem = new ListItem
                {
                    Text = place.PlaceName,
                    Value = "PlaceShow.aspx?" + "name=" + place.PlaceName
                };
                ListOfValues.Items.Add(listItem);
            }
        }
        public void AddRoutesToList(string value)
        {
            if (Route.SearchRoute(value) == null)
            {
                ListItem noData = new ListItem { Text = "No data found" };
                ListOfValues.Items.Add(noData);
                return;
            }

            List<Route> routes = Route.SearchRoute(value);
            for (int i = 0; i < routes.Count; i++)
            {
                Route route = routes[i];
                ListItem listItem = new ListItem
                {
                    Text = route.RouteName,
                    Value = "RouteUpdate.aspx?" + "name=" + route.RouteName
                };
                ListOfValues.Items.Add(listItem);
            }
        }

        public void AddPlacesToList(string value)
        {
            if (bbbbbbb.SearchPlace(value) == null)
            {
                ListItem noData = new ListItem { Text = "No data found" };
                ListOfValues.Items.Add(noData);
                return;
            }

            List<bbbbbbb> places = bbbbbbb.SearchPlace(value);
            for (int i = 0; i < places.Count; i++)
            {
                bbbbbbb place = places[i];
                ListItem listItem = new ListItem
                {
                    Text = place.PlaceName,
                    Value = "PlaceShow.aspx?" + "name=" + place.PlaceName
                };
                ListOfValues.Items.Add(listItem);
            }
        }
    }
}