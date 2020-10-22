namespace RT2020.Product
{
    partial class ProductWizard_Batch
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.cboAppendix3 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboAppendix2 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboAppendix1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblStkCode = new Gizmox.WebGUI.Forms.Label();
            this.tpGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.tpMisc = new Gizmox.WebGUI.Forms.TabPage();
            this.tpOrder = new Gizmox.WebGUI.Forms.TabPage();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.tabProduct = new Gizmox.WebGUI.Forms.TabControl();
            this.txtStkCode = new Gizmox.WebGUI.Forms.TextBox();
            this.cboItemStatus = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblItemStatus = new Gizmox.WebGUI.Forms.Label();
            this.lnkAppendix1 = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lnkAppendix2 = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lnkAppendix3 = new Gizmox.WebGUI.Forms.LinkLabel();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.BackColor = System.Drawing.Color.White;
            this.cboAppendix3.DropDownWidth = 121;
            this.cboAppendix3.Location = new System.Drawing.Point(390, 89);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix3.TabIndex = 9;
            this.cboAppendix3.LostFocus += new System.EventHandler(this.cboAppendix3_LostFocus);
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.BackColor = System.Drawing.Color.White;
            this.cboAppendix2.DropDownWidth = 121;
            this.cboAppendix2.Location = new System.Drawing.Point(390, 66);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix2.TabIndex = 7;
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.BackColor = System.Drawing.Color.White;
            this.cboAppendix1.DropDownWidth = 121;
            this.cboAppendix1.Location = new System.Drawing.Point(390, 42);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix1.TabIndex = 5;
            // 
            // lblStkCode
            // 
            this.lblStkCode.Location = new System.Drawing.Point(25, 46);
            this.lblStkCode.Name = "lblStkCode";
            this.lblStkCode.Size = new System.Drawing.Size(61, 23);
            this.lblStkCode.TabIndex = 1;
            this.lblStkCode.Text = "PLU:";
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
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
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
            // tabProduct
            // 
            this.tabProduct.Controls.Add(this.tpGeneral);
            this.tabProduct.Controls.Add(this.tpMisc);
            this.tabProduct.Controls.Add(this.tpOrder);
            this.tabProduct.Location = new System.Drawing.Point(12, 118);
            this.tabProduct.Multiline = false;
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.SelectedIndex = 0;
            this.tabProduct.ShowCloseButton = false;
            this.tabProduct.Size = new System.Drawing.Size(774, 376);
            this.tabProduct.TabIndex = 12;
            // 
            // txtStkCode
            // 
            this.txtStkCode.Location = new System.Drawing.Point(70, 43);
            this.txtStkCode.MaxLength = 10;
            this.txtStkCode.Name = "txtStkCode";
            this.txtStkCode.Size = new System.Drawing.Size(100, 20);
            this.txtStkCode.TabIndex = 2;
            // 
            // cboItemStatus
            // 
            this.cboItemStatus.DropDownWidth = 121;
            this.cboItemStatus.Items.AddRange(new object[] {
            "HOLD",
            "POST"});
            this.cboItemStatus.Location = new System.Drawing.Point(661, 42);
            this.cboItemStatus.Name = "cboItemStatus";
            this.cboItemStatus.Size = new System.Drawing.Size(121, 21);
            this.cboItemStatus.TabIndex = 11;
            this.cboItemStatus.TabStop = false;
            // 
            // lblItemStatus
            // 
            this.lblItemStatus.Location = new System.Drawing.Point(555, 45);
            this.lblItemStatus.Name = "lblItemStatus";
            this.lblItemStatus.Size = new System.Drawing.Size(100, 23);
            this.lblItemStatus.TabIndex = 10;
            this.lblItemStatus.TabStop = false;
            this.lblItemStatus.Text = "Item Status:";
            // 
            // lnkAppendix1
            // 
            this.lnkAppendix1.Location = new System.Drawing.Point(288, 46);
            this.lnkAppendix1.Name = "lnkAppendix1";
            this.lnkAppendix1.Size = new System.Drawing.Size(96, 23);
            this.lnkAppendix1.TabIndex = 4;
            this.lnkAppendix1.TabStop = false;
            this.lnkAppendix1.Text = "Season Combin.#:";
            this.lnkAppendix1.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkAppendix_LinkClicked);
            // 
            // lnkAppendix2
            // 
            this.lnkAppendix2.Location = new System.Drawing.Point(288, 69);
            this.lnkAppendix2.Name = "lnkAppendix2";
            this.lnkAppendix2.Size = new System.Drawing.Size(96, 23);
            this.lnkAppendix2.TabIndex = 6;
            this.lnkAppendix2.TabStop = false;
            this.lnkAppendix2.Text = "Color Combin.#:";
            this.lnkAppendix2.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkAppendix_LinkClicked);
            // 
            // lnkAppendix3
            // 
            this.lnkAppendix3.Location = new System.Drawing.Point(288, 92);
            this.lnkAppendix3.Name = "lnkAppendix3";
            this.lnkAppendix3.Size = new System.Drawing.Size(96, 23);
            this.lnkAppendix3.TabIndex = 8;
            this.lnkAppendix3.TabStop = false;
            this.lnkAppendix3.Text = "Size Combin.#:";
            this.lnkAppendix3.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkAppendix_LinkClicked);
            // 
            // btnFind
            // 
            iconResourceHandle2.File = "16x16.16_find.gif";
            this.btnFind.Image = iconResourceHandle2;
            this.btnFind.Location = new System.Drawing.Point(193, 41);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(36, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.TabStop = false;
            this.btnFind.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ProductWizard_Batch
            // 
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lnkAppendix3);
            this.Controls.Add(this.lnkAppendix2);
            this.Controls.Add(this.lnkAppendix1);
            this.Controls.Add(this.lblItemStatus);
            this.Controls.Add(this.cboItemStatus);
            this.Controls.Add(this.txtStkCode);
            this.Controls.Add(this.tabProduct);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblStkCode);
            this.Controls.Add(this.cboAppendix1);
            this.Controls.Add(this.cboAppendix2);
            this.Controls.Add(this.cboAppendix3);
            this.Size = new System.Drawing.Size(798, 500);
            this.Text = "ProductWizard_Batch";
            this.Load += new System.EventHandler(this.ProductWizard_Batch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox cboAppendix3;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix2;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix1;
        private Gizmox.WebGUI.Forms.Label lblStkCode;
        private Gizmox.WebGUI.Forms.TabPage tpGeneral;
        private Gizmox.WebGUI.Forms.TabPage tpMisc;
        private Gizmox.WebGUI.Forms.TabPage tpOrder;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TabControl tabProduct;
        private Gizmox.WebGUI.Forms.TextBox txtStkCode;
        private Gizmox.WebGUI.Forms.ComboBox cboItemStatus;
        private Gizmox.WebGUI.Forms.Label lblItemStatus;
        private Gizmox.WebGUI.Forms.LinkLabel lnkAppendix1;
        private Gizmox.WebGUI.Forms.LinkLabel lnkAppendix2;
        private Gizmox.WebGUI.Forms.LinkLabel lnkAppendix3;
        private Gizmox.WebGUI.Forms.Button btnFind;


    }
}