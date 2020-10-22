namespace RT2020.Staff
{
    partial class FindHKID
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
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.lvStaffList = new Gizmox.WebGUI.Forms.ListView();
            this.columnRecord = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnStaff = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHKID = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.lblHKID = new Gizmox.WebGUI.Forms.Label();
            this.lblStaff = new Gizmox.WebGUI.Forms.Label();
            this.txtStaff = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHKID = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(277, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cencel";
            this.btnCancel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(190, 320);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 24);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lvStaffList
            // 
            this.lvStaffList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnRecord,
            this.columnStaff,
            this.columnHKID});
            this.lvStaffList.ItemsPerPage = 20;
            this.lvStaffList.Location = new System.Drawing.Point(38, 88);
            this.lvStaffList.Name = "lvStaffList";
            this.lvStaffList.Size = new System.Drawing.Size(477, 207);
            this.lvStaffList.TabIndex = 4;
            // 
            // columnRecord
            // 
            this.columnRecord.Image = null;
            this.columnRecord.Text = "Record";
            this.columnRecord.Width = 80;
            // 
            // columnStaff
            // 
            this.columnStaff.Image = null;
            this.columnStaff.Text = "Staff#";
            this.columnStaff.Width = 100;
            // 
            // columnHKID
            // 
            this.columnHKID.Image = null;
            this.columnHKID.Text = "HKID";
            this.columnHKID.Width = 100;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(417, 54);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblHKID
            // 
            this.lblHKID.Location = new System.Drawing.Point(74, 55);
            this.lblHKID.Name = "lblHKID";
            this.lblHKID.Size = new System.Drawing.Size(73, 23);
            this.lblHKID.TabIndex = 0;
            this.lblHKID.Text = "HKID#";
            this.lblHKID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStaff
            // 
            this.lblStaff.Location = new System.Drawing.Point(74, 27);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(57, 21);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "Staff#";
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStaff
            // 
            this.txtStaff.BackColor = System.Drawing.SystemColors.Control;
            this.txtStaff.Location = new System.Drawing.Point(153, 28);
            this.txtStaff.MaxLength = 4;
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(248, 21);
            this.txtStaff.TabIndex = 1;
            this.txtStaff.Text = "*";
            // 
            // txtHKID
            // 
            this.txtHKID.Location = new System.Drawing.Point(153, 55);
            this.txtHKID.Name = "txtHKID";
            this.txtHKID.Size = new System.Drawing.Size(248, 21);
            this.txtHKID.TabIndex = 2;
            this.txtHKID.Text = "*";
            // 
            // FindHKID
            // 
            this.Controls.Add(this.txtHKID);
            this.Controls.Add(this.txtStaff);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.lblHKID);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lvStaffList);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Size = new System.Drawing.Size(571, 378);
            this.Text = "Find HKID";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Button btnOk;
        private Gizmox.WebGUI.Forms.ListView lvStaffList;
        private Gizmox.WebGUI.Forms.ColumnHeader columnRecord;
        private Gizmox.WebGUI.Forms.ColumnHeader columnStaff;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHKID;
        private Gizmox.WebGUI.Forms.Button btnFind;
        private Gizmox.WebGUI.Forms.Label lblHKID;
        private Gizmox.WebGUI.Forms.Label lblStaff;
        private Gizmox.WebGUI.Forms.TextBox txtStaff;
        private Gizmox.WebGUI.Forms.TextBox txtHKID;


    }
}