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
            this.cboAppendix1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboAppendix2 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboAppendix3 = new Gizmox.WebGUI.Forms.ComboBox();
            this.tabProduct = new Gizmox.WebGUI.Forms.TabControl();
            this.tpGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.tpBarcode = new Gizmox.WebGUI.Forms.TabPage();
            this.tpQty = new Gizmox.WebGUI.Forms.TabPage();
            this.tpMisc = new Gizmox.WebGUI.Forms.TabPage();
            this.tpOrder = new Gizmox.WebGUI.Forms.TabPage();
            this.tpDiscount = new Gizmox.WebGUI.Forms.TabPage();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
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
            this.tbWizardAction.TabStop = false;
            // 
            // lblStkCode
            // 
            this.lblStkCode.Location = new System.Drawing.Point(25, 45);
            this.lblStkCode.Name = "lblStkCode";
            this.lblStkCode.Size = new System.Drawing.Size(61, 23);
            this.lblStkCode.TabIndex = 0;
            this.lblStkCode.TabStop = false;
            this.lblStkCode.Text = "PLU:";
            // 
            // txtStkCode
            // 
            this.txtStkCode.Location = new System.Drawing.Point(70, 42);
            this.txtStkCode.MaxLength = 10;
            this.txtStkCode.Name = "txtStkCode";
            this.txtStkCode.Size = new System.Drawing.Size(100, 20);
            this.txtStkCode.TabIndex = 0;
            // 
            // lblAppendix1
            // 
            this.lblAppendix1.Location = new System.Drawing.Point(212, 45);
            this.lblAppendix1.Name = "lblAppendix1";
            this.lblAppendix1.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix1.TabIndex = 0;
            this.lblAppendix1.TabStop = false;
            this.lblAppendix1.Text = "Season:";
            // 
            // lblAppendix2
            // 
            this.lblAppendix2.Location = new System.Drawing.Point(212, 68);
            this.lblAppendix2.Name = "lblAppendix2";
            this.lblAppendix2.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix2.TabIndex = 0;
            this.lblAppendix2.TabStop = false;
            this.lblAppendix2.Text = "Color:";
            // 
            // lblAppendix3
            // 
            this.lblAppendix3.Location = new System.Drawing.Point(212, 91);
            this.lblAppendix3.Name = "lblAppendix3";
            this.lblAppendix3.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix3.TabIndex = 0;
            this.lblAppendix3.TabStop = false;
            this.lblAppendix3.Text = "Size:";
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.BackColor = System.Drawing.Color.White;
            this.cboAppendix1.DropDownWidth = 121;
            this.cboAppendix1.Location = new System.Drawing.Point(318, 41);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix1.TabIndex = 1;
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.BackColor = System.Drawing.Color.White;
            this.cboAppendix2.DropDownWidth = 121;
            this.cboAppendix2.Location = new System.Drawing.Point(318, 65);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix2.TabIndex = 2;
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.BackColor = System.Drawing.Color.White;
            this.cboAppendix3.DropDownWidth = 121;
            this.cboAppendix3.Location = new System.Drawing.Point(318, 88);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix3.TabIndex = 3;
            this.cboAppendix3.LostFocus += new System.EventHandler(this.cboAppendix3_LostFocus);
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
            this.tabProduct.Multiline = false;
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.SelectedIndex = 0;
            this.tabProduct.ShowCloseButton = false;
            this.tabProduct.Size = new System.Drawing.Size(774, 376);
            this.tabProduct.TabIndex = 4;
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
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // ProductWizard
            // 
            this.Controls.Add(this.tabProduct);
            this.Controls.Add(this.cboAppendix3);
            this.Controls.Add(this.cboAppendix2);
            this.Controls.Add(this.cboAppendix1);
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
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Label lblStkCode;
        private Gizmox.WebGUI.Forms.TextBox txtStkCode;
        private Gizmox.WebGUI.Forms.Label lblAppendix1;
        private Gizmox.WebGUI.Forms.Label lblAppendix2;
        private Gizmox.WebGUI.Forms.Label lblAppendix3;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix1;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix2;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix3;
        private Gizmox.WebGUI.Forms.TabControl tabProduct;
        private Gizmox.WebGUI.Forms.TabPage tpGeneral;
        private Gizmox.WebGUI.Forms.TabPage tpBarcode;
        private Gizmox.WebGUI.Forms.TabPage tpQty;
        private Gizmox.WebGUI.Forms.TabPage tpMisc;
        private Gizmox.WebGUI.Forms.TabPage tpOrder;
        private Gizmox.WebGUI.Forms.TabPage tpDiscount;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}