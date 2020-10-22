namespace RT2020.Inventory.Transfer.Import
{
    partial class AdvanceImport
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
            this.tabTxferImportAdvance = new Gizmox.WebGUI.Forms.TabControl();
            this.tpSummary = new Gizmox.WebGUI.Forms.TabPage();
            this.lvSummaryList = new Gizmox.WebGUI.Forms.ListView();
            this.colMark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBarcodeMatchedItems = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBarcodeUnmatchedItems = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRequiredMatchedItems = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRequiredUnmatchedItems = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProcessMessage = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblFileName = new Gizmox.WebGUI.Forms.Label();
            this.txtFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.btnBrowserFile = new Gizmox.WebGUI.Forms.Button();
            this.tpBarcode_MatchedItems = new Gizmox.WebGUI.Forms.TabPage();
            this.tpBarcode_UnMatchedItems = new Gizmox.WebGUI.Forms.TabPage();
            this.tpRequired_MatchedItems = new Gizmox.WebGUI.Forms.TabPage();
            this.tpRequired_UnMatchedItems = new Gizmox.WebGUI.Forms.TabPage();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblDay = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.lblMonth = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblYear = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.btnFileStructure = new Gizmox.WebGUI.Forms.Button();
            this.chkAccumulate = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnReadFile = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.btnImport = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.openFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tabTxferImportAdvance
            // 
            this.tabTxferImportAdvance.Controls.Add(this.tpSummary);
            this.tabTxferImportAdvance.Controls.Add(this.tpBarcode_MatchedItems);
            this.tabTxferImportAdvance.Controls.Add(this.tpBarcode_UnMatchedItems);
            this.tabTxferImportAdvance.Controls.Add(this.tpRequired_MatchedItems);
            this.tabTxferImportAdvance.Controls.Add(this.tpRequired_UnMatchedItems);
            this.tabTxferImportAdvance.Location = new System.Drawing.Point(12, 12);
            this.tabTxferImportAdvance.Multiline = false;
            this.tabTxferImportAdvance.Name = "tabTxferImportAdvance";
            this.tabTxferImportAdvance.SelectedIndex = 0;
            this.tabTxferImportAdvance.ShowCloseButton = false;
            this.tabTxferImportAdvance.Size = new System.Drawing.Size(706, 587);
            this.tabTxferImportAdvance.TabIndex = 0;
            // 
            // tpSummary
            // 
            this.tpSummary.Controls.Add(this.lvSummaryList);
            this.tpSummary.Controls.Add(this.lblFileName);
            this.tpSummary.Controls.Add(this.txtFileName);
            this.tpSummary.Controls.Add(this.btnBrowserFile);
            this.tpSummary.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpSummary.Location = new System.Drawing.Point(4, 22);
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Size = new System.Drawing.Size(698, 561);
            this.tpSummary.TabIndex = 0;
            this.tpSummary.Text = "Summary";
            // 
            // lvSummaryList
            // 
            this.lvSummaryList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colMark,
            this.colTxNumber,
            this.colBarcodeMatchedItems,
            this.colBarcodeUnmatchedItems,
            this.colRequiredMatchedItems,
            this.colRequiredUnmatchedItems,
            this.colRemarks,
            this.colProcessMessage});
            this.lvSummaryList.DataMember = null;
            this.lvSummaryList.ItemsPerPage = 20;
            this.lvSummaryList.Location = new System.Drawing.Point(6, 43);
            this.lvSummaryList.Name = "lvSummaryList";
            this.lvSummaryList.Size = new System.Drawing.Size(686, 512);
            this.lvSummaryList.TabIndex = 6;
            // 
            // colMark
            // 
            this.colMark.Image = null;
            this.colMark.Text = "Mark";
            this.colMark.Width = 40;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "Tx Number";
            this.colTxNumber.Width = 80;
            // 
            // colBarcodeMatchedItems
            // 
            this.colBarcodeMatchedItems.Image = null;
            this.colBarcodeMatchedItems.Text = "Matched(Barcode)";
            this.colBarcodeMatchedItems.Width = 100;
            // 
            // colBarcodeUnmatchedItems
            // 
            this.colBarcodeUnmatchedItems.Image = null;
            this.colBarcodeUnmatchedItems.Text = "Unmatched(Barcode)";
            this.colBarcodeUnmatchedItems.Width = 100;
            // 
            // colRequiredMatchedItems
            // 
            this.colRequiredMatchedItems.Image = null;
            this.colRequiredMatchedItems.Text = "Matched(Required)";
            this.colRequiredMatchedItems.Width = 100;
            // 
            // colRequiredUnmatchedItems
            // 
            this.colRequiredUnmatchedItems.Image = null;
            this.colRequiredUnmatchedItems.Text = "Unmatched(Required)";
            this.colRequiredUnmatchedItems.Width = 100;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 100;
            // 
            // colProcessMessage
            // 
            this.colProcessMessage.Image = null;
            this.colProcessMessage.Text = "Process Message";
            this.colProcessMessage.Width = 100;
            // 
            // lblFileName
            // 
            this.lblFileName.Location = new System.Drawing.Point(16, 17);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(70, 23);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(92, 14);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(497, 20);
            this.txtFileName.TabIndex = 4;
            // 
            // btnBrowserFile
            // 
            this.btnBrowserFile.Location = new System.Drawing.Point(595, 12);
            this.btnBrowserFile.Name = "btnBrowserFile";
            this.btnBrowserFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowserFile.TabIndex = 5;
            this.btnBrowserFile.Text = "...";
            this.btnBrowserFile.Click += new System.EventHandler(this.btnBrowserFile_Click);
            // 
            // tpBarcode_MatchedItems
            // 
            this.tpBarcode_MatchedItems.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpBarcode_MatchedItems.Location = new System.Drawing.Point(4, 22);
            this.tpBarcode_MatchedItems.Name = "tpBarcode_MatchedItems";
            this.tpBarcode_MatchedItems.Size = new System.Drawing.Size(698, 561);
            this.tpBarcode_MatchedItems.TabIndex = 0;
            this.tpBarcode_MatchedItems.Text = "Barcode - Matched Items";
            // 
            // tpBarcode_UnMatchedItems
            // 
            this.tpBarcode_UnMatchedItems.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpBarcode_UnMatchedItems.Location = new System.Drawing.Point(4, 22);
            this.tpBarcode_UnMatchedItems.Name = "tpBarcode_UnMatchedItems";
            this.tpBarcode_UnMatchedItems.Size = new System.Drawing.Size(698, 561);
            this.tpBarcode_UnMatchedItems.TabIndex = 1;
            this.tpBarcode_UnMatchedItems.Text = "Barcode - Unmatched Items";
            // 
            // tpRequired_MatchedItems
            // 
            this.tpRequired_MatchedItems.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpRequired_MatchedItems.Location = new System.Drawing.Point(4, 22);
            this.tpRequired_MatchedItems.Name = "tpRequired_MatchedItems";
            this.tpRequired_MatchedItems.Size = new System.Drawing.Size(698, 561);
            this.tpRequired_MatchedItems.TabIndex = 2;
            this.tpRequired_MatchedItems.Text = "Required - Matched Items";
            // 
            // tpRequired_UnMatchedItems
            // 
            this.tpRequired_UnMatchedItems.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpRequired_UnMatchedItems.Location = new System.Drawing.Point(4, 22);
            this.tpRequired_UnMatchedItems.Name = "tpRequired_UnMatchedItems";
            this.tpRequired_UnMatchedItems.Size = new System.Drawing.Size(698, 561);
            this.tpRequired_UnMatchedItems.TabIndex = 3;
            this.tpRequired_UnMatchedItems.Text = "Required - Unmatched Items";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblMonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(726, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.Text = "Today";
            // 
            // lblDay
            // 
            this.lblDay.BackColor = System.Drawing.Color.LightYellow;
            this.lblDay.Location = new System.Drawing.Point(74, 64);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(60, 19);
            this.lblDay.TabIndex = 4;
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Day";
            // 
            // lblMonth
            // 
            this.lblMonth.BackColor = System.Drawing.Color.LightYellow;
            this.lblMonth.Location = new System.Drawing.Point(74, 43);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(60, 19);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Year";
            // 
            // lblYear
            // 
            this.lblYear.BackColor = System.Drawing.Color.LightYellow;
            this.lblYear.Location = new System.Drawing.Point(74, 22);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(60, 19);
            this.lblYear.TabIndex = 2;
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Month";
            // 
            // btnFileStructure
            // 
            this.btnFileStructure.Location = new System.Drawing.Point(745, 129);
            this.btnFileStructure.Name = "btnFileStructure";
            this.btnFileStructure.Size = new System.Drawing.Size(115, 23);
            this.btnFileStructure.TabIndex = 2;
            this.btnFileStructure.Text = "File Structure";
            this.btnFileStructure.Click += new System.EventHandler(this.btnFileStructure_Click);
            // 
            // chkAccumulate
            // 
            this.chkAccumulate.Checked = false;
            this.chkAccumulate.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkAccumulate.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkAccumulate.Location = new System.Drawing.Point(745, 435);
            this.chkAccumulate.Name = "chkAccumulate";
            this.chkAccumulate.Size = new System.Drawing.Size(104, 24);
            this.chkAccumulate.TabIndex = 3;
            this.chkAccumulate.Text = "Accumulate";
            this.chkAccumulate.ThreeState = false;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(745, 479);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(115, 23);
            this.btnReadFile.TabIndex = 4;
            this.btnReadFile.Text = "Read File";
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(745, 510);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(115, 23);
            this.btnMarkAll.TabIndex = 5;
            this.btnMarkAll.Text = "Mark All";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(745, 541);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(115, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(745, 572);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(115, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "TXT files|*.txt";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // AdvanceImport
            // 
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnMarkAll);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.chkAccumulate);
            this.Controls.Add(this.btnFileStructure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabTxferImportAdvance);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(890, 611);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer Import Wizard (Advance)";
            this.Load += new System.EventHandler(this.Invt_TxferImportWizard_Advance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl tabTxferImportAdvance;
        private Gizmox.WebGUI.Forms.TabPage tpSummary;
        private Gizmox.WebGUI.Forms.TabPage tpBarcode_MatchedItems;
        private Gizmox.WebGUI.Forms.TabPage tpBarcode_UnMatchedItems;
        private Gizmox.WebGUI.Forms.TabPage tpRequired_MatchedItems;
        private Gizmox.WebGUI.Forms.TabPage tpRequired_UnMatchedItems;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Label lblDay;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label lblMonth;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label lblYear;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Button btnFileStructure;
        private Gizmox.WebGUI.Forms.CheckBox chkAccumulate;
        private Gizmox.WebGUI.Forms.Button btnReadFile;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.Button btnImport;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnBrowserFile;
        private Gizmox.WebGUI.Forms.TextBox txtFileName;
        private Gizmox.WebGUI.Forms.Label lblFileName;
        private Gizmox.WebGUI.Forms.ListView lvSummaryList;
        private Gizmox.WebGUI.Forms.ColumnHeader colMark;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colBarcodeMatchedItems;
        private Gizmox.WebGUI.Forms.ColumnHeader colBarcodeUnmatchedItems;
        private Gizmox.WebGUI.Forms.ColumnHeader colRequiredMatchedItems;
        private Gizmox.WebGUI.Forms.ColumnHeader colRequiredUnmatchedItems;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private Gizmox.WebGUI.Forms.ColumnHeader colProcessMessage;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog;


    }
}