using BCL.Admin.GroomerMngmt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class UploadFailedAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFailedAppointments();
            }
        }

        private void BindFailedAppointments()
        {
            Groomer objgroomer = new Groomer();

            DataSet ds = null;

            try
            {
                ds = objgroomer.GetFailedAppointments();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptFailedAppt.DataSource = ds.Tables[0];

                        rptFailedAppt.DataBind();
                    }
                }
            }
            finally
            {
                objgroomer = null;
            }
        }

        protected void rptFailedAppt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }
    }
}