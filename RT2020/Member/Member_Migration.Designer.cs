namespace RT2020.Member
{
    partial class Member_Migration
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
            this.rbtnOption1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnOption2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnOverwriteAllRecords = new Gizmox.WebGUI.Forms.RadioButton();
            this.gbOptions = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblOption1 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnProcess = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnOption1
            // 
            this.rbtnOption1.Location = new System.Drawing.Point(27, 30);
            this.rbtnOption1.Name = "rbtnOption1";
            this.rbtnOption1.Size = new System.Drawing.Size(351, 24);
            this.rbtnOption1.TabIndex = 0;
            this.rbtnOption1.Text = "1. Migrate Temporary VIP to Permanent VIP";
            // 
            // rbtnOption2
            // 
            this.rbtnOption2.Location = new System.Drawing.Point(27, 81);
            this.rbtnOption2.Name = "rbtnOption2";
            this.rbtnOption2.Size = new System.Drawing.Size(351, 24);
            this.rbtnOption2.TabIndex = 0;
            this.rbtnOption2.Text = "2. Migrate Temporary VIP to Permanent VIP With Delete";
            // 
            // rbtnOverwriteAllRecords
            // 
            this.rbtnOverwriteAllRecords.Enabled = false;
            this.rbtnOverwriteAllRecords.Location = new System.Drawing.Point(27, 132);
            this.rbtnOverwriteAllRecords.Name = "rbtnOverwriteAllRecords";
            this.rbtnOverwriteAllRecords.Size = new System.Drawing.Size(351, 24);
            this.rbtnOverwriteAllRecords.TabIndex = 0;
            this.rbtnOverwriteAllRecords.Text = "Overwrite all VIP records";
            this.rbtnOverwriteAllRecords.Visible = false;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.lblOption1);
            this.gbOptions.Controls.Add(this.label1);
            this.gbOptions.Controls.Add(this.rbtnOption2);
            this.gbOptions.Controls.Add(this.rbtnOverwriteAllRecords);
            this.gbOptions.Controls.Add(this.rbtnOption1);
            this.gbOptions.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbOptions.Location = new System.Drawing.Point(12, 12);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(410, 173);
            this.gbOptions.TabIndex = 1;
            this.gbOptions.Text = "Options";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(39, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "** Select this option ONLY IF you \'Export All Records\' in \'";
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.btnExit);
            this.mainPane.Controls.Add(this.btnProcess);
            this.mainPane.Controls.Add(this.gbOptions);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(434, 249);
            this.mainPane.TabIndex = 2;
            this.mainPane.KeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.mainPane_KeyDown);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(315, 206);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(225, 206);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Member_Migration
            // 
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.mainPane);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(434, 249);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Migrate Temporary VIP Code";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.RadioButton rbtnOption1;
        private Gizmox.WebGUI.Forms.RadioButton rbtnOption2;
        private Gizmox.WebGUI.Forms.RadioButton rbtnOverwriteAllRecords;
        private Gizmox.WebGUI.Forms.GroupBox gbOptions;
        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnProcess;
        private Gizmox.WebGUI.Forms.Label lblOption1;
        private Gizmox.WebGUI.Forms.Label label1;


    }
}