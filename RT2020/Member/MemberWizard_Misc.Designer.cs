namespace RT2020.Member
{
    partial class MemberWizard_Misc
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle3 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.lblPicFileName = new Gizmox.WebGUI.Forms.Label();
            this.txtPicFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.btnFindPic = new Gizmox.WebGUI.Forms.Button();
            this.btnDelete = new Gizmox.WebGUI.Forms.Button();
            this.btnRefresh = new Gizmox.WebGUI.Forms.Button();
            this.openFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.imgMemberPicture = new RT2020.Controls.RTImage();
            this.lblMemo = new Gizmox.WebGUI.Forms.Label();
            this.txtMemo = new Gizmox.WebGUI.Forms.TextBox();
            this.gbPicture = new Gizmox.WebGUI.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lblPicFileName
            // 
            this.lblPicFileName.Location = new System.Drawing.Point(6, 264);
            this.lblPicFileName.Name = "lblPicFileName";
            this.lblPicFileName.Size = new System.Drawing.Size(100, 23);
            this.lblPicFileName.TabIndex = 2;
            this.lblPicFileName.Text = "Picture File Name:";
            // 
            // txtPicFileName
            // 
            this.txtPicFileName.BackColor = System.Drawing.Color.LightYellow;
            this.txtPicFileName.Location = new System.Drawing.Point(152, 261);
            this.txtPicFileName.Name = "txtPicFileName";
            this.txtPicFileName.ReadOnly = true;
            this.txtPicFileName.Size = new System.Drawing.Size(381, 20);
            this.txtPicFileName.TabIndex = 3;
            // 
            // btnFindPic
            // 
            iconResourceHandle1.File = "16x16.16_find.gif";
            this.btnFindPic.Image = iconResourceHandle1;
            this.btnFindPic.Location = new System.Drawing.Point(539, 259);
            this.btnFindPic.Name = "btnFindPic";
            this.btnFindPic.Size = new System.Drawing.Size(34, 23);
            this.btnFindPic.TabIndex = 4;
            this.btnFindPic.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnFindPic.Click += new System.EventHandler(this.btnFindPic_Click);
            // 
            // btnDelete
            // 
            iconResourceHandle2.File = "16x16.16_L_remove.gif";
            this.btnDelete.Image = iconResourceHandle2;
            this.btnDelete.Location = new System.Drawing.Point(579, 259);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(33, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            iconResourceHandle3.File = "16x16.16_L_refresh.gif";
            this.btnRefresh.Image = iconResourceHandle3;
            this.btnRefresh.Location = new System.Drawing.Point(618, 259);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // imgMemberPicture
            // 
            this.imgMemberPicture.Image = null;
            this.imgMemberPicture.ImageName = "";
            this.imgMemberPicture.Location = new System.Drawing.Point(6, 19);
            this.imgMemberPicture.Name = "imgMemberPicture";
            this.imgMemberPicture.Size = new System.Drawing.Size(388, 227);
            this.imgMemberPicture.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.Normal;
            this.imgMemberPicture.TabIndex = 7;
            // 
            // lblMemo
            // 
            this.lblMemo.Location = new System.Drawing.Point(13, 11);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(59, 23);
            this.lblMemo.TabIndex = 8;
            this.lblMemo.Text = "Memo:";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(78, 8);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(671, 53);
            this.txtMemo.TabIndex = 9;
            // 
            // gbPicture
            // 
            this.gbPicture.Controls.Add(this.imgMemberPicture);
            this.gbPicture.Controls.Add(this.lblPicFileName);
            this.gbPicture.Controls.Add(this.txtPicFileName);
            this.gbPicture.Controls.Add(this.btnRefresh);
            this.gbPicture.Controls.Add(this.btnFindPic);
            this.gbPicture.Controls.Add(this.btnDelete);
            this.gbPicture.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbPicture.Location = new System.Drawing.Point(16, 67);
            this.gbPicture.Name = "gbPicture";
            this.gbPicture.Size = new System.Drawing.Size(733, 302);
            this.gbPicture.TabIndex = 10;
            this.gbPicture.Text = "Picture";
            // 
            // MemberWizard_MiscInfo
            // 
            this.Controls.Add(this.gbPicture);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.lblMemo);
            this.Size = new System.Drawing.Size(766, 379);
            this.Text = "MemberWizard_MiscInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblPicFileName;
        public Gizmox.WebGUI.Forms.Button btnFindPic;
        public Gizmox.WebGUI.Forms.Button btnDelete;
        public Gizmox.WebGUI.Forms.Button btnRefresh;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog;
        public RT2020.Controls.RTImage imgMemberPicture;
        public Gizmox.WebGUI.Forms.TextBox txtPicFileName;
        private Gizmox.WebGUI.Forms.Label lblMemo;
        private Gizmox.WebGUI.Forms.GroupBox gbPicture;
        public Gizmox.WebGUI.Forms.TextBox txtMemo;


    }
}