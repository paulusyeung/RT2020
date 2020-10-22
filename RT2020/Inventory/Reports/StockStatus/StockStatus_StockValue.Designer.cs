namespace RT2020.Inventory.Reports.StockStatus
{
    partial class StockStatus_StockValue
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
            this.chkZeroQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblStkRemark = new Gizmox.WebGUI.Forms.Label();
            this.cboStkRemark = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkTo = new Gizmox.WebGUI.Forms.Label();
            this.lblYear = new Gizmox.WebGUI.Forms.Label();
            this.lblMonth = new Gizmox.WebGUI.Forms.Label();
            this.cboFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtYear = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonth = new Gizmox.WebGUI.Forms.TextBox();
            this.btnPriview = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkZeroQty);
            this.groupBox1.Controls.Add(this.lblStkRemark);
            this.groupBox1.Controls.Add(this.cboStkRemark);
            this.groupBox1.Controls.Add(this.cboLocation);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.lblSTkFrom);
            this.groupBox1.Controls.Add(this.lblSTkTo);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.lblMonth);
            this.groupBox1.Controls.Add(this.cboFrom);
            this.groupBox1.Controls.Add(this.cboTo);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.txtMonth);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Selections";
            // 
            // chkZeroQty
            // 
            this.chkZeroQty.Checked = false;
            this.chkZeroQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkZeroQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkZeroQty.Location = new System.Drawing.Point(18, 186);
            this.chkZeroQty.Name = "chkZeroQty";
            this.chkZeroQty.Size = new System.Drawing.Size(203, 24);
            this.chkZeroQty.TabIndex = 12;
            this.chkZeroQty.Text = "Skip ZERO Qty(C/D QTY)";
            this.chkZeroQty.ThreeState = false;
            // 
            // lblStkRemark
            // 
            this.lblStkRemark.Location = new System.Drawing.Point(12, 157);
            this.lblStkRemark.Name = "lblStkRemark";
            this.lblStkRemark.Size = new System.Drawing.Size(100, 23);
            this.lblStkRemark.TabIndex = 10;
            this.lblStkRemark.Text = "Stock Remark :";
            this.lblStkRemark.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboStkRemark
            // 
            this.cboStkRemark.Items.AddRange(new object[] {
            "Class 1 - 6",
            "Description"});
            this.cboStkRemark.Location = new System.Drawing.Point(124, 154);
            this.cboStkRemark.Name = "cboStkRemark";
            this.cboStkRemark.Size = new System.Drawing.Size(157, 21);
            this.cboStkRemark.TabIndex = 11;
            this.cboStkRemark.Text = "Class 1 - 6";
            // 
            // cboLocation
            // 
            this.cboLocation.Location = new System.Drawing.Point(124, 73);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(157, 21);
            this.cboLocation.TabIndex = 5;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(12, 76);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 23);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Loc#  :";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSTkFrom
            // 
            this.lblSTkFrom.Location = new System.Drawing.Point(12, 103);
            this.lblSTkFrom.Name = "lblSTkFrom";
            this.lblSTkFrom.Size = new System.Drawing.Size(100, 23);
            this.lblSTkFrom.TabIndex = 6;
            this.lblSTkFrom.Text = "From Stock Code :";
            this.lblSTkFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSTkTo
            // 
            this.lblSTkTo.Location = new System.Drawing.Point(12, 130);
            this.lblSTkTo.Name = "lblSTkTo";
            this.lblSTkTo.Size = new System.Drawing.Size(100, 23);
            this.lblSTkTo.TabIndex = 8;
            this.lblSTkTo.Text = "To Stock Code :";
            this.lblSTkTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(12, 52);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(100, 23);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year :";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(15, 26);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(97, 23);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "For Month :";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboFrom
            // 
            this.cboFrom.Location = new System.Drawing.Point(124, 100);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(157, 21);
            this.cboFrom.TabIndex = 7;
            // 
            // cboTo
            // 
            this.cboTo.Location = new System.Drawing.Point(124, 127);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(157, 21);
            this.cboTo.TabIndex = 9;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(124, 49);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(97, 20);
            this.txtYear.TabIndex = 3;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(124, 23);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(97, 20);
            this.txtMonth.TabIndex = 1;
            // 
            // btnPriview
            // 
            this.btnPriview.Location = new System.Drawing.Point(158, 238);
            this.btnPriview.Name = "btnPriview";
            this.btnPriview.Size = new System.Drawing.Size(75, 23);
            this.btnPriview.TabIndex = 1;
            this.btnPriview.Text = "Priview";
            this.btnPriview.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // StockStatus_StockValue
            // 
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPriview);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(325, 266);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Status -> Stock Value";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Label lblStkRemark;
        private Gizmox.WebGUI.Forms.ComboBox cboStkRemark;
        private Gizmox.WebGUI.Forms.ComboBox cboLocation;
        private Gizmox.WebGUI.Forms.Label lblLocation;
        private Gizmox.WebGUI.Forms.Label lblSTkFrom;
        private Gizmox.WebGUI.Forms.Label lblSTkTo;
        private Gizmox.WebGUI.Forms.Label lblYear;
        private Gizmox.WebGUI.Forms.Label lblMonth;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.TextBox txtYear;
        private Gizmox.WebGUI.Forms.TextBox txtMonth;
        private Gizmox.WebGUI.Forms.Button btnPriview;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.CheckBox chkZeroQty;


    }
}