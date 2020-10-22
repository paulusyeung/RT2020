namespace RT2020.Member.Reports
{
    partial class RptVipThanksLetterForm
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
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.lblPurchaseValue = new Gizmox.WebGUI.Forms.Label();
            this.cmbFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtPurchaseValue = new Gizmox.WebGUI.Forms.TextBox();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.lblLetterWording = new Gizmox.WebGUI.Forms.Label();
            this.txtLetterWording = new Gizmox.WebGUI.Forms.TextBox();
            this.lblIncludeInactiveVIP = new Gizmox.WebGUI.Forms.Label();
            this.chkIncludeInactiveVIP = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblFrom.Location = new System.Drawing.Point(14, 21);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(92, 23);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From VIP#";
            // 
            // lblTo
            // 
            this.lblTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTo.Location = new System.Drawing.Point(14, 56);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(92, 23);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "To VIP#";
            // 
            // lblPurchaseValue
            // 
            this.lblPurchaseValue.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPurchaseValue.Location = new System.Drawing.Point(14, 180);
            this.lblPurchaseValue.Name = "lblPurchaseValue";
            this.lblPurchaseValue.Size = new System.Drawing.Size(115, 23);
            this.lblPurchaseValue.TabIndex = 0;
            this.lblPurchaseValue.Text = "Purchase Value HK$";
            // 
            // cmbFrom
            // 
            this.cmbFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmbFrom.DropDownWidth = 121;
            this.cmbFrom.Location = new System.Drawing.Point(135, 21);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(120, 21);
            this.cmbFrom.TabIndex = 1;
            // 
            // cmbTo
            // 
            this.cmbTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmbTo.DropDownWidth = 121;
            this.cmbTo.Location = new System.Drawing.Point(135, 58);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(120, 21);
            this.cmbTo.TabIndex = 2;
            // 
            // txtPurchaseValue
            // 
            this.txtPurchaseValue.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPurchaseValue.Location = new System.Drawing.Point(135, 181);
            this.txtPurchaseValue.Name = "txtPurchaseValue";
            this.txtPurchaseValue.Size = new System.Drawing.Size(120, 20);
            this.txtPurchaseValue.TabIndex = 4;
            this.txtPurchaseValue.Text = "0";
            // 
            // btnPrint
            // 
            this.btnPrint.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnPrint.Location = new System.Drawing.Point(351, 195);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(101, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print to Word";
            this.btnPrint.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExit.Location = new System.Drawing.Point(351, 219);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblLetterWording
            // 
            this.lblLetterWording.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLetterWording.Location = new System.Drawing.Point(14, 95);
            this.lblLetterWording.Name = "lblLetterWording";
            this.lblLetterWording.Size = new System.Drawing.Size(100, 23);
            this.lblLetterWording.TabIndex = 0;
            this.lblLetterWording.Text = "Letter Wording";
            // 
            // txtLetterWording
            // 
            this.txtLetterWording.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtLetterWording.Location = new System.Drawing.Point(135, 92);
            this.txtLetterWording.Multiline = true;
            this.txtLetterWording.Name = "txtLetterWording";
            this.txtLetterWording.Size = new System.Drawing.Size(215, 76);
            this.txtLetterWording.TabIndex = 3;
            // 
            // lblIncludeInactiveVIP
            // 
            this.lblIncludeInactiveVIP.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblIncludeInactiveVIP.Location = new System.Drawing.Point(14, 222);
            this.lblIncludeInactiveVIP.Name = "lblIncludeInactiveVIP";
            this.lblIncludeInactiveVIP.Size = new System.Drawing.Size(115, 23);
            this.lblIncludeInactiveVIP.TabIndex = 0;
            this.lblIncludeInactiveVIP.Text = "Print Inactive VIP";
            // 
            // chkIncludeInactiveVIP
            // 
            this.chkIncludeInactiveVIP.Checked = false;
            this.chkIncludeInactiveVIP.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkIncludeInactiveVIP.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkIncludeInactiveVIP.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkIncludeInactiveVIP.Location = new System.Drawing.Point(135, 217);
            this.chkIncludeInactiveVIP.Name = "chkIncludeInactiveVIP";
            this.chkIncludeInactiveVIP.Size = new System.Drawing.Size(104, 24);
            this.chkIncludeInactiveVIP.TabIndex = 5;
            this.chkIncludeInactiveVIP.ThreeState = false;
            // 
            // RptVipThanksLetterForm
            // 
            this.Controls.Add(this.chkIncludeInactiveVIP);
            this.Controls.Add(this.lblIncludeInactiveVIP);
            this.Controls.Add(this.txtLetterWording);
            this.Controls.Add(this.lblLetterWording);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtPurchaseValue);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.lblPurchaseValue);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Size = new System.Drawing.Size(464, 253);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Vip Thanks Letter Printing Wizard";
            this.Load += new System.EventHandler(this.RptVipThanksLetterForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Label lblPurchaseValue;
        private Gizmox.WebGUI.Forms.ComboBox cmbFrom;
        private Gizmox.WebGUI.Forms.ComboBox cmbTo;
        private Gizmox.WebGUI.Forms.TextBox txtPurchaseValue;
        private Gizmox.WebGUI.Forms.Button btnPrint;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Label lblLetterWording;
        private Gizmox.WebGUI.Forms.TextBox txtLetterWording;
        private Gizmox.WebGUI.Forms.Label lblIncludeInactiveVIP;
        private Gizmox.WebGUI.Forms.CheckBox chkIncludeInactiveVIP;


    }
}