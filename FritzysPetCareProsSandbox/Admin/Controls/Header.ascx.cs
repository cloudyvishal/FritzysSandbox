using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin.Controls
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUserName"] != null)
            {
                lblTDate.Text = System.DateTime.Now.ToString();

                lblUsername.Text = Session["AdminUserName"].ToString();
            }
            else
            {
                Response.Redirect("~/admin/default.aspx?mode=exp");
            }
        }

        protected void Menu_admin_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "Logout")
            {
                Session.Abandon();

                Session.Clear();

                Response.Redirect("~/Admin/default.aspx");
            }
        }
    }
}