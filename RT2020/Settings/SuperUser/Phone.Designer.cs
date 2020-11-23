using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace RT2020.Settings.SuperUser
{
    partial class Phone
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
            this.cmdGenPhoneNumbers = new Gizmox.WebGUI.Forms.Button();
            this.progressBar1 = new Gizmox.WebGUI.Forms.ProgressBar();
            this.cmdGenCountryCode = new Gizmox.WebGUI.Forms.Button();
            this.gbxCountryCode = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblCountryCode = new Gizmox.WebGUI.Forms.Label();
            this.gbxGenPhoneNumber = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblGenPhoneNumber = new Gizmox.WebGUI.Forms.Label();
            this.cmdGenRegionCode = new Gizmox.WebGUI.Forms.Button();
            this.gbxStateCity = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkTaiwan = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkHongKong = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkChina = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkMacao = new Gizmox.WebGUI.Forms.CheckBox();
            this.gbxCountryCode.SuspendLayout();
            this.gbxGenPhoneNumber.SuspendLayout();
            this.gbxStateCity.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGenPhoneNumbers
            // 
            this.cmdGenPhoneNumbers.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cmdGenPhoneNumbers.Location = new System.Drawing.Point(18, 69);
            this.cmdGenPhoneNumbers.Name = "cmdGenPhoneNumbers";
            this.cmdGenPhoneNumbers.Size = new System.Drawing.Size(313, 23);
            this.cmdGenPhoneNumbers.TabIndex = 0;
            this.cmdGenPhoneNumbers.Text = "Generate Random Phone Numbers for existing Members";
            this.cmdGenPhoneNumbers.Click += new System.EventHandler(this.cmdGenPhoneNumbers_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(268, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // cmdGenCountryCode
            // 
            this.cmdGenCountryCode.Location = new System.Drawing.Point(18, 67);
            this.cmdGenCountryCode.Name = "cmdGenCountryCode";
            this.cmdGenCountryCode.Size = new System.Drawing.Size(313, 23);
            this.cmdGenCountryCode.TabIndex = 0;
            this.cmdGenCountryCode.Text = "Generate Country Codes";
            this.cmdGenCountryCode.Click += new System.EventHandler(this.cmdGenCountryCode_Click);
            // 
            // gbxCountryCode
            // 
            this.gbxCountryCode.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.gbxCountryCode.Controls.Add(this.lblCountryCode);
            this.gbxCountryCode.Controls.Add(this.cmdGenCountryCode);
            this.gbxCountryCode.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxCountryCode.Location = new System.Drawing.Point(43, 34);
            this.gbxCountryCode.Name = "gbxCountryCode";
            this.gbxCountryCode.Size = new System.Drawing.Size(347, 103);
            this.gbxCountryCode.TabIndex = 2;
            this.gbxCountryCode.TabStop = false;
            this.gbxCountryCode.Text = "Generate Country Codes";
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.Location = new System.Drawing.Point(18, 30);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(313, 29);
            this.lblCountryCode.TabIndex = 1;
            this.lblCountryCode.Text = "Generate and fill dboCountry with:\r\nISO 3166 Alpha-2 Country Codes";
            this.lblCountryCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gbxGenPhoneNumber
            // 
            this.gbxGenPhoneNumber.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.gbxGenPhoneNumber.Controls.Add(this.lblGenPhoneNumber);
            this.gbxGenPhoneNumber.Controls.Add(this.cmdGenPhoneNumbers);
            this.gbxGenPhoneNumber.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxGenPhoneNumber.Location = new System.Drawing.Point(43, 152);
            this.gbxGenPhoneNumber.Name = "gbxGenPhoneNumber";
            this.gbxGenPhoneNumber.Size = new System.Drawing.Size(347, 106);
            this.gbxGenPhoneNumber.TabIndex = 3;
            this.gbxGenPhoneNumber.TabStop = false;
            this.gbxGenPhoneNumber.Text = "Generate Member Phone Numbers";
            // 
            // lblGenPhoneNumber
            // 
            this.lblGenPhoneNumber.Location = new System.Drawing.Point(15, 26);
            this.lblGenPhoneNumber.Name = "lblGenPhoneNumber";
            this.lblGenPhoneNumber.Size = new System.Drawing.Size(313, 43);
            this.lblGenPhoneNumber.TabIndex = 1;
            this.lblGenPhoneNumber.Text = "Generate random phone numbers for Members.\r\nTakes very long time to process, will" +
    " submit to Bot Server to do it in background.";
            this.lblGenPhoneNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdGenRegionCode
            // 
            this.cmdGenRegionCode.Location = new System.Drawing.Point(18, 67);
            this.cmdGenRegionCode.Name = "cmdGenRegionCode";
            this.cmdGenRegionCode.Size = new System.Drawing.Size(313, 23);
            this.cmdGenRegionCode.TabIndex = 0;
            this.cmdGenRegionCode.Text = "Generate Region Codes";
            this.cmdGenRegionCode.Click += new System.EventHandler(this.cmdGenRegionCode_Click);
            // 
            // gbxStateCity
            // 
            this.gbxStateCity.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.gbxStateCity.Controls.Add(this.chkMacao);
            this.gbxStateCity.Controls.Add(this.chkTaiwan);
            this.gbxStateCity.Controls.Add(this.chkHongKong);
            this.gbxStateCity.Controls.Add(this.chkChina);
            this.gbxStateCity.Controls.Add(this.cmdGenRegionCode);
            this.gbxStateCity.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxStateCity.Location = new System.Drawing.Point(406, 34);
            this.gbxStateCity.Name = "gbxStateCity";
            this.gbxStateCity.Size = new System.Drawing.Size(347, 103);
            this.gbxStateCity.TabIndex = 2;
            this.gbxStateCity.TabStop = false;
            this.gbxStateCity.Text = "Generate Region Codes";
            // 
            // chkTaiwan
            // 
            this.chkTaiwan.AutoSize = true;
            this.chkTaiwan.Location = new System.Drawing.Point(271, 31);
            this.chkTaiwan.Name = "chkTaiwan";
            this.chkTaiwan.Size = new System.Drawing.Size(60, 17);
            this.chkTaiwan.TabIndex = 1;
            this.chkTaiwan.Text = "Taiwan";
            // 
            // chkHongKong
            // 
            this.chkHongKong.AutoSize = true;
            this.chkHongKong.Location = new System.Drawing.Point(90, 31);
            this.chkHongKong.Name = "chkHongKong";
            this.chkHongKong.Size = new System.Drawing.Size(78, 17);
            this.chkHongKong.TabIndex = 1;
            this.chkHongKong.Text = "Hong Kong";
            // 
            // chkChina
            // 
            this.chkChina.AutoSize = true;
            this.chkChina.Location = new System.Drawing.Point(22, 31);
            this.chkChina.Name = "chkChina";
            this.chkChina.Size = new System.Drawing.Size(53, 17);
            this.chkChina.TabIndex = 1;
            this.chkChina.Text = "China";
            // 
            // chkMacao
            // 
            this.chkMacao.AutoSize = true;
            this.chkMacao.Location = new System.Drawing.Point(190, 31);
            this.chkMacao.Name = "chkMacao";
            this.chkMacao.Size = new System.Drawing.Size(57, 17);
            this.chkMacao.TabIndex = 1;
            this.chkMacao.Text = "Macao";
            // 
            // Phone
            // 
            this.Controls.Add(this.gbxStateCity);
            this.Controls.Add(this.gbxGenPhoneNumber);
            this.Controls.Add(this.gbxCountryCode);
            this.Controls.Add(this.progressBar1);
            this.Size = new System.Drawing.Size(800, 306);
            this.Text = "Phone";
            this.gbxCountryCode.ResumeLayout(false);
            this.gbxGenPhoneNumber.ResumeLayout(false);
            this.gbxStateCity.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private Button cmdGenPhoneNumbers;
        private ProgressBar progressBar1;
        private Button cmdGenCountryCode;
        private GroupBox gbxCountryCode;
        private Label lblCountryCode;
        private GroupBox gbxGenPhoneNumber;
        private Label lblGenPhoneNumber;
        private Button cmdGenRegionCode;
        private GroupBox gbxStateCity;
        private CheckBox chkTaiwan;
        private CheckBox chkHongKong;
        private CheckBox chkChina;
        private CheckBox chkMacao;
    }
}