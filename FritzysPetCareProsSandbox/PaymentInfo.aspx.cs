using BCL.Admin.StoreFrontMgr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CyberSource;
using System.Data;
using BCL.Utility.SendMailMgr;
using System.Configuration;
using BCL.Utility.Contents;
using CyberSourceStore;
using System.Data.SqlClient;

namespace FritzysPetCareProsSandbox
{
    public partial class PaymentInfo : System.Web.UI.Page
    {
        StoreFront objStoreFront = new StoreFront();
        decimal RevenueCost, TipCost, PriorRevenueCost;
        private ICSReply mReply;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!(null == Session["UserName"]))
                {
                    fillAppDetails();
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
                Session["Paycount"] = 1;
                Session["IsExecuted"] = "0";
            }
        }

        public void fillAppDetails()
        {
            DataSet ds = new DataSet();
            ds = objStoreFront.GetAppInfoforPayment(Session["UserName"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["GID"] = ds.Tables[0].Rows[0]["gid"];
                Session["logid"] = ds.Tables[0].Rows[0]["logid"];
                Session["Syncid"] = ds.Tables[0].Rows[0]["syncid"];
                Session["appid"] = ds.Tables[0].Rows[0]["apptid"];
                Session["AppDate"] = ds.Tables[0].Rows[0]["AddedOn"];
                lbl_time.Text = ds.Tables[0].Rows[0]["appDateTime"].ToString();
                lbl_description.Text = ds.Tables[0].Rows[0]["appString"].ToString();

                if (!(String.IsNullOrEmpty(ds.Tables[0].Rows[0]["revenueamt"].ToString())))
                {
                    lblRevenueCost.Text = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["revenueamt"].ToString()), 2).ToString();
                    RevenueCost = decimal.Parse(ds.Tables[0].Rows[0]["revenueamt"].ToString());
                }
                if (!(String.IsNullOrEmpty(ds.Tables[0].Rows[0]["tipamt"].ToString())))
                {
                    txtTipCost.Text = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["tipamt"].ToString()), 2).ToString();
                    TipCost = decimal.Parse(ds.Tables[0].Rows[0]["tipamt"].ToString());
                }
                if (!(String.IsNullOrEmpty(ds.Tables[0].Rows[0]["prioramt"].ToString())))
                {
                    lblPriorRevenueCost.Text = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["prioramt"].ToString()), 2).ToString();
                    PriorRevenueCost = decimal.Parse(ds.Tables[0].Rows[0]["prioramt"].ToString());
                }
                lblTotalCost.Text = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["totalamt"].ToString()), 2).ToString();
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected string GetOrderRefNumber()
        {
            string OrdNumber = "";
            try
            {
                OrdNumber = (new Random()).Next().ToString();

                IDataReader rdr = objStoreFront.CheckOrderRefNo(OrdNumber);

                if (rdr != null)
                {
                    OrdNumber = GetOrderRefNumber();
                }
            }
            catch (Exception ex)
            {
            }
            return OrdNumber;
        }

        protected void btnSubmitInfo_Click(object sender, EventArgs e)
        {
            string email = "info@fritzyspetcarepros.com";
            //dec2013
            //string email = "monali@dharne.com";
            try
            {
                int t = Convert.ToInt32(txtTipCost.Text);
                if (t <= (-1))
                {
                    lblerrormsg.Visible = true;
                    txtTipCost.Focus();
                }
                else
                {
                    if (Page.IsValid.Equals(true))
                    {
                        //check to avoid duplicate transactions.
                        if (!(null == Session["IsExecuted"]))
                        {
                            if (Session["IsExecuted"].Equals("0"))
                            {
                                Session["IsExecuted"] = "1";

                                if (!(null == Session["GID"]))
                                {
                                    btnSubmitInfo.Enabled = false;
                                    lblerrormsg.Visible = false;
                                    // set up Order number uniquely.
                                    string OrderRefNo = GetOrderRefNumber();
                                    Session["OrderNumber"] = OrderRefNo;
                                    int GId = Convert.ToInt32(Session["GID"]);

                                    objStoreFront.GetShopperInfo(GId, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), txtCity.Text.Trim(),
                                    txtState.Text.Trim(), txtZip.Text.Trim(), txtCountry.Text.Trim(), txtPhone.Text.Trim(), email, drpCardType.SelectedItem.Text, txtCardNumber.Text.Trim(),
                                    txtExpYear.Text.Trim(), drpMonth.SelectedValue, "", Convert.ToDecimal(lblTotalCost.Text),
                                    decimal.Parse("0"), decimal.Parse("0"), OrderRefNo);

                                    Session["emailid"] = email;
                                    Session["totalprice"] = lblTotalCost.Text.Trim().ToString();
                                    Session["CC_Name"] = txtFirstName.Text.Trim().ToString();
                                    Session["CC_Name1"] = txtLastName.Text.Trim().ToString();

                                    string errorMessage = (string)Session["ErrorMessage"];

                                    Item[] shoppingCart = new Item[1];

                                    shoppingCart[0].ProductName = "Pets Treatment";
                                    shoppingCart[0].UnitPrice = Convert.ToDecimal(lblTotalCost.Text);
                                    shoppingCart[0].Quantity = 1;
                                    shoppingCart[0].TaxwareCode = "default";

                                    Session["ShoppingCart"] = shoppingCart;

                                    // set up customer info.
                                    Shopper shopper;
                                    shopper.FirstName = txtFirstName.Text.Trim();
                                    shopper.LastName = txtLastName.Text.Trim();
                                    // shopper.Email = txtEmail.Text.Trim();
                                    shopper.Email = "info@fritzyspetcarepros.com";
                                    Session["Shopper"] = shopper;
                                    // set up address info.
                                    Address address;
                                    address.Address1 = txtAddress1.Text.Trim();
                                    address.Address2 = txtAddress2.Text.Trim();
                                    address.City = txtCity.Text.Trim();
                                    address.State = txtState.Text.Trim();

                                    address.Zip = txtZip.Text.Trim();
                                    address.Country = txtCountry.Text.Trim();
                                    address.Phone = txtPhone.Text.Trim();

                                    Session["BillAddress"] = address;

                                    // set up credit card info.
                                    CreditCard card;
                                    card.Number = txtCardNumber.Text.Trim();
                                    card.ExpMonth = drpMonth.SelectedValue.ToString();
                                    card.ExpYear = txtExpYear.Text.Trim();
                                    card.CV = txtVerificationNo.Text.Trim();
                                    // Calulates the Tax. 
                                    GlobalStore obj = new GlobalStore();

                                    GlobalStore global = (GlobalStore)Context.ApplicationInstance;

                                    //      CalculateTax(global.icsClient);
                                    // Authenticate Customer Credit Card details.
                                    Authorize(global.icsClient, ref card);

                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Authorize(ICSClient client, ref CreditCard card)
        {
            try
            {
                // create request object
                ICSRequest request = new ICSRequest();
                // add general fields
                if (!(null == Session["OrderNumber"]))
                {
                    request["merchant_ref_number"] = (string)Session["OrderNumber"];
                }
                request["ics_applications"] = "ics_auth,ics_bill";
                request["currency"] = "USD";

                Shopper shopper = (Shopper)Session["Shopper"];
                Address billAddress = (Address)Session["BillAddress"];
                Address shipToAddress = (Address)Session["BillAddress"];

                // add shopper and address info
                GlobalStore.AddShopperFields(request, ref shopper);
                GlobalStore.AddBillAddressFields(request, ref billAddress);
                GlobalStore.AddShipToAddressFields(request, ref shipToAddress);

                // add an offer for the total amount
                if (lblTotalCost.Text != "")
                {
                    request["offer0"] = "amount:" + Convert.ToDecimal(lblTotalCost.Text);
                }
                // add credit card info
                request["customer_cc_number"] = card.Number;
                request["customer_cc_expmo"] = card.ExpMonth;
                request["customer_cc_expyr"] = card.ExpYear;
                request["customer_cc_cv_number"] = card.CV;

                // send request now
                mReply = client.Send(request);
                // extract needed information from mReply.  A couple of reply fields
                // are extracted below for example.
                //   string requestId = mReply["request_id"];
                // process the transaction as per response.
                HandleReply();
            }
            catch (BugException e)
            {
                Session["Exception"] = e;
                HandleReply();
            }
            catch (NonCriticalTransactionException e)
            {
                Session["Exception"] = e;
                HandleReply();
            }
            catch (CriticalTransactionException e)
            {
                // The transaction may have been successfully processed by
                // CyberSource.  Aside from redirecting to an error page, you should
                // make sure that someone gets notified of the occurrence of this
                // exception so that they could check the outcome of the transaction
                // on the CyberSource Support Screens.  For example, you could
                // post an event log or send an email to a monitored address.
                Session["Exception"] = e;
                HandleReply();
            }
        }

        private void HandleReply()
        {
            try
            {
                string rFlag = "", ResponseID = "", Responsemsg = "", billtxnrefno = "", authCode = "";
                if (!(null == mReply))
                {
                    rFlag = mReply["ics_rflag"];
                    ResponseID = mReply["request_id"];
                    Responsemsg = mReply["ics_rmsg"];
                    billtxnrefno = mReply["bill_trans_ref_no"];
                    authCode = mReply["auth_auth_code"];
                }
                if (rFlag.Equals("DSETTINGS"))
                {
                    authCode = "SMART";
                }
                bool IsResponsefound = false;
                lblMessage.Text = "";
                lblReason.Text = "";
                string OrdNumber = (string)Session["OrderNumber"];
                int ID = 0;
                if (rFlag.Equals("SOK") || rFlag.Equals("DSETTINGS"))
                {
                    IsResponsefound = true;
                }

                if (rFlag.Equals("SOK") || rFlag.Equals("DSETTINGS"))
                {
                    IsResponsefound = true;
                    decimal TipCost;
                    if (txtTipCost.Text != "")
                    {
                        TipCost = decimal.Parse(txtTipCost.Text);
                    }
                    else
                    {
                        TipCost = 0;
                    }
                    if (!(String.IsNullOrEmpty(Session["logid"].ToString())))
                    {
                        objStoreFront.UpdatePGResponseDetails(rFlag, Session["logid"].ToString(), ResponseID, Session["PayID"].ToString(), Responsemsg, billtxnrefno, authCode);
                        objStoreFront.UpdateSyncAppStatus(Convert.ToInt32(Session["Syncid"]), "Paid", Convert.ToInt32(Session["PayID"]), TipCost);
                        PaymentDoneMessage("Your payment is made for groomer service.");
                        lblsmsg.Visible = true;
                        btnSubmitInfo.Enabled = false;
                        Session["Amt"] = "Paid";
                        Response.Redirect("PayList.aspx?msg=S");
                    }
                    else
                    {
                        objStoreFront.UpdatePGResponseDetails(rFlag, "0", ResponseID, Session["PayID"].ToString(), Responsemsg, billtxnrefno, authCode);
                        objStoreFront.UpdateSyncAppStatus(Convert.ToInt32(Session["Syncid"]), "Paid", Convert.ToInt32(Session["PayID"]), TipCost);
                        PaymentDoneMessage("Your payment is made for groomer service.");
                        lblsmsg.Visible = true;
                        btnSubmitInfo.Enabled = false;
                        Session["Amt"] = "Paid";
                        Response.Redirect("PayList.aspx?msg=S");
                    }

                }
                if (rFlag.Equals("DAVSNO"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Please verify that your address is correct.";
                }
                if (rFlag.Equals("DINVALIDADDRESS"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "City,state or postal code entered was invalid.";
                }
                else if (rFlag.Equals("DCALL"))
                {
                    IsResponsefound = true;
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    Session["ErrorMessage"] = "Your transaction can not be processed at this time,contact the payment processor to proceed with the transaction";
                }
                else if (rFlag.Equals("DCARDEXPIRED"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Your card has expired.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DCARDREFUSED"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Card Authorization failed.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DCV"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Incorrect Card Verification Number.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DINVALIDCARD"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Invalid credit card number.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DRESTRICTED"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "declined restriced card.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DSCORE"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Card not successfully authenticated.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("ESYSTEM"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "System Internal error.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DINVALIDDATA"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Invalid Data";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("ETIMEOUT"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Payment Transaction Timeout.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals(""))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Payment can not be processed please select another form of payment";
                }

                if (!(rFlag.Equals("SOK")))
                {
                    Session["IsExecuted"] = "0";
                    if (IsResponsefound.Equals(false))
                    {
                        Session["ErrorMessage"] = "Payment can not be processed please select another form of payment";
                    }
                    int PayCount = 0;
                    if (!(null == Session["Paycount"]))
                    {
                        PayCount = Convert.ToInt32(Session["Paycount"].ToString());
                    }
                    if (PayCount < 3)
                    {
                        btnSubmitInfo.Enabled = true;

                        txtFirstName.Focus();
                        if (!(null == Session["ErrorMessage"]))
                        {
                            lblMessage.Text = Session["ErrorMessage"].ToString() + " Please try again";
                            Session["Paycount"] = PayCount + 1;
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void PaymentDoneMessage(string body)
        {
            try
            {
                string Date_time = DateTime.Now.ToString();
                string datenew = Date_time.ToString();
                string Appoinment = Session["appid"].ToString();
                string Appoinment_Date = Session["AppDate"].ToString();
                string emailadd = Session["emailid"].ToString();
                string totalprice = Session["totalprice"].ToString();
                string CC_Name1 = Session["CC_Name"].ToString();
                string CC_Name2 = Session["CC_Name1"].ToString();
                string CC_Name = CC_Name1 + " " + CC_Name2;
                string orderno = (string)Session["OrderNumber"];
                string Mailbody = ContentManager.GetStaticeContentEmail("PaymentEmail.htm").Replace("~", "#");
                Mailbody = Mailbody.Replace("<!-- Date -->", Date_time);
                Mailbody = Mailbody.Replace("<!-- Appoinment -->", Appoinment);
                Mailbody = Mailbody.Replace("<!-- Appoinment_Date -->", Appoinment_Date);
                Mailbody = Mailbody.Replace("<!-- Total_Amount -->", totalprice);
                Mailbody = Mailbody.Replace("<!-- CC_Name -->", CC_Name);
                //Mailbody = Mailbody.Replace("<!-- orderNumber -->", orderno);
                SendMails ObjMail = new SendMails();

                ObjMail.PaymentMail(ConfigurationManager.AppSettings["FromEmail"].ToString(),
                                    datenew, Appoinment, Appoinment_Date, emailadd, totalprice, CC_Name, body, Mailbody);


            }
            catch (Exception ex)
            {
                string error = ex.Source + "_" + ex.Message + "_" + ex.ToString();
            }
        }

        private void CalculateTax(ICSClient client)
        {
            try
            {
                // create request object
                ICSRequest request = new ICSRequest();
                // add general fields
                request["merchant_ref_number"] = (string)Session["OrderNumber"];
                request["ics_applications"] = "ics_tax";
                request["currency"] = "USD";

                Shopper shopper = (Shopper)Session["Shopper"];
                Address billAddress = (Address)Session["BillAddress"];
                Address shipToAddress = (Address)Session["BillAddress"];

                // add shopper and address info
                GlobalStore.AddShopperFields(request, ref shopper);
                GlobalStore.AddBillAddressFields(request, ref billAddress);
                GlobalStore.AddShipToAddressFields(request, ref shipToAddress);

                // add an offer for each item in the shopping cart
                ICSOffer offer;
                Item[] shoppingCart = (Item[])Session["ShoppingCart"];
                int i = 0;
                foreach (Item item in shoppingCart)
                {
                    offer = new ICSOffer();
                    offer["amount"] = item.UnitPrice.ToString();
                    offer["quantity"] = item.Quantity.ToString();
                    offer["product_code"] = item.TaxwareCode;
                    request.SetOffer(i++, offer);
                }
                // add another offer for shipping and handling
                offer = new ICSOffer();
                offer["amount"] = "0";
                // replace shipping_and_handling with a more appropriate
                // taxware S&H code.
                offer["product_code"] = "shipping_and_handling";
                request.SetOffer(i, offer);
                // send request now
                ICSReply reply = client.Send(request);
                // ics_rcode of 1 means the transaction was processed successfully.
                if (reply["ics_rcode"] != "1")
                {
                    Session["ErrorMessage"] = "Error calculating tax.";
                    Response.Redirect("DisplayError.aspx", false);
                }
                // extract information from reply
                decimal mTax = Decimal.Parse(reply["tax_total_tax"]);
                decimal mTotal = Decimal.Parse(reply["tax_total_grand"]);
            }
            catch (BugException e)
            {
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
            catch (NonCriticalTransactionException e)
            {
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
            catch (CriticalTransactionException e)
            {
                // no need to handle a CriticalTransactionException differently
                // for ics_tax.
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            //lblTotalCost.Text = (decimal.Parse(lblRevenueCost.Text) + decimal.Parse(lblTipCost.Text) + decimal.Parse(lblPriorRevenueCost.Text)).ToString();
        }

        protected void txtTipCost_TextChanged(object sender, EventArgs e)
        {
            if (txtTipCost.Text != "")
            {
                int t = Convert.ToInt32(txtTipCost.Text);
                if (t <= (-1))
                {
                    lblerrormsg.Visible = true;
                    txtTipCost.Focus();
                }
                else
                {
                    lblerrormsg.Visible = false;
                    TipCost = decimal.Parse(txtTipCost.Text);
                    RevenueCost = decimal.Parse(lblRevenueCost.Text);
                    PriorRevenueCost = decimal.Parse(lblPriorRevenueCost.Text);
                    lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
                    Session["TotalCost"] = lblTotalCost.Text;
                }
            }
            else
            {
                txtTipCost.Text = "0";
                lblerrormsg.Visible = false;
                TipCost = decimal.Parse(txtTipCost.Text);
                RevenueCost = decimal.Parse(lblRevenueCost.Text);
                PriorRevenueCost = decimal.Parse(lblPriorRevenueCost.Text);
                lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
                Session["TotalCost"] = lblTotalCost.Text;
            }
        }
    }
}