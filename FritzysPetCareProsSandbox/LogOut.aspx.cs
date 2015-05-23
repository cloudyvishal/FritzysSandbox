using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class LogOut : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManagement.IsLogin = "0";

            SessionManagement.UserId = "4";

            SessionManagement.MemberName = "0";

            Response.Redirect("http://localhost:50372/Default.aspx", false);
        }
    }
}