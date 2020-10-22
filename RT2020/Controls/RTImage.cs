using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using System.IO;
using System.Drawing;
using Gizmox.WebGUI.Common.Gateways;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace RT2020.Controls
{
    /// <summary>
    /// Load the image in the '<Directory Code="RTImages" Path="D:\RT2020\RTImages\" />'
    /// </summary>
    public class RTImage : PictureBox, IGatewayComponent
    {
        private string imageName = string.Empty;

        public RTImage()
        {

        }

        [DefaultValueAttribute(typeof(string), "")]
        [DescriptionAttribute("The image name with the folder stored specified image.")]
        public virtual string ImageName
        {
            get
            {
                return imageName;
            }
            set
            {
                // 2014.02.11 Arron : Added to accept upper case file extensions
                if ((value.ToLower().Contains(".jpg") || value.ToLower().Contains(".jpeg")) && System.IO.File.Exists(value))
                {
                    imageName = value;
                }
                else
                {
                    // If there is no image loaded, load the default empty image.
                    imageName = Path.Combine(VWGContext.Current.Config.GetDirectory("Images"), "no_photo.jpg");
                }

                this.Image = new GatewayResourceHandle(new GatewayReference(this, "image"));
                this.Update();
            }
        }

        #region IGatewayControl Members

        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            if (strAction == "image")
            {
                // Trt to get the gateway handler
                IGatewayHandler objGatewayHandler = ProcessGatewayRequest(objContext.HttpContext, strAction);

                if (objGatewayHandler != null)
                {
                    objGatewayHandler.ProcessGatewayRequest(objContext, this);
                }
            }
        }

        protected override IGatewayHandler ProcessGatewayRequest(HttpContext objContext, string strAction)
        {
            IGatewayHandler objGH = null;

            int NewWidth = this.Size.Width;
            int MaxHeight = this.Size.Height;
            bool OnlyResizeIfWider = true;

            if (imageName.Length != 0)
            {
                if (!(File.Exists(imageName)))
                {
                    imageName = Path.Combine(VWGContext.Current.Config.GetDirectory("Images"), "no_photo.jpg");
                }

                // This allows us to resize the image. It prevents skewed images and
                // also vertically long images caused by trying to maintain the aspect
                // ratio on images who's height is larger than their width
                System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(imageName);

                // Prevent using images internal thumbnail
                FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

                if (OnlyResizeIfWider)
                {
                    if (FullsizeImage.Width <= NewWidth)
                    {
                        NewWidth = FullsizeImage.Width;
                    }
                }

                int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
                if (NewHeight > MaxHeight)
                {
                    // Resize with height instead
                    NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                    NewHeight = MaxHeight;
                }

                System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

                // Clear handle to original file so that we can overwrite it if necessary
                FullsizeImage.Dispose();

                // Save resized picture
                NewImage.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Jpeg);
                NewImage.Dispose();
            }

            return objGH;
        }

        #endregion
    }
}
