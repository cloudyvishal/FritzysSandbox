using BCL.Admin.StoreFrontMgr;
using BCL.Utility.Contents;
using MobileWeb.Shared.CommonValues;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb
{
    public partial class Cat_SuperBowl : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData((int)(Enumeration.ServiceId.CAT_SUPERBOWL_SERVICEID), (int)(Enumeration.ServiceId.COMMON_PAGE_ID));
            }
        }

        public void BindData(int ServiceID, int PageID)
        {
            StoreFront ObjService = null;

            DataSet ds = null;

            try
            {
                ObjService = new StoreFront();

                ds = new DataSet();

                ds = ObjService.GetServiceDetailFront(ServiceID, PageID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (PageID == 1)
                    {
                        ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/" + ds.Tables[0].Rows[0]["Image"].ToString();
                        
                        lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                        
                        Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                        
                        lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                        
                        litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/" + ds.Tables[0].Rows[0]["PageName"].ToString()));
                    }
                    if (PageID == 2)
                    {
                        ImgService.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["Image"].ToString();

                        lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                    }
                    if (PageID == 3)
                    {
                        ImgService.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["Image"].ToString();

                        lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                    }
                }
                else
                {

                }
            }
            finally
            {
                ObjService = null;

                ds.Dispose();
            }
        }
    }
}