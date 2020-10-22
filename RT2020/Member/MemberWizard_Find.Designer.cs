namespace RT2020.Member
{
    partial class MemberWizard_Find
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
            this.lblMemberNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblFirstName = new Gizmox.WebGUI.Forms.Label();
            this.lblLastName = new Gizmox.WebGUI.Forms.Label();
            this.lblHKID = new Gizmox.WebGUI.Forms.Label();
            this.txtMemberNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFirstName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHKID = new Gizmox.WebGUI.Forms.TextBox();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.gbResultSet = new Gizmox.WebGUI.Forms.GroupBox();
            this.lvResultSet = new Gizmox.WebGUI.Forms.ListView();
            this.colMemberId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRecords = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFirstName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHKID = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMemberNumber
            // 
            this.lblMemberNumber.Location = new System.Drawing.Point(36, 28);
            this.lblMemberNumber.Name = "lblMemberNumber";
            this.lblMemberNumber.Size = new System.Drawing.Size(100, 23);
            this.lblMemberNumber.TabIndex = 0;
            this.lblMemberNumber.Text = "Member #:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(36, 55);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(100, 23);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(36, 82);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(100, 23);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblHKID
            // 
            this.lblHKID.Location = new System.Drawing.Point(36, 109);
            this.lblHKID.Name = "lblHKID";
            this.lblHKID.Size = new System.Drawing.Size(100, 23);
            this.lblHKID.TabIndex = 3;
            this.lblHKID.Text = "HKID:";
            // 
            // txtMemberNumber
            // 
            this.txtMemberNumber.Location = new System.Drawing.Point(142, 25);
            this.txtMemberNumber.Name = "txtMemberNumber";
            this.txtMemberNumber.Size = new System.Drawing.Size(100, 20);
            this.txtMemberNumber.TabIndex = 4;
            this.txtMemberNumber.Text = "*";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(142, 52);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 5;
            this.txtFirstName.Text = "*";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(142, 79);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 6;
            this.txtLastName.Text = "*";
            // 
            // txtHKID
            // 
            this.txtHKID.Location = new System.Drawing.Point(142, 106);
            this.txtHKID.Name = "txtHKID";
            this.txtHKID.Size = new System.Drawing.Size(100, 20);
            this.txtHKID.TabIndex = 7;
            this.txtHKID.Text = "*";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(296, 104);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.ButtonClick);
            // 
            // gbResultSet
            // 
            this.gbResultSet.Controls.Add(this.lvResultSet);
            this.gbResultSet.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbResultSet.Location = new System.Drawing.Point(12, 144);
            this.gbResultSet.Name = "gbResultSet";
            this.gbResultSet.Size = new System.Drawing.Size(395, 206);
            this.gbResultSet.TabIndex = 9;
            // 
            // lvResultSet
            // 
            this.lvResultSet.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvResultSet.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colMemberId,
            this.colRecords,
            this.colMemberNumber,
            this.colFirstName,
            this.colLastName,
            this.colHKID});
            this.lvResultSet.DataMember = null;
            this.lvResultSet.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvResultSet.ItemsPerPage = 20;
            this.lvResultSet.Location = new System.Drawing.Point(3, 16);
            this.lvResultSet.Name = "lvResultSet";
            this.lvResultSet.Size = new System.Drawing.Size(389, 187);
            this.lvResultSet.TabIndex = 0;
            // 
            // colMemberId
            // 
            this.colMemberId.Image = null;
            this.colMemberId.Text = "MemberId";
            this.colMemberId.Visible = false;
            this.colMemberId.Width = 150;
            // 
            // colRecords
            // 
            this.colRecords.Image = null;
            this.colRecords.Text = "Records";
            this.colRecords.Width = 60;
            // 
            // colMemberNumber
            // 
            this.colMemberNumber.Image = null;
            this.colMemberNumber.Text = "Member #";
            this.colMemberNumber.Width = 90;
            // 
            // colFirstName
            // 
            this.colFirstName.Image = null;
            this.colFirstName.Text = "First Name";
            this.colFirstName.Width = 80;
            // 
            // colLastName
            // 
            this.colLastName.Image = null;
            this.colLastName.Text = "Last Name";
            this.colLastName.Width = 80;
            // 
            // colHKID
            // 
            this.colHKID.Image = null;
            this.colHKID.Text = "HKID";
            this.colHKID.Width = 90;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(167, 369);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.ButtonClick);
            // 
            // MemberWizard_Find
            // 
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbResultSet);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtHKID);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtMemberNumber);
            this.Controls.Add(this.lblHKID);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblMemberNumber);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(419, 414);
            this.Text = "Find Member";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblMemberNumber;
        private Gizmox.WebGUI.Forms.Label lblFirstName;
        private Gizmox.WebGUI.Forms.Label lblLastName;
        private Gizmox.WebGUI.Forms.Label lblHKID;
        private Gizmox.WebGUI.Forms.TextBox txtMemberNumber;
        private Gizmox.WebGUI.Forms.TextBox txtFirstName;
        private Gizmox.WebGUI.Forms.TextBox txtLastName;
        private Gizmox.WebGUI.Forms.TextBox txtHKID;
        private Gizmox.WebGUI.Forms.Button btnFind;
        private Gizmox.WebGUI.Forms.GroupBox gbResultSet;
        private Gizmox.WebGUI.Forms.ListView lvResultSet;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberId;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecords;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colFirstName;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastName;
        private Gizmox.WebGUI.Forms.ColumnHeader colHKID;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Button btnCancel;


    }
}