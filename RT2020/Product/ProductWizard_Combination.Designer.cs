namespace RT2020.Product
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
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.gbCombinationNumber = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtCombinNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCombinNumber = new Gizmox.WebGUI.Forms.Label();
            this.gbCombinationList = new Gizmox.WebGUI.Forms.GroupBox();
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
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinationList)).BeginInit();
            this.SuspendLayout();
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 0;
            // 
            // gbCombinationNumber
            // 
            this.gbCombinationNumber.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbCombinationNumber.Controls.Add(this.txtCombinNumber);
            this.gbCombinationNumber.Controls.Add(this.lblCombinNumber);
            this.gbCombinationNumber.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.gbCombinationNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.gbCombinationNumber.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbCombinationNumber.Location = new System.Drawing.Point(0, 28);
            this.gbCombinationNumber.Name = "gbCombinationNumber";
            this.gbCombinationNumber.Size = new System.Drawing.Size(681, 41);
            this.gbCombinationNumber.TabIndex = 1;
            // 
            // txtCombinNumber
            // 
            this.txtCombinNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCombinNumber.Location = new System.Drawing.Point(108, 13);
            this.txtCombinNumber.MaxLength = 10;
            this.txtCombinNumber.Name = "txtCombinNumber";
            this.txtCombinNumber.Size = new System.Drawing.Size(100, 20);
            this.txtCombinNumber.TabIndex = 1;
            // 
            // lblCombinNumber
            // 
            this.lblCombinNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCombinNumber.Location = new System.Drawing.Point(30, 16);
            this.lblCombinNumber.Name = "lblCombinNumber";
            this.lblCombinNumber.Size = new System.Drawing.Size(72, 23);
            this.lblCombinNumber.TabIndex = 0;
            this.lblCombinNumber.Text = "Combin.#:";
            // 
            // gbCombinationList
            // 
            this.gbCombinationList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbCombinationList.Controls.Add(this.dgvCombinationList);
            this.gbCombinationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.gbCombinationList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.gbCombinationList.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbCombinationList.Location = new System.Drawing.Point(0, 69);
            this.gbCombinationList.Name = "gbCombinationList";
            this.gbCombinationList.Size = new System.Drawing.Size(425, 411);
            this.gbCombinationList.TabIndex = 2;
            // 
            // dgvCombinationList
            // 
            this.dgvCombinationList.AllowUserToAddRows = false;
            this.dgvCombinationList.AllowUserToDeleteRows = false;
            this.dgvCombinationList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.dgvCombinationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvCombinationList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dgvCombinationList.Location = new System.Drawing.Point(3, 16);
            this.dgvCombinationList.Name = "dgvCombinationList";
            this.dgvCombinationList.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCombinationList.Size = new System.Drawing.Size(419, 392);
            this.dgvCombinationList.TabIndex = 0;
            this.dgvCombinationList.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvCombinationList_CellClick);
            // 
            // gbSelection
            // 
            this.gbSelection.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
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
            this.gbSelection.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.gbSelection.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbSelection.Location = new System.Drawing.Point(431, 69);
            this.gbSelection.Name = "gbSelection";
            this.gbSelection.Size = new System.Drawing.Size(250, 411);
            this.gbSelection.TabIndex = 3;
            this.gbSelection.Text = "Selection";
            // 
            // btnDelete
            // 
            this.btnDelete.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnDelete.Location = new System.Drawing.Point(163, 377);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnDeleteAll.Location = new System.Drawing.Point(163, 351);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 9;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnAdd.Location = new System.Drawing.Point(163, 325);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboAppendix3.DropDownWidth = 135;
            this.cboAppendix3.Location = new System.Drawing.Point(101, 59);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(135, 21);
            this.cboAppendix3.TabIndex = 7;
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboAppendix2.DropDownWidth = 135;
            this.cboAppendix2.Location = new System.Drawing.Point(101, 36);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(135, 21);
            this.cboAppendix2.TabIndex = 6;
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboAppendix1.DropDownWidth = 135;
            this.cboAppendix1.Location = new System.Drawing.Point(101, 13);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(135, 21);
            this.cboAppendix1.TabIndex = 5;
            // 
            // txtRowNum
            // 
            this.txtRowNum.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtRowNum.Location = new System.Drawing.Point(87, 379);
            this.txtRowNum.Name = "txtRowNum";
            this.txtRowNum.Size = new System.Drawing.Size(70, 20);
            this.txtRowNum.TabIndex = 4;
            // 
            // lblRowNum
            // 
            this.lblRowNum.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblRowNum.Location = new System.Drawing.Point(40, 382);
            this.lblRowNum.Name = "lblRowNum";
            this.lblRowNum.Size = new System.Drawing.Size(41, 23);
            this.lblRowNum.TabIndex = 3;
            this.lblRowNum.Text = "Row#";
            // 
            // lblAppendix3
            // 
            this.lblAppendix3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAppendix3.Location = new System.Drawing.Point(19, 62);
            this.lblAppendix3.Name = "lblAppendix3";
            this.lblAppendix3.Size = new System.Drawing.Size(76, 23);
            this.lblAppendix3.TabIndex = 2;
            this.lblAppendix3.Text = "APPENDIX3";
            this.lblAppendix3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAppendix2
            // 
            this.lblAppendix2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAppendix2.Location = new System.Drawing.Point(19, 39);
            this.lblAppendix2.Name = "lblAppendix2";
            this.lblAppendix2.Size = new System.Drawing.Size(76, 23);
            this.lblAppendix2.TabIndex = 1;
            this.lblAppendix2.Text = "APPENDIX2";
            this.lblAppendix2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAppendix1
            // 
            this.lblAppendix1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAppendix1.Location = new System.Drawing.Point(19, 16);
            this.lblAppendix1.Name = "lblAppendix1";
            this.lblAppendix1.Size = new System.Drawing.Size(76, 23);
            this.lblAppendix1.TabIndex = 0;
            this.lblAppendix1.Text = "APPENDIX1";
            this.lblAppendix1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // ProductWizard_Combination
            // 
            this.Controls.Add(this.gbSelection);
            this.Controls.Add(this.gbCombinationList);
            this.Controls.Add(this.gbCombinationNumber);
            this.Controls.Add(this.tbWizardAction);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(681, 480);
            this.Text = "Product Wizard [Combination]";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinationList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.GroupBox gbCombinationNumber;
        private Gizmox.WebGUI.Forms.TextBox txtCombinNumber;
        private Gizmox.WebGUI.Forms.Label lblCombinNumber;
        private Gizmox.WebGUI.Forms.GroupBox gbCombinationList;
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