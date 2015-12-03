using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Utility.CommonMethods;
using BCL.Utility.GlobalFunctions;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class UserAccess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            Global objGlobal = null;

            DataSet ds = null;

            try
            {
                objGlobal = new Global();

                ds = new DataSet();

                ds = objGlobal.GetAllUserType();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdAccess.DataSource = ds.Tables[0];

                    grdAccess.DataBind();

                    btnDelete.Visible = true;

                    btnStatus.Visible = true;

                    CheckAll();

                    check();

                    CommonFunctions.Setserial(grdAccess, "srno");

                    grdAccess.Visible = true;
                }
                else
                {
                    btnDelete.Visible = false;

                    btnStatus.Visible = false;

                    grdAccess.Visible = false;

                    lblError.Text = "No record found";
                }
            }
            finally
            {
                objGlobal = null;

                ds.Dispose();
            }
        }

        public void CheckAll()
        {
            CheckBox chkall;
            chkall = (CheckBox)grdAccess.HeaderRow.FindControl("chkall");
            chkall.Attributes.Add("onclick", "checkall()");
            string str;
            str = "function checkall()";
            str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
            str = str + "{";
            foreach (GridViewRow gvr in grdAccess.Rows)
            {
                CheckBox checkall;
                checkall = (CheckBox)gvr.FindControl("chkSelect");
                str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
            }
            str = str + "}";
            str = str + "else";
            str = str + "{";
            foreach (GridViewRow grv in grdAccess.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                str = str + "document.getElementById('" + chk1.ClientID + "').checked=false;";
            }
            str = str + "}}";
            Page.ClientScript.RegisterStartupScript(GetType(), "sss", str, true);
        }

        protected void check()
        {
            string checkid = "";
            checkid += "function val(id){";
            checkid += "var flg=0;";

            foreach (GridViewRow grv in grdAccess.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
                checkid += "flg=1;}";
            }
            checkid += "if(flg!=1){";
            checkid += "alert('Select Atleast One User Access ');return false;}";
            checkid += "if(flg==1 && id==1){";
            checkid += "if(!confirm('Do You Want To Delete Selected User Access(s) ?')){return false;}}";
            checkid += "if(flg==1 && id==2){";
            checkid += "if(!confirm('Do You Want To Change Status of User Type(s) ?')){return false;}}";
            checkid = checkid + "}";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

            btnDelete.Attributes.Add("onclick", "return val(1);");

            btnStatus.Attributes.Add("onclick", "return val(2);");
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

        protected void ImgSubmitService_Click(object sender, EventArgs e)
        {
            Global ObjAccess = null;

            try
            {
                ObjAccess = new Global();

                int count = ObjAccess.AddUserAccess(Convert.ToInt32(ddlUserType.SelectedValue), ddlModule.SelectedValue, ddlModule.SelectedItem.Text);

                if (count == 0)
                {
                    ErrorMessage("Duplicate entry");
                }
                else
                {
                    SuccessMessage("Access added successfully");
                }

                BindData();
            }
            finally
            {
                ObjAccess = null;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Global ObjGlo = null;

            try
            {
                string AccessID = CommonFunctions.GetCheckedRow(grdAccess, "chkSelect");

                if (AccessID != "")
                {
                    ObjGlo = new Global();

                    ObjGlo.DeleteUserAccess(AccessID);

                    BindData();
                }
            }
            finally
            {
                ObjGlo = null;
            }
        }

        protected void btnStatus_Click(object sender, EventArgs e)
        {
            Global ObjGlo = null;

            try
            {
                string AccessID = CommonFunctions.GetCheckedRow(grdAccess, "chkSelect");

                if (AccessID != "")
                {
                    ObjGlo = new Global();

                    if (ddlUserType.SelectedValue == "User Type")
                    {
                        ErrorMessage("Please select User Type");
                    }
                    else
                    {
                        SuccessMessage("User Access Updated");

                        int userType = Convert.ToInt32(ddlUserType.SelectedValue);

                        ObjGlo.ChangeUserAccess(AccessID, userType);
                    }

                    BindData();
                }
            }
            finally
            {
                ObjGlo = null;
            }
        }

        protected void grdAccess_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAccess.PageIndex = e.NewPageIndex;

            BindData();
        }
    }
}