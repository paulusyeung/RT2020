namespace RT2020.EmulatedPoS
{
    partial class AmendPaymentItem
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.cboTypeCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.cboCurrencyCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtXchgRate = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAmountHkd = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCardChq = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAuthorize = new Gizmox.WebGUI.Forms.TextBox();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // cboTypeCode
            // 
            this.cboTypeCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboTypeCode.Location = new System.Drawing.Point(90, 17);
            this.cboTypeCode.Name = "cboTypeCode";
            this.cboTypeCode.Size = new System.Drawing.Size(96, 21);
            this.cboTypeCode.TabIndex = 1;
            this.cboTypeCode.SelectedIndexChanged += new System.EventHandler(this.cboTypeCode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount";
            // 
            // cboCurrencyCode
            // 
            this.cboCurrencyCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrencyCode.Location = new System.Drawing.Point(90, 44);
            this.cboCurrencyCode.Name = "cboCurrencyCode";
            this.cboCurrencyCode.Size = new System.Drawing.Size(96, 21);
            this.cboCurrencyCode.TabIndex = 3;
            this.cboCurrencyCode.SelectedIndexChanged += new System.EventHandler(this.cboCurrencyCode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Curr/Card";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(90, 70);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(96, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Xchg Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Amount(HKD)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Card#/Chq#";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Authorize#";
            // 
            // txtXchgRate
            // 
            this.txtXchgRate.Location = new System.Drawing.Point(90, 96);
            this.txtXchgRate.Name = "txtXchgRate";
            this.txtXchgRate.Size = new System.Drawing.Size(96, 20);
            this.txtXchgRate.TabIndex = 10;
            this.txtXchgRate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtAmountHkd
            // 
            this.txtAmountHkd.Location = new System.Drawing.Point(90, 122);
            this.txtAmountHkd.Name = "txtAmountHkd";
            this.txtAmountHkd.ReadOnly = true;
            this.txtAmountHkd.Size = new System.Drawing.Size(96, 20);
            this.txtAmountHkd.TabIndex = 11;
            this.txtAmountHkd.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtCardChq
            // 
            this.txtCardChq.Location = new System.Drawing.Point(90, 148);
            this.txtCardChq.Name = "txtCardChq";
            this.txtCardChq.Size = new System.Drawing.Size(161, 20);
            this.txtCardChq.TabIndex = 12;
            // 
            // txtAuthorize
            // 
            this.txtAuthorize.Location = new System.Drawing.Point(90, 174);
            this.txtAuthorize.Name = "txtAuthorize";
            this.txtAuthorize.Size = new System.Drawing.Size(96, 20);
            this.txtAuthorize.TabIndex = 13;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(52, 215);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(133, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AmendPaymentItem
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtAuthorize);
            this.Controls.Add(this.txtCardChq);
            this.Controls.Add(this.txtAmountHkd);
            this.Controls.Add(this.txtXchgRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCurrencyCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTypeCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(261, 252);
            this.Text = "AmendPaymentItem";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.ComboBox cboTypeCode;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.ComboBox cboCurrencyCode;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.TextBox txtAmount;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Label label7;
        private Gizmox.WebGUI.Forms.TextBox txtXchgRate;
        private Gizmox.WebGUI.Forms.TextBox txtAmountHkd;
        private Gizmox.WebGUI.Forms.TextBox txtCardChq;
        private Gizmox.WebGUI.Forms.TextBox txtAuthorize;
        private Gizmox.WebGUI.Forms.Button btnOk;
        private Gizmox.WebGUI.Forms.Button btnCancel;


    }
}