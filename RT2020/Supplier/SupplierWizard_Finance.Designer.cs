namespace RT2020.Supplier
{
    partial class SupplierWizard_Finance
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
            this.lblCreditLimit = new Gizmox.WebGUI.Forms.Label();
            this.txtCreditLimit = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTerms = new Gizmox.WebGUI.Forms.Label();
            this.cboTerms = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCurrency = new Gizmox.WebGUI.Forms.Label();
            this.cboCurrency = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblBFAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtBFAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCDAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtCDAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLastPurchasedOn = new Gizmox.WebGUI.Forms.Label();
            this.lblLastPaidOn = new Gizmox.WebGUI.Forms.Label();
            this.lblLastReturnedOn = new Gizmox.WebGUI.Forms.Label();
            this.gbDiscount = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblOthersDiscountPcn = new Gizmox.WebGUI.Forms.Label();
            this.txtOthersDiscount = new Gizmox.WebGUI.Forms.TextBox();
            this.lblOthersDiscount = new Gizmox.WebGUI.Forms.Label();
            this.lblCashDiscountPcn = new Gizmox.WebGUI.Forms.Label();
            this.txtCashDiscount = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCashDiscount = new Gizmox.WebGUI.Forms.Label();
            this.lblYearEndBonusPcn = new Gizmox.WebGUI.Forms.Label();
            this.txtYearEndBonus = new Gizmox.WebGUI.Forms.TextBox();
            this.lblYearEndBonus = new Gizmox.WebGUI.Forms.Label();
            this.lblQuotaDiscountPcn = new Gizmox.WebGUI.Forms.Label();
            this.txtQuotaDiscount = new Gizmox.WebGUI.Forms.TextBox();
            this.lblQuotaDiscount = new Gizmox.WebGUI.Forms.Label();
            this.lblWholesalesDiscountPcn = new Gizmox.WebGUI.Forms.Label();
            this.txtWholesalesDiscount = new Gizmox.WebGUI.Forms.TextBox();
            this.lblWholesalesDiscount = new Gizmox.WebGUI.Forms.Label();
            this.lblNormalDiscountPcn = new Gizmox.WebGUI.Forms.Label();
            this.txtNormalDiscount = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNormalDiscount = new Gizmox.WebGUI.Forms.Label();
            this.datLastPurchased = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.datLastPaid = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.datLastReturned = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.gbDiscount.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCreditLimit
            // 
            this.lblCreditLimit.Location = new System.Drawing.Point(16, 18);
            this.lblCreditLimit.Name = "lblCreditLimit";
            this.lblCreditLimit.Size = new System.Drawing.Size(100, 23);
            this.lblCreditLimit.TabIndex = 0;
            this.lblCreditLimit.Text = "Credit Limit:";
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Location = new System.Drawing.Point(122, 15);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(100, 20);
            this.txtCreditLimit.TabIndex = 1;
            this.txtCreditLimit.Text = "0.00";
            this.txtCreditLimit.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblTerms
            // 
            this.lblTerms.Location = new System.Drawing.Point(16, 41);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(100, 23);
            this.lblTerms.TabIndex = 2;
            this.lblTerms.Text = "Terms:";
            // 
            // cboTerms
            // 
            this.cboTerms.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboTerms.DropDownWidth = 100;
            this.cboTerms.Location = new System.Drawing.Point(122, 38);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(100, 21);
            this.cboTerms.TabIndex = 3;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Location = new System.Drawing.Point(16, 64);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(100, 23);
            this.lblCurrency.TabIndex = 4;
            this.lblCurrency.Text = "Currency:";
            // 
            // cboCurrency
            // 
            this.cboCurrency.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrency.DropDownWidth = 100;
            this.cboCurrency.Location = new System.Drawing.Point(122, 61);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(100, 21);
            this.cboCurrency.TabIndex = 5;
            // 
            // lblBFAmount
            // 
            this.lblBFAmount.Location = new System.Drawing.Point(16, 126);
            this.lblBFAmount.Name = "lblBFAmount";
            this.lblBFAmount.Size = new System.Drawing.Size(100, 23);
            this.lblBFAmount.TabIndex = 6;
            this.lblBFAmount.Text = "B/F Amount:";
            // 
            // txtBFAmount
            // 
            this.txtBFAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtBFAmount.Location = new System.Drawing.Point(122, 123);
            this.txtBFAmount.Name = "txtBFAmount";
            this.txtBFAmount.ReadOnly = true;
            this.txtBFAmount.Size = new System.Drawing.Size(100, 20);
            this.txtBFAmount.TabIndex = 7;
            this.txtBFAmount.TabStop = false;
            this.txtBFAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblCDAmount
            // 
            this.lblCDAmount.Location = new System.Drawing.Point(16, 149);
            this.lblCDAmount.Name = "lblCDAmount";
            this.lblCDAmount.Size = new System.Drawing.Size(100, 23);
            this.lblCDAmount.TabIndex = 8;
            this.lblCDAmount.Text = "C/D Amount:";
            // 
            // txtCDAmount
            // 
            this.txtCDAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtCDAmount.Location = new System.Drawing.Point(122, 146);
            this.txtCDAmount.Name = "txtCDAmount";
            this.txtCDAmount.ReadOnly = true;
            this.txtCDAmount.Size = new System.Drawing.Size(100, 20);
            this.txtCDAmount.TabIndex = 9;
            this.txtCDAmount.TabStop = false;
            this.txtCDAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblLastPurchasedOn
            // 
            this.lblLastPurchasedOn.Location = new System.Drawing.Point(16, 172);
            this.lblLastPurchasedOn.Name = "lblLastPurchasedOn";
            this.lblLastPurchasedOn.Size = new System.Drawing.Size(100, 23);
            this.lblLastPurchasedOn.TabIndex = 10;
            this.lblLastPurchasedOn.Text = "Last Purchase:";
            // 
            // lblLastPaidOn
            // 
            this.lblLastPaidOn.Location = new System.Drawing.Point(16, 195);
            this.lblLastPaidOn.Name = "lblLastPaidOn";
            this.lblLastPaidOn.Size = new System.Drawing.Size(100, 23);
            this.lblLastPaidOn.TabIndex = 12;
            this.lblLastPaidOn.Text = "Last Pay Date:";
            // 
            // lblLastReturnedOn
            // 
            this.lblLastReturnedOn.Location = new System.Drawing.Point(16, 218);
            this.lblLastReturnedOn.Name = "lblLastReturnedOn";
            this.lblLastReturnedOn.Size = new System.Drawing.Size(100, 23);
            this.lblLastReturnedOn.TabIndex = 14;
            this.lblLastReturnedOn.Text = "Last Return Date:";
            // 
            // gbDiscount
            // 
            this.gbDiscount.Controls.Add(this.lblOthersDiscountPcn);
            this.gbDiscount.Controls.Add(this.txtOthersDiscount);
            this.gbDiscount.Controls.Add(this.lblOthersDiscount);
            this.gbDiscount.Controls.Add(this.lblCashDiscountPcn);
            this.gbDiscount.Controls.Add(this.txtCashDiscount);
            this.gbDiscount.Controls.Add(this.lblCashDiscount);
            this.gbDiscount.Controls.Add(this.lblYearEndBonusPcn);
            this.gbDiscount.Controls.Add(this.txtYearEndBonus);
            this.gbDiscount.Controls.Add(this.lblYearEndBonus);
            this.gbDiscount.Controls.Add(this.lblQuotaDiscountPcn);
            this.gbDiscount.Controls.Add(this.txtQuotaDiscount);
            this.gbDiscount.Controls.Add(this.lblQuotaDiscount);
            this.gbDiscount.Controls.Add(this.lblWholesalesDiscountPcn);
            this.gbDiscount.Controls.Add(this.txtWholesalesDiscount);
            this.gbDiscount.Controls.Add(this.lblWholesalesDiscount);
            this.gbDiscount.Controls.Add(this.lblNormalDiscountPcn);
            this.gbDiscount.Controls.Add(this.txtNormalDiscount);
            this.gbDiscount.Controls.Add(this.lblNormalDiscount);
            this.gbDiscount.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbDiscount.Location = new System.Drawing.Point(277, 8);
            this.gbDiscount.Name = "gbDiscount";
            this.gbDiscount.Size = new System.Drawing.Size(266, 227);
            this.gbDiscount.TabIndex = 16;
            this.gbDiscount.TabStop = false;
            this.gbDiscount.Text = "Discount";
            // 
            // lblOthersDiscountPcn
            // 
            this.lblOthersDiscountPcn.Location = new System.Drawing.Point(230, 141);
            this.lblOthersDiscountPcn.Name = "lblOthersDiscountPcn";
            this.lblOthersDiscountPcn.Size = new System.Drawing.Size(63, 23);
            this.lblOthersDiscountPcn.TabIndex = 17;
            this.lblOthersDiscountPcn.Text = "%";
            // 
            // txtOthersDiscount
            // 
            this.txtOthersDiscount.Location = new System.Drawing.Point(124, 138);
            this.txtOthersDiscount.Name = "txtOthersDiscount";
            this.txtOthersDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtOthersDiscount.TabIndex = 16;
            this.txtOthersDiscount.Text = "0";
            this.txtOthersDiscount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblOthersDiscount
            // 
            this.lblOthersDiscount.Location = new System.Drawing.Point(18, 141);
            this.lblOthersDiscount.Name = "lblOthersDiscount";
            this.lblOthersDiscount.Size = new System.Drawing.Size(100, 23);
            this.lblOthersDiscount.TabIndex = 15;
            this.lblOthersDiscount.Text = "Others";
            // 
            // lblCashDiscountPcn
            // 
            this.lblCashDiscountPcn.Location = new System.Drawing.Point(230, 118);
            this.lblCashDiscountPcn.Name = "lblCashDiscountPcn";
            this.lblCashDiscountPcn.Size = new System.Drawing.Size(50, 23);
            this.lblCashDiscountPcn.TabIndex = 14;
            this.lblCashDiscountPcn.Text = "%";
            // 
            // txtCashDiscount
            // 
            this.txtCashDiscount.Location = new System.Drawing.Point(124, 115);
            this.txtCashDiscount.Name = "txtCashDiscount";
            this.txtCashDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtCashDiscount.TabIndex = 13;
            this.txtCashDiscount.Text = "0";
            this.txtCashDiscount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblCashDiscount
            // 
            this.lblCashDiscount.Location = new System.Drawing.Point(18, 118);
            this.lblCashDiscount.Name = "lblCashDiscount";
            this.lblCashDiscount.Size = new System.Drawing.Size(100, 23);
            this.lblCashDiscount.TabIndex = 12;
            this.lblCashDiscount.Text = "Cash:";
            // 
            // lblYearEndBonusPcn
            // 
            this.lblYearEndBonusPcn.Location = new System.Drawing.Point(230, 95);
            this.lblYearEndBonusPcn.Name = "lblYearEndBonusPcn";
            this.lblYearEndBonusPcn.Size = new System.Drawing.Size(50, 23);
            this.lblYearEndBonusPcn.TabIndex = 11;
            this.lblYearEndBonusPcn.Text = "%";
            // 
            // txtYearEndBonus
            // 
            this.txtYearEndBonus.Location = new System.Drawing.Point(124, 92);
            this.txtYearEndBonus.Name = "txtYearEndBonus";
            this.txtYearEndBonus.Size = new System.Drawing.Size(100, 20);
            this.txtYearEndBonus.TabIndex = 10;
            this.txtYearEndBonus.Text = "0";
            this.txtYearEndBonus.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblYearEndBonus
            // 
            this.lblYearEndBonus.Location = new System.Drawing.Point(18, 95);
            this.lblYearEndBonus.Name = "lblYearEndBonus";
            this.lblYearEndBonus.Size = new System.Drawing.Size(100, 23);
            this.lblYearEndBonus.TabIndex = 9;
            this.lblYearEndBonus.Text = "Year-End Bonus:";
            // 
            // lblQuotaDiscountPcn
            // 
            this.lblQuotaDiscountPcn.Location = new System.Drawing.Point(230, 72);
            this.lblQuotaDiscountPcn.Name = "lblQuotaDiscountPcn";
            this.lblQuotaDiscountPcn.Size = new System.Drawing.Size(50, 23);
            this.lblQuotaDiscountPcn.TabIndex = 8;
            this.lblQuotaDiscountPcn.Text = "%";
            // 
            // txtQuotaDiscount
            // 
            this.txtQuotaDiscount.Location = new System.Drawing.Point(124, 69);
            this.txtQuotaDiscount.Name = "txtQuotaDiscount";
            this.txtQuotaDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtQuotaDiscount.TabIndex = 7;
            this.txtQuotaDiscount.Text = "0";
            this.txtQuotaDiscount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblQuotaDiscount
            // 
            this.lblQuotaDiscount.Location = new System.Drawing.Point(18, 72);
            this.lblQuotaDiscount.Name = "lblQuotaDiscount";
            this.lblQuotaDiscount.Size = new System.Drawing.Size(100, 23);
            this.lblQuotaDiscount.TabIndex = 6;
            this.lblQuotaDiscount.Text = "Quota:";
            // 
            // lblWholesalesDiscountPcn
            // 
            this.lblWholesalesDiscountPcn.Location = new System.Drawing.Point(230, 49);
            this.lblWholesalesDiscountPcn.Name = "lblWholesalesDiscountPcn";
            this.lblWholesalesDiscountPcn.Size = new System.Drawing.Size(50, 23);
            this.lblWholesalesDiscountPcn.TabIndex = 5;
            this.lblWholesalesDiscountPcn.Text = "%";
            // 
            // txtWholesalesDiscount
            // 
            this.txtWholesalesDiscount.Location = new System.Drawing.Point(124, 46);
            this.txtWholesalesDiscount.Name = "txtWholesalesDiscount";
            this.txtWholesalesDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtWholesalesDiscount.TabIndex = 4;
            this.txtWholesalesDiscount.Text = "0";
            this.txtWholesalesDiscount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblWholesalesDiscount
            // 
            this.lblWholesalesDiscount.Location = new System.Drawing.Point(18, 49);
            this.lblWholesalesDiscount.Name = "lblWholesalesDiscount";
            this.lblWholesalesDiscount.Size = new System.Drawing.Size(100, 23);
            this.lblWholesalesDiscount.TabIndex = 3;
            this.lblWholesalesDiscount.Text = "Wholesales:";
            // 
            // lblNormalDiscountPcn
            // 
            this.lblNormalDiscountPcn.Location = new System.Drawing.Point(230, 26);
            this.lblNormalDiscountPcn.Name = "lblNormalDiscountPcn";
            this.lblNormalDiscountPcn.Size = new System.Drawing.Size(50, 23);
            this.lblNormalDiscountPcn.TabIndex = 2;
            this.lblNormalDiscountPcn.Text = "%";
            // 
            // txtNormalDiscount
            // 
            this.txtNormalDiscount.Location = new System.Drawing.Point(124, 23);
            this.txtNormalDiscount.Name = "txtNormalDiscount";
            this.txtNormalDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtNormalDiscount.TabIndex = 1;
            this.txtNormalDiscount.Text = "0";
            this.txtNormalDiscount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblNormalDiscount
            // 
            this.lblNormalDiscount.Location = new System.Drawing.Point(18, 26);
            this.lblNormalDiscount.Name = "lblNormalDiscount";
            this.lblNormalDiscount.Size = new System.Drawing.Size(100, 23);
            this.lblNormalDiscount.TabIndex = 0;
            this.lblNormalDiscount.Text = "Normal:";
            // 
            // datLastPurchased
            // 
            this.datLastPurchased.Checked = false;
            this.datLastPurchased.CustomFormat = "yyyy-MM-dd";
            this.datLastPurchased.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.datLastPurchased.Location = new System.Drawing.Point(122, 169);
            this.datLastPurchased.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.datLastPurchased.Name = "datLastPurchased";
            this.datLastPurchased.ShowCheckBox = true;
            this.datLastPurchased.Size = new System.Drawing.Size(100, 21);
            this.datLastPurchased.TabIndex = 11;
            // 
            // datLastPaid
            // 
            this.datLastPaid.Checked = false;
            this.datLastPaid.CustomFormat = "yyyy-MM-dd";
            this.datLastPaid.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.datLastPaid.Location = new System.Drawing.Point(122, 193);
            this.datLastPaid.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.datLastPaid.Name = "datLastPaid";
            this.datLastPaid.ShowCheckBox = true;
            this.datLastPaid.Size = new System.Drawing.Size(100, 21);
            this.datLastPaid.TabIndex = 13;
            // 
            // datLastReturned
            // 
            this.datLastReturned.Checked = false;
            this.datLastReturned.CustomFormat = "yyyy-MM-dd";
            this.datLastReturned.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.datLastReturned.Location = new System.Drawing.Point(122, 217);
            this.datLastReturned.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.datLastReturned.Name = "datLastReturned";
            this.datLastReturned.ShowCheckBox = true;
            this.datLastReturned.Size = new System.Drawing.Size(100, 21);
            this.datLastReturned.TabIndex = 15;
            // 
            // SupplierWizard_Finance
            // 
            this.Controls.Add(this.datLastReturned);
            this.Controls.Add(this.datLastPaid);
            this.Controls.Add(this.datLastPurchased);
            this.Controls.Add(this.gbDiscount);
            this.Controls.Add(this.lblLastReturnedOn);
            this.Controls.Add(this.lblLastPaidOn);
            this.Controls.Add(this.lblLastPurchasedOn);
            this.Controls.Add(this.txtCDAmount);
            this.Controls.Add(this.lblCDAmount);
            this.Controls.Add(this.txtBFAmount);
            this.Controls.Add(this.lblBFAmount);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cboTerms);
            this.Controls.Add(this.lblTerms);
            this.Controls.Add(this.txtCreditLimit);
            this.Controls.Add(this.lblCreditLimit);
            this.Size = new System.Drawing.Size(766, 379);
            this.Text = "SupplierWizard_Financial";
            this.Load += new System.EventHandler(this.SupplierWizard_Finance_Load);
            this.gbDiscount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblCreditLimit;
        private Gizmox.WebGUI.Forms.Label lblTerms;
        private Gizmox.WebGUI.Forms.Label lblCurrency;
        private Gizmox.WebGUI.Forms.Label lblBFAmount;
        private Gizmox.WebGUI.Forms.Label lblCDAmount;
        private Gizmox.WebGUI.Forms.Label lblLastPurchasedOn;
        private Gizmox.WebGUI.Forms.Label lblLastPaidOn;
        private Gizmox.WebGUI.Forms.Label lblLastReturnedOn;
        private Gizmox.WebGUI.Forms.GroupBox gbDiscount;
        private Gizmox.WebGUI.Forms.Label lblOthersDiscountPcn;
        private Gizmox.WebGUI.Forms.Label lblOthersDiscount;
        private Gizmox.WebGUI.Forms.Label lblCashDiscountPcn;
        private Gizmox.WebGUI.Forms.Label lblCashDiscount;
        private Gizmox.WebGUI.Forms.Label lblYearEndBonusPcn;
        private Gizmox.WebGUI.Forms.Label lblYearEndBonus;
        private Gizmox.WebGUI.Forms.Label lblQuotaDiscountPcn;
        private Gizmox.WebGUI.Forms.Label lblQuotaDiscount;
        private Gizmox.WebGUI.Forms.Label lblWholesalesDiscountPcn;
        private Gizmox.WebGUI.Forms.Label lblWholesalesDiscount;
        private Gizmox.WebGUI.Forms.Label lblNormalDiscountPcn;
        private Gizmox.WebGUI.Forms.Label lblNormalDiscount;
        public Gizmox.WebGUI.Forms.TextBox txtCreditLimit;
        public Gizmox.WebGUI.Forms.ComboBox cboTerms;
        public Gizmox.WebGUI.Forms.ComboBox cboCurrency;
        public Gizmox.WebGUI.Forms.TextBox txtBFAmount;
        public Gizmox.WebGUI.Forms.TextBox txtCDAmount;
        public Gizmox.WebGUI.Forms.TextBox txtOthersDiscount;
        public Gizmox.WebGUI.Forms.TextBox txtCashDiscount;
        public Gizmox.WebGUI.Forms.TextBox txtYearEndBonus;
        public Gizmox.WebGUI.Forms.TextBox txtQuotaDiscount;
        public Gizmox.WebGUI.Forms.TextBox txtWholesalesDiscount;
        public Gizmox.WebGUI.Forms.TextBox txtNormalDiscount;
        public Gizmox.WebGUI.Forms.DateTimePicker datLastPurchased;
        public Gizmox.WebGUI.Forms.DateTimePicker datLastPaid;
        public Gizmox.WebGUI.Forms.DateTimePicker datLastReturned;
    }
}