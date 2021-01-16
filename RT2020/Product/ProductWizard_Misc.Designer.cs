namespace RT2020.Product
{
    partial class ProductWizard_Misc
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductWizard_Misc));
            this.txtMemo = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPicSize = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPicFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPicSize = new Gizmox.WebGUI.Forms.Label();
            this.lblPicFileName = new Gizmox.WebGUI.Forms.Label();
            this.btnDelete = new Gizmox.WebGUI.Forms.Button();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.btnRefresh = new Gizmox.WebGUI.Forms.Button();
            this.imgProductPic = new RT2020.Controls.RTImage();
            this.openFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.imgProductPic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(377, 13);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(364, 236);
            this.txtMemo.TabIndex = 10;
            // 
            // txtPicSize
            // 
            this.txtPicSize.BackColor = System.Drawing.Color.LightYellow;
            this.txtPicSize.Location = new System.Drawing.Point(97, 289);
            this.txtPicSize.Name = "txtPicSize";
            this.txtPicSize.ReadOnly = true;
            this.txtPicSize.Size = new System.Drawing.Size(412, 20);
            this.txtPicSize.TabIndex = 8;
            this.txtPicSize.Text = "1.8 * 3.4 Inch / 175 * 330 Pixel";
            // 
            // txtPicFileName
            // 
            this.txtPicFileName.Location = new System.Drawing.Point(97, 266);
            this.txtPicFileName.Name = "txtPicFileName";
            this.txtPicFileName.Size = new System.Drawing.Size(412, 20);
            this.txtPicFileName.TabIndex = 7;
            // 
            // lblPicSize
            // 
            this.lblPicSize.Location = new System.Drawing.Point(12, 292);
            this.lblPicSize.Name = "lblPicSize";
            this.lblPicSize.Size = new System.Drawing.Size(79, 23);
            this.lblPicSize.TabIndex = 6;
            this.lblPicSize.Text = "Picture Size:";
            // 
            // lblPicFileName
            // 
            this.lblPicFileName.Location = new System.Drawing.Point(12, 269);
            this.lblPicFileName.Name = "lblPicFileName";
            this.lblPicFileName.Size = new System.Drawing.Size(79, 23);
            this.lblPicFileName.TabIndex = 5;
            this.lblPicFileName.Text = "Picture File:";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnDelete.Image"));
            this.btnDelete.Location = new System.Drawing.Point(639, 287);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFind.Image"));
            this.btnFind.Location = new System.Drawing.Point(608, 287);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(25, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnRefresh.Image"));
            this.btnRefresh.Location = new System.Drawing.Point(577, 287);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // imgProductPic
            // 
            this.imgProductPic.Location = new System.Drawing.Point(0, 0);
            this.imgProductPic.Name = "imgProductPic";
            this.imgProductPic.Size = new System.Drawing.Size(64, 105);
            this.imgProductPic.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Theme = "";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // ProductWizard_Misc
            // 
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.txtPicSize);
            this.Controls.Add(this.txtPicFileName);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblPicSize);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblPicFileName);
            this.Controls.Add(this.btnDelete);
            this.DockPadding.All = 10;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.Size = new System.Drawing.Size(766, 350);
            this.Text = "ProductWizard_Misc";
            this.Load += new System.EventHandler(this.ProductWizard_Misc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgProductPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Gizmox.WebGUI.Forms.TextBox txtPicSize;
        private Gizmox.WebGUI.Forms.Label lblPicSize;
        private Gizmox.WebGUI.Forms.Label lblPicFileName;
        private Gizmox.WebGUI.Forms.Button btnDelete;
        private Gizmox.WebGUI.Forms.Button btnFind;
        private Gizmox.WebGUI.Forms.Button btnRefresh;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog;
        public Gizmox.WebGUI.Forms.TextBox txtPicFileName;
        public Gizmox.WebGUI.Forms.TextBox txtMemo;
        private Gizmox.WebGUI.Forms.ToolTip toolTip1;
    }
}