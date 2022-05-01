using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string email = TextBox2.Text;
            string password = TextBox1.Text;
            if (email == "" || password == "")
            {
                Label1.Text = "Empty Email/Password";
                return;
            }
            Customer cust = Customer.Login(email, password);
            if (cust == null)
            {
                Label1.Text = "Wrong Email/Password";
                return;
            }
            Session["Customer"] = cust;
            Response.Redirect("Home.aspx");
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}