namespace RT2020.Inventory.Replenishment
{
    partial class Preparation
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
            this.components = new System.ComponentModel.Container();
            this.gbDate = new Gizmox.WebGUI.Forms.GroupBox();
            this.dtpEnd = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblStart = new Gizmox.WebGUI.Forms.Label();
            this.dtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblEnd = new Gizmox.WebGUI.Forms.Label();
            this.gbTxType = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkTxferOut = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkNetSales_Retail = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkNetSales_Wholesale = new Gizmox.WebGUI.Forms.CheckBox();
            this.gbRecType = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkUnPost = new Gizmox.WebGUI.Forms.CheckBox();
            this.gbStockItem = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkIgnoreOffDisplayItem = new Gizmox.WebGUI.Forms.CheckBox();
            this.gbSelectStage = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtnWH2WH = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnWH2Shop = new Gizmox.WebGUI.Forms.RadioButton();
            this.gbLocation = new Gizmox.WebGUI.Forms.GroupBox();
            this.cboToWorkplace = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnSelectAll = new Gizmox.WebGUI.Forms.Button();
            this.lvToWorkplaceList = new Gizmox.WebGUI.Forms.ListView();
            this.colWorkplaceId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboFromWorkplace = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.txtSelectedFromWorkplace = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSelectedToWorkplace = new Gizmox.WebGUI.Forms.TextBox();
            this.btnPrepare = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // gbDate
            // 
            this.gbDate.Controls.Add(this.dtpEnd);
            this.gbDate.Controls.Add(this.lblStart);
            this.gbDate.Controls.Add(this.dtpStart);
            this.gbDate.Controls.Add(this.lblEnd);
            this.gbDate.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbDate.Location = new System.Drawing.Point(12, 12);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(184, 84);
            this.gbDate.TabIndex = 0;
            this.gbDate.Text = "Date";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpEnd.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(73, 47);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(94, 20);
            this.dtpEnd.TabIndex = 4;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(16, 30);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(51, 23);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "Start";
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpStart.CustomFormat = "dd/MM/yyyy";
            this.dtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(73, 24);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(94, 20);
            this.dtpStart.TabIndex = 3;
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(16, 53);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(51, 23);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "End";
            // 
            // gbTxType
            // 
            this.gbTxType.Controls.Add(this.chkTxferOut);
            this.gbTxType.Controls.Add(this.chkNetSales_Retail);
            this.gbTxType.Controls.Add(this.chkNetSales_Wholesale);
            this.gbTxType.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbTxType.Location = new System.Drawing.Point(12, 102);
            this.gbTxType.Name = "gbTxType";
            this.gbTxType.Size = new System.Drawing.Size(184, 110);
            this.gbTxType.TabIndex = 1;
            this.gbTxType.Text = "Transaction Type";
            // 
            // chkTxferOut
            // 
            this.chkTxferOut.Checked = false;
            this.chkTxferOut.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkTxferOut.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkTxferOut.Location = new System.Drawing.Point(19, 76);
            this.chkTxferOut.Name = "chkTxferOut";
            this.chkTxferOut.Size = new System.Drawing.Size(133, 24);
            this.chkTxferOut.TabIndex = 4;
            this.chkTxferOut.Text = "Transfer Out";
            this.chkTxferOut.ThreeState = false;
            // 
            // chkNetSales_Retail
            // 
            this.chkNetSales_Retail.Checked = false;
            this.chkNetSales_Retail.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkNetSales_Retail.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkNetSales_Retail.Location = new System.Drawing.Point(19, 28);
            this.chkNetSales_Retail.Name = "chkNetSales_Retail";
            this.chkNetSales_Retail.Size = new System.Drawing.Size(133, 24);
            this.chkNetSales_Retail.TabIndex = 2;
            this.chkNetSales_Retail.Text = "Net Sales (Retail)";
            this.chkNetSales_Retail.ThreeState = false;
            // 
            // chkNetSales_Wholesale
            // 
            this.chkNetSales_Wholesale.Checked = false;
            this.chkNetSales_Wholesale.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkNetSales_Wholesale.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkNetSales_Wholesale.Location = new System.Drawing.Point(19, 52);
            this.chkNetSales_Wholesale.Name = "chkNetSales_Wholesale";
            this.chkNetSales_Wholesale.Size = new System.Drawing.Size(133, 24);
            this.chkNetSales_Wholesale.TabIndex = 3;
            this.chkNetSales_Wholesale.Text = "Net Sales (Wholesale)";
            this.chkNetSales_Wholesale.ThreeState = false;
            // 
            // gbRecType
            // 
            this.gbRecType.Controls.Add(this.chkUnPost);
            this.gbRecType.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbRecType.Location = new System.Drawing.Point(12, 218);
            this.gbRecType.Name = "gbRecType";
            this.gbRecType.Size = new System.Drawing.Size(184, 65);
            this.gbRecType.TabIndex = 2;
            this.gbRecType.Text = "Record Type";
            // 
            // chkUnPost
            // 
            this.chkUnPost.Checked = false;
            this.chkUnPost.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkUnPost.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkUnPost.Location = new System.Drawing.Point(19, 30);
            this.chkUnPost.Name = "chkUnPost";
            this.chkUnPost.Size = new System.Drawing.Size(148, 24);
            this.chkUnPost.TabIndex = 0;
            this.chkUnPost.Text = "Un-Post";
            this.chkUnPost.ThreeState = false;
            // 
            // gbStockItem
            // 
            this.gbStockItem.Controls.Add(this.chkIgnoreOffDisplayItem);
            this.gbStockItem.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbStockItem.Location = new System.Drawing.Point(12, 289);
            this.gbStockItem.Name = "gbStockItem";
            this.gbStockItem.Size = new System.Drawing.Size(184, 67);
            this.gbStockItem.TabIndex = 3;
            this.gbStockItem.Text = "Stock Item";
            // 
            // chkIgnoreOffDisplayItem
            // 
            this.chkIgnoreOffDisplayItem.Checked = false;
            this.chkIgnoreOffDisplayItem.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkIgnoreOffDisplayItem.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkIgnoreOffDisplayItem.Location = new System.Drawing.Point(19, 32);
            this.chkIgnoreOffDisplayItem.Name = "chkIgnoreOffDisplayItem";
            this.chkIgnoreOffDisplayItem.Size = new System.Drawing.Size(148, 24);
            this.chkIgnoreOffDisplayItem.TabIndex = 4;
            this.chkIgnoreOffDisplayItem.Text = "Ignore Off-Display Item";
            this.chkIgnoreOffDisplayItem.ThreeState = false;
            // 
            // gbSelectStage
            // 
            this.gbSelectStage.Controls.Add(this.rbtnWH2WH);
            this.gbSelectStage.Controls.Add(this.rbtnWH2Shop);
            this.gbSelectStage.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbSelectStage.Location = new System.Drawing.Point(12, 362);
            this.gbSelectStage.Name = "gbSelectStage";
            this.gbSelectStage.Size = new System.Drawing.Size(184, 87);
            this.gbSelectStage.TabIndex = 4;
            this.gbSelectStage.Text = "Select Stage";
            // 
            // rbtnWH2WH
            // 
            this.rbtnWH2WH.Location = new System.Drawing.Point(19, 53);
            this.rbtnWH2WH.Name = "rbtnWH2WH";
            this.rbtnWH2WH.Size = new System.Drawing.Size(159, 24);
            this.rbtnWH2WH.TabIndex = 6;
            this.rbtnWH2WH.Text = "Warehouse -> Warehouse";
            this.rbtnWH2WH.CheckedChanged += new System.EventHandler(this.rbtns_CheckedChanged);
            // 
            // rbtnWH2Shop
            // 
            this.rbtnWH2Shop.Checked = true;
            this.rbtnWH2Shop.Location = new System.Drawing.Point(19, 29);
            this.rbtnWH2Shop.Name = "rbtnWH2Shop";
            this.rbtnWH2Shop.Size = new System.Drawing.Size(148, 24);
            this.rbtnWH2Shop.TabIndex = 5;
            this.rbtnWH2Shop.Text = "Warehouse -> Shop(s)";
            this.rbtnWH2Shop.CheckedChanged += new System.EventHandler(this.rbtns_CheckedChanged);
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.cboToWorkplace);
            this.gbLocation.Controls.Add(this.btnSelectAll);
            this.gbLocation.Controls.Add(this.lvToWorkplaceList);
            this.gbLocation.Controls.Add(this.cboFromWorkplace);
            this.gbLocation.Controls.Add(this.lblTo);
            this.gbLocation.Controls.Add(this.lblFrom);
            this.gbLocation.Controls.Add(this.txtSelectedFromWorkplace);
            this.gbLocation.Controls.Add(this.txtSelectedToWorkplace);
            this.gbLocation.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbLocation.Location = new System.Drawing.Point(202, 12);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(481, 358);
            this.gbLocation.TabIndex = 5;
            this.gbLocation.Text = "Location";
            // 
            // cboToWorkplace
            // 
            this.cboToWorkplace.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboToWorkplace.DropDownWidth = 103;
            this.cboToWorkplace.Location = new System.Drawing.Point(77, 50);
            this.cboToWorkplace.Name = "cboToWorkplace";
            this.cboToWorkplace.Size = new System.Drawing.Size(103, 21);
            this.cboToWorkplace.TabIndex = 2;
            this.cboToWorkplace.Visible = false;
            this.cboToWorkplace.SelectedIndexChanged += new System.EventHandler(this.cboToWorkplace_SelectedIndexChanged);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(375, 321);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lvToWorkplaceList
            // 
            this.lvToWorkplaceList.CheckBoxes = true;
            this.lvToWorkplaceList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colWorkplaceId,
            this.colLN,
            this.colWorkplaceCode,
            this.colWorkplaceName});
            this.lvToWorkplaceList.DataMember = null;
            this.lvToWorkplaceList.ItemsPerPage = 20;
            this.lvToWorkplaceList.Location = new System.Drawing.Point(77, 51);
            this.lvToWorkplaceList.Name = "lvToWorkplaceList";
            this.lvToWorkplaceList.Size = new System.Drawing.Size(373, 264);
            this.lvToWorkplaceList.TabIndex = 4;
            // 
            // colWorkplaceId
            // 
            this.colWorkplaceId.Image = null;
            this.colWorkplaceId.Text = "WorkplaceId";
            this.colWorkplaceId.Visible = false;
            this.colWorkplaceId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colWorkplaceCode
            // 
            this.colWorkplaceCode.Image = null;
            this.colWorkplaceCode.Text = "LOC#";
            this.colWorkplaceCode.Width = 80;
            // 
            // colWorkplaceName
            // 
            this.colWorkplaceName.Image = null;
            this.colWorkplaceName.Text = "Name";
            this.colWorkplaceName.Width = 120;
            // 
            // cboFromWorkplace
            // 
            this.cboFromWorkplace.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboFromWorkplace.DropDownWidth = 103;
            this.cboFromWorkplace.Location = new System.Drawing.Point(77, 27);
            this.cboFromWorkplace.Name = "cboFromWorkplace";
            this.cboFromWorkplace.Size = new System.Drawing.Size(103, 21);
            this.cboFromWorkplace.TabIndex = 2;
            this.cboFromWorkplace.SelectedIndexChanged += new System.EventHandler(this.cboFromWorkplace_SelectedIndexChanged);
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(19, 53);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(52, 23);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(19, 30);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(52, 23);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // txtSelectedFromWorkplace
            // 
            this.txtSelectedFromWorkplace.BackColor = System.Drawing.Color.LightYellow;
            this.txtSelectedFromWorkplace.Location = new System.Drawing.Point(186, 27);
            this.txtSelectedFromWorkplace.Name = "txtSelectedFromWorkplace";
            this.txtSelectedFromWorkplace.ReadOnly = true;
            this.txtSelectedFromWorkplace.Size = new System.Drawing.Size(218, 20);
            this.txtSelectedFromWorkplace.TabIndex = 3;
            // 
            // txtSelectedToWorkplace
            // 
            this.txtSelectedToWorkplace.BackColor = System.Drawing.Color.LightYellow;
            this.txtSelectedToWorkplace.Location = new System.Drawing.Point(186, 50);
            this.txtSelectedToWorkplace.Name = "txtSelectedToWorkplace";
            this.txtSelectedToWorkplace.ReadOnly = true;
            this.txtSelectedToWorkplace.Size = new System.Drawing.Size(218, 20);
            this.txtSelectedToWorkplace.TabIndex = 3;
            this.txtSelectedToWorkplace.Visible = false;
            // 
            // btnPrepare
            // 
            this.btnPrepare.Location = new System.Drawing.Point(496, 416);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(75, 23);
            this.btnPrepare.TabIndex = 6;
            this.btnPrepare.Text = "Prepare";
            this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(577, 416);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // Preparation
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrepare);
            this.Controls.Add(this.gbLocation);
            this.Controls.Add(this.gbSelectStage);
            this.Controls.Add(this.gbStockItem);
            this.Controls.Add(this.gbRecType);
            this.Controls.Add(this.gbTxType);
            this.Controls.Add(this.gbDate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(695, 461);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replenishment > Preparation";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox gbDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpEnd;
        private Gizmox.WebGUI.Forms.Label lblStart;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpStart;
        private Gizmox.WebGUI.Forms.Label lblEnd;
        private Gizmox.WebGUI.Forms.GroupBox gbTxType;
        private Gizmox.WebGUI.Forms.CheckBox chkTxferOut;
        private Gizmox.WebGUI.Forms.CheckBox chkNetSales_Retail;
        private Gizmox.WebGUI.Forms.CheckBox chkNetSales_Wholesale;
        private Gizmox.WebGUI.Forms.GroupBox gbRecType;
        private Gizmox.WebGUI.Forms.CheckBox chkUnPost;
        private Gizmox.WebGUI.Forms.GroupBox gbStockItem;
        private Gizmox.WebGUI.Forms.CheckBox chkIgnoreOffDisplayItem;
        private Gizmox.WebGUI.Forms.GroupBox gbSelectStage;
        private Gizmox.WebGUI.Forms.RadioButton rbtnWH2WH;
        private Gizmox.WebGUI.Forms.RadioButton rbtnWH2Shop;
        private Gizmox.WebGUI.Forms.GroupBox gbLocation;
        private Gizmox.WebGUI.Forms.Button btnSelectAll;
        private Gizmox.WebGUI.Forms.ListView lvToWorkplaceList;
        private Gizmox.WebGUI.Forms.TextBox txtSelectedFromWorkplace;
        private Gizmox.WebGUI.Forms.ComboBox cboFromWorkplace;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceName;
        private Gizmox.WebGUI.Forms.Button btnPrepare;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.ComboBox cboToWorkplace;
        private Gizmox.WebGUI.Forms.TextBox txtSelectedToWorkplace;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}