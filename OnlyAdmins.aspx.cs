﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                Response.Redirect("AskToBeA.aspx");
        }

        protected void SearchB_Click(object sender, EventArgs e)
        {
            string value =ValueTB.Text;
            if (string.IsNullOrEmpty(value))
            {
                Label1.Text = "Empty value";
                return;
            }
            if (DropDownList1.SelectedValue == "0")
            {
                Label1.Text = "Please choose what you would like to delete.";
                return;
            }
            if (DropDownList1.SelectedValue == "1")
            {
                if (Place.SearchPlace(value)==null)
                {

                }
                { Label1.Text = "Account deleted successfully"; return; }
                Label1.Text = "Wrong Username";

            }
            //if (DropDownList1.SelectedValue == "2")
            //{
            //    if (Admin.DeleteAnyPlace(x, username))
            //    { Label1.Text = "Place deleted successfully"; return; }
            //    Label1.Text = "Wrong Place Name";
            //}
            //if (DropDownList1.SelectedValue == "3")
            //{
            //    if (Admin.DeleteAnyRoute(x, username))
            //    { Label1.Text = "Route deleted successfully"; return; }
            //    Label1.Text = "Wrong Route Name";
            //}
            //if (DropDownList1.SelectedValue == "4")
            //{
            //    if (Admin.DeleteAnyReview(x, username))
            //    { Label1.Text = "Account deleted successfully"; return; }
            //    Label1.Text = "Wrong Caption";
            //}
        }
    }
}