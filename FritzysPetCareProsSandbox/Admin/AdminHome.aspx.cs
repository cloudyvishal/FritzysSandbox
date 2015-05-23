using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


using BCL.Utility.GlobalFunctions;
using BCL.Utility.CommonMethods;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lblDate.Text = DateTime.Now.Date.ToString("dd MMM yyyy");

                    BindData();

                    BindUsers();

                    BindContactUS();

                    BindAppointment();
                }
                finally
                { }
            }
        }

        public void BindData()
        {
            Global ObjSuggest = null;

            DataSet ds = null;

            DataTable dt = null;

            DataView dv = null;

            try
            {
                ObjSuggest = new Global();

                ds = new DataSet();

                dt = new DataTable();

                dv = new DataView();

                ds = ObjSuggest.GetTopSuggestion();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrdSuggestion.Visible = true;

                    dt = ds.Tables[0];

                    dv = dt.DefaultView;

                    if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                    {
                        dv.Sort = SortExpression + " " + SortDirection;
                    }

                    GrdSuggestion.DataSource = dv;
                    
                    GrdSuggestion.DataBind();

                    CommonFunctions.Setserial(GrdSuggestion, "srno");
                    
                    lblNorec.Visible = false;
                   
                    lnkSuggestion.Visible = true;
                }
                else
                {
                    lnkSuggestion.Visible = false;

                    lblNorec.Visible = true;

                    GrdSuggestion.Visible = false;
                }
            } finally{}
        }

        public void BindUsers()
        {
            Global ObjUser = null;

            DataSet ds = null;

            DataTable dt = null;

            DataView dv = null;

            try
            {
                ObjUser = new Global();
               
                ds = new DataSet();
                
                dt = new DataTable();
                
                dv = new DataView();
                
                ds = ObjUser.GetTopUserFront();
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrdUsers.Visible = true;
                    
                    dt = ds.Tables[0];
                    
                    dv = dt.DefaultView;
                    
                    if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                        dv.Sort = SortExpression + " " + SortDirection;

                    GrdUsers.DataSource = dv;
                    
                    GrdUsers.DataBind();

                    CommonFunctions.Setserial(GrdUsers, "srno");
                    
                    lblNoUser.Visible = false;
                    
                    lnkUser.Visible = true;
                }
                else
                {
                    lblNoUser.Visible = true;
                    GrdUsers.Visible = false;
                    lnkUser.Visible = false;
                }
            } finally{}
        }

        public void BindContactUS()
        {
            try
            {
                Global ObjContactUS = new Global();

                DataSet ds = new DataSet();

                ds = ObjContactUS.GetTopContactUS();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdContactUs.Visible = true;

                        grdContactUs.DataSource = ds.Tables[0];

                        grdContactUs.DataBind();

                        CommonFunctions.Setserial(grdContactUs, "srnoContact");

                        lblNoContactus.Visible = false;

                        hypContactUS.Visible = true;
                    }
                    else
                    {
                        lblNoContactus.Visible = true;

                        grdContactUs.Visible = false;

                        hypContactUS.Visible = false;
                    }
                }
            } finally{}
        }

        private void BindAppointment()
        {
            try
            {
                Global ObjAppointment = new Global();

                DataSet ds = new DataSet();

                ds = ObjAppointment.GetTopAppointment();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdAppointment.Visible = true;

                        grdAppointment.DataSource = ds.Tables[0];

                        grdAppointment.DataBind();

                        CommonFunctions.Setserial(grdAppointment, "srnoAppointment");

                        lblNoAppointment.Visible = false;
                    }
                    else
                    {
                        lblNoAppointment.Visible = true;

                        grdAppointment.Visible = false;
                    }
                }
            } finally{}
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
    }
}