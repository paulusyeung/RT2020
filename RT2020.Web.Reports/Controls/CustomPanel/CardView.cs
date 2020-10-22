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
    public class CardView : Panel
    {
        private PictureBox picBox = new PictureBox();
        private PictureBox line = new PictureBox();
        private Label lblName = new Label();
        private Label lblDescription = new Label();
        private Label lblLastPrintedOn = new Label();

        /// <summary>
        /// Initializes a new instance of the <see cref="CardView"/> class.
        /// </summary>
        public CardView()
        {
            this.InitialComponents();

            this.Size = new Size(411, 90);
            this.BorderColor = Color.SkyBlue;
        }

        #region Initial Components

        /// <summary>
        /// Initials this instance.
        /// </summary>
        private void InitialComponents()
        {
            this.PaintPictureBox();
            this.PaintNameLabel();
            this.PaintLine();
            this.PaintDescriptionLabel();
            this.PaintLastPrintedOnLabel();
        }

        /// <summary>
        /// Paints the picture box.
        /// </summary>
        private void PaintPictureBox()
        {
            picBox.Location = new Point(0, 0);
            picBox.Size = new Size(48, 48);
            picBox.SizeMode = PictureBoxSizeMode.CenterImage;
            picBox.Click += new EventHandler(ctrl_Click);
            picBox.Cursor = Cursors.Hand;
            this.Controls.Add(picBox);
        }

        /// <summary>
        /// Handles the DoubleClick event of the control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ctrl_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        /// <summary>
        /// Paints the label.
        /// </summary>
        private void PaintNameLabel()
        {
            lblName.Location = new Point(picBox.Width + 14, 0);
            lblName.Size = new Size(325, 24);
            lblName.ForeColor = Color.FromArgb(83, 99, 159);
            lblName.Font = new Font("Tahoma", 12, FontStyle.Bold);
            lblName.Cursor = Cursors.Hand;
            lblName.Click += new EventHandler(ctrl_Click);
            this.Controls.Add(lblName);
        }

        /// <summary>
        /// Paints the line.
        /// </summary>
        private void PaintLine()
        {
            line.Location = new Point(picBox.Width + 14, 24);
            line.Size = new Size(325, 3);
            line.SizeMode = PictureBoxSizeMode.CenterImage;
            line.Image = new IconResourceHandle("Icons.Line.line.png");
            this.Controls.Add(line);
        }

        /// <summary>
        /// Paints the label.
        /// </summary>
        private void PaintDescriptionLabel()
        {
            lblDescription.Location = new Point(picBox.Width + 14, lblName.Location.Y + 27);
            lblDescription.Size = new Size(325, 40);
            lblDescription.Font = new Font("Tahoma", 8.25f);
            this.Controls.Add(lblDescription);
        }

        /// <summary>
        /// Paints the label.
        /// </summary>
        private void PaintLastPrintedOnLabel()
        {
            lblLastPrintedOn.Location = new Point(picBox.Width + 14, lblDescription.Location.Y + 24);
            lblLastPrintedOn.Size = new Size(325, 13);
            lblLastPrintedOn.Font = new Font("Tahoma", 8.25f);
            this.Controls.Add(lblLastPrintedOn);
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

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return lblDescription.Text;
            }
            set
            {
                lblDescription.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the last printed on.
        /// </summary>
        /// <value>The last printed on.</value>
        public string LastPrintedOn
        {
            get
            {
                return lblLastPrintedOn.Text.Replace("Last Accessed on :", "");
            }
            set
            {
                lblLastPrintedOn.Text = "Last Accessed On:" + value;
            }
        }

        #endregion

        #region Events

        #endregion
    }
}