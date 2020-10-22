namespace RT2020.Inventory.StockTake.Import
{
    partial class ImportFromPoS
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
            this.lblStockTakeNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblWorkplaceCode = new Gizmox.WebGUI.Forms.Label();
            this.lblHHTID = new Gizmox.WebGUI.Forms.Label();
            this.txtStockTakeNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtWorkplaceCode = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHHTID = new Gizmox.WebGUI.Forms.TextBox();
            this.lblUploadedOn = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.txtUploadedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.lvUploadList = new Gizmox.WebGUI.Forms.ListView();
            this.colFileName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHHT = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnImportData = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.lblStatus = new Gizmox.WebGUI.Forms.Label();
            this.txtStatus = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblStockTakeNumber
            // 
            this.lblStockTakeNumber.AutoSize = true;
            this.lblStockTakeNumber.Location = new System.Drawing.Point(21, 19);
            this.lblStockTakeNumber.Name = "lblStockTakeNumber";
            this.lblStockTakeNumber.Size = new System.Drawing.Size(100, 23);
            this.lblStockTakeNumber.TabIndex = 0;
            this.lblStockTakeNumber.Text = "Stock Take#";
            // 
            // lblWorkplaceCode
            // 
            this.lblWorkplaceCode.AutoSize = true;
            this.lblWorkplaceCode.Location = new System.Drawing.Point(21, 45);
            this.lblWorkplaceCode.Name = "lblWorkplaceCode";
            this.lblWorkplaceCode.Size = new System.Drawing.Size(100, 23);
            this.lblWorkplaceCode.TabIndex = 1;
            this.lblWorkplaceCode.Text = "Location Code";
            // 
            // lblHHTID
            // 
            this.lblHHTID.AutoSize = true;
            this.lblHHTID.Location = new System.Drawing.Point(21, 71);
            this.lblHHTID.Name = "lblHHTID";
            this.lblHHTID.Size = new System.Drawing.Size(100, 23);
            this.lblHHTID.TabIndex = 2;
            this.lblHHTID.Text = "HHT ID";
            // 
            // txtStockTakeNumber
            // 
            this.txtStockTakeNumber.Enabled = false;
            this.txtStockTakeNumber.Location = new System.Drawing.Point(116, 16);
            this.txtStockTakeNumber.Name = "txtStockTakeNumber";
            this.txtStockTakeNumber.Size = new System.Drawing.Size(143, 20);
            this.txtStockTakeNumber.TabIndex = 3;
            // 
            // txtWorkplaceCode
            // 
            this.txtWorkplaceCode.Enabled = false;
            this.txtWorkplaceCode.Location = new System.Drawing.Point(116, 42);
            this.txtWorkplaceCode.Name = "txtWorkplaceCode";
            this.txtWorkplaceCode.Size = new System.Drawing.Size(143, 20);
            this.txtWorkplaceCode.TabIndex = 4;
            // 
            // txtHHTID
            // 
            this.txtHHTID.Enabled = false;
            this.txtHHTID.Location = new System.Drawing.Point(116, 68);
            this.txtHHTID.Name = "txtHHTID";
            this.txtHHTID.Size = new System.Drawing.Size(143, 20);
            this.txtHHTID.TabIndex = 5;
            // 
            // lblUploadedOn
            // 
            this.lblUploadedOn.AutoSize = true;
            this.lblUploadedOn.Location = new System.Drawing.Point(277, 19);
            this.lblUploadedOn.Name = "lblUploadedOn";
            this.lblUploadedOn.Size = new System.Drawing.Size(100, 23);
            this.lblUploadedOn.TabIndex = 6;
            this.lblUploadedOn.Text = "Upload On";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(277, 45);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 7;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtUploadedOn
            // 
            this.txtUploadedOn.Enabled = false;
            this.txtUploadedOn.Location = new System.Drawing.Point(355, 16);
            this.txtUploadedOn.Name = "txtUploadedOn";
            this.txtUploadedOn.Size = new System.Drawing.Size(215, 20);
            this.txtUploadedOn.TabIndex = 8;
            this.txtUploadedOn.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(355, 42);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(215, 20);
            this.txtRemarks.TabIndex = 9;
            // 
            // lvUploadList
            // 
            this.lvUploadList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colFileName,
            this.colTxNumber,
            this.colWorkplaceCode,
            this.colStatus,
            this.colRemarks,
            this.colHHT});
            this.lvUploadList.DataMember = null;
            this.lvUploadList.ItemsPerPage = 20;
            this.lvUploadList.Location = new System.Drawing.Point(12, 103);
            this.lvUploadList.Name = "lvUploadList";
            this.lvUploadList.Size = new System.Drawing.Size(635, 404);
            this.lvUploadList.TabIndex = 10;
            this.lvUploadList.Click += new System.EventHandler(this.lvUploadList_Click);
            // 
            // colFileName
            // 
            this.colFileName.Image = null;
            this.colFileName.Text = "File Name";
            this.colFileName.Width = 100;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "Trn#";
            this.colTxNumber.Width = 80;
            // 
            // colWorkplaceCode
            // 
            this.colWorkplaceCode.Image = null;
            this.colWorkplaceCode.Text = "Shop#";
            this.colWorkplaceCode.Width = 60;
            // 
            // colStatus
            // 
            this.colStatus.Image = null;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 60;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // colHHT
            // 
            this.colHHT.Image = null;
            this.colHHT.Text = "HHT";
            this.colHHT.Visible = false;
            this.colHHT.Width = 150;
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(669, 483);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(75, 23);
            this.btnImportData.TabIndex = 11;
            this.btnImportData.Text = "Import";
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(669, 512);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(21, 517);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status";
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(79, 514);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(568, 20);
            this.txtStatus.TabIndex = 14;
            this.txtStatus.Text = "Data Transform from POS Data successfully";
            // 
            // ImportFromPoS
            // 
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImportData);
            this.Controls.Add(this.lvUploadList);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtUploadedOn);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblUploadedOn);
            this.Controls.Add(this.txtHHTID);
            this.Controls.Add(this.txtWorkplaceCode);
            this.Controls.Add(this.txtStockTakeNumber);
            this.Controls.Add(this.lblHHTID);
            this.Controls.Add(this.lblWorkplaceCode);
            this.Controls.Add(this.lblStockTakeNumber);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(756, 547);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import From PoS";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblStockTakeNumber;
        private Gizmox.WebGUI.Forms.Label lblWorkplaceCode;
        private Gizmox.WebGUI.Forms.Label lblHHTID;
        private Gizmox.WebGUI.Forms.TextBox txtStockTakeNumber;
        private Gizmox.WebGUI.Forms.TextBox txtWorkplaceCode;
        private Gizmox.WebGUI.Forms.TextBox txtHHTID;
        private Gizmox.WebGUI.Forms.Label lblUploadedOn;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.TextBox txtUploadedOn;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.ListView lvUploadList;
        private Gizmox.WebGUI.Forms.Button btnImportData;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Label lblStatus;
        private Gizmox.WebGUI.Forms.TextBox txtStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colFileName;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private Gizmox.WebGUI.Forms.ColumnHeader colHHT;


    }
}