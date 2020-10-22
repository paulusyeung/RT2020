namespace RT2020.Web.Shop.Transfer
{
    partial class HistoryDetail
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
            this.colConfirmedQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblTotalStock = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalStock = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.lblTotalQty);
            this.splitContainer.Panel1.Controls.Add(this.txtTotalQty);
            this.splitContainer.Panel1.Controls.Add(this.txtTotalStock);
            this.splitContainer.Panel1.Controls.Add(this.lblTotalStock);
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
            this.splitContainer.Size = new System.Drawing.Size(770, 564);
            this.splitContainer.SplitterDistance = 100;
            this.splitContainer.TabIndex = 0;
            // 
            // txtType
            // 
            this.txtType.AutoSize = true;
            this.txtType.BackColor = System.Drawing.Color.Gold;
            this.txtType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtType.Location = new System.Drawing.Point(364, 38);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(49, 14);
            this.txtType.TabIndex = 15;
            this.txtType.Text = "{TYPE}";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblType.Location = new System.Drawing.Point(290, 38);
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
            this.colConfirmedQty});
            this.listView.DataMember = null;
            this.listView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listView.ItemsPerPage = 20;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(770, 460);
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
            // colConfirmedQty
            // 
            this.colConfirmedQty.Image = null;
            this.colConfirmedQty.Text = "CONFIRM QTY";
            this.colConfirmedQty.Width = 100;
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTotalStock.Location = new System.Drawing.Point(16, 61);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(108, 23);
            this.lblTotalStock.TabIndex = 1;
            this.lblTotalStock.Text = "Total Stock:";
            // 
            // txtTotalStock
            // 
            this.txtTotalStock.AutoSize = true;
            this.txtTotalStock.BackColor = System.Drawing.Color.Gold;
            this.txtTotalStock.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTotalStock.Location = new System.Drawing.Point(130, 61);
            this.txtTotalStock.Name = "txtTotalStock";
            this.txtTotalStock.Size = new System.Drawing.Size(82, 14);
            this.txtTotalStock.TabIndex = 3;
            this.txtTotalStock.Text = "{Total Stock}";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.AutoSize = true;
            this.txtTotalQty.BackColor = System.Drawing.Color.Gold;
            this.txtTotalQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTotalQty.Location = new System.Drawing.Point(364, 61);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(71, 14);
            this.txtTotalQty.TabIndex = 15;
            this.txtTotalQty.Text = "{Total Qty}";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTotalQty.Location = new System.Drawing.Point(290, 61);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(63, 14);
            this.lblTotalQty.TabIndex = 14;
            this.lblTotalQty.Text = "Total Qty:";
            // 
            // HistoryDetail
            // 
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(770, 564);
            this.Text = "History Detail";
            this.Load += new System.EventHandler(this.HistoryDetail_Load);
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
        private Gizmox.WebGUI.Forms.ColumnHeader colConfirmedQty;
        private Gizmox.WebGUI.Forms.Label lblTotalQty;
        private Gizmox.WebGUI.Forms.Label txtTotalQty;
        private Gizmox.WebGUI.Forms.Label txtTotalStock;
        private Gizmox.WebGUI.Forms.Label lblTotalStock;


    }
}