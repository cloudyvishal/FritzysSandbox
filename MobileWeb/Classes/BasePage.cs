using System;
using System.Web;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;

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
    public int UserId
    {
        get
        {
            return HttpContext.Current.Session["UserID"] == null ? 4 :
            (int)HttpContext.Current.Session["UserID"];
        }
        set
        { HttpContext.Current.Session["UserID"] = value; }
    }

    public string UserType
    {
        get
        {
            return HttpContext.Current.Session["UserType"] == null ?
                string.Empty : HttpContext.Current.Session["UserType"].ToString();
        }
        set { HttpContext.Current.Session["UserType"] = value; }
    }

    public string HomePath
    {
        get
        {
            return HttpContext.Current.Session["HomePath"].ToString() == ConfigurationManager.AppSettings["HomePathValue"].ToString() ? string.Empty : HttpContext.Current.Session["HomePath"].ToString();
        }
        set
        {
            HttpContext.Current.Session["HomePath"] = value;
        }
    }
}