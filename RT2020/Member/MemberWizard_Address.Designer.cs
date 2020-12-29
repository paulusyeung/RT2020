namespace RT2020.Member
{
    partial class MemberWizard_Address
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
            this.cboAddressType = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblAddressType = new Gizmox.WebGUI.Forms.Label();
            this.txtPostalCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPostalCode = new Gizmox.WebGUI.Forms.Label();
            this.cboCountry = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCountry = new Gizmox.WebGUI.Forms.Label();
            this.cboProvince = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblProvince = new Gizmox.WebGUI.Forms.Label();
            this.cboCity = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCity = new Gizmox.WebGUI.Forms.Label();
            this.txtAddress = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAddress = new Gizmox.WebGUI.Forms.Label();
            this.lblDistrict = new Gizmox.WebGUI.Forms.Label();
            this.txtDistrict = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPhoneNumbers = new Gizmox.WebGUI.Forms.Label();
            this.lblPhoneTag1 = new Gizmox.WebGUI.Forms.Label();
            this.lblPhoneTag2 = new Gizmox.WebGUI.Forms.Label();
            this.lblPhoneTag3 = new Gizmox.WebGUI.Forms.Label();
            this.lblPhoneTag4 = new Gizmox.WebGUI.Forms.Label();
            this.txtPhoneTag1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPhoneTag2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPhoneTag3 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPhoneTag4 = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPhoneTag5 = new Gizmox.WebGUI.Forms.Label();
            this.txtPhoneTag5 = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboAddressType
            // 
            this.cboAddressType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAddressType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboAddressType.DropDownWidth = 121;
            this.cboAddressType.Location = new System.Drawing.Point(122, 15);
            this.cboAddressType.Name = "cboAddressType";
            this.cboAddressType.Size = new System.Drawing.Size(121, 21);
            this.cboAddressType.TabIndex = 3;
            this.cboAddressType.SelectedIndexChanged += new System.EventHandler(this.cboAddressType_SelectedIndexChanged);
            // 
            // lblAddressType
            // 
            this.lblAddressType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAddressType.Location = new System.Drawing.Point(16, 18);
            this.lblAddressType.Name = "lblAddressType";
            this.lblAddressType.Size = new System.Drawing.Size(100, 23);
            this.lblAddressType.TabIndex = 0;
            this.lblAddressType.TabStop = false;
            this.lblAddressType.Text = "Address Type:";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPostalCode.Location = new System.Drawing.Point(355, 124);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(121, 20);
            this.txtPostalCode.TabIndex = 6;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPostalCode.Location = new System.Drawing.Point(249, 127);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(100, 23);
            this.lblPostalCode.TabIndex = 0;
            this.lblPostalCode.TabStop = false;
            this.lblPostalCode.Text = "Postal Code:";
            this.lblPostalCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboCountry
            // 
            this.cboCountry.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCountry.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboCountry.DropDownWidth = 121;
            this.cboCountry.Location = new System.Drawing.Point(122, 147);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(121, 21);
            this.cboCountry.TabIndex = 7;
            this.cboCountry.SelectedIndexChangedQueued += new System.EventHandler(this.cboCountry_SelectedIndexChangedQueued);
            // 
            // lblCountry
            // 
            this.lblCountry.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCountry.Location = new System.Drawing.Point(16, 150);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(100, 23);
            this.lblCountry.TabIndex = 0;
            this.lblCountry.TabStop = false;
            this.lblCountry.Text = "Country:";
            // 
            // cboProvince
            // 
            this.cboProvince.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboProvince.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboProvince.DropDownWidth = 121;
            this.cboProvince.Location = new System.Drawing.Point(122, 170);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(121, 21);
            this.cboProvince.TabIndex = 8;
            this.cboProvince.SelectedIndexChangedQueued += new System.EventHandler(this.cboProvince_SelectedIndexChangedQueued);
            // 
            // lblProvince
            // 
            this.lblProvince.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProvince.Location = new System.Drawing.Point(16, 173);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(100, 23);
            this.lblProvince.TabIndex = 0;
            this.lblProvince.TabStop = false;
            this.lblProvince.Text = "Province:";
            // 
            // cboCity
            // 
            this.cboCity.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCity.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboCity.DropDownWidth = 121;
            this.cboCity.Location = new System.Drawing.Point(355, 170);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(121, 21);
            this.cboCity.TabIndex = 9;
            // 
            // lblCity
            // 
            this.lblCity.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCity.Location = new System.Drawing.Point(249, 173);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(100, 23);
            this.lblCity.TabIndex = 0;
            this.lblCity.TabStop = false;
            this.lblCity.Text = "City:";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAddress
            // 
            this.txtAddress.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtAddress.Location = new System.Drawing.Point(122, 38);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(354, 84);
            this.txtAddress.TabIndex = 4;
            // 
            // lblAddress
            // 
            this.lblAddress.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAddress.Location = new System.Drawing.Point(16, 41);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.TabStop = false;
            this.lblAddress.Text = "Address:";
            // 
            // lblDistrict
            // 
            this.lblDistrict.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblDistrict.Location = new System.Drawing.Point(16, 127);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(100, 23);
            this.lblDistrict.TabIndex = 0;
            this.lblDistrict.TabStop = false;
            this.lblDistrict.Text = "District:";
            // 
            // txtDistrict
            // 
            this.txtDistrict.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtDistrict.Location = new System.Drawing.Point(122, 124);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(121, 20);
            this.txtDistrict.TabIndex = 5;
            // 
            // lblPhoneNumbers
            // 
            this.lblPhoneNumbers.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneNumbers.Location = new System.Drawing.Point(16, 219);
            this.lblPhoneNumbers.Name = "lblPhoneNumbers";
            this.lblPhoneNumbers.Size = new System.Drawing.Size(100, 23);
            this.lblPhoneNumbers.TabIndex = 0;
            this.lblPhoneNumbers.TabStop = false;
            this.lblPhoneNumbers.Text = "Phone #:";
            // 
            // lblPhoneTag1
            // 
            this.lblPhoneTag1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneTag1.Location = new System.Drawing.Point(122, 219);
            this.lblPhoneTag1.Name = "lblPhoneTag1";
            this.lblPhoneTag1.Size = new System.Drawing.Size(53, 23);
            this.lblPhoneTag1.TabIndex = 0;
            this.lblPhoneTag1.TabStop = false;
            this.lblPhoneTag1.Text = "Phone 1:";
            // 
            // lblPhoneTag2
            // 
            this.lblPhoneTag2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneTag2.Location = new System.Drawing.Point(122, 242);
            this.lblPhoneTag2.Name = "lblPhoneTag2";
            this.lblPhoneTag2.Size = new System.Drawing.Size(53, 23);
            this.lblPhoneTag2.TabIndex = 0;
            this.lblPhoneTag2.TabStop = false;
            this.lblPhoneTag2.Text = "Phone 2:";
            // 
            // lblPhoneTag3
            // 
            this.lblPhoneTag3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneTag3.Location = new System.Drawing.Point(122, 265);
            this.lblPhoneTag3.Name = "lblPhoneTag3";
            this.lblPhoneTag3.Size = new System.Drawing.Size(53, 23);
            this.lblPhoneTag3.TabIndex = 0;
            this.lblPhoneTag3.TabStop = false;
            this.lblPhoneTag3.Text = "Phone 3:";
            // 
            // lblPhoneTag4
            // 
            this.lblPhoneTag4.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneTag4.Location = new System.Drawing.Point(122, 288);
            this.lblPhoneTag4.Name = "lblPhoneTag4";
            this.lblPhoneTag4.Size = new System.Drawing.Size(53, 23);
            this.lblPhoneTag4.TabIndex = 0;
            this.lblPhoneTag4.TabStop = false;
            this.lblPhoneTag4.Text = "Phone 4:";
            // 
            // txtPhoneTag1
            // 
            this.txtPhoneTag1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneTag1.Location = new System.Drawing.Point(181, 216);
            this.txtPhoneTag1.Name = "txtPhoneTag1";
            this.txtPhoneTag1.Size = new System.Drawing.Size(295, 20);
            this.txtPhoneTag1.TabIndex = 10;
            // 
            // txtPhoneTag2
            // 
            this.txtPhoneTag2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneTag2.Location = new System.Drawing.Point(181, 239);
            this.txtPhoneTag2.Name = "txtPhoneTag2";
            this.txtPhoneTag2.Size = new System.Drawing.Size(295, 20);
            this.txtPhoneTag2.TabIndex = 11;
            // 
            // txtPhoneTag3
            // 
            this.txtPhoneTag3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneTag3.Location = new System.Drawing.Point(181, 262);
            this.txtPhoneTag3.Name = "txtPhoneTag3";
            this.txtPhoneTag3.Size = new System.Drawing.Size(295, 20);
            this.txtPhoneTag3.TabIndex = 12;
            // 
            // txtPhoneTag4
            // 
            this.txtPhoneTag4.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneTag4.Location = new System.Drawing.Point(181, 285);
            this.txtPhoneTag4.Name = "txtPhoneTag4";
            this.txtPhoneTag4.Size = new System.Drawing.Size(295, 20);
            this.txtPhoneTag4.TabIndex = 13;
            // 
            // lblPhoneTag5
            // 
            this.lblPhoneTag5.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneTag5.Location = new System.Drawing.Point(122, 311);
            this.lblPhoneTag5.Name = "lblPhoneTag5";
            this.lblPhoneTag5.Size = new System.Drawing.Size(53, 23);
            this.lblPhoneTag5.TabIndex = 0;
            this.lblPhoneTag5.TabStop = false;
            this.lblPhoneTag5.Text = "Phone 5:";
            // 
            // txtPhoneTag5
            // 
            this.txtPhoneTag5.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneTag5.Location = new System.Drawing.Point(181, 308);
            this.txtPhoneTag5.Name = "txtPhoneTag5";
            this.txtPhoneTag5.Size = new System.Drawing.Size(295, 20);
            this.txtPhoneTag5.TabIndex = 14;
            // 
            // MemberWizard_AddressInfo
            // 
            this.Controls.Add(this.txtPhoneTag5);
            this.Controls.Add(this.lblPhoneTag5);
            this.Controls.Add(this.txtPhoneTag4);
            this.Controls.Add(this.txtPhoneTag3);
            this.Controls.Add(this.txtPhoneTag2);
            this.Controls.Add(this.txtPhoneTag1);
            this.Controls.Add(this.lblPhoneTag4);
            this.Controls.Add(this.lblPhoneTag3);
            this.Controls.Add(this.lblPhoneTag2);
            this.Controls.Add(this.lblPhoneTag1);
            this.Controls.Add(this.lblPhoneNumbers);
            this.Controls.Add(this.txtDistrict);
            this.Controls.Add(this.lblDistrict);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.cboCity);
            this.Controls.Add(this.lblProvince);
            this.Controls.Add(this.cboProvince);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.lblPostalCode);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.lblAddressType);
            this.Controls.Add(this.cboAddressType);
            this.Size = new System.Drawing.Size(766, 379);
            this.Text = "MemberWizard_AddressInfo";
            this.ResumeLayout(false);

        }

        #endregion

        public Gizmox.WebGUI.Forms.ComboBox cboAddressType;
        private Gizmox.WebGUI.Forms.Label lblAddressType;
        public Gizmox.WebGUI.Forms.TextBox txtPostalCode;
        private Gizmox.WebGUI.Forms.Label lblPostalCode;
        public Gizmox.WebGUI.Forms.ComboBox cboCountry;
        private Gizmox.WebGUI.Forms.Label lblCountry;
        public Gizmox.WebGUI.Forms.ComboBox cboProvince;
        private Gizmox.WebGUI.Forms.Label lblProvince;
        public Gizmox.WebGUI.Forms.ComboBox cboCity;
        private Gizmox.WebGUI.Forms.Label lblCity;
        public Gizmox.WebGUI.Forms.TextBox txtAddress;
        private Gizmox.WebGUI.Forms.Label lblAddress;
        private Gizmox.WebGUI.Forms.Label lblDistrict;
        private Gizmox.WebGUI.Forms.Label lblPhoneNumbers;
        private Gizmox.WebGUI.Forms.Label lblPhoneTag1;
        private Gizmox.WebGUI.Forms.Label lblPhoneTag2;
        private Gizmox.WebGUI.Forms.Label lblPhoneTag3;
        private Gizmox.WebGUI.Forms.Label lblPhoneTag4;
        private Gizmox.WebGUI.Forms.Label lblPhoneTag5;
        public Gizmox.WebGUI.Forms.TextBox txtDistrict;
        public Gizmox.WebGUI.Forms.TextBox txtPhoneTag1;
        public Gizmox.WebGUI.Forms.TextBox txtPhoneTag2;
        public Gizmox.WebGUI.Forms.TextBox txtPhoneTag3;
        public Gizmox.WebGUI.Forms.TextBox txtPhoneTag4;
        public Gizmox.WebGUI.Forms.TextBox txtPhoneTag5;


    }
}