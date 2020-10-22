namespace RT2020.Supplier
{
    partial class SupplierWizard
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
            this.txtSupplierCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSupplierNumber = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.tabSupplier = new Gizmox.WebGUI.Forms.TabControl();
            this.tabGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.tabPersonal = new Gizmox.WebGUI.Forms.TabPage();
            this.tabContact = new Gizmox.WebGUI.Forms.TabPage();
            this.tabFinancial = new Gizmox.WebGUI.Forms.TabPage();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(101, 40);
            this.txtSupplierCode.MaxLength = 6;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(100, 20);
            this.txtSupplierCode.TabIndex = 1;
            // 
            // lblSupplierNumber
            // 
            this.lblSupplierNumber.Location = new System.Drawing.Point(34, 43);
            this.lblSupplierNumber.Name = "lblSupplierNumber";
            this.lblSupplierNumber.Size = new System.Drawing.Size(61, 23);
            this.lblSupplierNumber.TabIndex = 8;
            this.lblSupplierNumber.Text = "Supplier #:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 0;
            // 
            // tabSupplier
            // 
            this.tabSupplier.Controls.Add(this.tabGeneral);
            this.tabSupplier.Controls.Add(this.tabPersonal);
            this.tabSupplier.Controls.Add(this.tabContact);
            this.tabSupplier.Controls.Add(this.tabFinancial);
            this.tabSupplier.Location = new System.Drawing.Point(12, 83);
            this.tabSupplier.Multiline = false;
            this.tabSupplier.Name = "tabSupplier";
            this.tabSupplier.SelectedIndex = 0;
            this.tabSupplier.ShowCloseButton = false;
            this.tabSupplier.Size = new System.Drawing.Size(774, 405);
            this.tabSupplier.TabIndex = 9;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(766, 379);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // tabPersonal
            // 
            this.tabPersonal.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPersonal.Location = new System.Drawing.Point(4, 22);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Size = new System.Drawing.Size(766, 379);
            this.tabPersonal.TabIndex = 0;
            this.tabPersonal.Text = "Personal";
            // 
            // tabContact
            // 
            this.tabContact.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabContact.Location = new System.Drawing.Point(4, 22);
            this.tabContact.Name = "tabContact";
            this.tabContact.Size = new System.Drawing.Size(766, 379);
            this.tabContact.TabIndex = 2;
            this.tabContact.Text = "Contact";
            this.tabContact.Visible = false;
            // 
            // tabFinancial
            // 
            this.tabFinancial.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabFinancial.Location = new System.Drawing.Point(4, 22);
            this.tabFinancial.Name = "tabFinancial";
            this.tabFinancial.Size = new System.Drawing.Size(766, 379);
            this.tabFinancial.TabIndex = 1;
            this.tabFinancial.Text = "Financial";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // SupplierWizard
            // 
            this.Controls.Add(this.tabSupplier);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblSupplierNumber);
            this.Controls.Add(this.txtSupplierCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.Text = "SupplierWizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtSupplierCode;
        private Gizmox.WebGUI.Forms.Label lblSupplierNumber;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TabControl tabSupplier;
        private Gizmox.WebGUI.Forms.TabPage tabGeneral;
        private Gizmox.WebGUI.Forms.TabPage tabPersonal;
        private Gizmox.WebGUI.Forms.TabPage tabFinancial;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabPage tabContact;


    }
}