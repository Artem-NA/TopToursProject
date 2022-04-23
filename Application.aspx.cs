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
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //return to home page 
            Response.Redirect("HomePage.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            // submitting application to the data base
            Customer cust = (Customer)Session["customer"];
            Admin.RequestToBeAdmin(cust.Username, MessageTB.Text);
            ResponseL.Text = "Request sent successfully, Good Luck!!";
            Response.AddHeader("REFRESH", "3;URL=HomePage.aspx");   
        }
    }
}