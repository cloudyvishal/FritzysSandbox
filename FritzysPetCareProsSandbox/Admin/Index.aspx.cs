using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["AdminPath"] = ConfigurationManager.AppSettings["AdminPathValue"].ToString();

            Response.Redirect("Default.aspx", false);
        }
    }
}