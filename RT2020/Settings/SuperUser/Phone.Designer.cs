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
            this.gbxCountryCode.SuspendLayout();
            this.gbxGenPhoneNumber.SuspendLayout();
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
            this.gbxCountryCode.Location = new System.Drawing.Point(21, 37);
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
            this.gbxGenPhoneNumber.Location = new System.Drawing.Point(21, 171);
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
            // Phone
            // 
            this.Controls.Add(this.gbxGenPhoneNumber);
            this.Controls.Add(this.gbxCountryCode);
            this.Controls.Add(this.progressBar1);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Phone";
            this.gbxCountryCode.ResumeLayout(false);
            this.gbxGenPhoneNumber.ResumeLayout(false);
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
    }
}