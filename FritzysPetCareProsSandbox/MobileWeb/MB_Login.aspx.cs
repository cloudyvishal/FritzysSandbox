using BCL.Admin.StoreFrontMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb
{
    public partial class MB_Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserID"] = null;

            txtUserName.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            StoreFront objStoreFront = new StoreFront();
            DataSet ds = new DataSet();
            ds = objStoreFront.GetLoginUser(txtUserName.Text.Trim(), txtpassword.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["MemberName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
                Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                Session["IsLogin"] = "1";
                Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();

                lblLoginerror.Visible = false;
                Response.Cookies["remUsername"].Expires = DateTime.Now.AddYears(-30);
                Response.Cookies["remPassword"].Expires = DateTime.Now.AddYears(-30);

                HttpCookie c = new HttpCookie("IsLogin", "0");
                c.Expires = new DateTime(2015, 12, 1);
                Response.Cookies.Add(c);

                Server.Transfer("/fritzymobile/MB_index.aspx");
                // }

            }
            else
            {
                lblLoginerror.Visible = true;
                txtUserName.Text = string.Empty;
            }
        }
    }
}