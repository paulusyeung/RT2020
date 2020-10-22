namespace RT2020.Member.Import
{
    partial class ImportMember
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
            this.lblFileName = new Gizmox.WebGUI.Forms.Label();
            this.txtFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.btnBrowserFile = new Gizmox.WebGUI.Forms.Button();
            this.lblNumberOfTx = new Gizmox.WebGUI.Forms.Label();
            this.lblTxCount = new Gizmox.WebGUI.Forms.Label();
            this.btnImport = new Gizmox.WebGUI.Forms.Button();
            this.btnClose = new Gizmox.WebGUI.Forms.Button();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.openFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.lvColumnNameList = new Gizmox.WebGUI.Forms.ListView();
            this.colColumn = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFieldName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lvImportedList = new Gizmox.WebGUI.Forms.ListView();
            this.colVIPNum = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colGroup = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSalute = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colNName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAddress1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAddress2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAddress3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAddress4 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTeleWork = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTeleHome = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTeleP = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFax = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colEmail = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSex = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colNRDisc = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colGrade = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.Location = new System.Drawing.Point(12, 440);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(60, 23);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.LightYellow;
            this.txtFileName.Location = new System.Drawing.Point(78, 437);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(408, 20);
            this.txtFileName.TabIndex = 3;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnBrowserFile
            // 
            this.btnBrowserFile.Location = new System.Drawing.Point(492, 434);
            this.btnBrowserFile.Name = "btnBrowserFile";
            this.btnBrowserFile.Size = new System.Drawing.Size(57, 23);
            this.btnBrowserFile.TabIndex = 4;
            this.btnBrowserFile.Text = "...";
            this.btnBrowserFile.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnBrowserFile.Click += new System.EventHandler(this.btnBrowserFile_Click);
            // 
            // lblNumberOfTx
            // 
            this.lblNumberOfTx.Location = new System.Drawing.Point(590, 439);
            this.lblNumberOfTx.Name = "lblNumberOfTx";
            this.lblNumberOfTx.Size = new System.Drawing.Size(98, 23);
            this.lblNumberOfTx.TabIndex = 5;
            this.lblNumberOfTx.Text = "# of Transaction:";
            // 
            // lblTxCount
            // 
            this.lblTxCount.Location = new System.Drawing.Point(694, 439);
            this.lblTxCount.Name = "lblTxCount";
            this.lblTxCount.Size = new System.Drawing.Size(49, 23);
            this.lblTxCount.TabIndex = 6;
            this.lblTxCount.Text = "0";
            this.lblTxCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(586, 468);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(668, 468);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Exit";
            this.btnClose.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRemarks
            // 
            this.lblRemarks.ForeColor = System.Drawing.Color.Red;
            this.lblRemarks.Location = new System.Drawing.Point(9, 473);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(540, 23);
            this.lblRemarks.TabIndex = 9;
            this.lblRemarks.Text = "** Only 20 columns will be shown in the above grid, 80 columns will be imported b" +
                "y \'Import\' function.";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "|*.txt";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // lvColumnNameList
            // 
            this.lvColumnNameList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colColumn,
            this.colFieldName});
            this.lvColumnNameList.ItemsPerPage = 100;
            this.lvColumnNameList.Location = new System.Drawing.Point(555, 12);
            this.lvColumnNameList.Name = "lvColumnNameList";
            this.lvColumnNameList.Size = new System.Drawing.Size(188, 409);
            this.lvColumnNameList.TabIndex = 10;
            // 
            // colColumn
            // 
            this.colColumn.Image = null;
            this.colColumn.Text = "Column";
            this.colColumn.Width = 50;
            // 
            // colFieldName
            // 
            this.colFieldName.Image = null;
            this.colFieldName.Text = "Field Name";
            this.colFieldName.Width = 100;
            // 
            // lvImportedList
            // 
            this.lvImportedList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colVIPNum,
            this.colGroup,
            this.colSalute,
            this.colLName,
            this.colFName,
            this.colNName,
            this.colAddress1,
            this.colAddress2,
            this.colAddress3,
            this.colAddress4,
            this.colTeleWork,
            this.colTeleHome,
            this.colTeleP,
            this.colFax,
            this.colEmail,
            this.colSex,
            this.colRace,
            this.colRemarks,
            this.colNRDisc,
            this.colGrade});
            this.lvImportedList.ItemsPerPage = 20;
            this.lvImportedList.Location = new System.Drawing.Point(12, 12);
            this.lvImportedList.Name = "lvImportedList";
            this.lvImportedList.Size = new System.Drawing.Size(537, 409);
            this.lvImportedList.TabIndex = 11;
            // 
            // colVIPNum
            // 
            this.colVIPNum.Image = null;
            this.colVIPNum.Text = "VIP #";
            this.colVIPNum.Width = 80;
            // 
            // colGroup
            // 
            this.colGroup.Image = null;
            this.colGroup.Text = "Group";
            this.colGroup.Width = 50;
            // 
            // colSalute
            // 
            this.colSalute.Image = null;
            this.colSalute.Text = "Salute";
            this.colSalute.Width = 50;
            // 
            // colLName
            // 
            this.colLName.Image = null;
            this.colLName.Text = "L. Name";
            this.colLName.Width = 80;
            // 
            // colFName
            // 
            this.colFName.Image = null;
            this.colFName.Text = "F. Name";
            this.colFName.Width = 80;
            // 
            // colNName
            // 
            this.colNName.Image = null;
            this.colNName.Text = "N. Name";
            this.colNName.Width = 80;
            // 
            // colAddress1
            // 
            this.colAddress1.Image = null;
            this.colAddress1.Text = "Address1";
            this.colAddress1.Width = 150;
            // 
            // colAddress2
            // 
            this.colAddress2.Image = null;
            this.colAddress2.Text = "Address 2";
            this.colAddress2.Width = 150;
            // 
            // colAddress3
            // 
            this.colAddress3.Image = null;
            this.colAddress3.Text = "Address 3";
            this.colAddress3.Width = 150;
            // 
            // colAddress4
            // 
            this.colAddress4.Image = null;
            this.colAddress4.Text = "Address 4";
            this.colAddress4.Width = 150;
            // 
            // colTeleWork
            // 
            this.colTeleWork.Image = null;
            this.colTeleWork.Text = "Tel. W.";
            this.colTeleWork.Width = 60;
            // 
            // colTeleHome
            // 
            this.colTeleHome.Image = null;
            this.colTeleHome.Text = "Tel. H.";
            this.colTeleHome.Width = 60;
            // 
            // colTeleP
            // 
            this.colTeleP.Image = null;
            this.colTeleP.Text = "Tel. P.";
            this.colTeleP.Width = 60;
            // 
            // colFax
            // 
            this.colFax.Image = null;
            this.colFax.Text = "Fax";
            this.colFax.Width = 60;
            // 
            // colEmail
            // 
            this.colEmail.Image = null;
            this.colEmail.Text = "E-Mail";
            this.colEmail.Width = 70;
            // 
            // colSex
            // 
            this.colSex.Image = null;
            this.colSex.Text = "Sex";
            this.colSex.Width = 40;
            // 
            // colRace
            // 
            this.colRace.Image = null;
            this.colRace.Text = "Race";
            this.colRace.Width = 40;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // colNRDisc
            // 
            this.colNRDisc.Image = null;
            this.colNRDisc.Text = "Normal Discount";
            this.colNRDisc.Width = 70;
            // 
            // colGrade
            // 
            this.colGrade.Image = null;
            this.colGrade.Text = "Grade";
            this.colGrade.Width = 70;
            // 
            // ImportMember
            // 
            this.Controls.Add(this.lvImportedList);
            this.Controls.Add(this.lvColumnNameList);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblTxCount);
            this.Controls.Add(this.lblNumberOfTx);
            this.Controls.Add(this.btnBrowserFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(755, 503);
            this.Text = "Import Member";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblFileName;
        private Gizmox.WebGUI.Forms.TextBox txtFileName;
        private Gizmox.WebGUI.Forms.Button btnBrowserFile;
        private Gizmox.WebGUI.Forms.Label lblNumberOfTx;
        private Gizmox.WebGUI.Forms.Label lblTxCount;
        private Gizmox.WebGUI.Forms.Button btnImport;
        private Gizmox.WebGUI.Forms.Button btnClose;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog;
        private Gizmox.WebGUI.Forms.ListView lvColumnNameList;
        private Gizmox.WebGUI.Forms.ColumnHeader colColumn;
        private Gizmox.WebGUI.Forms.ColumnHeader colFieldName;
        private Gizmox.WebGUI.Forms.ListView lvImportedList;
        private Gizmox.WebGUI.Forms.ColumnHeader colVIPNum;
        private Gizmox.WebGUI.Forms.ColumnHeader colGroup;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalute;
        private Gizmox.WebGUI.Forms.ColumnHeader colLName;
        private Gizmox.WebGUI.Forms.ColumnHeader colFName;
        private Gizmox.WebGUI.Forms.ColumnHeader colNName;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddress1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddress2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddress3;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddress4;
        private Gizmox.WebGUI.Forms.ColumnHeader colTeleWork;
        private Gizmox.WebGUI.Forms.ColumnHeader colTeleHome;
        private Gizmox.WebGUI.Forms.ColumnHeader colTeleP;
        private Gizmox.WebGUI.Forms.ColumnHeader colFax;
        private Gizmox.WebGUI.Forms.ColumnHeader colEmail;
        private Gizmox.WebGUI.Forms.ColumnHeader colSex;
        private Gizmox.WebGUI.Forms.ColumnHeader colRace;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private Gizmox.WebGUI.Forms.ColumnHeader colNRDisc;
        private Gizmox.WebGUI.Forms.ColumnHeader colGrade;


    }
}