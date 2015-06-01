using System;
using System.Web;
using System.Xml;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MobileWeb.MasterPages
{
    public partial class MB_MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                Response.Cache.SetNoStore();
            }
            string Name;

            if (Session["UserID"] != null)
            {
                dvLogin.Visible = true;
                dvLogoutusers.Visible = false;
            }
            else
            {
                dvLogoutusers.Visible = true;
                dvLogin.Visible = false;
            }

            string path = ConfigurationManager.AppSettings["HomePathValue"] ;

            Name = (string)Session["UserType"];

            string xmlfile = path + "banners_Cat1.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlfile);

            int i = 0;

            XmlNodeList xnList = xmlDoc.SelectNodes("/rotator/bannerName/banners/banner");

            foreach (XmlNode node in xnList)
            {
                if (node["BannerId"] != null)
                {
                    switch (Convert.ToInt32(Name))
                    {
                        case 0:

                            string homepath = node["PageNames"].InnerText;

                            if (homepath == "Home1")
                            {
                                string priority = node["BannerId"].InnerText;

                                string firstName = node["link"].InnerText;

                                string lastName = node["imagePath"].InnerText;

                                int length = firstName.Length;

                                int last = firstName.LastIndexOf("=");

                                string value = firstName.Substring(last + 1);

                                if (Convert.ToInt32(value) == Convert.ToInt32(Name))
                                {
                                    if (int.Parse(priority) > 0)
                                    {
                                        if (i == 0)
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' class='active' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }
                                        else
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }

                                        XmlElement xmlElement = xmlDoc.DocumentElement;

                                        XmlNodeList FirstImage = xmlElement.ChildNodes;

                                        DataSet dataset = new DataSet();

                                        dataset.ReadXml(path + "banners_Cat1.xml");

                                        i++;
                                    }
                                }
                            }
                            break;

                        case 1:
                            string homepath1 = node["PageNames"].InnerText;

                            if (homepath1 == "Home2")
                            {
                                string priority = node["BannerId"].InnerText;

                                string firstName = node["link"].InnerText;

                                string lastName = node["virtualmobilepath1"].InnerText;

                                int length = firstName.Length;

                                int last = firstName.LastIndexOf("=");

                                string value = firstName.Substring(last + 1);

                                if (Convert.ToInt32(value) == Convert.ToInt32(Name))
                                {
                                    if (int.Parse(priority) > 0)
                                    {
                                        if (i == 0)
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' class='active' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }
                                        else
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }

                                        XmlElement xmlElement = xmlDoc.DocumentElement;

                                        XmlNodeList FirstImage = xmlElement.ChildNodes;

                                        DataSet dataset = new DataSet();

                                        dataset.ReadXml(path + "banners_Cat1.xml");

                                        i++;
                                    }
                                }
                            }
                            break;

                        case 2:
                            string homepath2 = node["PageNames"].InnerText;

                            if (homepath2 == "Home3")
                            {
                                string priority = node["BannerId"].InnerText;

                                string firstName = node["link"].InnerText;

                                string lastName = node["virtualmobilepath1"].InnerText;

                                int length = firstName.Length;

                                int last = firstName.LastIndexOf("=");

                                string value = firstName.Substring(last + 1);

                                if (Convert.ToInt32(value) == Convert.ToInt32(Name))
                                {
                                    if (int.Parse(priority) > 0)
                                    {
                                        if (i == 0)
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' class='active' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }
                                        else
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }

                                        XmlElement xmlElement = xmlDoc.DocumentElement;

                                        XmlNodeList FirstImage = xmlElement.ChildNodes;

                                        DataSet dataset = new DataSet();

                                        dataset.ReadXml(path + "banners_Cat1.xml");

                                        i++;
                                    }
                                }
                            }
                            break;

                        case 3:
                            string homepath3 = node["PageNames"].InnerText;

                            if (homepath3 == "Home4")
                            {
                                string priority = node["BannerId"].InnerText;

                                string firstName = node["link"].InnerText;

                                string lastName = node["virtualmobilepath1"].InnerText;

                                int length = firstName.Length;

                                int last = firstName.LastIndexOf("=");

                                string value = firstName.Substring(last + 1);

                                if (Convert.ToInt32(value) == Convert.ToInt32(Name))
                                {
                                    if (int.Parse(priority) > 0)
                                    {
                                        if (i == 0)
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' class='active' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }
                                        else
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }

                                        XmlElement xmlElement = xmlDoc.DocumentElement;

                                        XmlNodeList FirstImage = xmlElement.ChildNodes;

                                        DataSet dataset = new DataSet();

                                        dataset.ReadXml(path + "banners_Cat1.xml");

                                        i++;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}