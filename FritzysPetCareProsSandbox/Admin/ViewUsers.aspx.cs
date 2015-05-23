using BCL.Admin.StoreFrontMgr;

using BCL.Utility.CommonMethods;
using BCL.Utility.GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (!IsPostBack)
            {
                BindState();

                GetReferal();

                BindData();

                string PageName = Request.Url.AbsolutePath;

                getAppData();
            }
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

        /* Code to manage view state for sortExpression */
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
        /* Code to manage view state for sortdirection*/
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

        public void BindData()
        {
            try
            {
                Global ObjUser = new Global();

                DataSet ds = new DataSet();

                DataTable dt = new DataTable();

                DataView dv = new DataView();

                ds = ObjUser.GetUserInfo(Convert.ToInt32(Request.QueryString["ID"].ToString()));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();

                    lblAddress.Text = ds.Tables[0].Rows[0]["Street"].ToString() + " " + ds.Tables[0].Rows[0]["City"].ToString() + " " + ds.Tables[0].Rows[0]["State"].ToString() + " " + ds.Tables[0].Rows[0]["Zip"].ToString();

                    lblPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

                    lblMobile.Text = ds.Tables[0].Rows[0]["AltMobile"].ToString();

                    lblReferralSource.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();

                    lblAlternate.Text = ds.Tables[0].Rows[0]["ReferalName"].ToString();

                    lblAlternateAddress.Text = ds.Tables[0].Rows[0]["AltStreet"].ToString() + " " + ds.Tables[0].Rows[0]["AltCity"].ToString() + " " + ds.Tables[0].Rows[0]["AltState"].ToString() + " " + ds.Tables[0].Rows[0]["AltZip"].ToString();

                    lblAlternatePhone.Text = ds.Tables[0].Rows[0]["AltPhone"].ToString();

                    lblPreferredGroomer.Text = ds.Tables[0].Rows[0]["PreferredGroomer"].ToString();

                    lblEmail.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();

                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();

                    txtStreet.Text = ds.Tables[0].Rows[0]["Street"].ToString();

                    txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();

                    if (ds.Tables[0].Rows[0]["State"].ToString() != "0")
                        ddlState.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
                    else
                    {
                        ListItem lst = new ListItem();

                        lst.Selected = true; lst.Value = "0"; lst.Text = "State";

                        ddlState.Items.Insert(0, lst);
                    }

                    txtZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();

                    txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

                    txtAltMobile.Text = ds.Tables[0].Rows[0]["AltMobile"].ToString();

                    txtAltContact.Text = ds.Tables[0].Rows[0]["AltContact"].ToString();

                    txtAltStreet.Text = ds.Tables[0].Rows[0]["AltStreet"].ToString();

                    txtAltCity.Text = ds.Tables[0].Rows[0]["AltCity"].ToString();

                    if (ds.Tables[0].Rows[0]["AltState"].ToString() != "0")
                        ddlState1.SelectedValue = ds.Tables[0].Rows[0]["AltState"].ToString();
                    else
                    {
                        ListItem lst = new ListItem();

                        lst.Selected = true; lst.Value = "0"; lst.Text = "State";

                        ddlState1.Items.Insert(0, lst);
                    }
                    txtAltZip.Text = ds.Tables[0].Rows[0]["AltZip"].ToString();

                    txtAltPhone.Text = ds.Tables[0].Rows[0]["AltPhone"].ToString();

                    if (ds.Tables[0].Rows[0]["ReferralID"].ToString() != "")
                        ddlReferralSource.SelectedValue = ds.Tables[0].Rows[0]["ReferralID"].ToString();
                    else
                    {
                        ListItem lst = new ListItem();

                        lst.Value = "0"; lst.Text = "Select One";

                        ddlReferralSource.Items.Insert(0, lst);
                    }

                    txtEmailReg.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

                    txtPasswordReg.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    grdPet.DataSource = ds.Tables[1];

                    grdPet.DataBind();

                    grdPet.Visible = false;

                    NoPetDiv.Attributes.Add("style", "display:none");

                    lblNoPet.Visible = false;

                    dlPet.DataSource = ds.Tables[1];

                    dlPet.DataBind();
                }
                else
                {
                    grdPet.Visible = false;

                    NoPetDiv.Attributes.Add("style", "display:block");

                    lblNoPet.Visible = true;

                    lblNoPet.Text = "No record found";
                }
            } finally{}
        }

        public void BindState()
        {
            try
            {
                Global ObjState = new Global();

                DataSet ds = new DataSet();

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
            } finally{}
        }

        public void GetReferal()
        {
            try
            {
                StoreFrontUser ObjRef = new StoreFrontUser();
                DataSet ds1 = new DataSet();
                ds1 = ObjRef.GetReferalSourceFront();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    //ListItem lst = new ListItem();
                    //lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";

                    ddlReferralSource.DataTextField = "ReferalName";
                    ddlReferralSource.DataValueField = "ReferalID";
                    ddlReferralSource.DataSource = ds1.Tables[0];
                    ddlReferralSource.DataBind();
                }
            } finally{}
        }

        public void getAppData()
        {
            try
            {
                Global ObjUser = new Global();

                DataSet ds = new DataSet();

                DataTable dt = new DataTable();

                DataView dv = new DataView();

                ds = ObjUser.GetUserInfo(Convert.ToInt32(Request.QueryString["ID"].ToString()));

                if (ds.Tables[2].Rows.Count > 0)
                {
                    grdAppointment.Visible = true;

                    dt = ds.Tables[2];

                    dv = dt.DefaultView;

                    if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                        dv.Sort = SortExpression + " " + SortDirection;

                    grdAppointment.DataSource = dv;

                    grdAppointment.DataBind();

                    NoAppintmentDiv.Attributes.Add("style", "display:none");

                    lblNoAppintment.Visible = false;

                    CommonFunctions.Setserial(grdAppointment, "srno");
                }
                else
                {
                    grdAppointment.Visible = false;

                    NoAppintmentDiv.Attributes.Add("style", "display:block");

                    lblNoAppintment.Visible = true;

                    lblNoAppintment.Text = "No record found";
                }
            } finally{}
        }

        protected void grdAppointment_Sorting(object sender, GridViewSortEventArgs e)
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
            grdAppointment.PageIndex = 0;

            getAppData();
        }

        protected void grdAppointment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAppointment.PageIndex = e.NewPageIndex;

            getAppData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["p"].ToString() == "0")
            {
                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                Response.Redirect("Users.aspx?SearchFor=0&SearchText=");
            }
        }

        protected void dlPet_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType != ListItemType.Header) && (e.Item.ItemType != ListItemType.Footer))
                {
                    Global ObjGlobal = new Global();
                    DataSet ds = new DataSet();
                    DataTable dt_AdditionalServices = new DataTable();
                    ds = ObjGlobal.GetAllAdditionalServicesAdmin();
                    dt_AdditionalServices = ds.Tables[0];
                    Label lblAdditionalServices = (Label)e.Item.FindControl("lblAdditionalServices");
                    string[] temp = lblAdditionalServices.Text.Split(',');
                    string str = string.Empty;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        for (int j = 0; j < dt_AdditionalServices.Rows.Count; j++)
                        {
                            if (dt_AdditionalServices.Rows[j]["AdditionalServiceID"].ToString() == temp[i])
                            {
                                if (str == "")
                                    str = dt_AdditionalServices.Rows[j]["ServiceName"].ToString();
                                else
                                    str = str + "," + dt_AdditionalServices.Rows[j]["ServiceName"].ToString();
                            }
                        }
                    }

                    if (str == "")
                        lblAdditionalServices.Text = "No additional services";
                    else
                        lblAdditionalServices.Text = str;
                    ds.Dispose();
                    dt_AdditionalServices.Dispose();
                }
            } finally{}
        }

        protected void dlPet_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    Global ObjDelete = new Global();

                    ObjDelete.DeleteUserPet(int.Parse(e.CommandArgument.ToString()));

                    BindData();
                }
            } finally{}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                StoreFrontUser ObjStore = new StoreFrontUser();
                int Count = ObjStore.UpdateMember(int.Parse(Request.QueryString["Id"].ToString()), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtStreet.Text.Trim(), txtCity.Text.Trim(), ddlState.SelectedItem.Text, txtZip.Text.Trim(), txtPhone.Text.Trim(), txtAltMobile.Text.Trim(), txtAltContact.Text.Trim(), txtAltStreet.Text.Trim(), txtCity.Text.Trim(), ddlState1.SelectedItem.Text, txtAltZip.Text.Trim(), txtAltPhone.Text.Trim(), int.Parse(ddlReferralSource.SelectedValue), txtGroomer.Text.Trim(), txtEmailReg.Text.Trim(), txtPasswordReg.Text.Trim());
                if (Count == 0)
                {
                    ErrorMessage("Sorry this mail Id already exists.");
                }
                else
                {
                    SuccessMessage("User information updated successfully.");
                }
            } finally{}
        }
    }
}