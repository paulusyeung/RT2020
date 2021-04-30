namespace RT2020.PriceMgmt
{
    partial class ReasonCodeWizard
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
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.txtNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblName = new Gizmox.WebGUI.Forms.Label();
            this.lblCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.mainPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.ButtonSize = new System.Drawing.Size(24, 24);
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = true;
            this.tbWizardAction.ImageSize = new System.Drawing.Size(16, 16);
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.Size = new System.Drawing.Size(419, 30);
            this.tbWizardAction.TabIndex = 0;
            // 
            // mainPane
            // 
            this.mainPane.Controls.Add(this.txtNameAlt2);
            this.mainPane.Controls.Add(this.txtNameAlt1);
            this.mainPane.Controls.Add(this.txtName);
            this.mainPane.Controls.Add(this.txtCode);
            this.mainPane.Controls.Add(this.lblNameAlt2);
            this.mainPane.Controls.Add(this.lblNameAlt1);
            this.mainPane.Controls.Add(this.lblName);
            this.mainPane.Controls.Add(this.lblCode);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 30);
            this.mainPane.Name = "mainPane";
            this.mainPane.Padding = new Gizmox.WebGUI.Forms.Padding(6);
            this.mainPane.Size = new System.Drawing.Size(419, 436);
            this.mainPane.TabIndex = 1;
            // 
            // txtNameAlt2
            // 
            this.txtNameAlt2.Location = new System.Drawing.Point(139, 98);
            this.txtNameAlt2.Name = "txtNameAlt2";
            this.txtNameAlt2.Size = new System.Drawing.Size(189, 20);
            this.txtNameAlt2.TabIndex = 7;
            // 
            // txtNameAlt1
            // 
            this.txtNameAlt1.Location = new System.Drawing.Point(139, 72);
            this.txtNameAlt1.Name = "txtNameAlt1";
            this.txtNameAlt1.Size = new System.Drawing.Size(189, 20);
            this.txtNameAlt1.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(139, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(189, 20);
            this.txtName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(139, 20);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 4;
            // 
            // lblNameAlt2
            // 
            this.lblNameAlt2.Location = new System.Drawing.Point(35, 101);
            this.lblNameAlt2.Name = "lblNameAlt2";
            this.lblNameAlt2.Size = new System.Drawing.Size(101, 23);
            this.lblNameAlt2.TabIndex = 3;
            this.lblNameAlt2.Text = "Reason Name (Cht):";
            // 
            // lblNameAlt1
            // 
            this.lblNameAlt1.Location = new System.Drawing.Point(35, 75);
            this.lblNameAlt1.Name = "lblNameAlt1";
            this.lblNameAlt1.Size = new System.Drawing.Size(101, 23);
            this.lblNameAlt1.TabIndex = 2;
            this.lblNameAlt1.Text = "Reason Name (Chs):";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(22, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(111, 23);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Reason Name : ";
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(22, 23);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(111, 23);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Reason Code : ";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // ReasonCodeWizard
            // 
            this.Controls.Add(this.mainPane);
            this.Controls.Add(this.tbWizardAction);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "Reason Code Maintenance";
            this.Load += new System.EventHandler(this.ReasonCodeWizard_Load);
            this.mainPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.Label lblNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblName;
        private Gizmox.WebGUI.Forms.Label lblCode;
        private Gizmox.WebGUI.Forms.TextBox txtNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtName;
        private Gizmox.WebGUI.Forms.TextBox txtCode;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}