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
    public partial class GroomerAppointmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetGroomerAppointmentDetails();
        }

        public void GetGroomerAppointmentDetails()
        {
            try
            {
                Groomer objgroomer = new Groomer();

                DataSet ds = new DataSet();

                ds = objgroomer.GetGroomerAppointmentDetails(Convert.ToInt32(Request.QueryString["DailyLogID"].ToString()));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrdGroomer.DataSource = ds;

                    GrdGroomer.DataBind();
                }
            } finally{}
        }

        protected void lnkNorec_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExportToExcel.aspx");
        }
    }
}