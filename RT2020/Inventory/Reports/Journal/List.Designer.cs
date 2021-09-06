using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace RT2020.Inventory.Reports.Journal
{
    partial class List
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
            this.txtTo = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFrom = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSTkFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkTo = new Gizmox.WebGUI.Forms.Label();
            this.chkTakeQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.cmdPreview = new Gizmox.WebGUI.Forms.Button();
            this.cmdPDF = new Gizmox.WebGUI.Forms.Button();
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.datToDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.datFromDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblFromDate = new Gizmox.WebGUI.Forms.Label();
            this.lbltoDate = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.cmdPivot);
            this.splitContainer1.Panel1.Controls.Add(this.cmdExcel);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.cmdPreview);
            this.splitContainer1.Panel1.Controls.Add(this.cmdPDF);
            this.splitContainer1.Panel1.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.htmlBox1);
            this.splitContainer1.Size = new System.Drawing.Size(391, 296);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmdPivot
            // 
            this.cmdPivot.Location = new System.Drawing.Point(130, 258);
            this.cmdPivot.Name = "cmdPivot";
            this.cmdPivot.Size = new System.Drawing.Size(80, 23);
            this.cmdPivot.TabIndex = 4;
            this.cmdPivot.Text = "Pivot";
            this.cmdPivot.Click += new System.EventHandler(this.OnCommandClick);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Location = new System.Drawing.Point(130, 226);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(80, 23);
            this.cmdExcel.TabIndex = 3;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.Click += new System.EventHandler(this.OnCommandClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbltoDate);
            this.groupBox1.Controls.Add(this.txtTo);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Controls.Add(this.txtFrom);
            this.groupBox1.Controls.Add(this.datFromDate);
            this.groupBox1.Controls.Add(this.datToDate);
            this.groupBox1.Controls.Add(this.lblSTkFrom);
            this.groupBox1.Controls.Add(this.lblSTkTo);
            this.groupBox1.Controls.Add(this.chkTakeQty);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selections";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(106, 61);
            this.txtTo.Name = "txtTo";
            this.txtTo.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 3;
            this.txtTo.Enter += new System.EventHandler(this.txtTo_Enter);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(106, 24);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 1;
            this.txtFrom.Enter += new System.EventHandler(this.txtFrom_Enter);
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
            // chkTakeQty
            // 
            this.chkTakeQty.Location = new System.Drawing.Point(106, 177);
            this.chkTakeQty.Name = "chkTakeQty";
            this.chkTakeQty.Size = new System.Drawing.Size(100, 24);
            this.chkTakeQty.TabIndex = 8;
            this.chkTakeQty.Text = "Show Take Qty";
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(25, 226);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(80, 23);
            this.cmdPreview.TabIndex = 1;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.Click += new System.EventHandler(this.OnCommandClick);
            // 
            // cmdPDF
            // 
            this.cmdPDF.Location = new System.Drawing.Point(25, 258);
            this.cmdPDF.Name = "cmdPDF";
            this.cmdPDF.Size = new System.Drawing.Size(80, 23);
            this.cmdPDF.TabIndex = 2;
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
            this.htmlBox1.Size = new System.Drawing.Size(161, 296);
            this.htmlBox1.TabIndex = 0;
            // 
            // datToDate
            // 
            this.datToDate.CustomFormat = "yyyy-MM-dd";
            this.datToDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.datToDate.Location = new System.Drawing.Point(106, 134);
            this.datToDate.Name = "datToDate";
            this.datToDate.Size = new System.Drawing.Size(100, 21);
            this.datToDate.TabIndex = 7;
            // 
            // datFromDate
            // 
            this.datFromDate.CustomFormat = "yyyy-MM-dd";
            this.datFromDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.datFromDate.Location = new System.Drawing.Point(106, 97);
            this.datFromDate.Name = "datFromDate";
            this.datFromDate.Size = new System.Drawing.Size(100, 21);
            this.datFromDate.TabIndex = 5;
            this.datFromDate.ValueChanged += new System.EventHandler(this.datFromDate_ValueChanged);
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(18, 97);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.lblFromDate.Size = new System.Drawing.Size(86, 23);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From Date :";
            // 
            // lbltoDate
            // 
            this.lbltoDate.Location = new System.Drawing.Point(18, 134);
            this.lbltoDate.Name = "lbltoDate";
            this.lbltoDate.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.lbltoDate.Size = new System.Drawing.Size(86, 23);
            this.lbltoDate.TabIndex = 6;
            this.lbltoDate.Text = "To Date :";
            // 
            // List
            // 
            this.Controls.Add(this.splitContainer1);
            this.Size = new System.Drawing.Size(391, 296);
            this.Text = "List";
            this.Load += new System.EventHandler(this.Monthly_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private Label lblSTkFrom;
        private Label lblSTkTo;
        private CheckBox chkTakeQty;
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
    }
}