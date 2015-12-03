using BCL.Admin.StoreFrontMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb.MB_Controls
{
    public partial class Services_Cat : System.Web.UI.UserControl
    {
        PagedDataSource PageDs = new PagedDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindHeader();

                BindData();
            }
        }

        public void BindData()
        {
            StoreFront ObjService = null;

            DataSet ds = null;

            try
            {
                ObjService = new StoreFront();

                ds = new DataSet();

                ds = ObjService.GetAllCatDogService();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int currpage;

                    PageDs.DataSource = ds.Tables[0].DefaultView;

                    PageDs.AllowPaging = true;

                    PageDs.PageSize = 50;

                    if (ViewState["CurrentPage"] != null)
                    {
                        currpage = Convert.ToInt32(ViewState["CurrentPage"]);
                    }
                    else
                    {
                        currpage = 1;
                    }
                    ViewState["CurrentPage"] = currpage;

                    PageDs.CurrentPageIndex = currpage - 1;

                    bool check = false;

                    if (PageDs.IsFirstPage)
                    {
                        check = true;
                    }
                    else if (PageDs.IsLastPage)
                    {
                        check = true;
                    }
                    if (PageDs.PageCount == 1)
                    {

                    }
                    else if (PageDs.PageCount > 1 && check == false)
                    {
                    }
                    if (ds.Tables[1].Rows.Count == 0)
                    {
                        dlCat.Visible = false;
                    }
                    else
                    {
                        Session["PDSAllNewestProviders"] = PageDs;

                        dlCat.DataSource = PageDs;

                        dlCat.DataBind();
                    }
                }
                else
                {
                    dlCat.Visible = false;
                }
            }
            finally
            {
                ObjService = null;

                ds.Dispose();
            }
        }

        public void BindHeader()
        {
            StoreFront ObjStoreFront = null;

            DataSet ds = null;

            try
            {
                ObjStoreFront = new StoreFront();

                ds = new DataSet();

                if (!(null == Request.Cookies["IsLogin"]))
                {
                    ds = ObjStoreFront.GetServicePageServices(Convert.ToInt32(Session["UserType"].ToString()), 1);

                    if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "1"))
                    {
                        divCatService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();

                        imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();

                        imgCatservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
                    }
                }
                else
                {
                    ds = ObjStoreFront.GetServicePageServices(4, 1);

                    if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "1"))
                    {
                        divCatService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();

                        imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();

                        imgCatservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
                    }
                }
            }
            finally
            {
                ObjStoreFront = null;

                ds.Dispose();
            }
        }

        protected void lnkPrev_Click(object sender, EventArgs e)
        {
            PageDs = (PagedDataSource)Session["PDSAllNewestProviders"];

            if (!PageDs.IsFirstPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage"])) - 1;

                ViewState["CurrentPage"] = currPage.ToString();

                BindData();
            }
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            PageDs = (PagedDataSource)Session["PDSAllNewestProviders"];

            if (!PageDs.IsLastPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage"])) + 1;

                ViewState["CurrentPage"] = currPage.ToString();

                BindData();
            }
        }
    }
}