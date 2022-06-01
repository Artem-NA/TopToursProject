using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace toptours1
{
    public partial class Routes1 : System.Web.UI.Page
    {
        public List<Route> lst;
        public List<string> lstFav;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Customer cust = (Customer)Session["customer"];
            if (!IsPostBack)
            {
                BulletedList2.DisplayMode = BulletedListDisplayMode.HyperLink;
                ListItem home = new ListItem { Value = "Home2.aspx", Text = "HOME" };
                ListItem places = new ListItem { Value = "Places2.aspx", Text = "PLACES" };
                ListItem routess = new ListItem { Value = "Routes2.aspx", Text = "ROUTES" };
                ListItem aboutus = new ListItem { Value = "AboutUs2.aspx", Text = "ABOUT US" };
                ListItem contactus = new ListItem { Value = "ContactUs.aspx", Text = "CONTACT US" };
                BulletedList2.Items.Add(home);
                BulletedList2.Items.Add(places);
                BulletedList2.Items.Add(routess);
                BulletedList2.Items.Add(aboutus);
                BulletedList2.Items.Add(contactus);
                if (Session["customer"] != null)
                {
                    IsLogged.Text = "LOG OUT";
                    ListItem profile = new ListItem { Value = "Profile2.aspx", Text = cust.Username };
                    ListItem Admins = new ListItem { Value = "Admins.aspx", Text = "ADMINS" };
                    BulletedList2.Items.Add(profile);
                    BulletedList2.Items.Add(Admins);


                }
                else
                    IsLogged.Text = "LOGIN";
            }
            
            List <Route> routes = null;
                if (Route.GetAllRoutes(cust) != null)
                {

                    routes = Route.GetAllRoutes(cust);
                }
                this.lst = routes;
            List<string> favRoutes = null;
                if (Route.ShowFavorite(cust) != null)
                {
                    favRoutes = Route.ShowFavorite(cust);
                }
                this.lstFav = favRoutes;

             
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Customer cust = (Customer)Session["customer"];
            //string routeName = TextBox2.Text;
            //string routetitle = TextBox3.Text;
            //string routeInfo = TextBox4.Text;
            //if (routeName==""||routetitle==""||routeInfo=="")
            //{
            //    Label1.Text = "Empty";
            //    return;
            //}
            //    Route r = Route.AddRoute(cust, routeName, routetitle, routeInfo);
            //    if (r == null) { Label1.Text = "There was a problem"; }
            //    else { Label1.Text = "Route Created Successfuly";     }
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            //string routeName = TextBox9.Text;
            //Route r = Route.GetRoute(routeName);
            //if (r == null)
            //{
            //    Label1.Text = "No routes found";
            //    return;
            //}
            //Label1.Text = r.SearchRoute();
        }

       

        protected void Button10_Click(object sender, EventArgs e)
        {
            //Customer cust = (Customer)Session["customer"];
            //string fav = Route.ShowFavorite(cust);
            //if (fav == "")
            //{
            //    Label1.Text = "No favorite routes found";
            //    return;
            //}
            //Label1.Text = fav;

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string routeName = Name.Value ;
            string routetitle = Title.Value;
            string routeInfo = Info.Value;
            if (!IsValidInput(routeName) || !IsValidInput(routetitle) || !IsValidInput(routeInfo))
            {
                Response.Write("<script>alert('Invaild Data');</script>");
                return;
            }
            Route r = Route.AddRoute(cust, routeName, routetitle, routeInfo);
            if (r == null) { Response.Write("<script>alert('Route was not created');</script>"); }
            else {
                Response.Write("<script>alert('Route created successfully');</script>");
                Response.AddHeader("REFRESH", $"1;URL=Routes2.aspx");
            }
        }
        public static bool IsValidInput(string str)
        {
            //set min length and max length to input
            return (str.Length > 1 && str.Length < 10000);

        }

        protected void IsLogged_Click(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                Session["customer"] = null;
            }
            Response.Redirect("Login.aspx");
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            //string routeName = TextBox9.Text;
            //Route r = Route.GetRoute(routeName);
            //if (r == null)
            //{
            //    Label1.Text = "No routes found";
            //    return;
            //}
            //Label1.Text = r.SearchRoute();
            BulletedList1.Items.Clear();
            BulletedList1.DisplayMode = BulletedListDisplayMode.HyperLink;
            string value = searchValue.Value;
            if (Route.SearchRoute(value) == null)
            {
                ListItem listItem = new ListItem { Text = "No Routes found,try again" };
                BulletedList1.Items.Add(listItem);
                return;
            }
            List<Route> routes = Route.SearchRoute(value);
            for (int i = 0; i < routes.Count; i++)
            {
                //Place place = places[i];
                //ListItem listItem = new ListItem
                //{
                //    Text = place.PlaceName,
                //    Value = "PlaceShow.aspx?" + "name=" + place.PlaceName
                //};
                //BulletedList1.Items.Add(listItem);
                Route route = routes[i];
                ListItem listItem = new ListItem { Text = route.RouteName, Value = "RouteShow.aspx?" + "name="+route.RouteName };
                BulletedList1.Items.Add(listItem);
            }
        }
    }
}