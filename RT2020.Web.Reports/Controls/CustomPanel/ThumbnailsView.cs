using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Collections;
using Gizmox.WebGUI.Common.Resources;

namespace RT2020.Web.Reports.Controls.CustomPanel
{
    public class ThumbnailsView : Panel
    {
        private PictureBox picBox = new PictureBox();
        private Label lblName = new Label();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CardView"/> class.
        /// </summary>
        public ThumbnailsView()
        {
            this.InitialComponents();

            this.Size = new Size(350, 250);
            this.Padding = new Padding(6);
            this.BorderColor = Color.SkyBlue;
            this.Margin = new Padding(6);
        }

        #region Initial Components

        /// <summary>
        /// Initials this instance.
        /// </summary>
        private void InitialComponents()
        {
            this.PaintPictureBox();
            this.PaintNameLabel();
        }

        /// <summary>
        /// Paints the picture box.
        /// </summary>
        private void PaintPictureBox()
        {
            picBox.Anchor = AnchorStyles.Top;
            picBox.Location = new Point(25, 0);
            picBox.Size = new Size(300, 225);
            picBox.SizeMode = PictureBoxSizeMode.CenterImage;
            picBox.DoubleClick += new EventHandler(picBox_DoubleClick);
            this.Controls.Add(picBox);
        }

        /// <summary>
        /// Handles the DoubleClick event of the picBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void picBox_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);
        }

        /// <summary>
        /// Paints the label.
        /// </summary>
        private void PaintNameLabel()
        {
            //lblName.Anchor = AnchorStyles.Top;
            lblName.Location = new Point(picBox.Location.X, picBox.Height + 6);
            lblName.Height = 13;
            lblName.AutoSize = true;
            this.Controls.Add(lblName);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public ResourceHandle Image
        {
            get
            {
                return picBox.Image;
            }
            set
            {
                picBox.Image = value;
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value></value>
        public override string Text
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }

        #endregion

        #region Events

        #endregion
    }
}
