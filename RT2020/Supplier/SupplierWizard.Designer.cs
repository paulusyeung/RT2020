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
            this.tabAddress = new Gizmox.WebGUI.Forms.TabPage();
            this.tabContact = new Gizmox.WebGUI.Forms.TabPage();
            this.tabFinance = new Gizmox.WebGUI.Forms.TabPage();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabSupplier)).BeginInit();
            this.tabSupplier.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(122, 40);
            this.txtSupplierCode.MaxLength = 6;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(100, 20);
            this.txtSupplierCode.TabIndex = 1;
            // 
            // lblSupplierNumber
            // 
            this.lblSupplierNumber.Location = new System.Drawing.Point(19, 43);
            this.lblSupplierNumber.Name = "lblSupplierNumber";
            this.lblSupplierNumber.Size = new System.Drawing.Size(103, 23);
            this.lblSupplierNumber.TabIndex = 8;
            this.lblSupplierNumber.Text = "Supplier #:";
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
            this.tbWizardAction.Size = new System.Drawing.Size(806, 26);
            this.tbWizardAction.TabIndex = 0;
            // 
            // tabSupplier
            // 
            this.tabSupplier.Controls.Add(this.tabGeneral);
            this.tabSupplier.Controls.Add(this.tabAddress);
            this.tabSupplier.Controls.Add(this.tabContact);
            this.tabSupplier.Controls.Add(this.tabFinance);
            this.tabSupplier.Location = new System.Drawing.Point(12, 76);
            this.tabSupplier.Name = "tabSupplier";
            this.tabSupplier.SelectedIndex = 0;
            this.tabSupplier.Size = new System.Drawing.Size(785, 421);
            this.tabSupplier.TabIndex = 9;
            this.tabSupplier.SelectedIndexChanged += new System.EventHandler(this.tabSupplier_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(586, 310);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // tabAddress
            // 
            this.tabAddress.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabAddress.Location = new System.Drawing.Point(4, 22);
            this.tabAddress.Name = "tabAddress";
            this.tabAddress.Size = new System.Drawing.Size(766, 379);
            this.tabAddress.TabIndex = 1;
            this.tabAddress.Text = "Address";
            // 
            // tabContact
            // 
            this.tabContact.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabContact.Location = new System.Drawing.Point(4, 22);
            this.tabContact.Name = "tabContact";
            this.tabContact.Size = new System.Drawing.Size(766, 379);
            this.tabContact.TabIndex = 2;
            this.tabContact.Text = "Contact";
            // 
            // tabFinance
            // 
            this.tabFinance.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabFinance.Location = new System.Drawing.Point(4, 22);
            this.tabFinance.Name = "tabFinance";
            this.tabFinance.Size = new System.Drawing.Size(766, 379);
            this.tabFinance.TabIndex = 3;
            this.tabFinance.Text = "Finance";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            // 
            // SupplierWizard
            // 
            this.Controls.Add(this.tabSupplier);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblSupplierNumber);
            this.Controls.Add(this.txtSupplierCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.Text = "SupplierWizard";
            this.Load += new System.EventHandler(this.SupplierWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabSupplier)).EndInit();
            this.tabSupplier.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtSupplierCode;
        private Gizmox.WebGUI.Forms.Label lblSupplierNumber;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TabControl tabSupplier;
        private Gizmox.WebGUI.Forms.TabPage tabGeneral;
        private Gizmox.WebGUI.Forms.TabPage tabAddress;
        private Gizmox.WebGUI.Forms.TabPage tabFinance;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabPage tabContact;


    }
}