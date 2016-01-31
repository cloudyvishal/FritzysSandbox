using BCL.Admin.GroomerMngmt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class AddGroomerAppointment : System.Web.UI.Page
    {
        Groomer objGroomer = new Groomer();
        DataSet ds = new DataSet();
        string fomateds1;
        int UserAppId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGroomers();

                BindAppointmentType();
            }
        }

        private void BindAppointmentType()
        {
            objGroomer = new Groomer();

            ds = new DataSet();
            try
            {
                ListItem lst = new ListItem();

                ds = objGroomer.GetAppointmentType();

                lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";

                ddlApptType.DataTextField = "ApptType";

                ddlApptType.DataValueField = "ApptTypeId";

                ddlApptType.DataSource = ds.Tables[0];

                ddlApptType.DataBind();

                ddlApptType.Items.Insert(0, lst);
            }
            finally
            { }
        }

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

        public void BindGroomers()
        {
            try
            {
                Groomer objGroomer = new Groomer();
                DataSet ds = new DataSet();
                ds = objGroomer.BindGroomers();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ListItem lst = new ListItem();
                    lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
                    ddlGroomerlist.DataTextField = "Name";
                    ddlGroomerlist.DataValueField = "Gid";
                    ddlGroomerlist.DataSource = ds.Tables[0];
                    ddlGroomerlist.DataBind();
                    ddlGroomerlist.Items.Insert(0, lst);
                }
            }
            finally { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime selecteddate = Convert.ToDateTime(Session["SelectedDate"].ToString());
            if (selecteddate >= System.DateTime.Now.Date)
            {
                string pattern = @"^[0-9\- \/_?:.,\s]+$";

                bool IsMatched = Regex.IsMatch(txtDate.Text, pattern);

                if (IsMatched)
                {
                    string chdate = String.Format("{0:MM/dd}", selecteddate);
                    string[] caldate1 = chdate.Split('/');
                    string[] adate = txtDate.Text.Split('.');
                    string oldmonth = adate[0].Substring(0, 2);

                    string appdate = adate[0].Substring(2, 2);


                    string[] sttime = adate[0].Split('-');

                    string s1 = sttime[0].ToString();
                    if (Convert.ToUInt32(s1) > 600 && Convert.ToUInt32(s1) < 1000)
                    {
                        fomateds1 = sttime[0].Substring(0, 1) + ":" + sttime[0].Substring(1, 2) + ":00 AM";
                    }
                    else if (Convert.ToUInt32(s1) >= 1000 && Convert.ToUInt32(s1) < 1200)
                    {
                        fomateds1 = sttime[0].Substring(0, 2) + ":" + sttime[0].Substring(2, 2) + ":00 AM";
                    }

                    if (Convert.ToUInt32(s1) >= 1200 && Convert.ToUInt32(s1) < 1300)
                    {
                        fomateds1 = sttime[0].Substring(0, 2) + ":" + sttime[0].Substring(2, 2) + ":00 PM";
                    }
                    else if (Convert.ToUInt32(s1) > 100 && Convert.ToUInt32(s1) < 700)
                    {
                        fomateds1 = sttime[0].Substring(0, 1) + ":" + sttime[0].Substring(1, 2) + ":00 PM";
                    }

                    if (caldate1.Length > 0)
                    {
                        string newMonth = caldate1[0].Substring(0, 2);
                        string newDate = caldate1[0].Substring(2, 3);
                        string[] newDate1 = newDate.Split('-');
                        if (oldmonth == newMonth.ToString() && appdate == newDate1[1].ToString())//&& oldmonth == caldate1[0].ToString())
                        {
                            Groomer objGroomer = new Groomer();
                            DataSet dsseq = new DataSet();
                            DataSet ds4 = new DataSet();

                            dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), Convert.ToDateTime(Session["SelectedDate"].ToString()));
                            if (dsseq.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToInt32(txtSequence.Text) > Convert.ToInt32(dsseq.Tables[0].Rows[0]["sequence"]))
                                {
                                    txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
                                }
                                ds4 = objGroomer.GetGroomerNextsequenceForupdate(Convert.ToInt32(dsseq.Tables[0].Rows[0]["GId"]), Session["SelectedDate"].ToString(), Convert.ToInt32(txtSequence.Text));
                                if (ds4.Tables[0].Rows.Count > 0)
                                {
                                    for (int m = 0; m < ds4.Tables[0].Rows.Count; m++)
                                    {
                                        int h = Convert.ToInt32(ds4.Tables[0].Rows[m]["SequenceNo"]) + 1;
                                        objGroomer.UpdateGroomerSequence(Convert.ToInt32(ds4.Tables[0].Rows[0]["GId"]), Session["SelectedDate"].ToString(), h, Convert.ToInt32(ds4.Tables[0].Rows[m]["AppointmentId"]));
                                    }
                                }
                                int i = objGroomer.AddGroomerAppointment(Convert.ToInt32(ddlGroomerlist.SelectedValue), Session["SelectedDate"].ToString(), "", "", txtTotalRevnueExpected.Text, txtOthers.Text, txtDate.Text, Convert.ToInt32(txtSequence.Text), Convert.ToDecimal(txtExpectedpettime.Text), txtCustEmail.Text, fomateds1, UserAppId, Convert.ToInt32(ddlApptType.SelectedValue));
                                if (i > 0)
                                {
                                    Response.Redirect("ViewGroomerAppointment.aspx");
                                }
                                // }

                            }
                            else
                            {
                                txtSequence.Text = "1";
                                int i = objGroomer.AddGroomerAppointment(Convert.ToInt32(ddlGroomerlist.SelectedValue), Session["SelectedDate"].ToString(), "", "", txtTotalRevnueExpected.Text, txtOthers.Text, txtDate.Text, Convert.ToInt32(txtSequence.Text), Convert.ToDecimal(txtExpectedpettime.Text), txtCustEmail.Text, fomateds1, UserAppId, Convert.ToInt32(ddlApptType.SelectedValue));
                                if (i > 0)
                                {
                                    Response.Redirect("ViewGroomerAppointment.aspx");
                                }
                            }
                        }
                        else
                        {
                            ErrorMessage("Mismatch month & day with calender selected date");
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    ErrorMessage("Please provide correct date format for Date/Time");
                }
            }
            else
            {
                ErrorMessage("Mismatch month & day with calender selected date");
            }
        }

        public void GetMaxSequencenoOfGroomer()
        {
            try
            {
                Groomer objGroomer = new Groomer();

                DataSet dsseq = new DataSet();

                dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), Convert.ToDateTime(Session["SelectedDate"].ToString()));

                if (dsseq.Tables[0].Rows.Count > 0)
                {
                    if (dsseq.Tables[0].Rows[0]["sequence"].ToString() != "")
                    {
                        txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
                    }
                    else
                    {
                        txtSequence.Text = "1";
                    }

                }
                else
                {
                    txtSequence.Text = "1";
                }
            }
            finally { }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewGroomerAppointment.aspx");
        }

        protected void ddlGroomerlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetMaxSequencenoOfGroomer();

                divError.Visible = false;
            }
            finally { }
        }
    }
}