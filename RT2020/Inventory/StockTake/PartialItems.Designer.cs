namespace RT2020.Inventory.StockTake
{
    partial class PartialItems
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
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lvLocationList = new Gizmox.WebGUI.Forms.ListView();
            this.colWorkplaceId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLocation = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colColon = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTransactionInfo = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblClass6_To = new Gizmox.WebGUI.Forms.Label();
            this.lblClass5_To = new Gizmox.WebGUI.Forms.Label();
            this.lblClass4_To = new Gizmox.WebGUI.Forms.Label();
            this.lblClass3_To = new Gizmox.WebGUI.Forms.Label();
            this.lblClass2_To = new Gizmox.WebGUI.Forms.Label();
            this.lblClass1_To = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode_To = new Gizmox.WebGUI.Forms.Label();
            this.cboClass6_To = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass6_From = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass5_To = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass5_From = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass4_From = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass4_To = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass3_From = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass3_To = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass2_From = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass2_To = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass1_From = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboClass1_To = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboStockCode_To = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboStockCode_From = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCDQty = new Gizmox.WebGUI.Forms.Label();
            this.lblClass6 = new Gizmox.WebGUI.Forms.Label();
            this.lblClass5 = new Gizmox.WebGUI.Forms.Label();
            this.lblClass4 = new Gizmox.WebGUI.Forms.Label();
            this.lblClass3 = new Gizmox.WebGUI.Forms.Label();
            this.lblClass2 = new Gizmox.WebGUI.Forms.Label();
            this.lblClass1 = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.rbtnNonZeroQtyItems = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnAllItems = new Gizmox.WebGUI.Forms.RadioButton();
            this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
            this.progressBar1 = new Gizmox.WebGUI.Forms.ProgressBar();
            this.btnCreate = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvLocationList);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Location - Name : STK Trn#, Create Date";
            // 
            // lvLocationList
            // 
            this.lvLocationList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvLocationList.CheckBoxes = true;
            this.lvLocationList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colWorkplaceId,
            this.colLocation,
            this.colColon,
            this.colTransactionInfo});
            this.lvLocationList.DataMember = null;
            this.lvLocationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvLocationList.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.None;
            this.lvLocationList.ItemsPerPage = 20;
            this.lvLocationList.Location = new System.Drawing.Point(3, 16);
            this.lvLocationList.Name = "lvLocationList";
            this.lvLocationList.Size = new System.Drawing.Size(466, 342);
            this.lvLocationList.TabIndex = 0;
            this.lvLocationList.ItemCheck += new Gizmox.WebGUI.Forms.ItemCheckHandler(this.lvLocationList_ItemCheck);
            // 
            // colWorkplaceId
            // 
            this.colWorkplaceId.Image = null;
            this.colWorkplaceId.Text = "WorkplaceId";
            this.colWorkplaceId.Visible = false;
            this.colWorkplaceId.Width = 150;
            // 
            // colLocation
            // 
            this.colLocation.Image = null;
            this.colLocation.Text = "Location";
            this.colLocation.Width = 100;
            // 
            // colColon
            // 
            this.colColon.Image = null;
            this.colColon.Text = ":";
            this.colColon.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colColon.Width = 10;
            // 
            // colTransactionInfo
            // 
            this.colTransactionInfo.Image = null;
            this.colTransactionInfo.Text = "Transaction Info.";
            this.colTransactionInfo.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblClass6_To);
            this.groupBox2.Controls.Add(this.lblClass5_To);
            this.groupBox2.Controls.Add(this.lblClass4_To);
            this.groupBox2.Controls.Add(this.lblClass3_To);
            this.groupBox2.Controls.Add(this.lblClass2_To);
            this.groupBox2.Controls.Add(this.lblClass1_To);
            this.groupBox2.Controls.Add(this.lblStockCode_To);
            this.groupBox2.Controls.Add(this.cboClass6_To);
            this.groupBox2.Controls.Add(this.cboClass6_From);
            this.groupBox2.Controls.Add(this.cboClass5_To);
            this.groupBox2.Controls.Add(this.cboClass5_From);
            this.groupBox2.Controls.Add(this.cboClass4_From);
            this.groupBox2.Controls.Add(this.cboClass4_To);
            this.groupBox2.Controls.Add(this.cboClass3_From);
            this.groupBox2.Controls.Add(this.cboClass3_To);
            this.groupBox2.Controls.Add(this.cboClass2_From);
            this.groupBox2.Controls.Add(this.cboClass2_To);
            this.groupBox2.Controls.Add(this.cboClass1_From);
            this.groupBox2.Controls.Add(this.cboClass1_To);
            this.groupBox2.Controls.Add(this.cboStockCode_To);
            this.groupBox2.Controls.Add(this.cboStockCode_From);
            this.groupBox2.Controls.Add(this.lblCDQty);
            this.groupBox2.Controls.Add(this.lblClass6);
            this.groupBox2.Controls.Add(this.lblClass5);
            this.groupBox2.Controls.Add(this.lblClass4);
            this.groupBox2.Controls.Add(this.lblClass3);
            this.groupBox2.Controls.Add(this.lblClass2);
            this.groupBox2.Controls.Add(this.lblClass1);
            this.groupBox2.Controls.Add(this.lblStockCode);
            this.groupBox2.Controls.Add(this.rbtnNonZeroQtyItems);
            this.groupBox2.Controls.Add(this.rbtnAllItems);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(490, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 226);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.Text = "Add Items to Worksheet";
            // 
            // lblClass6_To
            // 
            this.lblClass6_To.Location = new System.Drawing.Point(249, 167);
            this.lblClass6_To.Name = "lblClass6_To";
            this.lblClass6_To.Size = new System.Drawing.Size(36, 23);
            this.lblClass6_To.TabIndex = 30;
            this.lblClass6_To.Text = "To";
            this.lblClass6_To.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblClass5_To
            // 
            this.lblClass5_To.Location = new System.Drawing.Point(249, 144);
            this.lblClass5_To.Name = "lblClass5_To";
            this.lblClass5_To.Size = new System.Drawing.Size(36, 23);
            this.lblClass5_To.TabIndex = 29;
            this.lblClass5_To.Text = "To";
            this.lblClass5_To.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblClass4_To
            // 
            this.lblClass4_To.Location = new System.Drawing.Point(249, 121);
            this.lblClass4_To.Name = "lblClass4_To";
            this.lblClass4_To.Size = new System.Drawing.Size(36, 23);
            this.lblClass4_To.TabIndex = 28;
            this.lblClass4_To.Text = "To";
            this.lblClass4_To.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblClass3_To
            // 
            this.lblClass3_To.Location = new System.Drawing.Point(249, 98);
            this.lblClass3_To.Name = "lblClass3_To";
            this.lblClass3_To.Size = new System.Drawing.Size(36, 23);
            this.lblClass3_To.TabIndex = 27;
            this.lblClass3_To.Text = "To";
            this.lblClass3_To.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblClass2_To
            // 
            this.lblClass2_To.Location = new System.Drawing.Point(249, 75);
            this.lblClass2_To.Name = "lblClass2_To";
            this.lblClass2_To.Size = new System.Drawing.Size(36, 23);
            this.lblClass2_To.TabIndex = 26;
            this.lblClass2_To.Text = "To";
            this.lblClass2_To.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblClass1_To
            // 
            this.lblClass1_To.Location = new System.Drawing.Point(249, 52);
            this.lblClass1_To.Name = "lblClass1_To";
            this.lblClass1_To.Size = new System.Drawing.Size(36, 23);
            this.lblClass1_To.TabIndex = 25;
            this.lblClass1_To.Text = "To";
            this.lblClass1_To.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStockCode_To
            // 
            this.lblStockCode_To.Location = new System.Drawing.Point(249, 29);
            this.lblStockCode_To.Name = "lblStockCode_To";
            this.lblStockCode_To.Size = new System.Drawing.Size(36, 23);
            this.lblStockCode_To.TabIndex = 24;
            this.lblStockCode_To.Text = "To";
            this.lblStockCode_To.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboClass6_To
            // 
            this.cboClass6_To.DropDownWidth = 121;
            this.cboClass6_To.Location = new System.Drawing.Point(298, 164);
            this.cboClass6_To.Name = "cboClass6_To";
            this.cboClass6_To.Size = new System.Drawing.Size(121, 21);
            this.cboClass6_To.TabIndex = 13;
            // 
            // cboClass6_From
            // 
            this.cboClass6_From.DropDownWidth = 121;
            this.cboClass6_From.Location = new System.Drawing.Point(121, 164);
            this.cboClass6_From.Name = "cboClass6_From";
            this.cboClass6_From.Size = new System.Drawing.Size(121, 21);
            this.cboClass6_From.TabIndex = 12;
            // 
            // cboClass5_To
            // 
            this.cboClass5_To.DropDownWidth = 121;
            this.cboClass5_To.Location = new System.Drawing.Point(298, 141);
            this.cboClass5_To.Name = "cboClass5_To";
            this.cboClass5_To.Size = new System.Drawing.Size(121, 21);
            this.cboClass5_To.TabIndex = 11;
            // 
            // cboClass5_From
            // 
            this.cboClass5_From.DropDownWidth = 121;
            this.cboClass5_From.Location = new System.Drawing.Point(121, 141);
            this.cboClass5_From.Name = "cboClass5_From";
            this.cboClass5_From.Size = new System.Drawing.Size(121, 21);
            this.cboClass5_From.TabIndex = 10;
            // 
            // cboClass4_From
            // 
            this.cboClass4_From.DropDownWidth = 121;
            this.cboClass4_From.Location = new System.Drawing.Point(121, 118);
            this.cboClass4_From.Name = "cboClass4_From";
            this.cboClass4_From.Size = new System.Drawing.Size(121, 21);
            this.cboClass4_From.TabIndex = 8;
            // 
            // cboClass4_To
            // 
            this.cboClass4_To.DropDownWidth = 121;
            this.cboClass4_To.Location = new System.Drawing.Point(298, 118);
            this.cboClass4_To.Name = "cboClass4_To";
            this.cboClass4_To.Size = new System.Drawing.Size(121, 21);
            this.cboClass4_To.TabIndex = 9;
            // 
            // cboClass3_From
            // 
            this.cboClass3_From.DropDownWidth = 121;
            this.cboClass3_From.Location = new System.Drawing.Point(121, 95);
            this.cboClass3_From.Name = "cboClass3_From";
            this.cboClass3_From.Size = new System.Drawing.Size(121, 21);
            this.cboClass3_From.TabIndex = 6;
            // 
            // cboClass3_To
            // 
            this.cboClass3_To.DropDownWidth = 121;
            this.cboClass3_To.Location = new System.Drawing.Point(298, 95);
            this.cboClass3_To.Name = "cboClass3_To";
            this.cboClass3_To.Size = new System.Drawing.Size(121, 21);
            this.cboClass3_To.TabIndex = 7;
            // 
            // cboClass2_From
            // 
            this.cboClass2_From.DropDownWidth = 121;
            this.cboClass2_From.Location = new System.Drawing.Point(121, 72);
            this.cboClass2_From.Name = "cboClass2_From";
            this.cboClass2_From.Size = new System.Drawing.Size(121, 21);
            this.cboClass2_From.TabIndex = 4;
            // 
            // cboClass2_To
            // 
            this.cboClass2_To.DropDownWidth = 121;
            this.cboClass2_To.Location = new System.Drawing.Point(298, 72);
            this.cboClass2_To.Name = "cboClass2_To";
            this.cboClass2_To.Size = new System.Drawing.Size(121, 21);
            this.cboClass2_To.TabIndex = 5;
            // 
            // cboClass1_From
            // 
            this.cboClass1_From.DropDownWidth = 121;
            this.cboClass1_From.Location = new System.Drawing.Point(121, 49);
            this.cboClass1_From.Name = "cboClass1_From";
            this.cboClass1_From.Size = new System.Drawing.Size(121, 21);
            this.cboClass1_From.TabIndex = 2;
            // 
            // cboClass1_To
            // 
            this.cboClass1_To.DropDownWidth = 121;
            this.cboClass1_To.Location = new System.Drawing.Point(298, 49);
            this.cboClass1_To.Name = "cboClass1_To";
            this.cboClass1_To.Size = new System.Drawing.Size(121, 21);
            this.cboClass1_To.TabIndex = 3;
            // 
            // cboStockCode_To
            // 
            this.cboStockCode_To.DropDownWidth = 121;
            this.cboStockCode_To.Location = new System.Drawing.Point(298, 26);
            this.cboStockCode_To.Name = "cboStockCode_To";
            this.cboStockCode_To.Size = new System.Drawing.Size(121, 21);
            this.cboStockCode_To.TabIndex = 1;
            // 
            // cboStockCode_From
            // 
            this.cboStockCode_From.DropDownWidth = 121;
            this.cboStockCode_From.Location = new System.Drawing.Point(121, 26);
            this.cboStockCode_From.Name = "cboStockCode_From";
            this.cboStockCode_From.Size = new System.Drawing.Size(121, 21);
            this.cboStockCode_From.TabIndex = 0;
            // 
            // lblCDQty
            // 
            this.lblCDQty.Location = new System.Drawing.Point(15, 190);
            this.lblCDQty.Name = "lblCDQty";
            this.lblCDQty.Size = new System.Drawing.Size(100, 23);
            this.lblCDQty.TabIndex = 23;
            this.lblCDQty.Text = "C/D Qty";
            // 
            // lblClass6
            // 
            this.lblClass6.Location = new System.Drawing.Point(15, 167);
            this.lblClass6.Name = "lblClass6";
            this.lblClass6.Size = new System.Drawing.Size(100, 23);
            this.lblClass6.TabIndex = 22;
            this.lblClass6.Text = "SUB-CAT";
            // 
            // lblClass5
            // 
            this.lblClass5.Location = new System.Drawing.Point(15, 144);
            this.lblClass5.Name = "lblClass5";
            this.lblClass5.Size = new System.Drawing.Size(100, 23);
            this.lblClass5.TabIndex = 21;
            this.lblClass5.Text = "CATEGORY";
            // 
            // lblClass4
            // 
            this.lblClass4.Location = new System.Drawing.Point(15, 121);
            this.lblClass4.Name = "lblClass4";
            this.lblClass4.Size = new System.Drawing.Size(100, 23);
            this.lblClass4.TabIndex = 20;
            this.lblClass4.Text = "GROUP";
            // 
            // lblClass3
            // 
            this.lblClass3.Location = new System.Drawing.Point(15, 98);
            this.lblClass3.Name = "lblClass3";
            this.lblClass3.Size = new System.Drawing.Size(100, 23);
            this.lblClass3.TabIndex = 19;
            this.lblClass3.Text = "COLLECTION";
            // 
            // lblClass2
            // 
            this.lblClass2.Location = new System.Drawing.Point(15, 75);
            this.lblClass2.Name = "lblClass2";
            this.lblClass2.Size = new System.Drawing.Size(100, 23);
            this.lblClass2.TabIndex = 18;
            this.lblClass2.Text = "GENDER";
            // 
            // lblClass1
            // 
            this.lblClass1.Location = new System.Drawing.Point(15, 52);
            this.lblClass1.Name = "lblClass1";
            this.lblClass1.Size = new System.Drawing.Size(100, 23);
            this.lblClass1.TabIndex = 17;
            this.lblClass1.Text = "VENDOR";
            // 
            // lblStockCode
            // 
            this.lblStockCode.Location = new System.Drawing.Point(15, 29);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(100, 23);
            this.lblStockCode.TabIndex = 16;
            this.lblStockCode.Text = "Stock Code";
            // 
            // rbtnNonZeroQtyItems
            // 
            this.rbtnNonZeroQtyItems.Checked = true;
            this.rbtnNonZeroQtyItems.Location = new System.Drawing.Point(294, 189);
            this.rbtnNonZeroQtyItems.Name = "rbtnNonZeroQtyItems";
            this.rbtnNonZeroQtyItems.Size = new System.Drawing.Size(157, 24);
            this.rbtnNonZeroQtyItems.TabIndex = 15;
            this.rbtnNonZeroQtyItems.Text = "Only Non-Zero Qty Items";
            // 
            // rbtnAllItems
            // 
            this.rbtnAllItems.Location = new System.Drawing.Point(121, 189);
            this.rbtnAllItems.Name = "rbtnAllItems";
            this.rbtnAllItems.Size = new System.Drawing.Size(164, 24);
            this.rbtnAllItems.TabIndex = 14;
            this.rbtnAllItems.Text = "All Items of Above Location";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(490, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 59);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.Text = "Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(444, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(784, 347);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(865, 347);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PartialItems
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(961, 386);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Take > Partial Items";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.RadioButton rbtnNonZeroQtyItems;
        private Gizmox.WebGUI.Forms.RadioButton rbtnAllItems;
        private Gizmox.WebGUI.Forms.GroupBox groupBox3;
        private Gizmox.WebGUI.Forms.ProgressBar progressBar1;
        private Gizmox.WebGUI.Forms.Button btnCreate;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Label lblClass6_To;
        private Gizmox.WebGUI.Forms.Label lblClass5_To;
        private Gizmox.WebGUI.Forms.Label lblClass4_To;
        private Gizmox.WebGUI.Forms.Label lblClass3_To;
        private Gizmox.WebGUI.Forms.Label lblClass2_To;
        private Gizmox.WebGUI.Forms.Label lblClass1_To;
        private Gizmox.WebGUI.Forms.Label lblStockCode_To;
        private Gizmox.WebGUI.Forms.ComboBox cboClass6_To;
        private Gizmox.WebGUI.Forms.ComboBox cboClass6_From;
        private Gizmox.WebGUI.Forms.ComboBox cboClass5_To;
        private Gizmox.WebGUI.Forms.ComboBox cboClass5_From;
        private Gizmox.WebGUI.Forms.ComboBox cboClass4_From;
        private Gizmox.WebGUI.Forms.ComboBox cboClass4_To;
        private Gizmox.WebGUI.Forms.ComboBox cboClass3_From;
        private Gizmox.WebGUI.Forms.ComboBox cboClass3_To;
        private Gizmox.WebGUI.Forms.ComboBox cboClass2_From;
        private Gizmox.WebGUI.Forms.ComboBox cboClass2_To;
        private Gizmox.WebGUI.Forms.ComboBox cboClass1_From;
        private Gizmox.WebGUI.Forms.ComboBox cboClass1_To;
        private Gizmox.WebGUI.Forms.ComboBox cboStockCode_To;
        private Gizmox.WebGUI.Forms.ComboBox cboStockCode_From;
        private Gizmox.WebGUI.Forms.Label lblCDQty;
        private Gizmox.WebGUI.Forms.Label lblClass6;
        private Gizmox.WebGUI.Forms.Label lblClass5;
        private Gizmox.WebGUI.Forms.Label lblClass4;
        private Gizmox.WebGUI.Forms.Label lblClass3;
        private Gizmox.WebGUI.Forms.Label lblClass2;
        private Gizmox.WebGUI.Forms.Label lblClass1;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.ListView lvLocationList;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLocation;
        private Gizmox.WebGUI.Forms.ColumnHeader colColon;
        private Gizmox.WebGUI.Forms.ColumnHeader colTransactionInfo;


    }
}