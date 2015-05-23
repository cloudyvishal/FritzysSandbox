using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.Mail;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

using BCL.Utility.GlobalFunctions;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Global ObjForGot = null;

            DataSet ds = null;

            try
            {
                if (txtUserId.Text != "")
                {
                    ObjForGot = new Global();

                    ds = new DataSet();

                    ds = ObjForGot.GetPassword(txtUserId.Text.Trim());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Sendmail(ds.Tables[0].Rows[0]["FullName"].ToString(), ds.Tables[0].Rows[0]["Email"].ToString(), ds.Tables[0].Rows[0]["UserName"].ToString(), ds.Tables[0].Rows[0]["Password"].ToString());
                       
                        lblError.Text = "Please check your mail account for username and password";
                    }
                    else
                    {
                        lblError.Text = "Please enter correct Username";
                    }
                }
            }
            finally
            {
                ObjForGot = null;

                ds.Dispose();
            }
        }

        public void Sendmail(string FullName, string Email, string Username, string Password)
        {
            try
            {
                string Message = " <table cellpadding='5' cellspacing='0' width='50%' border='1' style='background:#F1EBE2;'>" +
                  "<tr><td colspan='2'> Hello " + FullName.ToString() + ",<br> Your login details are as follows:.</td>" +
                  "</tr><tr><td style='width:20%;'>Username :</td>" +
                  "<td> " + Username + "</td>" +
                  "</tr><tr><td>Password :</td>" +
                  "<td> " + Password + "</td></tr>" +
                  "<tr><td colspan='2'>Have a great time on Fritzy's, <br>The Fritzy's Team. <br> <a href='http://www.localhost:50372/Fritzy/Admin'> http://www.localhost:50372/Fritzy/Admin </a></td></tr></table>";

                //string Message = "<table>";
                //string Message = "Test";
                MailMessage msg = new MailMessage();
                msg.From = ConfigurationSettings.AppSettings["FromEmail"];
                msg.To = Email.ToString();
                msg.Subject = "Forgot Password";
                msg.BodyFormat = MailFormat.Html;
                msg.Priority = MailPriority.Normal;

                string message = Message;
                msg.Body = message;
                SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SmtpServer"];

                msg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = System.Configuration.ConfigurationSettings.AppSettings["SmtpServer"];
                msg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}