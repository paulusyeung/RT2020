namespace RT2020.Inventory.StockTake.Import
{
    partial class ImportFromPPC_DataSelectionCtrl
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWorkplace = new Gizmox.WebGUI.Forms.Label();
            this.cboWorkplace = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblHHTTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtHHTTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStocktTakeNumber = new Gizmox.WebGUI.Forms.Label();
            this.cboStockTakeNumber = new Gizmox.WebGUI.Forms.ComboBox();
            this.ctrlPane = new Gizmox.WebGUI.Forms.Panel();
            this.chkHHTNumAsSTKTKNum = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWorkplace
            // 
            this.lblWorkplace.AutoSize = true;
            this.lblWorkplace.Location = new System.Drawing.Point(18, 16);
            this.lblWorkplace.Name = "lblWorkplace";
            this.lblWorkplace.Size = new System.Drawing.Size(100, 23);
            this.lblWorkplace.TabIndex = 0;
            this.lblWorkplace.Text = "LOC#";
            // 
            // cboWorkplace
            // 
            this.cboWorkplace.Location = new System.Drawing.Point(142, 13);
            this.cboWorkplace.Name = "cboWorkplace";
            this.cboWorkplace.Size = new System.Drawing.Size(161, 21);
            this.cboWorkplace.TabIndex = 1;
            // 
            // lblHHTTxNumber
            // 
            this.lblHHTTxNumber.AutoSize = true;
            this.lblHHTTxNumber.Location = new System.Drawing.Point(18, 43);
            this.lblHHTTxNumber.Name = "lblHHTTxNumber";
            this.lblHHTTxNumber.Size = new System.Drawing.Size(100, 23);
            this.lblHHTTxNumber.TabIndex = 2;
            this.lblHHTTxNumber.Text = "HHT TRN#";
            // 
            // txtHHTTxNumber
            // 
            this.txtHHTTxNumber.Enabled = false;
            this.txtHHTTxNumber.Location = new System.Drawing.Point(142, 40);
            this.txtHHTTxNumber.Name = "txtHHTTxNumber";
            this.txtHHTTxNumber.Size = new System.Drawing.Size(161, 20);
            this.txtHHTTxNumber.TabIndex = 3;
            // 
            // lblStocktTakeNumber
            // 
            this.lblStocktTakeNumber.AutoSize = true;
            this.lblStocktTakeNumber.Location = new System.Drawing.Point(18, 69);
            this.lblStocktTakeNumber.Name = "lblStocktTakeNumber";
            this.lblStocktTakeNumber.Size = new System.Drawing.Size(100, 23);
            this.lblStocktTakeNumber.TabIndex = 4;
            this.lblStocktTakeNumber.Text = "Stock Take#";
            // 
            // cboStockTakeNumber
            // 
            this.cboStockTakeNumber.Location = new System.Drawing.Point(142, 66);
            this.cboStockTakeNumber.Name = "cboStockTakeNumber";
            this.cboStockTakeNumber.Size = new System.Drawing.Size(161, 21);
            this.cboStockTakeNumber.TabIndex = 5;
            // 
            // ctrlPane
            // 
            this.ctrlPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.ctrlPane.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctrlPane.Controls.Add(this.btnExit);
            this.ctrlPane.Controls.Add(this.btnOK);
            this.ctrlPane.Controls.Add(this.chkHHTNumAsSTKTKNum);
            this.ctrlPane.Controls.Add(this.lblWorkplace);
            this.ctrlPane.Controls.Add(this.cboStockTakeNumber);
            this.ctrlPane.Controls.Add(this.cboWorkplace);
            this.ctrlPane.Controls.Add(this.lblStocktTakeNumber);
            this.ctrlPane.Controls.Add(this.lblHHTTxNumber);
            this.ctrlPane.Controls.Add(this.txtHHTTxNumber);
            this.ctrlPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ctrlPane.DockPadding.All = 3;
            this.ctrlPane.Location = new System.Drawing.Point(0, 0);
            this.ctrlPane.Name = "ctrlPane";
            this.ctrlPane.Size = new System.Drawing.Size(326, 190);
            this.ctrlPane.TabIndex = 6;
            // 
            // chkHHTNumAsSTKTKNum
            // 
            this.chkHHTNumAsSTKTKNum.Checked = false;
            this.chkHHTNumAsSTKTKNum.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkHHTNumAsSTKTKNum.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkHHTNumAsSTKTKNum.ForeColor = System.Drawing.Color.Red;
            this.chkHHTNumAsSTKTKNum.Location = new System.Drawing.Point(21, 103);
            this.chkHHTNumAsSTKTKNum.Name = "chkHHTNumAsSTKTKNum";
            this.chkHHTNumAsSTKTKNum.Size = new System.Drawing.Size(282, 24);
            this.chkHHTNumAsSTKTKNum.TabIndex = 6;
            this.chkHHTNumAsSTKTKNum.Text = "Using HHT TRN# as Stock Take#";
            this.chkHHTNumAsSTKTKNum.ThreeState = false;
            this.chkHHTNumAsSTKTKNum.Click += new System.EventHandler(this.chkHHTNumAsSTKTKNum_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(142, 145);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(228, 145);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ImportFromPPC_DataSelectionCtrl
            // 
            this.Controls.Add(this.ctrlPane);
            this.Size = new System.Drawing.Size(326, 190);
            this.Text = "ImportFromPPC_DataSelectionCtrl";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblWorkplace;
        private Gizmox.WebGUI.Forms.ComboBox cboWorkplace;
        private Gizmox.WebGUI.Forms.Label lblHHTTxNumber;
        private Gizmox.WebGUI.Forms.TextBox txtHHTTxNumber;
        private Gizmox.WebGUI.Forms.Label lblStocktTakeNumber;
        private Gizmox.WebGUI.Forms.ComboBox cboStockTakeNumber;
        private Gizmox.WebGUI.Forms.Panel ctrlPane;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.CheckBox chkHHTNumAsSTKTKNum;


    }
}