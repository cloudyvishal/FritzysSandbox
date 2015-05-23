using System;
using System.IO;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;


using BCL.Utility.Contents;
using BCL.Utility.RandomString;
using BCL.Utility.GlobalFunctions;
using System.Configuration;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class EditFriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindData();
                }
                finally
                { }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
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
                            if (ViewState["LogoImage"] != null)
                            {
                                string LogicalPath = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/FriendLogo/" + ViewState["LogoImage"].ToString();

                                string physicalPath = ContentManager.GetPhysicalPath(LogicalPath);

                                if (System.IO.File.Exists(physicalPath))
                                {
                                    System.IO.File.Delete(physicalPath);
                                }
                            }
                            string NewImageName = RandomStringsAndNumbers.Generate() + ext;

                            string virtualpath2 = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/FriendLogo/" + NewImageName;

                            string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);


                            System.Drawing.Image image = System.Drawing.Image.FromStream(flUploadDetail.PostedFile.InputStream);

                            Bitmap myBitmap = ResizeImage(flUploadDetail.PostedFile.InputStream, 75, 50);

                            myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);

                            myBitmap.Dispose();

                            ViewState["LogoImage"] = NewImageName.ToString();
                            
                            Global ObjFriend = new Global();
                           
                            ObjFriend.UpdateFriends(FriendID, txtTitle.Text.Trim(), txtDescription.Text.Trim(), ViewState["LogoImage"].ToString(), txtReferallink.Text.Trim());
                            
                            SuccessMessage("Updated successfully");
                            
                            BindData();
                        }
                        else
                        { ErrorMessage("Sorry, File Format Not Supported."); }
                    }
                    else
                    {
                        Global ObjFriend = new Global();
                       
                        ObjFriend.UpdateFriends(FriendID, txtTitle.Text.Trim(), txtDescription.Text.Trim(), ViewState["LogoImage"].ToString(), txtReferallink.Text.Trim());
                        
                        SuccessMessage("Fritzy's Friend Updated successfully.");
                        
                        BindData();
                    }
                }
            } finally{}
        }

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

        protected int FriendID
        {
            get
            {
                if (Request.QueryString["FriendID"] != null)
                {
                    return int.Parse(Request.QueryString["FriendID"].ToString());
                }
                else
                {
                    return 0;
                }
            }
        }

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

        protected void BindData()
        {
            try
            {
                Global ObjFriend = new Global();

                DataSet ds = new DataSet();

                ds = ObjFriend.GetFriend(FriendID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();

                    txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                    txtReferallink.Text = ds.Tables[0].Rows[0]["RefLink"].ToString();

                    imgLogo.ImageUrl = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/FriendLogo/" + ds.Tables[0].Rows[0]["Logo"].ToString();

                    ViewState["LogoImage"] = ds.Tables[0].Rows[0]["Logo"].ToString();
                }
                else
                {
                    ErrorMessage("Sorry, No records found.");
                }
            } finally{}
        }
    }
}