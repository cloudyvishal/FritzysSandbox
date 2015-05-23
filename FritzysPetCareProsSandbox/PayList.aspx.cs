using BCL.Admin.StoreFrontMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class PayList : BasePage
    {
        StoreFront ObjStoreFront = new StoreFront();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!(null == Request.QueryString["msg"]))
                {
                    string s = Request.QueryString["msg"].ToString();
                    lblsmsg.Visible = true;
                }
                bindSyncLink();
            }
        }

        public void bindSyncLink()
        {
            DataSet ds = new DataSet();
            if (!(null == Session["UserName"]))
            {
                ds = ObjStoreFront.GetAppInfoforPayment(Session["UserName"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnSycAppLink.Enabled = true;
                }
                else
                {
                    btnSycAppLink.Enabled = false;
                }
            }
        }

        protected void btnSycAppLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentInfo.aspx");
        }
    }
}