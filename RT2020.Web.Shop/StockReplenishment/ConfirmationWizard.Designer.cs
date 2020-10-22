namespace RT2020.Web.Shop.StockReplenishment
{
    partial class ConfirmationWizard
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle3 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.btnRefresh = new Gizmox.WebGUI.Forms.Button();
            this.btnFillAll = new Gizmox.WebGUI.Forms.Button();
            this.txtTotalActualQty = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalActualQty = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.dgvConfirmationList = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.toolBar = new Gizmox.WebGUI.Forms.ToolBar();
            this.tbtnConfirm = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnSuspend = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnSeparator = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnPrint = new Gizmox.WebGUI.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmationList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer.Panel1.Controls.Add(this.btnFillAll);
            this.splitContainer.Panel1.Controls.Add(this.txtTotalActualQty);
            this.splitContainer.Panel1.Controls.Add(this.lblTotalActualQty);
            this.splitContainer.Panel1.Controls.Add(this.txtTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.txtFromLocation);
            this.splitContainer.Panel1.Controls.Add(this.lblTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblFromLocation);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvConfirmationList);
            this.splitContainer.Size = new System.Drawing.Size(770, 536);
            this.splitContainer.SplitterDistance = 120;
            this.splitContainer.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(646, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFillAll
            // 
            this.btnFillAll.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnFillAll.Location = new System.Drawing.Point(646, 78);
            this.btnFillAll.Name = "btnFillAll";
            this.btnFillAll.Size = new System.Drawing.Size(75, 23);
            this.btnFillAll.TabIndex = 6;
            this.btnFillAll.Text = "Fill All";
            this.btnFillAll.Click += new System.EventHandler(this.btnFillAll_Click);
            // 
            // txtTotalActualQty
            // 
            this.txtTotalActualQty.AutoSize = true;
            this.txtTotalActualQty.BackColor = System.Drawing.Color.Gold;
            this.txtTotalActualQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTotalActualQty.Location = new System.Drawing.Point(516, 21);
            this.txtTotalActualQty.Name = "txtTotalActualQty";
            this.txtTotalActualQty.Size = new System.Drawing.Size(109, 14);
            this.txtTotalActualQty.TabIndex = 5;
            this.txtTotalActualQty.Text = "{Total Actual Qty}";
            // 
            // lblTotalActualQty
            // 
            this.lblTotalActualQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTotalActualQty.Location = new System.Drawing.Point(391, 21);
            this.lblTotalActualQty.Name = "lblTotalActualQty";
            this.lblTotalActualQty.Size = new System.Drawing.Size(119, 23);
            this.lblTotalActualQty.TabIndex = 4;
            this.lblTotalActualQty.Text = "Total Actual Qty:";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.AutoSize = true;
            this.txtTxNumber.BackColor = System.Drawing.Color.Gold;
            this.txtTxNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTxNumber.Location = new System.Drawing.Point(133, 55);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(55, 14);
            this.txtTxNumber.TabIndex = 3;
            this.txtTxNumber.Text = "{TRN #}";
            // 
            // txtFromLocation
            // 
            this.txtFromLocation.AutoSize = true;
            this.txtFromLocation.BackColor = System.Drawing.Color.Gold;
            this.txtFromLocation.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFromLocation.Location = new System.Drawing.Point(133, 21);
            this.txtFromLocation.Name = "txtFromLocation";
            this.txtFromLocation.Size = new System.Drawing.Size(78, 14);
            this.txtFromLocation.TabIndex = 2;
            this.txtFromLocation.Text = "{From Loc#}";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTxNumber.Location = new System.Drawing.Point(46, 55);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(81, 23);
            this.lblTxNumber.TabIndex = 1;
            this.lblTxNumber.Text = "TRN #:";
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFromLocation.Location = new System.Drawing.Point(46, 21);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(81, 23);
            this.lblFromLocation.TabIndex = 0;
            this.lblFromLocation.Text = "From Loc#:";
            // 
            // dgvConfirmationList
            // 
            this.dgvConfirmationList.AllowUserToAddRows = false;
            this.dgvConfirmationList.AllowUserToDeleteRows = false;
            this.dgvConfirmationList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.dgvConfirmationList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvConfirmationList.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvConfirmationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvConfirmationList.Location = new System.Drawing.Point(0, 0);
            this.dgvConfirmationList.Name = "dgvConfirmationList";
            this.dgvConfirmationList.Size = new System.Drawing.Size(770, 412);
            this.dgvConfirmationList.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DetailsId";
            this.dataGridViewTextBoxColumn8.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn8.HeaderText = "DetailsId";
            this.dataGridViewTextBoxColumn8.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 100;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "HeaderId";
            this.dataGridViewTextBoxColumn9.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn9.HeaderText = "HeaderId";
            this.dataGridViewTextBoxColumn9.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 100;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ProductId";
            this.dataGridViewTextBoxColumn10.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn10.HeaderText = "ProductId";
            this.dataGridViewTextBoxColumn10.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn10.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 100;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "STKCODE";
            this.dataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn1.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.Width = 100;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "APPENDIX1";
            this.dataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn2.HeaderText = "APPENDIX1";
            this.dataGridViewTextBoxColumn2.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.Width = 100;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "APPENDIX2";
            this.dataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn3.HeaderText = "APPENDIX2";
            this.dataGridViewTextBoxColumn3.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Width = 100;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "APPENDIX3";
            this.dataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn4.HeaderText = "APPENDIX3";
            this.dataGridViewTextBoxColumn4.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.Width = 100;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "From_CDQTY";
            this.dataGridViewTextBoxColumn5.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn5.HeaderText = "FM C/D Qty";
            this.dataGridViewTextBoxColumn5.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.Width = 100;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "QtyRequested";
            this.dataGridViewTextBoxColumn6.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn6.HeaderText = "RPL Qty";
            this.dataGridViewTextBoxColumn6.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.Width = 100;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ActualQty";
            this.dataGridViewTextBoxColumn7.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn7.HeaderText = "Actual Qty";
            this.dataGridViewTextBoxColumn7.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn7.Width = 100;
            // 
            // toolBar
            // 
            this.toolBar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.toolBar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.toolBar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbtnConfirm,
            this.tbtnSuspend,
            this.tbtnSeparator,
            this.tbtnPrint});
            this.toolBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.toolBar.DragHandle = true;
            this.toolBar.DropDownArrows = false;
            this.toolBar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolBar.ImageList = null;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.MenuHandle = true;
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.TabIndex = 1;
            this.toolBar.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbtnConfirm
            // 
            this.tbtnConfirm.CustomStyle = "";
            iconResourceHandle1.File = "16x16.ico_16_4209.gif";
            this.tbtnConfirm.Image = iconResourceHandle1;
            this.tbtnConfirm.ImageKey = null;
            this.tbtnConfirm.Name = "tbtnConfirm";
            this.tbtnConfirm.Pushed = true;
            this.tbtnConfirm.Size = 24;
            this.tbtnConfirm.Text = "Confirm";
            this.tbtnConfirm.ToolTipText = "";
            // 
            // tbtnSuspend
            // 
            this.tbtnSuspend.CustomStyle = "";
            iconResourceHandle2.File = "16x16.16_L_save.gif";
            this.tbtnSuspend.Image = iconResourceHandle2;
            this.tbtnSuspend.ImageKey = null;
            this.tbtnSuspend.Name = "tbtnSuspend";
            this.tbtnSuspend.Pushed = true;
            this.tbtnSuspend.Size = 24;
            this.tbtnSuspend.Text = "Suspend";
            this.tbtnSuspend.ToolTipText = "";
            // 
            // tbtnSeparator
            // 
            this.tbtnSeparator.CustomStyle = "";
            this.tbtnSeparator.ImageKey = null;
            this.tbtnSeparator.Name = "tbtnSeparator";
            this.tbtnSeparator.Pushed = true;
            this.tbtnSeparator.Size = 24;
            this.tbtnSeparator.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.tbtnSeparator.ToolTipText = "";
            // 
            // tbtnPrint
            // 
            this.tbtnPrint.CustomStyle = "";
            iconResourceHandle3.File = "16x16.16_print.gif";
            this.tbtnPrint.Image = iconResourceHandle3;
            this.tbtnPrint.ImageKey = null;
            this.tbtnPrint.Name = "tbtnPrint";
            this.tbtnPrint.Pushed = true;
            this.tbtnPrint.Size = 24;
            this.tbtnPrint.Text = "Print";
            this.tbtnPrint.ToolTipText = "";
            // 
            // ConfirmationWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolBar);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(770, 564);
            this.Text = "Confirmation Wizard";
            this.Load += new System.EventHandler(this.ConfirmationWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmationList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ToolBar toolBar;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnConfirm;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnSuspend;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnSeparator;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnPrint;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Label lblFromLocation;
        private Gizmox.WebGUI.Forms.Label txtTotalActualQty;
        private Gizmox.WebGUI.Forms.Label lblTotalActualQty;
        private Gizmox.WebGUI.Forms.Label txtTxNumber;
        private Gizmox.WebGUI.Forms.Label txtFromLocation;
        private Gizmox.WebGUI.Forms.DataGridView dgvConfirmationList;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private Gizmox.WebGUI.Forms.Button btnFillAll;
        private Gizmox.WebGUI.Forms.Button btnRefresh;


    }
}