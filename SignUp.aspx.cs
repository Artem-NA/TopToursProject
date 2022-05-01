using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace toptours1
{
    public partial class SignUp : System.Web.UI.Page
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
            //Get url image
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string path= Server.MapPath(FileUpload1.FileName);
            if (filename == "")
            {
                filename = "DefaultProfile.png";
                path = @"C:\Users\artem\source\repos\toptours1\imgs";
            }
            if (!IsValidInput(fn) || !IsValidInput(ln) || !IsValidInput(username) || !IsValidInput(password))
            {
                Label1.Text = "Invaild field detected";
                return;
            }
            if (!IsValidEmail(email))
            {
                Label1.Text = "Invaild email";
                return;
            }
            if (Customer.SignUp(fn, ln, username, password, email,filename,path) == null)
            {
                Label1.Text = "Email already taken,Try again with  a different email";
                return;
            }
            Customer cust = Customer.Login(email, password);
            Session["Customer"] = cust;
            Response.Redirect("Home.aspx");
        }
        public static bool IsValidInput(string str)
        {
            return (str.Length > 1);
        }
        //check if email has @ symbol and 3 part in it
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}