namespace RT2020.Web.Shop.Public
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
            this.lblUserName = new Gizmox.WebGUI.Forms.Label();
            this.lblPassword = new Gizmox.WebGUI.Forms.Label();
            this.lblShopNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblShopPassword = new Gizmox.WebGUI.Forms.Label();
            this.txtUserName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.txtShopPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.cboShopList = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnLogon = new Gizmox.WebGUI.Forms.Button();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.lblErrorMessage = new Gizmox.WebGUI.Forms.Label();
            this.headerPane = new RT2020.Web.Shop.Public.HeaderPane();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(116, 128);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(100, 28);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(116, 159);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 28);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // lblShopNumber
            // 
            this.lblShopNumber.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblShopNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopNumber.Location = new System.Drawing.Point(116, 187);
            this.lblShopNumber.Name = "lblShopNumber";
            this.lblShopNumber.Size = new System.Drawing.Size(100, 28);
            this.lblShopNumber.TabIndex = 5;
            this.lblShopNumber.Text = "Shop #:";
            // 
            // lblShopPassword
            // 
            this.lblShopPassword.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblShopPassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopPassword.Location = new System.Drawing.Point(116, 218);
            this.lblShopPassword.Name = "lblShopPassword";
            this.lblShopPassword.Size = new System.Drawing.Size(100, 28);
            this.lblShopPassword.TabIndex = 6;
            this.lblShopPassword.Text = "Shop Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(222, 125);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(141, 22);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(222, 156);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(141, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // txtShopPassword
            // 
            this.txtShopPassword.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtShopPassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShopPassword.Location = new System.Drawing.Point(222, 215);
            this.txtShopPassword.Name = "txtShopPassword";
            this.txtShopPassword.PasswordChar = '*';
            this.txtShopPassword.Size = new System.Drawing.Size(141, 22);
            this.txtShopPassword.TabIndex = 3;
            // 
            // cboShopList
            // 
            this.cboShopList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cboShopList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboShopList.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboShopList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShopList.Location = new System.Drawing.Point(222, 185);
            this.cboShopList.Name = "cboShopList";
            this.cboShopList.Size = new System.Drawing.Size(141, 22);
            this.cboShopList.TabIndex = 2;
            // 
            // btnLogon
            // 
            this.btnLogon.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.btnLogon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogon.Location = new System.Drawing.Point(288, 261);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(75, 23);
            this.btnLogon.TabIndex = 4;
            this.btnLogon.Text = "Logon";
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            this.errorProvider.Icon = null;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(116, 300);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(83, 14);
            this.lblErrorMessage.TabIndex = 12;
            this.lblErrorMessage.Text = "Error Message";
            this.lblErrorMessage.Visible = false;
            // 
            // headerPane
            // 
            this.headerPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.headerPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.headerPane.Location = new System.Drawing.Point(0, 0);
            this.headerPane.Name = "headerPane";
            this.headerPane.Size = new System.Drawing.Size(524, 111);
            this.headerPane.TabIndex = 13;
            this.headerPane.Text = "HeaderPane";
            // 
            // Logon
            // 
            this.AcceptButton = this.btnLogon;
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblShopNumber);
            this.Controls.Add(this.lblShopPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtShopPassword);
            this.Controls.Add(this.cboShopList);
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.headerPane);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(524, 377);
            this.Text = "RT2020 > Web Shop > Logon";
            this.Load += new System.EventHandler(this.Logon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblUserName;
        private Gizmox.WebGUI.Forms.Label lblPassword;
        private Gizmox.WebGUI.Forms.Label lblShopNumber;
        private Gizmox.WebGUI.Forms.Label lblShopPassword;
        private Gizmox.WebGUI.Forms.TextBox txtUserName;
        private Gizmox.WebGUI.Forms.TextBox txtPassword;
        private Gizmox.WebGUI.Forms.TextBox txtShopPassword;
        private Gizmox.WebGUI.Forms.ComboBox cboShopList;
        private Gizmox.WebGUI.Forms.Button btnLogon;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblErrorMessage;
        private HeaderPane headerPane;


    }
}