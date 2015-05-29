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
    public partial class ViewGroomerAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                List<string> appointmentIds = new List<string>();

                foreach (string key in Request.Form.Keys)
                {
                    if (key.StartsWith("chkDelete"))
                    {
                        appointmentIds.Add(key.Substring(9));
                    }
                }

                if (appointmentIds.Count > 0)
                {
                    Groomer g = new Groomer();

                    foreach (string apptId in appointmentIds)
                    {
                        g.DeleteGroomerAppointment(int.Parse(apptId));
                    }

                    BindGroomersAppointment();

                }
            }

            if (!IsPostBack)
            {
                BindGroomersAppointment();

                BindDayYear();

                DvAptGrid.Attributes["class"] = "ViewAptGrid";
            }
        }

        #region Declare
        /* Error message and success messages are use to display messages to user*/
        public void ErrorMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void SuccessMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        /* These two varibles are used for Sorting to maintain sort expression and sortdirection */
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

        #endregion

        public void CheckAll()
        {
            CheckBox chkall;
            chkall = (CheckBox)GrdUsers.HeaderRow.FindControl("chkall");
            chkall.Attributes.Add("onclick", "checkall()");
            string str;
            str = "function checkall()";
            str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
            str = str + "{";
            foreach (GridViewRow gvr in GrdUsers.Rows)
            {
                CheckBox checkall;
                checkall = (CheckBox)gvr.FindControl("chkSelect");
                str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
            }
            str = str + "}";
            str = str + "else";
            str = str + "{";
            foreach (GridViewRow grv in GrdUsers.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                str = str + "document.getElementById('" + chk1.ClientID + "').checked=false;";
            }
            str = str + "}}";
            Page.ClientScript.RegisterStartupScript(GetType(), "sss", str, true);
        }

        /* Check function is use to check select at least one row of grid which is register client script */
        protected void check()
        {
            string checkid = "";
            checkid += "function val(id){";
            checkid += "var flg=0;";

            foreach (GridViewRow grv in GrdUsers.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
                checkid += "flg=1;}";
            }
            checkid += "if(flg!=1){";
            checkid += "alert('Select Atleast One Groomer Appointment');return false;}";
            checkid += "if(flg==1 && id==1){";
            checkid += "if(!confirm('Do You Want To Delete Selected User(s) ?')){return false;}}";
            checkid += "if(flg==1 && id==2){";
            checkid += "if(!confirm('Do You Want To Delete Groomer Appointment(s) ?')){return false;}}";
            checkid = checkid + "}";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

            btnDeleteAppointment.Attributes.Add("onclick", "return val(2);");
        }

        #region BindData

        /* Bind User function is use to bind all users to grid */
        public void BindGroomersAppointment()
        {
            try
            {
                Groomer ObjGroomer = new Groomer();

                DataSet ds = new DataSet();

                DataTable dt1 = new DataTable();

                DataView dv = new DataView();

                DateTime TodaysDate = System.DateTime.Now;

                DateTime olddate = Convert.ToDateTime("01/01/0001");

                TodaysDate = TodaysDate.AddMonths(-20);

                if (calDate.SelectedDate == olddate)
                {
                    //
                    if (Session["SelectedDate"] != null)
                    {
                        calDate.SelectedDate = Convert.ToDateTime(Session["SelectedDate"]);
                    }
                    else
                    {
                        calDate.SelectedDate = TodaysDate.Date;
                    }
                }

                ds = ObjGroomer.GetGroomersAppointment(calDate.SelectedDate);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrdUsers.Visible = true;

                    dt1 = ds.Tables[0];

                    dv = dt1.DefaultView;

                    dv.Sort = "Name ASC,SequenceNo ASC";

                    if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                    {
                        if ((SortExpression == "Name") && (SortDirection == "ASC"))
                        {
                            dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo ASC";
                        }
                        if ((SortExpression == "Name") && (SortDirection == "DESC"))
                        {
                            dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo Asc";
                        }
                        if ((SortExpression == "SequenceNo") && (SortDirection == "ASC"))
                        {
                            dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                        }
                        if ((SortExpression == "SequenceNo") && (SortDirection == "DESC"))
                        {
                            dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                        }
                    }

                    lblSelectDate.Text = calDate.SelectedDate.ToLongDateString();

                    Session["SelectedDate"] = calDate.SelectedDate;

                    GrdUsers.DataSource = dv;

                    GrdUsers.DataBind();

                    divError.Visible = false;

                    CheckAll();
                    check();

                }
                else
                {
                    GrdUsers.Visible = false;

                    ErrorMessage("Sorry, No appointment scheduled for today");

                    Session["SelectedDate"] = calDate.SelectedDate;

                    lblSelectDate.Text = calDate.SelectedDate.ToLongDateString();
                }
            }
            finally { }
        }

        #endregion

        protected void GrdUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (!(null == Session["EditMode"]))
                {
                    if (Session["EditMode"].ToString().Equals("0"))
                    {
                        int AppointmentID;

                        GridViewRow row = GrdUsers.Rows[e.RowIndex];

                        if (row != null)
                        {
                            string AptStart_Time = "";

                            string AptEnd_Time = "";

                            AppointmentID = Convert.ToInt32(GrdUsers.DataKeys[e.RowIndex].Value);

                            Label lblAppointmentID = (Label)GrdUsers.Rows[e.RowIndex].FindControl("lblAppointmentID");

                            TextBox txtSequenceNo = (TextBox)GrdUsers.Rows[e.RowIndex].FindControl("txtSequenceNo");

                            TextBox txtAppointmentDate = (TextBox)GrdUsers.Rows[e.RowIndex].FindControl("txtAppointmentDate");

                            TextBox txtOthers = (TextBox)GrdUsers.Rows[e.RowIndex].FindControl("txtOthers");

                            TextBox txtExpectedTotalRevenue = (TextBox)GrdUsers.Rows[e.RowIndex].FindControl("txtExpectedTotalRevenue");

                            DropDownList ddlName = (DropDownList)GrdUsers.Rows[e.RowIndex].FindControl("ddlName");

                            Label lblGId = (Label)GrdUsers.Rows[e.RowIndex].FindControl("lblGId");

                            Label lblAptPTime = (Label)GrdUsers.Rows[e.RowIndex].FindControl("lblStatusP");

                            Label lblAptStime = (Label)GrdUsers.Rows[e.RowIndex].FindControl("lblAptSTime");

                            Label lblAptEtime = (Label)GrdUsers.Rows[e.RowIndex].FindControl("lblAptETime");

                            DropDownList ddlStatusPresented = (DropDownList)GrdUsers.Rows[e.RowIndex].FindControl("ddlStatusPresented");

                            TextBox txtExpectedPetTime = (TextBox)GrdUsers.Rows[e.RowIndex].FindControl("txtExpectedPetTime");

                            int Astatus = 0;

                            bool Pstatus = false;

                            if (ddlStatusPresented.SelectedValue == "YES")
                            {
                                Pstatus = true;

                                AptStart_Time = lblAptStime.Text;

                                AptEnd_Time = lblAptEtime.Text;
                            }
                            else
                            {
                                Pstatus = false;
                            }

                            string AptTime = "";

                            if (lblAptPTime.Text.Equals("NO"))
                            {
                                if (ddlStatusPresented.SelectedValue == "YES")
                                {
                                    AptTime = DateTime.Now.ToString("hh:mm:ss tt");
                                }
                            }
                            else
                            {
                                AptTime = lblAptPTime.Text;
                            }

                            Groomer objGroomer = new Groomer();

                            DataSet ds2 = new DataSet();

                            DataSet ds4 = new DataSet();

                            ds2 = objGroomer.GetGroomersSequence(Session["SelectedDate"].ToString(), Convert.ToInt32(lblAppointmentID.Text), Convert.ToInt32(ddlName.SelectedValue));

                            bool SquenceNo = false;

                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                                {
                                    if (txtSequenceNo.Text == ds2.Tables[0].Rows[j]["SequenceNo"].ToString())
                                    {
                                        DataSet ds3 = new DataSet();

                                        objGroomer.DeleteGroomerAppointment(Convert.ToInt32(lblAppointmentID.Text));

                                        int Addappointment = objGroomer.AssignGroomerAppointment(Convert.ToInt32(ddlName.SelectedValue), Session["SelectedDate"].ToString(), AptStart_Time, AptEnd_Time, txtExpectedTotalRevenue.Text.Trim(), txtOthers.Text.Trim(), txtAppointmentDate.Text.Trim(), Convert.ToInt32(txtSequenceNo.Text.Trim()), Convert.ToDecimal(txtExpectedPetTime.Text));

                                        ds3 = objGroomer.GetGroomersSequenceforUpdate(Convert.ToInt32(ddlName.SelectedValue), Session["SelectedDate"].ToString());

                                        if (ds3.Tables[0].Rows.Count > 0)
                                        {
                                            for (int k = 0; k < ds3.Tables[0].Rows.Count; k++)
                                            {
                                                SquenceNo = true;

                                                int h = Convert.ToInt32(ds3.Tables[0].Rows[k]["SequenceNo"]) + 1;

                                                objGroomer.UpdateGroomerSequence(Convert.ToInt32(ddlName.SelectedValue), Session["SelectedDate"].ToString(), h, Convert.ToInt32(ds3.Tables[0].Rows[k]["AppointmentId"]));

                                                GrdUsers.EditIndex = -1;

                                                BindGroomersAppointment();

                                                SuccessMessage("Groomer appointment updated successfully");

                                                Session["EditMode"] = "1";
                                            }
                                        }

                                        ds4 = objGroomer.GetPreviousGroomersSequenceforUpdate1(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString());

                                        if (ds4.Tables[0].Rows.Count > 0)
                                        {
                                            int seq = 1;
                                            for (int m = 0; m < ds4.Tables[0].Rows.Count; m++)
                                            {
                                                if (m != 0)
                                                {
                                                    if (m == Convert.ToInt32(ds4.Tables[0].Rows[0]["SequenceNo"]))
                                                    {
                                                        seq = Convert.ToInt32(ds4.Tables[0].Rows[0]["SequenceNo"]) + 1;
                                                    }
                                                    objGroomer.UpdateGroomerSequence(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString(), seq, Convert.ToInt32(ds4.Tables[0].Rows[m]["AppointmentId"]));

                                                    seq++;

                                                    GrdUsers.EditIndex = -1;

                                                    BindGroomersAppointment();

                                                    SuccessMessage("Groomer appointment updated successfully");

                                                    Session["EditMode"] = "1";
                                                }
                                            }
                                        }
                                    }
                                }
                                if (SquenceNo == false)
                                {
                                    int i = objGroomer.UpdateGroomerAppointment(Convert.ToInt32(lblAppointmentID.Text), Convert.ToInt32(ddlName.SelectedValue), Session["SelectedDate"].ToString(), AptStart_Time, AptEnd_Time, txtExpectedTotalRevenue.Text.Trim(), txtOthers.Text.Trim(), Convert.ToInt32(txtSequenceNo.Text.Trim()), txtAppointmentDate.Text.Trim(), Astatus, Convert.ToDecimal(txtExpectedPetTime.Text), Pstatus, AptTime);

                                    GrdUsers.EditIndex = -1;

                                    BindGroomersAppointment();

                                    ds4 = objGroomer.GetPreviousGroomersSequenceforUpdate(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString());

                                    if (ds4.Tables[0].Rows.Count > 0)
                                    {
                                        for (int m = 0; m < ds4.Tables[0].Rows.Count; m++)
                                        {
                                            objGroomer.UpdateGroomerSequence(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString(), m + 1, Convert.ToInt32(ds4.Tables[0].Rows[m]["AppointmentId"]));

                                            GrdUsers.EditIndex = -1;

                                            BindGroomersAppointment();

                                            SuccessMessage("Groomer appointment updated successfully");

                                            Session["EditMode"] = "1";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int i = objGroomer.UpdateGroomerAppointment(Convert.ToInt32(lblAppointmentID.Text), Convert.ToInt32(ddlName.SelectedValue), Session["SelectedDate"].ToString(), AptStart_Time, AptEnd_Time, txtExpectedTotalRevenue.Text.Trim(), txtOthers.Text.Trim(), Convert.ToInt32(txtSequenceNo.Text.Trim()), txtAppointmentDate.Text.Trim(), Astatus, Convert.ToDecimal(txtExpectedPetTime.Text), Pstatus, AptTime);

                                GrdUsers.EditIndex = -1;

                                BindGroomersAppointment();

                                SuccessMessage("Groomer appointment updated successfully");

                                ds4 = objGroomer.GetPreviousGroomersSequenceforUpdate(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString());

                                if (ds4.Tables[0].Rows.Count > 0)
                                {
                                    for (int m = 0; m < ds4.Tables[0].Rows.Count; m++)
                                    {
                                        objGroomer.UpdateGroomerSequence(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString(), m + 1, Convert.ToInt32(ds4.Tables[0].Rows[m]["AppointmentId"]));

                                        GrdUsers.EditIndex = -1;

                                        BindGroomersAppointment();

                                        SuccessMessage("Groomer appointment updated successfully");

                                        Session["EditMode"] = "1";
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        GrdUsers.EditIndex = -1;

                        BindGroomersAppointment();
                    }
                }
            }
            finally { }
        }

        protected void GrdUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdUsers.EditIndex = e.NewEditIndex;

            BindGroomersAppointment();

            GrdUsers.Rows[e.NewEditIndex].FindControl("txtOthers").Focus();

            Session["EditMode"] = "0";

            DvAptGrid.Attributes["class"] = "EditAptGrid";
        }

        protected void GrdUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdUsers.EditIndex = -1;

            BindGroomersAppointment();

            Session["EditMode"] = "1";

            DvAptGrid.Attributes["class"] = "ViewAptGrid";

        }

        protected void GrdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdUsers.PageIndex = e.NewPageIndex;

            BindGroomersAppointment();
        }

        #region MessageBox

        private void MessageBox(string strMsg)
        {
            Label lbl = new Label();

            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" + strMsg + "'" + ")</script>";

            Page.Controls.Add(lbl);
        }

        #endregion MessageBox

        protected void GrdUsers_Sorting(object sender, GridViewSortEventArgs e)
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
            GrdUsers.PageIndex = 0;

            BindGroomersAppointment();
        }

        protected void GrdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlName = (DropDownList)e.Row.FindControl("ddlName");

                    DropDownList ddlStatusPresented = (DropDownList)e.Row.FindControl("ddlStatusPresented");

                    Label lblGId = (Label)e.Row.FindControl("lblGId");

                    Label lblAStatusId = (Label)e.Row.FindControl("lblAStatusId");

                    Label lblSPresented = (Label)e.Row.FindControl("lblSPresented");

                    Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                    Groomer objGroomer = new Groomer();

                    DataSet ds = new DataSet();

                    ds = objGroomer.BindGroomers();

                    if (GrdUsers.EditIndex == e.Row.RowIndex)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddlName.DataTextField = "Name";

                            ddlName.DataValueField = "Gid";

                            ddlName.DataSource = ds.Tables[0];

                            ddlName.DataBind();

                            ddlName.SelectedValue = lblGId.Text.ToString();
                        }
                        ddlStatusPresented.Items.Remove("NO");

                        ddlStatusPresented.Items.Remove("YES");

                        ddlStatusPresented.Items.Insert(0, "NO");

                        ddlStatusPresented.Items.Insert(1, "YES");

                        ddlStatusPresented.Text = lblSPresented.Text.ToString();
                    }
                    if (lblStatus.Text == "YES")
                    {
                        e.Row.Cells[11].Enabled = false;
                    }
                }
            }
            finally { }
        }

        #region GridEvent
        //Event use for pagination
        protected void GrdUsers_DataBound(object sender, EventArgs e)
        {
            GridViewRow gvr = GrdUsers.BottomPagerRow;
            Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
            lb1.Text = Convert.ToString(GrdUsers.PageIndex + 1);
            int[] page = new int[7];
            page[0] = GrdUsers.PageIndex - 2;
            page[1] = GrdUsers.PageIndex - 1;
            page[2] = GrdUsers.PageIndex;
            page[3] = GrdUsers.PageIndex + 1;
            page[4] = GrdUsers.PageIndex + 2;
            page[5] = GrdUsers.PageIndex + 3;
            page[6] = GrdUsers.PageIndex + 4;
            for (int i = 0; i < 7; i++)
            {
                if (i != 3)
                {
                    if (page[i] < 1 || page[i] > GrdUsers.PageCount)
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
            if (GrdUsers.PageIndex == 0)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
                lb.Visible = false;

            }
            if (GrdUsers.PageIndex == GrdUsers.PageCount - 1)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
                lb.Visible = false;

            }
            if (GrdUsers.PageIndex > GrdUsers.PageCount - 5)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
                lbmore.Visible = false;
            }
            if (GrdUsers.PageIndex < 4)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
                lbmore.Visible = false;
            }
        }
        protected void GrdUsers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvr = e.Row;
                gvr.Cells[12].Text = "Delete&nbsp;&nbsp;";
            }


            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewRow gvr = e.Row;
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p0");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p1");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p2");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p4");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p5");
                lb.Command += new CommandEventHandler(lb_Command);
                lb = (LinkButton)gvr.Cells[0].FindControl("p6");
                lb.Command += new CommandEventHandler(lb_Command);
            }
        }

        void lb_Command(object sender, CommandEventArgs e)
        {
            GrdUsers.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
            BindGroomersAppointment();
        }

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddGroomerAppointment.aspx");
        }

        protected void calDate_SelectionChanged(object sender, EventArgs e)
        {
            BindGroomersAppointment();

            DateTime dtSelectedDate = new DateTime();

            dtSelectedDate = Convert.ToDateTime(Session["SelectedDate"]);

            if (dtSelectedDate.Date >= System.DateTime.Now.Date)
                btnAdd.Visible = true;
            else
                btnAdd.Visible = false;
        }

        protected void GrdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int AppointmentIDs;

                Groomer objGroomer = new Groomer();

                DataSet ds5 = new DataSet();

                GridViewRow row = GrdUsers.Rows[e.RowIndex];

                if (row != null)
                {
                    AppointmentIDs = Convert.ToInt32(GrdUsers.DataKeys[e.RowIndex].Value);

                    Label lblGId = (Label)GrdUsers.Rows[e.RowIndex].FindControl("lblGId");

                    objGroomer.DeleteGroomerAppointment(AppointmentIDs);

                    ds5 = objGroomer.GetPreviousGroomersSequenceforUpdate(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString());

                    if (ds5.Tables[0].Rows.Count > 0)
                    {
                        for (int n = 0; n < ds5.Tables[0].Rows.Count; n++)
                        {
                            objGroomer.UpdateGroomerSequence(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString(), n + 1, Convert.ToInt32(ds5.Tables[0].Rows[n]["AppointmentId"]));

                            BindGroomersAppointment();

                            SuccessMessage("Groomer(s) appointment deleted successfully.");
                        }
                    }
                    else
                    {
                        BindGroomersAppointment();

                        SuccessMessage("Groomer(s) appointment deleted successfully.");
                    }
                }
            }
            finally { }
        }

        public void BindDayYear()
        {
            string[] day = new string[31];
            for (int i = 0; i < 31; i++)
            {
                day[i] = (i + 1).ToString();
            }
            string[] Years = new string[5];

            for (int i = 0; i < 5; i++)
            {
                Years[i] = (DateTime.Now.Year - i).ToString();
            }
            ddlYear.DataSource = Years;
            ddlYear.DataBind();

        }

        protected void btnDeleteAppointment_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string month = ddlMonth.SelectedValue + "/" + "1" + "/" + ddlYear.SelectedValue;

                DateTime dtSelectedDate = new DateTime();

                dtSelectedDate = Convert.ToDateTime(month);

                DateTime todaysdate = new DateTime();

                todaysdate = System.DateTime.Today.AddMonths(-2);

                if (dtSelectedDate.Date < todaysdate)
                {
                    DateTime enddate;

                    enddate = dtSelectedDate.Date.AddDays(30);

                    Groomer objGroomer = new Groomer();

                    objGroomer.DeleteOldGroomerAppointment(dtSelectedDate.Date, enddate);

                    BindGroomersAppointment();

                    SuccessMessage("Groomer(s) appointment deleted successfully.");
                }
                else
                {
                    ErrorMessage("Select month should be two months less than current date.");
                }
            }
            finally { }
        }

        protected void calDate_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    e.Day.IsSelectable = false;

                    e.Cell.ForeColor = System.Drawing.Color.Gray;

                    DateTime dt = new DateTime();

                    string t = "2013-12-22 00:00:00.000";

                    dt = Convert.ToDateTime(t);

                    if (e.Day.Date == dt)
                    {
                        e.Day.IsSelectable = true;
                        e.Cell.ForeColor = System.Drawing.Color.Gray;

                    }
                }

                if (Session["SelectedDate"] != null)
                {
                    DateTime TodaysDate = Convert.ToDateTime(Session["SelectedDate"]);
                }
                else
                {
                    DateTime TodaysDate = System.DateTime.Now;
                }
            }
            finally { }
        }
    }
}