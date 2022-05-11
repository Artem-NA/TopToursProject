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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Customer cust = (Customer)Session["customer"];
            //My Routes
            if (!IsPostBack)
            {
                //BulletedList1.DisplayMode = BulletedListDisplayMode.HyperLink;
                if (Route.GetAllRoutes(cust) == null)
                {
                    Label1.Text = "You Don't have any routes";
                    return;
                }
                List<Route> routes = Route.GetAllRoutes(cust);
                this.lst = routes;

                
                //for (int i = 0; i < routes.Count; i++)
                //{
                //    Route route = routes[i];
                //    ListItem listItem = new ListItem
                //    {
                //        Text = route.RouteName,
                //        Value = "RouteUpdate.aspx?" + "name=" + route.RouteName
                //    };
                //    BulletedList1.Items.Add(listItem);
                //}
            }
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string routeName = TextBox2.Text;
            string routetitle = TextBox3.Text;
            string routeInfo = TextBox4.Text;
            if (routeName==""||routetitle==""||routeInfo=="")
            {
                Label1.Text = "Empty";
                return;
            }
                Route r = Route.AddRoute(cust, routeName, routetitle, routeInfo);
                if (r == null) { Label1.Text = "There was a problem"; }
                else { Label1.Text = "Route Created Successfuly";     }
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            string routeName = TextBox9.Text;
            Route r = Route.GetRoute(routeName);
            if (r == null)
            {
                Label1.Text = "Route is not created!";
                return;
            }
            Label1.Text = r.SearchRoute();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string fav = Route.ShowFavorite(cust);
            if (fav == "")
            {
                Label1.Text = "No favorite routes found";
                return;
            }
            Label1.Text = fav;

        }
    }
}