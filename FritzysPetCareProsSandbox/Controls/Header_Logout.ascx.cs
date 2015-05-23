using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace FritzysPetCarePros.Controls
{
    public partial class Header_Logout : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkLogo.HRef = Session["HomePath"] + "Index.aspx";
        }

        protected void btnSearchLogin_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Search.aspx?Key=" + txtSearchLogout.Text.Trim());
        }
    }
}