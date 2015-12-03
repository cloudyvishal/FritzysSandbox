using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Net.Mail;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Utility.Contents;
using BCL.Utility.SendMailMgr;
using BCL.Admin.StoreFrontMgr;
using BCL.Security.Cryptography;
using BCL.Security.CryptoGraphy;
using BCL.Utility.GlobalFunctions;
using BCL.Admin.GroomerMngmt;

namespace FritzysPetCareProsSandbox
{
    public partial class MyAccount : BasePage
    {
        int update = 0;

        int Add = 0;

        int Delete = 0;

        string PetTypeID = "0";

        string custusername;

        static List<int> lstappid = new List<int>();

        static List<int> lstprepayappid = new List<int>();

        int userID;

        DataTable Dt = new DataTable();

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

        public void GetBreed()
        {
            StoreFrontUser ObjReg = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjReg.GetBreedFront("0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ListItem lst = new ListItem();
                lst.Value = "0"; lst.Text = "Select One";

                ddlBreed1.DataTextField = "BreedName";
                ddlBreed1.DataValueField = "BreedID";
                ddlBreed1.DataSource = ds.Tables[0];
                ddlBreed1.DataBind();
                ddlBreed1.Items.Insert(0, lst);

                ddlBreed2.DataTextField = "BreedName";
                ddlBreed2.DataValueField = "BreedID";
                ddlBreed2.DataSource = ds.Tables[0];
                ddlBreed2.DataBind();

                ddlBreed3.DataTextField = "BreedName";
                ddlBreed3.DataValueField = "BreedID";
                ddlBreed3.DataSource = ds.Tables[0];
                ddlBreed3.DataBind();

                ddlBreed4.DataTextField = "BreedName";
                ddlBreed4.DataValueField = "BreedID";
                ddlBreed4.DataSource = ds.Tables[0];
                ddlBreed4.DataBind();

                ddlBreed5.DataTextField = "BreedName";
                ddlBreed5.DataValueField = "BreedID";
                ddlBreed5.DataSource = ds.Tables[0];
                ddlBreed5.DataBind();

                ddlBreed6.DataTextField = "BreedName";
                ddlBreed6.DataValueField = "BreedID";
                ddlBreed6.DataSource = ds.Tables[0];
                ddlBreed6.DataBind();
            }
        }

        public void GetReferal()
        {
            StoreFrontUser ObjRef = new StoreFrontUser();

            DataSet ds1 = new DataSet();

            ds1 = ObjRef.GetReferalSourceFront();

            if (ds1.Tables[0].Rows.Count > 0)
            {
                ListItem lst = new ListItem();

                lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";

                ddlReferralSource.DataTextField = "ReferalName";

                ddlReferralSource.DataValueField = "ReferalID";

                ddlReferralSource.DataSource = ds1.Tables[0];

                ddlReferralSource.DataBind();

                ddlReferralSource.Items.Insert(0, lst);
            }
        }

        public void BindUser()
        {
            StoreFrontUser ObjUser = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjUser.GetUser(Convert.ToInt32(Session["UserID"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["UserInformation"] = (DataTable)ds.Tables[0];
                ViewState["UserMail"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtStreet.Text = ds.Tables[0].Rows[0]["Street"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                if (ds.Tables[0].Rows[0]["State"].ToString() != "0")
                    ddlState.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
                txtZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtAltMobile.Text = ds.Tables[0].Rows[0]["AltMobile"].ToString();
                txtAltContact.Text = ds.Tables[0].Rows[0]["AltContact"].ToString();
                txtAltStreet.Text = ds.Tables[0].Rows[0]["AltStreet"].ToString();
                txtAltCity.Text = ds.Tables[0].Rows[0]["AltCity"].ToString();
                if (ds.Tables[0].Rows[0]["AltState"].ToString() != "0")
                    ddlState1.SelectedValue = ds.Tables[0].Rows[0]["AltState"].ToString();
                txtAltZip.Text = ds.Tables[0].Rows[0]["AltZip"].ToString();
                txtAltPhone.Text = ds.Tables[0].Rows[0]["AltPhone"].ToString();
                txtGroomer.Text = ds.Tables[0].Rows[0]["PreferredGroomer"].ToString();
                txtEmailReg.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
               
                custusername = ds.Tables[0].Rows[0]["UserName"].ToString();
                Session["custname"] = custusername;
                ddlReferralSource.SelectedValue = ds.Tables[0].Rows[0]["ReferralID"].ToString();
                txtEmailReg.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            }
        }

        public void BindPet()
        {
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            StoreFrontUser ObjPet = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjPet.GetAllPetFront(Convert.ToInt32(Session["UserID"]));

            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["Pet"] = (DataTable)ds.Tables[0];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            ViewState["RowID"] = 0;
                            ViewState["IsPet"] = "1";
                            p1.Visible = true;
                            txtPetName1.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtPetDOB1.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight1.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength1.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID1.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType1.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed1("0");
                            else
                                GetBreed1("1");
                            ddlBreed1.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgDelete1.Visible = true;
                            break;
                        case 1:
                            ViewState["RowID"] = 1;
                            p2.Visible = true;
                            txtPetName2.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB2.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight2.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength2.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID2.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType2.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed2("0");
                            else
                                GetBreed2("1");
                            ddlBreed2.SelectedValue = ds.Tables[0].Rows[i]["BreedID"].ToString();
                            imgDelete2.Visible = true;
                            break;
                        case 2:
                            ViewState["RowID"] = 2;
                            p3.Visible = true;
                            txtPetName3.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB3.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight3.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength3.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID3.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType3.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed3("0");
                            else
                                GetBreed3("1");
                            ddlBreed3.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgDelete3.Visible = true;
                            break;
                        case 3:
                            ViewState["RowID"] = 3;
                            p4.Visible = true;
                            txtPetName4.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB4.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight4.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength4.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID4.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType4.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed4("0");
                            else
                                GetBreed4("1");
                            ddlBreed4.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgDelete4.Visible = true;
                            break;
                        case 4:
                            ViewState["RowID"] = 4;
                            p5.Visible = true;
                            txtPetName5.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB5.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight5.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength5.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID5.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType5.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed5("0");
                            else
                                GetBreed5("1");
                            ddlBreed5.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgDelete5.Visible = true;
                            break;
                        case 5:
                            ViewState["RowID"] = 5;
                            p6.Visible = true;
                            txtPetName6.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB6.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight6.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength6.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID6.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType6.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed6("0");
                            else
                                GetBreed6("1");
                            ddlBreed6.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgAddmore.Visible = false;
                            imgDelete6.Visible = true;
                            break;
                        default:
                            p1.Visible = true;
                            ViewState["RowID"] = "0";
                            ViewState["IsPet"] = "0";
                            break;
                    }
                }
            }
            else
            {
                p1.Visible = true;
                ViewState["RowID"] = "0";
                ViewState["IsPet"] = "0";
            }
        }

        public void GetBreed1(string PetType)
        {
            StoreFrontUser ObjReg = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjReg.GetBreedFront(PetType);
            ListItem lst = new ListItem();
            lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBreed1.DataTextField = "BreedName";
                ddlBreed1.DataValueField = "BreedID";
                ddlBreed1.DataSource = ds.Tables[0];
                ddlBreed1.DataBind();
                ddlBreed1.Items.Insert(0, lst);
            }
            else
            {
                ddlBreed1.Items.Insert(0, lst);
            }
        }

        public void GetBreed2(string PetType)
        {
            StoreFrontUser ObjReg = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjReg.GetBreedFront(PetType);
            ListItem lst = new ListItem();
            lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBreed2.DataTextField = "BreedName";
                ddlBreed2.DataValueField = "BreedID";
                ddlBreed2.DataSource = ds.Tables[0];
                ddlBreed2.DataBind();
                ddlBreed2.Items.Insert(0, lst);
            }
            else
            {
                ddlBreed2.Items.Insert(0, lst);
            }
        }

        public void GetBreed3(string PetType)
        {
            StoreFrontUser ObjReg = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjReg.GetBreedFront(PetType);
            ListItem lst = new ListItem();
            lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBreed3.DataTextField = "BreedName";
                ddlBreed3.DataValueField = "BreedID";
                ddlBreed3.DataSource = ds.Tables[0];
                ddlBreed3.DataBind();
                ddlBreed3.Items.Insert(0, lst);
            }
            else
            {
                ddlBreed3.Items.Insert(0, lst);
            }
        }

        public void GetBreed4(string PetType)
        {
            StoreFrontUser ObjReg = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjReg.GetBreedFront(PetType);
            ListItem lst = new ListItem();
            lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBreed4.DataTextField = "BreedName";
                ddlBreed4.DataValueField = "BreedID";
                ddlBreed4.DataSource = ds.Tables[0];
                ddlBreed4.DataBind();
                ddlBreed4.Items.Insert(0, lst);
            }
            else
            {
                ddlBreed4.Items.Insert(0, lst);
            }
        }

        public void GetBreed5(string PetType)
        {
            StoreFrontUser ObjReg = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjReg.GetBreedFront(PetType);
            ListItem lst = new ListItem();
            lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBreed5.DataTextField = "BreedName";
                ddlBreed5.DataValueField = "BreedID";
                ddlBreed5.DataSource = ds.Tables[0];
                ddlBreed5.DataBind();
                ddlBreed5.Items.Insert(0, lst);
            }
            else
            {
                ddlBreed5.Items.Insert(0, lst);
            }
        }

        public void GetBreed6(string PetType)
        {
            StoreFrontUser ObjReg = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjReg.GetBreedFront(PetType);
            ListItem lst = new ListItem();
            lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBreed6.DataTextField = "BreedName";
                ddlBreed6.DataValueField = "BreedID";
                ddlBreed6.DataSource = ds.Tables[0];
                ddlBreed6.DataBind();
                ddlBreed6.Items.Insert(0, lst);
            }
            else
            {
                ddlBreed6.Items.Insert(0, lst);
            }
        }

        public void BindState()
        {
            Global ObjState = new Global();
            DataSet ds = new DataSet();
            ListItem lst = new ListItem();
            lst.Text = "State";
            lst.Value = "0";

            ds = ObjState.GetAllState();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlState.DataValueField = "StateShortName";
                ddlState.DataTextField = "StateShortName";
                ddlState.DataSource = ds.Tables[0];
                ddlState.DataBind();
                ddlState1.DataValueField = "StateShortName";
                ddlState1.DataTextField = "StateShortName";
                ddlState1.DataSource = ds.Tables[0];
                ddlState1.DataBind();
            }
            ddlState.Items.Insert(0, lst);
            ddlState1.Items.Insert(0, lst);
        }

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
            BindAppointments();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = Convert.ToInt32(Session["UserID"]);

            if (!IsPostBack)
            {
                if (!(null == Request.QueryString["msg"]))
                {
                    string s = Request.QueryString["msg"].ToString();

                    lblsmsg.Visible = true;
                }
                ViewState["IsPet"] = "0";

                BindState();

                GetBreed();

                GetReferal();

                BindUser();

                bindUserAppID();

                bindPrePayAppId();

                BindPet();

                BindAppointments();

                BindPastAppointments();

                litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/StaticeContent/RegistrationUpdate.htm"));
            }
        }

        public void bindUserAppID()
        {

            DataSet ds = new DataSet();
            Groomer obj = new Groomer();
            ds = obj.GetFutureAppointmentID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lstappid.Add(Convert.ToInt32(ds.Tables[0].Rows[0]["UserAppID"]));
                }
            }
        }

        public void bindPrePayAppId()
        {

            DataSet ds1 = new DataSet();
            Groomer obj = new Groomer();
            ds1 = obj.GetAllPreAppointmentID();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    lstprepayappid.Add(Convert.ToInt32(ds1.Tables[0].Rows[i]["AppointmentID"]));
                }
            }
        }

        public void BindAppointments()
        {
            DataSet ds = new DataSet();

            DataTable dt1 = new DataTable();

            DataView dv = new DataView();

            Groomer obj = new Groomer();

            ds = obj.GetFutureAppointment(userID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdUsers.Visible = true;

                dt1 = ds.Tables[0];

                dv = dt1.DefaultView;

                GrdUsers.DataSource = dv;

                GrdUsers.DataBind();
            }
            else
            {
                lblfutureinfo.Visible = true;
            }
        }

        public void BindPastAppointments()
        {
            Groomer obj = new Groomer();
            DataSet ds = obj.GetPastAppointment(Session["custname"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                lblPastInfo.Visible = true;
            }
        }

        protected void ResetViewStateAfterDelete()
        {
            if (ViewState["RowID"].ToString() == "1")
            {
                ViewState["RowID"] = "0";
            }
            else if (ViewState["RowID"].ToString() == "2")
            {
                ViewState["RowID"] = "1";
            }
            else if (ViewState["RowID"].ToString() == "3")
            {
                ViewState["RowID"] = "2";
            }
            else if (ViewState["RowID"].ToString() == "4")
            {
                ViewState["RowID"] = "3";
            }
            else if (ViewState["RowID"].ToString() == "5")
            {
                ViewState["RowID"] = "4";
            }
            else if (ViewState["RowID"].ToString() == "6")
            {
                ViewState["RowID"] = "5";
            }
        }

        protected void ResetPanel1()
        {
            ddlPetType1.SelectedIndex = 0;

            txtPetName1.Text = "";

            txtPetDOB1.Text = "";

            txtPetWeight1.Text = "";

            txtPetLength1.Text = "";
        }

        protected void ResetPanel2()
        {
            ddlPetType2.SelectedIndex = 0;
            txtPetName2.Text = "";
            txtDOB2.Text = "";
            txtPetWeight2.Text = "";
            txtPetLength2.Text = "";
        }

        protected void ResetPanel3()
        {
            ddlPetType3.SelectedIndex = 0;
            txtPetName3.Text = "";
            txtDOB3.Text = "";
            txtPetWeight3.Text = "";
            txtPetLength3.Text = "";
        }

        protected void ResetPanel4()
        {
            ddlPetType4.SelectedIndex = 0;
            txtPetName4.Text = "";
            txtDOB4.Text = "";
            txtPetWeight4.Text = "";
            txtPetLength4.Text = "";
        }

        protected void ResetPanel5()
        {
            ddlPetType5.SelectedIndex = 0;
            txtPetName5.Text = "";
            txtDOB5.Text = "";
            txtPetWeight5.Text = "";
            txtPetLength5.Text = "";
        }

        protected void ResetPanel6()
        {
            ddlPetType6.SelectedIndex = 0;
            txtPetName6.Text = "";
            txtDOB6.Text = "";
            txtPetWeight6.Text = "";
            txtPetLength6.Text = "";
        }

        protected void imgAddmore_Click(object sender, ImageClickEventArgs e)
        {
            ListItem lst = new ListItem();
            lst.Value = "0"; lst.Text = "Select One";

            if (ViewState["RowID"].ToString() == "0")
            {
                p2.Visible = true;
                ddlBreed2.Items.Insert(0, lst);
                ViewState["RowID"] = "1";
                imgDelete1.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "1")
            {
                p3.Visible = true;
                ViewState["RowID"] = "2";
                ddlBreed3.Items.Insert(0, lst);
                imgDelete2.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "2")
            {
                p4.Visible = true;
                ViewState["RowID"] = "3";
                ddlBreed4.Items.Insert(0, lst);
                imgDelete3.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "3")
            {
                p5.Visible = true;
                ViewState["RowID"] = "4";
                ddlBreed5.Items.Insert(0, lst);
                imgDelete4.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "4")
            {
                p6.Visible = true;
                ViewState["RowID"] = "5";
                ddlBreed6.Items.Insert(0, lst);
                imgDelete5.Visible = true;
                imgDelete6.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "5")
            {
                imgAddmore.Visible = false;
                lblMessageSix.Visible = true;
                lblMessageSix.Text = "You can add only six pets";
            }
        }

        protected void IdNext_Click(object sender, ImageClickEventArgs e)
        {
            int result;
            UpdateData(out result);
            if (result == 1)
                lblErrorEmail.Visible = true;
            lblErrorEmail.Text = "Account information updated successfully";
        }

        protected void IdReset_Click(object sender, ImageClickEventArgs e)
        {
            int result;
            UpdateData(out result);
            if (result == 1)
                Response.Redirect("Appointment.aspx");
        }

        protected void ddlPetType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed1(ddlPetType1.SelectedValue);
        }

        protected void ddlPetType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed2(ddlPetType2.SelectedValue);
        }

        protected void ddlPetType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed3(ddlPetType3.SelectedValue);
        }

        protected void ddlPetType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed4(ddlPetType4.SelectedValue);
        }

        protected void ddlPetType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed5(ddlPetType5.SelectedValue);
        }

        protected void ddlPetType6_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed6(ddlPetType6.SelectedValue);
        }

        public void UpdateData(out int result)
        {
            string AddPetMail = string.Empty;
            string TempAddPetMail = string.Empty;
            string UpdatePet = string.Empty;
            StoreFrontUser ObjUpdateUser = new StoreFrontUser();
            int Status = 3;
            int Type = CheckPet();
            if (Type == 3)
                Status = CheckStatus();
            else
                Status = Type;
            Session["UserType"] = Status.ToString();
            Session["MemberName"] = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();

            int Count = ObjUpdateUser.UpdateUser(Convert.ToInt32(Session["UserID"]), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtStreet.Text.Trim(), txtCity.Text.Trim(), ddlState.SelectedValue, txtZip.Text.Trim(), txtPhone.Text.Trim(), Convert.ToInt32(ddlReferralSource.SelectedValue), txtAltMobile.Text.Trim(), txtAltContact.Text.Trim(), txtAltStreet.Text.Trim(), txtAltCity.Text.Trim(), ddlState1.SelectedValue, txtAltZip.Text.Trim(), txtAltPhone.Text.Trim(), txtGroomer.Text.Trim(), Status, txtEmailReg.Text.Trim());
            if (Count == 0)
            {
                lblErrorEmail.Visible = true;
                lblErrorEmail.Text = "Sorry this mail id is already exists";
                result = 0;
            }
            else
            {
                result = 1;
                UpdateUserInfoMail();
                lblErrorEmail.Visible = false;
                int UserID = Convert.ToInt32(Session["UserID"]);
                int petID = 0;
                string I = PetID1.Text;
                if (p1.Visible == true)
                {
                    if ((txtPetName1.Text.Trim() != "") && (ddlBreed1.SelectedIndex != 0) && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
                    {
                        if (PetID1.Text == "0")
                        {
                            TempAddPetMail = ObjUpdateUser.AddPet(UserID, Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName1.Text.Trim(), Convert.ToInt32(ddlBreed1.SelectedValue), Convert.ToInt32(txtPetDOB1.Text.Trim()), Convert.ToDecimal(txtPetWeight1.Text.Trim()), Convert.ToDecimal(txtPetLength1.Text.Trim()));

                            if (AddPetMail == string.Empty) AddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            else AddPetMail = AddPetMail + TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            Add = Add = +1;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePet(Convert.ToInt32(PetID1.Text), UserID, Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName1.Text.Trim(), Convert.ToInt32(ddlBreed1.SelectedValue), Convert.ToInt32(txtPetDOB1.Text.Trim()), Convert.ToDecimal(txtPetWeight1.Text.Trim()), Convert.ToDecimal(txtPetLength1.Text.Trim()));
                            DataTable dt = (DataTable)ViewState["Pet"];
                            DataRow[] dr = dt.Select("UserID = 11", "");
                            update = update + 1;
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(1);
                            else UpdatePet = UpdatePet + IsPetUpdate(1);
                        }
                    }
                }
                if (p2.Visible == true)
                {
                    if ((txtPetName2.Text.Trim() != "") && (ddlBreed2.SelectedIndex != 0) && (txtDOB2.Text.Trim() != "") && (txtPetWeight2.Text.Trim() != "") && (txtPetLength2.Text.Trim() != ""))
                    {
                        if (PetID2.Text == "0")
                        {
                            TempAddPetMail = ObjUpdateUser.AddPet(UserID, Convert.ToInt32(ddlPetType2.SelectedValue), txtPetName2.Text.Trim(), Convert.ToInt32(ddlBreed2.SelectedValue), Convert.ToInt32(txtDOB2.Text.Trim()), Convert.ToDecimal(txtPetWeight2.Text.Trim()), Convert.ToDecimal(txtPetLength2.Text.Trim()));
                            if (AddPetMail == string.Empty) AddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            else AddPetMail = AddPetMail + TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            Add = Add = +1;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePet(Convert.ToInt32(PetID2.Text), UserID, Convert.ToInt32(ddlPetType2.SelectedValue), txtPetName2.Text.Trim(), Convert.ToInt32(ddlBreed2.SelectedValue), Convert.ToInt32(txtDOB2.Text.Trim()), Convert.ToDecimal(txtPetWeight2.Text.Trim()), Convert.ToDecimal(txtPetLength2.Text.Trim()));
                            update = update + 1;
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(2);
                            else UpdatePet = UpdatePet + IsPetUpdate(2);
                        }
                    }
                }
                if (p3.Visible == true)
                {
                    if ((txtPetName3.Text.Trim() != "") && (ddlBreed3.SelectedIndex != 0) && (txtDOB3.Text.Trim() != "") && (txtPetWeight3.Text.Trim() != "") && (txtPetLength3.Text.Trim() != ""))
                    {
                        if (PetID3.Text == "0")
                        {
                            TempAddPetMail = ObjUpdateUser.AddPet(UserID, Convert.ToInt32(ddlPetType3.SelectedValue), txtPetName3.Text.Trim(), Convert.ToInt32(ddlBreed3.SelectedValue), Convert.ToInt32(txtDOB3.Text.Trim()), Convert.ToDecimal(txtPetWeight3.Text.Trim()), Convert.ToDecimal(txtPetLength3.Text.Trim()));
                            if (AddPetMail == string.Empty) AddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            else AddPetMail = AddPetMail + TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            Add = Add = +1;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePet(Convert.ToInt32(PetID3.Text), UserID, Convert.ToInt32(ddlPetType3.SelectedValue), txtPetName3.Text.Trim(), Convert.ToInt32(ddlBreed3.SelectedValue), Convert.ToInt32(txtDOB3.Text.Trim()), Convert.ToDecimal(txtPetWeight3.Text.Trim()), Convert.ToDecimal(txtPetLength3.Text.Trim()));
                            update = update + 1;
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(3);
                            else UpdatePet = UpdatePet + IsPetUpdate(3);
                        }
                    }
                }
                if (p4.Visible == true)
                {
                    if ((txtPetName4.Text.Trim() != "") && (ddlBreed4.SelectedIndex != 0) && (txtDOB4.Text.Trim() != "") && (txtPetWeight4.Text.Trim() != "") && (txtPetLength4.Text.Trim() != ""))
                    {
                        if (PetID4.Text == "0")
                        {
                            TempAddPetMail = ObjUpdateUser.AddPet(UserID, Convert.ToInt32(ddlPetType4.SelectedValue), txtPetName4.Text.Trim(), Convert.ToInt32(ddlBreed4.SelectedValue), Convert.ToInt32(txtDOB4.Text.Trim()), Convert.ToDecimal(txtPetWeight4.Text.Trim()), Convert.ToDecimal(txtPetLength4.Text.Trim()));
                            if (AddPetMail == string.Empty) AddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            else AddPetMail = AddPetMail + TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            Add = Add = +1;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePet(Convert.ToInt32(PetID4.Text), UserID, Convert.ToInt32(ddlPetType4.SelectedValue), txtPetName4.Text.Trim(), Convert.ToInt32(ddlBreed4.SelectedValue), Convert.ToInt32(txtDOB4.Text.Trim()), Convert.ToDecimal(txtPetWeight4.Text.Trim()), Convert.ToDecimal(txtPetLength4.Text.Trim()));
                            update = update + 1;
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(4);
                            else UpdatePet = UpdatePet + IsPetUpdate(4);
                        }
                    }
                }
                if (p5.Visible == true)
                {
                    if ((txtPetName5.Text.Trim() != "") && (ddlBreed5.SelectedIndex != 0) && (txtDOB5.Text.Trim() != "") && (txtPetWeight5.Text.Trim() != "") && (txtPetLength5.Text.Trim() != ""))
                    {
                        if (PetID5.Text == "0")
                        {
                            TempAddPetMail = ObjUpdateUser.AddPet(UserID, Convert.ToInt32(ddlPetType5.SelectedValue), txtPetName5.Text.Trim(), Convert.ToInt32(ddlBreed5.SelectedValue), Convert.ToInt32(txtDOB5.Text.Trim()), Convert.ToDecimal(txtPetWeight5.Text.Trim()), Convert.ToDecimal(txtPetLength5.Text.Trim()));
                            if (AddPetMail == string.Empty) AddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            else AddPetMail = AddPetMail + TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            Add = Add = +1;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePet(Convert.ToInt32(PetID5.Text), UserID, Convert.ToInt32(ddlPetType5.SelectedValue), txtPetName5.Text.Trim(), Convert.ToInt32(ddlBreed5.SelectedValue), Convert.ToInt32(txtDOB5.Text.Trim()), Convert.ToDecimal(txtPetWeight5.Text.Trim()), Convert.ToDecimal(txtPetLength5.Text.Trim()));
                            update = update + 1;
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(5);
                            else UpdatePet = UpdatePet + IsPetUpdate(5);
                        }
                    }
                }
                if (p6.Visible == true)
                {
                    if ((txtPetName6.Text.Trim() != "") && (ddlBreed6.SelectedIndex != 0) && (txtDOB6.Text.Trim() != "") && (txtPetWeight6.Text.Trim() != "") && (txtPetLength6.Text.Trim() != ""))
                    {
                        if (PetID6.Text == "0")
                        {
                            TempAddPetMail = ObjUpdateUser.AddPet(UserID, Convert.ToInt32(ddlPetType6.SelectedValue), txtPetName6.Text.Trim(), Convert.ToInt32(ddlBreed6.SelectedValue), Convert.ToInt32(txtDOB6.Text.Trim()), Convert.ToDecimal(txtPetWeight6.Text.Trim()), Convert.ToDecimal(txtPetLength6.Text.Trim()));
                            if (AddPetMail == string.Empty) TempAddPetMail = AddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            else AddPetMail = AddPetMail + TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text.ToString());
                            Add = Add = +1;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePet(Convert.ToInt32(PetID6.Text), UserID, Convert.ToInt32(ddlPetType6.SelectedValue), txtPetName6.Text.Trim(), Convert.ToInt32(ddlBreed6.SelectedValue), Convert.ToInt32(txtDOB6.Text.Trim()), Convert.ToDecimal(txtPetWeight6.Text.Trim()), Convert.ToDecimal(txtPetLength6.Text.Trim()));
                            update = update + 1;
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(6);
                            else UpdatePet = UpdatePet + IsPetUpdate(6);
                        }
                    }
                }
                if (AddPetMail != string.Empty)
                {
                    PetAddMail(AddPetMail);
                }
                if (UpdatePet != string.Empty)
                {
                    PetUpdateMail(UpdatePet);
                }
            }
        }

        public int CheckStatus()
        {
            int c = 0;
            int d = 0;
            if ((p1.Visible == true) && (ViewState["IsPet"].ToString() != "0"))
            {
                if (ddlPetType1.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (p2.Visible == true)
            {
                if (ddlPetType2.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (p3.Visible == true)
            {
                if (ddlPetType3.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (p4.Visible == true)
            {
                if (ddlPetType4.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (p5.Visible == true)
            {
                if (ddlPetType5.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (p6.Visible == true)
            {
                if (ddlPetType6.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            int status = 3;
            if ((c == 0) && (d == 0))
                status = 3;
            if ((c > 0) && (d > 0))
                status = 3;
            if ((c > 0) && (d == 0))
                status = 1;
            if ((c == 0) && (d > 0))
                status = 2;
            return status;
        }

        public int CheckPet()
        {
            if (ViewState["IsPet"].ToString() == "0")
            {
                if ((txtPetName1.Text.Trim() != "") && (ddlBreed1.SelectedIndex != 0) && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
                {
                    ViewState["RowID"] = "0";
                    return Convert.ToInt32(ddlPetType1.SelectedValue) + 1;
                }
                else
                    return 3;
            }
            else
                return 3;
        }

        protected void imgDelete1_Click(object sender, ImageClickEventArgs e)
        {
            p1.Visible = false;
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID1.Text.Trim()), GetUpdatedPet());
            string Body = "Pet = " + ddlPetType1.SelectedItem.Text + "<br>Pet Name = " + txtPetName1.Text.Trim() + "<br> Breed Name = " + ddlBreed1.SelectedItem.Text +
                          "<br>Years = " + txtPetDOB1.Text.Trim() + "<br>Weight = " + txtPetWeight1.Text.Trim() + "<br> Fur Length = " + txtPetLength1.Text.Trim() + "<br><br><br>";
            PetDeleteMail(Body);
            BindPet();
        }

        protected void imgDelete2_Click(object sender, ImageClickEventArgs e)
        {
            p2.Visible = false;
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID2.Text.Trim()), GetUpdatedPet());
            int Status = GetUpdatedPet();
            string Body = "Pet = " + ddlPetType2.SelectedItem.Text + "<br>Pet Name = " + txtPetName2.Text.Trim() + "<br> Breed Name = " + ddlBreed2.SelectedItem.Text +
                          "<br>Years = " + txtDOB2.Text.Trim() + "<br>Weight = " + txtPetWeight2.Text.Trim() + "<br> Fur Length = " + txtPetLength2.Text.Trim() + "<br><br><br>";
            PetDeleteMail(Body);
            BindPet();
        }
        protected void imgDelete3_Click(object sender, ImageClickEventArgs e)
        {
            p3.Visible = false;
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            int Status = GetUpdatedPet();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID3.Text.Trim()), GetUpdatedPet());
            string Body = "Pet = " + ddlPetType3.SelectedItem.Text + "<br>Pet Name = " + txtPetName3.Text.Trim() + "<br> Breed Name = " + ddlBreed3.SelectedItem.Text +
                          "<br>Years = " + txtDOB3.Text.Trim() + "<br>Weight = " + txtPetWeight3.Text.Trim() + "<br> Fur Length = " + txtPetLength3.Text.Trim() + "<br><br><br>";
            PetDeleteMail(Body);
            BindPet();
        }
        protected void imgDelete4_Click(object sender, ImageClickEventArgs e)
        {
            p4.Visible = false;
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID4.Text.Trim()), GetUpdatedPet());
            string Body = "Pet = " + ddlPetType4.SelectedItem.Text + "<br>Pet Name = " + txtPetName4.Text.Trim() + "<br> Breed Name = " + ddlBreed4.SelectedItem.Text +
                          "<br>Years = " + txtDOB4.Text.Trim() + "<br>Weight = " + txtPetWeight4.Text.Trim() + "<br> Fur Length = " + txtPetLength4.Text.Trim() + "<br><br><br>";
            PetDeleteMail(Body);
            BindPet();
        }
        protected void imgDelete5_Click(object sender, ImageClickEventArgs e)
        {
            p5.Visible = false;
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID5.Text.Trim()), GetUpdatedPet());
            string Body = "Pet = " + ddlPetType5.SelectedItem.Text + "<br>Pet Name = " + txtPetName5.Text.Trim() + "<br> Breed Name = " + ddlBreed5.SelectedItem.Text +
                          "<br>Years = " + txtDOB5.Text.Trim() + "<br>Weight = " + txtPetWeight5.Text.Trim() + "<br> Fur Length = " + txtPetLength5.Text.Trim() + "<br><br><br>";
            PetDeleteMail(Body);
            BindPet();
        }
        protected void imgDelete6_Click(object sender, ImageClickEventArgs e)
        {
            p6.Visible = false;
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID6.Text.Trim()), GetUpdatedPet());
            string Body = "Pet = " + ddlPetType6.SelectedItem.Text + "<br>Pet Name = " + txtPetName6.Text.Trim() + "<br> Breed Name = " + ddlBreed6.SelectedItem.Text +
                          "<br>Years = " + txtDOB6.Text.Trim() + "<br>Weight = " + txtPetWeight6.Text.Trim() + "<br> Fur Length = " + txtPetLength6.Text.Trim() + "<br><br><br>";
            PetDeleteMail(Body);
            BindPet();
        }

        public int GetUpdatedPet()
        {
            int Status = 3;
            int Type = CheckPet();
            if (Type == 3)
                Status = CheckStatus();
            else
                Status = Type;
            Session["UserType"] = Status.ToString();
            return Status;
        }

        public void PetAddMail(string body)
        {
            try
            {
                string Mailbody = ContentManager.GetStaticeContentEmail("AddPet.htm").Replace("~", "#");
                Mailbody = Mailbody.Replace("<!-- Update -->", body);
                Mailbody = Mailbody.Replace("<!-- UserName -->", txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());
                SendMails ObjMail = new SendMails();
                ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), "User add pet", Mailbody);
            }
            catch(Exception ex)
            {
            }
        }

        public void PetDeleteMail(string body)
        {
            try
            {
                string Mailbody = ContentManager.GetStaticeContentEmail("DeletePet.htm").Replace("~", "#");
                Mailbody = Mailbody.Replace("<!-- Update -->", body);
                Mailbody = Mailbody.Replace("<!-- UserName -->", txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());
                SendMails ObjMail = new SendMails();
                ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), "User delete pet", Mailbody);
            }
            catch (Exception ex)
            {
            }
        }

        public void PetUpdateMail(string body)
        {
            try
            {
                string Mailbody = ContentManager.GetStaticeContentEmail("PetUpdate.htm").Replace("~", "#");
                Mailbody = Mailbody.Replace("<!-- Update -->", body);
                Mailbody = Mailbody.Replace("<!-- UserName -->", txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());
                SendMails ObjMail = new SendMails();
                ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), "User pet updated", Mailbody);
            }
            catch (Exception ex)
            {
            }
        }

        public void UpdateUserInfoMail()
        {
            SendMails ObjMail = new SendMails();
            string str = string.Empty;
            DataTable dt = (DataTable)ViewState["UserInformation"];
            string Mailbody = ContentManager.GetStaticeContentEmail("UpdateUser.htm").Replace("~", "#");
            if (txtFirstName.Text.Trim() != dt.Rows[0]["FirstName"].ToString())
                str = str + "FirstName = " + txtFirstName.Text.Trim() + "<br>";
            if (txtLastName.Text.Trim() != dt.Rows[0]["LastName"].ToString())
                str = str + "LastName = " + txtLastName.Text.Trim() + "<br>";
            if ((txtStreet.Text.Trim() != dt.Rows[0]["Street"].ToString()) || (txtCity.Text.Trim() != dt.Rows[0]["City"].ToString()) || (ddlState.SelectedValue != dt.Rows[0]["State"].ToString()) || (txtZip.Text.Trim() != dt.Rows[0]["Zip"].ToString()))
            {
                str = str + "Address = " + txtStreet.Text.Trim() + "," +
                    txtCity.Text.Trim() + "," +
                    ddlState.SelectedValue + "," +
                    txtZip.Text.Trim() + "<br>";
            }
            if (txtPhone.Text.Trim() != dt.Rows[0]["Phone"].ToString())
                str = str + "Phone = " + txtPhone.Text.Trim() + "<br>";
            if (txtAltMobile.Text.Trim() != dt.Rows[0]["AltMobile"].ToString())
                str = str + "Alternate Mobile = " + txtAltMobile.Text.Trim() + "<br>";
            if (txtAltContact.Text.Trim() != dt.Rows[0]["AltContact"].ToString())
                str = str + "Alternate Contact Name = " + txtAltContact.Text.Trim() + "<br>";
            if ((txtAltStreet.Text.Trim() != dt.Rows[0]["AltStreet"].ToString()) || (txtAltCity.Text.Trim() != dt.Rows[0]["AltCity"].ToString()) || (ddlState1.SelectedValue != dt.Rows[0]["AltState"].ToString()) || (txtAltZip.Text.Trim() != dt.Rows[0]["AltZip"].ToString()))
                str = str + "Alternate Address = " + txtAltStreet.Text.Trim() + "," +
                     txtAltCity.Text.Trim() + "," +
                    ddlState1.SelectedValue + "," +
                    txtAltZip.Text.Trim() + "<br>";
            if (txtAltPhone.Text.Trim() != dt.Rows[0]["AltPhone"].ToString())
                str = str + "Alternate Phone" + txtAltPhone.Text.Trim() + "<br>";
            if (txtGroomer.Text.Trim() != dt.Rows[0]["PreferredGroomer"].ToString())
                str = str + "Preferred Groomer = " + txtGroomer.Text.Trim() + "<br>";

            if (ddlReferralSource.SelectedValue != dt.Rows[0]["ReferralID"].ToString())
                str = str + "Referral Source = " + ddlReferralSource.SelectedValue + "<br>";

            if (str != string.Empty)
            {
                
                Mailbody = Mailbody.Replace("<!-- Update -->", str);
                Mailbody = Mailbody.Replace("<!-- UserName -->", dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString());
               
                ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), "Update user profile", Mailbody);
            }
        }

        public string IsPetUpdate(int count)
        {
            string str = string.Empty;
            DataTable dt = (DataTable)ViewState["Pet"];
            switch (count)
            {
                case 1:
                    if (ddlPetType1.SelectedValue != dt.Rows[0]["PetType"].ToString() || txtPetName1.Text.Trim() != dt.Rows[0]["PetName"].ToString() || ddlBreed1.SelectedValue != dt.Rows[0]["BreedID"].ToString() || txtPetDOB1.Text.Trim() != dt.Rows[0]["Years"].ToString() || txtPetWeight1.Text.Trim() != dt.Rows[0]["Weight"].ToString() || txtPetLength1.Text.Trim() != dt.Rows[0]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType1.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName1.Text + "<br>" +
                        "Breed Name = " + ddlBreed1.SelectedItem.Text + "<br>" +
                        "Year = " + txtPetDOB1.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight1.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength1.Text.Trim();
                    }
                    break;
                case 2:
                    if (ddlPetType2.SelectedValue != dt.Rows[1]["PetType"].ToString() || txtPetName2.Text.Trim() != dt.Rows[1]["PetName"].ToString() || ddlBreed2.SelectedValue != dt.Rows[1]["BreedID"].ToString() || txtDOB2.Text.Trim() != dt.Rows[1]["Years"].ToString() || txtPetWeight2.Text.Trim() != dt.Rows[1]["Weight"].ToString() || txtPetLength2.Text.Trim() != dt.Rows[1]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType2.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName2.Text + "<br>" +
                        "Breed Name = " + ddlBreed2.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB2.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight2.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength2.Text.Trim();
                    }
                    break;
                case 3:
                    if (ddlPetType3.SelectedValue != dt.Rows[2]["PetType"].ToString() || txtPetName3.Text.Trim() != dt.Rows[2]["PetName"].ToString() || ddlBreed3.SelectedValue != dt.Rows[2]["BreedID"].ToString() || txtDOB3.Text.Trim() != dt.Rows[2]["Years"].ToString() || txtPetWeight3.Text.Trim() != dt.Rows[2]["Weight"].ToString() || txtPetLength3.Text.Trim() != dt.Rows[2]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType3.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName3.Text + "<br>" +
                        "Breed Name = " + ddlBreed3.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB3.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight3.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength3.Text.Trim();
                    }
                    break;
                case 4:
                    if (ddlPetType4.SelectedValue != dt.Rows[3]["PetType"].ToString() || txtPetName4.Text.Trim() != dt.Rows[3]["PetName"].ToString() || ddlBreed4.SelectedValue != dt.Rows[3]["BreedID"].ToString() || txtDOB4.Text.Trim() != dt.Rows[3]["Years"].ToString() || txtPetWeight4.Text.Trim() != dt.Rows[3]["Weight"].ToString() || txtPetLength4.Text.Trim() != dt.Rows[3]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType4.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName4.Text + "<br>" +
                        "Breed Name = " + ddlBreed4.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB4.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight4.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength4.Text.Trim();
                    }
                    break;
                case 5:
                    if (ddlPetType5.SelectedValue != dt.Rows[4]["PetType"].ToString() || txtPetName5.Text.Trim() != dt.Rows[4]["PetName"].ToString() || ddlBreed5.SelectedValue != dt.Rows[4]["BreedID"].ToString() || txtDOB5.Text.Trim() != dt.Rows[4]["Years"].ToString() || txtPetWeight5.Text.Trim() != dt.Rows[4]["Weight"].ToString() || txtPetLength5.Text.Trim() != dt.Rows[4]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType5.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName5.Text + "<br>" +
                        "Breed Name = " + ddlBreed5.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB5.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight5.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength5.Text.Trim();
                    }
                    break;
                case 6:
                    if (ddlPetType6.SelectedValue != dt.Rows[5]["PetType"].ToString() || txtPetName6.Text.Trim() != dt.Rows[5]["PetName"].ToString() || ddlBreed6.SelectedValue != dt.Rows[5]["BreedID"].ToString() || txtDOB6.Text.Trim() != dt.Rows[5]["Years"].ToString() || txtPetWeight6.Text.Trim() != dt.Rows[5]["Weight"].ToString() || txtPetLength6.Text.Trim() != dt.Rows[5]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType6.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName6.Text + "<br>" +
                        "Breed Name = " + ddlBreed6.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB6.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight6.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength6.Text.Trim();
                    }
                    break;
            }
            return str;
        }

        protected void GrdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        void lb_Command(object sender, CommandEventArgs e)
        {
            GrdUsers.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
            BindAppointments();
        }

        void lb_Command1(object sender, CommandEventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
            BindPastAppointments();
        }

        protected void GrdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblpUserappId = (Label)e.Row.FindControl("lblappId");
                HyperLink lnkpayment = (HyperLink)e.Row.FindControl("HypName");
                Label lblpstat1 = (Label)e.Row.FindControl("lblpStatus1");
                Label lblPStatus = (Label)e.Row.FindControl("lblPaidStatus");
                ImageButton btnimg = (ImageButton)e.Row.FindControl("btnDeleteApp");
                //c = checkappid();
                if (lstappid.Contains(Convert.ToInt32(lblpUserappId.Text)))
                {
                    lblpstat1.Text = "Confirmed";
                    lnkpayment.Visible = false;
                    lblPStatus.Visible = true;
                    btnimg.Enabled = false;
                }
                else if (lstprepayappid.Contains(Convert.ToInt32(lblpUserappId.Text)))
                {
                    lblpstat1.Text = "Unconfirmed";
                    lnkpayment.Visible = false;
                    lblPStatus.Visible = true;
                    btnimg.Enabled = false;
                }
                else
                {
                    lblpstat1.Text = "Unconfirmed";
                    lnkpayment.Visible = true;
                }
            }
        }

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

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridViewRow gvr = GridView1.BottomPagerRow;
            Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
            lb1.Text = Convert.ToString(GridView1.PageIndex + 1);
            int[] page = new int[7];
            page[0] = GridView1.PageIndex - 2;
            page[1] = GridView1.PageIndex - 1;
            page[2] = GridView1.PageIndex;
            page[3] = GridView1.PageIndex + 1;
            page[4] = GridView1.PageIndex + 2;
            page[5] = GridView1.PageIndex + 3;
            page[6] = GridView1.PageIndex + 4;
            for (int i = 0; i < 7; i++)
            {
                if (i != 3)
                {
                    if (page[i] < 1 || page[i] > GridView1.PageCount)
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
            if (GridView1.PageIndex == 0)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
                lb.Visible = false;
            }
            if (GridView1.PageIndex == GrdUsers.PageCount - 1)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
                lb.Visible = false;
            }
            if (GridView1.PageIndex > GrdUsers.PageCount - 5)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
                lbmore.Visible = false;
            }
            if (GridView1.PageIndex < 4)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
                lbmore.Visible = false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewRow gvr = e.Row;
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p0");
                lb.Command += new CommandEventHandler(lb_Command1);
                lb = (LinkButton)gvr.Cells[0].FindControl("p1");
                lb.Command += new CommandEventHandler(lb_Command1);
                lb = (LinkButton)gvr.Cells[0].FindControl("p2");
                lb.Command += new CommandEventHandler(lb_Command1);
                lb = (LinkButton)gvr.Cells[0].FindControl("p4");
                lb.Command += new CommandEventHandler(lb_Command1);
                lb = (LinkButton)gvr.Cells[0].FindControl("p5");
                lb.Command += new CommandEventHandler(lb_Command1);
                lb = (LinkButton)gvr.Cells[0].FindControl("p6");
                lb.Command += new CommandEventHandler(lb_Command1);
            }
        }

        protected void GrdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int lbldeleteid = Convert.ToInt32(GrdUsers.DataKeys[e.RowIndex].Value);
            sendCancelAppMail(lbldeleteid);
            deleteCustomerApp(lbldeleteid);

        }

        public void deleteCustomerApp(int id)
        {
            Groomer obj = new Groomer();
            obj.DeleteCustomerAppointment(id);
            Response.Redirect("MyAccount.aspx");
        }

        public void sendCancelAppMail(int id)
        {
            Groomer obj = new Groomer();
            DataSet ds = new DataSet();

            ds = obj.GetCustAppointmentbyID(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string txtAppointmentDate = ds.Tables[0].Rows[0]["Date"].ToString();
                string txtExpectedPetTime = ds.Tables[0].Rows[0]["T"].ToString();
                string txtcName = ds.Tables[0].Rows[0]["fullName"].ToString();
                string lblStatus = ds.Tables[0].Rows[0]["Address"].ToString();

                SendMails ObjMail = new SendMails();
                string MailbodyAdmin = ContentManager.GetStaticeContentEmail("CancelCustAppointment.htm").Replace("~", "#");
                MailbodyAdmin = MailbodyAdmin.Replace("<!-- Date -->", txtAppointmentDate);
                MailbodyAdmin = MailbodyAdmin.Replace("<!-- Time -->", txtExpectedPetTime);
                MailbodyAdmin = MailbodyAdmin.Replace("<!-- UserName -->", txtcName);
                MailbodyAdmin = MailbodyAdmin.Replace("<!-- Address -->", lblStatus);

                ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), "Appointment cancel by " + Convert.ToString(Session["MemberName"]), MailbodyAdmin);
            }
        }
    }
}