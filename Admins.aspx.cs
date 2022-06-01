using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace toptours1
{
    public partial class OnlyAdmins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            if (cust.IsAdmin() == null)
                Response.Redirect("Application.aspx");

            

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
                    IsLogged.Text = "LOG OUT";
                    ListItem profile = new ListItem { Value = "Profile2.aspx", Text = cust.Username };
                    ListItem Admins = new ListItem { Value = "Admins.aspx", Text = "ADMINS" };
                    BulletedList1.Items.Add(profile);
                    BulletedList1.Items.Add(Admins);


                }
                else
                    IsLogged.Text = "LOGIN";
            }
            //Customers Area
            
            List<string> list = Admin.GetCustomers();
            for (int i = 0; i < list.Count; i++)
            {
                string username = list[i].ToString();
                Label usernameL = new Label { Text = list[i].ToString()+"    " ,ID="UserLab"+username };
                Label space = new Label { Text = "<br/>" ,ID="Lab"+ list[i].ToString() };
                Button buttonYes = new Button { Text = "Delete", CommandArgument = username ,ID="Btn"+list[i].ToString() , CssClass = "btn-dark" };
                buttonYes.Command += DeleteUser;
                All.Controls.Add(usernameL);
                All.Controls.Add(buttonYes);
                All.Controls.Add(space);

            }
            //Applications Area
            
            List<string> appl = Admin.Applications();
            List<string> appl2 = Admin.ApplicationsID();
            for (int i = 0; i < appl.Count; i++)
            {
                string id = appl2[i].ToString();
                Label labelUserInfo = new Label { Text = appl[i].ToString() , ID="info"+id};
                Button buttonYes = new Button { Text = "Accept", CommandArgument = id, ID="BtnYes"+id , CssClass = "btn-dark" };
                Button buttonNo = new Button { Text = "Cancel", CommandArgument = id,ID="btnNo"+id, CssClass = "btn-dark" };
                buttonYes.Command += AcceptUser;
                buttonNo.Command += RejectUser;  
                Applications.Controls.Add(labelUserInfo);
                Applications.Controls.Add(buttonYes);
                Applications.Controls.Add(buttonNo);
            }



        }

        protected void Search_Click(object sender, EventArgs e)
        {
            All.Visible = false;
            Applications.Visible = false;
            if (DropDownList1.SelectedValue == "0")
            {
                Label1.Text = "Please choose what would you like to do";
                return;
            }
            if (DropDownList1.SelectedValue == "1")
            {
                All.Visible = true;

            }
            if (DropDownList1.SelectedValue == "2")
            {
                Applications.Visible = true;
            }
            //if (DropDownList1.SelectedValue == "1")
            //{
            //    update = new Update(Customer.UpdatePassword);
            //    cust = update(email, password, newX);
            //    if (cust == null)
            //    { Label1.Text = "update process failed"; return; }
            //    Label1.Text = "Account updated";
            //}
            //if (DropDownList1.SelectedValue == "3")
            //{
            //    update = new Update(Customer.UpdateUsername);
            //    cust = update(email, password, newX);
            //    if (cust == null)
            //    { Label1.Text = "update process failed"; return; }
            //    Label1.Text = "Account updated";
            //}



        }
        protected void DeleteUser(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument as String;
            Admin.DeleteAnyUser(username);

            this.FindControl("btn" + username).Visible=false;
            this.FindControl("Lab" + username).Visible = false;
            this.FindControl("UserLab" + username).Visible = false;
        }
        protected void AcceptUser(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument as String;
            Convert.ToInt32(id);
            Admin.NewAdmin(id, true);
            this.FindControl("info" + id).Visible = false;
            this.FindControl("BtnYes" + id).Visible = false;
            this.FindControl("BtnNo" + id).Visible = false;
        }
        protected void RejectUser(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument as String;
            Convert.ToInt32(id);
            Admin.NewAdmin(id, false);
            this.FindControl("info" + id).Visible = false;
            this.FindControl("BtnYes" + id).Visible = false;
            this.FindControl("BtnNo" + id).Visible = false;
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