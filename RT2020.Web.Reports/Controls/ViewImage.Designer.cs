namespace RT2020.Web.Reports.Controls
{
    partial class ViewImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productImage1 = new RT2020.Web.Reports.Controls.ProductImage();
            this.SuspendLayout();
            // 
            // productImage1
            // 
            this.productImage1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.productImage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.productImage1.Image = null;
            this.productImage1.Location = new System.Drawing.Point(0, 0);
            this.productImage1.Name = "productImage1";
            this.productImage1.Size = new System.Drawing.Size(360, 300);
            this.productImage1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.CenterImage;
            this.productImage1.TabIndex = 1;
            // 
            // ViewImage
            // 
            this.Controls.Add(this.productImage1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(360, 300);
            this.Text = "ViewImage";
            this.ResumeLayout(false);

        }

        #endregion

        private ProductImage productImage1;


    }
}