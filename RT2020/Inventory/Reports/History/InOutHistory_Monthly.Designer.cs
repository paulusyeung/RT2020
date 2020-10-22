namespace RT2020.Inventory.Reports.History
{
    partial class InOutHistory_Monthly
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
            this.lblSTkFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkTo = new Gizmox.WebGUI.Forms.Label();
            this.lblYear = new Gizmox.WebGUI.Forms.Label();
            this.lblMonth = new Gizmox.WebGUI.Forms.Label();
            this.cboFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtYear = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonth = new Gizmox.WebGUI.Forms.TextBox();
            this.chkTakeQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSTkFrom);
            this.groupBox1.Controls.Add(this.lblSTkTo);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.lblMonth);
            this.groupBox1.Controls.Add(this.cboFrom);
            this.groupBox1.Controls.Add(this.cboTo);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.txtMonth);
            this.groupBox1.Controls.Add(this.chkTakeQty);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 210);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.Text = "Selections";
            // 
            // lblSTkFrom
            // 
            this.lblSTkFrom.Location = new System.Drawing.Point(6, 27);
            this.lblSTkFrom.Name = "lblSTkFrom";
            this.lblSTkFrom.Size = new System.Drawing.Size(100, 23);
            this.lblSTkFrom.TabIndex = 0;
            this.lblSTkFrom.Text = "From Stock Code :";
            this.lblSTkFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSTkTo
            // 
            this.lblSTkTo.Location = new System.Drawing.Point(9, 64);
            this.lblSTkTo.Name = "lblSTkTo";
            this.lblSTkTo.Size = new System.Drawing.Size(100, 23);
            this.lblSTkTo.TabIndex = 1;
            this.lblSTkTo.Text = "To Stock Code :";
            this.lblSTkTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(9, 103);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(100, 23);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year(YYYY)";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(12, 139);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(100, 23);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "Month(MM)";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboFrom
            // 
            this.cboFrom.Location = new System.Drawing.Point(121, 24);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(157, 21);
            this.cboFrom.TabIndex = 4;
            // 
            // cboTo
            // 
            this.cboTo.Location = new System.Drawing.Point(121, 61);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(157, 21);
            this.cboTo.TabIndex = 5;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(121, 100);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 6;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(121, 136);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(100, 20);
            this.txtMonth.TabIndex = 7;
            // 
            // chkTakeQty
            // 
            this.chkTakeQty.Checked = false;
            this.chkTakeQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkTakeQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkTakeQty.Location = new System.Drawing.Point(121, 177);
            this.chkTakeQty.Name = "chkTakeQty";
            this.chkTakeQty.Size = new System.Drawing.Size(104, 24);
            this.chkTakeQty.TabIndex = 8;
            this.chkTakeQty.Text = "Show Take Qty";
            this.chkTakeQty.ThreeState = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(145, 234);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(226, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InOutHistory_Monthly
            // 
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(315, 266);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "In / Out History -> Monthly";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Label lblSTkFrom;
        private Gizmox.WebGUI.Forms.Label lblSTkTo;
        private Gizmox.WebGUI.Forms.Label lblYear;
        private Gizmox.WebGUI.Forms.Label lblMonth;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.TextBox txtYear;
        private Gizmox.WebGUI.Forms.TextBox txtMonth;
        private Gizmox.WebGUI.Forms.CheckBox chkTakeQty;
        private Gizmox.WebGUI.Forms.Button btnPreview;
        private Gizmox.WebGUI.Forms.Button btnCancel;



    }
}