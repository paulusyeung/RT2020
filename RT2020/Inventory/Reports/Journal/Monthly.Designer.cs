using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace RT2020.Inventory.Reports.Journal
{
    partial class Monthly
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
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblSTkFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkTo = new Gizmox.WebGUI.Forms.Label();
            this.lblYear = new Gizmox.WebGUI.Forms.Label();
            this.lblMonth = new Gizmox.WebGUI.Forms.Label();
            this.txtYear = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonth = new Gizmox.WebGUI.Forms.TextBox();
            this.chkTakeQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.cmdPDF = new Gizmox.WebGUI.Forms.Button();
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.txtFrom = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTo = new Gizmox.WebGUI.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel1.Controls.Add(this.cmdPDF);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.htmlBox1);
            this.splitContainer1.Size = new System.Drawing.Size(384, 306);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTo);
            this.groupBox1.Controls.Add(this.txtFrom);
            this.groupBox1.Controls.Add(this.lblSTkFrom);
            this.groupBox1.Controls.Add(this.lblSTkTo);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.lblMonth);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.txtMonth);
            this.groupBox1.Controls.Add(this.chkTakeQty);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selections";
            // 
            // lblSTkFrom
            // 
            this.lblSTkFrom.Location = new System.Drawing.Point(18, 27);
            this.lblSTkFrom.Name = "lblSTkFrom";
            this.lblSTkFrom.Size = new System.Drawing.Size(86, 23);
            this.lblSTkFrom.TabIndex = 0;
            this.lblSTkFrom.Text = "From STKCODE :";
            // 
            // lblSTkTo
            // 
            this.lblSTkTo.Location = new System.Drawing.Point(18, 64);
            this.lblSTkTo.Name = "lblSTkTo";
            this.lblSTkTo.Size = new System.Drawing.Size(86, 23);
            this.lblSTkTo.TabIndex = 2;
            this.lblSTkTo.Text = "To Stock Code :";
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(18, 103);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(86, 23);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year (YYYY):";
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(18, 139);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(86, 23);
            this.lblMonth.TabIndex = 6;
            this.lblMonth.Text = "Month (MM):";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(106, 100);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 5;
            this.txtYear.Enter += new System.EventHandler(this.txtYear_Enter);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(106, 136);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(100, 20);
            this.txtMonth.TabIndex = 7;
            this.txtMonth.Enter += new System.EventHandler(this.txtMonth_Enter);
            // 
            // chkTakeQty
            // 
            this.chkTakeQty.Location = new System.Drawing.Point(106, 177);
            this.chkTakeQty.Name = "chkTakeQty";
            this.chkTakeQty.Size = new System.Drawing.Size(100, 24);
            this.chkTakeQty.TabIndex = 8;
            this.chkTakeQty.Text = "Show Take Qty";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(64, 226);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cmdPDF
            // 
            this.cmdPDF.Location = new System.Drawing.Point(145, 226);
            this.cmdPDF.Name = "cmdPDF";
            this.cmdPDF.Size = new System.Drawing.Size(75, 23);
            this.cmdPDF.TabIndex = 2;
            this.cmdPDF.Text = "PDF";
            this.cmdPDF.Click += new System.EventHandler(this.cmdPDF_Click);
            // 
            // htmlBox1
            // 
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.htmlBox1.Html = "<HTML></HTML>";
            this.htmlBox1.Location = new System.Drawing.Point(0, 0);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(161, 306);
            this.htmlBox1.TabIndex = 0;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(106, 24);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 1;
            this.txtFrom.Enter += new System.EventHandler(this.txtFrom_Enter);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(106, 61);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 3;
            this.txtTo.Enter += new System.EventHandler(this.txtTo_Enter);
            // 
            // Monthly
            // 
            this.Controls.Add(this.splitContainer1);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Monthly";
            this.Load += new System.EventHandler(this.Monthly_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private Label lblSTkFrom;
        private Label lblSTkTo;
        private Label lblYear;
        private Label lblMonth;
        private TextBox txtYear;
        private TextBox txtMonth;
        private CheckBox chkTakeQty;
        private Button btnPreview;
        private Button cmdPDF;
        private HtmlBox htmlBox1;
        private TextBox txtTo;
        private TextBox txtFrom;
    }
}