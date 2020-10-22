namespace RT2020.Inventory.Transfer.Export
{
    partial class Export2Txt
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
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtnPosted = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnUnposted = new Gizmox.WebGUI.Forms.RadioButton();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.cboFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.btnExport = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.lblFileName = new Gizmox.WebGUI.Forms.Label();
            this.txtFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.btnBrowseFile = new Gizmox.WebGUI.Forms.Button();
            this.btnHelp = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnPosted);
            this.groupBox1.Controls.Add(this.rbtnUnposted);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // rbtnPosted
            // 
            this.rbtnPosted.Checked = true;
            this.rbtnPosted.Location = new System.Drawing.Point(18, 60);
            this.rbtnPosted.Name = "rbtnPosted";
            this.rbtnPosted.Size = new System.Drawing.Size(104, 24);
            this.rbtnPosted.TabIndex = 1;
            this.rbtnPosted.Text = "Posted";
            this.rbtnPosted.CheckedChanged += new System.EventHandler(this.rbtnPosted_CheckedChanged);
            // 
            // rbtnUnposted
            // 
            this.rbtnUnposted.Location = new System.Drawing.Point(18, 30);
            this.rbtnUnposted.Name = "rbtnUnposted";
            this.rbtnUnposted.Size = new System.Drawing.Size(104, 24);
            this.rbtnUnposted.TabIndex = 0;
            this.rbtnUnposted.Text = "Un-posted";
            this.rbtnUnposted.CheckedChanged += new System.EventHandler(this.rbtnUnposted_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.cboFrom);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(179, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Range";
            // 
            // cboTo
            // 
            this.cboTo.DropDownWidth = 143;
            this.cboTo.Location = new System.Drawing.Point(64, 63);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(143, 21);
            this.cboTo.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(17, 36);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 23);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.TabStop = false;
            this.lblFrom.Text = "From";
            // 
            // cboFrom
            // 
            this.cboFrom.DropDownWidth = 143;
            this.cboFrom.Location = new System.Drawing.Point(64, 33);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(143, 21);
            this.cboFrom.TabIndex = 0;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(17, 66);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 23);
            this.lblTo.TabIndex = 3;
            this.lblTo.TabStop = false;
            this.lblTo.Text = "To";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(251, 148);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(332, 148);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 124);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(100, 23);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(75, 121);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(266, 20);
            this.txtFileName.TabIndex = 5;
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(347, 119);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseFile.TabIndex = 6;
            this.btnBrowseFile.Text = "...";
            this.btnBrowseFile.Visible = false;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(377, 119);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 23);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "?";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Export2Txt
            // 
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 180);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer Export Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.RadioButton rbtnPosted;
        private Gizmox.WebGUI.Forms.RadioButton rbtnUnposted;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Button btnExport;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Label lblFileName;
        private Gizmox.WebGUI.Forms.TextBox txtFileName;
        private Gizmox.WebGUI.Forms.Button btnBrowseFile;
        private Gizmox.WebGUI.Forms.Button btnHelp;


    }
}