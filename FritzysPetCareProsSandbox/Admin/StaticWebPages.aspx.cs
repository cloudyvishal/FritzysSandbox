
using BCL.Utility.CommonMethods;
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
    public partial class StaticWebPages : System.Web.UI.Page
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
                Global ObjUser = new Global();

                DataSet ds = new DataSet();

                ds = ObjUser.GetAllPages();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrdFileManager.DataSource = ds.Tables[0];

                        GrdFileManager.DataBind();

                        CommonFunctions.Setserial(GrdFileManager, "srno");
                    }
                    else
                    {

                    }
                }
            } finally{}
        }
    }
}