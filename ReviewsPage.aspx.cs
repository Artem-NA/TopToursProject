using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace toptours1
{
    public partial class ReviewsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Route r = Route.GetRoute(GetNameFromUrl());
            Label1.Text = "Enter your review to" + r.RouteName; 
        }
        public static string GetNameFromUrl()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            return query.Get("name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string content = TextBox2.Text;
            int rating = Convert.ToInt32(TextBox3.Text);
            string caption = TextBox4.Text;
            Route r = Route.GetRoute(GetNameFromUrl());
            if (MyService.AddReview(content, rating, caption, cust.CustomerID, r.RouteID))
            {
                Label1.Text = "Review not added because route not created or the same review already created by yourself";
                return;
            }
            Label1.Text = "Review added!";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string caption = TextBox4.Text;
            localhost.Review r = MyService.GetReview(cust.CustomerID, caption);
            MyService.DeleteReview(r);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string content = TextBox2.Text;
            string rating = TextBox3.Text;
            string caption = TextBox4.Text;
            localhost.Review r = MyService.GetReview(cust.CustomerID, caption);
            if (r == null)
            {
                Label1.Text = "Update failed";
                return;
            }
            //r.UpdateCaption(caption);
            //r.UpdateRating(rating);
            //r.UpdateContent(content);
            Label1.Text = "Review Updated Successfully";


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string caption = TextBox4.Text;
            localhost.Review r = MyService.GetReview(cust.CustomerID, caption);
            if (r == null) { Label1.Text = "There is not review with that name"; return; }
            TextBox2.Text = r.Content;
            TextBox3.Text = Convert.ToString(r.Rating);
            //TextBox1.Text = r.GetRouteName(cust);
            // TextBox3.Text = Convert.ToString(r.Rating);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home2.aspx");
        }

    }
}