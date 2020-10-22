namespace RT2020.Inventory.GoodsReceive.Export
{
    partial class Export2Txt
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
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtnPosted = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnUnposted = new Gizmox.WebGUI.Forms.RadioButton();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.cboFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.btnExport = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnPosted);
            this.groupBox1.Controls.Add(this.rbtnUnposted);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Export";
            // 
            // rbtnPosted
            // 
            this.rbtnPosted.Checked = true;
            this.rbtnPosted.Location = new System.Drawing.Point(18, 60);
            this.rbtnPosted.Name = "rbtnPosted";
            this.rbtnPosted.Size = new System.Drawing.Size(104, 24);
            this.rbtnPosted.TabIndex = 3;
            this.rbtnPosted.Text = "Posted";
            this.rbtnPosted.CheckedChanged += new System.EventHandler(this.rbtnPosted_CheckedChanged);
            // 
            // rbtnUnposted
            // 
            this.rbtnUnposted.Location = new System.Drawing.Point(18, 30);
            this.rbtnUnposted.Name = "rbtnUnposted";
            this.rbtnUnposted.Size = new System.Drawing.Size(104, 24);
            this.rbtnUnposted.TabIndex = 2;
            this.rbtnUnposted.Text = "Un-posted";
            this.rbtnUnposted.CheckedChanged += new System.EventHandler(this.rbtnUnposted_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.cboFrom);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(179, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.Text = "Range";
            // 
            // cboTo
            // 
            this.cboTo.DropDownWidth = 143;
            this.cboTo.Location = new System.Drawing.Point(64, 63);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(143, 21);
            this.cboTo.TabIndex = 5;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(17, 36);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 23);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            // 
            // cboFrom
            // 
            this.cboFrom.DropDownWidth = 143;
            this.cboFrom.Location = new System.Drawing.Point(64, 33);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(143, 21);
            this.cboFrom.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(17, 66);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 23);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(251, 128);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(332, 128);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Export2Txt
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 163);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Goods Receive > Export";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.RadioButton rbtnPosted;
        private Gizmox.WebGUI.Forms.RadioButton rbtnUnposted;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Button btnExport;
        private Gizmox.WebGUI.Forms.Button btnExit;


    }
}