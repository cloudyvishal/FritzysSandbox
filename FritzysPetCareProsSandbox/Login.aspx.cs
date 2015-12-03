using BCL.Admin.StoreFrontMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkForgotPassword.PostBackUrl = "";

            if (!IsPostBack)
            {
                if (Request.Cookies["remUsername"] != null)
                {
                    txtUsername.Text = Request.Cookies["remUsername"].Value.ToString();
                    chkRemember.Checked = true;
                }
                if (Request.Cookies["remPassword"] != null)
                {
                    txtPassword.Attributes.Add("value", Request.Cookies["remPassword"].Value.ToString());
                    chkRemember.Checked = true;

                }
            }
        }

        #region Login
        protected void btnLogin_Click1(object sender, ImageClickEventArgs e)
        {
            StoreFront objStoreFront = new StoreFront();

            DataSet ds = new DataSet();

            ds = objStoreFront.GetLoginUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.SessionManagement.MemberName = ds.Tables[0].Rows[0]["FullName"].ToString();

                this.SessionManagement.UserId = ds.Tables[0].Rows[0]["UserID"].ToString();

                this.SessionManagement.IsLogin = "1";

                lblLoginerror.Visible = false;

                if (chkRemember.Checked == true)
                {
                    HttpContext.Current.Request.Cookies.Clear();
                    if (Request.Cookies["remUsername"] == null)
                    {
                        HttpCookie c = new HttpCookie("remUsername", txtUsername.Text);
                        c.Expires = new DateTime(2015, 12, 1);
                        Response.Cookies.Add(c);
                    }
                    if (Request.Cookies["remPassword"] == null)
                    {
                        HttpCookie c = new HttpCookie("remPassword", txtPassword.Text);
                        c.Expires = new DateTime(2015, 12, 1);
                        Response.Cookies.Add(c);
                    }
                }
                else
                {
                    Response.Cookies["remUsername"].Expires = DateTime.Now.AddYears(-30);
                    Response.Cookies["remPassword"].Expires = DateTime.Now.AddYears(-30);
                }
                Response.Redirect("index.aspx");
            }
            else
            {
                lblLoginerror.Visible = true;
            }
        }
        #endregion

        protected void btnSumbmit_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}