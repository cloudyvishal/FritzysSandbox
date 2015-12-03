
using BCL.Utility.Contents;
using BCL.Utility.GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ViewEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string FileName = Request.QueryString["File"].ToString();
            if (FileName == "Appointment.htm")
            {
                Page.Title = "View - Appointment Mail";
                lblHead.Text = "Appointment";
            }
            else if (FileName == "ContactUs.htm")
            {
                lblHead.Text = "Contact Us ";
                Page.Title = "View - Contact Us Mail";
            }
            else if (FileName == "ForgotPassword.htm")
            {
                lblHead.Text = "Forgot Password";
                Page.Title = "View - Forgot Password Mail";
            }
            else if (FileName == "Registration.htm")
            {
                lblHead.Text = "Registration";
                Page.Title = "View - Registration Mail";
            }
            else if (FileName == "Suggestion.htm")
            {
                lblHead.Text = "Suggestion";
                Page.Title = "View - Suggestion Mail";
            }


            ViewState["FileName"] = FileName;

            if (!IsPostBack)
            {
                try
                {
                    BindFckEditor();

                    BindSubject();
                }
                finally
                { }
            }
        }

        public void SuccessMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void BindSubject()
        {
            try
            {
                Global ObjSubjec = new Global();

                DataSet ds_Subject = ObjSubjec.GetEmailSubject(Request.QueryString["File"].ToString());

                txtSubject.Text = ds_Subject.Tables[0].Rows[0]["Subject"].ToString();
            } finally{}
        }

        protected void BindFckEditor()
        {
            string FileName = ViewState["FileName"].ToString();
           
            FCKeditor2.Value = ContentManager.GetStaticeContentEmail(FileName).Replace("~", "#");
           
            FCKeditor2.Height = 300;
           
            FCKeditor2.Width = 810;
           
            FCKeditor2.SkinPath = "skins/silver/";
        }

        #region "SaveFile"
        protected void SaveFile(string StrContent)
        {
            try
            {
                Global ObjGlobal = new Global();

                ObjGlobal.UpdateSubject(Request.QueryString["File"].ToString(), txtSubject.Text.Trim());

                string Fullpath = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/Email/" + ViewState["FileName"].ToString();

                string fullpath2 = ContentManager.GetPhysicalPath(Fullpath);

                FileStream file = new FileStream(fullpath2, FileMode.Create, FileAccess.Write);

                StreamWriter sw = new StreamWriter(file);

                sw.WriteLine(StrContent);

                sw.Close();

                file.Close();

                SuccessMessage("Your content has been saved. ");

                BindFckEditor();
            } finally{}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFile(FCKeditor2.Value);
            } finally{}
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageEmail.aspx");
        }
        #endregion
    }
}