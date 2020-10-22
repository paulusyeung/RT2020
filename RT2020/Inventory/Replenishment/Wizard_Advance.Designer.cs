namespace RT2020.Inventory.Replenishment
{
    partial class Wizard_Advance
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
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.chkShowItemDescription = new Gizmox.WebGUI.Forms.CheckBox();
            this.tabGoodsRpl = new Gizmox.WebGUI.Forms.TabControl();
            this.rpRecord = new Gizmox.WebGUI.Forms.TabPage();
            this.dgvRecord = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.rpDetail = new Gizmox.WebGUI.Forms.TabPage();
            this.dgvDetail = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.tpReference = new Gizmox.WebGUI.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxNumber.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtTxNumber.ClientAction = null;
            this.txtTxNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtTxNumber.Location = new System.Drawing.Point(105, 43);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 11;
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.ClientAction = null;
            this.lblTxNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTxNumber.Location = new System.Drawing.Point(23, 46);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(76, 23);
            this.lblTxNumber.TabIndex = 10;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.ClientAction = null;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 0;
            // 
            // chkShowItemDescription
            // 
            this.chkShowItemDescription.Checked = false;
            this.chkShowItemDescription.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowItemDescription.ClientAction = null;
            this.chkShowItemDescription.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkShowItemDescription.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowItemDescription.Location = new System.Drawing.Point(250, 45);
            this.chkShowItemDescription.Name = "chkShowItemDescription";
            this.chkShowItemDescription.Size = new System.Drawing.Size(145, 24);
            this.chkShowItemDescription.TabIndex = 12;
            this.chkShowItemDescription.Text = "Show Item Description";
            this.chkShowItemDescription.ThreeState = false;
            // 
            // tabGoodsRpl
            // 
            this.tabGoodsRpl.ClientAction = null;
            this.tabGoodsRpl.Controls.Add(this.rpRecord);
            this.tabGoodsRpl.Controls.Add(this.rpDetail);
            this.tabGoodsRpl.Controls.Add(this.tpReference);
            this.tabGoodsRpl.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tabGoodsRpl.Location = new System.Drawing.Point(12, 83);
            this.tabGoodsRpl.Multiline = false;
            this.tabGoodsRpl.Name = "tabGoodsRpl";
            this.tabGoodsRpl.SelectedIndex = 0;
            this.tabGoodsRpl.ShowCloseButton = false;
            this.tabGoodsRpl.Size = new System.Drawing.Size(774, 405);
            this.tabGoodsRpl.TabIndex = 13;
            // 
            // rpRecord
            // 
            this.rpRecord.ClientAction = null;
            this.rpRecord.Controls.Add(this.dgvRecord);
            this.rpRecord.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.rpRecord.Location = new System.Drawing.Point(4, 22);
            this.rpRecord.Name = "rpRecord";
            this.rpRecord.Size = new System.Drawing.Size(766, 379);
            this.rpRecord.TabIndex = 0;
            this.rpRecord.Text = "Record";
            // 
            // dgvRecord
            // 
            this.dgvRecord.AllowUserToAddRows = false;
            this.dgvRecord.AllowUserToDeleteRows = false;
            this.dgvRecord.AllowUserToResizeColumns = false;
            this.dgvRecord.AllowUserToResizeRows = false;
            this.dgvRecord.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.dgvRecord.ClientAction = null;
            this.dgvRecord.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvRecord.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvRecord.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dgvRecord.Location = new System.Drawing.Point(0, 0);
            this.dgvRecord.Name = "dgvRecord";
            this.dgvRecord.Size = new System.Drawing.Size(766, 379);
            this.dgvRecord.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn1.HeaderText = "Caption";
            this.dataGridViewTextBoxColumn1.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn2.HeaderText = "Data";
            this.dataGridViewTextBoxColumn2.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.Width = 260;
            // 
            // rpDetail
            // 
            this.rpDetail.ClientAction = null;
            this.rpDetail.Controls.Add(this.dgvDetail);
            this.rpDetail.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.rpDetail.Location = new System.Drawing.Point(4, 22);
            this.rpDetail.Name = "rpDetail";
            this.rpDetail.Size = new System.Drawing.Size(766, 379);
            this.rpDetail.TabIndex = 0;
            this.rpDetail.Text = "Detail";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.dgvDetail.ClientAction = null;
            this.dgvDetail.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvDetail.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetail.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.Size = new System.Drawing.Size(766, 379);
            this.dgvDetail.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn3.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Width = 100;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn4.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.Width = 100;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn5.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn5.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.Width = 100;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn6.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn6.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.Width = 100;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn7.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn7.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn7.Width = 100;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn8.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn8.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn8.Width = 100;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn9.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn9.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn9.Width = 100;
            // 
            // tpReference
            // 
            this.tpReference.ClientAction = null;
            this.tpReference.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tpReference.Enabled = false;
            this.tpReference.Location = new System.Drawing.Point(4, 22);
            this.tpReference.Name = "tpReference";
            this.tpReference.Size = new System.Drawing.Size(766, 379);
            this.tpReference.TabIndex = 1;
            this.tpReference.Text = "Reference";
            this.tpReference.Visible = false;
            // 
            // Wizard_Advance
            // 
            this.Controls.Add(this.tabGoodsRpl);
            this.Controls.Add(this.chkShowItemDescription);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.txtTxNumber);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replenishment > Wizard > Advance";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.CheckBox chkShowItemDescription;
        private Gizmox.WebGUI.Forms.TabControl tabGoodsRpl;
        private Gizmox.WebGUI.Forms.TabPage rpRecord;
        private Gizmox.WebGUI.Forms.TabPage rpDetail;
        private Gizmox.WebGUI.Forms.DataGridView dgvRecord;
        private Gizmox.WebGUI.Forms.DataGridView dgvDetail;
        private Gizmox.WebGUI.Forms.TabPage tpReference;
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