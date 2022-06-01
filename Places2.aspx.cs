using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;

namespace toptours1
{
    public partial class Places2 : System.Web.UI.Page
    {
        public List<Place> lst;
        //variable that contains a list of places that customer created
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
                Response.Redirect("Login.aspx");
            Customer cust = (Customer)Session["customer"];
            //if (!IsPostBack)
            //{
                List<Place> lst =null;
                if (Place.GetAllMyPlaces(cust) != null)
                {
                    lst = Place.GetAllMyPlaces(cust);
                }
                this.lst = lst;
            //}
            if (!IsPostBack)
            {
                BulletedList2.DisplayMode = BulletedListDisplayMode.HyperLink;
                ListItem home = new ListItem { Value = "Home2.aspx", Text = "HOME" };
                ListItem places = new ListItem { Value = "Places2.aspx", Text = "PLACES" };
                ListItem routess = new ListItem { Value = "Routes2.aspx", Text = "ROUTES" };
                ListItem aboutus = new ListItem { Value = "AboutUs2.aspx", Text = "ABOUT US" };
                ListItem contactus = new ListItem { Value = "ContactUs.aspx", Text = "CONTACT US" };
                BulletedList2.Items.Add(home);
                BulletedList2.Items.Add(places);
                BulletedList2.Items.Add(routess);
                BulletedList2.Items.Add(aboutus);
                BulletedList2.Items.Add(contactus);
                if (Session["customer"] != null)
                {
                    
                    IsLogged.Text = "LOG OUT";
                    ListItem profile = new ListItem { Value = "Profile2.aspx", Text = cust.Username };
                    ListItem Admins = new ListItem { Value = "Admins.aspx", Text = "ADMINS" };
                    BulletedList2.Items.Add(profile);
                    BulletedList2.Items.Add(Admins);


                }
                else
                    IsLogged.Text = "LOGIN";
            }
        }
        public static string Filter(string str, List<char> charsToRemove)
        {
            foreach (char c in charsToRemove)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }

            return str;
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            bool IsPrivate=false;
            string placeName = Name.Value;
            string placeInfo = Info.Value;
            string elnla = Text1.Value;
            Debug.Print("1:" + elnla);
            List<char> charsToRemove = new List<char>() { 'L', 'n', 'g', 'a','t','(',')',' ' };

            elnla = Filter(elnla,charsToRemove);
            Debug.Print("2:" + elnla);
            string[] halfs = elnla.Split(',');
            string longitudeSt = halfs[0] ;
            string latitudeSt=halfs[1];
            string folderPath = Server.MapPath(@"~\images\");
            file1.SaveAs(folderPath + Path.GetFileName(file1.FileName));
            //Debug.Print("lollll"+folderPath + Path.GetFileName(FileUpload1.FileName));

            string filename = Path.GetFileName(file1.PostedFile.FileName);
            //string path = Server.MapPath(file1.PostedFile.FileName);
            if (filename == "")
            {
                filename = "DefaultProfile.png";
            }
            if (RadioButton1.Checked)
                IsPrivate = true;
            if (!IsValidInput(placeName) || !IsValidInput(placeInfo) || !IsValidInput(longitudeSt) || !IsValidInput(latitudeSt))
            {
                Response.Write("<script>alert('Invaild Data');</script>");
                return;
            }
            Place place = Place.AddPlace(placeName, placeInfo, (float)Convert.ToDouble(longitudeSt), (float)Convert.ToDouble(latitudeSt), IsPrivate, cust.CustomerID,filename);
            if (place == null)
            { Response.Write("<script>alert('Place was not created');</script>"); }
            else
            { Response.Write("<script>alert('Place created successfully');</script>");
                Response.AddHeader("REFRESH", $"1;URL=Places2.aspx");
            }
        }
        public static bool IsValidInput(string str)
        {
            //set min length and max length to input
            return (str.Length > 1 && str.Length < 10000);

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            BulletedList1.Items.Clear();
            BulletedList1.DisplayMode = BulletedListDisplayMode.HyperLink;
            string value = searchValue.Value;
            if (Place.SearchPlace(value) == null)
            {
                ListItem listItem = new ListItem { Text = "No Places found,try again" };
                BulletedList1.Items.Add(listItem);
                return;
            }
            List<Place> places = Place.SearchPlace(value);
            for (int i = 0; i < places.Count; i++)
            {
                Place place = places[i];
                ListItem listItem = new ListItem
                {
                    Text = place.PlaceName,
                    Value = "PlaceShow.aspx?" + "name=" + place.PlaceName
                };
                BulletedList1.Items.Add(listItem);
            }

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