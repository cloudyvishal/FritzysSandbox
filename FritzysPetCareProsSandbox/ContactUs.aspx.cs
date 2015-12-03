using BCL.Admin.StoreFrontMgr;
using BCL.Utility.CommonMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCL.Utility.Contents;

namespace FritzysPetCareProsSandbox
{
    public partial class ContactUs : System.Web.UI.Page
    {
        public void SuccessMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool Ismobile = false;
                string[] mobiles =
                new[]
                {
                    "midp","android","j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                     "opwv", "chtml","320x480",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi", 
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                     "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };
                //Loop through each item in the list created above 
                //and check if the header contains that text
                foreach (string s in mobiles)
                {
                    // if (Request.ServerVariables["HTTP_USER_AGENT"].
                    if (Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                    {
                        Ismobile = true;
                    }
                }

                if (Ismobile.Equals(true))
                {
                    string repData = Request.Url.ToString();
                    string p = repData.Replace(".com/", ".com/fritzymobile/MB_").ToLower();
                   
                    HttpContext.Current.Response.Status = "301 Moved Permanently";
                    HttpContext.Current.Response.AddHeader("Location",
                    Request.Url.ToString().Replace(Request.Url.ToString(), p));

                }

                else
                {                    

                }
            }
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
                msg.To = System.Configuration.ConfigurationManager.AppSettings["ToEmail"];
                msg.Subject = "Contact us detail : " + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
                msg.BodyFormat = MailFormat.Html;
                msg.Priority = MailPriority.Normal;

                string message = Mailbody;
                msg.Body = message;
                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                msg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"];
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