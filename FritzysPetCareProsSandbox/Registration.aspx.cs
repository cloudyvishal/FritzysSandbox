using System;
using System.Web;
using System.Data;
using System.Linq;
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

public delegate void CaptchaEventHandler();

namespace FritzysPetCareProsSandbox
{
    public partial class Registration : BasePage
    {
        string PetTypeID = "0";
        private string color = "#ffffff";
        protected string style;
        private event CaptchaEventHandler success;
        private event CaptchaEventHandler failure;
        #region Captcha Code
        /*
        This region sse to set captcha control 
        
    */
        private void SetCaptcha()
        {
            // Set image
            string s = RandomText.Generate();

            // Encrypt
            string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));

            // Save to session
            Session["captcha"] = s.ToLower();

            // Set url
            imgCaptcha.ImageUrl = "~/Captcha.ashx?w=305&h=92&c=" + ens + "&bc=" + color;
        }

        public string BackgroundColor
        {
            set { color = value.Trim("#".ToCharArray()); }
            get { return color; }
        }
        public string Style
        {
            set { style = value; }
            get { return style; }
        }
        public event CaptchaEventHandler Success
        {
            add { success += value; }
            remove { success += null; }
        }
        public event CaptchaEventHandler Failure
        {
            add { failure += value; }
            remove { failure += null; }
        }

        #endregion

        #region Bind
        /* This region use to bind all data breed releated */
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
            }
            ddlState.Items.Insert(0, lst);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!(null == Session["UserID"]))
                {
                    tblAlternate.Visible = true;

                    txtPasswordReg.Enabled = false;

                    txtConPasswordReg.Enabled = false;

                    ReqPasswordReg.Enabled = false;

                    custPasswordLength.Enabled = false;

                    ReqConPasswordReg.Enabled = false;

                    ValConfirmPass.Enabled = false;

                    BindLoginUserDetails(Convert.ToInt32(Session["UserID"]));
                }
                else
                {
                    txtPasswordReg.Enabled = true;

                    txtConPasswordReg.Enabled = true;
                }
                bool Ismobile = false;
                string[] mobiles =
                new[]
                {
                    "midp","android","j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                     "opwv", "chtml","320x480",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi", 
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                     "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };
                //Loop through each item in the list created above 
                //and check if the header contains that text
                foreach (string s in mobiles)
                {
                    if (Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                    {
                        Ismobile = true;
                    }
                }

                if (Ismobile.Equals(true))
                {
                    HttpContext.Current.Response.Status = "301 Moved Permanently";
                    HttpContext.Current.Response.AddHeader("Location",
                    Request.Url.ToString().Replace(Request.Url.ToString(), ("http://localhost:50372/fritzymobile/MB_Registration.aspx").ToLower()));

                }

                else
                {
                    ViewState["IsPet"] = "0";
                    SetCaptcha();

                    GetBreed1(PetTypeID);
                    GetBreed2(PetTypeID);
                    GetBreed3(PetTypeID);
                    GetBreed4(PetTypeID);
                    GetBreed5(PetTypeID);
                    GetBreed6(PetTypeID);


                    GetReferal();
                    ViewState["RowID"] = 0;
                    p2.Visible = false;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = false;
                    p6.Visible = false;
                    BindState();
                    litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/StaticeContent/Registration_Basic.htm"));

                }
            }
        }

        private void BindLoginUserDetails(int UserId)
        {
            DataSet ds = null;

            StoreFrontUser objStoreFrontUser = null;

            try
            {
                objStoreFrontUser = new StoreFrontUser();

                ds = objStoreFrontUser.BindLoginUserDetails(UserId);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();

                        txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();

                        txtStreet.Text = ds.Tables[0].Rows[0]["Street"].ToString();

                        txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();

                        txtZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();

                        txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

                        txtEmailReg.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

                        txtPasswordReg.Text = ds.Tables[0].Rows[0]["Password"].ToString();

                        txtConPasswordReg.Text = txtPasswordReg.Text;
                    }
                }
            }
            finally
            {
                objStoreFrontUser = null;

                ds.Dispose();
            }
        }

        #region Event
        /* This region Use to reset captcha text */
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            txtConfirmReg.Text = string.Empty;
            SetCaptcha();
        }

        /* This event is use to set new row for pet and maintain the row count asuser can add only six pet */
        protected void imgAddmore_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["RowID"].ToString() == "0")
            {
                p2.Visible = true;
                ViewState["RowID"] = "1";
                ViewState["IsPet"] = "1";
                //imgDelete1.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "1")
            {
                p3.Visible = true;
                ViewState["RowID"] = "2";
                //imgDelete2.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "2")
            {
                p4.Visible = true;
                ViewState["RowID"] = "3";
                //imgDelete3.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "3")
            {
                p5.Visible = true;
                ViewState["RowID"] = "4";
                //imgDelete4.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "4")
            {
                p6.Visible = true;
                ViewState["RowID"] = "5";
                //imgDelete5.Visible = true;
            }
            else if (ViewState["RowID"].ToString() == "5")
            {
                imgAddmore.Visible = false;
                lblMessageSix.Visible = true;
                lblMessageSix.Text = "You can add only six pets";
                //imgDelete6.Visible = true;
            }

        }

        /* 
         *  This event is used to add new member data to database with check and 
            Add pet information to database.
         *  also set if Isrember function as per user choice 
         *  send a mail to user to "Welcome User"
         */
        protected void IdSubmit_Click(object sender, ImageClickEventArgs e)
        {

            string str = Session["captcha"].ToString();
            int UserID = 0;
            if (txtConfirmReg.Text.ToLower() != Session["captcha"].ToString())
            {
                lblCaptchaError.Visible = true;
                lblCaptchaError.Text = "Please enter correct confirmation code";
            }
            else
            {
                lblCaptchaError.Visible = false;
                lblCaptchaError.Text = "";
                StoreFrontUser ObjNewUser = new StoreFrontUser();
                int Status = 3;
                int Type = CheckPet();
                if (Type == 3)
                    Status = CheckStatus();
                else
                    Status = Type;
                Session["UserType"] = Status.ToString();
                Session["MemberName"] = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();

                if (!(null == Session["UserID"]))
                {
                    ObjNewUser.UpdateUser(Convert.ToInt32(Session["UserID"]), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtStreet.Text.Trim(), txtCity.Text.Trim(), ddlState.SelectedValue, txtZip.Text.Trim(), txtPhone.Text.Trim(), Convert.ToInt32(ddlReferralSource.SelectedValue), txtAltPhone.Text.ToString(), txtAltContact.Text.ToString(), txtAltStreet.Text, txtAltCity.Text.ToString(), txtAltStreet.Text.ToString(), txtAltZip.Text.ToString(), txtAltPhone.Text.ToString(), txtGroomer.Text.ToString(), Status, txtEmailReg.Text.ToString());
                }
                else
                {
                    UserID = ObjNewUser.AddUserBasic(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtStreet.Text.Trim(), txtCity.Text.Trim(), ddlState.SelectedValue, txtZip.Text.Trim(), txtPhone.Text.Trim(), Convert.ToInt32(ddlReferralSource.SelectedValue), txtEmailReg.Text.Trim(), txtPasswordReg.Text.Trim(), Status);
                }
                if (UserID != 0)
                {
                    if ((p1.Visible == true) && (txtPetName1.Text.Trim() != "") && (ddlBreed1.SelectedIndex != 0) && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
                    {
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName1.Text.Trim(), Convert.ToInt32(ddlBreed1.SelectedValue), Convert.ToInt32(txtPetDOB1.Text.Trim()), Convert.ToDecimal(txtPetWeight1.Text.Trim()), Convert.ToDecimal(txtPetLength1.Text.Trim()));
                    }
                    if ((p2.Visible == true) && (txtPetName2.Text.Trim() != "") && (ddlBreed2.SelectedIndex != 0) && (txtDOB2.Text.Trim() != "") && (txtPetWeight2.Text.Trim() != "") && (txtPetLength2.Text.Trim() != ""))
                    {
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType2.SelectedValue), txtPetName2.Text.Trim(), Convert.ToInt32(ddlBreed2.SelectedValue), Convert.ToInt32(txtDOB2.Text.Trim()), Convert.ToDecimal(txtPetWeight2.Text.Trim()), Convert.ToDecimal(txtPetLength2.Text.Trim()));
                    }
                    if ((p3.Visible == true) && (txtPetName3.Text.Trim() != "") && (ddlBreed3.SelectedIndex != 0) && (txtDOB3.Text.Trim() != "") && (txtPetWeight3.Text.Trim() != "") && (txtPetLength3.Text.Trim() != ""))
                    {
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType3.SelectedValue), txtPetName3.Text.Trim(), Convert.ToInt32(ddlBreed3.SelectedValue), Convert.ToInt32(txtDOB3.Text.Trim()), Convert.ToDecimal(txtPetWeight3.Text.Trim()), Convert.ToDecimal(txtPetLength3.Text.Trim()));
                    }
                    if ((p4.Visible == true) && (txtPetName4.Text.Trim() != "") && (ddlBreed4.SelectedIndex != 0) && (txtDOB4.Text.Trim() != "") && (txtPetWeight4.Text.Trim() != "") && (txtPetLength4.Text.Trim() != ""))
                    {
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType4.SelectedValue), txtPetName4.Text.Trim(), Convert.ToInt32(ddlBreed4.SelectedValue), Convert.ToInt32(txtDOB4.Text.Trim()), Convert.ToDecimal(txtPetWeight4.Text.Trim()), Convert.ToDecimal(txtPetLength4.Text.Trim()));
                    }
                    if ((p5.Visible == true) && (txtPetName5.Text.Trim() != "") && (ddlBreed5.SelectedIndex != 0) && (txtDOB5.Text.Trim() != "") && (txtPetWeight5.Text.Trim() != "") && (txtPetLength5.Text.Trim() != ""))
                    {
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType5.SelectedValue), txtPetName5.Text.Trim(), Convert.ToInt32(ddlBreed5.SelectedValue), Convert.ToInt32(txtDOB5.Text.Trim()), Convert.ToDecimal(txtPetWeight5.Text.Trim()), Convert.ToDecimal(txtPetLength5.Text.Trim()));
                    }
                    if ((p6.Visible == true) && (txtPetName6.Text.Trim() != "") && (ddlBreed6.SelectedIndex != 0) && (txtDOB6.Text.Trim() != "") && (txtPetWeight6.Text.Trim() != "") && (txtPetLength6.Text.Trim() != ""))
                    {
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType6.SelectedValue), txtPetName6.Text.Trim(), Convert.ToInt32(ddlBreed6.SelectedValue), Convert.ToInt32(txtDOB6.Text.Trim()), Convert.ToDecimal(txtPetWeight6.Text.Trim()), Convert.ToDecimal(txtPetLength6.Text.Trim()));
                    }


                    if (chkRemember.Checked == true)
                    {
                        HttpContext.Current.Request.Cookies.Clear();
                        if (Request.Cookies["remUsername"] == null)
                        {
                            HttpCookie c = new HttpCookie("remUsername", txtEmailReg.Text);
                            c.Expires = new DateTime(2015, 12, 1);
                            Response.Cookies.Add(c);
                        }
                        if (Request.Cookies["remPassword"] == null)
                        {
                            HttpCookie c = new HttpCookie("remPassword", txtPasswordReg.Text);
                            c.Expires = new DateTime(2015, 12, 1);
                            Response.Cookies.Add(c);
                        }
                    }
                    else
                    {
                        Response.Cookies["remUsername"].Expires = DateTime.Now.AddYears(-30);
                        Response.Cookies["remPassword"].Expires = DateTime.Now.AddYears(-30);
                    }
                    if ((Request.Cookies["IsLogin"] == null) || (Request.Cookies["IsLogin"].ToString() == "0"))
                    {
                        HttpCookie c = new HttpCookie("IsLogin", "1");
                        c.Expires = new DateTime(2050, 12, 1);
                        Response.Cookies.Add(c);
                    }
                    Session["MemberName"] = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
                    Session["UserID"] = UserID.ToString();
                    Session["IsLogin"] = "1";
                    string Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();

                    string Message = ContentManager.GetStaticeContentEmail("Registration.htm").Replace("~", "#");
                    Message = Message.Replace("<!-- Name -->", Name);

                    MailMessage mail = null;

                    SmtpClient client = null;

                    try
                    {
                        Global ObjSubjec = new Global();

                        DataSet ds_Subject = ObjSubjec.GetEmailSubject("Registration.htm");

                        string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                        string smtpPort = ConfigurationManager.AppSettings["SmtpPort"].ToString();

                        mail = new MailMessage();

                        mail.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
                        mail.To.Add(new MailAddress(txtEmailReg.Text.Trim()));
                        mail.Subject = ds_Subject.Tables[0].Rows[0]["Subject"].ToString(); // "Welcome to Fritzy's";
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.High;

                        string message = Message;
                        mail.Body = message;

                        client = new SmtpClient();

                        client.Host = smtpHost;

                        client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;

                        client.Send(mail);
                    }
                    catch
                    {
                    }
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    lblCaptchaError.Visible = true;
                    lblCaptchaError.Text = "We’re sorry, this username already exists.";
                }
            }
        }


        /* this event reset the al field of page */
        protected void IdReset_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }


        /* 
         *  This function use tocheck the user type as per user pet selection 
            1 - Cat intreated user
         *  2 - Dog intreated user
         *  3 - CatandDog intreated user
         */
        public int CheckStatus()
        {
            int c = 0;
            int d = 0;
            if ((p1.Visible == true) && (ViewState["RowID"].ToString() != "0"))
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
        #endregion

        #region Dropdown event

        /* This region include all pet type selected index change event */
        protected void ddlPetType1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed1(ddlPetType1.SelectedValue);
        }
        protected void ddlPetType2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed2(ddlPetType2.SelectedValue);
        }
        protected void ddlPetType3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed3(ddlPetType3.SelectedValue);
        }
        protected void ddlPetType4_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed4(ddlPetType4.SelectedValue);
        }
        protected void ddlPetType5_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed5(ddlPetType5.SelectedValue);
        }
        protected void ddlPetType6_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetBreed6(ddlPetType6.SelectedValue);
        }
        #endregion

    }
}