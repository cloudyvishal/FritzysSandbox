using BCL.Admin.StoreFrontMgr;

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
    public partial class EditPet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
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

        public void BindData()
        {
            try
            {
                Global ObjGlobal = new Global();

                DataSet ds = new DataSet();

                ds = ObjGlobal.getPetInfo(int.Parse(Request.QueryString["PetID"].ToString()));

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        BindBreed(ds.Tables[0].Rows[0]["PetType"].ToString());

                        BindStyle();

                        ddlPetType1.SelectedValue = ds.Tables[0].Rows[0]["PetType"].ToString();

                        txtPetName.Text = ds.Tables[0].Rows[0]["PetName"].ToString();

                        ddlBreed.SelectedValue = ds.Tables[0].Rows[0]["BreedID"].ToString();

                        txtPetDOB.Text = ds.Tables[0].Rows[0]["Years"].ToString();

                        txtPetWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();

                        txtPetLength.Text = ds.Tables[0].Rows[0]["Length"].ToString();

                        if (ds.Tables[0].Rows[0]["Length"].ToString() == "1")
                            chkSpa1.Checked = true;

                        ddlStyle1.SelectedValue = ds.Tables[0].Rows[0]["StyleID"].ToString();

                        txtAddServicesID1.Text = ds.Tables[0].Rows[0]["AdditionalService"].ToString();

                        txtAddServices1.Text = GetAdditionalServices(ds.Tables[0].Rows[0]["AdditionalService"].ToString());
                    }
                    else
                    {

                    }
                }
            } finally{}
        }

        public void BindBreed(string Id)
        {
            try
            {
                StoreFrontUser ObjReg = new StoreFrontUser();

                DataSet ds = new DataSet();

                ds = ObjReg.GetBreedFront(Id);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ListItem lst1 = new ListItem();

                        lst1.Value = "0"; lst1.Text = "Select One";

                        ddlBreed.DataTextField = "BreedName";

                        ddlBreed.DataValueField = "BreedID";

                        ddlBreed.DataSource = ds.Tables[0];

                        ddlBreed.DataBind();

                        ddlBreed.Items.Insert(0, lst1);
                    }
                }
            } finally{}
        }

        public void BindStyle()
        {
            try
            {
                StoreFrontUser ObjReg = new StoreFrontUser();

                DataSet ds = new DataSet();

                ds = ObjReg.GetStyleFront();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ListItem lst1 = new ListItem();

                        lst1.Value = "0"; lst1.Text = "Select One";

                        ddlStyle1.DataTextField = "StyleName";

                        ddlStyle1.DataValueField = "StyleID";

                        ddlStyle1.DataSource = ds.Tables[0];

                        ddlStyle1.DataBind();

                        ddlStyle1.Items.Insert(0, lst1);
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {

                        lstAddservices1.DataTextField = "ServiceName";

                        lstAddservices1.DataValueField = "AdditionalServiceID";

                        lstAddservices1.DataSource = ds.Tables[1];

                        lstAddservices1.DataBind();
                    }
                }
            } finally{}
        }

        public string GetAdditionalServices(string Ids)
        {
            string str = string.Empty;

            try
            {
                StoreFrontUser ObjReg = new StoreFrontUser();

                DataSet ds = new DataSet();

                ds = ObjReg.GetStyleFront();

                DataTable dt_AdditionalServices = ds.Tables[1];

                string[] temp = Ids.Split(',');

                for (int i = 0; i < temp.Length; i++)
                {
                    for (int j = 0; j < dt_AdditionalServices.Rows.Count; j++)
                    {
                        if (dt_AdditionalServices.Rows[j]["AdditionalServiceID"].ToString() == temp[i])
                        {
                            if (str == "")
                            {
                                str = dt_AdditionalServices.Rows[j]["ServiceName"].ToString();
                            }
                            else
                            {
                                str = str + "," + dt_AdditionalServices.Rows[j]["ServiceName"].ToString();
                            }
                        }
                    }
                }
                ds.Dispose();
            } finally{}
            if (str == "")
                return "Select Service";
            else
                return str;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUsers.aspx?ID=" + Request.QueryString["ID"].ToString() + "&p=" + Request.QueryString["p"].ToString());
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int Spa = 0;

                if (chkSpa1.Checked == true)
                {
                    Spa = 1;
                }

                Global ObjGlobal = new Global();

                ObjGlobal.UpdatePetAdmin(int.Parse(Request.QueryString["PetID"].ToString()), Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName.Text.Trim(), Convert.ToInt32(ddlBreed.SelectedValue), Convert.ToInt32(txtPetDOB.Text.Trim()), Convert.ToDecimal(txtPetWeight.Text.Trim()), Convert.ToDecimal(txtPetLength.Text.Trim()), Spa, Convert.ToInt32(ddlStyle1.SelectedValue), txtAddServicesID1.Text.Trim());
                
                SuccessMessage("Pet updated successfully");
            } finally{}
        }

        protected void ddlPetType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindBreed(ddlPetType1.SelectedValue);
            } finally{}
        }
    }
}