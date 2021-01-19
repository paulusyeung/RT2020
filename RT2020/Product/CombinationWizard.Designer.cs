namespace RT2020.Product
{
    partial class CombinationWizard
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
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtCombinNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCombinNumber = new Gizmox.WebGUI.Forms.Label();
            this.dgvCombinationList = new Gizmox.WebGUI.Forms.DataGridView();
            this.gbSelection = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnDelete = new Gizmox.WebGUI.Forms.Button();
            this.btnDeleteAll = new Gizmox.WebGUI.Forms.Button();
            this.btnAdd = new Gizmox.WebGUI.Forms.Button();
            this.cboAppendix3 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboAppendix2 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboAppendix1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtRowNum = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRowNum = new Gizmox.WebGUI.Forms.Label();
            this.lblAppendix3 = new Gizmox.WebGUI.Forms.Label();
            this.lblAppendix2 = new Gizmox.WebGUI.Forms.Label();
            this.lblAppendix1 = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinationList)).BeginInit();
            this.gbSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.ButtonSize = new System.Drawing.Size(20, 20);
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = true;
            this.tbWizardAction.ImageSize = new System.Drawing.Size(16, 16);
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.Size = new System.Drawing.Size(800, 26);
            this.tbWizardAction.TabIndex = 0;
            // 
            // txtCombinNumber
            // 
            this.txtCombinNumber.Location = new System.Drawing.Point(112, 20);
            this.txtCombinNumber.MaxLength = 10;
            this.txtCombinNumber.Name = "txtCombinNumber";
            this.txtCombinNumber.Size = new System.Drawing.Size(100, 20);
            this.txtCombinNumber.TabIndex = 1;
            // 
            // lblCombinNumber
            // 
            this.lblCombinNumber.Location = new System.Drawing.Point(19, 23);
            this.lblCombinNumber.Name = "lblCombinNumber";
            this.lblCombinNumber.Size = new System.Drawing.Size(90, 20);
            this.lblCombinNumber.TabIndex = 0;
            this.lblCombinNumber.Text = "Combination #:";
            // 
            // dgvCombinationList
            // 
            this.dgvCombinationList.AllowUserToAddRows = false;
            this.dgvCombinationList.AllowUserToDeleteRows = false;
            this.dgvCombinationList.Location = new System.Drawing.Point(48, 49);
            this.dgvCombinationList.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.dgvCombinationList.Name = "dgvCombinationList";
            this.dgvCombinationList.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCombinationList.Size = new System.Drawing.Size(400, 338);
            this.dgvCombinationList.TabIndex = 0;
            this.dgvCombinationList.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvCombinationList_CellClick);
            // 
            // gbSelection
            // 
            this.gbSelection.Controls.Add(this.txtCombinNumber);
            this.gbSelection.Controls.Add(this.lblCombinNumber);
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
            this.gbSelection.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.gbSelection.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbSelection.Location = new System.Drawing.Point(555, 26);
            this.gbSelection.Margin = new Gizmox.WebGUI.Forms.Padding(10, 3, 10, 10);
            this.gbSelection.Name = "gbSelection";
            this.gbSelection.Size = new System.Drawing.Size(230, 424);
            this.gbSelection.TabIndex = 3;
            this.gbSelection.TabStop = false;
            this.gbSelection.Text = "Selection";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(137, 186);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(137, 160);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 9;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(137, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix3.DropDownWidth = 135;
            this.cboAppendix3.Location = new System.Drawing.Point(112, 89);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(100, 21);
            this.cboAppendix3.TabIndex = 7;
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix2.DropDownWidth = 135;
            this.cboAppendix2.Location = new System.Drawing.Point(112, 66);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(100, 21);
            this.cboAppendix2.TabIndex = 6;
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix1.DropDownWidth = 135;
            this.cboAppendix1.Location = new System.Drawing.Point(112, 43);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(100, 21);
            this.cboAppendix1.TabIndex = 5;
            // 
            // txtRowNum
            // 
            this.txtRowNum.Location = new System.Drawing.Point(92, 188);
            this.txtRowNum.Name = "txtRowNum";
            this.txtRowNum.Size = new System.Drawing.Size(39, 20);
            this.txtRowNum.TabIndex = 4;
            // 
            // lblRowNum
            // 
            this.lblRowNum.Location = new System.Drawing.Point(45, 191);
            this.lblRowNum.Name = "lblRowNum";
            this.lblRowNum.Size = new System.Drawing.Size(44, 23);
            this.lblRowNum.TabIndex = 3;
            this.lblRowNum.Text = "Row#";
            this.lblRowNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAppendix3
            // 
            this.lblAppendix3.Location = new System.Drawing.Point(19, 92);
            this.lblAppendix3.Name = "lblAppendix3";
            this.lblAppendix3.Size = new System.Drawing.Size(90, 20);
            this.lblAppendix3.TabIndex = 2;
            this.lblAppendix3.Text = "APPENDIX3";
            // 
            // lblAppendix2
            // 
            this.lblAppendix2.Location = new System.Drawing.Point(19, 69);
            this.lblAppendix2.Name = "lblAppendix2";
            this.lblAppendix2.Size = new System.Drawing.Size(90, 20);
            this.lblAppendix2.TabIndex = 1;
            this.lblAppendix2.Text = "APPENDIX2";
            // 
            // lblAppendix1
            // 
            this.lblAppendix1.Location = new System.Drawing.Point(19, 46);
            this.lblAppendix1.Name = "lblAppendix1";
            this.lblAppendix1.Size = new System.Drawing.Size(90, 20);
            this.lblAppendix1.TabIndex = 0;
            this.lblAppendix1.Text = "APPENDIX1";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // CombinationWizard
            // 
            this.Controls.Add(this.dgvCombinationList);
            this.Controls.Add(this.gbSelection);
            this.Controls.Add(this.tbWizardAction);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(800, 450);
            this.Text = "Product Wizard [Combination]";
            this.Load += new System.EventHandler(this.CombinationWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinationList)).EndInit();
            this.gbSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TextBox txtCombinNumber;
        private Gizmox.WebGUI.Forms.Label lblCombinNumber;
        private Gizmox.WebGUI.Forms.GroupBox gbSelection;
        private Gizmox.WebGUI.Forms.Button btnDelete;
        private Gizmox.WebGUI.Forms.Button btnDeleteAll;
        private Gizmox.WebGUI.Forms.Button btnAdd;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix3;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix2;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix1;
        private Gizmox.WebGUI.Forms.TextBox txtRowNum;
        private Gizmox.WebGUI.Forms.Label lblRowNum;
        private Gizmox.WebGUI.Forms.Label lblAppendix3;
        private Gizmox.WebGUI.Forms.Label lblAppendix2;
        private Gizmox.WebGUI.Forms.Label lblAppendix1;
        private Gizmox.WebGUI.Forms.DataGridView dgvCombinationList;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}