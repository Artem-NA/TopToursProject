using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fn = TextBox2.Text;
            string ln = TextBox3.Text;
            string username = TextBox4.Text;
            string password = TextBox5.Text;
            string email = TextBox6.Text;
            if (fn == "" || ln == "" || username == "" || password == "" || email == "")
                Label1.Text = "Empty";
            else
            {
               // Customer cust = Customer.SignUp(fn, ln, username, password, email);
                //if (cust == null) { Label1.Text = "Email already taken,Try again with different email"; }
               // else { Label1.Text = "Account Created Successfuly"; }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string email = TextBox7.Text;
            string password = TextBox8.Text;
            if (email == "" || password == "")
                Label1.Text = "Empty Email/Password";
            else
            {
                Customer cust = Customer.Login(email, password);
                if (cust == null)
                    Label1.Text = "Wrong Email/Password";
                else
                {
                    Session["Customer"] = cust;
                    Response.Redirect("HomePage.aspx");
                }
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string email = TextBox9.Text;
            string password = TextBox10.Text;
            string newX = TextBox12.Text;
            Customer cust = Customer.Login(email, password);
            Update update;
            if (cust != null)
            {
                if (TextBox11.Text == "Email")
                {
                    update = new Update(Customer.UpdateEmail);
                    cust = update(email, password, newX);
                    if (cust != null)
                        Label1.Text = "Account updated";
                    else
                        Label1.Text = "Failed";
                }
                if (TextBox11.Text == "Password")
                {
                    update = new Update(Customer.UpdatePassword);
                    cust = update(email, password, newX);
                    if (cust != null)
                        Label1.Text = "Account updated";
                    else
                        Label1.Text = "Failed";
                }
                if (TextBox11.Text == "Username")
                {
                    update = new Update(Customer.UpdateUsername);
                    cust = update(email, password, newX);
                    if (cust != null)
                        Label1.Text = "Account updated";
                    else
                        Label1.Text = "Failed";
                }
            }
            else
                Label1.Text = "email/password incorrect";

            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //string email = TextBox13.Text;
            //string password = TextBox14.Text;
            //if (email == "" || password == "")
            //    Label1.Text = "Empty Email/Password";
            //else
            //{
            //    bool result= Customer.DeleteAccount();
            //    if (result)
            //        Label1.Text = "Account deleted successfully";
            //    else
            //        Label1.Text = "incorrect email/password";


            //}
        }
    }
}