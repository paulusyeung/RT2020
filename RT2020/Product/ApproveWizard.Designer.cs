namespace RT2020.Product
{
    partial class ApproveWizard
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
            this.components = new System.ComponentModel.Container();
            this.lvwList = new Gizmox.WebGUI.Forms.ListView();
            this.colBatchId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colMarks = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colSTKCODE = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAppendix1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAppendix2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAppendix3 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colDescription = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCreatedOn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPostResult = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.paneTop = new Gizmox.WebGUI.Forms.Panel();
            this.txtRemarks2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRemarks1 = new Gizmox.WebGUI.Forms.TextBox();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnPost = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.btnPrintReport = new Gizmox.WebGUI.Forms.Button();
            this.gbxFilter = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtData = new Gizmox.WebGUI.Forms.TextBox();
            this.btnReload = new Gizmox.WebGUI.Forms.Button();
            this.cboOperator = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboSortColumn = new Gizmox.WebGUI.Forms.ComboBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.paneTop.SuspendLayout();
            this.gbxFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colBatchId,
            this.colMarks,
            this.colLN,
            this.colSTKCODE,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colDescription,
            this.colCreatedOn,
            this.colPostResult});
            this.lvwList.DataMember = null;
            this.lvwList.Location = new System.Drawing.Point(45, 130);
            this.lvwList.Margin = new Gizmox.WebGUI.Forms.Padding(10, 10, 0, 10);
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(552, 175);
            this.lvwList.TabIndex = 0;
            this.lvwList.UseInternalPaging = true;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // colBatchId
            // 
            this.colBatchId.Text = "BatchId";
            this.colBatchId.Visible = false;
            this.colBatchId.Width = 40;
            // 
            // colMarks
            // 
            this.colMarks.Text = "Mark";
            this.colMarks.Width = 40;
            // 
            // colLN
            // 
            this.colLN.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            this.colLN.Text = "LN";
            this.colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colLN.Width = 30;
            // 
            // colSTKCODE
            // 
            this.colSTKCODE.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Left;
            this.colSTKCODE.Text = "PLU";
            this.colSTKCODE.Width = 80;
            // 
            // colAppendix1
            // 
            this.colAppendix1.Text = "Season";
            this.colAppendix1.Width = 80;
            // 
            // colAppendix2
            // 
            this.colAppendix2.Text = "Color";
            this.colAppendix2.Width = 80;
            // 
            // colAppendix3
            // 
            this.colAppendix3.Text = "Size";
            this.colAppendix3.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colDescription.Width = 100;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.Text = "Date Create";
            this.colCreatedOn.Width = 100;
            // 
            // colPostResult
            // 
            this.colPostResult.Text = "Result";
            this.colPostResult.Width = 80;
            // 
            // paneTop
            // 
            this.paneTop.Controls.Add(this.txtRemarks2);
            this.paneTop.Controls.Add(this.txtRemarks1);
            this.paneTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.paneTop.Location = new System.Drawing.Point(0, 0);
            this.paneTop.Name = "paneTop";
            this.paneTop.Size = new System.Drawing.Size(800, 68);
            this.paneTop.TabIndex = 1;
            // 
            // txtRemarks2
            // 
            this.txtRemarks2.BackColor = System.Drawing.Color.LightYellow;
            this.txtRemarks2.Location = new System.Drawing.Point(12, 38);
            this.txtRemarks2.Name = "txtRemarks2";
            this.txtRemarks2.ReadOnly = true;
            this.txtRemarks2.Size = new System.Drawing.Size(498, 20);
            this.txtRemarks2.TabIndex = 1;
            this.txtRemarks2.Text = "** Only those with Status equals \"POST\" are shown. **";
            // 
            // txtRemarks1
            // 
            this.txtRemarks1.BackColor = System.Drawing.Color.LightYellow;
            this.txtRemarks1.Location = new System.Drawing.Point(12, 12);
            this.txtRemarks1.Name = "txtRemarks1";
            this.txtRemarks1.ReadOnly = true;
            this.txtRemarks1.Size = new System.Drawing.Size(498, 20);
            this.txtRemarks1.TabIndex = 0;
            this.txtRemarks1.Text = "** This function is used to post the Stock Data in Batch Mode. **";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(21, 250);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(21, 199);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(100, 23);
            this.btnPost.TabIndex = 4;
            this.btnPost.Text = "Post";
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(21, 171);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(100, 23);
            this.btnMarkAll.TabIndex = 3;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.Click += new System.EventHandler(this.btnMarkAll_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(21, 142);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(100, 23);
            this.btnPrintReport.TabIndex = 2;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // gbxFilter
            // 
            this.gbxFilter.Controls.Add(this.txtData);
            this.gbxFilter.Controls.Add(this.btnReload);
            this.gbxFilter.Controls.Add(this.cboOperator);
            this.gbxFilter.Controls.Add(this.cboSortColumn);
            this.gbxFilter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxFilter.Location = new System.Drawing.Point(10, 0);
            this.gbxFilter.Name = "gbxFilter";
            this.gbxFilter.Size = new System.Drawing.Size(122, 134);
            this.gbxFilter.TabIndex = 1;
            this.gbxFilter.TabStop = false;
            this.gbxFilter.Text = "Filter";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(11, 74);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(100, 20);
            this.txtData.TabIndex = 9;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(11, 100);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(100, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // cboOperator
            // 
            this.cboOperator.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOperator.DropDownWidth = 121;
            this.cboOperator.Items.AddRange(new object[] {
            "None",
            "Like",
            "="});
            this.cboOperator.Location = new System.Drawing.Point(11, 47);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(100, 21);
            this.cboOperator.TabIndex = 5;
            // 
            // cboSortColumn
            // 
            this.cboSortColumn.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSortColumn.DropDownWidth = 121;
            this.cboSortColumn.Items.AddRange(new object[] {
            "PLU",
            "Season",
            "Color",
            "Size",
            "Description",
            "Date Create(dd/MM/yyyy)"});
            this.cboSortColumn.Location = new System.Drawing.Point(11, 21);
            this.cboSortColumn.Name = "cboSortColumn";
            this.cboSortColumn.Size = new System.Drawing.Size(100, 21);
            this.cboSortColumn.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnPost);
            this.panel1.Controls.Add(this.gbxFilter);
            this.panel1.Controls.Add(this.btnMarkAll);
            this.panel1.Controls.Add(this.btnPrintReport);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(655, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 282);
            this.panel1.TabIndex = 3;
            // 
            // ApproveWizard
            // 
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paneTop);
            this.Size = new System.Drawing.Size(800, 350);
            this.Text = "ProductWizard_Authorization";
            this.Load += new System.EventHandler(this.ApproveWizard_Load);
            this.paneTop.ResumeLayout(false);
            this.gbxFilter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lvwList;
        private Gizmox.WebGUI.Forms.ColumnHeader colBatchId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colSTKCODE;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn;
        private Gizmox.WebGUI.Forms.Panel paneTop;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks2;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks1;
        private Gizmox.WebGUI.Forms.ColumnHeader colPostResult;
        private Gizmox.WebGUI.Forms.GroupBox gbxFilter;
        private Gizmox.WebGUI.Forms.ComboBox cboSortColumn;
        private Gizmox.WebGUI.Forms.ComboBox cboOperator;
        private Gizmox.WebGUI.Forms.Button btnReload;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnPost;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.Button btnPrintReport;
        private Gizmox.WebGUI.Forms.TextBox txtData;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarks;
        private Gizmox.WebGUI.Forms.Panel panel1;
    }
}