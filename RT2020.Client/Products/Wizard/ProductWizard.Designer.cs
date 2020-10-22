namespace RT2020.Client.Products .Wizard
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
            this.lblStkCode = new System.Windows.Forms.Label();
            this.txtStkCode = new System.Windows.Forms.TextBox();
            this.lblAppendix1 = new System.Windows.Forms.Label();
            this.lblAppendix2 = new System.Windows.Forms.Label();
            this.lblAppendix3 = new System.Windows.Forms.Label();
            this.cboAppendix1 = new System.Windows.Forms.ComboBox();
            this.cboAppendix2 = new System.Windows.Forms.ComboBox();
            this.cboAppendix3 = new System.Windows.Forms.ComboBox();
            this.tabProduct = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tpBarcode = new System.Windows.Forms.TabPage();
            this.tpQty = new System.Windows.Forms.TabPage();
            this.tpMisc = new System.Windows.Forms.TabPage();
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.tpDiscount = new System.Windows.Forms.TabPage();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.wspDetails.SuspendLayout();
            this.tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // wspDetails
            // 
            this.wspDetails.BackColor = System.Drawing.SystemColors.Control;
            this.wspDetails.Controls.Add(this.tabProduct);
            this.wspDetails.Location = new System.Drawing.Point(10, 108);
            this.wspDetails.Padding = new System.Windows.Forms.Padding(3);
            this.wspDetails.Size = new System.Drawing.Size(784, 379);
            this.wspDetails.TabIndex = 1;
            // 
            // wspStatus
            // 
            this.wspStatus.Location = new System.Drawing.Point(10, 487);
            this.wspStatus.Size = new System.Drawing.Size(784, 0);
            // 
            // wspHeader
            // 
            this.wspHeader.BackColor = System.Drawing.SystemColors.Control;
            this.wspHeader.Size = new System.Drawing.Size(784, 98);
            // 
            // lblStkCode
            // 
            this.lblStkCode.BackColor = System.Drawing.SystemColors.Control;
            this.lblStkCode.Location = new System.Drawing.Point(25, 45);
            this.lblStkCode.Name = "lblStkCode";
            this.lblStkCode.Size = new System.Drawing.Size(61, 23);
            this.lblStkCode.TabIndex = 2;
            this.lblStkCode.Text = "PLU:";
            // 
            // txtStkCode
            // 
            this.txtStkCode.Location = new System.Drawing.Point(70, 42);
            this.txtStkCode.MaxLength = 10;
            this.txtStkCode.Name = "txtStkCode";
            this.txtStkCode.Size = new System.Drawing.Size(100, 20);
            this.txtStkCode.TabIndex = 3;
            // 
            // lblAppendix1
            // 
            this.lblAppendix1.BackColor = System.Drawing.SystemColors.Control;
            this.lblAppendix1.Location = new System.Drawing.Point(212, 45);
            this.lblAppendix1.Name = "lblAppendix1";
            this.lblAppendix1.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix1.TabIndex = 4;
            this.lblAppendix1.Text = "Season:";
            // 
            // lblAppendix2
            // 
            this.lblAppendix2.BackColor = System.Drawing.SystemColors.Control;
            this.lblAppendix2.Location = new System.Drawing.Point(212, 68);
            this.lblAppendix2.Name = "lblAppendix2";
            this.lblAppendix2.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix2.TabIndex = 6;
            this.lblAppendix2.Text = "Color:";
            // 
            // lblAppendix3
            // 
            this.lblAppendix3.BackColor = System.Drawing.SystemColors.Control;
            this.lblAppendix3.Location = new System.Drawing.Point(212, 91);
            this.lblAppendix3.Name = "lblAppendix3";
            this.lblAppendix3.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix3.TabIndex = 8;
            this.lblAppendix3.Text = "Size:";
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.BackColor = System.Drawing.Color.White;
            this.cboAppendix1.DropDownWidth = 121;
            this.cboAppendix1.Location = new System.Drawing.Point(318, 41);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix1.TabIndex = 5;
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.BackColor = System.Drawing.Color.White;
            this.cboAppendix2.DropDownWidth = 121;
            this.cboAppendix2.Location = new System.Drawing.Point(318, 65);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix2.TabIndex = 7;
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.BackColor = System.Drawing.Color.White;
            this.cboAppendix3.DropDownWidth = 121;
            this.cboAppendix3.Location = new System.Drawing.Point(318, 88);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(121, 21);
            this.cboAppendix3.TabIndex = 9;
            // 
            // tabProduct
            // 
            this.tabProduct.Controls.Add(this.tpGeneral);
            this.tabProduct.Controls.Add(this.tpBarcode);
            this.tabProduct.Controls.Add(this.tpQty);
            this.tabProduct.Controls.Add(this.tpMisc);
            this.tabProduct.Controls.Add(this.tpOrder);
            this.tabProduct.Controls.Add(this.tpDiscount);
            this.tabProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProduct.Location = new System.Drawing.Point(3, 3);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.SelectedIndex = 0;
            this.tabProduct.Size = new System.Drawing.Size(778, 373);
            this.tabProduct.TabIndex = 0;
            this.tabProduct.SelectedIndexChanged += new System.EventHandler(this.tabProduct_SelectedIndexChanged);
            // 
            // tpGeneral
            // 
            this.tpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(770, 347);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            // 
            // tpBarcode
            // 
            this.tpBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpBarcode.Location = new System.Drawing.Point(4, 22);
            this.tpBarcode.Name = "tpBarcode";
            this.tpBarcode.Size = new System.Drawing.Size(760, 393);
            this.tpBarcode.TabIndex = 0;
            this.tpBarcode.Text = "Barcode";
            // 
            // tpQty
            // 
            this.tpQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpQty.Location = new System.Drawing.Point(4, 22);
            this.tpQty.Name = "tpQty";
            this.tpQty.Size = new System.Drawing.Size(760, 393);
            this.tpQty.TabIndex = 1;
            this.tpQty.Text = "Quantity";
            // 
            // tpMisc
            // 
            this.tpMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMisc.Location = new System.Drawing.Point(4, 22);
            this.tpMisc.Name = "tpMisc";
            this.tpMisc.Size = new System.Drawing.Size(760, 393);
            this.tpMisc.TabIndex = 2;
            this.tpMisc.Text = "Misc";
            // 
            // tpOrder
            // 
            this.tpOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpOrder.Location = new System.Drawing.Point(4, 22);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(760, 393);
            this.tpOrder.TabIndex = 3;
            this.tpOrder.Text = "Order";
            // 
            // tpDiscount
            // 
            this.tpDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpDiscount.Location = new System.Drawing.Point(4, 22);
            this.tpDiscount.Name = "tpDiscount";
            this.tpDiscount.Size = new System.Drawing.Size(760, 393);
            this.tpDiscount.TabIndex = 4;
            this.tpDiscount.Text = "Discount";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = " ";
            // 
            // ProductWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(804, 522);
            this.Controls.Add(this.cboAppendix3);
            this.Controls.Add(this.cboAppendix2);
            this.Controls.Add(this.cboAppendix1);
            this.Controls.Add(this.lblAppendix3);
            this.Controls.Add(this.lblAppendix2);
            this.Controls.Add(this.lblAppendix1);
            this.Controls.Add(this.txtStkCode);
            this.Controls.Add(this.lblStkCode);
            this.Name = "ProductWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Wizard";
            this.Load += new System.EventHandler(this.ProductWizard_Load);
            this.Controls.SetChildIndex(this.lblStkCode, 0);
            this.Controls.SetChildIndex(this.txtStkCode, 0);
            this.Controls.SetChildIndex(this.lblAppendix1, 0);
            this.Controls.SetChildIndex(this.lblAppendix2, 0);
            this.Controls.SetChildIndex(this.lblAppendix3, 0);
            this.Controls.SetChildIndex(this.cboAppendix1, 0);
            this.Controls.SetChildIndex(this.cboAppendix2, 0);
            this.Controls.SetChildIndex(this.cboAppendix3, 0);
            this.wspDetails.ResumeLayout(false);
            this.tabProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStkCode;
        private System.Windows.Forms.TextBox txtStkCode;
        private System.Windows.Forms.Label lblAppendix1;
        private System.Windows.Forms.Label lblAppendix2;
        private System.Windows.Forms.Label lblAppendix3;
        private System.Windows.Forms.ComboBox cboAppendix1;
        private System.Windows.Forms.ComboBox cboAppendix2;
        private System.Windows.Forms.ComboBox cboAppendix3;
        private System.Windows.Forms.TabControl tabProduct;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpBarcode;
        private System.Windows.Forms.TabPage tpQty;
        private System.Windows.Forms.TabPage tpMisc;
        private System.Windows.Forms.TabPage tpOrder;
        private System.Windows.Forms.TabPage tpDiscount;
        private System.Windows.Forms.ErrorProvider errorProvider;


    }
}