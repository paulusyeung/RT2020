namespace RT2020.Inventory.GoodsReceive.Import
{
    partial class ImportTxt
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
            this.lvImportedList = new Gizmox.WebGUI.Forms.ListView();
            this.colCAPNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLocation = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colOperator = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRecvDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSupplierNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRef = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblNumberOfTransaction = new Gizmox.WebGUI.Forms.Label();
            this.lblTxCount = new Gizmox.WebGUI.Forms.Label();
            this.lblFileName = new Gizmox.WebGUI.Forms.Label();
            this.txtFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.btnBrowserFile = new Gizmox.WebGUI.Forms.Button();
            this.btnInfo = new Gizmox.WebGUI.Forms.Button();
            this.btnImport = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.openFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.colMessage = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvImportedList
            // 
            this.lvImportedList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colCAPNumber,
            this.colLocation,
            this.colOperator,
            this.colRecvDate,
            this.colSupplierNumber,
            this.colRef,
            this.colRemarks,
            this.colMessage});
            this.lvImportedList.DataMember = null;
            this.lvImportedList.ItemsPerPage = 20;
            this.lvImportedList.Location = new System.Drawing.Point(12, 31);
            this.lvImportedList.Name = "lvImportedList";
            this.lvImportedList.Size = new System.Drawing.Size(782, 373);
            this.lvImportedList.TabIndex = 0;
            // 
            // colCAPNumber
            // 
            this.colCAPNumber.Image = null;
            this.colCAPNumber.Text = "CAP#";
            this.colCAPNumber.Width = 80;
            // 
            // colLocation
            // 
            this.colLocation.Image = null;
            this.colLocation.Text = "LOC#";
            this.colLocation.Width = 80;
            // 
            // colOperator
            // 
            this.colOperator.Image = null;
            this.colOperator.Text = "Operator";
            this.colOperator.Width = 80;
            // 
            // colRecvDate
            // 
            this.colRecvDate.Image = null;
            this.colRecvDate.Text = "Rec. Date";
            this.colRecvDate.Width = 80;
            // 
            // colSupplierNumber
            // 
            this.colSupplierNumber.Image = null;
            this.colSupplierNumber.Text = "Supplier#";
            this.colSupplierNumber.Width = 80;
            // 
            // colRef
            // 
            this.colRef.Image = null;
            this.colRef.Text = "Ref#";
            this.colRef.Width = 80;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remark(s)";
            this.colRemarks.Width = 80;
            // 
            // lblNumberOfTransaction
            // 
            this.lblNumberOfTransaction.Location = new System.Drawing.Point(588, 9);
            this.lblNumberOfTransaction.Name = "lblNumberOfTransaction";
            this.lblNumberOfTransaction.Size = new System.Drawing.Size(100, 19);
            this.lblNumberOfTransaction.TabIndex = 1;
            this.lblNumberOfTransaction.Text = "# of Transactions:";
            // 
            // lblTxCount
            // 
            this.lblTxCount.Location = new System.Drawing.Point(694, 9);
            this.lblTxCount.Name = "lblTxCount";
            this.lblTxCount.Size = new System.Drawing.Size(100, 19);
            this.lblTxCount.TabIndex = 2;
            this.lblTxCount.Text = "0";
            // 
            // lblFileName
            // 
            this.lblFileName.Location = new System.Drawing.Point(12, 419);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(70, 23);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.LightYellow;
            this.txtFileName.Location = new System.Drawing.Point(88, 416);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(336, 20);
            this.txtFileName.TabIndex = 4;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnBrowserFile
            // 
            this.btnBrowserFile.Location = new System.Drawing.Point(430, 414);
            this.btnBrowserFile.Name = "btnBrowserFile";
            this.btnBrowserFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowserFile.TabIndex = 5;
            this.btnBrowserFile.Text = "...";
            this.btnBrowserFile.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnBrowserFile.Click += new System.EventHandler(this.btnBrowserFile_Click);
            // 
            // btnInfo
            // 
            iconResourceHandle1.File = "16x16.16_info.gif";
            this.btnInfo.Image = iconResourceHandle1;
            this.btnInfo.Location = new System.Drawing.Point(466, 414);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(28, 23);
            this.btnInfo.TabIndex = 6;
            this.btnInfo.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(630, 414);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(711, 414);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "TXT files|*.txt";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // colMessage
            // 
            this.colMessage.Image = null;
            this.colMessage.Text = "Message";
            this.colMessage.Width = 150;
            // 
            // ImportTxt
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnBrowserFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblTxCount);
            this.Controls.Add(this.lblNumberOfTransaction);
            this.Controls.Add(this.lvImportedList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 446);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "CAP Text file Import";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lvImportedList;
        private Gizmox.WebGUI.Forms.ColumnHeader colCAPNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colLocation;
        private Gizmox.WebGUI.Forms.ColumnHeader colOperator;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecvDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colSupplierNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colRef;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private Gizmox.WebGUI.Forms.Label lblNumberOfTransaction;
        private Gizmox.WebGUI.Forms.Label lblTxCount;
        private Gizmox.WebGUI.Forms.Label lblFileName;
        private Gizmox.WebGUI.Forms.TextBox txtFileName;
        private Gizmox.WebGUI.Forms.Button btnBrowserFile;
        private Gizmox.WebGUI.Forms.Button btnInfo;
        private Gizmox.WebGUI.Forms.Button btnImport;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog;
        private Gizmox.WebGUI.Forms.ColumnHeader colMessage;


    }
}