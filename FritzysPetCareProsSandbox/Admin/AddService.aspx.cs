using BCL.Admin.ServiceMgr;
using BCL.Utility.Contents;
using BCL.Utility.RandomString;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class AddService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFckEditor();

                ImgService.Visible = false;
            }
        }

        #region

        /* Region to set FCK Editor content */
        protected void BindFckEditor()
        {
            FCKeditor2.Height = 300;

            FCKeditor2.Width = 800;

            FCKeditor2.SkinPath = "skins/silver/";
        }

        /* Error message and success messages are use to display messages to user*/
        public void ErrorMessage(string Message)
        {
            divError.Visible = true;

            lblError.Attributes.Add("Class", "errorTable");

            lblError.Visible = true;

            lblError.Text = Message;
        }

        public void SuccessMessage(string Message)
        {
            divError.Visible = true;

            lblError.Attributes.Add("Class", "successTable");

            lblError.Visible = true;

            lblError.Text = Message;
        }

        #endregion

        #region Event
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ImageName"] != null)
                {
                    string FileName;

                    Services ObjServices = new Services();

                    DataSet ds = new DataSet();

                    FileName = txtPageName.Text + ".htm";
                   
                    int count = ObjServices.AddService(Convert.ToInt32(ddlServiceType.SelectedValue),
                                            txtServiceTitle.Text.Trim(),
                                            txtServiceDesc.Text.Trim(),
                                            FileName,
                                            Convert.ToInt32(ddlStatus.SelectedValue),
                                            ViewState["ImageName"].ToString());
                    if (count == 1)
                    {
                        SuccessMessage("Service added successfully");

                        txtServiceTitle.Text = "";

                        txtServiceDesc.Text = "";

                        txtPageName.Text = "";

                        FCKeditor2.Value = "";

                        ImgService.ImageUrl = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/Images/Not.jpg";
                       
                        ContentManager.SaveRightHandSectionContent(FCKeditor2.Value, FileName);
                    }
                    else
                    {
                        ErrorMessage("Duplicate service name");
                    }
                }
                else
                {
                    ErrorMessage("Please upload image");
                }
            } finally{}
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageServices.aspx?SearchFor=0&SearchText=");
        }

        /* This event is use to Upload image after verification */
        protected void btnUpload_Click1(object sender, EventArgs e)
        {
            try
            {
                if (flUploadDetail.PostedFile != null)
                {
                    string ImageName2 = System.IO.Path.GetFileName(flUploadDetail.PostedFile.FileName);

                    if (ImageName2 != "")
                    {
                        string ext = System.IO.Path.GetExtension(flUploadDetail.FileName);

                        if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                        {
                            string NewImageName = RandomStringsAndNumbers.Generate() + ext;

                            string virtualpath2 = "~/StoreData/Images/" + NewImageName;

                            string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);


                            System.Drawing.Image image = System.Drawing.Image.FromStream(flUploadDetail.PostedFile.InputStream);

                            Bitmap myBitmap = ResizeImage(flUploadDetail.PostedFile.InputStream, 88, 144);

                            myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);

                            myBitmap.Dispose();

                            ViewState["ImageName"] = NewImageName.ToString();

                            ImgService.Visible = true;

                            ImgService.ImageUrl = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/Images/" + NewImageName;

                            divError.Visible = false;
                        }
                        else
                        { ErrorMessage("File Format Not Supported."); }
                    }
                    else
                    {
                        ErrorMessage("Please upload Image.");
                    }
                }
                else
                {
                    ErrorMessage("Please upload Image.");
                }
            } finally{}
        }

        /* This function is use to resize the inmage to require size and also maintain original ratio of image*/
        private Bitmap ResizeImage(Stream streamImage, int maxWidth, int maxHeight)
        {
            Bitmap originalImage = new Bitmap(streamImage);

            int sourceWidth = originalImage.Width;

            int sourceHeight = originalImage.Height;

            float nPercent = 0;

            float nPercentW = 0;

            float nPercentH = 0;

            nPercentW = ((float)maxWidth / (float)sourceWidth);

            nPercentH = ((float)maxHeight / (float)sourceHeight);


            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);

            int destHeight = (int)(sourceHeight * nPercent);

            return new Bitmap(originalImage, destWidth, destHeight);
        }
        #endregion
    }
}