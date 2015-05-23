
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
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void BindFckEditor()
        {
            FCKeditor2.ImageBrowserURL = ConfigurationManager.AppSettings["HomePathValue"] + "FCKeditor/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Images&Connector=connectors/aspx/connector.aspx";
            
            FCKeditor2.BasePath = "~/FCKeditor/FCKeditor/";
            
            string FileName = "AboutUs.htm";
            
            FCKeditor2.Value = ContentManager.GetRightHandSectionFileContent(FileName).Replace("~", "#");
            
            FCKeditor2.Height = 300;
            
            FCKeditor2.Width = 810;
            
            FCKeditor2.SkinPath = "skins/silver/";
        }

        #endregion

        #region "SaveFile"

        protected void SaveFile(string StrContent)
        {
            try
            {
                string Fullpath = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/AboutUs.htm";

                string fullpath2 = ContentManager.GetPhysicalPath(Fullpath);

                FileStream file = new FileStream(fullpath2, FileMode.Create, FileAccess.Write);

                StreamWriter sw = new StreamWriter(file);

                sw.WriteLine(StrContent);

                sw.Close();

                file.Close();

                SuccessMessage("Your content has been saved. ");
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
            Response.Redirect("AdminHome.aspx");
        }

        #endregion
    }
}