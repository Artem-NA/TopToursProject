using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class AskToBeA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            cust.AskToBeAdmin();
            Label1.Text = "Request sent successfully";
            Response.AddHeader("REFRESH", "4;URL=HomePage.aspx");
            
        }
    }
}