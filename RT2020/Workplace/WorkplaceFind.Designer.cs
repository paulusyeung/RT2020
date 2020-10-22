namespace RT2020.Workplace
{
    partial class WorkplaceFind
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
            this.txtInitial = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLoc = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLoc = new Gizmox.WebGUI.Forms.Label();
            this.lblInitial = new Gizmox.WebGUI.Forms.Label();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.lvWorkplaceList = new Gizmox.WebGUI.Forms.ListView();
            this.columnWorkplaceId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnRecord = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnLoc = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnInitial = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInitial
            // 
            this.txtInitial.Location = new System.Drawing.Point(153, 73);
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(248, 21);
            this.txtInitial.TabIndex = 2;
            this.txtInitial.Text = "*";
            // 
            // txtLoc
            // 
            this.txtLoc.BackColor = System.Drawing.SystemColors.Control;
            this.txtLoc.Location = new System.Drawing.Point(153, 46);
            this.txtLoc.MaxLength = 4;
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(248, 21);
            this.txtLoc.TabIndex = 1;
            this.txtLoc.Text = "*";
            // 
            // lblLoc
            // 
            this.lblLoc.Location = new System.Drawing.Point(74, 45);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(57, 21);
            this.lblLoc.TabIndex = 0;
            this.lblLoc.Text = "Loc#";
            this.lblLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInitial
            // 
            this.lblInitial.Location = new System.Drawing.Point(74, 73);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(73, 23);
            this.lblInitial.TabIndex = 0;
            this.lblInitial.Text = "Initial";
            this.lblInitial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(417, 72);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lvWorkplaceList
            // 
            this.lvWorkplaceList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnWorkplaceId,
            this.columnRecord,
            this.columnLoc,
            this.columnInitial});
            this.lvWorkplaceList.ItemsPerPage = 20;
            this.lvWorkplaceList.Location = new System.Drawing.Point(38, 106);
            this.lvWorkplaceList.Name = "lvWorkplaceList";
            this.lvWorkplaceList.Size = new System.Drawing.Size(477, 207);
            this.lvWorkplaceList.TabIndex = 4;
            // 
            // columnWorkplaceId
            // 
            this.columnWorkplaceId.Image = null;
            this.columnWorkplaceId.Text = "WorkplaceId";
            this.columnWorkplaceId.Visible = false;
            this.columnWorkplaceId.Width = 100;
            // 
            // columnRecord
            // 
            this.columnRecord.Image = null;
            this.columnRecord.Text = "Record";
            this.columnRecord.Width = 80;
            // 
            // columnLoc
            // 
            this.columnLoc.Image = null;
            this.columnLoc.Text = "Loc#";
            this.columnLoc.Width = 100;
            // 
            // columnInitial
            // 
            this.columnInitial.Image = null;
            this.columnInitial.Text = "Initial";
            this.columnInitial.Width = 100;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(190, 338);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 24);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(277, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cencel";
            this.btnCancel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // WorkplaceFind
            // 
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lvWorkplaceList);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblInitial);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.txtInitial);
            this.Size = new System.Drawing.Size(568, 410);
            this.Text = "Workplace Find";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtInitial;
        private Gizmox.WebGUI.Forms.TextBox txtLoc;
        private Gizmox.WebGUI.Forms.Label lblLoc;
        private Gizmox.WebGUI.Forms.Label lblInitial;
        private Gizmox.WebGUI.Forms.Button btnFind;
        private Gizmox.WebGUI.Forms.ListView lvWorkplaceList;
        private Gizmox.WebGUI.Forms.ColumnHeader columnLoc;
        private Gizmox.WebGUI.Forms.ColumnHeader columnInitial;
        private Gizmox.WebGUI.Forms.ColumnHeader columnRecord;
        private Gizmox.WebGUI.Forms.ColumnHeader columnWorkplaceId;
        private Gizmox.WebGUI.Forms.Button btnOk;
        private Gizmox.WebGUI.Forms.Button btnCancel;


    }
}