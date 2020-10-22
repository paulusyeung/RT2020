namespace RT2020.Web.Shop.Transfer
{
    partial class InTransitWizard
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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.txtType = new Gizmox.WebGUI.Forms.Label();
            this.lblType = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.txtFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.listView = new Gizmox.WebGUI.Forms.ListView();
            this.colDetailId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLineNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSTKCODE = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFromLocCDQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRequestQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.tbtnSeparator = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnPrint = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnSave = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBar = new Gizmox.WebGUI.Forms.ToolBar();
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
            this.splitContainer.Panel1.Controls.Add(this.txtType);
            this.splitContainer.Panel1.Controls.Add(this.lblType);
            this.splitContainer.Panel1.Controls.Add(this.txtTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblFromLocation);
            this.splitContainer.Panel1.Controls.Add(this.txtFromLocation);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(770, 536);
            this.splitContainer.SplitterDistance = 80;
            this.splitContainer.TabIndex = 0;
            // 
            // txtType
            // 
            this.txtType.AutoSize = true;
            this.txtType.BackColor = System.Drawing.Color.Gold;
            this.txtType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtType.Location = new System.Drawing.Point(314, 15);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(49, 14);
            this.txtType.TabIndex = 15;
            this.txtType.Text = "{TYPE}";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblType.Location = new System.Drawing.Point(267, 15);
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
            // listView
            // 
            this.listView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.listView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colDetailId,
            this.colLineNumber,
            this.colSTKCODE,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colFromLocCDQty,
            this.colRequestQty});
            this.listView.DataMember = null;
            this.listView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listView.ItemsPerPage = 20;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(770, 452);
            this.listView.TabIndex = 0;
            // 
            // colDetailId
            // 
            this.colDetailId.Image = null;
            this.colDetailId.Text = "DetailId";
            this.colDetailId.Visible = false;
            this.colDetailId.Width = 50;
            // 
            // colLineNumber
            // 
            this.colLineNumber.Image = null;
            this.colLineNumber.Text = "SEQ#";
            this.colLineNumber.Width = 50;
            // 
            // colSTKCODE
            // 
            this.colSTKCODE.Image = null;
            this.colSTKCODE.Text = "STKCODE";
            this.colSTKCODE.Width = 80;
            // 
            // colAppendix1
            // 
            this.colAppendix1.Image = null;
            this.colAppendix1.Text = "Appendix1";
            this.colAppendix1.Width = 80;
            // 
            // colAppendix2
            // 
            this.colAppendix2.Image = null;
            this.colAppendix2.Text = "Appendix2";
            this.colAppendix2.Width = 80;
            // 
            // colAppendix3
            // 
            this.colAppendix3.Image = null;
            this.colAppendix3.Text = "Appendix3";
            this.colAppendix3.Width = 80;
            // 
            // colFromLocCDQty
            // 
            this.colFromLocCDQty.Image = null;
            this.colFromLocCDQty.Text = "C/D QTY";
            this.colFromLocCDQty.Width = 60;
            // 
            // colRequestQty
            // 
            this.colRequestQty.Image = null;
            this.colRequestQty.Text = "REQ QTY";
            this.colRequestQty.Width = 60;
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
            iconResourceHandle1.File = "16x16.16_print.gif";
            this.tbtnPrint.Image = iconResourceHandle1;
            this.tbtnPrint.ImageKey = null;
            this.tbtnPrint.Name = "tbtnPrint";
            this.tbtnPrint.Pushed = true;
            this.tbtnPrint.Size = 24;
            this.tbtnPrint.Text = "Print";
            this.tbtnPrint.ToolTipText = "";
            // 
            // tbtnSave
            // 
            this.tbtnSave.CustomStyle = "";
            iconResourceHandle2.File = "16x16.16_L_save.gif";
            this.tbtnSave.Image = iconResourceHandle2;
            this.tbtnSave.ImageKey = null;
            this.tbtnSave.Name = "tbtnSave";
            this.tbtnSave.Pushed = true;
            this.tbtnSave.Size = 24;
            this.tbtnSave.Text = "Save";
            this.tbtnSave.ToolTipText = "";
            // 
            // toolBar
            // 
            this.toolBar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.toolBar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.toolBar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbtnSave,
            this.tbtnSeparator,
            this.tbtnPrint});
            this.toolBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.toolBar.DragHandle = true;
            this.toolBar.DropDownArrows = false;
            this.toolBar.Enabled = false;
            this.toolBar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolBar.ImageList = null;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.MenuHandle = true;
            this.toolBar.Name = "toolBar";
            //this.toolBar.RightToLeft = false;
            this.toolBar.ShowToolTips = true;
            this.toolBar.TabIndex = 1;
            // 
            // InTransitWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolBar);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(770, 564);
            this.Text = "In Transit Wizard";
            this.Load += new System.EventHandler(this.InTransitWizard_Load);
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
        private Gizmox.WebGUI.Forms.ListView listView;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colSTKCODE;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colFromLocCDQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colRequestQty;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnSeparator;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnPrint;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnSave;
        private Gizmox.WebGUI.Forms.ToolBar toolBar;


    }
}