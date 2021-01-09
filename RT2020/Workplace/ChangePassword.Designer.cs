namespace RT2020.Workplace
{
    partial class ChangePassword
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
            this.lblOldPwd = new Gizmox.WebGUI.Forms.Label();
            this.lblNewpwd = new Gizmox.WebGUI.Forms.Label();
            this.lblComPwd = new Gizmox.WebGUI.Forms.Label();
            this.txtOldPwd = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNewPwd = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCNewPwd = new Gizmox.WebGUI.Forms.TextBox();
            this.btnAccept = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.Location = new System.Drawing.Point(57, 35);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(150, 23);
            this.lblOldPwd.TabIndex = 0;
            this.lblOldPwd.Text = "Old Password:";
            this.lblOldPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNewpwd
            // 
            this.lblNewpwd.Location = new System.Drawing.Point(57, 73);
            this.lblNewpwd.Name = "lblNewpwd";
            this.lblNewpwd.Size = new System.Drawing.Size(150, 23);
            this.lblNewpwd.TabIndex = 0;
            this.lblNewpwd.Text = "New Password:";
            this.lblNewpwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComPwd
            // 
            this.lblComPwd.Location = new System.Drawing.Point(57, 113);
            this.lblComPwd.Name = "lblComPwd";
            this.lblComPwd.Size = new System.Drawing.Size(150, 23);
            this.lblComPwd.TabIndex = 0;
            this.lblComPwd.Text = "Confirm New Password:";
            this.lblComPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(213, 35);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(156, 21);
            this.txtOldPwd.TabIndex = 0;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(213, 75);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(156, 21);
            this.txtNewPwd.TabIndex = 1;
            this.txtNewPwd.GotFocus += new System.EventHandler(this.txtNewPwd_GotFocus);
            // 
            // txtCNewPwd
            // 
            this.txtCNewPwd.Location = new System.Drawing.Point(213, 115);
            this.txtCNewPwd.Name = "txtCNewPwd";
            this.txtCNewPwd.PasswordChar = '*';
            this.txtCNewPwd.Size = new System.Drawing.Size(156, 21);
            this.txtCNewPwd.TabIndex = 2;
            this.txtCNewPwd.Click += new System.EventHandler(this.txtNewPwd_GotFocus);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(213, 163);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(294, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChangePassword
            // 
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtCNewPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.lblComPwd);
            this.Controls.Add(this.lblNewpwd);
            this.Controls.Add(this.lblOldPwd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 232);
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblOldPwd;
        private Gizmox.WebGUI.Forms.Label lblNewpwd;
        private Gizmox.WebGUI.Forms.Label lblComPwd;
        private Gizmox.WebGUI.Forms.TextBox txtOldPwd;
        private Gizmox.WebGUI.Forms.TextBox txtNewPwd;
        private Gizmox.WebGUI.Forms.TextBox txtCNewPwd;
        private Gizmox.WebGUI.Forms.Button btnAccept;
        private Gizmox.WebGUI.Forms.Button btnCancel;


    }
}