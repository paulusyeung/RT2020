namespace RT2020.EmulatedPoS
{
    partial class FastModeLogin
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
            this.dtpTxDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cboWorkplace = new Gizmox.WebGUI.Forms.ComboBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpTxDate
            // 
            this.dtpTxDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpTxDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDate.Location = new System.Drawing.Point(74, 11);
            this.dtpTxDate.MaxDate = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            this.dtpTxDate.Name = "dtpTxDate";
            this.dtpTxDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxDate.TabIndex = 2;
            this.dtpTxDate.Value = new System.DateTime(2010, 4, 22, 0, 0, 0, 0);
            // 
            // cboWorkplace
            // 
            this.cboWorkplace.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboWorkplace.Location = new System.Drawing.Point(74, 37);
            this.cboWorkplace.Name = "cboWorkplace";
            this.cboWorkplace.Size = new System.Drawing.Size(231, 21);
            this.cboWorkplace.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Loc#";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Trn. Date";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(99, 73);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(180, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FastModeLogin
            // 
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboWorkplace);
            this.Controls.Add(this.dtpTxDate);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(322, 109);
            this.Text = "FastModeLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDate;
        private Gizmox.WebGUI.Forms.ComboBox cboWorkplace;
        private Gizmox.WebGUI.Forms.Label label7;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Button btnOk;
        private Gizmox.WebGUI.Forms.Button btnCancel;


    }
}