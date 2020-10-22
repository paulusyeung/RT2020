namespace RT2020.Web.Shop.Transfer
{
    partial class InTransit
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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
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
            this.colType});
            this.listView.DataMember = null;
            this.listView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.ItemsPerPage = 20;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(712, 473);
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
            this.colTransferDate.Text = "Transfer Date";
            this.colTransferDate.Width = 100;
            // 
            // colType
            // 
            this.colType.Image = null;
            this.colType.Text = "Type";
            this.colType.Width = 100;
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
            this.splitContainer.Panel1.Controls.Add(this.btnLookup);
            this.splitContainer.Panel1.Controls.Add(this.txtLookupTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblTxNumber);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(712, 527);
            this.splitContainer.TabIndex = 0;
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
            // InTransit
            // 
            this.Controls.Add(this.splitContainer);
            this.Size = new System.Drawing.Size(712, 527);
            this.Text = "InTransit";
            this.Load += new System.EventHandler(this.InTransit_Load);
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


    }
}