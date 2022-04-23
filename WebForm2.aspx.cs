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
            List<string> list = Admin.Applications();
            List<string> list2 = Admin.ApplicationsID();
            for(int i = 0; i < list.Count; i++)
            {
                Label labelUserInfo = new Label { Text = list[i].ToString() };
                Label user_id= new Label { Text = list2[i].ToString() };
                Button buttonYes = new Button { Text ="Accept"};
                Button buttonNo = new Button { Text ="Cancel"};
                buttonYes.Command += AcceptUser;
                buttonYes.CommandArgument = user_id.Text;
                buttonNo.Command += RejectUser;
                buttonNo.CommandArgument= user_id.Text;
                Applications.Controls.Add(labelUserInfo);
                Applications.Controls.Add(buttonYes);
                Applications.Controls.Add(buttonNo);
            }
        }
        protected void AcceptUser(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument as String;
            Convert.ToInt32(id);
            Admin.NewAdmin(id,true);
        }
        protected void RejectUser(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument as String;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //add new user to admin
            //Admin.AddNewAdmin(TextBox1.Text, TextBox1.Text);
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