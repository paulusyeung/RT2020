namespace RT2020.Client.Purchasing.Wizard
{
    partial class ReceivingFind
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
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvReceivingFindList = new System.Windows.Forms.DataGridView();
            this.colOrderHeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPONumber = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivingFindList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPONumber
            // 
            this.txtPONumber.Location = new System.Drawing.Point(138, 13);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.Size = new System.Drawing.Size(162, 20);
            this.txtPONumber.TabIndex = 0;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(138, 40);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(162, 20);
            this.txtType.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(306, 40);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.dgvReceivingFindList);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 248);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(126, 219);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // dgvReceivingFindList
            // 
            this.dgvReceivingFindList.AllowUserToAddRows = false;
            this.dgvReceivingFindList.AllowUserToDeleteRows = false;
            this.dgvReceivingFindList.AllowUserToOrderColumns = true;
            this.dgvReceivingFindList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceivingFindList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderHeaderId,
            this.colRecords,
            this.colPONumber,
            this.colType});
            this.dgvReceivingFindList.Location = new System.Drawing.Point(9, 15);
            this.dgvReceivingFindList.Name = "dgvReceivingFindList";
            this.dgvReceivingFindList.ReadOnly = true;
            this.dgvReceivingFindList.Size = new System.Drawing.Size(410, 199);
            this.dgvReceivingFindList.TabIndex = 0;
            // 
            // colOrderHeaderId
            // 
            this.colOrderHeaderId.DataPropertyName = "OrderHeaderId";
            this.colOrderHeaderId.HeaderText = "OrderHeaderId";
            this.colOrderHeaderId.Name = "colOrderHeaderId";
            this.colOrderHeaderId.ReadOnly = true;
            this.colOrderHeaderId.Visible = false;
            // 
            // colRecords
            // 
            this.colRecords.DataPropertyName = "Records";
            this.colRecords.HeaderText = "Records";
            this.colRecords.Name = "colRecords";
            this.colRecords.ReadOnly = true;
            // 
            // colPONumber
            // 
            this.colPONumber.DataPropertyName = "PONumber";
            this.colPONumber.HeaderText = "PONumber";
            this.colPONumber.Name = "colPONumber";
            this.colPONumber.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // lblPONumber
            // 
            this.lblPONumber.AutoSize = true;
            this.lblPONumber.Location = new System.Drawing.Point(67, 13);
            this.lblPONumber.Name = "lblPONumber";
            this.lblPONumber.Size = new System.Drawing.Size(62, 13);
            this.lblPONumber.TabIndex = 4;
            this.lblPONumber.Text = "PO Number";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(67, 42);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type";
            // 
            // ReceivingFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 326);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblPONumber);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtPONumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceivingFind";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReceivingFind";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivingFindList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPONumber;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.DataGridView dgvReceivingFindList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderHeaderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
    }
}