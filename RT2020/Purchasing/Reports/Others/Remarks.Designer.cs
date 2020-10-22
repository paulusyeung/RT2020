namespace RT2020.Purchasing.Reports.Others
{
    partial class Remarks
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
            this.cmdPDF = new Gizmox.WebGUI.Forms.Button();
            this.cmdExcel = new Gizmox.WebGUI.Forms.Button();
            this.cmdPreview = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblRemarkCode = new Gizmox.WebGUI.Forms.Label();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.cboFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdPDF
            // 
            this.cmdPDF.ClientAction = null;
            this.cmdPDF.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdPDF.Location = new System.Drawing.Point(80, 136);
            this.cmdPDF.Name = "cmdPDF";
            this.cmdPDF.Size = new System.Drawing.Size(75, 23);
            this.cmdPDF.TabIndex = 4;
            this.cmdPDF.Text = "PDF";
            this.cmdPDF.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdPDF.Click += new System.EventHandler(this.CmdPDF_Click);
            // 
            // cmdExcel
            // 
            this.cmdExcel.ClientAction = null;
            this.cmdExcel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdExcel.Location = new System.Drawing.Point(163, 136);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(75, 23);
            this.cmdExcel.TabIndex = 4;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.ClientAction = null;
            this.cmdPreview.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdPreview.Location = new System.Drawing.Point(246, 136);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(75, 23);
            this.cmdPreview.TabIndex = 4;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdPreview.Click += new System.EventHandler(this.CmdPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.ClientAction = null;
            this.btnExit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExit.Location = new System.Drawing.Point(329, 136);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Cancel";
            this.btnExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.ClientAction = null;
            this.groupBox2.Controls.Add(this.lblRemarkCode);
            this.groupBox2.Controls.Add(this.cboTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.cboFrom);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(15, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Range";
            // 
            // lblRemarkCode
            // 
            this.lblRemarkCode.ClientAction = null;
            this.lblRemarkCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblRemarkCode.Location = new System.Drawing.Point(15, 19);
            this.lblRemarkCode.Name = "lblRemarkCode";
            this.lblRemarkCode.Size = new System.Drawing.Size(84, 17);
            this.lblRemarkCode.TabIndex = 6;
            this.lblRemarkCode.TabStop = false;
            this.lblRemarkCode.Text = "Remark Code:";
            // 
            // cboTo
            // 
            this.cboTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboTo.ClientAction = null;
            this.cboTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboTo.DropDownWidth = 143;
            this.cboTo.Location = new System.Drawing.Point(294, 38);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(140, 21);
            this.cboTo.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.ClientAction = null;
            this.lblFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblFrom.Location = new System.Drawing.Point(28, 41);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 18);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.TabStop = false;
            this.lblFrom.Text = "From";
            // 
            // cboFrom
            // 
            this.cboFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboFrom.ClientAction = null;
            this.cboFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboFrom.DropDownWidth = 143;
            this.cboFrom.Location = new System.Drawing.Point(75, 38);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(140, 21);
            this.cboFrom.TabIndex = 0;
            // 
            // lblTo
            // 
            this.lblTo.ClientAction = null;
            this.lblTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTo.Location = new System.Drawing.Point(247, 41);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 18);
            this.lblTo.TabIndex = 3;
            this.lblTo.TabStop = false;
            this.lblTo.Text = "To";
            // 
            // Remarks
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.cmdExcel);
            this.Controls.Add(this.cmdPDF);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(485, 195);
            this.Text = "Purchase Order > Reports > Others > P.O. Remarks";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button cmdPDF;
        private Gizmox.WebGUI.Forms.Button cmdExcel;
        private Gizmox.WebGUI.Forms.Button cmdPreview;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.Label lblRemarkCode;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;


    }
}