

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using BCL.Admin.HomeServices;
using BCL.Utility.CommonMethods;
using System.Web.UI.HtmlControls;
using BCL.Utility.Contents;
using System.Configuration;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ManageHomePageService : System.Web.UI.Page
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

        public void BindData()
        {
            try
            {
                HomeServices ObjHome = new HomeServices();

                DataSet ds = new DataSet();

                ds = ObjHome.GetAllHomeServiceAdmin(Convert.ToInt32(ddlUserType.SelectedValue));

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrdServiceHome.Visible = true;

                        GrdServiceHome.DataSource = ds.Tables[0];

                        GrdServiceHome.DataBind();

                        CommonFunctions.Setserial(GrdServiceHome, "srno");
                    }
                    else
                    {
                        GrdServiceHome.Visible = true;
                    }
                }
            } finally{}
        }

        protected void GrdServiceHome_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblImageName = (Label)e.Row.FindControl("lblImageName");

                HtmlImage imgThumb = (HtmlImage)e.Row.FindControl("ImageCoupon");

                string Temp = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/HomeServices/" + lblImageName.Text;

                string fulpath = ContentManager.GetPhysicalPath(Temp);

                if (System.IO.File.Exists(fulpath))
                {
                    imgThumb.Src = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/HomeServices/" + lblImageName.Text;
                }
                else
                {
                    
                }
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindData();
            } finally{}
        }
    }
}