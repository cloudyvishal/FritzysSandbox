using System;
using System.IO;
using System.Web;
using System.Text;
using System.Configuration;

public class BasePage : System.Web.UI.Page
{
    private SessionManagement _SessionManagement;

    public SessionManagement SessionManagement
    {
        get
        {
            if (Session["SessionManagement"] == null)
            {
                _SessionManagement = new SessionManagement();
                Session["SessionManagement"] = _SessionManagement;
            }
            else
            {
                _SessionManagement = Session["SessionManagement"] as
                    SessionManagement;
            }
            return _SessionManagement;
        }
    }
}

public class SessionManagement
{
    public string UserId
    {
        get
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                HttpContext.Current.Session["UserID"] = "4";
            }
            else
            {
                HttpContext.Current.Session["UserID"] = HttpContext.Current.Session["UserID"].ToString();
            }
            return HttpContext.Current.Session["UserID"].ToString();
        }
        set
        { HttpContext.Current.Session["UserID"] = value; }
    }
   
    public string MemberName
    {
        get
        {
            if (HttpContext.Current.Session["MemberName"] == null)
            {
                HttpContext.Current.Session["MemberName"] = "0";
            }
            else
            {
                HttpContext.Current.Session["MemberName"] = HttpContext.Current.Session["MemberName"].ToString();
            }
            return HttpContext.Current.Session["MemberName"].ToString();
        }
        set
        { HttpContext.Current.Session["MemberName"] = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public string UserType
    {
        get
        {
            if (HttpContext.Current.Session["UserType"] == null)
            {
                HttpContext.Current.Session["UserType"] = "4";
            }
            else
            {
                HttpContext.Current.Session["UserType"] = HttpContext.Current.Session["UserType"];
            }
            return Convert.ToString(HttpContext.Current.Session["UserType"]);
        }
        set { HttpContext.Current.Session["UserType"] = value; }
    }

    public string HomePath
    {
        get
        {
            HttpContext.Current.Session["HomePath"] = ConfigurationManager.AppSettings["HomePathValue"];

            return HttpContext.Current.Session["HomePath"].ToString();
        }
        set
        {
            HttpContext.Current.Session["HomePath"] = value;
        }
    }

    public string AdminPath
    {
        get
        {
            HttpContext.Current.Session["AdminPathValue"] = ConfigurationManager.AppSettings["AdminPathValue"];

            return HttpContext.Current.Session["AdminPathValue"].ToString();
        }
        set
        {
            HttpContext.Current.Session["AdminPathValue"] = value;
        }
    }

    public string UserName
    {
        get
        {
            if (HttpContext.Current.Session["UserName"] == null)
            {
                HttpContext.Current.Session["UserName"] = "0";
            }
            else
            {
                HttpContext.Current.Session["UserName"] = HttpContext.Current.Session["UserName"].ToString();
            }

            return HttpContext.Current.Session["UserName"].ToString();
        }
        set
        { HttpContext.Current.Session["UserName"] = value; }
    }

    public string IsLogin
    {
        get
        {
            if (HttpContext.Current.Session["LoginId"] == null)
            {
                HttpContext.Current.Session["LoginId"] = "0";
            }
            else
            {
                HttpContext.Current.Session["LoginId"] = HttpContext.Current.Session["LoginId"].ToString();
            }
            return HttpContext.Current.Session["LoginId"].ToString();
        }
        set
        { HttpContext.Current.Session["LoginId"] = value; }
    }
}
