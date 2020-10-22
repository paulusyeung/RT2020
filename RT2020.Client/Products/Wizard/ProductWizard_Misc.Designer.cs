namespace RT2020.Client.Products.Wizard
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
            this.gbMisc = new System.Windows.Forms.GroupBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.imgProductPic = new System.Windows.Forms.PictureBox();
            this.txtPicSize = new System.Windows.Forms.TextBox();
            this.txtPicFileName = new System.Windows.Forms.TextBox();
            this.lblPicSize = new System.Windows.Forms.Label();
            this.lblPicFileName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProductPic)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMisc
            // 
            this.gbMisc.Controls.Add(this.txtMemo);
            this.gbMisc.Controls.Add(this.imgProductPic);
            this.gbMisc.Controls.Add(this.txtPicSize);
            this.gbMisc.Controls.Add(this.txtPicFileName);
            this.gbMisc.Controls.Add(this.lblPicSize);
            this.gbMisc.Controls.Add(this.lblPicFileName);
            this.gbMisc.Controls.Add(this.btnDelete);
            this.gbMisc.Controls.Add(this.btnFind);
            this.gbMisc.Controls.Add(this.btnRefresh);
            this.gbMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbMisc.Location = new System.Drawing.Point(0, 0);
            this.gbMisc.Name = "gbMisc";
            this.gbMisc.Size = new System.Drawing.Size(766, 350);
            this.gbMisc.TabIndex = 0;
            this.gbMisc.TabStop = false;
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(382, 19);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(364, 236);
            this.txtMemo.TabIndex = 10;
            // 
            // imgProductPic
            // 
            this.imgProductPic.Location = new System.Drawing.Point(20, 19);
            this.imgProductPic.Name = "imgProductPic";
            this.imgProductPic.Size = new System.Drawing.Size(356, 236);
            this.imgProductPic.TabIndex = 9;
            this.imgProductPic.TabStop = false;
            // 
            // txtPicSize
            // 
            this.txtPicSize.BackColor = System.Drawing.Color.LightYellow;
            this.txtPicSize.Location = new System.Drawing.Point(102, 295);
            this.txtPicSize.Name = "txtPicSize";
            this.txtPicSize.ReadOnly = true;
            this.txtPicSize.Size = new System.Drawing.Size(412, 20);
            this.txtPicSize.TabIndex = 8;
            this.txtPicSize.Text = "1.8 * 3.4 Inch / 175 * 330 Pixel";
            // 
            // txtPicFileName
            // 
            this.txtPicFileName.Location = new System.Drawing.Point(102, 272);
            this.txtPicFileName.Name = "txtPicFileName";
            this.txtPicFileName.Size = new System.Drawing.Size(412, 20);
            this.txtPicFileName.TabIndex = 7;
            // 
            // lblPicSize
            // 
            this.lblPicSize.Location = new System.Drawing.Point(17, 298);
            this.lblPicSize.Name = "lblPicSize";
            this.lblPicSize.Size = new System.Drawing.Size(79, 23);
            this.lblPicSize.TabIndex = 6;
            this.lblPicSize.Text = "Picture Size:";
            // 
            // lblPicFileName
            // 
            this.lblPicFileName.Location = new System.Drawing.Point(17, 275);
            this.lblPicFileName.Name = "lblPicFileName";
            this.lblPicFileName.Size = new System.Drawing.Size(79, 23);
            this.lblPicFileName.TabIndex = 5;
            this.lblPicFileName.Text = "Picture File:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(644, 293);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Visible = false;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(613, 293);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(25, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(582, 293);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Visible = false;
            // 
            // ProductWizard_Misc
            // 
            this.Controls.Add(this.gbMisc);
            this.Name = "ProductWizard_Misc";
            this.Size = new System.Drawing.Size(766, 350);
            this.gbMisc.ResumeLayout(false);
            this.gbMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProductPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMisc;
        private System.Windows.Forms.TextBox txtPicSize;
        private System.Windows.Forms.Label lblPicSize;
        private System.Windows.Forms.Label lblPicFileName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public System.Windows.Forms.TextBox txtPicFileName;
        public System.Windows.Forms.PictureBox imgProductPic;
        public System.Windows.Forms.TextBox txtMemo;


    }
}