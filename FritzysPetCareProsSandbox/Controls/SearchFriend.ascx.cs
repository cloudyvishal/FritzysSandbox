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
    public partial class SearchFriend : BaseUserControl
    {
        PagedDataSource PageDs_Friend = new PagedDataSource();

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

            DataSet DS = null;

            try
            {
                ObjService = new StoreFront();

                DS = new DataSet();

                DS = ObjService.GetFriendSearch(Request.QueryString["Key"].ToString());

                if (DS.Tables[0].Rows.Count > 0)
                {
                    lblTitleFriend.Text = "Fritzy's Pet Care Pros friends listing :";

                    int currpage;

                    PageDs_Friend.DataSource = DS.Tables[0].DefaultView;

                    PageDs_Friend.AllowPaging = true;

                    PageDs_Friend.PageSize = 10;

                    if (ViewState["CurrentPage_Friend"] != null)
                    {
                        currpage = Convert.ToInt32(ViewState["CurrentPage_Friend"]);
                    }
                    else
                    {
                        currpage = 1;
                    }
                    ViewState["CurrentPage_Friend"] = currpage;

                    PageDs_Friend.CurrentPageIndex = currpage - 1;

                    bool check = false;

                    if (PageDs_Friend.IsFirstPage)
                    {
                        check = true;

                        lnkFriendPrev.Visible = false;

                        lnkFriendNext.Visible = true;

                    }
                    else if (PageDs_Friend.IsLastPage)
                    {
                        check = true;

                        lnkFriendPrev.Visible = true;

                        lnkFriendNext.Visible = false;
                    }
                    if (PageDs_Friend.PageCount == 1)
                    {
                        lnkFriendPrev.Visible = false;

                        lnkFriendNext.Visible = false;

                        lnkFriendPrev.CssClass = "linkDisable";

                        lnkFriendNext.CssClass = "linkDisable";
                    }
                    else if (PageDs_Friend.PageCount > 1 && check == false)
                    {
                        lnkFriendPrev.Visible = true;

                        lnkFriendNext.Visible = true;
                    }


                    if (DS.Tables[0].Rows.Count == 0)
                    {
                        dlFriends.Visible = false;
                    }
                    else
                    {
                        Session["PDSAllFriends"] = PageDs_Friend;

                        dlFriends.DataSource = PageDs_Friend;

                        dlFriends.DataBind();
                    }
                    if ((lnkFriendPrev.Visible == true) && (lnkFriendNext.Visible == true))
                    {
                        lblFriendLine.Visible = true;
                    }
                    else
                    {
                        lblFriendLine.Visible = false;
                    }
                }
                else
                {
                    dlFriends.Visible = false;

                    lnkFriendPrev.Visible = false;

                    lnkFriendNext.Visible = false;

                    lblFriendLine.Visible = false;

                    lblTitleFriend.Text = "No record found.";
                }
            }
            finally
            {
                ObjService = null;

                DS.Dispose();
            }
        }

        protected void prevFriendlink_Click(object sender, EventArgs e)
        {
            PageDs_Friend = (PagedDataSource)Session["PDSAllFriends"];

            if (!PageDs_Friend.IsFirstPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage_Friend"])) - 1;

                ViewState["CurrentPage_Friend"] = currPage.ToString();

                BindData();

            }
        }
        protected void lnkFriendNext_Click(object sender, EventArgs e)
        {
            PageDs_Friend = (PagedDataSource)Session["PDSAllFriends"];

            if (!PageDs_Friend.IsLastPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage_Friend"])) + 1;

                ViewState["CurrentPage_Friend"] = currPage.ToString();

                BindData();
            }
        }
    }
}