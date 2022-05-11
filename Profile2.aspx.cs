using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;


namespace toptours1
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");

            Customer cust = (Customer)Session["customer"];
            string str = "No";
            Label2.Text = "<br/>First Name: " + cust.FirstName;
            Label3.Text = "<br/>Last Name: " + cust.LastName;

            Label4.Text = "<br/>Username: " + cust.Username;
            Label5.Text = "<br/>Email: " + cust.Email;
            if (cust.IsAdmin() != null)
            {
                str = "Yes";
            }
            Label6.Text = "<br/>Admin: " + str;
            string image = cust.ProfileImage;
            Image1.ImageUrl = @"\images\"+image;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string email = TextBox9.Text;
            string password = TextBox10.Text;
            string newX = TextBox12.Text;
            Customer cust = Customer.Login(email, password);
            Update update;
            if (cust == null)
            {
                Label1.Text = "Incorrect Email/Password!!!!!!!!";
                return;
            }
            if (DropDownList1.SelectedValue == "0")
            {
                Label1.Text = "Please choose what would you like to update.";
                return;
            }
            if (DropDownList1.SelectedValue == "2")
            {
                update = new Update(Customer.UpdateEmail);
                cust = update(email, password, newX);
                if(cust==null)
                { Label1.Text = "update process failed"; return; }
                Label1.Text = "Account updated";
               
            }
            if (DropDownList1.SelectedValue == "1")
            {
                update = new Update(Customer.UpdatePassword);
                cust = update(email, password, newX);
                if (cust == null)
                { Label1.Text = "update process failed"; return; }
                Label1.Text = "Account updated";
            }
            if (DropDownList1.SelectedValue == "3")
            {
                update = new Update(Customer.UpdateUsername);
                cust = update(email, password, newX);
                if (cust == null)
                { Label1.Text = "update process failed"; return; }
                Label1.Text = "Account updated";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string email = TextBox13.Text;
            string password = pass.Value.ToString();
            if (email == "" || password == "")
            {
                Label1.Text = "Empty Email/Password";
                return;
            }
            Customer cust = Customer.Login(email, password);
            if(cust==null)
            {
                Label1.Text = "Wrong password/email";
                return;
            }
            if (cust.DeleteAccount())
            {
                    Label1.Text = "Account deleted successfully";
                    Response.AddHeader("REFRESH", "3;URL=Login.aspx");
                    return;
            }
            Label1.Text = "Incorrect Email/Password";
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {

        }
    }
}