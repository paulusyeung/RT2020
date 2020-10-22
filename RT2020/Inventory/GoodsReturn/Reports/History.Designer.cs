namespace RT2020.Inventory.GoodsReturn.Reports
{
    partial class HistoryWizard
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtTxNumberTo = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTxNumberFrom = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpTxDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpTxDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblTxDateTo = new Gizmox.WebGUI.Forms.Label();
            this.lblTxDateFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblTxDate = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.cmdPreview = new Gizmox.WebGUI.Forms.Button();
            this.btnFindFromTxNumber = new Gizmox.WebGUI.Forms.Button();
            this.btnFindToTxNumber = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFindToTxNumber);
            this.groupBox2.Controls.Add(this.btnFindFromTxNumber);
            this.groupBox2.Controls.Add(this.txtTxNumberTo);
            this.groupBox2.Controls.Add(this.txtTxNumberFrom);
            this.groupBox2.Controls.Add(this.dtpTxDateTo);
            this.groupBox2.Controls.Add(this.dtpTxDateFrom);
            this.groupBox2.Controls.Add(this.lblTxDateTo);
            this.groupBox2.Controls.Add(this.lblTxDateFrom);
            this.groupBox2.Controls.Add(this.lblTxDate);
            this.groupBox2.Controls.Add(this.lblTxNumber);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Range";
            // 
            // txtTxNumberTo
            // 
            this.txtTxNumberTo.Location = new System.Drawing.Point(75, 63);
            this.txtTxNumberTo.Name = "txtTxNumberTo";
            this.txtTxNumberTo.Size = new System.Drawing.Size(120, 20);
            this.txtTxNumberTo.TabIndex = 1;
            this.txtTxNumberTo.Text = "zz";
            // 
            // txtTxNumberFrom
            // 
            this.txtTxNumberFrom.Location = new System.Drawing.Point(75, 39);
            this.txtTxNumberFrom.Name = "txtTxNumberFrom";
            this.txtTxNumberFrom.Size = new System.Drawing.Size(120, 20);
            this.txtTxNumberFrom.TabIndex = 0;
            this.txtTxNumberFrom.Text = "00";
            // 
            // dtpTxDateTo
            // 
            this.dtpTxDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDateTo.Location = new System.Drawing.Point(305, 62);
            this.dtpTxDateTo.Name = "dtpTxDateTo";
            this.dtpTxDateTo.Size = new System.Drawing.Size(140, 20);
            this.dtpTxDateTo.TabIndex = 3;
            // 
            // dtpTxDateFrom
            // 
            this.dtpTxDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDateFrom.Location = new System.Drawing.Point(305, 39);
            this.dtpTxDateFrom.Name = "dtpTxDateFrom";
            this.dtpTxDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpTxDateFrom.TabIndex = 2;
            // 
            // lblTxDateTo
            // 
            this.lblTxDateTo.Location = new System.Drawing.Point(253, 66);
            this.lblTxDateTo.Name = "lblTxDateTo";
            this.lblTxDateTo.Size = new System.Drawing.Size(42, 18);
            this.lblTxDateTo.TabIndex = 9;
            this.lblTxDateTo.TabStop = false;
            this.lblTxDateTo.Text = "To";
            // 
            // lblTxDateFrom
            // 
            this.lblTxDateFrom.Location = new System.Drawing.Point(253, 43);
            this.lblTxDateFrom.Name = "lblTxDateFrom";
            this.lblTxDateFrom.Size = new System.Drawing.Size(46, 15);
            this.lblTxDateFrom.TabIndex = 8;
            this.lblTxDateFrom.TabStop = false;
            this.lblTxDateFrom.Text = "From";
            // 
            // lblTxDate
            // 
            this.lblTxDate.Location = new System.Drawing.Point(239, 19);
            this.lblTxDate.Name = "lblTxDate";
            this.lblTxDate.Size = new System.Drawing.Size(60, 17);
            this.lblTxDate.TabIndex = 7;
            this.lblTxDate.TabStop = false;
            this.lblTxDate.Text = "Tx Date:";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(15, 19);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(64, 17);
            this.lblTxNumber.TabIndex = 6;
            this.lblTxNumber.TabStop = false;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(28, 41);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 18);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.TabStop = false;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(28, 66);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 18);
            this.lblTo.TabIndex = 3;
            this.lblTo.TabStop = false;
            this.lblTo.Text = "To";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(393, 128);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Cancel";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(317, 128);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(75, 23);
            this.cmdPreview.TabIndex = 4;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // btnFindFromTxNumber
            // 
            iconResourceHandle2.File = "16x16.16_find.gif";
            this.btnFindFromTxNumber.Image = iconResourceHandle2;
            this.btnFindFromTxNumber.Location = new System.Drawing.Point(201, 36);
            this.btnFindFromTxNumber.Name = "btnFindFromTxNumber";
            this.btnFindFromTxNumber.Size = new System.Drawing.Size(32, 23);
            this.btnFindFromTxNumber.TabIndex = 10;
            this.btnFindFromTxNumber.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnFindFromTxNumber.Click += new System.EventHandler(this.btnFindFromTxNumber_Click);
            // 
            // btnFindToTxNumber
            // 
            iconResourceHandle1.File = "16x16.16_find.gif";
            this.btnFindToTxNumber.Image = iconResourceHandle1;
            this.btnFindToTxNumber.Location = new System.Drawing.Point(201, 61);
            this.btnFindToTxNumber.Name = "btnFindToTxNumber";
            this.btnFindToTxNumber.Size = new System.Drawing.Size(32, 23);
            this.btnFindToTxNumber.TabIndex = 11;
            this.btnFindToTxNumber.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnFindToTxNumber.Click += new System.EventHandler(this.btnFindToTxNumber_Click);
            // 
            // HistoryWizard
            // 
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(484, 163);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Goods Return > Report > History";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDateFrom;
        private Gizmox.WebGUI.Forms.Label lblTxDateTo;
        private Gizmox.WebGUI.Forms.Label lblTxDateFrom;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDateTo;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumberTo;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumberFrom;
        private Gizmox.WebGUI.Forms.Button cmdPreview;
        private Gizmox.WebGUI.Forms.Button btnFindToTxNumber;
        private Gizmox.WebGUI.Forms.Button btnFindFromTxNumber;


    }
}