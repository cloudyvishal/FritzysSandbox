
using BCL.Utility.Contents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ImageManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Bind();
            } finally{}
        }

        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void Bind()
        {
            try
            {
                ImgGift.ImageUrl = ConfigurationManager.AppSettings["HomePathValue"] + "Images/giftcard1.jpg";
            } 
            finally{}
        }

        protected void btnGift_Click(object sender, EventArgs e)
        {
            try
            {
                if (fluGiftCard.PostedFile != null)
                {
                    string ImageName2 = System.IO.Path.GetFileName(fluGiftCard.PostedFile.FileName);
                    if (ImageName2 != "")
                    {
                        string ext = System.IO.Path.GetExtension(fluGiftCard.FileName);
                        if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                        {
                            string virtualpath2 = ConfigurationManager.AppSettings["HomePathValue"] + "Images/giftcard1.jpg";
                            string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(fluGiftCard.PostedFile.InputStream);
                            Bitmap myBitmap = ResizeImage(fluGiftCard.PostedFile.InputStream, 234, 138);
                            myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);
                            myBitmap.Dispose();
                            divError.Visible = false;
                        }
                        else
                        { ErrMessage("File Format Not Supported"); }
                    }
                    else
                    {
                        ErrMessage("Please upload Image.");
                    }
                }
                else
                {
                    ErrMessage("Please upload Image.");
                }
                Bind();
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

            //float maxWidth = 88;
            //float maxHeight = 144;

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
    }
}