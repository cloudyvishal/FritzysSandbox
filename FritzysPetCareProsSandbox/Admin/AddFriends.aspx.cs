using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;


using BCL.Utility.Contents;
using BCL.Utility.RandomString;
using BCL.Utility.GlobalFunctions;
using System.Configuration;


namespace FritzysPetCareProsSandbox.Admin
{
    public partial class AddFriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (flUploadDetail.PostedFile != null)
                {
                    string ImageName2 = System.IO.Path.GetFileName(flUploadDetail.PostedFile.FileName);
                    
                    if (ImageName2 != "")
                    {
                        string ext = System.IO.Path.GetExtension(flUploadDetail.FileName).ToLower();
                        
                        if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                        {
                            string NewImageName = RandomStringsAndNumbers.Generate() + ext;

                            string virtualpath2 = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/FriendLogo/" + NewImageName;

                            string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);


                            System.Drawing.Image image = System.Drawing.Image.FromStream(flUploadDetail.PostedFile.InputStream);

                            Bitmap myBitmap = ResizeImage(flUploadDetail.PostedFile.InputStream, 75, 50);

                            myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);

                            myBitmap.Dispose();

                            Global ObjFriend = new Global();

                            ObjFriend.AddFriend(txtTitle.Text.Trim(), txtDescription.Text.Trim(), NewImageName, txtReferallink.Text.Trim());

                            txtTitle.Text = "";

                            txtReferallink.Text = "";

                            txtDescription.Text = "";

                            SuccessMessage("Friend  added successfully");
                        }
                        else
                        { ErrorMessage("File Format Not Supported"); }
                    }
                    else
                    {
                        ErrorMessage("You Forgot To Select File Please Select File & Then Try.");
                    }
                }
                else
                {
                    ErrorMessage("You Forgot To Select File Please Select File & Then Try.");
                }
            } finally{}
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Bitmap bmIP = new Bitmap(flUploadDetail.PostedFile.InputStream);

            if (bmIP.Width > 75 | bmIP.Height > 55)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
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
    }
}