using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Admin.StoreFrontMgr;

namespace FritzysPetCarePros.Controls
{
    public partial class Appointment : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["MemberName"] == null) || (Session["MemberName"].ToString() == ""))
                {
                    logAppointment.Visible = true;
                    NormalAppointment.Visible = false;
                }
                else
                {
                    NormalAppointment.Visible = true;
                    logAppointment.Visible = false;
                }
            }
        }

        protected void ImgAppointment_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Session["MemberName"] != null)
                {
                    //StoreFrontUser ObjUserCheck = new StoreFrontUser();

                   // DataSet ds = new DataSet();

                    // ds = ObjUserCheck.IsFullProfile(Convert.ToInt32(Session["UserID"].ToString()));

                    //if (ds.Tables[0].Rows.Count > 0)
                    // {
                    //   if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    //   {
                    Response.Redirect("Appointment.aspx");
                    //  }
                    //  else
                    //  {
                    //  Response.Redirect("Registration.aspx");
                    // }
                }
                // }
                else
                {
                    Response.Redirect("Registration.aspx");
                }
            }
            finally
            { }
        }
    }
}