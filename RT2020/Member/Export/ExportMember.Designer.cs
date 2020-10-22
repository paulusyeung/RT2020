namespace RT2020.Member.Export
{
    partial class ExportMember
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
            this.lblNumberOfTx = new Gizmox.WebGUI.Forms.Label();
            this.lblTxCount = new Gizmox.WebGUI.Forms.Label();
            this.btnExport = new Gizmox.WebGUI.Forms.Button();
            this.btnClose = new Gizmox.WebGUI.Forms.Button();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
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
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.gbExportType = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtnExportNewRecords = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnExportAllRecords = new Gizmox.WebGUI.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblNumberOfTx
            // 
            this.lblNumberOfTx.Location = new System.Drawing.Point(552, 443);
            this.lblNumberOfTx.Name = "lblNumberOfTx";
            this.lblNumberOfTx.Size = new System.Drawing.Size(98, 23);
            this.lblNumberOfTx.TabIndex = 5;
            this.lblNumberOfTx.Text = "# of Transaction:";
            // 
            // lblTxCount
            // 
            this.lblTxCount.Location = new System.Drawing.Point(656, 443);
            this.lblTxCount.Name = "lblTxCount";
            this.lblTxCount.Size = new System.Drawing.Size(49, 23);
            this.lblTxCount.TabIndex = 6;
            this.lblTxCount.Text = "0";
            this.lblTxCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(465, 420);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(465, 449);
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
            this.lblRemarks.Location = new System.Drawing.Point(552, 388);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(191, 49);
            this.lblRemarks.TabIndex = 9;
            this.lblRemarks.Text = "** Only 20 columns will be shown in the above grid, 80 columns will be imported b" +
                "y \'Import\' function.";
            // 
            // lvColumnNameList
            // 
            this.lvColumnNameList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colColumn,
            this.colFieldName});
            this.lvColumnNameList.ItemsPerPage = 100;
            this.lvColumnNameList.Location = new System.Drawing.Point(555, 12);
            this.lvColumnNameList.Name = "lvColumnNameList";
            this.lvColumnNameList.Size = new System.Drawing.Size(188, 373);
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
            this.lvImportedList.Size = new System.Drawing.Size(537, 373);
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
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(465, 391);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // gbExportType
            // 
            this.gbExportType.Controls.Add(this.rbtnExportNewRecords);
            this.gbExportType.Controls.Add(this.rbtnExportAllRecords);
            this.gbExportType.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbExportType.Location = new System.Drawing.Point(12, 388);
            this.gbExportType.Name = "gbExportType";
            this.gbExportType.Size = new System.Drawing.Size(392, 73);
            this.gbExportType.TabIndex = 13;
            this.gbExportType.Text = "Export Data Type";
            // 
            // rbtnExportNewRecords
            // 
            this.rbtnExportNewRecords.Location = new System.Drawing.Point(17, 43);
            this.rbtnExportNewRecords.Name = "rbtnExportNewRecords";
            this.rbtnExportNewRecords.Size = new System.Drawing.Size(369, 24);
            this.rbtnExportNewRecords.TabIndex = 1;
            this.rbtnExportNewRecords.Text = "Export New Record(s) only";
            // 
            // rbtnExportAllRecords
            // 
            this.rbtnExportAllRecords.Location = new System.Drawing.Point(17, 19);
            this.rbtnExportAllRecords.Name = "rbtnExportAllRecords";
            this.rbtnExportAllRecords.Size = new System.Drawing.Size(369, 24);
            this.rbtnExportAllRecords.TabIndex = 0;
            this.rbtnExportAllRecords.Text = "Export All Record(s)";
            // 
            // ExportMember
            // 
            this.Controls.Add(this.gbExportType);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lvImportedList);
            this.Controls.Add(this.lvColumnNameList);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblTxCount);
            this.Controls.Add(this.lblNumberOfTx);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(755, 480);
            this.Text = "Export Member";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblNumberOfTx;
        private Gizmox.WebGUI.Forms.Label lblTxCount;
        private Gizmox.WebGUI.Forms.Button btnExport;
        private Gizmox.WebGUI.Forms.Button btnClose;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
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
        private Gizmox.WebGUI.Forms.Button btnPreview;
        private Gizmox.WebGUI.Forms.GroupBox gbExportType;
        private Gizmox.WebGUI.Forms.RadioButton rbtnExportNewRecords;
        private Gizmox.WebGUI.Forms.RadioButton rbtnExportAllRecords;


    }
}