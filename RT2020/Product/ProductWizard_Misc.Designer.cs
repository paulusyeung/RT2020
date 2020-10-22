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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle3 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.gbMisc = new Gizmox.WebGUI.Forms.GroupBox();
            this.imgProductPic = new RT2020.Controls.RTImage();
            this.txtPicSize = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPicFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPicSize = new Gizmox.WebGUI.Forms.Label();
            this.lblPicFileName = new Gizmox.WebGUI.Forms.Label();
            this.btnDelete = new Gizmox.WebGUI.Forms.Button();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.btnRefresh = new Gizmox.WebGUI.Forms.Button();
            this.openFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.txtMemo = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gbMisc
            // 
            this.gbMisc.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbMisc.Controls.Add(this.txtMemo);
            this.gbMisc.Controls.Add(this.imgProductPic);
            this.gbMisc.Controls.Add(this.txtPicSize);
            this.gbMisc.Controls.Add(this.txtPicFileName);
            this.gbMisc.Controls.Add(this.lblPicSize);
            this.gbMisc.Controls.Add(this.lblPicFileName);
            this.gbMisc.Controls.Add(this.btnDelete);
            this.gbMisc.Controls.Add(this.btnFind);
            this.gbMisc.Controls.Add(this.btnRefresh);
            this.gbMisc.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.gbMisc.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.gbMisc.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbMisc.Location = new System.Drawing.Point(0, 0);
            this.gbMisc.Name = "gbMisc";
            this.gbMisc.Size = new System.Drawing.Size(766, 350);
            this.gbMisc.TabIndex = 0;
            // 
            // imgProductPic
            // 
            this.imgProductPic.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.imgProductPic.Image = null;
            this.imgProductPic.ImageName = string.Empty;
            this.imgProductPic.Location = new System.Drawing.Point(20, 19);
            this.imgProductPic.Name = "imgProductPic";
            this.imgProductPic.Size = new System.Drawing.Size(356, 236);
            this.imgProductPic.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.Normal;
            this.imgProductPic.TabIndex = 9;
            // 
            // txtPicSize
            // 
            this.txtPicSize.BackColor = System.Drawing.Color.LightYellow;
            this.txtPicSize.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPicSize.Location = new System.Drawing.Point(102, 295);
            this.txtPicSize.Name = "txtPicSize";
            this.txtPicSize.ReadOnly = true;
            this.txtPicSize.Size = new System.Drawing.Size(412, 20);
            this.txtPicSize.TabIndex = 8;
            this.txtPicSize.Text = "1.8 * 3.4 Inch / 175 * 330 Pixel";
            // 
            // txtPicFileName
            // 
            this.txtPicFileName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPicFileName.Location = new System.Drawing.Point(102, 272);
            this.txtPicFileName.Name = "txtPicFileName";
            this.txtPicFileName.Size = new System.Drawing.Size(412, 20);
            this.txtPicFileName.TabIndex = 7;
            // 
            // lblPicSize
            // 
            this.lblPicSize.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPicSize.Location = new System.Drawing.Point(17, 298);
            this.lblPicSize.Name = "lblPicSize";
            this.lblPicSize.Size = new System.Drawing.Size(79, 23);
            this.lblPicSize.TabIndex = 6;
            this.lblPicSize.Text = "Picture Size:";
            // 
            // lblPicFileName
            // 
            this.lblPicFileName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPicFileName.Location = new System.Drawing.Point(17, 275);
            this.lblPicFileName.Name = "lblPicFileName";
            this.lblPicFileName.Size = new System.Drawing.Size(79, 23);
            this.lblPicFileName.TabIndex = 5;
            this.lblPicFileName.Text = "Picture File:";
            // 
            // btnDelete
            // 
            this.btnDelete.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            iconResourceHandle1.File = "16x16.16_L_remove.gif";
            this.btnDelete.Image = iconResourceHandle1;
            this.btnDelete.Location = new System.Drawing.Point(644, 293);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFind
            // 
            this.btnFind.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            iconResourceHandle2.File = "16x16.16_find.gif";
            this.btnFind.Image = iconResourceHandle2;
            this.btnFind.Location = new System.Drawing.Point(613, 293);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(25, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            iconResourceHandle3.File = "16x16.16_L_refresh.gif";
            this.btnRefresh.Image = iconResourceHandle3;
            this.btnRefresh.Location = new System.Drawing.Point(582, 293);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // txtMemo
            // 
            this.txtMemo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemo.Location = new System.Drawing.Point(382, 19);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(364, 236);
            this.txtMemo.TabIndex = 10;
            // 
            // ProductWizard_Misc
            // 
            this.Controls.Add(this.gbMisc);
            this.Size = new System.Drawing.Size(766, 350);
            this.Text = "ProductWizard_Misc";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox gbMisc;
        private Gizmox.WebGUI.Forms.TextBox txtPicSize;
        private Gizmox.WebGUI.Forms.Label lblPicSize;
        private Gizmox.WebGUI.Forms.Label lblPicFileName;
        private Gizmox.WebGUI.Forms.Button btnDelete;
        private Gizmox.WebGUI.Forms.Button btnFind;
        private Gizmox.WebGUI.Forms.Button btnRefresh;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog;
        public Gizmox.WebGUI.Forms.TextBox txtPicFileName;
        public RT2020.Controls.RTImage imgProductPic;
        public Gizmox.WebGUI.Forms.TextBox txtMemo;


    }
}