using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCarePros.Controls
{
    public partial class Footer : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsLogin"] == "1")
            {
                QualityServay.Visible = true;

                QualityServay.HRef = ConfigurationManager.AppSettings["HomePathValue"] + "Contactus.aspx";
            }
            else
            {
                QualityServay.Visible = false;
            }
        }
    }
}