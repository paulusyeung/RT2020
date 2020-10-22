namespace RT2020.Client
{
    partial class WizardWithTabsBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardWithTabsBase));
            this.ansWizard = new System.Windows.Forms.ToolStrip();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdSaveNew = new System.Windows.Forms.ToolStripButton();
            this.cmdSaveClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdApproval = new System.Windows.Forms.ToolStripButton();
            this.wspPane = new System.Windows.Forms.Panel();
            this.wspDetails = new System.Windows.Forms.Panel();
            this.wspStatus = new System.Windows.Forms.Panel();
            this.wspHeader = new System.Windows.Forms.Panel();
            this.ansWizard.SuspendLayout();
            this.wspPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // ansWizard
            // 
            this.ansWizard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSave,
            this.cmdSaveNew,
            this.cmdSaveClose,
            this.toolStripSeparator1,
            this.cmdDelete,
            this.toolStripSeparator2,
            this.cmdApproval});
            this.ansWizard.Location = new System.Drawing.Point(0, 0);
            this.ansWizard.Name = "ansWizard";
            this.ansWizard.Size = new System.Drawing.Size(794, 25);
            this.ansWizard.TabIndex = 0;
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(51, 22);
            this.cmdSave.Text = "Save";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdSaveNew
            // 
            this.cmdSaveNew.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveNew.Image")));
            this.cmdSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSaveNew.Name = "cmdSaveNew";
            this.cmdSaveNew.Size = new System.Drawing.Size(91, 22);
            this.cmdSaveNew.Text = "Save && New";
            this.cmdSaveNew.Click += new System.EventHandler(this.cmdSaveNew_Click);
            // 
            // cmdSaveClose
            // 
            this.cmdSaveClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveClose.Image")));
            this.cmdSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSaveClose.Name = "cmdSaveClose";
            this.cmdSaveClose.Size = new System.Drawing.Size(96, 22);
            this.cmdSaveClose.Text = "Save && Close";
            this.cmdSaveClose.Click += new System.EventHandler(this.cmdSaveClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Enabled = false;
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(60, 22);
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdApproval
            // 
            this.cmdApproval.Image = ((System.Drawing.Image)(resources.GetObject("cmdApproval.Image")));
            this.cmdApproval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdApproval.Name = "cmdApproval";
            this.cmdApproval.Size = new System.Drawing.Size(75, 22);
            this.cmdApproval.Text = "Approval";
            this.cmdApproval.Visible = false;
            this.cmdApproval.Click += new System.EventHandler(this.cmdApproval_Click);
            // 
            // wspPane
            // 
            this.wspPane.BackColor = System.Drawing.Color.WhiteSmoke;
            this.wspPane.Controls.Add(this.wspDetails);
            this.wspPane.Controls.Add(this.wspStatus);
            this.wspPane.Controls.Add(this.wspHeader);
            this.wspPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wspPane.Location = new System.Drawing.Point(0, 25);
            this.wspPane.Name = "wspPane";
            this.wspPane.Padding = new System.Windows.Forms.Padding(10);
            this.wspPane.Size = new System.Drawing.Size(794, 543);
            this.wspPane.TabIndex = 1;
            // 
            // wspDetails
            // 
            this.wspDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wspDetails.Location = new System.Drawing.Point(10, 80);
            this.wspDetails.Name = "wspDetails";
            this.wspDetails.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.wspDetails.Size = new System.Drawing.Size(774, 405);
            this.wspDetails.TabIndex = 5;
            // 
            // wspStatus
            // 
            this.wspStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wspStatus.Location = new System.Drawing.Point(10, 485);
            this.wspStatus.Name = "wspStatus";
            this.wspStatus.Size = new System.Drawing.Size(774, 48);
            this.wspStatus.TabIndex = 2;
            // 
            // wspHeader
            // 
            this.wspHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.wspHeader.Location = new System.Drawing.Point(10, 10);
            this.wspHeader.Name = "wspHeader";
            this.wspHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.wspHeader.Size = new System.Drawing.Size(774, 70);
            this.wspHeader.TabIndex = 0;
            // 
            // WizardWithTabsBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.wspPane);
            this.Controls.Add(this.ansWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardWithTabsBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{0} > Wizard";
            this.Load += new System.EventHandler(this.WizardBase_Load);
            this.Activated += new System.EventHandler(this.WizardBase_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WizardBase_FormClosing);
            this.ansWizard.ResumeLayout(false);
            this.ansWizard.PerformLayout();
            this.wspPane.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton cmdSave;
        private System.Windows.Forms.ToolStripButton cmdSaveNew;
        private System.Windows.Forms.ToolStripButton cmdSaveClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel wspPane;
        public System.Windows.Forms.Panel wspDetails;
        public System.Windows.Forms.Panel wspStatus;
        public System.Windows.Forms.Panel wspHeader;
        public System.Windows.Forms.ToolStrip ansWizard;
        public System.Windows.Forms.ToolStripButton cmdDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton cmdApproval;
    }
}
