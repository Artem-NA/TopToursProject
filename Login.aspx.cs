using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class Login11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["customer"] = null;
        }

        protected void LoginB_Click(object sender, EventArgs e)
        {
            string value = Username.Value;
            string password = Password.Value;
            Customer cust = Customer.Login(value, password);
            //check if user typed correct values
            if (cust == null)
            {
                Label1.Text = "Wrong Email/Password";
                return;
            }
            Session["Customer"] = cust;
            
            //Move to secured pages
            Response.Redirect("Home2.aspx");
        }
    }
}