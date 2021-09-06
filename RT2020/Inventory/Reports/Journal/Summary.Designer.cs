using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace RT2020.Inventory.Reports.Journal
{
    partial class Summary
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
            this.cmdPivot = new Gizmox.WebGUI.Forms.Button();
            this.cmdExcel = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblIgnorQty = new Gizmox.WebGUI.Forms.Label();
            this.pnlWorkplace = new Gizmox.WebGUI.Forms.Panel();
            this.tvwWorkplace = new Gizmox.WebGUI.Forms.TreeView();
            this.lbltoDate = new Gizmox.WebGUI.Forms.Label();
            this.txtTo = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFromDate = new Gizmox.WebGUI.Forms.Label();
            this.txtFrom = new Gizmox.WebGUI.Forms.TextBox();
            this.datFromDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.datToDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblSTkFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkTo = new Gizmox.WebGUI.Forms.Label();
            this.chkZeroQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.cmdPreview = new Gizmox.WebGUI.Forms.Button();
            this.cmdPDF = new Gizmox.WebGUI.Forms.Button();
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.pnlDown = new Gizmox.WebGUI.Forms.Panel();
            this.pnlUp = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.pnlWorkplace.SuspendLayout();
            this.pnlDown.SuspendLayout();
            this.pnlUp.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.pnlUp);
            this.splitContainer1.Panel1.Controls.Add(this.pnlDown);
            this.splitContainer1.Panel1.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.htmlBox1);
            this.splitContainer1.Size = new System.Drawing.Size(390, 1088);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmdPivot
            // 
            this.cmdPivot.Location = new System.Drawing.Point(123, 42);
            this.cmdPivot.Name = "cmdPivot";
            this.cmdPivot.Size = new System.Drawing.Size(80, 23);
            this.cmdPivot.TabIndex = 3;
            this.cmdPivot.Text = "Pivot";
            this.cmdPivot.Click += new System.EventHandler(this.OnCommandClick);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Location = new System.Drawing.Point(123, 10);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(80, 23);
            this.cmdExcel.TabIndex = 2;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.Click += new System.EventHandler(this.OnCommandClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.pnlWorkplace);
            this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new Gizmox.WebGUI.Forms.Padding(0, 0, 6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Gizmox.WebGUI.Forms.Padding(3, 6, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(228, 566);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selections";
            // 
            // lblIgnorQty
            // 
            this.lblIgnorQty.Location = new System.Drawing.Point(12, 117);
            this.lblIgnorQty.Name = "lblIgnorQty";
            this.lblIgnorQty.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.lblIgnorQty.Size = new System.Drawing.Size(90, 20);
            this.lblIgnorQty.TabIndex = 8;
            this.lblIgnorQty.Text = "Ignor Zero Qty:";
            this.lblIgnorQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlWorkplace
            // 
            this.pnlWorkplace.Controls.Add(this.tvwWorkplace);
            this.pnlWorkplace.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlWorkplace.Location = new System.Drawing.Point(3, 20);
            this.pnlWorkplace.Margin = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 140);
            this.pnlWorkplace.Name = "pnlWorkplace";
            this.pnlWorkplace.Size = new System.Drawing.Size(222, 543);
            this.pnlWorkplace.TabIndex = 0;
            // 
            // tvwWorkplace
            // 
            this.tvwWorkplace.Location = new System.Drawing.Point(56, 61);
            this.tvwWorkplace.Name = "tvwWorkplace";
            this.tvwWorkplace.Size = new System.Drawing.Size(100, 100);
            this.tvwWorkplace.TabIndex = 0;
            // 
            // lbltoDate
            // 
            this.lbltoDate.Location = new System.Drawing.Point(12, 90);
            this.lbltoDate.Name = "lbltoDate";
            this.lbltoDate.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.lbltoDate.Size = new System.Drawing.Size(90, 20);
            this.lbltoDate.TabIndex = 6;
            this.lbltoDate.Text = "To Date :";
            this.lbltoDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(102, 35);
            this.txtTo.Name = "txtTo";
            this.txtTo.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 3;
            this.txtTo.Enter += new System.EventHandler(this.txtTo_Enter);
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(12, 62);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.lblFromDate.Size = new System.Drawing.Size(90, 20);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From Date :";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(102, 9);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 1;
            this.txtFrom.Enter += new System.EventHandler(this.txtFrom_Enter);
            // 
            // datFromDate
            // 
            this.datFromDate.CustomFormat = "yyyy-MM-dd";
            this.datFromDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.datFromDate.Location = new System.Drawing.Point(102, 62);
            this.datFromDate.Name = "datFromDate";
            this.datFromDate.Size = new System.Drawing.Size(100, 21);
            this.datFromDate.TabIndex = 5;
            this.datFromDate.ValueChanged += new System.EventHandler(this.datFromDate_ValueChanged);
            // 
            // datToDate
            // 
            this.datToDate.CustomFormat = "yyyy-MM-dd";
            this.datToDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.datToDate.Location = new System.Drawing.Point(102, 90);
            this.datToDate.Name = "datToDate";
            this.datToDate.Size = new System.Drawing.Size(100, 21);
            this.datToDate.TabIndex = 7;
            // 
            // lblSTkFrom
            // 
            this.lblSTkFrom.Location = new System.Drawing.Point(12, 9);
            this.lblSTkFrom.Name = "lblSTkFrom";
            this.lblSTkFrom.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.lblSTkFrom.Size = new System.Drawing.Size(90, 20);
            this.lblSTkFrom.TabIndex = 0;
            this.lblSTkFrom.Text = "From STKCODE :";
            this.lblSTkFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSTkTo
            // 
            this.lblSTkTo.Location = new System.Drawing.Point(12, 35);
            this.lblSTkTo.Name = "lblSTkTo";
            this.lblSTkTo.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.lblSTkTo.Size = new System.Drawing.Size(90, 20);
            this.lblSTkTo.TabIndex = 2;
            this.lblSTkTo.Text = "To Stock Code :";
            this.lblSTkTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkZeroQty
            // 
            this.chkZeroQty.Location = new System.Drawing.Point(102, 115);
            this.chkZeroQty.Name = "chkZeroQty";
            this.chkZeroQty.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.chkZeroQty.Size = new System.Drawing.Size(100, 24);
            this.chkZeroQty.TabIndex = 9;
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(18, 10);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(80, 23);
            this.cmdPreview.TabIndex = 0;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.Click += new System.EventHandler(this.OnCommandClick);
            // 
            // cmdPDF
            // 
            this.cmdPDF.Location = new System.Drawing.Point(18, 42);
            this.cmdPDF.Name = "cmdPDF";
            this.cmdPDF.Size = new System.Drawing.Size(80, 23);
            this.cmdPDF.TabIndex = 1;
            this.cmdPDF.Text = "PDF";
            this.cmdPDF.Click += new System.EventHandler(this.OnCommandClick);
            // 
            // htmlBox1
            // 
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.htmlBox1.Html = "<HTML></HTML>";
            this.htmlBox1.Location = new System.Drawing.Point(0, 0);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(161, 1088);
            this.htmlBox1.TabIndex = 0;
            // 
            // pnlDown
            // 
            this.pnlDown.Controls.Add(this.cmdExcel);
            this.pnlDown.Controls.Add(this.cmdPivot);
            this.pnlDown.Controls.Add(this.cmdPDF);
            this.pnlDown.Controls.Add(this.cmdPreview);
            this.pnlDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.pnlDown.Location = new System.Drawing.Point(0, 1014);
            this.pnlDown.Name = "pnlDown";
            this.pnlDown.Size = new System.Drawing.Size(228, 74);
            this.pnlDown.TabIndex = 0;
            // 
            // pnlUp
            // 
            this.pnlUp.Controls.Add(this.groupBox1);
            this.pnlUp.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlUp.Location = new System.Drawing.Point(0, 0);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(228, 1014);
            this.pnlUp.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTo);
            this.panel1.Controls.Add(this.lblIgnorQty);
            this.panel1.Controls.Add(this.chkZeroQty);
            this.panel1.Controls.Add(this.lblSTkTo);
            this.panel1.Controls.Add(this.lbltoDate);
            this.panel1.Controls.Add(this.lblSTkFrom);
            this.panel1.Controls.Add(this.datToDate);
            this.panel1.Controls.Add(this.lblFromDate);
            this.panel1.Controls.Add(this.datFromDate);
            this.panel1.Controls.Add(this.txtFrom);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 140);
            this.panel1.TabIndex = 1;
            // 
            // Summary
            // 
            this.Controls.Add(this.splitContainer1);
            this.Size = new System.Drawing.Size(391, 640);
            this.Text = "List";
            this.Load += new System.EventHandler(this.Monthly_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlWorkplace.ResumeLayout(false);
            this.pnlDown.ResumeLayout(false);
            this.pnlUp.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private Label lblSTkFrom;
        private Label lblSTkTo;
        private CheckBox chkZeroQty;
        private Button cmdPreview;
        private Button cmdPDF;
        private HtmlBox htmlBox1;
        private TextBox txtTo;
        private TextBox txtFrom;
        private Button cmdExcel;
        private Button cmdPivot;
        private Label lbltoDate;
        private Label lblFromDate;
        private DateTimePicker datFromDate;
        private DateTimePicker datToDate;
        private Panel pnlWorkplace;
        private TreeView tvwWorkplace;
        private Label lblIgnorQty;
        private Panel pnlUp;
        private Panel panel1;
        private Panel pnlDown;
    }
}