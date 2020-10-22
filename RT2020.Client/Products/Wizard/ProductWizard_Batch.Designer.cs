namespace RT2020.Client.Products .Wizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductWizard_Batch));
            this.cboAppendix3 = new System.Windows.Forms.ComboBox();
            this.cboAppendix2 = new System.Windows.Forms.ComboBox();
            this.cboAppendix1 = new System.Windows.Forms.ComboBox();
            this.lblStkCode = new System.Windows.Forms.Label();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tpMisc = new System.Windows.Forms.TabPage();
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabProduct = new System.Windows.Forms.TabControl();
            this.txtStkCode = new System.Windows.Forms.TextBox();
            this.cboItemStatus = new System.Windows.Forms.ComboBox();
            this.lblItemStatus = new System.Windows.Forms.Label();
            this.lnkAppendix1 = new System.Windows.Forms.LinkLabel();
            this.lnkAppendix2 = new System.Windows.Forms.LinkLabel();
            this.lnkAppendix3 = new System.Windows.Forms.LinkLabel();
            this.btnFind = new System.Windows.Forms.Button();
            this.wspDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // wspDetails
            // 
            this.wspDetails.BackColor = System.Drawing.SystemColors.Control;
            this.wspDetails.Controls.Add(this.tabProduct);
            this.wspDetails.Location = new System.Drawing.Point(10, 95);
            this.wspDetails.Size = new System.Drawing.Size(818, 407);
            // 
            // wspStatus
            // 
            this.wspStatus.Location = new System.Drawing.Point(10, 502);
            this.wspStatus.Size = new System.Drawing.Size(818, 0);
            // 
            // wspHeader
            // 
            this.wspHeader.BackColor = System.Drawing.SystemColors.Control;
            this.wspHeader.Size = new System.Drawing.Size(818, 85);
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.BackColor = System.Drawing.Color.White;
            this.cboAppendix3.DropDownWidth = 121;
            this.cboAppendix3.Location = new System.Drawing.Point(390, 89);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix3.TabIndex = 10;
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.BackColor = System.Drawing.Color.White;
            this.cboAppendix2.DropDownWidth = 121;
            this.cboAppendix2.Location = new System.Drawing.Point(390, 66);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix2.TabIndex = 8;
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.BackColor = System.Drawing.Color.White;
            this.cboAppendix1.DropDownWidth = 121;
            this.cboAppendix1.Location = new System.Drawing.Point(390, 42);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix1.TabIndex = 6;
            // 
            // lblStkCode
            // 
            this.lblStkCode.BackColor = System.Drawing.SystemColors.Control;
            this.lblStkCode.Location = new System.Drawing.Point(25, 46);
            this.lblStkCode.Name = "lblStkCode";
            this.lblStkCode.Size = new System.Drawing.Size(61, 23);
            this.lblStkCode.TabIndex = 2;
            this.lblStkCode.Text = "PLU:";
            // 
            // tpGeneral
            // 
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(810, 378);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            // 
            // tpMisc
            // 
            this.tpMisc.Location = new System.Drawing.Point(4, 22);
            this.tpMisc.Name = "tpMisc";
            this.tpMisc.Size = new System.Drawing.Size(766, 409);
            this.tpMisc.TabIndex = 2;
            this.tpMisc.Text = "Misc";
            // 
            // tpOrder
            // 
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(766, 409);
            this.tpOrder.TabIndex = 3;
            this.tpOrder.Text = "Order";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // tabProduct
            // 
            this.tabProduct.Controls.Add(this.tpGeneral);
            this.tabProduct.Controls.Add(this.tpMisc);
            this.tabProduct.Controls.Add(this.tpOrder);
            this.tabProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProduct.Location = new System.Drawing.Point(0, 0);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.SelectedIndex = 0;
            this.tabProduct.Size = new System.Drawing.Size(818, 404);
            this.tabProduct.TabIndex = 0;
            // 
            // txtStkCode
            // 
            this.txtStkCode.Location = new System.Drawing.Point(70, 43);
            this.txtStkCode.MaxLength = 10;
            this.txtStkCode.Name = "txtStkCode";
            this.txtStkCode.Size = new System.Drawing.Size(100, 20);
            this.txtStkCode.TabIndex = 3;
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
            this.cboItemStatus.TabIndex = 12;
            // 
            // lblItemStatus
            // 
            this.lblItemStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblItemStatus.Location = new System.Drawing.Point(555, 45);
            this.lblItemStatus.Name = "lblItemStatus";
            this.lblItemStatus.Size = new System.Drawing.Size(100, 23);
            this.lblItemStatus.TabIndex = 11;
            this.lblItemStatus.Text = "Item Status:";
            // 
            // lnkAppendix1
            // 
            this.lnkAppendix1.BackColor = System.Drawing.SystemColors.Control;
            this.lnkAppendix1.Location = new System.Drawing.Point(288, 46);
            this.lnkAppendix1.Name = "lnkAppendix1";
            this.lnkAppendix1.Size = new System.Drawing.Size(96, 23);
            this.lnkAppendix1.TabIndex = 5;
            this.lnkAppendix1.TabStop = true;
            this.lnkAppendix1.Text = "Season Combin.#:";
            this.lnkAppendix1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAppendix_LinkClicked);
            // 
            // lnkAppendix2
            // 
            this.lnkAppendix2.BackColor = System.Drawing.SystemColors.Control;
            this.lnkAppendix2.Location = new System.Drawing.Point(288, 69);
            this.lnkAppendix2.Name = "lnkAppendix2";
            this.lnkAppendix2.Size = new System.Drawing.Size(96, 23);
            this.lnkAppendix2.TabIndex = 7;
            this.lnkAppendix2.TabStop = true;
            this.lnkAppendix2.Text = "Color Combin.#:";
            this.lnkAppendix2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAppendix_LinkClicked);
            // 
            // lnkAppendix3
            // 
            this.lnkAppendix3.BackColor = System.Drawing.SystemColors.Control;
            this.lnkAppendix3.Location = new System.Drawing.Point(288, 92);
            this.lnkAppendix3.Name = "lnkAppendix3";
            this.lnkAppendix3.Size = new System.Drawing.Size(96, 23);
            this.lnkAppendix3.TabIndex = 9;
            this.lnkAppendix3.TabStop = true;
            this.lnkAppendix3.Text = "Size Combin.#:";
            this.lnkAppendix3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAppendix_LinkClicked);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(193, 41);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(36, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ProductWizard_Batch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(838, 537);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lnkAppendix3);
            this.Controls.Add(this.lnkAppendix2);
            this.Controls.Add(this.lnkAppendix1);
            this.Controls.Add(this.lblItemStatus);
            this.Controls.Add(this.cboItemStatus);
            this.Controls.Add(this.txtStkCode);
            this.Controls.Add(this.lblStkCode);
            this.Controls.Add(this.cboAppendix1);
            this.Controls.Add(this.cboAppendix2);
            this.Controls.Add(this.cboAppendix3);
            this.Name = "ProductWizard_Batch";
            this.Text = "ProductWizard_Batch";
            this.Load += new System.EventHandler(this.ProductWizard_Batch_Load);
            this.Controls.SetChildIndex(this.cboAppendix3, 0);
            this.Controls.SetChildIndex(this.cboAppendix2, 0);
            this.Controls.SetChildIndex(this.cboAppendix1, 0);
            this.Controls.SetChildIndex(this.lblStkCode, 0);
            this.Controls.SetChildIndex(this.txtStkCode, 0);
            this.Controls.SetChildIndex(this.cboItemStatus, 0);
            this.Controls.SetChildIndex(this.lblItemStatus, 0);
            this.Controls.SetChildIndex(this.lnkAppendix1, 0);
            this.Controls.SetChildIndex(this.lnkAppendix2, 0);
            this.Controls.SetChildIndex(this.lnkAppendix3, 0);
            this.Controls.SetChildIndex(this.btnFind, 0);
            this.wspDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabProduct.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAppendix3;
        private System.Windows.Forms.ComboBox cboAppendix2;
        private System.Windows.Forms.ComboBox cboAppendix1;
        private System.Windows.Forms.Label lblStkCode;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpMisc;
        private System.Windows.Forms.TabPage tpOrder;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tabProduct;
        private System.Windows.Forms.TextBox txtStkCode;
        private System.Windows.Forms.ComboBox cboItemStatus;
        private System.Windows.Forms.Label lblItemStatus;
        private System.Windows.Forms.LinkLabel lnkAppendix1;
        private System.Windows.Forms.LinkLabel lnkAppendix2;
        private System.Windows.Forms.LinkLabel lnkAppendix3;
        private System.Windows.Forms.Button btnFind;


    }
}