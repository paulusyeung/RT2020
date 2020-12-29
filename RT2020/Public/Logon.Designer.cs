namespace RT2020.Public
{
    partial class Logon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logon));
            this.lblStaffNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblPassword = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.txtStaffNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.btnLogon = new Gizmox.WebGUI.Forms.Button();
            this.lblZone = new Gizmox.WebGUI.Forms.Label();
            this.cboZone = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblErrorMessage = new Gizmox.WebGUI.Forms.Label();
            this.lblVersionNumber = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStaffNumber
            // 
            this.lblStaffNumber.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            resources.ApplyResources(this.lblStaffNumber, "lblStaffNumber");
            this.lblStaffNumber.Name = "lblStaffNumber";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            // 
            // txtStaffNumber
            // 
            this.txtStaffNumber.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            resources.ApplyResources(this.txtStaffNumber, "txtStaffNumber");
            this.txtStaffNumber.Name = "txtStaffNumber";
            this.txtStaffNumber.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtStaffNumber_EnterKeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtPassword_EnterKeyDown);
            // 
            // btnLogon
            // 
            this.btnLogon.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            resources.ApplyResources(this.btnLogon, "btnLogon");
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // lblZone
            // 
            this.lblZone.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            resources.ApplyResources(this.lblZone, "lblZone");
            this.lblZone.Name = "lblZone";
            // 
            // cboZone
            // 
            this.cboZone.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cboZone.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.DropDownWidth = 136;
            resources.ApplyResources(this.cboZone, "cboZone");
            this.cboZone.Name = "cboZone";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblErrorMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.lblErrorMessage, "lblErrorMessage");
            this.lblErrorMessage.Name = "lblErrorMessage";
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblVersionNumber.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblVersionNumber, "lblVersionNumber");
            this.lblVersionNumber.Name = "lblVersionNumber";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblStaffNumber);
            this.panel1.Controls.Add(this.lblVersionNumber);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.lblErrorMessage);
            this.panel1.Controls.Add(this.txtStaffNumber);
            this.panel1.Controls.Add(this.cboZone);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblZone);
            this.panel1.Controls.Add(this.btnLogon);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // Logon
            // 
            this.AcceptButton = this.btnLogon;
            this.Controls.Add(this.panel1);
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.Logon_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblStaffNumber;
        private Gizmox.WebGUI.Forms.Label lblPassword;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TextBox txtStaffNumber;
        private Gizmox.WebGUI.Forms.TextBox txtPassword;
        private Gizmox.WebGUI.Forms.Button btnLogon;
        private Gizmox.WebGUI.Forms.Label lblZone;
        private Gizmox.WebGUI.Forms.ComboBox cboZone;
        private Gizmox.WebGUI.Forms.Label lblErrorMessage;
        private Gizmox.WebGUI.Forms.Label lblVersionNumber;
        private Gizmox.WebGUI.Forms.Panel panel1;
    }
}