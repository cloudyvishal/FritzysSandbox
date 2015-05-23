using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["HomePath"] = ConfigurationManager.AppSettings["HomePathValue"].ToString();

            Session["HomePath"] = ConfigurationManager.AppSettings["HomePathValue"].ToString();     // Session["Homepath"] use to set root directory path and this path can be set from Web.config

            Session["AdminPath"] = Session["HomePath"] + "Admin/";                             // Session["AdminPath"] use to set root directory path of admin folder 

            Session["StaticContentPhysicalPath"] = Session["HomePath"] + "StoreData/";

            Session["MemberName"] = null;                                                      // Session["MemberName"] Use to store member name display on home page 

            Session["IsLogin"] = "0";                                                          // Session["IsLogin"] is use to check whether user is Loged in or not default Not  

            if (null == Session["UserType"] || "3" == Session["UserType"])
            {
                Session["UserType"] = "3";                                                         // Session["UserType"] is use to set UseType 0 (Cat) ,1(Dog), 2(CatDog)
            }

            Session["AdminUserType"] = "1";                                                    // Session["AdminUserType"] is user to set Admin user type 0 for admin and 1 for Subadmin

            Session["MobilePath"] = ConfigurationManager.AppSettings["MobileWebPath"];

            HttpContext.Current.Response.Status = "301 Moved Permanently";

            string rawUrl = Request.RawUrl;

            string strUserAgent = Request.UserAgent.ToString().ToLower();

            String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;

            String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");

            bool Ismobile = false;

            string[] mobiles =
                   new[]
                {
                    "midp","android","j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                     "opwv", "chtml","320x480",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi", 
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                     "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };

            foreach (string s in mobiles)
            {
                if (Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                {
                    Ismobile = true;
                }
            }
            if (Ismobile.Equals(true))
            {
                string repData = Request.Url.ToString();

                Uri uri = new Uri(repData);

                string passURL = strUrl + "FritzysMobile/Default.aspx";

                HttpContext.Current.Response.Status = "301 Moved Permanently";

                Response.Redirect(passURL, false);
            }

            else
            {
                HttpContext.Current.Response.AddHeader("Location",
                Request.Url.ToString().Replace(Request.Url.ToString(), (strUrl).ToLower()));
            }

        }
    }
}