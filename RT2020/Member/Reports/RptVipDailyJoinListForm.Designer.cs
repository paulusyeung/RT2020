namespace RT2020.Member.Reports
{
    partial class RptVipDailyJoinListForm
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
            this.lblToRegDate = new Gizmox.WebGUI.Forms.Label();
            this.dtpFromRegDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpToRegDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblFromRegDate = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.btnExportToExcel = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblToRegDate
            // 
            this.lblToRegDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblToRegDate.Location = new System.Drawing.Point(130, 46);
            this.lblToRegDate.Name = "lblToRegDate";
            this.lblToRegDate.Size = new System.Drawing.Size(51, 23);
            this.lblToRegDate.TabIndex = 9;
            this.lblToRegDate.Text = "To";
            // 
            // dtpFromRegDate
            // 
            this.dtpFromRegDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromRegDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromRegDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpFromRegDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromRegDate.Location = new System.Drawing.Point(187, 22);
            this.dtpFromRegDate.Name = "dtpFromRegDate";
            this.dtpFromRegDate.Size = new System.Drawing.Size(120, 20);
            this.dtpFromRegDate.TabIndex = 10;
            // 
            // dtpToRegDate
            // 
            this.dtpToRegDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToRegDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToRegDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpToRegDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToRegDate.Location = new System.Drawing.Point(187, 47);
            this.dtpToRegDate.Name = "dtpToRegDate";
            this.dtpToRegDate.Size = new System.Drawing.Size(120, 20);
            this.dtpToRegDate.TabIndex = 11;
            // 
            // lblFromRegDate
            // 
            this.lblFromRegDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblFromRegDate.Location = new System.Drawing.Point(130, 21);
            this.lblFromRegDate.Name = "lblFromRegDate";
            this.lblFromRegDate.Size = new System.Drawing.Size(51, 23);
            this.lblFromRegDate.TabIndex = 8;
            this.lblFromRegDate.Text = "From";
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Registration Date";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExportToExcel.Location = new System.Drawing.Point(129, 89);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(97, 23);
            this.btnExportToExcel.TabIndex = 13;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnExit
            // 
            this.btnExit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExit.Location = new System.Drawing.Point(232, 89);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // RptVipDailyJoinListForm
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFromRegDate);
            this.Controls.Add(this.dtpToRegDate);
            this.Controls.Add(this.dtpFromRegDate);
            this.Controls.Add(this.lblToRegDate);
            this.Size = new System.Drawing.Size(319, 125);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Vip Daily Join List - Export to Excel";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblToRegDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromRegDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToRegDate;
        private Gizmox.WebGUI.Forms.Label lblFromRegDate;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Button btnExportToExcel;
        private Gizmox.WebGUI.Forms.Button btnExit;


    }
}