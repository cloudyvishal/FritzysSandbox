using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCL.Users.Management;
using System.Configuration;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["AdminPath"] = ConfigurationManager.AppSettings["AdminPathValue"].ToString();
            string VisitorIPAddress = Request.UserHostAddress.ToString();
            string FakeIp1 = "69.230.59.106";
            string FakeIp2 = "76.167.105.185";
            // lblip1.Text = VisitorIPAddress;
            if (VisitorIPAddress == FakeIp1 || VisitorIPAddress == FakeIp2)
            {
                string virtualpath2 = ConfigurationManager.AppSettings["HomePathValue"].ToString();
                Response.Redirect("../index.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.Cookies["RemeberMe"] != null)
                {
                    txtUserId.Text = Request.Cookies["RemeberMe"].Value.ToString();
                    chkRemember.Checked = true;
                }
                if (Request.Cookies["RemeberMePassword"] != null)
                {
                    txtPass.Attributes.Add("value", Request.Cookies["RemeberMePassword"].Value.ToString());
                    chkRemember.Checked = true;

                }
            }
        }

        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "" || txtPass.Text == "")
            {
                ErrMessage("Please Enter UserName/Password.");
            }
            else
            {
                GetUser();

            }
        }

        public void GetUser()
        {
            try
            {
                DataSet DT = new DataSet();

                User ObjUser = new User();

                DT = ObjUser.GetUser(txtUserId.Text, txtPass.Text);

                if (DT.Tables[0].Rows.Count > 0)
                {
                    Session["AdminUserName"] = DT.Tables[0].Rows[0]["Firstname"].ToString() + " " + DT.Tables[0].Rows[0]["Lastname"].ToString();

                    Session["UserID"] = DT.Tables[0].Rows[0]["UserID"].ToString();

                    Session["AdminUserType"] = DT.Tables[0].Rows[0]["UserType"].ToString();

                    if (chkRemember.Checked)
                    {
                        HttpContext.Current.Request.Cookies.Clear();

                        if (Request.Cookies["RemeberMe"] == null)
                        {
                            HttpCookie c = new HttpCookie("RemeberMe", txtUserId.Text);

                            c.Expires = new DateTime(2015, 12, 1);

                            Response.Cookies.Add(c);
                        }
                        if (Request.Cookies["RemeberMePassword"] == null)
                        {
                            HttpCookie c = new HttpCookie("RemeberMePassword", txtPass.Text);

                            c.Expires = new DateTime(2015, 12, 1);

                            Response.Cookies.Add(c);
                        }
                    }
                    else
                    {
                        Response.Cookies["RemeberMe"].Expires = DateTime.Now.AddYears(-30);

                        Response.Cookies["RemeberMePassword"].Expires = DateTime.Now.AddYears(-30);

                    }

                    Response.Redirect("AdminHome.aspx");

                }
                else
                {
                    ErrMessage("Please verify your username and password");
                }
            }
            finally
            {
                //  ErrorMessage(ex.Message.ToString());
            }
        }
    }
}