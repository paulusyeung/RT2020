namespace RT2020.Product
{
    partial class ProductWizard_Authorization
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
            this.lvHoldBatchList = new Gizmox.WebGUI.Forms.ListView();
            this.colBatchId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPLU = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSeason = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colColor = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSize = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colDescription = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCreatedOn = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPostResult = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.paneTop = new Gizmox.WebGUI.Forms.Panel();
            this.txtRemarks2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRemarks1 = new Gizmox.WebGUI.Forms.TextBox();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnPost = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.btnPrintReport = new Gizmox.WebGUI.Forms.Button();
            this.gbSearchCriteria = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtData = new Gizmox.WebGUI.Forms.TextBox();
            this.btnReload = new Gizmox.WebGUI.Forms.Button();
            this.lblData = new Gizmox.WebGUI.Forms.Label();
            this.cboOperator = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOperator = new Gizmox.WebGUI.Forms.Label();
            this.cboOrdering = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOrdering = new Gizmox.WebGUI.Forms.Label();
            this.cboSortColumn = new Gizmox.WebGUI.Forms.ComboBox();
            this.chkSortAndFilter = new Gizmox.WebGUI.Forms.CheckBox();
            this.gbRecords = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblRecords = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider();
            this.SuspendLayout();
            // 
            // lvHoldBatchList
            // 
            this.lvHoldBatchList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvHoldBatchList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colBatchId,
            this.colMarks,
            this.colLN,
            this.colPLU,
            this.colSeason,
            this.colColor,
            this.colSize,
            this.colDescription,
            this.colCreatedOn,
            this.colPostResult});
            this.lvHoldBatchList.DataMember = null;
            this.lvHoldBatchList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvHoldBatchList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvHoldBatchList.ItemsPerPage = 20;
            this.lvHoldBatchList.Location = new System.Drawing.Point(0, 0);
            this.lvHoldBatchList.Name = "lvHoldBatchList";
            this.lvHoldBatchList.Size = new System.Drawing.Size(650, 459);
            this.lvHoldBatchList.TabIndex = 0;
            this.lvHoldBatchList.UseInternalPaging = true;
            this.lvHoldBatchList.Click += new System.EventHandler(this.lvHoldBatchList_Click);
            // 
            // colBatchId
            // 
            this.colBatchId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colBatchId.Image = null;
            this.colBatchId.Text = "BatchId";
            this.colBatchId.Visible = false;
            this.colBatchId.Width = 40;
            // 
            // colMarks
            // 
            this.colMarks.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMarks.Image = null;
            this.colMarks.Text = "Mark";
            this.colMarks.Width = 40;
            // 
            // colLN
            // 
            this.colLN.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colLN.Width = 30;
            // 
            // colPLU
            // 
            this.colPLU.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Left;
            this.colPLU.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPLU.Image = null;
            this.colPLU.Text = "PLU";
            this.colPLU.Width = 80;
            // 
            // colSeason
            // 
            this.colSeason.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSeason.Image = null;
            this.colSeason.Text = "Season";
            this.colSeason.Width = 80;
            // 
            // colColor
            // 
            this.colColor.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colColor.Image = null;
            this.colColor.Text = "Color";
            this.colColor.Width = 80;
            // 
            // colSize
            // 
            this.colSize.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSize.Image = null;
            this.colSize.Text = "Size";
            this.colSize.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colDescription.Image = null;
            this.colDescription.Text = "Description";
            this.colDescription.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colDescription.Width = 120;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCreatedOn.Image = null;
            this.colCreatedOn.Text = "Date Create";
            this.colCreatedOn.Width = 80;
            // 
            // colPostResult
            // 
            this.colPostResult.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPostResult.Image = null;
            this.colPostResult.Text = "Posting Result";
            this.colPostResult.Width = 80;
            // 
            // paneTop
            // 
            this.paneTop.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.paneTop.Controls.Add(this.txtRemarks2);
            this.paneTop.Controls.Add(this.txtRemarks1);
            this.paneTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.paneTop.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.paneTop.Location = new System.Drawing.Point(0, 0);
            this.paneTop.Name = "paneTop";
            this.paneTop.Size = new System.Drawing.Size(800, 68);
            this.paneTop.TabIndex = 1;
            // 
            // txtRemarks2
            // 
            this.txtRemarks2.BackColor = System.Drawing.Color.LightYellow;
            this.txtRemarks2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtRemarks2.Location = new System.Drawing.Point(12, 38);
            this.txtRemarks2.Name = "txtRemarks2";
            this.txtRemarks2.ReadOnly = true;
            this.txtRemarks2.Size = new System.Drawing.Size(498, 20);
            this.txtRemarks2.TabIndex = 1;
            this.txtRemarks2.Text = "** Only the Status in \"POST\" can be show  **";
            // 
            // txtRemarks1
            // 
            this.txtRemarks1.BackColor = System.Drawing.Color.LightYellow;
            this.txtRemarks1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtRemarks1.Location = new System.Drawing.Point(12, 12);
            this.txtRemarks1.Name = "txtRemarks1";
            this.txtRemarks1.ReadOnly = true;
            this.txtRemarks1.Size = new System.Drawing.Size(498, 20);
            this.txtRemarks1.TabIndex = 0;
            this.txtRemarks1.Text = "** This program is used to post the Stock Data which is in Batch Mode. **";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 68);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvHoldBatchList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnExit);
            this.splitContainer.Panel2.Controls.Add(this.btnPost);
            this.splitContainer.Panel2.Controls.Add(this.btnMarkAll);
            this.splitContainer.Panel2.Controls.Add(this.btnPrintReport);
            this.splitContainer.Panel2.Controls.Add(this.gbSearchCriteria);
            this.splitContainer.Panel2.Controls.Add(this.gbRecords);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(800, 459);
            this.splitContainer.SplitterDistance = 650;
            this.splitContainer.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExit.Location = new System.Drawing.Point(36, 422);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPost
            // 
            this.btnPost.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnPost.Location = new System.Drawing.Point(36, 394);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 4;
            this.btnPost.Text = "Post";
            this.btnPost.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnMarkAll.Location = new System.Drawing.Point(36, 366);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(75, 23);
            this.btnMarkAll.TabIndex = 3;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnMarkAll.Click += new System.EventHandler(this.btnMarkAll_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnPrintReport.Location = new System.Drawing.Point(36, 332);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(75, 23);
            this.btnPrintReport.TabIndex = 2;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // gbSearchCriteria
            // 
            this.gbSearchCriteria.Controls.Add(this.txtData);
            this.gbSearchCriteria.Controls.Add(this.btnReload);
            this.gbSearchCriteria.Controls.Add(this.lblData);
            this.gbSearchCriteria.Controls.Add(this.cboOperator);
            this.gbSearchCriteria.Controls.Add(this.lblOperator);
            this.gbSearchCriteria.Controls.Add(this.cboOrdering);
            this.gbSearchCriteria.Controls.Add(this.lblOrdering);
            this.gbSearchCriteria.Controls.Add(this.cboSortColumn);
            this.gbSearchCriteria.Controls.Add(this.chkSortAndFilter);
            this.gbSearchCriteria.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.gbSearchCriteria.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbSearchCriteria.Location = new System.Drawing.Point(3, 72);
            this.gbSearchCriteria.Name = "gbSearchCriteria";
            this.gbSearchCriteria.Size = new System.Drawing.Size(140, 249);
            this.gbSearchCriteria.TabIndex = 1;
            // 
            // txtData
            // 
            this.txtData.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(9, 189);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(119, 20);
            this.txtData.TabIndex = 9;
            // 
            // btnReload
            // 
            this.btnReload.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(33, 218);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload";
            this.btnReload.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblData
            // 
            this.lblData.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblData.Location = new System.Drawing.Point(6, 163);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(100, 23);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data";
            // 
            // cboOperator
            // 
            this.cboOperator.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOperator.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboOperator.DropDownWidth = 121;
            this.cboOperator.Enabled = false;
            this.cboOperator.Items.AddRange(new object[] {
            "None",
            "Like",
            "="});
            this.cboOperator.Location = new System.Drawing.Point(7, 139);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(121, 21);
            this.cboOperator.TabIndex = 5;
            // 
            // lblOperator
            // 
            this.lblOperator.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblOperator.Location = new System.Drawing.Point(6, 113);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(100, 23);
            this.lblOperator.TabIndex = 4;
            this.lblOperator.Text = "Operator";
            // 
            // cboOrdering
            // 
            this.cboOrdering.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOrdering.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboOrdering.DropDownWidth = 121;
            this.cboOrdering.Enabled = false;
            this.cboOrdering.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cboOrdering.Location = new System.Drawing.Point(7, 89);
            this.cboOrdering.Name = "cboOrdering";
            this.cboOrdering.Size = new System.Drawing.Size(121, 21);
            this.cboOrdering.TabIndex = 3;
            // 
            // lblOrdering
            // 
            this.lblOrdering.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblOrdering.Location = new System.Drawing.Point(6, 63);
            this.lblOrdering.Name = "lblOrdering";
            this.lblOrdering.Size = new System.Drawing.Size(100, 23);
            this.lblOrdering.TabIndex = 2;
            this.lblOrdering.Text = "Ordering";
            // 
            // cboSortColumn
            // 
            this.cboSortColumn.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSortColumn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboSortColumn.DropDownWidth = 121;
            this.cboSortColumn.Enabled = false;
            this.cboSortColumn.Items.AddRange(new object[] {
            "PLU",
            "Season",
            "Color",
            "Size",
            "Description",
            "Date Create(dd/MM/yyyy)"});
            this.cboSortColumn.Location = new System.Drawing.Point(7, 39);
            this.cboSortColumn.Name = "cboSortColumn";
            this.cboSortColumn.Size = new System.Drawing.Size(121, 21);
            this.cboSortColumn.TabIndex = 1;
            // 
            // chkSortAndFilter
            // 
            this.chkSortAndFilter.Checked = false;
            this.chkSortAndFilter.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkSortAndFilter.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkSortAndFilter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkSortAndFilter.Location = new System.Drawing.Point(7, 9);
            this.chkSortAndFilter.Name = "chkSortAndFilter";
            this.chkSortAndFilter.Size = new System.Drawing.Size(124, 24);
            this.chkSortAndFilter.TabIndex = 0;
            this.chkSortAndFilter.Text = "Sort And Filter by";
            this.chkSortAndFilter.ThreeState = false;
            this.chkSortAndFilter.Click += new System.EventHandler(this.chkSortAndFilter_Click);
            // 
            // gbRecords
            // 
            this.gbRecords.Controls.Add(this.lblRecords);
            this.gbRecords.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.gbRecords.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbRecords.Location = new System.Drawing.Point(3, 6);
            this.gbRecords.Name = "gbRecords";
            this.gbRecords.Size = new System.Drawing.Size(140, 60);
            this.gbRecords.TabIndex = 0;
            // 
            // lblRecords
            // 
            this.lblRecords.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblRecords.Location = new System.Drawing.Point(18, 20);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(100, 23);
            this.lblRecords.TabIndex = 0;
            this.lblRecords.Text = "Rec: 0";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // ProductWizard_Authorization
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.paneTop);
            this.Size = new System.Drawing.Size(800, 527);
            this.Text = "ProductWizard_Authorization";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lvHoldBatchList;
        private Gizmox.WebGUI.Forms.ColumnHeader colBatchId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colPLU;
        private Gizmox.WebGUI.Forms.ColumnHeader colSeason;
        private Gizmox.WebGUI.Forms.ColumnHeader colColor;
        private Gizmox.WebGUI.Forms.ColumnHeader colSize;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn;
        private Gizmox.WebGUI.Forms.Panel paneTop;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks2;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks1;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ColumnHeader colPostResult;
        private Gizmox.WebGUI.Forms.GroupBox gbRecords;
        private Gizmox.WebGUI.Forms.Label lblRecords;
        private Gizmox.WebGUI.Forms.GroupBox gbSearchCriteria;
        private Gizmox.WebGUI.Forms.ComboBox cboSortColumn;
        private Gizmox.WebGUI.Forms.CheckBox chkSortAndFilter;
        private Gizmox.WebGUI.Forms.ComboBox cboOrdering;
        private Gizmox.WebGUI.Forms.Label lblOrdering;
        private Gizmox.WebGUI.Forms.Label lblData;
        private Gizmox.WebGUI.Forms.ComboBox cboOperator;
        private Gizmox.WebGUI.Forms.Label lblOperator;
        private Gizmox.WebGUI.Forms.Button btnReload;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnPost;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.Button btnPrintReport;
        private Gizmox.WebGUI.Forms.TextBox txtData;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarks;


    }
}