using System;
using System.Xml;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Admin.BannerMgr;

using BCL.Utility.Contents;
using BCL.Custom.BannerOrderMgr;
using System.Configuration;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ManageBaners : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                BindSequenceData();

                SetBannersInXML();
            }
        }

        #region "Declare Variables"

        PagedDataSource pgds = new PagedDataSource();

        PagedDataSource pgdsbannerlist = new PagedDataSource();

        DataSet ds = new DataSet();

        int cnt = 0;

        int PageId = 0;

        int UserID = 0;

        #endregion

        #region "Manage orders"

        private void BindSequenceData()
        {
            try
            {
                BannerOrder objOrder = new BannerOrder();

                DataSet dsOrder = new DataSet();

                PageId = Convert.ToInt32(ddlPage.SelectedValue);

                UserID = Convert.ToInt32(ddlUserType.SelectedValue);

                cnt = 0;

                dsOrder = objOrder.GetBannerList(PageId, UserID);

                if (dsOrder.Tables.Count > 0)
                {
                    pgds.AllowPaging = true;

                    pgds.PageSize = 1000000;

                    pgds.DataSource = dsOrder.Tables[0].DefaultView;

                    dtlOrder.Visible = true;

                    dtlOrder.DataSource = pgds;

                    dtlOrder.DataBind();
                }
            }
            finally { }
        }

        #endregion

        #region "Functions"

        protected void BindData()
        {
            try
            {
                DataTable myDt = new DataTable();

                myDt = CreateDataTable();

                if (myDt.Rows.Count > 0)
                {

                    ViewState["myDt"] = myDt;


                    divError.Visible = false;

                    pgdsbannerlist.AllowPaging = true;

                    pgdsbannerlist.PageSize = 1000;

                    pgdsbannerlist.DataSource = myDt.DefaultView;

                    dtBannerlIst.Visible = true;

                    dtBannerlIst.DataSource = pgdsbannerlist;

                    dtBannerlIst.DataBind();

                }
                else
                {
                    ErrMessage("No banner found");
                }
            }
            finally { }
        }

        private DataTable CreateDataTable()
        {
            try
            {
                DataTable myDataTable = new DataTable();

                DataColumn myDataColumn;

                myDataColumn = new DataColumn();

                myDataColumn.DataType = Type.GetType("System.String");

                myDataColumn.ColumnName = "BannerId";

                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();

                myDataColumn.DataType = Type.GetType("System.String");

                myDataColumn.ColumnName = "virtualmobilepath";

                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();

                myDataColumn.DataType = Type.GetType("System.String");

                myDataColumn.ColumnName = "BannerName";

                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();

                myDataColumn.DataType = Type.GetType("System.String");

                myDataColumn.ColumnName = "BannerPath";

                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();

                myDataColumn.DataType = Type.GetType("System.String");

                myDataColumn.ColumnName = "UsedForms";

                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();

                myDataColumn.DataType = Type.GetType("System.String");

                myDataColumn.ColumnName = "BId";

                myDataTable.Columns.Add(myDataColumn);

                FillDataTableWithRequiredData(myDataTable);

                return myDataTable;
            }
            finally { }
        }

        private void FillDataTableWithRequiredData(DataTable myDataTable)
        {
            try
            {
                DataSet ds = new DataSet();

                DataSet dsDefault = new DataSet();

                Banners objB = new Banners();

                ds = objB.GetBannerList();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int BannerId = 0;

                        int BId = 0;

                        string BannerName = "";

                        string BannerPath = "";

                        string UsedForms = "";

                        string virtualmobilepath = "";

                        BId = Convert.ToInt32(ds.Tables[0].Rows[i]["BId"]);

                        BannerId = Convert.ToInt32(ds.Tables[0].Rows[i]["BannerId"]);

                        BannerName = Convert.ToString(ds.Tables[0].Rows[i]["BannerName"]);

                        BannerPath = Convert.ToString(ds.Tables[0].Rows[i]["BannerPath"]);

                        virtualmobilepath = Convert.ToString(ds.Tables[0].Rows[i]["virtualmobilepath"]);

                        //Find Set Banner
                        DataSet ds1 = new DataSet();

                        ds1 = objB.CheckUsedBannerList(BannerId);

                        string FormNameList = "";

                        if (ds1.Tables[0].Rows.Count > 0)
                        {

                            for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
                            {
                                string pgNm = "";

                                pgNm = Convert.ToString(ds1.Tables[0].Rows[k]["pageName"]);

                                FormNameList = FormNameList + ", " + pgNm;

                            }
                            FormNameList = FormNameList.Remove(0, 1);
                        }

                        DataSet ds2 = new DataSet();

                        ds2 = objB.CheckUsedDefaultBanner(BannerId);

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                            {
                                FormNameList = FormNameList + ", Default-" + Convert.ToString(ds2.Tables[0].Rows[j]["pageName"]);
                            }
                        }

                        if (FormNameList.Length == 0) FormNameList = "NOT IN USE";

                        UsedForms = FormNameList;

                        AddDataToTable(Convert.ToString(BannerId), BannerName, BannerPath, UsedForms, myDataTable, Convert.ToString(BId), virtualmobilepath);
                    }
                }
            }
            finally { }
        }

        private void AddDataToTable(string BannerId, string BannerName, string BannerPath, string UsedForms, DataTable myTable, string BId, string virtualmobilepath)
        {
            try
            {
                DataRow row;

                row = myTable.NewRow();

                row["BId"] = BId;

                row["BannerId"] = BannerId;

                row["BannerName"] = BannerName;

                row["BannerPath"] = BannerPath;

                row["UsedForms"] = UsedForms;

                row["virtualmobilepath"] = virtualmobilepath;

                myTable.Rows.Add(row);
            }
            finally { }
        }

        #endregion

        #region "Error Message"

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

        #endregion

        #region "Dropdown Events"

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSequenceData();

            SetBannersInXML();
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSequenceData();

            SetBannersInXML();
        }
        #endregion

        #region "Save Button"

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SetBannersInXML();
        }

        #endregion

        #region "XML Functions"

        private void SetBannersInXML()
        {
            try
            {
                Banners objB = new Banners();

                BannerOrder objBannerOrder = new BannerOrder();

                PageId = Convert.ToInt32(ddlPage.SelectedValue);

                UserID = Convert.ToInt32(ddlUserType.SelectedValue);

                string PageName = string.Empty;

                string virtualpath2 = string.Empty;

                string virtualmobilepath = string.Empty;

                string ImageName2 = string.Empty;

                string BannerId = string.Empty;

                string PgName = string.Empty;

                string IsCoupon = string.Empty;

                int boolIscoupon = 0;

                string strPgName = GetPageNameForSequence(Convert.ToString(PageId), Convert.ToString(UserID));

                DeleteFromXml(strPgName, PageId, UserID);

                DataTable OrderDt = (DataTable)ViewState["myDt"];

                foreach (DataListItem item in dtlOrder.Items)
                {
                    TextBox myTextBox = (TextBox)item.FindControl("txtId");

                    Label lblPageName = (Label)item.FindControl("lblPageName");

                    Label lblIsCoupon = (Label)item.FindControl("lblIsCoupon");

                    Label lblId = (Label)item.FindControl("lblId");

                    CheckBox chkIsCOupon = (CheckBox)item.FindControl("chkIsCOupon");

                    if (chkIsCOupon.Checked)
                    {
                        boolIscoupon = 1;
                    }
                    else
                    {
                        boolIscoupon = 0;
                    }

                    BannerId = myTextBox.Text;

                    PgName = strPgName;

                    IsCoupon = lblIsCoupon.Text;

                    int Id = Convert.ToInt32(lblId.Text);

                    if (BannerId != "")
                    {
                        for (int i = 0; i < OrderDt.Rows.Count; i++)
                        {
                            DataRow row = OrderDt.Rows[i];
                            if (BannerId == Convert.ToString(row["BId"]))
                            {
                                virtualpath2 = Convert.ToString(row["BannerPath"]);

                                ImageName2 = Convert.ToString(row["BannerName"]);

                                virtualmobilepath = Convert.ToString(row["virtualmobilepath"]);

                                objBannerOrder.UpdateBannerSequence(Id, Convert.ToInt32(BannerId), boolIscoupon);

                                if (PageId != 10)
                                {
                                    AddBannerToXml(virtualpath2, ImageName2, IsCoupon, strPgName, Convert.ToString(PageId), Convert.ToString(UserID), virtualmobilepath, BannerId);
                                }
                                break;
                            }
                            else
                            {
                                objBannerOrder.UpdateBannerSequence(Id, 0, 0);
                            }


                        }
                    }
                    else
                    {
                        objBannerOrder.UpdateBannerSequence(Id, 0, 0);
                    }

                }
                DataSet dsDefault = new DataSet();

                int emtCnt = 0;

                int EID = 0;

                DataSet dsPages = new DataSet();

                dsPages = objBannerOrder.GetPagesNames();

                for (int j = 0; j < dsPages.Tables[0].Rows.Count; j++)
                {
                    DataRow PageRow = dsPages.Tables[0].Rows[j];

                    PageId = Convert.ToInt32(PageRow["PageId"]);

                    UserID = Convert.ToInt32(PageRow["UserId"]);

                    strPgName = GetPageNameForSequence(Convert.ToString(PageId), Convert.ToString(UserID));

                    dsDefault = objBannerOrder.GetBannerList(PageId, UserID);

                    if (dsDefault.Tables[1].Rows.Count > 0)
                    {
                        DataRow countRow = dsDefault.Tables[1].Rows[0];

                        if (dsDefault.Tables[4].Rows.Count > 0)
                        {
                            DataRow checkDefRow = dsDefault.Tables[4].Rows[0];

                            if (Convert.ToInt32(checkDefRow["defbannercount"]) == 0)
                            {
                                if (Convert.ToInt32(countRow["bannercount"]) == 0)
                                {
                                    DeleteFromXml(strPgName, PageId, UserID);

                                    objBannerOrder.UpdateBannerSequenceByPage(strPgName);
                                }
                            }
                        }


                        if (Convert.ToString(countRow["bannercount"]) == "0")
                        {
                            DeleteFromXml(strPgName, PageId, UserID);

                            emtCnt = dsDefault.Tables[0].Rows.Count;

                            int Kcount = dsDefault.Tables[2].Rows.Count;

                            for (int k = 0; k < dsDefault.Tables[2].Rows.Count; k++)
                            {
                                DataRow BannerRow = dsDefault.Tables[2].Rows[k];

                                if (emtCnt <= Kcount)
                                {
                                    DataRow emptyRow = dsDefault.Tables[0].Rows[k];

                                    EID = Convert.ToInt32(emptyRow["ID"]);
                                }

                                BannerId = Convert.ToString(BannerRow["BannerId"]);

                                boolIscoupon = Convert.ToInt32(BannerRow["IsCoupon"]);

                                for (int i = 0; i < OrderDt.Rows.Count; i++)
                                {

                                    DataRow defaultRow = OrderDt.Rows[i];

                                    if (BannerId == Convert.ToString(defaultRow["BId"]))
                                    {
                                        virtualpath2 = Convert.ToString(defaultRow["BannerPath"]);

                                        ImageName2 = Convert.ToString(defaultRow["BannerName"]);

                                        objBannerOrder.UpdateBannerSequence(EID, Convert.ToInt32(BannerId), boolIscoupon);

                                        AddBannerToXml(virtualpath2, ImageName2, IsCoupon, strPgName, Convert.ToString(PageId), Convert.ToString(UserID), virtualmobilepath, BannerId);
                                    }

                                }
                            }
                        }
                    }

                }

                BindData();

                BindSequenceData();

            }
            finally { }
        }
        private string GetPageNameForSequence(string PageId, string UserID)
        {
            try
            {
                string strPageName = string.Empty;

                switch (PageId)
                {
                    case "0":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "Home1";
                                break;
                            case "1":
                                strPageName = "Home2";
                                break;
                            case "2":
                                strPageName = "Home3";
                                break;
                            case "3":
                                strPageName = "Home4";
                                break;
                            default: break;
                        }
                        break;
                    case "1":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "Service_Unregister";
                                break;
                            case "1":
                                strPageName = "Services2";
                                break;
                            case "2":
                                strPageName = "Services3";
                                break;
                            case "3":
                                strPageName = "Services4";
                                break;
                            default: break;
                        }
                        break;
                    case "2":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "ServiceDetail1";
                                break;
                            case "1":
                                strPageName = "ServiceDetail2";
                                break;
                            case "2":
                                strPageName = "ServiceDetail3";
                                break;
                            case "3":
                                strPageName = "ServiceDetail4";
                                break;
                            default: break;
                        }
                        break;
                    case "3":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "Product1";
                                break;
                            case "1":
                                strPageName = "Product2";
                                break;
                            case "2":
                                strPageName = "Product3";
                                break;
                            case "3":
                                strPageName = "Product4";
                                break;
                            default: break;
                        }
                        break;
                    case "4":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "Flea1";
                                break;
                            case "1":
                                strPageName = "Flea2";
                                break;
                            case "2":
                                strPageName = "Flea3";
                                break;
                            case "3":
                                strPageName = "Flea4";
                                break;
                            default: break;
                        }
                        break;
                    case "5":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "FritzyFriend1";
                                break;
                            case "1":
                                strPageName = "Friend2";
                                break;
                            case "2":
                                strPageName = "Friend3";
                                break;
                            case "3":
                                strPageName = "Friend4";
                                break;
                            default: break;
                        }
                        break;
                    case "6":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "AboutUs1";
                                break;
                            case "1":
                                strPageName = "AboutUs2";
                                break;
                            case "2":
                                strPageName = "AboutUs3";
                                break;
                            case "3":
                                strPageName = "AboutUs4";
                                break;
                            default: break;
                        }
                        break;
                    case "7":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "ContactUs_Unregister";
                                break;
                            case "1":
                                strPageName = "ContactUs2";
                                break;
                            case "2":
                                strPageName = "ContactUs3";
                                break;
                            case "3":
                                strPageName = "ContactUs4";
                                break;
                            default: break;
                        }
                        break;
                    case "8":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "Registration1";
                                break;
                            case "1":
                                strPageName = "Registration2";
                                break;
                            case "2":
                                strPageName = "Registration3";
                                break;
                            case "3":
                                strPageName = "Registration4";
                                break;
                            default: break;
                        }
                        break;
                    case "9":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "NewsDetail1";
                                break;
                            case "1":
                                strPageName = "NewsDetail2";
                                break;
                            case "2":
                                strPageName = "NewsDetail3";
                                break;
                            case "3":
                                strPageName = "NewsDetail4";
                                break;
                            default: break;
                        }
                        break;
                    case "10":
                        switch (UserID)
                        {
                            case "0":
                                strPageName = "Default1";
                                break;
                            case "1":
                                strPageName = "Default2";
                                break;
                            case "2":
                                strPageName = "Default3";
                                break;
                            case "3":
                                strPageName = "Default4";
                                break;
                            default: break;
                        }
                        break;
                }
                return strPageName;
            }
            finally { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempPath"></param>
        /// <param name="ImageName2"></param>
        /// <param name="ImageCoupon"></param>
        /// <param name="PageName"></param>
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <param name="virtualmobilepath"></param>
        /// <param name="BannerId"></param>
        public void AddBannerToXml(string tempPath, string ImageName2, string ImageCoupon, string PageName, string PageId, string UserId, string virtualmobilepath, string BannerId)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();

                xmldoc.Load(ConfigurationManager.AppSettings["HomePathValue"] + BannerOrder.BannerXml);

                XmlNodeList Node;

                Node = xmldoc.GetElementsByTagName("bannerName");

                XmlElement banners = xmldoc.CreateElement("banners");

                XmlElement banner = xmldoc.CreateElement("banner");

                XmlElement name = xmldoc.CreateElement("name");

                XmlElement body = xmldoc.CreateElement("body");

                XmlElement imagePath = xmldoc.CreateElement("imagePath");

                XmlElement link = xmldoc.CreateElement("link");

                XmlElement PageNames = xmldoc.CreateElement("PageNames");

                XmlElement virtualmobilepath1 = xmldoc.CreateElement("virtualmobilepath1");

                XmlElement BannerId2 = xmldoc.CreateElement("BannerId");

                name.InnerText = "New";

                body.InnerText = "Lorem Ipsum";

                imagePath.InnerText = "../StoreData/BannerNew/" + ImageName2;

                virtualmobilepath1.InnerText = virtualmobilepath;

                BannerId2.InnerText = BannerId;

                link.InnerText = ConfigurationManager.AppSettings["HomePathValue"] + "PrintCoupon1.aspx?CouponID=" + ImageCoupon + "&PageName=" + PageName + "&PageId=" + PageId + "&UserId=" + UserId;

                PageNames.InnerText = PageName;

                banner.AppendChild(name);

                banner.AppendChild(body);

                banner.AppendChild(imagePath);

                banner.AppendChild(link);

                banner.AppendChild(PageNames);

                banner.AppendChild(virtualmobilepath1);

                banner.AppendChild(BannerId2);

                int tempNodeId1 = 0;

                tempNodeId1 = GetPagesNode(Convert.ToInt32(PageId), Convert.ToInt32(UserId));

                XmlNodeList Node1;

                Node1 = xmldoc.GetElementsByTagName("banners");

                Node1.Item(tempNodeId1).AppendChild(banner);   // Important Count

                XmlNodeList Node2;

                Node2 = xmldoc.GetElementsByTagName("bannerName");

                Node2.Item(tempNodeId1).FirstChild.InnerText = Node1.Item(tempNodeId1).ChildNodes.Count.ToString();

                xmldoc.Save(ContentManager.GetPhysicalPath(ConfigurationManager.AppSettings["HomePathValue"] + BannerOrder.BannerXml));
            }
            finally
            { }
        }

        public int GetPagesNode(int pgId, int usId)
        {
            try
            {
                int BannerID = 0;

                Banners ObjBanner = new Banners();

                DataSet ds = ObjBanner.GetPageanduserTypes(pgId, usId);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    BannerID = Convert.ToInt32(ds.Tables[0].Rows[0]["BannerID"].ToString());
                }
                return BannerID;
            }
            finally { }
        }

        public void DeleteFromXml(string PageName, int PageId, int UserId)
        {
            try
            {
                int PId = PageId;

                int UId = UserId;

                XmlDocument xmldoc = new XmlDocument();

                xmldoc.Load(ConfigurationManager.AppSettings["HomePathValue"].ToString() + BannerOrder.BannerXml);

                XmlNodeList Node1;

                Node1 = xmldoc.GetElementsByTagName("banner");

                int Totalcnt = Node1.Count;

                for (int i = 0; i < Node1.Count; i++)
                {
                    XmlElement id = (XmlElement)xmldoc.GetElementsByTagName("banner")[i];

                    if (id.ChildNodes.Item(4).InnerText.ToString() == PageName)
                    {
                        id.ParentNode.RemoveChild(id);
                        i = i - 1;
                    }
                }

                int tempNodeId = 0;

                tempNodeId = GetPagesNode(PId, UId);

                XmlNodeList Node2;

                Node2 = xmldoc.GetElementsByTagName("banners");

                int c = Node2.Item(tempNodeId).ChildNodes.Count;

                XmlNodeList Node3;

                Node3 = xmldoc.GetElementsByTagName("bannerName");

                Node3.Item(tempNodeId).FirstChild.InnerText = Node2.Item(tempNodeId).ChildNodes.Count.ToString();

                xmldoc.Save(ContentManager.GetPhysicalPath(ConfigurationManager.AppSettings["HomePathValue"] + "banners_Cat1.xml"));
            }
            finally
            { }
        }

        protected void dtlOrder_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                DataRowView rowView = (DataRowView)e.Item.DataItem;
                CheckBox chkIsCOupon = (CheckBox)e.Item.FindControl("chkIsCOupon");
                Label lblSrNo = (Label)e.Item.FindControl("lblSrNo");
                cnt = cnt + 1;
                lblSrNo.Text = Convert.ToString(cnt);

                string strIsCoupon = Convert.ToString(rowView["IsCoupon"]);
                switch (strIsCoupon)
                {
                    case "True":
                        chkIsCOupon.Checked = true;
                        break;
                    case "False":
                        chkIsCOupon.Checked = false;
                        break;
                    default: break;
                }
            }
        }

        #endregion
    }
}