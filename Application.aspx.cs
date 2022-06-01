using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class Application : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if user has session
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                BulletedList1.DisplayMode = BulletedListDisplayMode.HyperLink;
                ListItem home = new ListItem { Value = "Home2.aspx", Text = "HOME" };
                ListItem places = new ListItem { Value = "Places2.aspx", Text = "PLACES" };
                ListItem routess = new ListItem { Value = "Routes2.aspx", Text = "ROUTES" };
                ListItem aboutus = new ListItem { Value = "AboutUs2.aspx", Text = "ABOUT US" };
                ListItem contactus = new ListItem { Value = "ContactUs.aspx", Text = "CONTACT US" };
                BulletedList1.Items.Add(home);
                BulletedList1.Items.Add(places);
                BulletedList1.Items.Add(routess);
                BulletedList1.Items.Add(aboutus);
                BulletedList1.Items.Add(contactus);
                if (Session["customer"] != null)
                {
                    Customer cust = (Customer)Session["customer"];
                    IsLogged.Text = "LOG OUT";
                    ListItem profile = new ListItem { Value = "Profile2.aspx", Text = cust.Username };
                    ListItem Admins = new ListItem { Value = "Admins.aspx", Text = "ADMINS" };
                    BulletedList1.Items.Add(profile);
                    BulletedList1.Items.Add(Admins);


                }
                else
                    IsLogged.Text = "LOGIN";
            }
        }

   

        protected void Button7_Click(object sender, EventArgs e)
        {
            // submitting application to the data base
            Customer cust = (Customer)Session["customer"];
            Admin.RequestToBeAdmin(cust.Username, Info.Value);
            ResponseL.Text = "Request sent successfully, Good Luck!!";
            Response.AddHeader("REFRESH", "3;URL=Home2.aspx");   
        }

        protected void IsLogged_Click(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                Session["customer"] = null;
            }
            Response.Redirect("Login.aspx");
        }
    }
}