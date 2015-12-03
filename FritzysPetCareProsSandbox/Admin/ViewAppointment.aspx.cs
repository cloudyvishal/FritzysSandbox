
using BCL.User.UserAppointmentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ViewAppointment : System.Web.UI.Page
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
                UserAppointment App = new UserAppointment();

                DataSet ds = new DataSet();

                ds = App.GetAppointment(Convert.ToInt32(Request.QueryString["ID"].ToString()));

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();

                        lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                        lblPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();


                        lblDate.Text = ds.Tables[0].Rows[0]["Date"].ToString() + " " + ds.Tables[0].Rows[0]["T"].ToString();

                        lblConfirmBy.Text = ds.Tables[0].Rows[0]["ConfirmBy"].ToString();

                        lblFlex.Text = ds.Tables[0].Rows[0]["Flex"].ToString();

                        lblNote.Text = ds.Tables[0].Rows[0]["Note"].ToString();

                        lblEmail.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    }
                    else
                    {
                        lblError.Text = "No record found";
                    }
                }
            } finally{}
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["p"] == "0")
                Response.Redirect("AdminHome.aspx");
            else
                Response.Redirect("Appointment.aspx");
        }
    }
}