using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


using BCL.Utility.CommonMethods;
using BCL.Utility.GlobalFunctions;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ManageEmail : System.Web.UI.Page
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

                ds = ObjUser.GetAllMail();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdEmail.DataSource = ds.Tables[0];

                        grdEmail.DataBind();

                        CommonFunctions.Setserial(grdEmail, "srno");
                    }
                    else
                    {

                    }
                }
            } finally{}

        }
    }
}