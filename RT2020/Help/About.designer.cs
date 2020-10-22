namespace RT2020.Help
{
    partial class About
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
            this.lnkWebsite = new Gizmox.WebGUI.Forms.LinkLabel();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.lnkCopyright = new Gizmox.WebGUI.Forms.LinkLabel();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLabelVersion = new Gizmox.WebGUI.Forms.Label();
            this.cmdOK = new Gizmox.WebGUI.Forms.Button();
            this.picLogo = new Gizmox.WebGUI.Forms.PictureBox();
            this.clientStorage1 = new Gizmox.WebGUI.Forms.Client.ClientStorage();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkWebsite
            // 
            this.lnkWebsite.LinkColor = System.Drawing.Color.Blue;
            this.lnkWebsite.Location = new System.Drawing.Point(53, 128);
            this.lnkWebsite.Name = "lnkWebsite";
            this.lnkWebsite.Size = new System.Drawing.Size(314, 16);
            this.lnkWebsite.TabIndex = 0;
            this.lnkWebsite.TabStop = true;
            this.lnkWebsite.Text = "www.nxstudio.com";
            this.lnkWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkWebsite.Url = "http://www.nxstudio.com";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Site:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkCopyright
            // 
            this.lnkCopyright.LinkColor = System.Drawing.Color.Blue;
            this.lnkCopyright.Location = new System.Drawing.Point(7, 296);
            this.lnkCopyright.Name = "lnkCopyright";
            this.lnkCopyright.Size = new System.Drawing.Size(272, 23);
            this.lnkCopyright.TabIndex = 2;
            this.lnkCopyright.TabStop = true;
            this.lnkCopyright.Text = "Copyright (c) 2020 nxStudio";
            this.lnkCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 168);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(360, 120);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "RT2020 is developed using ASP.NET (C#) and Visual WebGUI framework. Visual WebGui" +
    " is an open source rapid application development framework built on top of Micro" +
    "soft ASP.NET (C#) platform.";
            // 
            // mobjLabelVersion
            // 
            this.mobjLabelVersion.Location = new System.Drawing.Point(7, 112);
            this.mobjLabelVersion.Name = "mobjLabelVersion";
            this.mobjLabelVersion.Size = new System.Drawing.Size(360, 16);
            this.mobjLabelVersion.TabIndex = 4;
            this.mobjLabelVersion.Text = "Version: {0} ({1})";
            this.mobjLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(295, 296);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.Location = new System.Drawing.Point(-1, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(382, 100);
            this.picLogo.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 6;
            this.picLogo.TabStop = false;
            // 
            // clientStorage1
            // 
            this.clientStorage1.Description = "";
            this.clientStorage1.MajorVersion = ((ushort)(1));
            this.clientStorage1.MinorVersion = ((ushort)(0));
            // 
            // About
            // 
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.mobjLabelVersion);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lnkCopyright);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lnkWebsite);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(376, 326);
            this.Text = "About RT2020";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.LinkLabel lnkWebsite;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.LinkLabel lnkCopyright;
        private Gizmox.WebGUI.Forms.TextBox textBox2;
        private Gizmox.WebGUI.Forms.Label mobjLabelVersion;
        private Gizmox.WebGUI.Forms.Button cmdOK;
        private Gizmox.WebGUI.Forms.PictureBox picLogo;
        private Gizmox.WebGUI.Forms.Client.ClientStorage clientStorage1;
    }
}