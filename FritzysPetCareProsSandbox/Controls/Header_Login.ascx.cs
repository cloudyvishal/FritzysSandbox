using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

using BCL.Utility.Contents;
using BCL.Utility.SendMailMgr;
using BCL.Utility.StoreFrontClass;
using BCL.Utility.GlobalFunctions;

namespace FritzysPetCarePros.Controls
{
    public partial class Header_Login : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["HomePath"] = ConfigurationManager.AppSettings["HomePathValue"].ToString();

                lnkLogo.HRef = ConfigurationManager.AppSettings["HomePathValue"] + "index.aspx";

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

                lblLoginerror.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            StoreFront objStoreFront = null;

            DataSet ds = null;

            try
            {
                objStoreFront = new StoreFront();

                BasePage bPage = new BasePage();

                ds = new DataSet();

                ds = objStoreFront.GetLoginUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["MemberName"] = ds.Tables[0].Rows[0]["FullName"].ToString();

                    Session["UserId"] = ds.Tables[0].Rows[0]["UserID"].ToString();

                    Session["IsLogin"] = "1";

                    Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();

                    Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();

                    bPage.SessionManagement.MemberName = ds.Tables[0].Rows[0]["FullName"].ToString();

                    bPage.SessionManagement.UserId = ds.Tables[0].Rows[0]["UserID"].ToString();

                    bPage.SessionManagement.IsLogin = "1";

                    bPage.SessionManagement.UserType = Convert.ToString(ds.Tables[0].Rows[0]["UserType"]);

                    bPage.SessionManagement.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();

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

                        if (Request.Cookies["IsLogin"] == null)
                        {
                            HttpCookie c = new HttpCookie("IsLogin", "1");

                            c.Expires = new DateTime(2015, 12, 1);

                            Response.Cookies.Add(c);
                        }

                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Response.Cookies["remUsername"].Expires = DateTime.Now.AddYears(-30);

                        Response.Cookies["remPassword"].Expires = DateTime.Now.AddYears(-30);

                        HttpCookie c = new HttpCookie("IsLogin", "0");

                        c.Expires = new DateTime(2015, 12, 1);

                        Response.Cookies.Add(c);

                        Response.Redirect("Index.aspx");
                    }

                }
                else
                {
                    lblLoginerror.Visible = true;

                    ModalLogin.Show();
                }
            }
            finally
            {
                objStoreFront = null;

                ds.Dispose();
            }
        }

        protected void ImgSubmitForgot1_Click(object sender, ImageClickEventArgs e)
        {
            Global ObjPassword = null;

            Global ObjSubjec = null;

            SendMails ObjMai = null;

            try
            {
                divForgot.Attributes.Add("Style", "display:none");

                DivlnkForgot.Attributes.Add("Style", "display:block");

                divlblForgotmessage.Attributes.Add("Style", "display:block");

                ObjPassword = new Global();

                DataSet ds = new DataSet();

                ds = ObjPassword.GetPasswordAdmin(txtforgotUsername.Text.Trim());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblForgotmessage.Text = "<br> Please check your mail account <br> for username and password";


                    string Message = ContentManager.GetStaticeContentEmail("ForgotPassword.htm").Replace("~", "#");

                    Message = Message.Replace("<!-- Username -->", txtforgotUsername.Text.Trim());

                    Message = Message.Replace("<!-- Password -->", ds.Tables[0].Rows[0]["Password"].ToString());

                    ObjSubjec = new Global();

                    DataSet ds_Subject = ObjSubjec.GetEmailSubject("ForgotPassword.htm");

                    ObjMai = new SendMails();

                    ObjMai.SendEmails(ConfigurationManager.AppSettings["FromEmail"], txtforgotUsername.Text.Trim(), ds_Subject.Tables[0].Rows[0]["Subject"].ToString(), Message);
                }
                else
                {
                    lblForgotmessage.Text = "<br> Please enter valid username.<br> ";
                }
                DivlnkForgot.Attributes.Add("Style", "display:none");

                ModalLogin.CancelControlID = "closeLoginWindow";

                ModalLogin.Show();

                txtforgotUsername.Text = "";
            }
            finally
            {
                ObjPassword = null;

                ObjSubjec = null;

                ObjMai = null;
            }
        }

        protected void btnSearchLogout_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Search.aspx?Key=" + txtSearchLogin.Text.Trim());
        }
    }
}