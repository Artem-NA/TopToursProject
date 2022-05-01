using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace toptours1
{
    /// <summary>
    /// Summary description for TopTours
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TopTours : System.Web.Services.WebService //get all xmls
    {

        [WebMethod] //with this tag, you expose the function to the internet
        public string HelloWorld(string name)
        {
            return $@"Hello {name}!!!!";
        }
        [WebMethod] 
        public string Gay(string gender) 
        {

            return "";
        
        
        }

    }
}
