namespace RT2020.Web.Shop.Transfer
{
    partial class History
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
            this.listView = new Gizmox.WebGUI.Forms.ListView();
            this.colHeaderId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFromLoc = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTransferDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTotalQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.dtpTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.chkIncludesDateRange = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnLookup = new Gizmox.WebGUI.Forms.Button();
            this.txtLookupTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.listView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colHeaderId,
            this.colTxNumber,
            this.colFromLoc,
            this.colTxDate,
            this.colTransferDate,
            this.colType,
            this.colTotalQty});
            this.listView.DataMember = null;
            this.listView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.ItemsPerPage = 20;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(760, 473);
            this.listView.TabIndex = 0;
            this.listView.UseInternalPaging = true;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // colHeaderId
            // 
            this.colHeaderId.Image = null;
            this.colHeaderId.Text = "HeaderId";
            this.colHeaderId.Visible = false;
            this.colHeaderId.Width = 50;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "TRN #";
            this.colTxNumber.Width = 100;
            // 
            // colFromLoc
            // 
            this.colFromLoc.Image = null;
            this.colFromLoc.Text = "From Loc#";
            this.colFromLoc.Width = 100;
            // 
            // colTxDate
            // 
            this.colTxDate.Image = null;
            this.colTxDate.Text = "TRN Date";
            this.colTxDate.Width = 100;
            // 
            // colTransferDate
            // 
            this.colTransferDate.Image = null;
            this.colTransferDate.Text = "Transfer-In Confirm Date";
            this.colTransferDate.Width = 150;
            // 
            // colType
            // 
            this.colType.Image = null;
            this.colType.Text = "Type";
            this.colType.Width = 100;
            // 
            // colTotalQty
            // 
            this.colTotalQty.Image = null;
            this.colTotalQty.Text = "Total Qty";
            this.colTotalQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colTotalQty.Width = 80;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer.Panel1.Controls.Add(this.lblFrom);
            this.splitContainer.Panel1.Controls.Add(this.lblTo);
            this.splitContainer.Panel1.Controls.Add(this.dtpTo);
            this.splitContainer.Panel1.Controls.Add(this.dtpFrom);
            this.splitContainer.Panel1.Controls.Add(this.chkIncludesDateRange);
            this.splitContainer.Panel1.Controls.Add(this.btnLookup);
            this.splitContainer.Panel1.Controls.Add(this.txtLookupTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblTxNumber);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(760, 527);
            this.splitContainer.TabIndex = 0;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Enabled = false;
            this.lblFrom.Location = new System.Drawing.Point(428, 17);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(31, 13);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Enabled = false;
            this.lblTo.Location = new System.Drawing.Point(579, 17);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(19, 13);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Enabled = false;
            this.dtpTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(614, 14);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(78, 20);
            this.dtpTo.TabIndex = 5;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(473, 14);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(81, 20);
            this.dtpFrom.TabIndex = 4;
            // 
            // chkIncludesDateRange
            // 
            this.chkIncludesDateRange.Checked = true;
            this.chkIncludesDateRange.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkIncludesDateRange.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkIncludesDateRange.Location = new System.Drawing.Point(318, 12);
            this.chkIncludesDateRange.Name = "chkIncludesDateRange";
            this.chkIncludesDateRange.Size = new System.Drawing.Size(104, 24);
            this.chkIncludesDateRange.TabIndex = 3;
            this.chkIncludesDateRange.Text = "Confirm Date:";
            this.chkIncludesDateRange.ThreeState = false;
            this.chkIncludesDateRange.Click += new System.EventHandler(this.chkIncludesDateRange_Click);
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(213, 12);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 23);
            this.btnLookup.TabIndex = 2;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // txtLookupTxNumber
            // 
            this.txtLookupTxNumber.Location = new System.Drawing.Point(89, 14);
            this.txtLookupTxNumber.Name = "txtLookupTxNumber";
            this.txtLookupTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtLookupTxNumber.TabIndex = 1;
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(33, 17);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(50, 23);
            this.lblTxNumber.TabIndex = 0;
            this.lblTxNumber.Text = "TRN #:";
            // 
            // History
            // 
            this.Controls.Add(this.splitContainer);
            this.Size = new System.Drawing.Size(760, 527);
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView listView;
        private Gizmox.WebGUI.Forms.ColumnHeader colHeaderId;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colFromLoc;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colTransferDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colType;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.Button btnLookup;
        private Gizmox.WebGUI.Forms.TextBox txtLookupTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colTotalQty;
        private Gizmox.WebGUI.Forms.CheckBox chkIncludesDateRange;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFrom;


    }
}