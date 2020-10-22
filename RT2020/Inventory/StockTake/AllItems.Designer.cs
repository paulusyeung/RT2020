namespace RT2020.Inventory.StockTake
{
    partial class AllItems
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
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtnNonZeroQtyItems = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnAllItems = new Gizmox.WebGUI.Forms.RadioButton();
            this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
            this.progressBar1 = new Gizmox.WebGUI.Forms.ProgressBar();
            this.btnCreate = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.lvLocationList = new Gizmox.WebGUI.Forms.ListView();
            this.colLocation = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTransactionInfo = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colColon = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvLocationList);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Location - Name : STK Trn#, Create Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnNonZeroQtyItems);
            this.groupBox2.Controls.Add(this.rbtnAllItems);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(12, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.Text = "Add Items to Worksheet";
            // 
            // rbtnNonZeroQtyItems
            // 
            this.rbtnNonZeroQtyItems.Checked = true;
            this.rbtnNonZeroQtyItems.Location = new System.Drawing.Point(198, 23);
            this.rbtnNonZeroQtyItems.Name = "rbtnNonZeroQtyItems";
            this.rbtnNonZeroQtyItems.Size = new System.Drawing.Size(157, 24);
            this.rbtnNonZeroQtyItems.TabIndex = 1;
            this.rbtnNonZeroQtyItems.Text = "Only Non-Zero Qty Items";
            // 
            // rbtnAllItems
            // 
            this.rbtnAllItems.Location = new System.Drawing.Point(12, 23);
            this.rbtnAllItems.Name = "rbtnAllItems";
            this.rbtnAllItems.Size = new System.Drawing.Size(164, 24);
            this.rbtnAllItems.TabIndex = 0;
            this.rbtnAllItems.Text = "All Items of Above Location";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(12, 387);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 59);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.Text = "Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(377, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(242, 452);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(323, 452);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.lvLocationList.Size = new System.Drawing.Size(389, 286);
            this.lvLocationList.TabIndex = 0;
            this.lvLocationList.ItemCheck += new Gizmox.WebGUI.Forms.ItemCheckHandler(this.lvLocationList_ItemCheck);
            // 
            // colLocation
            // 
            this.colLocation.Image = null;
            this.colLocation.Text = "Location";
            this.colLocation.Width = 100;
            // 
            // colTransactionInfo
            // 
            this.colTransactionInfo.Image = null;
            this.colTransactionInfo.Text = "Transaction Info.";
            this.colTransactionInfo.Width = 200;
            // 
            // colWorkplaceId
            // 
            this.colWorkplaceId.Image = null;
            this.colWorkplaceId.Text = "WorkplaceId";
            this.colWorkplaceId.Visible = false;
            this.colWorkplaceId.Width = 150;
            // 
            // colColon
            // 
            this.colColon.Image = null;
            this.colColon.Text = ":";
            this.colColon.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colColon.Width = 10;
            // 
            // AllItems
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 501);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Take > All Items";
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
        private Gizmox.WebGUI.Forms.ListView lvLocationList;
        private Gizmox.WebGUI.Forms.ColumnHeader colLocation;
        private Gizmox.WebGUI.Forms.ColumnHeader colTransactionInfo;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceId;
        private Gizmox.WebGUI.Forms.ColumnHeader colColon;


    }
}