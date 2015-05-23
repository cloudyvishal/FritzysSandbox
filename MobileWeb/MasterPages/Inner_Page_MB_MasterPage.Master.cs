using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb.MasterPages
{
    public partial class Inner_Page_MB_MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                dvLogin.Visible = true;
                dvLogoutusers.Visible = false;
            }
            else
            {
                dvLogoutusers.Visible = true;
                dvLogin.Visible = false;
            }
        }
    }
}