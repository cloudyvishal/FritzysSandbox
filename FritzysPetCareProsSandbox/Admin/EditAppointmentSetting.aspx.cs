
using BCL.Groomer.AppointmentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class EditAppointmentSetting : System.Web.UI.Page
    {
        string dt = string.Empty;

        PagedDataSource pgds = new PagedDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["dt"] != null)
            {
                dt = Convert.ToString(Request.QueryString["dt"]);
            }
            if (!IsPostBack)
            {
                try
                {
                    txtDate.Text = dt;

                    BindData();

                    BindDataToEdit();
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void BindDataToEdit()
        {
            try
            {
                DataSet DS = new DataSet();

                Appointment objApp = new Appointment();

                DS = objApp.GetAppointmentslotsToEdit(Convert.ToDateTime(dt));

                foreach (DataListItem item in dtlTime.Items)
                {
                    Label lblTimeId = (Label)item.FindControl("lblTimeId");

                    CheckBox chkTime = (CheckBox)item.FindControl("chkTime");

                    if (DS.Tables.Count > 0)
                    {
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            DataRow row = DS.Tables[0].Rows[i];

                            string TimeId = Convert.ToString(row["APTId"]);

                            if (lblTimeId.Text == TimeId)
                            {
                                chkTime.Checked = true;

                            }
                        }
                    }
                }
            } finally{}
        }

        protected void BindData()
        {
            try
            {
                DataSet DS = new DataSet();

                Appointment objApp = new Appointment();

                DS = objApp.GetAppointmentTime();

                if (DS.Tables.Count > 0)
                {
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        pgds.AllowPaging = true;

                        pgds.PageSize = 24;

                        pgds.DataSource = DS.Tables[0].DefaultView;

                        dtlTime.Visible = true;

                        dtlTime.DataSource = pgds;

                        dtlTime.DataBind();

                    }
                    else
                    {

                    }
                }
            } finally{}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Appointment objApp = new Appointment();

                objApp.DeleteAppointmentslots(Convert.ToDateTime(dt));

                foreach (DataListItem item in dtlTime.Items)
                {
                    Label lblTimeId = (Label)item.FindControl("lblTimeId");

                    CheckBox chkTime = (CheckBox)item.FindControl("chkTime");

                    if (chkTime.Checked)
                    {
                        objApp.AddAppointmentslots(Convert.ToDateTime(txtDate.Text), Convert.ToInt32(lblTimeId.Text));
                    }
                }
            } finally{}
            Response.Redirect("AppointmentSettings.aspx");
        }
    }
}