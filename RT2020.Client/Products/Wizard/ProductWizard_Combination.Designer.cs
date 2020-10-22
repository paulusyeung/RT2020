namespace RT2020.Client.Products .Wizard
{
    partial class ProductWizard_Combination
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
            this.components = new System.ComponentModel.Container();
            this.gbCombinationNumber = new System.Windows.Forms.GroupBox();
            this.txtCombinNumber = new System.Windows.Forms.TextBox();
            this.lblCombinNumber = new System.Windows.Forms.Label();
            this.gbCombinationList = new System.Windows.Forms.GroupBox();
            this.dgvCombinationList = new System.Windows.Forms.DataGridView();
            this.gbSelection = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboAppendix3 = new System.Windows.Forms.ComboBox();
            this.cboAppendix2 = new System.Windows.Forms.ComboBox();
            this.cboAppendix1 = new System.Windows.Forms.ComboBox();
            this.txtRowNum = new System.Windows.Forms.TextBox();
            this.lblRowNum = new System.Windows.Forms.Label();
            this.lblAppendix3 = new System.Windows.Forms.Label();
            this.lblAppendix2 = new System.Windows.Forms.Label();
            this.lblAppendix1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.wspDetails.SuspendLayout();
            this.wspHeader.SuspendLayout();
            this.gbCombinationNumber.SuspendLayout();
            this.gbCombinationList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinationList)).BeginInit();
            this.gbSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // wspDetails
            // 
            this.wspDetails.BackColor = System.Drawing.SystemColors.Control;
            this.wspDetails.Controls.Add(this.gbSelection);
            this.wspDetails.Controls.Add(this.gbCombinationList);
            this.wspDetails.Location = new System.Drawing.Point(10, 65);
            this.wspDetails.Padding = new System.Windows.Forms.Padding(6);
            this.wspDetails.Size = new System.Drawing.Size(669, 424);
            // 
            // wspStatus
            // 
            this.wspStatus.Location = new System.Drawing.Point(10, 489);
            this.wspStatus.Size = new System.Drawing.Size(669, 0);
            // 
            // wspHeader
            // 
            this.wspHeader.BackColor = System.Drawing.SystemColors.Control;
            this.wspHeader.Controls.Add(this.gbCombinationNumber);
            this.wspHeader.Padding = new System.Windows.Forms.Padding(6);
            this.wspHeader.Size = new System.Drawing.Size(669, 55);
            // 
            // gbCombinationNumber
            // 
            this.gbCombinationNumber.BackColor = System.Drawing.SystemColors.Control;
            this.gbCombinationNumber.Controls.Add(this.txtCombinNumber);
            this.gbCombinationNumber.Controls.Add(this.lblCombinNumber);
            this.gbCombinationNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCombinationNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbCombinationNumber.Location = new System.Drawing.Point(6, 6);
            this.gbCombinationNumber.Name = "gbCombinationNumber";
            this.gbCombinationNumber.Size = new System.Drawing.Size(657, 43);
            this.gbCombinationNumber.TabIndex = 1;
            this.gbCombinationNumber.TabStop = false;
            // 
            // txtCombinNumber
            // 
            this.txtCombinNumber.Location = new System.Drawing.Point(108, 13);
            this.txtCombinNumber.MaxLength = 10;
            this.txtCombinNumber.Name = "txtCombinNumber";
            this.txtCombinNumber.Size = new System.Drawing.Size(100, 20);
            this.txtCombinNumber.TabIndex = 1;
            // 
            // lblCombinNumber
            // 
            this.lblCombinNumber.Location = new System.Drawing.Point(30, 16);
            this.lblCombinNumber.Name = "lblCombinNumber";
            this.lblCombinNumber.Size = new System.Drawing.Size(72, 23);
            this.lblCombinNumber.TabIndex = 0;
            this.lblCombinNumber.Text = "Combin.#:";
            // 
            // gbCombinationList
            // 
            this.gbCombinationList.BackColor = System.Drawing.SystemColors.Control;
            this.gbCombinationList.Controls.Add(this.dgvCombinationList);
            this.gbCombinationList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbCombinationList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbCombinationList.Location = new System.Drawing.Point(6, 6);
            this.gbCombinationList.Name = "gbCombinationList";
            this.gbCombinationList.Size = new System.Drawing.Size(425, 412);
            this.gbCombinationList.TabIndex = 2;
            this.gbCombinationList.TabStop = false;
            // 
            // dgvCombinationList
            // 
            this.dgvCombinationList.AllowUserToAddRows = false;
            this.dgvCombinationList.AllowUserToDeleteRows = false;
            this.dgvCombinationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCombinationList.Location = new System.Drawing.Point(3, 16);
            this.dgvCombinationList.Name = "dgvCombinationList";
            this.dgvCombinationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCombinationList.Size = new System.Drawing.Size(419, 393);
            this.dgvCombinationList.TabIndex = 0;
            this.dgvCombinationList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCombinationList_CellClick);
            // 
            // gbSelection
            // 
            this.gbSelection.BackColor = System.Drawing.SystemColors.Control;
            this.gbSelection.Controls.Add(this.btnDelete);
            this.gbSelection.Controls.Add(this.btnDeleteAll);
            this.gbSelection.Controls.Add(this.btnAdd);
            this.gbSelection.Controls.Add(this.cboAppendix3);
            this.gbSelection.Controls.Add(this.cboAppendix2);
            this.gbSelection.Controls.Add(this.cboAppendix1);
            this.gbSelection.Controls.Add(this.txtRowNum);
            this.gbSelection.Controls.Add(this.lblRowNum);
            this.gbSelection.Controls.Add(this.lblAppendix3);
            this.gbSelection.Controls.Add(this.lblAppendix2);
            this.gbSelection.Controls.Add(this.lblAppendix1);
            this.gbSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbSelection.Location = new System.Drawing.Point(431, 6);
            this.gbSelection.Name = "gbSelection";
            this.gbSelection.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.gbSelection.Size = new System.Drawing.Size(232, 412);
            this.gbSelection.TabIndex = 3;
            this.gbSelection.TabStop = false;
            this.gbSelection.Text = "Selection";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(151, 377);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(151, 351);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 9;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(151, 325);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.DropDownWidth = 135;
            this.cboAppendix3.Location = new System.Drawing.Point(91, 65);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(135, 21);
            this.cboAppendix3.TabIndex = 7;
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.DropDownWidth = 135;
            this.cboAppendix2.Location = new System.Drawing.Point(91, 42);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(135, 21);
            this.cboAppendix2.TabIndex = 6;
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.DropDownWidth = 135;
            this.cboAppendix1.Location = new System.Drawing.Point(91, 19);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(135, 21);
            this.cboAppendix1.TabIndex = 5;
            // 
            // txtRowNum
            // 
            this.txtRowNum.Location = new System.Drawing.Point(75, 379);
            this.txtRowNum.Name = "txtRowNum";
            this.txtRowNum.Size = new System.Drawing.Size(70, 20);
            this.txtRowNum.TabIndex = 4;
            // 
            // lblRowNum
            // 
            this.lblRowNum.Location = new System.Drawing.Point(28, 382);
            this.lblRowNum.Name = "lblRowNum";
            this.lblRowNum.Size = new System.Drawing.Size(41, 23);
            this.lblRowNum.TabIndex = 3;
            this.lblRowNum.Text = "Row#";
            // 
            // lblAppendix3
            // 
            this.lblAppendix3.Location = new System.Drawing.Point(9, 68);
            this.lblAppendix3.Name = "lblAppendix3";
            this.lblAppendix3.Size = new System.Drawing.Size(76, 23);
            this.lblAppendix3.TabIndex = 2;
            this.lblAppendix3.Text = "APPENDIX3";
            this.lblAppendix3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAppendix2
            // 
            this.lblAppendix2.Location = new System.Drawing.Point(9, 45);
            this.lblAppendix2.Name = "lblAppendix2";
            this.lblAppendix2.Size = new System.Drawing.Size(76, 23);
            this.lblAppendix2.TabIndex = 1;
            this.lblAppendix2.Text = "APPENDIX2";
            this.lblAppendix2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAppendix1
            // 
            this.lblAppendix1.Location = new System.Drawing.Point(9, 22);
            this.lblAppendix1.Name = "lblAppendix1";
            this.lblAppendix1.Size = new System.Drawing.Size(76, 23);
            this.lblAppendix1.TabIndex = 0;
            this.lblAppendix1.Text = "APPENDIX1";
            this.lblAppendix1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // ProductWizard_Combination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(689, 524);
            this.Name = "ProductWizard_Combination";
            this.Text = "Product Wizard [Combination]";
            this.wspDetails.ResumeLayout(false);
            this.wspHeader.ResumeLayout(false);
            this.gbCombinationNumber.ResumeLayout(false);
            this.gbCombinationNumber.PerformLayout();
            this.gbCombinationList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinationList)).EndInit();
            this.gbSelection.ResumeLayout(false);
            this.gbSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCombinationNumber;
        private System.Windows.Forms.TextBox txtCombinNumber;
        private System.Windows.Forms.Label lblCombinNumber;
        private System.Windows.Forms.GroupBox gbCombinationList;
        private System.Windows.Forms.GroupBox gbSelection;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboAppendix3;
        private System.Windows.Forms.ComboBox cboAppendix2;
        private System.Windows.Forms.ComboBox cboAppendix1;
        private System.Windows.Forms.TextBox txtRowNum;
        private System.Windows.Forms.Label lblRowNum;
        private System.Windows.Forms.Label lblAppendix3;
        private System.Windows.Forms.Label lblAppendix2;
        private System.Windows.Forms.Label lblAppendix1;
        private System.Windows.Forms.DataGridView dgvCombinationList;
        private System.Windows.Forms.ErrorProvider errorProvider;


    }
}