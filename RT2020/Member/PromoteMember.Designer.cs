namespace RT2020.Member
{
    partial class PromoteMember
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
            this.radOption1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.radOption2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.radPurgeAllRecords = new Gizmox.WebGUI.Forms.RadioButton();
            this.gbxOptions = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblOption1 = new Gizmox.WebGUI.Forms.Label();
            this.lblOption2 = new Gizmox.WebGUI.Forms.Label();
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnProcess = new Gizmox.WebGUI.Forms.Button();
            this.gbxOptions.SuspendLayout();
            this.mainPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // radOption1
            // 
            this.radOption1.Location = new System.Drawing.Point(27, 30);
            this.radOption1.Name = "radOption1";
            this.radOption1.Size = new System.Drawing.Size(351, 24);
            this.radOption1.TabIndex = 0;
            this.radOption1.Tag = "option1";
            this.radOption1.Text = "1. Migrate Temporary VIP to Permanent VIP";
            this.radOption1.CheckedChanged += new System.EventHandler(this.options_CheckedChanged);
            // 
            // radOption2
            // 
            this.radOption2.Location = new System.Drawing.Point(27, 81);
            this.radOption2.Name = "radOption2";
            this.radOption2.Size = new System.Drawing.Size(351, 24);
            this.radOption2.TabIndex = 2;
            this.radOption2.Tag = "option2";
            this.radOption2.Text = "2. Migrate Temporary VIP to Permanent VIP With Delete";
            this.radOption2.CheckedChanged += new System.EventHandler(this.options_CheckedChanged);
            // 
            // radPurgeAllRecords
            // 
            this.radPurgeAllRecords.Location = new System.Drawing.Point(27, 132);
            this.radPurgeAllRecords.Name = "radPurgeAllRecords";
            this.radPurgeAllRecords.Size = new System.Drawing.Size(351, 24);
            this.radPurgeAllRecords.TabIndex = 4;
            this.radPurgeAllRecords.Tag = "option3";
            this.radPurgeAllRecords.Text = "Purge all VIP records";
            this.radPurgeAllRecords.CheckedChanged += new System.EventHandler(this.options_CheckedChanged);
            // 
            // gbxOptions
            // 
            this.gbxOptions.Controls.Add(this.lblOption1);
            this.gbxOptions.Controls.Add(this.lblOption2);
            this.gbxOptions.Controls.Add(this.radOption2);
            this.gbxOptions.Controls.Add(this.radPurgeAllRecords);
            this.gbxOptions.Controls.Add(this.radOption1);
            this.gbxOptions.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxOptions.Location = new System.Drawing.Point(12, 12);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(410, 173);
            this.gbxOptions.TabIndex = 0;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Options";
            // 
            // lblOption1
            // 
            this.lblOption1.AutoSize = true;
            this.lblOption1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblOption1.ForeColor = System.Drawing.Color.Red;
            this.lblOption1.Location = new System.Drawing.Point(39, 57);
            this.lblOption1.Name = "lblOption1";
            this.lblOption1.Size = new System.Drawing.Size(369, 17);
            this.lblOption1.TabIndex = 1;
            this.lblOption1.Text = "** Select this option ONLY IF you \'Export New Records ON";
            // 
            // lblOption2
            // 
            this.lblOption2.AutoSize = true;
            this.lblOption2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblOption2.ForeColor = System.Drawing.Color.Red;
            this.lblOption2.Location = new System.Drawing.Point(39, 108);
            this.lblOption2.Name = "lblOption2";
            this.lblOption2.Size = new System.Drawing.Size(356, 17);
            this.lblOption2.TabIndex = 3;
            this.lblOption2.Text = "** Select this option ONLY IF you \'Export All Records\' in \'";
            // 
            // mainPane
            // 
            this.mainPane.Controls.Add(this.btnExit);
            this.mainPane.Controls.Add(this.btnProcess);
            this.mainPane.Controls.Add(this.gbxOptions);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Padding = new Gizmox.WebGUI.Forms.Padding(6);
            this.mainPane.Size = new System.Drawing.Size(434, 249);
            this.mainPane.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(315, 206);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(225, 206);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.ButtonClick);
            // 
            // PromoteMember
            // 
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.mainPane);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(434, 249);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Migrate Temporary VIP Code";
            this.gbxOptions.ResumeLayout(false);
            this.mainPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.RadioButton radOption1;
        private Gizmox.WebGUI.Forms.RadioButton radOption2;
        private Gizmox.WebGUI.Forms.RadioButton radPurgeAllRecords;
        private Gizmox.WebGUI.Forms.GroupBox gbxOptions;
        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnProcess;
        private Gizmox.WebGUI.Forms.Label lblOption1;
        private Gizmox.WebGUI.Forms.Label lblOption2;


    }
}