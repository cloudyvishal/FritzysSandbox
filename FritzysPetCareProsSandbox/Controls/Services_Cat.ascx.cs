using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using BCL.Utility.Contents;
using BCL.Admin.StoreFrontMgr;

namespace FritzysPetCarePros.Controls
{
    public partial class Services_Cat : BaseUserControl
    {
        #region Bind data

        PagedDataSource PageDs = new PagedDataSource();

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

                        lnkPrev.Visible = false;

                        lnkNext.Visible = true;
                    }
                    else if (PageDs.IsLastPage)
                    {
                        check = true;

                        lnkPrev.Visible = true;

                        lnkNext.Visible = false;
                    }
                    if (PageDs.PageCount == 1)
                    {
                        lnkPrev.Visible = false;

                        lnkNext.Visible = false;

                        lnkPrev.CssClass = "inactivelink";

                        lnkNext.CssClass = "inactivelink";
                    }
                    else if (PageDs.PageCount > 1 && check == false)
                    {
                        lnkPrev.Visible = true;

                        lnkNext.Visible = true;
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
                    if ((lnkPrev.Visible == true) && (lnkNext.Visible == true))
                    {
                        lblDivider.Visible = true;
                    }
                    else
                    {
                        lblDivider.Visible = false;
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

                if (Request.Cookies["IsLogin"].Value.ToString() == "0")
                {
                    ds = ObjStoreFront.GetServicePageServices(4, 1);
                }
                else
                {
                    ds = ObjStoreFront.GetServicePageServices(Convert.ToInt32(Session["UserType"].ToString()), 1);
                }
                if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "1"))
                {
                    divCatService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();

                    imgCatservice.ImageUrl = "~/" + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();

                    imgCatservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
                }
            }
            finally
            {
                ObjStoreFront = null;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindHeader();

                BindData();
            }
        }

        #region Links

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

        #endregion
    }
}