namespace RT2020.Member
{
    partial class MassUpdateWizard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MassUpdateWizard));
            this.gbxOptions = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblToGrade = new Gizmox.WebGUI.Forms.Label();
            this.cboFromGrade = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblSmartTag1 = new Gizmox.WebGUI.Forms.Label();
            this.cboToGrade = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboToShop = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblFromShop = new Gizmox.WebGUI.Forms.Label();
            this.cboFromShop = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblToShop = new Gizmox.WebGUI.Forms.Label();
            this.btnLookUpToMemberNumber = new Gizmox.WebGUI.Forms.Button();
            this.btnLookupFromMemberNumber = new Gizmox.WebGUI.Forms.Button();
            this.txtToMemberNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblToMemberNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtFromMemberNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMemberNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblPromotionDiscountPercentage = new Gizmox.WebGUI.Forms.Label();
            this.lblNormalDiscountPercentage = new Gizmox.WebGUI.Forms.Label();
            this.chkCheckAddOnDiscount = new Gizmox.WebGUI.Forms.CheckBox();
            this.txtStaffQuota = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPromotionDiscount = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNormalDiscount = new Gizmox.WebGUI.Forms.TextBox();
            this.chkStaffQuota = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkAddOnDiscount = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkNormalDiscount = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkPromotionDiscount = new Gizmox.WebGUI.Forms.CheckBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.btnUpdate = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.gbxUpdates = new Gizmox.WebGUI.Forms.GroupBox();
            this.gbxOptions.SuspendLayout();
            this.gbxUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxOptions
            // 
            this.gbxOptions.Controls.Add(this.lblToGrade);
            this.gbxOptions.Controls.Add(this.cboFromGrade);
            this.gbxOptions.Controls.Add(this.lblSmartTag1);
            this.gbxOptions.Controls.Add(this.cboToGrade);
            this.gbxOptions.Controls.Add(this.cboToShop);
            this.gbxOptions.Controls.Add(this.lblFromShop);
            this.gbxOptions.Controls.Add(this.cboFromShop);
            this.gbxOptions.Controls.Add(this.lblToShop);
            this.gbxOptions.Controls.Add(this.btnLookUpToMemberNumber);
            this.gbxOptions.Controls.Add(this.btnLookupFromMemberNumber);
            this.gbxOptions.Controls.Add(this.txtToMemberNumber);
            this.gbxOptions.Controls.Add(this.lblToMemberNumber);
            this.gbxOptions.Controls.Add(this.txtFromMemberNumber);
            this.gbxOptions.Controls.Add(this.lblMemberNumber);
            this.gbxOptions.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxOptions.Location = new System.Drawing.Point(12, 12);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(403, 117);
            this.gbxOptions.TabIndex = 0;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Options";
            // 
            // lblToGrade
            // 
            this.lblToGrade.AutoSize = true;
            this.lblToGrade.Location = new System.Drawing.Point(243, 83);
            this.lblToGrade.Name = "lblToGrade";
            this.lblToGrade.Size = new System.Drawing.Size(19, 13);
            this.lblToGrade.TabIndex = 12;
            this.lblToGrade.Text = "To";
            this.lblToGrade.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboFromGrade
            // 
            this.cboFromGrade.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboFromGrade.Location = new System.Drawing.Point(98, 80);
            this.cboFromGrade.Name = "cboFromGrade";
            this.cboFromGrade.Size = new System.Drawing.Size(100, 21);
            this.cboFromGrade.TabIndex = 11;
            // 
            // lblSmartTag1
            // 
            this.lblSmartTag1.Location = new System.Drawing.Point(17, 83);
            this.lblSmartTag1.Name = "lblSmartTag1";
            this.lblSmartTag1.Size = new System.Drawing.Size(75, 23);
            this.lblSmartTag1.TabIndex = 10;
            this.lblSmartTag1.Text = "Grade:";
            // 
            // cboToGrade
            // 
            this.cboToGrade.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboToGrade.Location = new System.Drawing.Point(265, 80);
            this.cboToGrade.Name = "cboToGrade";
            this.cboToGrade.Size = new System.Drawing.Size(100, 21);
            this.cboToGrade.TabIndex = 13;
            // 
            // cboToShop
            // 
            this.cboToShop.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboToShop.Location = new System.Drawing.Point(265, 53);
            this.cboToShop.Name = "cboToShop";
            this.cboToShop.Size = new System.Drawing.Size(100, 21);
            this.cboToShop.TabIndex = 9;
            // 
            // lblFromShop
            // 
            this.lblFromShop.Location = new System.Drawing.Point(17, 56);
            this.lblFromShop.Name = "lblFromShop";
            this.lblFromShop.Size = new System.Drawing.Size(75, 23);
            this.lblFromShop.TabIndex = 6;
            this.lblFromShop.Text = "Shop:";
            // 
            // cboFromShop
            // 
            this.cboFromShop.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboFromShop.Location = new System.Drawing.Point(98, 53);
            this.cboFromShop.Name = "cboFromShop";
            this.cboFromShop.Size = new System.Drawing.Size(100, 21);
            this.cboFromShop.TabIndex = 7;
            // 
            // lblToShop
            // 
            this.lblToShop.AutoSize = true;
            this.lblToShop.Location = new System.Drawing.Point(243, 56);
            this.lblToShop.Name = "lblToShop";
            this.lblToShop.Size = new System.Drawing.Size(19, 13);
            this.lblToShop.TabIndex = 8;
            this.lblToShop.Text = "To";
            this.lblToShop.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnLookUpToMemberNumber
            // 
            this.btnLookUpToMemberNumber.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnLookUpToMemberNumber.Image"));
            this.btnLookUpToMemberNumber.Location = new System.Drawing.Point(365, 25);
            this.btnLookUpToMemberNumber.Name = "btnLookUpToMemberNumber";
            this.btnLookUpToMemberNumber.Size = new System.Drawing.Size(22, 22);
            this.btnLookUpToMemberNumber.TabIndex = 5;
            this.btnLookUpToMemberNumber.TabStop = false;
            this.btnLookUpToMemberNumber.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnLookupFromMemberNumber
            // 
            this.btnLookupFromMemberNumber.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnLookupFromMemberNumber.Image"));
            this.btnLookupFromMemberNumber.Location = new System.Drawing.Point(198, 25);
            this.btnLookupFromMemberNumber.Name = "btnLookupFromMemberNumber";
            this.btnLookupFromMemberNumber.Size = new System.Drawing.Size(22, 22);
            this.btnLookupFromMemberNumber.TabIndex = 2;
            this.btnLookupFromMemberNumber.TabStop = false;
            this.btnLookupFromMemberNumber.Click += new System.EventHandler(this.ButtonClick);
            // 
            // txtToMemberNumber
            // 
            this.txtToMemberNumber.Location = new System.Drawing.Point(265, 26);
            this.txtToMemberNumber.Name = "txtToMemberNumber";
            this.txtToMemberNumber.Size = new System.Drawing.Size(100, 20);
            this.txtToMemberNumber.TabIndex = 4;
            // 
            // lblToMemberNumber
            // 
            this.lblToMemberNumber.AutoSize = true;
            this.lblToMemberNumber.Location = new System.Drawing.Point(243, 29);
            this.lblToMemberNumber.Name = "lblToMemberNumber";
            this.lblToMemberNumber.Size = new System.Drawing.Size(19, 13);
            this.lblToMemberNumber.TabIndex = 3;
            this.lblToMemberNumber.Text = "To";
            this.lblToMemberNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFromMemberNumber
            // 
            this.txtFromMemberNumber.Location = new System.Drawing.Point(98, 26);
            this.txtFromMemberNumber.Name = "txtFromMemberNumber";
            this.txtFromMemberNumber.Size = new System.Drawing.Size(100, 20);
            this.txtFromMemberNumber.TabIndex = 1;
            // 
            // lblMemberNumber
            // 
            this.lblMemberNumber.Location = new System.Drawing.Point(17, 29);
            this.lblMemberNumber.Name = "lblMemberNumber";
            this.lblMemberNumber.Size = new System.Drawing.Size(75, 23);
            this.lblMemberNumber.TabIndex = 0;
            this.lblMemberNumber.Text = "Member#:";
            // 
            // lblPromotionDiscountPercentage
            // 
            this.lblPromotionDiscountPercentage.AutoSize = true;
            this.lblPromotionDiscountPercentage.Location = new System.Drawing.Point(279, 63);
            this.lblPromotionDiscountPercentage.Name = "lblPromotionDiscountPercentage";
            this.lblPromotionDiscountPercentage.Size = new System.Drawing.Size(18, 13);
            this.lblPromotionDiscountPercentage.TabIndex = 5;
            this.lblPromotionDiscountPercentage.Text = "%";
            // 
            // lblNormalDiscountPercentage
            // 
            this.lblNormalDiscountPercentage.AutoSize = true;
            this.lblNormalDiscountPercentage.Location = new System.Drawing.Point(279, 33);
            this.lblNormalDiscountPercentage.Name = "lblNormalDiscountPercentage";
            this.lblNormalDiscountPercentage.Size = new System.Drawing.Size(18, 13);
            this.lblNormalDiscountPercentage.TabIndex = 2;
            this.lblNormalDiscountPercentage.Text = "%";
            // 
            // chkCheckAddOnDiscount
            // 
            this.chkCheckAddOnDiscount.Enabled = false;
            this.chkCheckAddOnDiscount.Location = new System.Drawing.Point(173, 88);
            this.chkCheckAddOnDiscount.Name = "chkCheckAddOnDiscount";
            this.chkCheckAddOnDiscount.Size = new System.Drawing.Size(104, 24);
            this.chkCheckAddOnDiscount.TabIndex = 7;
            // 
            // txtStaffQuota
            // 
            this.txtStaffQuota.Enabled = false;
            this.txtStaffQuota.Location = new System.Drawing.Point(173, 120);
            this.txtStaffQuota.Name = "txtStaffQuota";
            this.txtStaffQuota.Size = new System.Drawing.Size(100, 20);
            this.txtStaffQuota.TabIndex = 9;
            // 
            // txtPromotionDiscount
            // 
            this.txtPromotionDiscount.Enabled = false;
            this.txtPromotionDiscount.Location = new System.Drawing.Point(173, 60);
            this.txtPromotionDiscount.Name = "txtPromotionDiscount";
            this.txtPromotionDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtPromotionDiscount.TabIndex = 4;
            this.txtPromotionDiscount.Text = "0";
            this.txtPromotionDiscount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtNormalDiscount
            // 
            this.txtNormalDiscount.Enabled = false;
            this.txtNormalDiscount.Location = new System.Drawing.Point(173, 30);
            this.txtNormalDiscount.Name = "txtNormalDiscount";
            this.txtNormalDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtNormalDiscount.TabIndex = 1;
            this.txtNormalDiscount.Text = "0";
            this.txtNormalDiscount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // chkStaffQuota
            // 
            this.chkStaffQuota.Location = new System.Drawing.Point(17, 118);
            this.chkStaffQuota.Name = "chkStaffQuota";
            this.chkStaffQuota.Size = new System.Drawing.Size(104, 24);
            this.chkStaffQuota.TabIndex = 8;
            this.chkStaffQuota.Text = "StaffQuota";
            this.chkStaffQuota.Click += new System.EventHandler(this.CheckBoxClick);
            // 
            // chkAddOnDiscount
            // 
            this.chkAddOnDiscount.Location = new System.Drawing.Point(17, 88);
            this.chkAddOnDiscount.Name = "chkAddOnDiscount";
            this.chkAddOnDiscount.Size = new System.Drawing.Size(104, 24);
            this.chkAddOnDiscount.TabIndex = 6;
            this.chkAddOnDiscount.Text = "Add on Discount";
            this.chkAddOnDiscount.Click += new System.EventHandler(this.CheckBoxClick);
            // 
            // chkNormalDiscount
            // 
            this.chkNormalDiscount.Location = new System.Drawing.Point(17, 28);
            this.chkNormalDiscount.Name = "chkNormalDiscount";
            this.chkNormalDiscount.Size = new System.Drawing.Size(150, 24);
            this.chkNormalDiscount.TabIndex = 0;
            this.chkNormalDiscount.Text = "Normal Item Discount";
            this.chkNormalDiscount.Click += new System.EventHandler(this.CheckBoxClick);
            // 
            // chkPromotionDiscount
            // 
            this.chkPromotionDiscount.Location = new System.Drawing.Point(17, 58);
            this.chkPromotionDiscount.Name = "chkPromotionDiscount";
            this.chkPromotionDiscount.Size = new System.Drawing.Size(150, 24);
            this.chkPromotionDiscount.TabIndex = 3;
            this.chkPromotionDiscount.Text = "Promotion Item Discount";
            this.chkPromotionDiscount.Click += new System.EventHandler(this.CheckBoxClick);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(429, 246);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(429, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.ButtonClick);
            // 
            // gbxUpdates
            // 
            this.gbxUpdates.Controls.Add(this.lblPromotionDiscountPercentage);
            this.gbxUpdates.Controls.Add(this.txtNormalDiscount);
            this.gbxUpdates.Controls.Add(this.lblNormalDiscountPercentage);
            this.gbxUpdates.Controls.Add(this.chkPromotionDiscount);
            this.gbxUpdates.Controls.Add(this.chkCheckAddOnDiscount);
            this.gbxUpdates.Controls.Add(this.chkNormalDiscount);
            this.gbxUpdates.Controls.Add(this.txtStaffQuota);
            this.gbxUpdates.Controls.Add(this.chkAddOnDiscount);
            this.gbxUpdates.Controls.Add(this.txtPromotionDiscount);
            this.gbxUpdates.Controls.Add(this.chkStaffQuota);
            this.gbxUpdates.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxUpdates.Location = new System.Drawing.Point(12, 140);
            this.gbxUpdates.Name = "gbxUpdates";
            this.gbxUpdates.Size = new System.Drawing.Size(403, 161);
            this.gbxUpdates.TabIndex = 4;
            this.gbxUpdates.TabStop = false;
            this.gbxUpdates.Text = "Updates";
            // 
            // MassUpdateWizard
            // 
            this.Controls.Add(this.gbxUpdates);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbxOptions);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(516, 316);
            this.Text = "Member [Mass Update]";
            this.Load += new System.EventHandler(this.MassUpdateWizard_Load);
            this.gbxOptions.ResumeLayout(false);
            this.gbxUpdates.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox gbxOptions;
        private Gizmox.WebGUI.Forms.TextBox txtToMemberNumber;
        private Gizmox.WebGUI.Forms.Label lblToMemberNumber;
        private Gizmox.WebGUI.Forms.TextBox txtFromMemberNumber;
        private Gizmox.WebGUI.Forms.Label lblMemberNumber;
        private Gizmox.WebGUI.Forms.Button btnLookUpToMemberNumber;
        private Gizmox.WebGUI.Forms.Button btnLookupFromMemberNumber;
        private Gizmox.WebGUI.Forms.Label lblToGrade;
        private Gizmox.WebGUI.Forms.ComboBox cboFromGrade;
        private Gizmox.WebGUI.Forms.Label lblSmartTag1;
        private Gizmox.WebGUI.Forms.ComboBox cboToGrade;
        private Gizmox.WebGUI.Forms.ComboBox cboToShop;
        private Gizmox.WebGUI.Forms.Label lblFromShop;
        private Gizmox.WebGUI.Forms.ComboBox cboFromShop;
        private Gizmox.WebGUI.Forms.Label lblToShop;
        private Gizmox.WebGUI.Forms.CheckBox chkStaffQuota;
        private Gizmox.WebGUI.Forms.CheckBox chkAddOnDiscount;
        private Gizmox.WebGUI.Forms.CheckBox chkNormalDiscount;
        private Gizmox.WebGUI.Forms.CheckBox chkPromotionDiscount;
        private Gizmox.WebGUI.Forms.Label lblPromotionDiscountPercentage;
        private Gizmox.WebGUI.Forms.Label lblNormalDiscountPercentage;
        private Gizmox.WebGUI.Forms.CheckBox chkCheckAddOnDiscount;
        private Gizmox.WebGUI.Forms.TextBox txtStaffQuota;
        private Gizmox.WebGUI.Forms.TextBox txtPromotionDiscount;
        private Gizmox.WebGUI.Forms.TextBox txtNormalDiscount;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Button btnUpdate;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.GroupBox gbxUpdates;
    }
}