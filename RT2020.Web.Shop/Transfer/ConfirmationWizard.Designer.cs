namespace RT2020.Web.Shop.Transfer
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle3 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle4 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.btnFillAll = new Gizmox.WebGUI.Forms.Button();
            this.txtType = new Gizmox.WebGUI.Forms.Label();
            this.lblType = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.txtFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.dgvConfirmationList = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.tbtnSeparator = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnSuspend = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnConfirm = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBar = new Gizmox.WebGUI.Forms.ToolBar();
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
            this.splitContainer.Panel1.Controls.Add(this.btnFillAll);
            this.splitContainer.Panel1.Controls.Add(this.txtType);
            this.splitContainer.Panel1.Controls.Add(this.lblType);
            this.splitContainer.Panel1.Controls.Add(this.txtTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblFromLocation);
            this.splitContainer.Panel1.Controls.Add(this.txtFromLocation);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvConfirmationList);
            this.splitContainer.Size = new System.Drawing.Size(770, 536);
            this.splitContainer.SplitterDistance = 80;
            this.splitContainer.TabIndex = 0;
            // 
            // btnFillAll
            // 
            this.btnFillAll.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnFillAll.Location = new System.Drawing.Point(500, 34);
            this.btnFillAll.Name = "btnFillAll";
            this.btnFillAll.Size = new System.Drawing.Size(75, 23);
            this.btnFillAll.TabIndex = 16;
            this.btnFillAll.Text = "Fill All";
            this.btnFillAll.Click += new System.EventHandler(this.btnFillAll_Click);
            // 
            // txtType
            // 
            this.txtType.AutoSize = true;
            this.txtType.BackColor = System.Drawing.Color.Gold;
            this.txtType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtType.Location = new System.Drawing.Point(319, 38);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(49, 14);
            this.txtType.TabIndex = 15;
            this.txtType.Text = "{TYPE}";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblType.Location = new System.Drawing.Point(272, 38);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 14);
            this.lblType.TabIndex = 14;
            this.lblType.Text = "TYPE:";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.AutoSize = true;
            this.txtTxNumber.BackColor = System.Drawing.Color.Gold;
            this.txtTxNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTxNumber.Location = new System.Drawing.Point(130, 38);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(80, 14);
            this.txtTxNumber.TabIndex = 3;
            this.txtTxNumber.Text = "{Tx Number}";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTxNumber.Location = new System.Drawing.Point(16, 38);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(73, 23);
            this.lblTxNumber.TabIndex = 1;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFromLocation.Location = new System.Drawing.Point(16, 15);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(108, 23);
            this.lblFromLocation.TabIndex = 0;
            this.lblFromLocation.Text = "From Location:";
            // 
            // txtFromLocation
            // 
            this.txtFromLocation.BackColor = System.Drawing.Color.Gold;
            this.txtFromLocation.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFromLocation.Location = new System.Drawing.Point(130, 15);
            this.txtFromLocation.Name = "txtFromLocation";
            this.txtFromLocation.Size = new System.Drawing.Size(119, 14);
            this.txtFromLocation.TabIndex = 2;
            this.txtFromLocation.Text = "{From Location}";
            // 
            // dgvConfirmationList
            // 
            this.dgvConfirmationList.AllowUserToAddRows = false;
            this.dgvConfirmationList.AllowUserToDeleteRows = false;
            this.dgvConfirmationList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.dgvConfirmationList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvConfirmationList.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvConfirmationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvConfirmationList.Location = new System.Drawing.Point(0, 0);
            this.dgvConfirmationList.Name = "dgvConfirmationList";
            this.dgvConfirmationList.Size = new System.Drawing.Size(770, 452);
            this.dgvConfirmationList.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "HeaderId";
            this.dataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn1.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 100;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
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
            this.dataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn3.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Width = 100;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn4.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.Width = 100;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn5.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn5.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.Width = 100;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn6.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn6.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.Width = 100;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn7.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn7.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn7.Width = 100;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn8.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn8.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn8.Width = 100;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ConfirmedQty";
            this.dataGridViewTextBoxColumn9.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn9.FillWeight = 60F;
            this.dataGridViewTextBoxColumn9.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn9.Width = 60;
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
            // tbtnSuspend
            // 
            this.tbtnSuspend.CustomStyle = "";
            iconResourceHandle3.File = "16x16.16_L_save.gif";
            this.tbtnSuspend.Image = iconResourceHandle3;
            this.tbtnSuspend.ImageKey = null;
            this.tbtnSuspend.Name = "tbtnSuspend";
            this.tbtnSuspend.Pushed = true;
            this.tbtnSuspend.Size = 24;
            this.tbtnSuspend.Text = "Suspend";
            this.tbtnSuspend.ToolTipText = "";
            // 
            // tbtnConfirm
            // 
            this.tbtnConfirm.CustomStyle = "";
            iconResourceHandle4.File = "16x16.ico_16_4209.gif";
            this.tbtnConfirm.Image = iconResourceHandle4;
            this.tbtnConfirm.ImageKey = null;
            this.tbtnConfirm.Name = "tbtnConfirm";
            this.tbtnConfirm.Pushed = true;
            this.tbtnConfirm.Size = 24;
            this.tbtnConfirm.Text = "Confirm";
            this.tbtnConfirm.ToolTipText = "";
            // 
            // toolBar
            // 
            this.toolBar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.toolBar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.toolBar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbtnConfirm,
            this.tbtnSeparator,
            this.tbtnSuspend});
            this.toolBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.toolBar.DragHandle = true;
            this.toolBar.DropDownArrows = false;
            this.toolBar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolBar.ImageList = null;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.MenuHandle = true;
            this.toolBar.Name = "toolBar";
            //this.toolBar.RightToLeft = false;
            this.toolBar.ShowToolTips = true;
            this.toolBar.TabIndex = 1;
            this.toolBar.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // ConfirmationWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolBar);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(770, 564);
            this.Text = "Confirmation Wizard";
            this.Load += new System.EventHandler(this.InTransitWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmationList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.Label txtType;
        private Gizmox.WebGUI.Forms.Label lblType;
        private Gizmox.WebGUI.Forms.Label txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Label lblFromLocation;
        private Gizmox.WebGUI.Forms.Label txtFromLocation;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnSeparator;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnSuspend;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnConfirm;
        private Gizmox.WebGUI.Forms.ToolBar toolBar;
        private Gizmox.WebGUI.Forms.Button btnFillAll;
        private Gizmox.WebGUI.Forms.DataGridView dgvConfirmationList;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;


    }
}