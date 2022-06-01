using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace toptours1
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    Customer cust = (Customer)Session["customer"];
                    IsLogged.Text = "LOG OUT";
                    ListItem profile = new ListItem { Value = "Profile2.aspx", Text = cust.Username };
                    ListItem Admins = new ListItem { Value = "Admins.aspx", Text = "ADMINS" };
                    BulletedList1.Items.Add(profile);
                    BulletedList1.Items.Add(Admins);


                }
                else
                    IsLogged.Text = "LOGIN";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string name = Name.Value;
            string email = Email.Value;
            string subject = Subject.Value;
            string content = Message.Value;
            SmtpClient client = new SmtpClient("smtp.gmail.com"); //mail address format
            MailMessage message = new MailMessage();
            message.From = new MailAddress("infotoptours10@gmail.com");
            message.To.Add(email);
            message.Subject = "TopTours- Approval of the request";
            message.Body = "Hello "+name +" ,We approved your request successfully, answer will be within 24 hours";
            client.UseDefaultCredentials = false;
            client.Port = 587; //Gmail's port
            client.Credentials = new System.Net.NetworkCredential("infotoptours10", "top12345$");
            client.EnableSsl = true;
            client.Send(message);

            //send content to topToursMail
            SmtpClient client1 = new SmtpClient("smtp.gmail.com"); //mail address format
            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress("infotoptours10@gmail.com");
            message1.To.Add("infotoptours10@gmail.com");
            message1.Subject = subject + "From:"+email;
            message1.Body = content;
            client1.UseDefaultCredentials = false;
            client1.Port = 587; //Gmail's port
            client1.Credentials = new System.Net.NetworkCredential("infotoptours10", "top12345$");
            client1.EnableSsl = true;
            client1.Send(message1);
            Response.Write("<script>alert('Your request had been sent, check your email to verify!');</script>");
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