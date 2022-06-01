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
    public partial class Signup1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.Print("Hello World");
        }

        protected void LoginB_Click(object sender, EventArgs e)
        {
            string fn = FirstName.Value;
            string ln = LastName.Value;
            string username = Username.Value;
            string password = Password.Value;
            string email = Email.Value;
            //Get url image\
            string folderPath = Server.MapPath(@"~\images\");
            file1.SaveAs(folderPath + Path.GetFileName(file1.FileName));
            //Debug.Print("lollll"+folderPath + Path.GetFileName(FileUpload1.FileName));
            
            string filename = Path.GetFileName(file1.PostedFile.FileName);
            //string path = Server.MapPath(file1.PostedFile.FileName);
            if (filename == "")
            {
                filename = "DefaultProfile.png";
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
            if (Customer.SignUp(fn, ln, username, password, email, filename) == null)
            {
                Label1.Text = "Email already taken,Try again with  a different email";
                return;
            }
            Customer cust = Customer.Login(email, password);
            Session["Customer"] = cust;
            Response.Redirect("Home2.aspx");
        }
        public static bool IsValidInput(string str)
        {
            //set min length and max length to input
            return (str.Length > 1 && str.Length < 100);
                
        }
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