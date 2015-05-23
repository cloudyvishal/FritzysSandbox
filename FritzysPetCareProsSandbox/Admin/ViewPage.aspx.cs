
using BCL.Utility.Contents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string FileName = Request.QueryString["File"].ToString();
            if (FileName == "WhatsNew.htm")
            {
                Page.Title = "View - What's This";
                lblHead.Text = "What's This Content";
            }
            else if (FileName == "Products.htm")
            {
                lblHead.Text = "Products";
                Page.Title = "View - Products Content";
            }
            else if (FileName == "GiftCard.htm")
            {
                lblHead.Text = "Gift Card";
                Page.Title = "View - Gift Card Content";
            }
            else if (FileName == "AboutUs.htm")
            {
                lblHead.Text = "About Us Content";
                Page.Title = "View - About Us Content";
            }

            else if (FileName == "Appointment.htm")
            {
                lblHead.Text = "Appointment Content";
                Page.Title = "View - Appointment Content";
            }

            else if (FileName == "RegistrationUpdate.htm")
            {
                lblHead.Text = "My Account Content";
                Page.Title = "View - My Account Content";
            }
            else if (FileName == "Registratio_Full.htm")
            {
                lblHead.Text = "Registration Content";
                Page.Title = "View - Registration Content";
            }
            else if (FileName == "Registration_Basic.htm")
            {
                lblHead.Text = "Registration Basic";
                Page.Title = "View - Registration Content";
            }
            ViewState["FileName"] = FileName;

            if (!IsPostBack)
            {
                BindFckEditor();
            }
        }

        #region "bindData"

        public void SuccessMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        #endregion

        protected void BindFckEditor()
        {
            string FileName = ViewState["FileName"].ToString();

            FCKeditor2.Value = ContentManager.GetStaticeContent(FileName).Replace("~", "#");

            FCKeditor2.Height = 300;

            FCKeditor2.Width = 810;

            FCKeditor2.SkinPath = "skins/silver/";
        }

        #region "SaveFile"
        protected void SaveFile(string StrContent)
        {
            try
            {
                string Fullpath = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/StaticeContent/" + ViewState["FileName"].ToString();

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
        #endregion

        #region "Save Btn"
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFile(FCKeditor2.Value);
            } finally{}
        }
        #endregion 

        #region "cancelBtn"
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaticWebPages.aspx");
        }
        #endregion
    }
}