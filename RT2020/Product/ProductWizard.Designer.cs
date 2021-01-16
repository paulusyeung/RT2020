namespace RT2020.Product
{
    partial class ProductWizard
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
            this.lblStkCode = new Gizmox.WebGUI.Forms.Label();
            this.txtStkCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAppendix1 = new Gizmox.WebGUI.Forms.Label();
            this.lblAppendix2 = new Gizmox.WebGUI.Forms.Label();
            this.lblAppendix3 = new Gizmox.WebGUI.Forms.Label();
            this.tabProduct = new Gizmox.WebGUI.Forms.TabControl();
            this.tpGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.tpBarcode = new Gizmox.WebGUI.Forms.TabPage();
            this.tpQty = new Gizmox.WebGUI.Forms.TabPage();
            this.tpMisc = new Gizmox.WebGUI.Forms.TabPage();
            this.tpOrder = new Gizmox.WebGUI.Forms.TabPage();
            this.tpDiscount = new Gizmox.WebGUI.Forms.TabPage();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.cboAppendix1 = new RT2020.Components.Appendix1ComboBox();
            this.cboAppendix2 = new RT2020.Components.Appendix2ComboBox();
            this.cboAppendix3 = new RT2020.Components.Appendix3ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabProduct)).BeginInit();
            this.tabProduct.SuspendLayout();
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
            this.tbWizardAction.Size = new System.Drawing.Size(798, 26);
            this.tbWizardAction.TabIndex = 0;
            // 
            // lblStkCode
            // 
            this.lblStkCode.Location = new System.Drawing.Point(19, 39);
            this.lblStkCode.Name = "lblStkCode";
            this.lblStkCode.Size = new System.Drawing.Size(82, 23);
            this.lblStkCode.TabIndex = 1;
            this.lblStkCode.Text = "STOCKCODE:";
            // 
            // txtStkCode
            // 
            this.txtStkCode.Location = new System.Drawing.Point(101, 35);
            this.txtStkCode.MaxLength = 10;
            this.txtStkCode.Name = "txtStkCode";
            this.txtStkCode.Size = new System.Drawing.Size(100, 20);
            this.txtStkCode.TabIndex = 2;
            // 
            // lblAppendix1
            // 
            this.lblAppendix1.Location = new System.Drawing.Point(212, 39);
            this.lblAppendix1.Name = "lblAppendix1";
            this.lblAppendix1.Size = new System.Drawing.Size(100, 20);
            this.lblAppendix1.TabIndex = 3;
            this.lblAppendix1.Text = "Appendix1:";
            this.lblAppendix1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAppendix2
            // 
            this.lblAppendix2.Location = new System.Drawing.Point(212, 62);
            this.lblAppendix2.Name = "lblAppendix2";
            this.lblAppendix2.Size = new System.Drawing.Size(100, 20);
            this.lblAppendix2.TabIndex = 5;
            this.lblAppendix2.Text = "Appendix2:";
            this.lblAppendix2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAppendix3
            // 
            this.lblAppendix3.Location = new System.Drawing.Point(212, 85);
            this.lblAppendix3.Name = "lblAppendix3";
            this.lblAppendix3.Size = new System.Drawing.Size(100, 20);
            this.lblAppendix3.TabIndex = 7;
            this.lblAppendix3.Text = "Appendix3:";
            this.lblAppendix3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabProduct
            // 
            this.tabProduct.Controls.Add(this.tpGeneral);
            this.tabProduct.Controls.Add(this.tpBarcode);
            this.tabProduct.Controls.Add(this.tpQty);
            this.tabProduct.Controls.Add(this.tpMisc);
            this.tabProduct.Controls.Add(this.tpOrder);
            this.tabProduct.Controls.Add(this.tpDiscount);
            this.tabProduct.Location = new System.Drawing.Point(12, 117);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.SelectedIndex = 0;
            this.tabProduct.Size = new System.Drawing.Size(774, 376);
            this.tabProduct.TabIndex = 9;
            this.tabProduct.SelectedIndexChanged += new System.EventHandler(this.tabProduct_SelectedIndexChanged);
            // 
            // tpGeneral
            // 
            this.tpGeneral.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(766, 350);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            // 
            // tpBarcode
            // 
            this.tpBarcode.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpBarcode.Location = new System.Drawing.Point(4, 22);
            this.tpBarcode.Name = "tpBarcode";
            this.tpBarcode.Size = new System.Drawing.Size(766, 350);
            this.tpBarcode.TabIndex = 0;
            this.tpBarcode.Text = "Barcode";
            // 
            // tpQty
            // 
            this.tpQty.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpQty.Location = new System.Drawing.Point(4, 22);
            this.tpQty.Name = "tpQty";
            this.tpQty.Size = new System.Drawing.Size(766, 350);
            this.tpQty.TabIndex = 1;
            this.tpQty.Text = "Quantity";
            // 
            // tpMisc
            // 
            this.tpMisc.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpMisc.Location = new System.Drawing.Point(4, 22);
            this.tpMisc.Name = "tpMisc";
            this.tpMisc.Size = new System.Drawing.Size(766, 350);
            this.tpMisc.TabIndex = 2;
            this.tpMisc.Text = "Misc";
            // 
            // tpOrder
            // 
            this.tpOrder.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(766, 350);
            this.tpOrder.TabIndex = 3;
            this.tpOrder.Text = "Order";
            // 
            // tpDiscount
            // 
            this.tpDiscount.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpDiscount.Location = new System.Drawing.Point(4, 22);
            this.tpDiscount.Name = "tpDiscount";
            this.tpDiscount.Size = new System.Drawing.Size(766, 350);
            this.tpDiscount.TabIndex = 4;
            this.tpDiscount.Text = "Discount";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.AutoCompleteMode = Gizmox.WebGUI.Forms.AutoCompleteMode.Append;
            this.cboAppendix1.AutoCompleteSource = Gizmox.WebGUI.Forms.AutoCompleteSource.ListItems;
            this.cboAppendix1.CustomStyle = "Appendix1ComboBoxSkin";
            this.cboAppendix1.FormattingEnabled = true;
            this.cboAppendix1.Location = new System.Drawing.Point(312, 34);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(100, 21);
            this.cboAppendix1.TabIndex = 4;
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.AutoCompleteMode = Gizmox.WebGUI.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAppendix2.AutoCompleteSource = Gizmox.WebGUI.Forms.AutoCompleteSource.ListItems;
            this.cboAppendix2.CustomStyle = "Appendix2ComboBoxSkin";
            this.cboAppendix2.FormattingEnabled = true;
            this.cboAppendix2.Location = new System.Drawing.Point(312, 59);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(100, 21);
            this.cboAppendix2.TabIndex = 6;
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.AutoCompleteMode = Gizmox.WebGUI.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAppendix3.AutoCompleteSource = Gizmox.WebGUI.Forms.AutoCompleteSource.ListItems;
            this.cboAppendix3.CustomStyle = "Appendix3ComboBoxSkin";
            this.cboAppendix3.FormattingEnabled = true;
            this.cboAppendix3.Location = new System.Drawing.Point(312, 82);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(100, 21);
            this.cboAppendix3.TabIndex = 8;
            // 
            // ProductWizard
            // 
            this.Controls.Add(this.cboAppendix3);
            this.Controls.Add(this.cboAppendix2);
            this.Controls.Add(this.cboAppendix1);
            this.Controls.Add(this.tabProduct);
            this.Controls.Add(this.lblAppendix3);
            this.Controls.Add(this.lblAppendix2);
            this.Controls.Add(this.lblAppendix1);
            this.Controls.Add(this.txtStkCode);
            this.Controls.Add(this.lblStkCode);
            this.Controls.Add(this.tbWizardAction);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Wizard";
            this.Load += new System.EventHandler(this.ProductWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabProduct)).EndInit();
            this.tabProduct.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Label lblStkCode;
        private Gizmox.WebGUI.Forms.TextBox txtStkCode;
        private Gizmox.WebGUI.Forms.Label lblAppendix1;
        private Gizmox.WebGUI.Forms.Label lblAppendix2;
        private Gizmox.WebGUI.Forms.Label lblAppendix3;
        private Gizmox.WebGUI.Forms.TabControl tabProduct;
        private Gizmox.WebGUI.Forms.TabPage tpGeneral;
        private Gizmox.WebGUI.Forms.TabPage tpBarcode;
        private Gizmox.WebGUI.Forms.TabPage tpQty;
        private Gizmox.WebGUI.Forms.TabPage tpMisc;
        private Gizmox.WebGUI.Forms.TabPage tpOrder;
        private Gizmox.WebGUI.Forms.TabPage tpDiscount;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Components.Appendix1ComboBox cboAppendix1;
        private Components.Appendix2ComboBox cboAppendix2;
        private Components.Appendix3ComboBox cboAppendix3;
    }
}