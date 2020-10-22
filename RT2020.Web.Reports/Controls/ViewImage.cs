#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using System.IO;

#endregion

namespace RT2020.Web.Reports.Controls
{
    public partial class ViewImage : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewImage"/> class.
        /// </summary>
        public ViewImage()
        {
            InitializeComponent();
        }

        public string ImageName
        {
            set
            {
                productImage1.ImageName = value;
            }
            
        }

        //private string imageFile = string.Empty;

        ///// <summary>
        ///// Gets or sets the image file.
        ///// </summary>
        ///// <value>The image file.</value>
        //public string ImageFile
        //{
        //    get
        //    {
        //        return imageFile;
        //    }
        //    set
        //    {
        //        imageFile = value;
        //        string imageFolder = VWGContext.Current.Config.GetDirectory("RTImages");
        //        string imagePath = Path.Combine(Path.Combine(imageFolder, "Product"), imageFile);
        //        ImageResourceHandle resc = new ImageResourceHandle();
        //        resc.File = imagePath;
        //    }
        //}
    }
}