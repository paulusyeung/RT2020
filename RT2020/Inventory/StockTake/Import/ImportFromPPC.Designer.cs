namespace RT2020.Inventory.StockTake.Import
{
    partial class ImportFromPPC
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
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.gbGeneralInfo = new Gizmox.WebGUI.Forms.GroupBox();
            this.selectedDataCtrl = new RT2020.Inventory.StockTake.Import.ImportFromPPC_DataSelectionCtrl();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnSave = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.btnLoadPacketList = new Gizmox.WebGUI.Forms.Button();
            this.txtStockTakeNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStockTakeTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblHHTTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtHHTTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblHHTId = new Gizmox.WebGUI.Forms.Label();
            this.txtHHTId = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUploadOn = new Gizmox.WebGUI.Forms.TextBox();
            this.lblUploadOn = new Gizmox.WebGUI.Forms.Label();
            this.lbPacketList = new Gizmox.WebGUI.Forms.ListBox();
            this.lblPacketList = new Gizmox.WebGUI.Forms.Label();
            this.lblLedgendOfStockTakeNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblRecordNotFound = new Gizmox.WebGUI.Forms.Label();
            this.lblMessage = new Gizmox.WebGUI.Forms.Label();
            this.lvPPCPacketList = new Gizmox.WebGUI.Forms.ListView();
            this.colLocation = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStockTakeNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHHTTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colUploadOn = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHHTId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colShelfNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFileName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colOriginLoc = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colOriginStockTake = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnHelp = new Gizmox.WebGUI.Forms.Button();
            this.openFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.gbGeneralInfo);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(753, 570);
            this.mainPane.TabIndex = 1;
            // 
            // gbGeneralInfo
            // 
            this.gbGeneralInfo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbGeneralInfo.Controls.Add(this.selectedDataCtrl);
            this.gbGeneralInfo.Controls.Add(this.btnExit);
            this.gbGeneralInfo.Controls.Add(this.btnSave);
            this.gbGeneralInfo.Controls.Add(this.btnMarkAll);
            this.gbGeneralInfo.Controls.Add(this.btnLoadPacketList);
            this.gbGeneralInfo.Controls.Add(this.txtStockTakeNumber);
            this.gbGeneralInfo.Controls.Add(this.lblStockTakeTxNumber);
            this.gbGeneralInfo.Controls.Add(this.lblHHTTxNumber);
            this.gbGeneralInfo.Controls.Add(this.txtHHTTxNumber);
            this.gbGeneralInfo.Controls.Add(this.lblHHTId);
            this.gbGeneralInfo.Controls.Add(this.txtHHTId);
            this.gbGeneralInfo.Controls.Add(this.txtUploadOn);
            this.gbGeneralInfo.Controls.Add(this.lblUploadOn);
            this.gbGeneralInfo.Controls.Add(this.lbPacketList);
            this.gbGeneralInfo.Controls.Add(this.lblPacketList);
            this.gbGeneralInfo.Controls.Add(this.lblLedgendOfStockTakeNumber);
            this.gbGeneralInfo.Controls.Add(this.lblRecordNotFound);
            this.gbGeneralInfo.Controls.Add(this.lblMessage);
            this.gbGeneralInfo.Controls.Add(this.lvPPCPacketList);
            this.gbGeneralInfo.Controls.Add(this.btnHelp);
            this.gbGeneralInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.gbGeneralInfo.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbGeneralInfo.Location = new System.Drawing.Point(6, 6);
            this.gbGeneralInfo.Name = "gbGeneralInfo";
            this.gbGeneralInfo.Size = new System.Drawing.Size(741, 558);
            this.gbGeneralInfo.TabIndex = 0;
            this.gbGeneralInfo.Text = "General Info";
            // 
            // selectedDataCtrl
            // 
            this.selectedDataCtrl.HasChanged = false;
            this.selectedDataCtrl.HHTTxNumber = " ";
            this.selectedDataCtrl.Location = new System.Drawing.Point(111, 167);
            this.selectedDataCtrl.Name = "selectedDataCtrl";
            this.selectedDataCtrl.SelectedIndex = 0;
            this.selectedDataCtrl.Size = new System.Drawing.Size(326, 190);
            this.selectedDataCtrl.StockTakeNumber = " ";
            this.selectedDataCtrl.TabIndex = 13;
            this.selectedDataCtrl.Text = "ImportFromPPC_DataSelectionCtrl";
            this.selectedDataCtrl.Visible = false;
            this.selectedDataCtrl.Workplace = " ";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(596, 487);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(596, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(596, 417);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(96, 23);
            this.btnMarkAll.TabIndex = 10;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.Click += new System.EventHandler(this.btnMarkAll_Click);
            // 
            // btnLoadPacketList
            // 
            this.btnLoadPacketList.Location = new System.Drawing.Point(596, 382);
            this.btnLoadPacketList.Name = "btnLoadPacketList";
            this.btnLoadPacketList.Size = new System.Drawing.Size(96, 23);
            this.btnLoadPacketList.TabIndex = 9;
            this.btnLoadPacketList.Text = "Load Packet List";
            this.btnLoadPacketList.Click += new System.EventHandler(this.btnLoadPacketList_Click);
            // 
            // txtStockTakeNumber
            // 
            this.txtStockTakeNumber.Enabled = false;
            this.txtStockTakeNumber.Location = new System.Drawing.Point(561, 307);
            this.txtStockTakeNumber.Name = "txtStockTakeNumber";
            this.txtStockTakeNumber.Size = new System.Drawing.Size(174, 20);
            this.txtStockTakeNumber.TabIndex = 8;
            // 
            // lblStockTakeTxNumber
            // 
            this.lblStockTakeTxNumber.AutoSize = true;
            this.lblStockTakeTxNumber.Location = new System.Drawing.Point(559, 294);
            this.lblStockTakeTxNumber.Name = "lblStockTakeTxNumber";
            this.lblStockTakeTxNumber.Size = new System.Drawing.Size(100, 23);
            this.lblStockTakeTxNumber.TabIndex = 7;
            this.lblStockTakeTxNumber.Text = "Stock Take#";
            // 
            // lblHHTTxNumber
            // 
            this.lblHHTTxNumber.AutoSize = true;
            this.lblHHTTxNumber.Location = new System.Drawing.Point(559, 261);
            this.lblHHTTxNumber.Name = "lblHHTTxNumber";
            this.lblHHTTxNumber.Size = new System.Drawing.Size(100, 23);
            this.lblHHTTxNumber.TabIndex = 7;
            this.lblHHTTxNumber.Text = "HHT TRN#";
            // 
            // txtHHTTxNumber
            // 
            this.txtHHTTxNumber.Enabled = false;
            this.txtHHTTxNumber.Location = new System.Drawing.Point(561, 274);
            this.txtHHTTxNumber.Name = "txtHHTTxNumber";
            this.txtHHTTxNumber.Size = new System.Drawing.Size(174, 20);
            this.txtHHTTxNumber.TabIndex = 8;
            // 
            // lblHHTId
            // 
            this.lblHHTId.AutoSize = true;
            this.lblHHTId.Location = new System.Drawing.Point(559, 228);
            this.lblHHTId.Name = "lblHHTId";
            this.lblHHTId.Size = new System.Drawing.Size(100, 23);
            this.lblHHTId.TabIndex = 7;
            this.lblHHTId.Text = "HHT ID";
            // 
            // txtHHTId
            // 
            this.txtHHTId.Enabled = false;
            this.txtHHTId.Location = new System.Drawing.Point(561, 241);
            this.txtHHTId.Name = "txtHHTId";
            this.txtHHTId.Size = new System.Drawing.Size(174, 20);
            this.txtHHTId.TabIndex = 8;
            // 
            // txtUploadOn
            // 
            this.txtUploadOn.Enabled = false;
            this.txtUploadOn.Location = new System.Drawing.Point(561, 208);
            this.txtUploadOn.Name = "txtUploadOn";
            this.txtUploadOn.Size = new System.Drawing.Size(174, 20);
            this.txtUploadOn.TabIndex = 8;
            // 
            // lblUploadOn
            // 
            this.lblUploadOn.AutoSize = true;
            this.lblUploadOn.Location = new System.Drawing.Point(559, 195);
            this.lblUploadOn.Name = "lblUploadOn";
            this.lblUploadOn.Size = new System.Drawing.Size(100, 23);
            this.lblUploadOn.TabIndex = 7;
            this.lblUploadOn.Text = "Upload Date/Time";
            // 
            // lbPacketList
            // 
            this.lbPacketList.Location = new System.Drawing.Point(561, 35);
            this.lbPacketList.Name = "lbPacketList";
            this.lbPacketList.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.lbPacketList.Size = new System.Drawing.Size(174, 147);
            this.lbPacketList.TabIndex = 6;
            this.lbPacketList.Click += new System.EventHandler(this.lbPacketList_Click);
            // 
            // lblPacketList
            // 
            this.lblPacketList.AutoSize = true;
            this.lblPacketList.Location = new System.Drawing.Point(558, 19);
            this.lblPacketList.Name = "lblPacketList";
            this.lblPacketList.Size = new System.Drawing.Size(100, 23);
            this.lblPacketList.TabIndex = 5;
            this.lblPacketList.Text = "Packet List";
            // 
            // lblLedgendOfStockTakeNumber
            // 
            this.lblLedgendOfStockTakeNumber.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lblLedgendOfStockTakeNumber.Location = new System.Drawing.Point(457, 536);
            this.lblLedgendOfStockTakeNumber.Name = "lblLedgendOfStockTakeNumber";
            this.lblLedgendOfStockTakeNumber.Size = new System.Drawing.Size(71, 13);
            this.lblLedgendOfStockTakeNumber.TabIndex = 4;
            this.lblLedgendOfStockTakeNumber.Text = "Stock Take#";
            this.lblLedgendOfStockTakeNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecordNotFound
            // 
            this.lblRecordNotFound.Location = new System.Drawing.Point(340, 536);
            this.lblRecordNotFound.Name = "lblRecordNotFound";
            this.lblRecordNotFound.Size = new System.Drawing.Size(97, 13);
            this.lblRecordNotFound.TabIndex = 3;
            this.lblRecordNotFound.Text = "Record Not Found";
            this.lblRecordNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(6, 536);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(100, 23);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "** Double Click the Target to update LOC# and Stock Take#";
            // 
            // lvPPCPacketList
            // 
            this.lvPPCPacketList.CheckBoxes = true;
            this.lvPPCPacketList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colLocation,
            this.colStockTakeNumber,
            this.colHHTTxNumber,
            this.colUploadOn,
            this.colHHTId,
            this.colShelfNumber,
            this.colQty,
            this.colRemarks,
            this.colFileName,
            this.colOriginLoc,
            this.colOriginStockTake});
            this.lvPPCPacketList.DataMember = null;
            this.lvPPCPacketList.ItemsPerPage = 20;
            this.lvPPCPacketList.Location = new System.Drawing.Point(6, 19);
            this.lvPPCPacketList.Name = "lvPPCPacketList";
            this.lvPPCPacketList.Size = new System.Drawing.Size(546, 511);
            this.lvPPCPacketList.TabIndex = 1;
            this.lvPPCPacketList.DoubleClick += new System.EventHandler(this.lvPPCPacketList_DoubleClick);
            // 
            // colLocation
            // 
            this.colLocation.Image = null;
            this.colLocation.Text = "LOC#";
            this.colLocation.Width = 60;
            // 
            // colStockTakeNumber
            // 
            this.colStockTakeNumber.Image = null;
            this.colStockTakeNumber.Text = "Stock Take#";
            this.colStockTakeNumber.Width = 100;
            // 
            // colHHTTxNumber
            // 
            this.colHHTTxNumber.Image = null;
            this.colHHTTxNumber.Text = "HHT TRN#";
            this.colHHTTxNumber.Width = 100;
            // 
            // colUploadOn
            // 
            this.colUploadOn.Image = null;
            this.colUploadOn.Text = "Upload Time";
            this.colUploadOn.Width = 100;
            // 
            // colHHTId
            // 
            this.colHHTId.Image = null;
            this.colHHTId.Text = "HHT ID";
            this.colHHTId.Width = 80;
            // 
            // colShelfNumber
            // 
            this.colShelfNumber.Image = null;
            this.colShelfNumber.Text = "# of Shelf";
            this.colShelfNumber.Width = 60;
            // 
            // colQty
            // 
            this.colQty.Image = null;
            this.colQty.Text = "Qty";
            this.colQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colQty.Width = 60;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // colFileName
            // 
            this.colFileName.Image = null;
            this.colFileName.Text = "File Name";
            this.colFileName.Visible = false;
            this.colFileName.Width = 150;
            // 
            // colOriginLoc
            // 
            this.colOriginLoc.Image = null;
            this.colOriginLoc.Text = "OriginLoc";
            this.colOriginLoc.Visible = false;
            this.colOriginLoc.Width = 150;
            // 
            // colOriginStockTake
            // 
            this.colOriginStockTake.Image = null;
            this.colOriginStockTake.Text = "OriginStockTake";
            this.colOriginStockTake.Visible = false;
            this.colOriginStockTake.Width = 150;
            // 
            // btnHelp
            // 
            iconResourceHandle1.File = "16x16.16_help.gif";
            this.btnHelp.Image = iconResourceHandle1;
            this.btnHelp.Location = new System.Drawing.Point(712, 0);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 23);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "TXT files|*.txt";
            this.openFileDialog.MaxFileSize = 10240;
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // ImportFromPPC
            // 
            this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.mainPane);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(753, 570);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import From PPC";
            this.Closed += new System.EventHandler(this.ImportFromPPC_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.GroupBox gbGeneralInfo;
        private Gizmox.WebGUI.Forms.Button btnHelp;
        private Gizmox.WebGUI.Forms.ListView lvPPCPacketList;
        private Gizmox.WebGUI.Forms.ColumnHeader colLocation;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockTakeNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colHHTTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colUploadOn;
        private Gizmox.WebGUI.Forms.ColumnHeader colHHTId;
        private Gizmox.WebGUI.Forms.ColumnHeader colShelfNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private Gizmox.WebGUI.Forms.Label lblLedgendOfStockTakeNumber;
        private Gizmox.WebGUI.Forms.Label lblRecordNotFound;
        private Gizmox.WebGUI.Forms.Label lblMessage;
        private Gizmox.WebGUI.Forms.TextBox txtStockTakeNumber;
        private Gizmox.WebGUI.Forms.Label lblStockTakeTxNumber;
        private Gizmox.WebGUI.Forms.Label lblHHTTxNumber;
        private Gizmox.WebGUI.Forms.TextBox txtHHTTxNumber;
        private Gizmox.WebGUI.Forms.Label lblHHTId;
        private Gizmox.WebGUI.Forms.TextBox txtHHTId;
        private Gizmox.WebGUI.Forms.TextBox txtUploadOn;
        private Gizmox.WebGUI.Forms.Label lblUploadOn;
        private Gizmox.WebGUI.Forms.ListBox lbPacketList;
        private Gizmox.WebGUI.Forms.Label lblPacketList;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnSave;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.Button btnLoadPacketList;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog;
        private ImportFromPPC_DataSelectionCtrl selectedDataCtrl;
        private Gizmox.WebGUI.Forms.ColumnHeader colFileName;
        private Gizmox.WebGUI.Forms.ColumnHeader colOriginLoc;
        private Gizmox.WebGUI.Forms.ColumnHeader colOriginStockTake;


    }
}