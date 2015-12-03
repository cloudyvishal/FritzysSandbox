using BCL.Utility.Contents;
using BCL.Utility.GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class FritzyFriends : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath("StoreData/StaticeContent/Friend.htm"));
            }
        }

        public void BindData()
        {
            Global ObjGlobal = new Global();
            DataSet ds = new DataSet();
            ds = ObjGlobal.GetAllFriendFront();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dtlFriends.Visible = true;
                dtlFriends.DataSource = ds.Tables[0];
                dtlFriends.DataBind();
            }
            else
            {
                dtlFriends.Visible = false;

            }

        }
    }
}