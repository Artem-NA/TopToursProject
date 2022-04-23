using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Customer cust = (Customer)Session["customer"];
            LinkButton3.Text = "Welcome "+cust.Username;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewsPage.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Session["customer"] = null;
            Response.Redirect("login.aspx");
        }
    }
}