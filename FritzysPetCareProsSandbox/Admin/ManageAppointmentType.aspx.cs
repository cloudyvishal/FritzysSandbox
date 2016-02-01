using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Admin.GroomerMngmt;
using BCL.Admin.StoreFrontMgr;
using BCL.Utility.CommonMethods;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ManageAppointmentType : System.Web.UI.Page
    {
        int ApptTypeId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAppointmentType();
            }
        }

        private void BindAppointmentType()
        {
            Groomer objGroomer = new Groomer();

            DataSet ds = new DataSet();

            try
            {
                ListItem lst = new ListItem();

                ds = objGroomer.GetAppointmentType();

                gdvApptType.DataSource = ds.Tables[0];

                gdvApptType.DataBind();

                CommonFunctions.Setserial(gdvApptType, "srno");
            }
            finally
            {
                objGroomer = null;
            }
        }

        #region "Grid Event"

        protected void gdvApptType_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void gdvApptType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gdvApptType.Rows[e.RowIndex];
                if (row != null)
                {
                    ApptTypeId = Convert.ToInt32(gdvApptType.DataKeys[e.RowIndex].Value);
                    Label lblApptType = (Label)gdvApptType.Rows[e.RowIndex].FindControl("lblApptType");

                    TextBox txtAppointmentType = (TextBox)gdvApptType.Rows[e.RowIndex].FindControl("txtAppointmentType");

                    if (txtAppointmentType.Text == "")
                    {
                        MessageBox("Please enter Breed Name.");
                    }

                    else
                    {
                        StoreFront ObjStoreFront = new StoreFront();
                        int Count = ObjStoreFront.UpdateAppointment(ApptTypeId, txtAppointmentType.Text.Trim());

                        if (Count == 1)
                        {
                            SuccesfullMessage("Breed updated successfully.");
                            gdvApptType.EditIndex = -1;
                            BindAppointmentType();

                        }
                        else
                        {

                            ErrMessage("Duplicate breed name.");
                            gdvApptType.EditIndex = -1;
                            BindAppointmentType();
                        }
                    }
                }
            }
            finally { }
        }

        protected void gdvApptType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gdvApptType.EditIndex = e.NewEditIndex;
                BindAppointmentType();
            }
            finally { }
        }

        protected void gdvApptType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gdvApptType.EditIndex = -1;
                BindAppointmentType();
            }
            finally { }
        }

        protected void gdvApptType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gdvApptType.SelectedIndex = -1;
                gdvApptType.PageIndex = e.NewPageIndex;
                BindAppointmentType();
            }
            finally { }
        }

        /* Grid Sorting event*/
        protected void gdvApptType_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                if (SortExpression != e.SortExpression)
                {
                    SortExpression = e.SortExpression;
                    SortDirection = "ASC";
                }
                else
                {
                    if (SortDirection == "ASC")
                    {
                        SortDirection = "DESC";
                    }
                    else
                    {
                        SortDirection = "ASC";
                    }
                }
                gdvApptType.PageIndex = 0;
                BindAppointmentType();
            }
            finally { }
        }

        #endregion

        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        private string SortExpression
        {
            get
            {
                if (ViewState["SortExpression"] != null)
                    return (string)ViewState["SortExpression"];
                else
                    return string.Empty;
            }
            set
            {
                if (ViewState["SortExpression"] == null)
                    ViewState.Add("SortExpression", value);
                else
                    ViewState["SortExpression"] = value;
            }
        }

        private string SortDirection
        {
            get
            {
                if (ViewState["SortDirection"] != null)
                    return (string)ViewState["SortDirection"];
                else
                    return "ASC";
            }
            set
            {
                if (ViewState["SortDirection"] == null)
                    ViewState.Add("SortDirection", value);
                else
                    ViewState["SortDirection"] = value;
            }
        }

        private void MessageBox(string strMsg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" + strMsg + "'" + ")</script>";
            Page.Controls.Add(lbl);
        }

        protected void ImgSubmitService_Click(object sender, EventArgs e)
        {
            try
            {
                StoreFront ObjStoreFront = new StoreFront();
                int count = ObjStoreFront.AddAppointmentType(txtAppointmentType.Text.Trim());
                if (count == 1)
                {
                    SuccesfullMessage("Appointment type added successfully.");
                    txtAppointmentType.Text = "";
                    BindAppointmentType();
                }
                else
                {
                    ErrMessage("Duplicate Appointment type name.");
                    txtAppointmentType.Text = "";
                }
            }
            finally { }
        }

        protected void lnkNorec_Click(object sender, EventArgs e)
        {

        }

        protected void gdvApptType_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvApptType_DataBound(object sender, EventArgs e)
        {
            GridViewRow gvr = gdvApptType.BottomPagerRow;
            Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
            lb1.Text = Convert.ToString(gdvApptType.PageIndex + 1);
            int[] page = new int[7];
            page[0] = gdvApptType.PageIndex - 2;
            page[1] = gdvApptType.PageIndex - 1;
            page[2] = gdvApptType.PageIndex;
            page[3] = gdvApptType.PageIndex + 1;
            page[4] = gdvApptType.PageIndex + 2;
            page[5] = gdvApptType.PageIndex + 3;
            page[6] = gdvApptType.PageIndex + 4;
            for (int i = 0; i < 7; i++)
            {
                if (i != 3)
                {
                    if (page[i] < 1 || page[i] > gdvApptType.PageCount)
                    {
                        LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                        lb.Visible = false;
                    }
                    else
                    {
                        LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                        lb.Text = Convert.ToString(page[i]);

                        lb.CommandName = "PageNo";
                        lb.CommandArgument = lb.Text;

                    }
                }
            }
            if (gdvApptType.PageIndex == 0)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
                lb.Visible = false;

            }
            if (gdvApptType.PageIndex == gdvApptType.PageCount - 1)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
                lb.Visible = false;

            }
            if (gdvApptType.PageIndex > gdvApptType.PageCount - 5)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
                lbmore.Visible = false;
            }
            if (gdvApptType.PageIndex < 4)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
                lbmore.Visible = false;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            divAddBreed.Visible = true;
        }
    }
}