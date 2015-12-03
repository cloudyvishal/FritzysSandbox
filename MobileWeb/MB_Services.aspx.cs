using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace MobileWeb
{
    public partial class MB_Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == "0")
            {
                if (Request.QueryString["PetID"] != null)
                {
                    if (Request.QueryString["PetID"] == "Cat")
                    {
                        Control bodyCntrl = LoadControl("MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl1 = LoadControl("MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl1);
                    }
                    else if (Request.QueryString["PetID"] == "Dog")
                    {
                        Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl2);
                    }
                }
                else
                {
                    Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                    plcServices.Controls.Add(bodyCntrl);

                    Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                    plcServices.Controls.Add(bodyCntrl2);
                }
            }
            else
            {
                if (Session["UserType"] == "3")
                {
                    if (Request.QueryString["PetID"] != null)
                    {
                        if (Request.QueryString["PetID"] == "Cat")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl1 = LoadControl("MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl1);
                        }
                        else if (Request.QueryString["PetID"] == "Dog")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl2);
                        }
                    }
                    else
                    {
                        Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl6 = LoadControl("MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl6);
                    }
                }

                if (Session["UserType"] == "4")
                {
                    if (Request.QueryString["PetID"] != null)
                    {
                        if (Request.QueryString["PetID"] == "Cat")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Cat.ascx");

                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl1 = LoadControl("MB_Controls/Services_Dog.ascx");

                            plcServices.Controls.Add(bodyCntrl1);
                        }
                        else if (Request.QueryString["PetID"] == "Dog")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");

                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");

                            plcServices.Controls.Add(bodyCntrl2);
                        }
                    }
                    else
                    {
                        Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl2);
                    }
                }

                if (Session["UserType"] == "1")
                {
                    if (Request.QueryString["PetID"] != null)
                    {
                        if (Request.QueryString["PetID"] == "Cat")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl1 = LoadControl("MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl1);
                        }
                        else if (Request.QueryString["PetID"] == "Dog")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl2);
                        }
                    }
                    else
                    {

                        Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl2);

                        Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                    }
                }

                if (Session["UserType"] == "2")
                {
                    if (Request.QueryString["PetID"] != null)
                    {
                        if (Request.QueryString["PetID"] == "Cat")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl1 = LoadControl("MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl1);
                        }
                        else if (Request.QueryString["PetID"] == "Dog")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl2);
                        }
                    }
                    else
                    {
                        Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl2);
                    }
                }
                if ((Session["UserType"] == null || Session["UserType"] == ""))
                {
                    if (Request.QueryString["PetID"] != null)
                    {
                        if (Request.QueryString["PetID"] == "Cat")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl1 = LoadControl("MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl1);
                        }
                        else if (Request.QueryString["PetID"] == "Dog")
                        {
                            Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl2);
                        }
                    }
                    else
                    {
                        Control bodyCntrl = LoadControl("MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl2 = LoadControl("MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl2);
                    }
                }
            }
        }
    }
}