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
            string routeName = TextBox1.Text;
            if (Review.AddReview(content, rating, caption, cust, routeName) == null)
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
            Review r = Review.GetReview(cust, caption);
            r.DeleteReview();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string content = TextBox2.Text;
            string rating = TextBox3.Text;
            string caption = TextBox4.Text;
            Review r = Review.GetReview(cust, caption);
            if (r == null)
            {
                Label1.Text = "Update failed";
                return;
            }
            r.UpdateCaption(caption);
            r.UpdateRating(rating);
            r.UpdateContent(content);
            Label1.Text = "Review Updated Successfully";


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            string caption = TextBox4.Text;
            Review r = Review.GetReview(cust, caption);
            if (r == null) { Label1.Text = "There is not review with that name"; return; }
            TextBox2.Text = r.Content;
            TextBox3.Text = Convert.ToString(r.Rating);
            TextBox1.Text = r.GetRouteName(cust);
           // TextBox3.Text = Convert.ToString(r.Rating);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}