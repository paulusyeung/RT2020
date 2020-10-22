namespace RT2020.Client
{
    partial class SqlConnection
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
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblAuth = new System.Windows.Forms.Label();
            this.radWinAuth = new System.Windows.Forms.RadioButton();
            this.radSqlAuth = new System.Windows.Forms.RadioButton();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(13, 13);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(72, 13);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Server Name:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(110, 10);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(268, 20);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SqlConnection_KeyUp);
            // 
            // lblAuth
            // 
            this.lblAuth.AutoSize = true;
            this.lblAuth.Location = new System.Drawing.Point(13, 43);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(78, 13);
            this.lblAuth.TabIndex = 2;
            this.lblAuth.Text = "Authentication:";
            // 
            // radWinAuth
            // 
            this.radWinAuth.AutoSize = true;
            this.radWinAuth.Location = new System.Drawing.Point(110, 43);
            this.radWinAuth.Name = "radWinAuth";
            this.radWinAuth.Size = new System.Drawing.Size(140, 17);
            this.radWinAuth.TabIndex = 3;
            this.radWinAuth.TabStop = true;
            this.radWinAuth.Text = "Windows Authentication";
            this.radWinAuth.UseVisualStyleBackColor = true;
            this.radWinAuth.CheckedChanged += new System.EventHandler(this.Auth_CheckedChanged);
            // 
            // radSqlAuth
            // 
            this.radSqlAuth.AutoSize = true;
            this.radSqlAuth.Location = new System.Drawing.Point(110, 67);
            this.radSqlAuth.Name = "radSqlAuth";
            this.radSqlAuth.Size = new System.Drawing.Size(151, 17);
            this.radSqlAuth.TabIndex = 4;
            this.radSqlAuth.TabStop = true;
            this.radSqlAuth.Text = "SQL Server Authentication";
            this.radSqlAuth.UseVisualStyleBackColor = true;
            this.radSqlAuth.CheckedChanged += new System.EventHandler(this.Auth_CheckedChanged);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(13, 96);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 5;
            this.lblLogin.Text = "Login:";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(110, 96);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(268, 20);
            this.txtLogin.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(13, 127);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 127);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(268, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(292, 162);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(86, 23);
            this.cmdSave.TabIndex = 9;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // SqlConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 197);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.radSqlAuth);
            this.Controls.Add(this.radWinAuth);
            this.Controls.Add(this.lblAuth);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblServerName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings > Sql Connection";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SqlConnection_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblAuth;
        private System.Windows.Forms.RadioButton radWinAuth;
        private System.Windows.Forms.RadioButton radSqlAuth;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button cmdSave;
    }
}