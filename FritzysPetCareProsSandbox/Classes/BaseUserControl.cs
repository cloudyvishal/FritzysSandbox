using System;
using System.Web;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;


public class BaseUserControl : System.Web.UI.UserControl
{
    private SessionManagementControl _SessionManagement;

    public SessionManagementControl SessionManagementControl
    {
        get
        {
            if (Session["SessionManagement"] == null)
            {
                _SessionManagement = new SessionManagementControl();
                Session["SessionManagement"] = _SessionManagement;
            }
            else
            {
                _SessionManagement = Session["SessionManagement"] as
                    SessionManagementControl;
            }
            return _SessionManagement;
        }
    }
}
public class SessionManagementControl
{
    public string UserId
    {
        get
        {
            return HttpContext.Current.Session["UserID"] == null ? "4" : HttpContext.Current.Session["UserID"].ToString();
        }
        set
        { HttpContext.Current.Session["UserID"] = value; }
    }

    public string UserType
    {
        get
        {
            return HttpContext.Current.Session["UserType"] == null ? string.Empty : HttpContext.Current.Session["UserType"].ToString();
        }
        set
        {
            HttpContext.Current.Session["UserType"] = value;
        }
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

    public string IsLogin
    {
        get
        {
            return HttpContext.Current.Session["LoginId"] == null ? "0" : HttpContext.Current.Session["LoginId"].ToString();
        }
        set
        { HttpContext.Current.Session["LoginId"] = value; }
    }

    public string MemberName
    {
        get
        {
            return HttpContext.Current.Session["MemberName"] == null ? "0" : HttpContext.Current.Session["MemberName"].ToString();
        }
        set
        { HttpContext.Current.Session["MemberName"] = value; }
    }

    public string UserName
    {
        get
        {
            return HttpContext.Current.Session["UserName"] == null ? "0" : HttpContext.Current.Session["UserName"].ToString();
        }
        set
        { HttpContext.Current.Session["UserName"] = value; }
    }
}
