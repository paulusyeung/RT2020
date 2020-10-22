namespace RT2020.Settings
{
    partial class SystemMonthEnd
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
            this.gbStep1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkResetServiceItemCDQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.btnProcess = new Gizmox.WebGUI.Forms.Button();
            this.txtMonthEnded = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCompanyName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMonthEnded = new Gizmox.WebGUI.Forms.Label();
            this.lblCompanyName = new Gizmox.WebGUI.Forms.Label();
            this.gbProgress = new Gizmox.WebGUI.Forms.GroupBox();
            this.progressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.txtProgessMessage = new Gizmox.WebGUI.Forms.Label();
            this.lblProgressMessage = new Gizmox.WebGUI.Forms.Label();
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.SuspendLayout();
            // 
            // gbStep1
            // 
            this.gbStep1.Controls.Add(this.chkResetServiceItemCDQty);
            this.gbStep1.Controls.Add(this.btnCancel);
            this.gbStep1.Controls.Add(this.btnProcess);
            this.gbStep1.Controls.Add(this.txtMonthEnded);
            this.gbStep1.Controls.Add(this.txtCompanyName);
            this.gbStep1.Controls.Add(this.lblMonthEnded);
            this.gbStep1.Controls.Add(this.lblCompanyName);
            this.gbStep1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbStep1.Location = new System.Drawing.Point(12, 10);
            this.gbStep1.Name = "gbStep1";
            this.gbStep1.Size = new System.Drawing.Size(458, 116);
            this.gbStep1.TabIndex = 0;
            this.gbStep1.TabStop = false;
            this.gbStep1.Text = "Preparation";
            // 
            // chkResetServiceItemCDQty
            // 
            this.chkResetServiceItemCDQty.Checked = false;
            this.chkResetServiceItemCDQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkResetServiceItemCDQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkResetServiceItemCDQty.Location = new System.Drawing.Point(31, 78);
            this.chkResetServiceItemCDQty.Name = "chkResetServiceItemCDQty";
            this.chkResetServiceItemCDQty.Size = new System.Drawing.Size(179, 17);
            this.chkResetServiceItemCDQty.TabIndex = 1;
            this.chkResetServiceItemCDQty.Text = "Reset Service Item\'s CDQty = 0";
            this.chkResetServiceItemCDQty.ThreeState = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(362, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(269, 74);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtMonthEnded
            // 
            this.txtMonthEnded.BackColor = System.Drawing.Color.LightYellow;
            this.txtMonthEnded.Location = new System.Drawing.Point(113, 51);
            this.txtMonthEnded.Name = "txtMonthEnded";
            this.txtMonthEnded.ReadOnly = true;
            this.txtMonthEnded.Size = new System.Drawing.Size(100, 21);
            this.txtMonthEnded.TabIndex = 3;
            this.txtMonthEnded.TabStop = false;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.LightYellow;
            this.txtCompanyName.Location = new System.Drawing.Point(113, 24);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(198, 21);
            this.txtCompanyName.TabIndex = 2;
            this.txtCompanyName.TabStop = false;
            // 
            // lblMonthEnded
            // 
            this.lblMonthEnded.AutoSize = true;
            this.lblMonthEnded.Location = new System.Drawing.Point(28, 54);
            this.lblMonthEnded.Name = "lblMonthEnded";
            this.lblMonthEnded.Size = new System.Drawing.Size(74, 13);
            this.lblMonthEnded.TabIndex = 1;
            this.lblMonthEnded.Text = "Month Ended:";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(28, 27);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(56, 13);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Company:";
            // 
            // gbProgress
            // 
            this.gbProgress.Controls.Add(this.progressBar);
            this.gbProgress.Controls.Add(this.txtProgessMessage);
            this.gbProgress.Controls.Add(this.lblProgressMessage);
            this.gbProgress.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbProgress.Location = new System.Drawing.Point(12, 132);
            this.gbProgress.Name = "gbProgress";
            this.gbProgress.Size = new System.Drawing.Size(458, 92);
            this.gbProgress.TabIndex = 1;
            this.gbProgress.TabStop = false;
            this.gbProgress.Text = "Progress";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(22, 43);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(415, 23);
            this.progressBar.TabIndex = 3;
            // 
            // txtProgessMessage
            // 
            this.txtProgessMessage.Location = new System.Drawing.Point(87, 27);
            this.txtProgessMessage.Name = "txtProgessMessage";
            this.txtProgessMessage.Size = new System.Drawing.Size(350, 13);
            this.txtProgessMessage.TabIndex = 1;
            this.txtProgessMessage.Text = "[Progress Message]";
            // 
            // lblProgressMessage
            // 
            this.lblProgressMessage.AutoSize = true;
            this.lblProgressMessage.Location = new System.Drawing.Point(28, 27);
            this.lblProgressMessage.Name = "lblProgressMessage";
            this.lblProgressMessage.Size = new System.Drawing.Size(53, 13);
            this.lblProgressMessage.TabIndex = 0;
            this.lblProgressMessage.Text = "Message:";
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPane.Controls.Add(this.gbStep1);
            this.mainPane.Controls.Add(this.gbProgress);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(482, 239);
            this.mainPane.TabIndex = 2;
            // 
            // SystemMonthEnd
            // 
            this.Controls.Add(this.mainPane);
            this.Size = new System.Drawing.Size(482, 239);
            this.Text = "RT2020 > Month End";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox gbStep1;
        private Gizmox.WebGUI.Forms.CheckBox chkResetServiceItemCDQty;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Button btnProcess;
        private Gizmox.WebGUI.Forms.TextBox txtMonthEnded;
        private Gizmox.WebGUI.Forms.TextBox txtCompanyName;
        private Gizmox.WebGUI.Forms.Label lblMonthEnded;
        private Gizmox.WebGUI.Forms.Label lblCompanyName;
        private Gizmox.WebGUI.Forms.GroupBox gbProgress;
        private Gizmox.WebGUI.Forms.ProgressBar progressBar;
        private Gizmox.WebGUI.Forms.Label txtProgessMessage;
        private Gizmox.WebGUI.Forms.Label lblProgressMessage;
        private Gizmox.WebGUI.Forms.Panel mainPane;
    }
}

