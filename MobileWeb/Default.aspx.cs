using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb
{
    public partial class _Default : BasePage
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

            Session["MobilePath"] = Session["HomePath"] + "mobileweb/";

            HttpContext.Current.Response.Status = "301 Moved Permanently";

            string rawUrl = Request.RawUrl;

            HttpContext.Current.Response.AddHeader("Location",
            Request.Url.ToString().Replace(Request.Url.ToString(), (ConfigurationManager.AppSettings["HomePathValue"] + "MB_Index.aspx").ToLower()));

            Response.Redirect(ConfigurationManager.AppSettings["HomePathValue"] + "MB_AboutUs.aspx", false);
        }
    }
}