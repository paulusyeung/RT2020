namespace RT2020.Client
{
	partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.butSetting = new System.Windows.Forms.Button();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // butSetting
            // 
            this.butSetting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butSetting.Location = new System.Drawing.Point(11, 215);
            this.butSetting.Name = "butSetting";
            this.butSetting.Size = new System.Drawing.Size(75, 23);
            this.butSetting.TabIndex = 101;
            this.butSetting.Text = "Setting";
            this.butSetting.UseVisualStyleBackColor = true;
            this.butSetting.Visible = false;
            this.butSetting.Click += new System.EventHandler(this.butSetting_Click);
            // 
            // cbRemember
            // 
            this.cbRemember.AccessibleDescription = "Remember password";
            this.cbRemember.AccessibleName = "Remember Password";
            this.cbRemember.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbRemember.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbRemember.Location = new System.Drawing.Point(103, 178);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(136, 24);
            this.cbRemember.TabIndex = 97;
            this.cbRemember.Text = "Remember Password";
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butCancel.Location = new System.Drawing.Point(263, 215);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 99;
            this.butCancel.Text = "Cancel";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = "OK";
            this.btnOK.AccessibleName = "OK";
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(175, 215);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 98;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.lblVersion);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Location = new System.Drawing.Point(-1, -1);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(496, 80);
            this.Panel1.TabIndex = 91;
            // 
            // lblVersion
            // 
            this.lblVersion.AccessibleDescription = "Version label";
            this.lblVersion.AccessibleName = "Version Label";
            this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVersion.Location = new System.Drawing.Point(106, 48);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(144, 16);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "< version >";
            // 
            // Label3
            // 
            this.Label3.AccessibleDescription = "TaskVision label";
            this.Label3.AccessibleName = "TaskVision label";
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(106, 16);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(191, 23);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "RT2020.Client";
            // 
            // PictureBox1
            // 
            this.PictureBox1.AccessibleDescription = "Logo for TaskVision";
            this.PictureBox1.AccessibleName = "Logo for TaskVision";
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox1.Location = new System.Drawing.Point(32, 15);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(48, 48);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AccessibleDescription = "User Name";
            this.lblUserName.AccessibleName = "User Name";
            this.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUserName.Location = new System.Drawing.Point(25, 99);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(72, 20);
            this.lblUserName.TabIndex = 92;
            this.lblUserName.Text = "User Number:";
            // 
            // txtPassword
            // 
            this.txtPassword.AccessibleDescription = "Password";
            this.txtPassword.AccessibleName = "Password";
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPassword.Location = new System.Drawing.Point(103, 137);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 20);
            this.txtPassword.TabIndex = 95;
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleDescription = "User name";
            this.txtUserName.AccessibleName = "User name";
            this.txtUserName.Location = new System.Drawing.Point(103, 99);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(192, 20);
            this.txtUserName.TabIndex = 93;
            // 
            // lblPassword
            // 
            this.lblPassword.AccessibleDescription = "Password";
            this.lblPassword.AccessibleName = "Password";
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPassword.Location = new System.Drawing.Point(25, 139);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 20);
            this.lblPassword.TabIndex = 94;
            this.lblPassword.Text = "Password:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 259);
            this.Controls.Add(this.butSetting);
            this.Controls.Add(this.cbRemember);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyUp);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button butSetting;
		internal System.Windows.Forms.CheckBox cbRemember;
		internal System.Windows.Forms.Button butCancel;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Label lblVersion;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label lblUserName;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.TextBox txtUserName;
		internal System.Windows.Forms.Label lblPassword;
	}
}