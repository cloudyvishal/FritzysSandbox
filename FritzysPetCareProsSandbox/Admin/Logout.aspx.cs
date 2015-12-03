using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["AdminUserName"] = null;

            Session["UserID"] = null;

            Session.Abandon();

            Response.Redirect(Session["AdminPath"] + "default.aspx");
        }
    }
}