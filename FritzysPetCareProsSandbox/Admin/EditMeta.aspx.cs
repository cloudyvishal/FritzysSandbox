
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
    public partial class EditMeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MetaID"] != "")
                {
                    try
                    {
                        int UserID = int.Parse(Request.QueryString["MetaID"]);

                        Bind(UserID);
                    }
                    finally
                    { }
                }
                else
                {
                    Response.Redirect("MetaTag.aspx?SearchFor=0&SearchText=");
                }
            }
        }

        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void Bind(int MetaID)
        {
            try
            {
                DataSet ds = new DataSet();

                Global ObjGlobal = new Global();

                ds = ObjGlobal.GetMetaDetail(MetaID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();

                        txtContent.Text = ds.Tables[0].Rows[0]["MetaContent"].ToString();

                        txtKeywords.Text = ds.Tables[0].Rows[0]["Keywords"].ToString();
                    }
                    else
                    {

                    }
                }
            } finally{}
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Global ObjUser = new Global();

                ObjUser.UpdateMeta(int.Parse(Request.QueryString["MetaID"]), txtName.Text.Trim(), txtContent.Text.Trim(), txtKeywords.Text.Trim());

                SuccesfullMessage("Meta tag updated successfully.");
            } finally{}
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MetaTags.aspx?PageID=" + Request.QueryString["PageID"].ToString() + "&SearchFor=0&SearchText=");
        }
    }
}