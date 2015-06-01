using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using BCL.Utility.Contents;
using BCL.Utility.GlobalFunctions;

namespace MobileWeb
{
    public partial class MB_AboutUs : BasePage
    {
        #region "Declare Variables"

        PagedDataSource PageDs = new PagedDataSource();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/StaticeContent/AboutUs.htm"));
            }
        }

        protected void BindData()
        {
            Global ObjGlobal = null;

            DataSet ds = null;

            try
            {
                ObjGlobal = new Global();

                ds = new DataSet();

                ds = ObjGlobal.GetNewsOnStoreFront();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    PageDs.DataSource = ds.Tables[0].DefaultView;

                    PageDs.AllowPaging = true;

                    PageDs.PageSize = 8;

                    dtlNews.DataSource = PageDs;

                    dtlNews.DataBind();
                }
            }
            finally
            {
                ObjGlobal = null;

                ds.Dispose();
            }
        }

        protected void dtlNews_ItemDataBound(object sender, DataListItemEventArgs e)
        {
        }
    }
}