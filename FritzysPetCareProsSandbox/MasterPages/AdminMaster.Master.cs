using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Utility.GlobalFunctions;

namespace FritzysPetCareProsSandbox.MasterPages
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUserName"] == null)
            {
                Response.Redirect(Session["AdminPath"] + "default.aspx");
            }
            if (Session["UserID"] == null)
            {
                Response.Redirect(Session["AdminPath"] + "default.aspx");
            }
            if (Session["AdminUserName"].ToString() == "")
            {
                Response.Redirect(Session["AdminPath"] + "default.aspx");
            }
            if (Session["UserID"].ToString() == "")
            {
                Response.Redirect(Session["AdminPath"] + "default.aspx");
            }

            if (!IsPostBack)
            {
                lnkAdminHome.NavigateUrl = Session["AdminPath"] + "AdminHome.aspx";

                lnkManageUser.NavigateUrl = Session["AdminPath"] + "ManageUser.aspx?SearchFor=0&SearchText=";

                lnkFriends.NavigateUrl = Session["AdminPath"] + "ManageFriends.aspx?SearchFor=0&SearchText=";

                lnkNews.NavigateUrl = Session["AdminPAth"] + "ManageNews.aspx?SearchFor=0&SearchText=";

                lnkServices.NavigateUrl = Session["AdminPath"] + "ManageServices.aspx?SearchFor=0&SearchText=";

                lnkManageMembers.NavigateUrl = Session["AdminPath"] + "Users.aspx?SearchFor=0&SearchText=";

                lnkManageAppointment.NavigateUrl = Session["AdminPath"] + "Appointment.aspx?SearchFor=0&SearchText=";

                lnkContactus.NavigateUrl = Session["AdminPath"] + "ContactUs.aspx?SearchFor=0&SearchText=";

                lnkSuggestion.NavigateUrl = Session["AdminPath"] + "Suggestion.aspx?SearchFor=0&SearchText=";

                lnkVisitorVan.NavigateUrl = Session["AdminPath"] + "VisitVan.aspx";

                lnkZipCode.NavigateUrl = Session["AdminPath"] + "ManageLocations.aspx?SearchFor=0&SearchText=";

                lnkLogout.NavigateUrl = Session["AdminPath"] + "Logout.aspx";

                lnkAdditionalService.NavigateUrl = Session["AdminPath"] + "ManageAdditionalService.aspx?SearchFor=0&SearchText=";

                lnkManageBreed.NavigateUrl = Session["AdminPath"] + "ManageBreed.aspx?SearchFor=0&SearchText=";

                lnkManageStyle.NavigateUrl = Session["AdminPath"] + "ManageStyle.aspx?SearchFor=0&SearchText=";

                lnkReferalSource.NavigateUrl = Session["AdminPath"] + "ManageReferalSource.aspx?SearchFor=0&SearchText=";

                lnkPassword.NavigateUrl = Session["AdminPath"] + "ChangePassword.aspx";

                lnkAccountSetting.NavigateUrl = Session["AdminPath"] + "ChangePassword.aspx";

                lnkMeta.NavigateUrl = Session["AdminPath"] + "MetaTags.aspx?PageID=1&SearchFor=0&SearchText=";

                lblUsername.Text = Session["AdminUserName"].ToString();

                lnkProducts.NavigateUrl = Session["AdminPath"] + "ManageProducts.aspx?SearchFor=0&SearchText=";

                lnkStaticeContent.NavigateUrl = Session["AdminPath"] + "StaticWebPages.aspx";

                lnkImageManager.NavigateUrl = Session["AdminPath"] + "ImageManager.aspx";

                lnkManageHomePageService.NavigateUrl = Session["AdminPath"] + "ManageHomePageService.aspx";

                lnkManageFTService.NavigateUrl = Session["AdminPath"] + "ManageFleaTickService.aspx";

                lnkEmail.NavigateUrl = Session["AdminPath"] + "ManageEmail.aspx";

                lnkBackup.NavigateUrl = Session["AdminPath"] + "SiteBackup.aspx";

                lnkManageGroomer.NavigateUrl = Session["AdminPath"] + "ManageGroomer.aspx?SearchFor=0&SearchText=";

                lnkEditExcel.NavigateUrl = Session["AdminPath"] + "EditExcel.aspx";

                lnkGroomerAppointment.NavigateUrl = Session["AdminPath"] + "ViewGroomerAppointment.aspx?SearchFor=0&SearchText=";

                lnkUploadDnloadExl.NavigateUrl = Session["AdminPath"] + "UploadDnloadExcel.aspx";

                lnkUploadgroomerapt.NavigateUrl = Session["AdminPath"] + "UploadGroomerAppointments.aspx";

                lnkAppointment.NavigateUrl = Session["AdminPath"] + "AppointmentSettings.aspx";

                lnkAppointmentDate.NavigateUrl = Session["AdminPath"] + "AppointmentDateSetting.aspx";

                HypUploadBanner.NavigateUrl = Session["AdminPath"] + "UploadBanners.aspx";

                HypBanner.NavigateUrl = Session["AdminPath"] + "ManageBaners.aspx";

                lnkManageAgents.NavigateUrl = Session["AdminPath"] + "ManageAgents.aspx?SearchFor=0&SearchText=";

                lnkManageManger.NavigateUrl = Session["AdminPath"] + "ManageManager.aspx?SearchFor=0&SearchText=";

                lnkUserAccess.NavigateUrl = Session["AdminPath"] + "UserAccess.aspx";

                lnkUploadFailedAppointment.NavigateUrl = Session["AdminPath"] + "UploadFailedAppointments.aspx";

                AccessNew();
            }
        }

        private void AccessNew()
        {
            string currentpage = Request.Url.PathAndQuery.ToString().ToLower();

            Global get_pages = new Global();

            DataSet pageDs = get_pages.GetPageName(Convert.ToInt32(Session["AdminUserType"].ToString()));

            for (int i = 0; i < pageDs.Tables[0].Rows.Count; i++)
            {
                string pagename = pageDs.Tables[0].Rows[i]["PageName"].ToString().ToLower();

                if (currentpage.IndexOf(pagename) > -1)
                {
                    Response.Redirect("~/Admin/NotAllow.aspx");
                }
            }
        }
    }
}