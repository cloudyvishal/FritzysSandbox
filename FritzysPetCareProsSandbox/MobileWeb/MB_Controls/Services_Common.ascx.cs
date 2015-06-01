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
    public partial class Services_Common : System.Web.UI.UserControl
    {
        PagedDataSource PageDs = new PagedDataSource();
        
        PagedDataSource PageDsCat = new PagedDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            StoreFront ObjService = null;

            StoreFront ObjStoreFront = null;

            DataSet ds = null;

            DataSet ds_Service = null;

            try
            {
                #region Dog

                ObjService = new StoreFront();

                ds = new DataSet();

                ds = ObjService.GetAllCatDogService();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    int currpage;

                    PageDs.DataSource = ds.Tables[1].DefaultView;

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
                        dlDog.Visible = false;
                    }
                    else
                    {
                        Session["PDSAllNewestProviders"] = PageDs;
                        dlDog.DataSource = PageDs;
                        dlDog.DataBind();
                    }
                }
                else
                {
                    dlDog.Visible = false;
                }

                #endregion Dg

                #region Cat
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int currpage;

                    PageDsCat.DataSource = ds.Tables[0].DefaultView;

                    PageDsCat.AllowPaging = true;

                    PageDsCat.PageSize = 50;

                    if (ViewState["CurrentPage_Cat"] != null)
                    {
                        currpage = Convert.ToInt32(ViewState["CurrentPage_Cat"]);
                    }
                    else
                    {
                        currpage = 1;
                    }
                    ViewState["CurrentPage_Cat"] = currpage;

                    PageDsCat.CurrentPageIndex = currpage - 1;

                    bool check = false;
                    if (PageDsCat.IsFirstPage)
                    {
                        check = true;

                    }
                    else if (PageDsCat.IsLastPage)
                    {
                        check = true;
                    }
                    if (PageDsCat.PageCount == 1)
                    {
                    }
                    else if (PageDsCat.PageCount > 1 && check == false)
                    {
                    }
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        dlCat.Visible = false;
                    }
                    else
                    {
                        Session["PDSAllNewestProviders_Cat"] = PageDsCat;
                        dlCat.DataSource = PageDsCat;
                        dlCat.DataBind();
                    }
                }
                else
                {
                    dlCat.Visible = false;
                }

                #endregion

                #region Header Services

                ds_Service = new DataSet();

                ds_Service = ObjStoreFront.GetAllServicePageServices(Convert.ToInt32(Session["UserType"].ToString()));

                if (ds_Service.Tables[1].Rows.Count > 0)
                {
                    ImgDog.ToolTip = ds_Service.Tables[1].Rows[0]["Description"].ToString();

                    divDogService.InnerText = ds_Service.Tables[1].Rows[0]["Description"].ToString();
                }
                if (ds_Service.Tables[0].Rows.Count > 0)
                {
                    imgCatservice.ToolTip = ds_Service.Tables[0].Rows[0]["Description"].ToString();

                    divCatService.InnerText = ds_Service.Tables[0].Rows[0]["Description"].ToString();
                }
                #endregion
            }
            finally
            {
                ObjStoreFront = null;

                ObjService = null;

                ds.Dispose();

                ds_Service.Dispose();
            }
        }

        protected void lnkPrev_Cat_Click(object sender, EventArgs e)
        {
            PageDsCat = (PagedDataSource)Session["PDSAllNewestProviders_Cat"];

            if (!PageDsCat.IsFirstPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage_Cat"])) - 1;

                ViewState["CurrentPage_Cat"] = currPage.ToString();

                BindData();
            }
        }

        protected void lnkNext_Cat_Click(object sender, EventArgs e)
        {
            PageDsCat = (PagedDataSource)Session["PDSAllNewestProviders_Cat"];

            if (!PageDsCat.IsLastPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage_Cat"])) + 1;

                ViewState["CurrentPage_Cat"] = currPage.ToString();

                BindData();
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