namespace RT2020.Inventory.Transfer.Import
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
            this.colTransactionNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFromLocation = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colToLocation = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colOperator = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxferDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCompletedDate = new Gizmox.WebGUI.Forms.ColumnHeader();
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
            this.SuspendLayout();
            // 
            // lvImportedList
            // 
            this.lvImportedList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTransactionNumber,
            this.colFromLocation,
            this.colToLocation,
            this.colOperator,
            this.colTxDate,
            this.colTxferDate,
            this.colCompletedDate,
            this.colRef,
            this.colRemarks});
            this.lvImportedList.DataMember = null;
            this.lvImportedList.ItemsPerPage = 20;
            this.lvImportedList.Location = new System.Drawing.Point(12, 31);
            this.lvImportedList.Name = "lvImportedList";
            this.lvImportedList.Size = new System.Drawing.Size(782, 373);
            this.lvImportedList.TabIndex = 0;
            // 
            // colTransactionNumber
            // 
            this.colTransactionNumber.Image = null;
            this.colTransactionNumber.Text = "Tx Number";
            this.colTransactionNumber.Width = 80;
            // 
            // colFromLocation
            // 
            this.colFromLocation.Image = null;
            this.colFromLocation.Text = "From Location";
            this.colFromLocation.Width = 80;
            // 
            // colToLocation
            // 
            this.colToLocation.Image = null;
            this.colToLocation.Text = "To Location";
            this.colToLocation.Width = 80;
            // 
            // colOperator
            // 
            this.colOperator.Image = null;
            this.colOperator.Text = "Operator";
            this.colOperator.Width = 80;
            // 
            // colTxDate
            // 
            this.colTxDate.Image = null;
            this.colTxDate.Text = "Tx Date";
            this.colTxDate.Width = 80;
            // 
            // colTxferDate
            // 
            this.colTxferDate.Image = null;
            this.colTxferDate.Text = "Txfer Date";
            this.colTxferDate.Width = 80;
            // 
            // colCompletedDate
            // 
            this.colCompletedDate.Image = null;
            this.colCompletedDate.Text = "Comp. Date";
            this.colCompletedDate.Width = 80;
            // 
            // colRef
            // 
            this.colRef.Image = null;
            this.colRef.Text = "Ref.";
            this.colRef.Width = 80;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remarks";
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
            this.txtFileName.Location = new System.Drawing.Point(88, 416);
            this.txtFileName.Name = "txtFileName";
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "TXT files|*.txt";
            this.openFileDialog.Title = "Select text file to import";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
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
            this.Text = "Transfer Import Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lvImportedList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTransactionNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colFromLocation;
        private Gizmox.WebGUI.Forms.ColumnHeader colToLocation;
        private Gizmox.WebGUI.Forms.ColumnHeader colOperator;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxferDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colCompletedDate;
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


    }
}