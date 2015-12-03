using BCL.Admin.StoreFrontMgr;
using BCL.Utility.Contents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb
{
    public partial class MB_ContactUs : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SuccessMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StoreFront ObjStoreFront = new StoreFront();
            //Add to Database
            ObjStoreFront.AddContactus(txtFName.Text.Trim(),
                                        txtLName.Text.Trim(),
                                        txtContactEmail.Text.Trim(),
                                        txtMobile.Text.Trim(),
                                        txtMessage.Text.Trim()
                                        );

            SuccessMessage("Message sent successfully");
            string Mailbody = ContentManager.GetStaticeContentEmail("ContactUs.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- FirstName -->", txtFName.Text.Trim());
            Mailbody = Mailbody.Replace("<!-- LastName -->", txtLName.Text.Trim());
            Mailbody = Mailbody.Replace("<!-- Email -->", txtContactEmail.Text.Trim());
            Mailbody = Mailbody.Replace("<!-- Phone -->", txtMobile.Text.Trim());
            Mailbody = Mailbody.Replace("<!-- Suggestion -->", txtMessage.Text.Trim());

            try
            {
                MailMessage msg = new MailMessage();
                //msg.From = txtContactEmail.Text.Trim();
                msg.From = ConfigurationManager.AppSettings["FromEmail"];
                msg.To = ConfigurationManager.AppSettings["ToEmail"];
                msg.Subject = "Contact us detail : " + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
                msg.BodyFormat = MailFormat.Html;
                msg.Priority = MailPriority.Normal;

                string message = Mailbody;
                msg.Body = message;
                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];
                //SmtpMail.SmtpServer = "localhost";

                msg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];
                msg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(msg);
            }
            catch
            {
            }
            txtFName.Text = "";
            txtLName.Text = "";
            txtContactEmail.Text = "";
            txtMobile.Text = "";
            txtMessage.Text = "";

        }
    }
}