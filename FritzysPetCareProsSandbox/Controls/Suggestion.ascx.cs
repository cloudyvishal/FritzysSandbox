using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.Mail;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Utility.Contents;
using BCL.Utility.GlobalFunctions;

namespace FritzysPetCarePros.Controls
{
    public partial class Suggestion : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSuggestion.ImageUrl = ConfigurationManager.AppSettings["HomePathValue"] + "Images/btn_suggestion_box_bg.jpg";
        }

        protected void btnSumbmit_Click(object sender, ImageClickEventArgs e)
        {
            Global Obj_Suggest = new Global();

            Obj_Suggest.AddSuggestion(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtComment.Text.Trim());

            string Message = ContentManager.GetStaticeContentEmail("Suggestion.htm").Replace("~", "#");

            Message = Message.Replace("<!-- Name -->", txtName.Text.Trim());

            Message = Message.Replace("<!-- Email -->", txtEmail.Text.Trim());

            Message = Message.Replace("<!-- Phone -->", txtPhone.Text.Trim());

            Message = Message.Replace("<!-- Suggestion -->", txtComment.Text.Trim());

            try
            {

                MailMessage msg = new MailMessage();

                msg.From = txtEmail.Text;

                msg.To = ConfigurationManager.AppSettings["ToEmail"];

                msg.Subject = "Suggestion from : " + txtName.Text.Trim();

                msg.BodyFormat = MailFormat.Html;

                msg.Priority = MailPriority.Normal;

                string message = Message;

                msg.Body = message;

                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                msg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];

                msg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(msg);

                txtName.Text = "";
                
                txtEmail.Text = "";
                
                txtPhone.Text = "";

                txtComment.Text = "";
            }
            finally
            { }
        }
    }
}