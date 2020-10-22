namespace RT2020.Member
{
    partial class MemberWizard_VipNumber
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
            this.lblVipNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtVipNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.chkFillZero = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblMessage = new Gizmox.WebGUI.Forms.Label();
            this.lblMessage2 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVipNumber
            // 
            this.lblVipNumber.AutoSize = true;
            this.lblVipNumber.Location = new System.Drawing.Point(19, 70);
            this.lblVipNumber.Name = "lblVipNumber";
            this.lblVipNumber.Size = new System.Drawing.Size(94, 13);
            this.lblVipNumber.TabIndex = 0;
            this.lblVipNumber.Text = "New VIP Number: ";
            // 
            // txtVipNumber
            // 
            this.txtVipNumber.Location = new System.Drawing.Point(119, 67);
            this.txtVipNumber.Name = "txtVipNumber";
            this.txtVipNumber.Size = new System.Drawing.Size(264, 20);
            this.txtVipNumber.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(227, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(308, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.Button_Click);
            // 
            // chkFillZero
            // 
            this.chkFillZero.Checked = false;
            this.chkFillZero.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkFillZero.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkFillZero.Location = new System.Drawing.Point(22, 93);
            this.chkFillZero.Name = "chkFillZero";
            this.chkFillZero.Size = new System.Drawing.Size(361, 24);
            this.chkFillZero.TabIndex = 3;
            this.chkFillZero.Text = "Fill \'0\' in front of new VIP# (All new VIP# will be 13 digits)";
            this.chkFillZero.ThreeState = false;
            this.chkFillZero.Click += new System.EventHandler(this.chkFillZero_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(19, 18);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(145, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Fill the new VIP Number! ";
            // 
            // lblMessage2
            // 
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.ForeColor = System.Drawing.Color.Red;
            this.lblMessage2.Location = new System.Drawing.Point(19, 41);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(349, 13);
            this.lblMessage2.TabIndex = 5;
            this.lblMessage2.Text = "Default new VIP Number is the next number of largest existing number.";
            // 
            // MemberWizard_VipNumber
            // 
            this.AcceptButton = this.btnOK;
            this.Controls.Add(this.lblMessage2);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtVipNumber);
            this.Controls.Add(this.lblVipNumber);
            this.Controls.Add(this.chkFillZero);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 172);
            this.Text = "Member Wizard > Setting Vip Number";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblVipNumber;
        private Gizmox.WebGUI.Forms.TextBox txtVipNumber;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.CheckBox chkFillZero;
        private Gizmox.WebGUI.Forms.Label lblMessage;
        private Gizmox.WebGUI.Forms.Label lblMessage2;


    }
}