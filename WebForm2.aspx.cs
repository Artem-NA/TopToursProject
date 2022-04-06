using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //show application only if user asked to be admin
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //add new user to admin
            Admin.AddNewAdmin(TextBox1.Text, TextBox1.Text);
            Response.Write("<script>alert('successful');</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //if already not admin
            Admin.RequestToBeAdmin(TextBox1.Text, TextBox2.Text);
            Response.Write("<script>alert('requsted successful!');</script>");
        }
    }
}