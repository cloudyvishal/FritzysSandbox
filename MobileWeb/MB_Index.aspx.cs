using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb
{
    public partial class MB_Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                dvloginusernew.Visible = false;
                dvloginusernew1.Visible = true;
            }
            else
            {
                dvloginusernew.Visible = true;
                dvloginusernew1.Visible = false;
                Session["UserType"] = "0";
            }
        }
    }
}