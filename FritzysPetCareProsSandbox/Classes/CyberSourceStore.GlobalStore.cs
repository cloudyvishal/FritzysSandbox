using Classes.Utility;
using CyberSource;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberSourceStore
{
    public struct Item
    {
        public string ProductName;
        public decimal UnitPrice;
        public int Quantity;
        public string TaxwareCode;
    }

    public struct Shopper
    {
        public string FirstName;
        public string LastName;
        public string Email;
    }

    public struct Address
    {
        public string Address1;
        public string Address2;
        public string City;
        public string State;
        public string Zip;
        public string Country;
        public string Phone;
    }

    public struct CreditCard
    {
        public string Number;
        public string ExpMonth;
        public string ExpYear;
        public string CV;
    }

    public class GlobalStore : System.Web.HttpApplication
    {
        public CyberSource.ICSClient icsClient;
        private System.ComponentModel.IContainer components;

        public GlobalStore()
        {
            InitializeComponent();
        }

        protected void Application_Start(Object sender, EventArgs e)
        {

        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            try
            {
                if (Session["HomePath"] == null)
                {
                    Session["HomePath"] = ConfigurationManager.AppSettings["HomePath"].ToString();     // Session["Homepath"] use to set root directory path and this path can be set from Web.config
                    Session["AdminPath"] = Session["HomePath"] + "Admin/";                             // Session["AdminPath"] use to set root directory path of admin folder 
                    Session["StaticContentPhysicalPath"] = Session["HomePath"] + "StoreData/";
                    Session["MemberName"] = null;                                                      // Session["MemberName"] Use to store member name display on home page 
                    Session["IsLogin"] = "0";                                                          // Session["IsLogin"] is use to check whether user is Loged in or not default Not  
                    Session["UserType"] = "4";                                                         // Session["UserType"] is use to set UseType 0 (Cat) ,1(Dog), 2(CatDog)
                    Session["AdminUserType"] = "1";                                                    // Session["AdminUserType"] is user to set Admin user type 0 for admin and 1 for Subadmin
                    Session["MobilePath"] = Session["HomePath"] + "mobileweb/";
                }

                //Session["UserID"]
            }
            catch (System.Data.SqlClient.SqlException ex) { }
            //if (Request.ServerVariables["HTTP_COOKIE"] == null)
            //{
            //    Response.Redirect("DisableCookies.htm");
            //}
            if (Session["HomePath"] == null)
            {
                Session["HomePath"] = System.Configuration.ConfigurationManager.AppSettings["HomePath"];
            }
            if (CheckBrowser.isMobileBrowser())
            {
                Session["Mobile"] = CheckBrowser.Mobile;

            }
            else
            {
                Session["Desktop"] = CheckBrowser.Desktop;
            }
            if (Session["Desktop"].ToString() == "Desktop")
            {
                Response.Redirect("http://localhost:53313/index.aspx", false);
            }
            else if (Session["Mobile"].ToString() == "Mobile")
            {
                Response.Redirect("http://localhost:53313/mobileweb/MB_index.aspx", false);
            }
        }

        public static string Amount2String(decimal amount)
        {
            return (String.Format("{0:c}", amount));
        }

        public static void AddShopperFields(ICSRequest request, ref Shopper shopper)
        {
            request["customer_firstname"] = shopper.FirstName;
            request["customer_lastname"] = shopper.LastName;
            request["customer_email"] = shopper.Email;
        }

        public static void AddBillAddressFields(
            ICSRequest request, ref Address billAddress)
        {
            request["bill_address1"] = billAddress.Address1;
            if (billAddress.Address2 != null &&
                billAddress.Address2.Length > 0)
            {
                request["bill_address2"] = billAddress.Address2;
            }
            request["bill_city"] = billAddress.City;
            request["bill_state"] = billAddress.State;
            request["bill_zip"] = billAddress.Zip;
            request["bill_country"] = billAddress.Country;
            request["customer_phone"] = billAddress.Phone;
        }

        public static void AddShipToAddressFields(
           ICSRequest request, ref Address shipToAddress)
        {
            request["ship_to_address1"] = shipToAddress.Address1;
            if (shipToAddress.Address2 != null &&
                shipToAddress.Address2.Length > 0)
            {
                request["ship_to_address2"] = shipToAddress.Address2;
            }
            request["ship_to_city"] = shipToAddress.City;
            request["ship_to_state"] = shipToAddress.State;
            request["ship_to_zip"] = shipToAddress.Zip;
            request["ship_to_country"] = shipToAddress.Country;
            request["ship_to_phone"] = shipToAddress.Phone;
        }

        internal static decimal DisplayItems(
            System.Web.UI.WebControls.Table table,
            System.Web.SessionState.HttpSessionState sessionState)
        {
            // Add headings
            TableRow row = new TableRow();
            row.Cells.Add(CreateHeadingCell("Product Name"));
            row.Cells.Add(CreateHeadingCell("Quantity"));
            row.Cells.Add(CreateHeadingCell("Unit Price"));
            row.Cells.Add(CreateHeadingCell("Total"));
            table.Rows.Add(row);

            // Add items
            Item[] shoppingCart = (Item[])sessionState["ShoppingCart"];

            decimal rowTotal, total = 0.00m;

            foreach (Item item in shoppingCart)
            {
                row = new TableRow();
                row.Cells.Add(CreateCell(item.ProductName));
                row.Cells.Add(CreateCell(item.Quantity.ToString()));
                row.Cells.Add(CreateCell(Amount2String(item.UnitPrice)));

                rowTotal = item.UnitPrice * item.Quantity;
                total += rowTotal;
                row.Cells.Add(CreateCell(Amount2String(rowTotal)));

                table.Rows.Add(row);
            }

            return (total);
        }

        internal static TableCell CreateHeadingCell(string label)
        {
            TableCell cell = new TableCell();
            cell.Controls.Add(new LiteralControl(label));
            cell.Font.Bold = true;
            return (cell);
        }

        internal static TableCell CreateCell(string label)
        {
            TableCell cell = new TableCell();
            cell.Controls.Add(new LiteralControl(label));
            return (cell);
        }

        public static void DisplayAmount(
            Table table, string heading, decimal amount)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell());
            row.Cells.Add(new TableCell());
            row.Cells.Add(GlobalStore.CreateHeadingCell(heading));
            row.Cells.Add(GlobalStore.CreateCell(GlobalStore.Amount2String(amount)));
            table.Rows.Add(row);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }

        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.icsClient = new CyberSource.ICSClient(this.components);

            this.icsClient.HTTPProxyPassword = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyPassword", typeof(string))));
            this.icsClient.HTTPProxyURL = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyURL", typeof(string))));
            this.icsClient.HTTPProxyUsername = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyUsername", typeof(string))));
            this.icsClient.KeysDir = ((string)(configurationAppSettings.GetValue("icsClient.KeysDir", typeof(string))));
            this.icsClient.LogFile = ((string)(configurationAppSettings.GetValue("icsClient.LogFile", typeof(string))));
            this.icsClient.LogLevel = ((string)(configurationAppSettings.GetValue("icsClient.LogLevel", typeof(string))));
            this.icsClient.LogMaxSize = ((int)(configurationAppSettings.GetValue("icsClient.LogMaxSize", typeof(int))));
            this.icsClient.MerchantId = ((string)(configurationAppSettings.GetValue("icsClient.MerchantId", typeof(string))));
            this.icsClient.RetryEnabled = ((string)(configurationAppSettings.GetValue("icsClient.RetryEnabled", typeof(string))));
            this.icsClient.RetryStart = ((int)(configurationAppSettings.GetValue("icsClient.RetryStart", typeof(int))));
            this.icsClient.ServerHost = ((string)(configurationAppSettings.GetValue("icsClient.ServerHost", typeof(string))));
            this.icsClient.ServerId = ((string)(configurationAppSettings.GetValue("icsClient.ServerId", typeof(string))));
            this.icsClient.ServerPort = ((int)(configurationAppSettings.GetValue("icsClient.ServerPort", typeof(int))));
            this.icsClient.ThrowLogException = ((string)(configurationAppSettings.GetValue("icsClient.ThrowLogException", typeof(string))));
            this.icsClient.Timeout = ((int)(configurationAppSettings.GetValue("icsClient.Timeout", typeof(int))));

        }
        #endregion
    }
}