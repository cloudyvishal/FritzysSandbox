using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb
{
    public partial class MB_Logout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["MemberName"] = null;
            Session["IsLogin"] = "0";
            Session["UserType"] = "0";

            HttpCookie c = new HttpCookie("IsLogin", "0");
            c.Expires = new DateTime(2015, 12, 1);
            Response.Cookies.Add(c);
            Server.Transfer("MB_Login.aspx");
        }
    }
}