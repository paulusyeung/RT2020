namespace RT2020.Inventory.Reports.StockStatus
{
    partial class StockStatus_Monthly
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
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.btnPriview = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblStkRemark = new Gizmox.WebGUI.Forms.Label();
            this.cboStkRemark = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboLocationTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboLocationFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblLocationTo = new Gizmox.WebGUI.Forms.Label();
            this.lblLocationFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkTo = new Gizmox.WebGUI.Forms.Label();
            this.lblYear = new Gizmox.WebGUI.Forms.Label();
            this.lblMonth = new Gizmox.WebGUI.Forms.Label();
            this.cboFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtYear = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonth = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(239, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPriview
            // 
            this.btnPriview.Location = new System.Drawing.Point(158, 247);
            this.btnPriview.Name = "btnPriview";
            this.btnPriview.Size = new System.Drawing.Size(75, 23);
            this.btnPriview.TabIndex = 1;
            this.btnPriview.Text = "Priview";
            this.btnPriview.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStkRemark);
            this.groupBox1.Controls.Add(this.cboStkRemark);
            this.groupBox1.Controls.Add(this.cboLocationTo);
            this.groupBox1.Controls.Add(this.cboLocationFrom);
            this.groupBox1.Controls.Add(this.lblLocationTo);
            this.groupBox1.Controls.Add(this.lblLocationFrom);
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
            this.groupBox1.Size = new System.Drawing.Size(303, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Selections";
            // 
            // lblStkRemark
            // 
            this.lblStkRemark.Location = new System.Drawing.Point(12, 186);
            this.lblStkRemark.Name = "lblStkRemark";
            this.lblStkRemark.Size = new System.Drawing.Size(100, 23);
            this.lblStkRemark.TabIndex = 13;
            this.lblStkRemark.Text = "Stock Remark :";
            this.lblStkRemark.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboStkRemark
            // 
            this.cboStkRemark.Items.AddRange(new object[] {
            "Class 1 - 6",
            "Description"});
            this.cboStkRemark.Location = new System.Drawing.Point(124, 183);
            this.cboStkRemark.Name = "cboStkRemark";
            this.cboStkRemark.Size = new System.Drawing.Size(157, 21);
            this.cboStkRemark.TabIndex = 0;
            this.cboStkRemark.Text = "Class 1 - 6";
            // 
            // cboLocationTo
            // 
            this.cboLocationTo.Location = new System.Drawing.Point(124, 156);
            this.cboLocationTo.Name = "cboLocationTo";
            this.cboLocationTo.Size = new System.Drawing.Size(157, 21);
            this.cboLocationTo.TabIndex = 12;
            // 
            // cboLocationFrom
            // 
            this.cboLocationFrom.Location = new System.Drawing.Point(124, 129);
            this.cboLocationFrom.Name = "cboLocationFrom";
            this.cboLocationFrom.Size = new System.Drawing.Size(157, 21);
            this.cboLocationFrom.TabIndex = 10;
            // 
            // lblLocationTo
            // 
            this.lblLocationTo.Location = new System.Drawing.Point(12, 159);
            this.lblLocationTo.Name = "lblLocationTo";
            this.lblLocationTo.Size = new System.Drawing.Size(100, 23);
            this.lblLocationTo.TabIndex = 11;
            this.lblLocationTo.Text = "To Location :";
            this.lblLocationTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLocationFrom
            // 
            this.lblLocationFrom.Location = new System.Drawing.Point(12, 132);
            this.lblLocationFrom.Name = "lblLocationFrom";
            this.lblLocationFrom.Size = new System.Drawing.Size(100, 23);
            this.lblLocationFrom.TabIndex = 9;
            this.lblLocationFrom.Text = "From Location :";
            this.lblLocationFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSTkFrom
            // 
            this.lblSTkFrom.Location = new System.Drawing.Point(12, 78);
            this.lblSTkFrom.Name = "lblSTkFrom";
            this.lblSTkFrom.Size = new System.Drawing.Size(100, 23);
            this.lblSTkFrom.TabIndex = 5;
            this.lblSTkFrom.Text = "From Stock Code :";
            this.lblSTkFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSTkTo
            // 
            this.lblSTkTo.Location = new System.Drawing.Point(12, 105);
            this.lblSTkTo.Name = "lblSTkTo";
            this.lblSTkTo.Size = new System.Drawing.Size(100, 23);
            this.lblSTkTo.TabIndex = 7;
            this.lblSTkTo.Text = "To Stock Code :";
            this.lblSTkTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(12, 52);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(100, 23);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Year :";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(15, 26);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(97, 23);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "For Month :";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboFrom
            // 
            this.cboFrom.Location = new System.Drawing.Point(124, 75);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(157, 21);
            this.cboFrom.TabIndex = 6;
            // 
            // cboTo
            // 
            this.cboTo.Location = new System.Drawing.Point(124, 102);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(157, 21);
            this.cboTo.TabIndex = 8;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(124, 49);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(97, 20);
            this.txtYear.TabIndex = 4;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(124, 23);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(97, 20);
            this.txtMonth.TabIndex = 2;
            // 
            // StockStatus_Monthly
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPriview);
            this.Controls.Add(this.btnCancel);
            this.Size = new System.Drawing.Size(330, 279);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Status -> Monthly";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Button btnPriview;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Label lblSTkFrom;
        private Gizmox.WebGUI.Forms.Label lblSTkTo;
        private Gizmox.WebGUI.Forms.Label lblYear;
        private Gizmox.WebGUI.Forms.Label lblMonth;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.TextBox txtYear;
        private Gizmox.WebGUI.Forms.TextBox txtMonth;
        private Gizmox.WebGUI.Forms.Label lblStkRemark;
        private Gizmox.WebGUI.Forms.ComboBox cboStkRemark;
        private Gizmox.WebGUI.Forms.ComboBox cboLocationTo;
        private Gizmox.WebGUI.Forms.ComboBox cboLocationFrom;
        private Gizmox.WebGUI.Forms.Label lblLocationTo;
        private Gizmox.WebGUI.Forms.Label lblLocationFrom;


    }
}