
using BCL.Utility.GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class EditNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindData();
                }
                finally
                { }
            }
        }

        #region Declare

        protected int NewsID
        {
            get
            {
                if (Request.QueryString["NewsID"] != null)
                {
                    return int.Parse(Request.QueryString["NewsID"].ToString());
                }
                else
                {
                    return 0;
                }
            }
        }

        /* Error message and success messages are use to display messages to user*/
        public void ErrorMessage(string Message)
        {
            divError.Visible = true;

            lblError.Attributes.Add("Class", "errorTable");

            lblError.Visible = true;

            lblError.Text = Message;
        }

        public void SuccessMessage(string Message)
        {
            divError.Visible = true;

            lblError.Attributes.Add("Class", "successTable");

            lblError.Visible = true;

            lblError.Text = Message;
        }

        //Fuunction use to set the fckeditor
        protected void BindFckEditor(string FileName)
        {
            FCKeditor2.Value = FileName.ToString(); 

            FCKeditor2.Height = 500;

            FCKeditor2.Width = 640;

            FCKeditor2.SkinPath = "skins/silver/";
        }

        /* Bind data is use to bind all news detail from database */
        protected void BindData()
        {
            try
            {
                Global ObjNews = new Global();

                DataSet ds = new DataSet();

                ds = ObjNews.GetNews(NewsID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTitle.Text = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                    
                    txtShortDesc.Text = ds.Tables[0].Rows[0]["ShortDescription"].ToString();
                    
                    BindFckEditor(ds.Tables[0].Rows[0]["Description"].ToString());
                }
                else
                {
                    ErrorMessage("No record found");
                }
            } finally{}
        }
        #endregion

        #region Event
        /* Event is use to update Update information in  database*/
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Global ObjNews = new Global();
                
                ObjNews.UpdateNews(NewsID, txtTitle.Text.Trim(), txtShortDesc.Text.Trim(), FCKeditor2.Value);
                
                BindData();

                SuccessMessage("Updated successfully");
            } finally{}
        }
        #endregion

        protected void btnPreview_Click(object sender, EventArgs e)
        {

            string url = "NewsDetails.aspx?ID=" + NewsID;

            string script = "window.open('" + url + "','')";

            if (!ClientScript.IsClientScriptBlockRegistered("NewWindow"))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "NewWindow", script, true);
            }
        }
    }
}