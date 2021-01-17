#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

using System.IO;
using System.Linq;
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard : Form
    {
        #region public properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _ProductId = Guid.Empty;
        public Guid ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        #endregion

        #region declare tab pages
        bool tabGeneralLoaded = false, tabBarcodeLoaded = false, tabQuantityLoaded = false, tabMiscLoaded = false, tabOrderLoaded = false, tabDiscountLoaded = false;

        ProductWizard_General general = null;
        ProductWizard_Barcode barcode = null;
        ProductWizard_Quantity quantity = null;
        ProductWizard_Misc misc = null;
        ProductWizard_Order order = null;
        ProductWizard_Discount discount = null;
        #endregion

        public ProductWizard()
        {
            InitializeComponent();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //SetSystemLabels();
        }

        private void ProductWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            //TabCtrl();
            SetProtectedFields();
            FillAppendixes();
            LoadTabPage(0);

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadProductInfo();
                    break;
            }

            this.txtStkCode.Focus();
        }

        #region SetCaptions, SetAttributes & SetPhoneTag
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("setup", "Product");

            lblStkCode.Text = WestwindHelper.GetWordWithColon("general.STKCODE", "Product");
            lblAppendix1.Text = WestwindHelper.GetWordWithColon("appendix.appendix1", "Product");
            lblAppendix2.Text = WestwindHelper.GetWordWithColon("appendix.appendix2", "Product");
            lblAppendix3.Text = WestwindHelper.GetWordWithColon("appendix.appendix3", "Product");

            tpGeneral.Text = WestwindHelper.GetWord("general", "Product");
            tpBarcode.Text = WestwindHelper.GetWord("barcode", "Product");
            tpQty.Text = WestwindHelper.GetWord("inventory", "Product");
            tpMisc.Text = WestwindHelper.GetWord("misc", "Product");
            tpOrder.Text = WestwindHelper.GetWord("order", "Product");
            tpDiscount.Text = WestwindHelper.GetWord("discount", "Product");
        }

        private void SetAttributes()
        {
            txtStkCode.MaxLength = 10;      // dbo.Product.STKCODE VARCHAR(10)

            #region 設定 clickable Appendix 1 label
            //lblAppendix1.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblAppendix1.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblAppendix1.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductAppendixWizardAio();
                dialog.ProductAppendixType = ProductHelper.Appendix.Appendix1;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillAppendixe1();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Appendix 2 label
            //lblAppendix2.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblAppendix2.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblAppendix2.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductAppendixWizardAio();
                dialog.ProductAppendixType = ProductHelper.Appendix.Appendix2;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillAppendixe2();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Appendix 3 label
            //lblAppendix3.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblAppendix3.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblAppendix3.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductAppendixWizardAio();
                dialog.ProductAppendixType = ProductHelper.Appendix.Appendix3;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillAppendixe3();
                };
                dialog.ShowDialog();
            };
            #endregion
        }
        #endregion

        #region ToolBar
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", WestwindHelper.GetWord("edit.save.new", "General"));
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", WestwindHelper.GetWord("edit.save.close", "General"));
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (ProductId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Delete);
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
                        break;
                    case "save & new":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
                        break;
                    case "save & close":
                        MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveCloseMessageHandler));
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Set protected fields for STKCODE / Appendix, LoadTabPage
        private void SetProtectedFields()
        {
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    txtStkCode.BackColor = cboAppendix1.BackColor = cboAppendix2.BackColor = cboAppendix3.BackColor = Color.LightSkyBlue;
                    txtStkCode.Enabled = cboAppendix1.Enabled = cboAppendix2.Enabled = cboAppendix3.Enabled = true;
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    txtStkCode.BackColor = cboAppendix1.BackColor = cboAppendix2.BackColor = cboAppendix3.BackColor = Color.LightYellow;
                    txtStkCode.Enabled = cboAppendix1.Enabled = cboAppendix2.Enabled = cboAppendix3.Enabled = false;
                    break;
            }
        }

        private void LoadTabPage(int index = 0)
        {
            switch (index)
            {
                case 0:
                    #region General
                    if (!tabGeneralLoaded)
                    {
                        general = new ProductWizard_General();
                        general.Dock = DockStyle.Fill;
                        general.EditMode = _EditMode;
                        general.ProductId = _ProductId;
                        tpGeneral.Controls.Add(general);

                        tabGeneralLoaded = true;
                    }
                    break;
                    #endregion
                case 1:
                    #region Barcode
                    if (!tabBarcodeLoaded)
                    {
                        barcode = new ProductWizard_Barcode();
                        barcode.Dock = DockStyle.Fill;
                        barcode.EditMode = _EditMode;
                        barcode.ProductId = _ProductId;
                        tpBarcode.Controls.Add(barcode);

                        tabBarcodeLoaded = true;
                    }
                    break;
                    #endregion
                case 2:
                    #region Quantity
                    if (!tabQuantityLoaded)
                    {
                        quantity = new ProductWizard_Quantity();
                        quantity.Dock = DockStyle.Fill;
                        quantity.EditMode = _EditMode;
                        quantity.ProductId = _ProductId;
                        tpQty.Controls.Add(quantity);

                        tabQuantityLoaded = true;
                    }
                    break;
                    #endregion
                case 3:
                    #region Misc
                    if (!tabMiscLoaded)
                    {
                        misc = new ProductWizard_Misc();
                        misc.Dock = DockStyle.Fill;
                        misc.ProductId = _ProductId;
                        misc.EditMode = _EditMode;
                        tpMisc.Controls.Add(misc);

                        tabMiscLoaded = true;
                    }
                    break;
                    #endregion
                case 4:
                    #region Order
                    if (!tabOrderLoaded)
                    {
                        order = new ProductWizard_Order();
                        order.Dock = DockStyle.Fill;
                        order.EditMode = _EditMode;
                        order.ProductId = _ProductId;
                        tpOrder.Controls.Add(order);

                        tabOrderLoaded = true;
                    }
                    break;
                    #endregion
                case 5:
                    #region Discount
                    if (!tabDiscountLoaded)
                    {
                        discount = new ProductWizard_Discount();
                        discount.Dock = DockStyle.Fill;
                        discount.EditMode = _EditMode;
                        discount.ProductId = _ProductId;
                        tpDiscount.Controls.Add(discount);

                        tabDiscountLoaded = true;
                    }
                    break;
                    #endregion
            }
        }
        #endregion

        #region Load Appendix
        private void FillAppendixes()
        {
            FillAppendixe1();
            FillAppendixe2();
            FillAppendixe3();
        }

        private void FillAppendixe1()
        {
            cboAppendix1.BindData();
        }

        private void FillAppendixe2()
        {
            cboAppendix2.BindData();
        }

        private void FillAppendixe3()
        {
            cboAppendix3.BindData();
        }
        #endregion

        #region Actions Methods
        private bool IsValidAppendix()
        {
            bool result = true;

            result = result & IsValidAppendix1();
            result = result & IsValidAppendix2();
            result = result & IsValidAppendix3();

            return result;
        }

        private bool IsValidAppendix1()
        {
            var result = true;
            errorProvider.SetError(cboAppendix1, string.Empty);

            if (cboAppendix1.Text.Trim().Length > 0)
            {
                if (!ModelEx.ProductAppendix1Ex.IsAppendixCodeInUse(cboAppendix1.Text))
                {
                    errorProvider.SetError(cboAppendix1, "The code is invalid! Try to select a value from the list!");
                    result = false;
                }
            }

            return result;
        }

        private bool IsValidAppendix2()
        {
            var result = true;
            errorProvider.SetError(cboAppendix2, string.Empty);

            if (cboAppendix2.Text.Trim().Length > 0)
            {
                if (!ModelEx.ProductAppendix2Ex.IsAppendixCodeInUse(cboAppendix2.Text))
                {
                    errorProvider.SetError(cboAppendix2, "The code is invalid! Try to select a value from the list!");
                    result = false;
                }
            }

            return result;
        }

        private bool IsValidAppendix3()
        {
            var result = true;
            errorProvider.SetError(cboAppendix3, string.Empty);

            if (cboAppendix3.Text.Trim().Length > 0)
            {
                if (!ModelEx.ProductAppendix3Ex.IsAppendixCodeInUse(cboAppendix3.Text))
                {
                    errorProvider.SetError(cboAppendix3, "The code is invalid! Try to select a value from the list!");
                    result = false;
                }
            }

            return result;
        }

        private bool IsValid()
        {
            var result = true;
            errorProvider.SetError(txtStkCode, string.Empty);

            if (txtStkCode.Text == string.Empty)
            {
                errorProvider.SetError(txtStkCode, "Can not be blank!");
                return false;
            }
            result = IsValidAppendix();

            return result;
        }

        private bool IsDuplicated()
        {
            if (ProductHelper.IsDuplicated(txtStkCode.Text, cboAppendix1.Text, cboAppendix2.Text, cboAppendix3.Text))
            {
                MessageBox.Show(string.Format(Resources.Common.DuplicatedCode, "Stock Code + Appendix1 + Appendix2 + Appendix3"), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Save Product Info
        private bool Save()
        {
            bool result = false;

            if (IsValid())
            {
                if (!IsDuplicated())
                {
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        using (var scope = ctx.Database.BeginTransaction())
                        {
                            try
                            {
                                #region this.ProductId = SaveGeneralInfo();

                                var oProduct = ctx.Product.Find(this.ProductId);
                                if (oProduct == null)
                                {
                                    #region new Product
                                    oProduct = new EF6.Product();
                                    oProduct.ProductId = Guid.NewGuid();
                                    oProduct.STKCODE = txtStkCode.Text.Trim();
                                    oProduct.APPENDIX1 = cboAppendix1.Text.Trim();
                                    oProduct.APPENDIX2 = cboAppendix2.Text.Trim();
                                    oProduct.APPENDIX3 = cboAppendix3.Text.Trim();

                                    oProduct.Status = (int)EnumHelper.Status.Active;

                                    oProduct.CreatedBy = ConfigHelper.CurrentUserId;
                                    oProduct.CreatedOn = DateTime.Now;

                                    ctx.Product.Add(oProduct);
                                    _ProductId = oProduct.ProductId;
                                    #endregion
                                }
                                #region Porduct core data
                                oProduct.CLASS1 = general.cboClass1.Text;
                                oProduct.CLASS2 = general.cboClass2.Text;
                                oProduct.CLASS3 = general.cboClass3.Text;
                                oProduct.CLASS4 = general.cboClass4.Text;
                                oProduct.CLASS5 = general.cboClass5.Text;
                                oProduct.CLASS6 = general.cboClass6.Text;

                                oProduct.ProductName = general.txtProductName.Text;
                                oProduct.ProductName_Chs = general.txtProductNameChs.Text;
                                oProduct.ProductName_Cht = general.txtProductNameCht.Text;
                                oProduct.Remarks = general.txtRemarks.Text;

                                oProduct.NormalDiscount = Convert.ToDecimal((general.txtRetailDiscount.Text == string.Empty) ? "0" : general.txtRetailDiscount.Text);
                                oProduct.UOM = general.txtUnit.Text;
                                oProduct.NatureId = new Guid(general.cboNature.SelectedValue.ToString());

                                oProduct.FixedPriceItem = discount.chkFixedPrice.Checked;

                                #region save Price
                                oProduct.RetailPrice = Convert.ToDecimal((general.txtCurrentRetailPrice.Text == string.Empty) ? "0" : general.txtCurrentRetailPrice.Text);
                                oProduct.WholesalePrice = Convert.ToDecimal((general.txtWholesalesPrice.Text == string.Empty) ? "0" : general.txtWholesalesPrice.Text);
                                oProduct.OriginalRetailPrice = Convert.ToDecimal((general.txtOriginalRetailPrice.Text == string.Empty) ? "0" : general.txtOriginalRetailPrice.Text);
                                //oItem.Markup = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);
                                #endregion

                                #region Download Packets
                                oProduct.DownloadToPOS = general.chkRetailItem.Checked;
                                oProduct.DownloadToCounter = general.chkCounterItem.Checked;
                                #endregion

                                oProduct.Status = _EditMode == EnumHelper.EditMode.Add ? (int)EnumHelper.Status.Active : (int)EnumHelper.Status.Modified;

                                #region MaxOnLoanQty
                                decimal olnQty = 0;
                                if (tabQuantityLoaded) decimal.TryParse(quantity.txtMaxOLNQty.Text, out olnQty);

                                oProduct.MaxOnLoanQty = olnQty;
                                #endregion

                                oProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                                oProduct.ModifiedOn = DateTime.Now;

                                #region SaveOrderInfo();
                                if (tabOrderLoaded)
                                {
                                    oProduct.AlternateItem = order.txtVendorItemNum.Text; // Vendor Item Number
                                    oProduct.ReorderLevel = Convert.ToDecimal((order.txtReorderLevel.Text == string.Empty) ? "0" : order.txtReorderLevel.Text);
                                    oProduct.ReorderQty = Convert.ToDecimal((order.txtReorderQuantity.Text == string.Empty) ? "0" : order.txtReorderQuantity.Text);
                                }
                                #endregion

                                ctx.SaveChanges();
                                #endregion

                                #region log4net
                                RT2020.Controls.Log4net.LogInfo(_EditMode == EnumHelper.EditMode.Add ?
                                    RT2020.Controls.Log4net.LogAction.Create :
                                    RT2020.Controls.Log4net.LogAction.Update,
                                    oProduct.ToString());
                                #endregion

                                #region SaveProductBarcode(oProduct);
                                string stkcode = oProduct.STKCODE;

                                if (oProduct.STKCODE.Length > 10)
                                {
                                    stkcode = oProduct.STKCODE.Remove(10);
                                }

                                string barcode = stkcode + oProduct.APPENDIX1 + oProduct.APPENDIX2 + oProduct.APPENDIX3;
                                //string sql = "ProductId = '" + oProduct.ProductId.ToString() + "' AND Barcode = '" + barcode + "'";
                                var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == oProduct.ProductId && x.Barcode == barcode).FirstOrDefault();
                                if (oBarcode == null)
                                {
                                    oBarcode = new EF6.ProductBarcode();
                                    oBarcode.ProductBarcodeId = Guid.NewGuid();
                                    oBarcode.ProductId = oProduct.ProductId;
                                    oBarcode.Barcode = barcode;
                                    oBarcode.BarcodeType = "INTER";
                                    oBarcode.PrimaryBarcode = true;
                                    oBarcode.DownloadToPOS = general.chkRetailItem.Checked;
                                    oBarcode.DownloadToCounter = general.chkCounterItem.Checked;

                                    ctx.ProductBarcode.Add(oBarcode);
                                }
                                #endregion

                                #region Appendix / Class
                                Guid a1Id = (cboAppendix1.SelectedValue != null) ? new Guid(cboAppendix1.SelectedValue.ToString()) : Guid.Empty;
                                Guid a2Id = (cboAppendix2.SelectedValue != null) ? new Guid(cboAppendix2.SelectedValue.ToString()) : Guid.Empty;
                                Guid a3Id = (cboAppendix3.SelectedValue != null) ? new Guid(cboAppendix3.SelectedValue.ToString()) : Guid.Empty;

                                Guid c1Id = (general.cboClass1.SelectedValue != null) ? new Guid(general.cboClass1.SelectedValue.ToString()) : Guid.Empty;
                                Guid c2Id = (general.cboClass2.SelectedValue != null) ? new Guid(general.cboClass2.SelectedValue.ToString()) : Guid.Empty;
                                Guid c3Id = (general.cboClass3.SelectedValue != null) ? new Guid(general.cboClass3.SelectedValue.ToString()) : Guid.Empty;
                                Guid c4Id = (general.cboClass4.SelectedValue != null) ? new Guid(general.cboClass4.SelectedValue.ToString()) : Guid.Empty;
                                Guid c5Id = (general.cboClass5.SelectedValue != null) ? new Guid(general.cboClass5.SelectedValue.ToString()) : Guid.Empty;
                                Guid c6Id = (general.cboClass6.SelectedValue != null) ? new Guid(general.cboClass6.SelectedValue.ToString()) : Guid.Empty;

                                //SaveProductCode(oProduct.ProductId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);
                                //string sql = "ProductId = '" + this.productId.ToString() + "'";
                                var oCode = ctx.ProductCode.Where(x => x.ProductId == this._ProductId).FirstOrDefault();
                                if (oCode == null)
                                {
                                    oCode = new EF6.ProductCode();
                                    oCode.CodeId = Guid.NewGuid();
                                    oCode.ProductId = _ProductId;
                                    oCode.Appendix1Id = a1Id;
                                    oCode.Appendix2Id = a2Id;
                                    oCode.Appendix3Id = a3Id;

                                    ctx.ProductCode.Add(oCode);
                                }
                                oCode.Class1Id = c1Id;
                                oCode.Class2Id = c2Id;
                                oCode.Class3Id = c3Id;
                                oCode.Class4Id = c4Id;
                                oCode.Class5Id = c5Id;
                                oCode.Class6Id = c6Id;

                                #endregion

                                // Product Barcode
                                this.barcode.AddBarcode();

                                // Product Price
                                #region SaveProductSupplement(oProduct.ProductId);
                                var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == this._ProductId).FirstOrDefault();
                                if (oProdSupp == null)
                                {
                                    oProdSupp = new EF6.ProductSupplement();
                                    oProdSupp.SupplementId = Guid.NewGuid();
                                    oProdSupp.ProductId = this._ProductId;

                                    ctx.ProductSupplement.Add(oProdSupp);
                                }
                                oProdSupp.VendorCurrencyCode = general.cboVendorCurrency.Text;
                                oProdSupp.VendorPrice = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);
                                oProdSupp.ProductName_Memo = general.txtMemo.Text;
                                oProdSupp.ProductName_Pole = general.txtPole.Text;

                                if (tabDiscountLoaded)
                                {
                                    oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((discount.txtFixPriceItem.Text == string.Empty) ? "0" : discount.txtFixPriceItem.Text);
                                    oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((discount.txtDiscountItem.Text == string.Empty) ? "0" : discount.txtDiscountItem.Text);
                                    oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((discount.txtNoDiscountItem.Text == string.Empty) ? "0" : discount.txtNoDiscountItem.Text);
                                    oProdSupp.StaffDiscount = Convert.ToDecimal((discount.txtStaffDiscount.Text == string.Empty) ? "0" : discount.txtStaffDiscount.Text);
                                }
                                ctx.SaveChanges();
                                #endregion

                                //SaveProductPrice(oProduct.ProductId);
                                #region SaveProductPrice(productId, ProductHelper.Prices.BASPRC.ToString(), general.txtCurrentRetailCurrency.Text, general.txtCurrentRetailPrice.Text);
                                var price = general.txtCurrentRetailPrice.Text;
                                var currencyCode = general.txtCurrentRetailCurrency.Text;
                                var priceType = ProductHelper.Prices.BASPRC.ToString();
                                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);

                                var oBPrice = ctx.ProductPrice.Where(x => x.ProductId == _ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oBPrice == null)
                                {
                                    oBPrice = new EF6.ProductPrice();
                                    oBPrice.ProductPriceId = Guid.NewGuid();
                                    oBPrice.ProductId = _ProductId;
                                    ctx.ProductPrice.Add(oBPrice);
                                }
                                oBPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                                oBPrice.CurrencyCode = currencyCode;
                                oBPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                                ctx.SaveChanges();
                                #endregion
                                //
                                #region SaveProductPrice(productId, ProductHelper.Prices.ORIPRC.ToString(), general.txtOriginalRetailCurrency.Text, general.txtOriginalRetailPrice.Text);
                                price = general.txtOriginalRetailPrice.Text;
                                currencyCode = general.txtOriginalRetailCurrency.Text;
                                priceType = ProductHelper.Prices.ORIPRC.ToString();
                                priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);

                                var oOPrice = ctx.ProductPrice.Where(x => x.ProductId == _ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oOPrice == null)
                                {
                                    oOPrice = new EF6.ProductPrice();
                                    oOPrice.ProductPriceId = Guid.NewGuid();
                                    oOPrice.ProductId = _ProductId;
                                    ctx.ProductPrice.Add(oOPrice);
                                }
                                oOPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                                oOPrice.CurrencyCode = currencyCode;
                                oOPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                                ctx.SaveChanges();
                                #endregion
                                //
                                #region SaveProductPrice(productId, ProductHelper.Prices.VPRC.ToString(), general.cboVendorCurrency.Text, general.txtVendorPrice.Text);
                                price = general.txtVendorPrice.Text;
                                currencyCode = general.cboVendorCurrency.Text;
                                priceType = ProductHelper.Prices.VPRC.ToString();
                                priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);

                                var oVPrice = ctx.ProductPrice.Where(x => x.ProductId == _ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oVPrice == null)
                                {
                                    oVPrice = new EF6.ProductPrice();
                                    oVPrice.ProductPriceId = Guid.NewGuid();
                                    oVPrice.ProductId = _ProductId;
                                    ctx.ProductPrice.Add(oVPrice);
                                }
                                oVPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                                oVPrice.CurrencyCode = currencyCode;
                                oVPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                                ctx.SaveChanges();
                                #endregion
                                //
                                #region SaveProductPrice(productId, ProductHelper.Prices.WHLPRC.ToString(), general.txtWholesalesCurrency.Text, general.txtWholesalesPrice.Text);
                                price = general.txtWholesalesPrice.Text;
                                currencyCode = general.txtWholesalesCurrency.Text;
                                priceType = ProductHelper.Prices.WHLPRC.ToString();
                                priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);

                                var oWPrice = ctx.ProductPrice.Where(x => x.ProductId == _ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oWPrice == null)
                                {
                                    oWPrice = new EF6.ProductPrice();
                                    oWPrice.ProductPriceId = Guid.NewGuid();
                                    oWPrice.ProductId = _ProductId;
                                    ctx.ProductPrice.Add(oWPrice);
                                }
                                oWPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                                oWPrice.CurrencyCode = currencyCode;
                                oWPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                                ctx.SaveChanges();
                                #endregion

                                // Remarks
                                #region SaveProductRemarks(oProduct.ProductId);
                                //string sql = "ProductId = '" + productId.ToString() + "'";
                                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == _ProductId).FirstOrDefault();
                                if (oRemarks == null)
                                {
                                    oRemarks = new EF6.ProductRemarks();
                                    oRemarks.ProductRemarksId = Guid.NewGuid();
                                    oRemarks.ProductId = _ProductId;

                                    ctx.ProductRemarks.Add(oRemarks);
                                }
                                oRemarks.BinX = general.txtBin_X.Text;
                                oRemarks.BinY = general.txtBin_Y.Text;
                                oRemarks.BinZ = general.txtBin_Z.Text;

                                oRemarks.DownloadToShop = general.chkRetailItem.Checked;
                                oRemarks.OffDisplayItem = general.chkOffDisplayItem.Checked;
                                oRemarks.DownloadToCounter = general.chkCounterItem.Checked;

                                oRemarks.REMARK1 = general.txtRemarks1.Text;
                                oRemarks.REMARK2 = general.txtRemarks2.Text;
                                oRemarks.REMARK3 = general.txtRemarks3.Text;
                                oRemarks.REMARK4 = general.txtRemarks4.Text;
                                oRemarks.REMARK5 = general.txtRemarks5.Text;
                                oRemarks.REMARK6 = general.txtRemarks6.Text;

                                if (tabMiscLoaded)
                                {
                                    oRemarks.Notes = misc.txtMemo.Text;

                                    if (string.IsNullOrEmpty(oRemarks.Photo))
                                    {
                                        oRemarks.Photo = misc.txtPicFileName.Text;
                                    }
                                    else if (oRemarks.Photo != misc.txtPicFileName.Text)
                                    {
                                        oRemarks.Photo5 = oRemarks.Photo4;
                                        oRemarks.Photo4 = oRemarks.Photo3;
                                        oRemarks.Photo3 = oRemarks.Photo2;
                                        oRemarks.Photo2 = oRemarks.Photo;
                                        oRemarks.Photo = misc.txtPicFileName.Text;
                                    }
                                }

                                ctx.SaveChanges();
                                #endregion

                                #endregion

                                #region SaveProductCurrentSummary(this.ProductId);
                                //string where = "ProductId = '" + productId.ToString() + "'";
                                var oCurrSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == _ProductId).FirstOrDefault();
                                if (oCurrSummary == null)
                                {
                                    oCurrSummary = new EF6.ProductCurrentSummary();
                                    oCurrSummary.CurrentSummaryId = Guid.NewGuid();
                                    oCurrSummary.ProductId = _ProductId;
                                    oCurrSummary.CDQTY = 0;
                                    oCurrSummary.LastPurchasedOn = new DateTime(1900, 1, 1);
                                    oCurrSummary.LastSoldOn = new DateTime(1900, 1, 1);

                                    ctx.ProductCurrentSummary.Add(oCurrSummary);
                                }
                                #endregion

                                ctx.SaveChanges();

                                scope.Commit();
                            }
                            catch (Exception ex)
                            {
                                scope.Rollback();
                            }
                        }
                    }
                }
            }

            return result;
        }

        private Guid SaveGeneralInfo()
        {
            Guid result = Guid.Empty;
            bool isNew = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oProduct = ctx.Product.Find(this.ProductId);
                        if (oProduct == null)
                        {
                            #region add new product
                            oProduct = new EF6.Product();
                            oProduct.ProductId = Guid.NewGuid();
                            oProduct.STKCODE = txtStkCode.Text.Trim();
                            oProduct.APPENDIX1 = cboAppendix1.Text.Trim();
                            oProduct.APPENDIX2 = cboAppendix2.Text.Trim();
                            oProduct.APPENDIX3 = cboAppendix3.Text.Trim();

                            oProduct.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));
                            oProduct.CreatedBy = ConfigHelper.CurrentUserId;
                            oProduct.CreatedOn = DateTime.Now;

                            ctx.Product.Add(oProduct);
                            isNew = true;
                            #endregion
                        }
                        #region Product core data
                        oProduct.CLASS1 = general.cboClass1.Text;
                        oProduct.CLASS2 = general.cboClass2.Text;
                        oProduct.CLASS3 = general.cboClass3.Text;
                        oProduct.CLASS4 = general.cboClass4.Text;
                        oProduct.CLASS5 = general.cboClass5.Text;
                        oProduct.CLASS6 = general.cboClass6.Text;

                        oProduct.ProductName = general.txtProductName.Text;
                        oProduct.ProductName_Chs = general.txtProductNameChs.Text;
                        oProduct.ProductName_Cht = general.txtProductNameCht.Text;
                        oProduct.Remarks = general.txtRemarks.Text;

                        oProduct.NormalDiscount = Convert.ToDecimal((general.txtRetailDiscount.Text == string.Empty) ? "0" : general.txtRetailDiscount.Text);
                        oProduct.UOM = general.txtUnit.Text;
                        oProduct.NatureId = new Guid(general.cboNature.SelectedValue.ToString());

                        oProduct.FixedPriceItem = discount.chkFixedPrice.Checked;

                        #region Price
                        oProduct.RetailPrice = Convert.ToDecimal((general.txtCurrentRetailPrice.Text == string.Empty) ? "0" : general.txtCurrentRetailPrice.Text);
                        oProduct.WholesalePrice = Convert.ToDecimal((general.txtWholesalesPrice.Text == string.Empty) ? "0" : general.txtWholesalesPrice.Text);
                        oProduct.OriginalRetailPrice = Convert.ToDecimal((general.txtOriginalRetailPrice.Text == string.Empty) ? "0" : general.txtOriginalRetailPrice.Text);
                        //oItem.Markup = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);
                        #endregion

                        // Download Packets
                        oProduct.DownloadToPOS = general.chkRetailItem.Checked;
                        oProduct.DownloadToCounter = general.chkCounterItem.Checked;

                        // If the item existed, change the status to Modified.
                        if (!isNew) oProduct.Status = Convert.ToInt32(EnumHelper.Status.Modified.ToString("d"));

                        oProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                        oProduct.ModifiedOn = DateTime.Now;

                        ctx.SaveChanges();
                        #endregion

                        var productId = oProduct.ProductId;

                        #region log4net
                        if (isNew)
                        {// log activity (New Record)
                            RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Create, oProduct.ToString());
                        }
                        else
                        { // log activity (Update)
                            RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Update, oProduct.ToString());
                        }
                        #endregion

                        #region SaveProductBarcode(oProduct);
                        string stkcode = oProduct.STKCODE.Length > 10 ? oProduct.STKCODE.Remove(10) : oProduct.STKCODE;
                        string barcode = stkcode + oProduct.APPENDIX1 + oProduct.APPENDIX2 + oProduct.APPENDIX3;

                        var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == oProduct.ProductId && x.Barcode == barcode).FirstOrDefault();
                        if (oBarcode == null)
                        {
                            oBarcode = new EF6.ProductBarcode();
                            oBarcode.ProductBarcodeId = Guid.NewGuid();
                            oBarcode.ProductId = oProduct.ProductId;
                            oBarcode.Barcode = barcode;
                            oBarcode.BarcodeType = "INTER";
                            oBarcode.PrimaryBarcode = true;
                            oBarcode.DownloadToPOS = general.chkRetailItem.Checked;
                            oBarcode.DownloadToCounter = general.chkCounterItem.Checked;

                            ctx.ProductBarcode.Add(oBarcode);
                            ctx.SaveChanges();
                        }
                        #endregion

                        #region Appendix / Class
                        System.Guid a1Id = (cboAppendix1.SelectedValue != null) ? new Guid(cboAppendix1.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid a2Id = (cboAppendix2.SelectedValue != null) ? new Guid(cboAppendix2.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid a3Id = (cboAppendix3.SelectedValue != null) ? new Guid(cboAppendix3.SelectedValue.ToString()) : System.Guid.Empty;

                        System.Guid c1Id = (general.cboClass1.SelectedValue != null) ? new Guid(general.cboClass1.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c2Id = (general.cboClass2.SelectedValue != null) ? new Guid(general.cboClass2.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c3Id = (general.cboClass3.SelectedValue != null) ? new Guid(general.cboClass3.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c4Id = (general.cboClass4.SelectedValue != null) ? new Guid(general.cboClass4.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c5Id = (general.cboClass5.SelectedValue != null) ? new Guid(general.cboClass5.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c6Id = (general.cboClass6.SelectedValue != null) ? new Guid(general.cboClass6.SelectedValue.ToString()) : System.Guid.Empty;
                        //SaveProductCode(oProduct.ProductId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);
                        var oCode = ctx.ProductCode.Where(x => x.ProductId == productId).FirstOrDefault();
                        if (oCode == null)
                        {
                            oCode = new EF6.ProductCode();
                            oCode.CodeId = Guid.NewGuid();
                            oCode.ProductId = productId;
                            oCode.Appendix1Id = a1Id;
                            oCode.Appendix2Id = a2Id;
                            oCode.Appendix3Id = a3Id;

                            ctx.ProductCode.Add(oCode);
                        }
                        oCode.Class1Id = c1Id;
                        oCode.Class2Id = c2Id;
                        oCode.Class3Id = c3Id;
                        oCode.Class4Id = c4Id;
                        oCode.Class5Id = c5Id;
                        oCode.Class6Id = c6Id;

                        ctx.SaveChanges();
                        #endregion

                        // Product Barcode
                        this.barcode.AddBarcode();

                        // Product Price
                        #region SaveProductSupplement(oProduct.ProductId);
                        var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == productId).FirstOrDefault();
                        if (oProdSupp == null)
                        {
                            oProdSupp = new EF6.ProductSupplement();
                            oProdSupp.SupplementId = Guid.NewGuid();
                            oProdSupp.ProductId = productId;

                            ctx.ProductSupplement.Add(oProdSupp);
                        }
                        oProdSupp.VendorCurrencyCode = general.cboVendorCurrency.Text;
                        oProdSupp.VendorPrice = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);
                        oProdSupp.ProductName_Memo = general.txtMemo.Text;
                        oProdSupp.ProductName_Pole = general.txtPole.Text;

                        oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((discount.txtFixPriceItem.Text == string.Empty) ? "0" : discount.txtFixPriceItem.Text);
                        oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((discount.txtDiscountItem.Text == string.Empty) ? "0" : discount.txtDiscountItem.Text);
                        oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((discount.txtNoDiscountItem.Text == string.Empty) ? "0" : discount.txtNoDiscountItem.Text);
                        oProdSupp.StaffDiscount = Convert.ToDecimal((discount.txtStaffDiscount.Text == string.Empty) ? "0" : discount.txtStaffDiscount.Text);

                        ctx.SaveChanges();
                        #endregion
                        //
                        //SaveProductPrice(oProduct.ProductId);
                        #region SaveProductPrice(productId, ProductHelper.Prices.BASPRC.ToString(), general.txtCurrentRetailCurrency.Text, general.txtCurrentRetailPrice.Text);
                        var price = general.txtCurrentRetailPrice.Text;
                        var currencyCode = general.txtCurrentRetailCurrency.Text;
                        var priceType = ProductHelper.Prices.BASPRC.ToString();
                        var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);

                        var oBPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                        if (oBPrice == null)
                        {
                            oBPrice = new EF6.ProductPrice();
                            oBPrice.ProductPriceId = Guid.NewGuid();
                            oBPrice.ProductId = productId;
                            ctx.ProductPrice.Add(oBPrice);
                        }
                        oBPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                        oBPrice.CurrencyCode = currencyCode;
                        oBPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                        ctx.SaveChanges();
                        #endregion
                        //
                        #region SaveProductPrice(productId, ProductHelper.Prices.ORIPRC.ToString(), general.txtOriginalRetailCurrency.Text, general.txtOriginalRetailPrice.Text);
                        price = general.txtOriginalRetailPrice.Text;
                        currencyCode = general.txtOriginalRetailCurrency.Text;
                        priceType = ProductHelper.Prices.ORIPRC.ToString();
                        priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);

                        var oOPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                        if (oOPrice == null)
                        {
                            oOPrice = new EF6.ProductPrice();
                            oOPrice.ProductPriceId = Guid.NewGuid();
                            oOPrice.ProductId = productId;
                            ctx.ProductPrice.Add(oOPrice);
                        }
                        oOPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                        oOPrice.CurrencyCode = currencyCode;
                        oOPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                        ctx.SaveChanges();
                        #endregion
                        //
                        #region SaveProductPrice(productId, ProductHelper.Prices.VPRC.ToString(), general.cboVendorCurrency.Text, general.txtVendorPrice.Text);
                        price = general.txtVendorPrice.Text;
                        currencyCode = general.cboVendorCurrency.Text;
                        priceType = ProductHelper.Prices.VPRC.ToString();
                        priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);

                        var oVPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                        if (oVPrice == null)
                        {
                            oVPrice = new EF6.ProductPrice();
                            oVPrice.ProductPriceId = Guid.NewGuid();
                            oVPrice.ProductId = productId;
                            ctx.ProductPrice.Add(oVPrice);
                        }
                        oVPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                        oVPrice.CurrencyCode = currencyCode;
                        oVPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                        ctx.SaveChanges();
                        #endregion
                        //
                        #region SaveProductPrice(productId, ProductHelper.Prices.WHLPRC.ToString(), general.txtWholesalesCurrency.Text, general.txtWholesalesPrice.Text);
                        price = general.txtWholesalesPrice.Text;
                        currencyCode = general.txtWholesalesCurrency.Text;
                        priceType = ProductHelper.Prices.WHLPRC.ToString();
                        priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);

                        var oWPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                        if (oWPrice == null)
                        {
                            oWPrice = new EF6.ProductPrice();
                            oWPrice.ProductPriceId = Guid.NewGuid();
                            oWPrice.ProductId = productId;
                            ctx.ProductPrice.Add(oWPrice);
                        }
                        oWPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                        oWPrice.CurrencyCode = currencyCode;
                        oWPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                        ctx.SaveChanges();
                        #endregion

                        // Remarks
                        #region SaveProductRemarks(oProduct.ProductId);
                        var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == productId).FirstOrDefault();
                        if (oRemarks == null)
                        {
                            oRemarks = new EF6.ProductRemarks();
                            oRemarks.ProductRemarksId = Guid.NewGuid();
                            oRemarks.ProductId = productId;

                            ctx.ProductRemarks.Add(oRemarks);
                        }
                        oRemarks.BinX = general.txtBin_X.Text;
                        oRemarks.BinY = general.txtBin_Y.Text;
                        oRemarks.BinZ = general.txtBin_Z.Text;

                        oRemarks.DownloadToShop = general.chkRetailItem.Checked;
                        oRemarks.OffDisplayItem = general.chkOffDisplayItem.Checked;
                        oRemarks.DownloadToCounter = general.chkCounterItem.Checked;

                        oRemarks.REMARK1 = general.txtRemarks1.Text;
                        oRemarks.REMARK2 = general.txtRemarks2.Text;
                        oRemarks.REMARK3 = general.txtRemarks3.Text;
                        oRemarks.REMARK4 = general.txtRemarks4.Text;
                        oRemarks.REMARK5 = general.txtRemarks5.Text;
                        oRemarks.REMARK6 = general.txtRemarks6.Text;

                        oRemarks.Notes = misc.txtMemo.Text;

                        if (string.IsNullOrEmpty(oRemarks.Photo))
                        {
                            oRemarks.Photo = misc.txtPicFileName.Text;
                        }
                        else if (oRemarks.Photo != misc.txtPicFileName.Text)
                        {
                            oRemarks.Photo5 = oRemarks.Photo4;
                            oRemarks.Photo4 = oRemarks.Photo3;
                            oRemarks.Photo3 = oRemarks.Photo2;
                            oRemarks.Photo2 = oRemarks.Photo;
                            oRemarks.Photo = misc.txtPicFileName.Text;
                        }

                        ctx.SaveChanges();
                        #endregion

                        result = productId;

                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                    return result;
                }
            }
        }
        /**
        private void SaveProductCurrentSummary(Guid productId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string where = "ProductId = '" + productId.ToString() + "'";
                var oCurrSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oCurrSummary == null)
                {
                    oCurrSummary = new EF6.ProductCurrentSummary();
                    oCurrSummary.CurrentSummaryId = Guid.NewGuid();
                    oCurrSummary.ProductId = productId;
                    oCurrSummary.CDQTY = 0;
                    oCurrSummary.LastPurchasedOn = new DateTime(1900, 1, 1);
                    oCurrSummary.LastSoldOn = new DateTime(1900, 1, 1);

                    ctx.ProductCurrentSummary.Add(oCurrSummary);
                    ctx.SaveChanges();
                }
            }
        }
        
        private void SaveProductBarcode(RT2020.DAL.Product oItem)
        {
            string stkcode = oItem.STKCODE;

            if (oItem.STKCODE.Length > 10)
            {
                stkcode = oItem.STKCODE.Remove(10);
            }

            using (var ctx = new EF6.RT2020Entities())
            {
                string barcode = stkcode + oItem.APPENDIX1 + oItem.APPENDIX2 + oItem.APPENDIX3;
                //string sql = "ProductId = '" + oItem.ProductId.ToString() + "' AND Barcode = '" + barcode + "'";
                var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == oItem.ProductId && x.Barcode == barcode).FirstOrDefault();
                if (oBarcode == null)
                {
                    oBarcode = new EF6.ProductBarcode();
                    oBarcode.ProductBarcodeId = Guid.NewGuid();
                    oBarcode.ProductId = oItem.ProductId;
                    oBarcode.Barcode = barcode;
                    oBarcode.BarcodeType = "INTER";
                    oBarcode.PrimaryBarcode = true;
                    oBarcode.DownloadToPOS = general.chkRetailItem.Checked;
                    oBarcode.DownloadToCounter = general.chkCounterItem.Checked;

                    ctx.ProductBarcode.Add(oBarcode);
                    ctx.SaveChanges();
                }
            }
        }
        
        private void SaveQtyInfo()
        {
            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(this.ProductId);
            if (oItem != null)
            {
                oItem.MaxOnLoanQty = Convert.ToDecimal((quantity.txtMaxOLNQty.Text == string.Empty) ? "0" : quantity.txtMaxOLNQty.Text);

                oItem.ModifiedBy = ConfigHelper.CurrentUserId;
                oItem.ModifiedOn = DateTime.Now;
                oItem.Save();
            }
        }

        private void SaveOrderInfo()
        {
            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(this.ProductId);
            if (oItem != null)
            {
                oItem.AlternateItem = order.txtVendorItemNum.Text; // Vendor Item Number
                oItem.ReorderLevel = Convert.ToDecimal((order.txtReorderLevel.Text == string.Empty) ? "0" : order.txtReorderLevel.Text);
                oItem.ReorderQty = Convert.ToDecimal((order.txtReorderQuantity.Text == string.Empty) ? "0" : order.txtReorderQuantity.Text);

                oItem.ModifiedBy = ConfigHelper.CurrentUserId;
                oItem.ModifiedOn = DateTime.Now;
                oItem.Save();
            }
        }
        
        private void SaveDiscountInfo()
        {
            SaveProductSupplement(this.ProductId);
        }
        
        private void SaveProductCode(Guid productId, Guid a1Id, Guid a2Id, Guid a3Id, Guid c1Id, Guid c2Id, Guid c3Id, Guid c4Id, Guid c5Id, Guid c6Id)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + productId.ToString() + "'";
                var oCode = ctx.ProductCode.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oCode == null)
                {
                    oCode = new EF6.ProductCode();
                    oCode.CodeId = Guid.NewGuid();
                    oCode.ProductId = productId;
                    oCode.Appendix1Id = a1Id;
                    oCode.Appendix2Id = a2Id;
                    oCode.Appendix3Id = a3Id;

                    ctx.ProductCode.Add(oCode);
                }
                oCode.Class1Id = c1Id;
                oCode.Class2Id = c2Id;
                oCode.Class3Id = c3Id;
                oCode.Class4Id = c4Id;
                oCode.Class5Id = c5Id;
                oCode.Class6Id = c6Id;

                ctx.SaveChanges();
            }
        }
        
        private void SaveProductSupplement(Guid productId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oProdSupp == null)
                {
                    oProdSupp = new EF6.ProductSupplement();
                    oProdSupp.SupplementId = Guid.NewGuid();
                    oProdSupp.ProductId = productId;

                    ctx.ProductSupplement.Add(oProdSupp);
                }
                oProdSupp.VendorCurrencyCode = general.cboVendorCurrency.Text;
                oProdSupp.VendorPrice = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);
                oProdSupp.ProductName_Memo = general.txtMemo.Text;
                oProdSupp.ProductName_Pole = general.txtPole.Text;

                oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((discount.txtDiscount1_FixPriceItem.Text == string.Empty) ? "0" : discount.txtDiscount1_FixPriceItem.Text);
                oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((discount.txtDiscount2_DiscountItem.Text == string.Empty) ? "0" : discount.txtDiscount2_DiscountItem.Text);
                oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((discount.txtDiscount3_NoDiscountItem.Text == string.Empty) ? "0" : discount.txtDiscount3_NoDiscountItem.Text);
                oProdSupp.StaffDiscount = Convert.ToDecimal((discount.txtStaff.Text == string.Empty) ? "0" : discount.txtStaff.Text);

                ctx.SaveChanges();
            }
        }
        
        private void SaveProductPrice(Guid productId)
        {
            SaveProductPrice(productId, ProductHelper.Prices.BASPRC.ToString(), general.txtCurrentRetailCurrency.Text, general.txtCurrentRetailPrice.Text);
            SaveProductPrice(productId, ProductHelper.Prices.ORIPRC.ToString(), general.txtOriginalRetailCurrency.Text, general.txtOriginalRetailPrice.Text);
            SaveProductPrice(productId, ProductHelper.Prices.VPRC.ToString(), general.cboVendorCurrency.Text, general.txtVendorPrice.Text);
            SaveProductPrice(productId, ProductHelper.Prices.WHLPRC.ToString(), general.txtWholesalesCurrency.Text, general.txtWholesalesPrice.Text);
        }

        private void SaveProductPrice(Guid productId, string priceType, string currencyCode, string price)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "ProductId = '" + productId.ToString() + "' AND PriceTypeId = '" + GetPriceType(priceType).ToString() + "'";
                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                var oPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                if (oPrice == null)
                {
                    oPrice = new EF6.ProductPrice();
                    oPrice.ProductPriceId = Guid.NewGuid();
                    oPrice.ProductId = productId;
                    ctx.ProductPrice.Add(oPrice);
                }
                oPrice.PriceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                oPrice.CurrencyCode = currencyCode;
                oPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
                ctx.SaveChanges();
            }
        }
        
        private void SaveProductRemarks(Guid productId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "ProductId = '" + productId.ToString() + "'";
                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oRemarks == null)
                {
                    oRemarks = new EF6.ProductRemarks();
                    oRemarks.ProductRemarksId = Guid.NewGuid();
                    oRemarks.ProductId = productId;

                    ctx.ProductRemarks.Add(oRemarks);
                }
                oRemarks.BinX = general.txtBin_X.Text;
                oRemarks.BinY = general.txtBin_Y.Text;
                oRemarks.BinZ = general.txtBin_Z.Text;

                oRemarks.DownloadToShop = general.chkRetailItem.Checked;
                oRemarks.OffDisplayItem = general.chkOffDisplayItem.Checked;
                oRemarks.DownloadToCounter = general.chkCounterItem.Checked;

                oRemarks.REMARK1 = general.txtRemarks1.Text;
                oRemarks.REMARK2 = general.txtRemarks2.Text;
                oRemarks.REMARK3 = general.txtRemarks3.Text;
                oRemarks.REMARK4 = general.txtRemarks4.Text;
                oRemarks.REMARK5 = general.txtRemarks5.Text;
                oRemarks.REMARK6 = general.txtRemarks6.Text;

                oRemarks.Notes = misc.txtMemo.Text;

                if (string.IsNullOrEmpty(oRemarks.Photo))
                {
                    oRemarks.Photo = misc.txtPicFileName.Text;
                }
                else if (oRemarks.Photo != misc.txtPicFileName.Text)
                {
                    oRemarks.Photo5 = oRemarks.Photo4;
                    oRemarks.Photo4 = oRemarks.Photo3;
                    oRemarks.Photo3 = oRemarks.Photo2;
                    oRemarks.Photo2 = oRemarks.Photo;
                    oRemarks.Photo = misc.txtPicFileName.Text;
                }

                ctx.SaveChanges();
            }
        }
        */
        #endregion

        #endregion

        #region Loading Product Info
        private void LoadProductInfo()
        {
            LoadGeneralInfo();
            //LoadProductRemarks();
            //LoadProductSupplement();
        }

        private void LoadGeneralInfo()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oItem = ctx.Product.Where(x => x.ProductId == this.ProductId).AsNoTracking().FirstOrDefault();
                if (oItem != null)
                {
                    txtStkCode.Text = oItem.STKCODE;
                    cboAppendix1.Text = oItem.APPENDIX1;
                    cboAppendix2.Text = oItem.APPENDIX2;
                    cboAppendix3.Text = oItem.APPENDIX3;
                    /**
                    general.cboClass1.Text = oItem.CLASS1;
                    general.cboClass2.Text = oItem.CLASS2;
                    general.cboClass3.Text = oItem.CLASS3;
                    general.cboClass4.Text = oItem.CLASS4;
                    general.cboClass5.Text = oItem.CLASS5;
                    general.cboClass6.Text = oItem.CLASS6;

                    general.txtProductName.Text = oItem.ProductName;
                    general.txtProductNameChs.Text = oItem.ProductName_Chs;
                    general.txtProductNameCht.Text = oItem.ProductName_Cht;
                    general.txtRemarks.Text = oItem.Remarks;

                    general.txtWholesalesPrice.Text = oItem.WholesalePrice.Value.ToString("n2");
                    general.txtOriginalRetailPrice.Text = oItem.OriginalRetailPrice.Value.ToString("n2");
                    general.txtCurrentRetailPrice.Text = oItem.RetailPrice.Value.ToString("n2");
                    general.txtRetailDiscount.Text = oItem.NormalDiscount.ToString("n2");
                    general.txtUnit.Text = oItem.UOM;
                    general.cboNature.SelectedValue = oItem.NatureId;

                    //discount.chkFixedPrice.Checked = oItem.FixedPriceItem;

                    general.txtStatus_Counter.Text = "";
                    general.txtStatus_Office.Text = "";
                    general.txtCreatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oItem.CreatedOn, false);
                    general.txtModifiedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oItem.ModifiedOn, false);
                    general.txtModifiedBy.Text = ModelEx.StaffEx.GetStaffNumberById(oItem.ModifiedBy);

                    // Quantity Info
                    //quantity.txtMaxOLNQty.Text = oItem.MaxOnLoanQty.ToString("n0");

                    // Order Info
                    //order.txtVendorItemNum.Text = oItem.AlternateItem; // Vendor Item Number
                    //order.txtReorderLevel.Text = oItem.ReorderLevel.ToString("n0");
                    //order.txtReorderQuantity.Text = oItem.ReorderQty.Value.ToString("n0");

                    // Product Price
                    #region LoadProductBasicPrice();
                    //string sql = "ProductId = '" + this.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(ProductHelper.Prices.BASPRC.ToString()) + "'";
                    var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.BASPRC.ToString());
                    var oBPrice = ctx.ProductPrice.Where(x => x.ProductId == this.ProductId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
                    if (oBPrice != null)
                    {
                        general.txtCurrentRetailCurrency.Text = oBPrice.CurrencyCode;
                        general.txtCurrentRetailPrice.Text = oBPrice.Price.Value.ToString("n2");
                    }
                    #endregion

                    #region LoadProductOriginalPrice();
                    priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.ORIPRC.ToString());
                    //string sql = "ProductId = '" + this.ProductId.ToString() + "' AND PriceTypeId = '" + priceTypeId.ToString() + "'";
                    var oOPrice = ctx.ProductPrice.Where(x => x.ProductId == this.ProductId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
                    if (oOPrice != null)
                    {
                        general.txtOriginalRetailCurrency.Text = oOPrice.CurrencyCode;
                        general.txtOriginalRetailPrice.Text = oOPrice.Price.Value.ToString("n2");
                    }
                    #endregion

                    #region LoadProductVendorPrice();
                    //string sql = "ProductId = '" + this.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(ProductHelper.Prices.VPRC.ToString()) + "'";
                    priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.VPRC.ToString());
                    var oVPrice = ctx.ProductPrice.Where(x => x.ProductId == this.ProductId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
                    if (oVPrice != null)
                    {
                        general.cboVendorCurrency.Text = oVPrice.CurrencyCode;
                        general.txtVendorPrice.Text = oVPrice.Price.Value.ToString("n2");
                    }
                    #endregion

                    #region LoadProductWholesalesPrice();
                    //string sql = "ProductId = '" + this.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(ProductHelper.Prices.WHLPRC.ToString()) + "'";
                    priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.WHLPRC.ToString());
                    var oWPrice = ctx.ProductPrice.Where(x => x.ProductId == this.ProductId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
                    if (oWPrice != null)
                    {
                        general.txtWholesalesCurrency.Text = oWPrice.CurrencyCode;
                        general.txtWholesalesPrice.Text = oWPrice.Price.Value.ToString("n2");
                    }
                    #endregion

                    general.txtCurrentRetailPrice.Text = oItem.RetailPrice.Value.ToString("n2");
                    */
                }
            }
        }

        // Product Price
        private void LoadProductSupplement()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + _ProductId.ToString() + "'";
                var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == this._ProductId).AsNoTracking().FirstOrDefault();
                if (oProdSupp != null)
                {
                    general.cboVendorCurrency.Text = oProdSupp.VendorCurrencyCode;
                    general.txtVendorPrice.Text = oProdSupp.VendorPrice.Value.ToString("n2");
                    general.txtMemo.Text = oProdSupp.ProductName_Memo;
                    general.txtPole.Text = oProdSupp.ProductName_Pole;

                    //discount.txtDiscount1_FixPriceItem.Text = oProdSupp.VipDiscount_FixedItem.ToString("n2");
                    //discount.txtDiscount2_DiscountItem.Text = oProdSupp.VipDiscount_DiscountItem.ToString("n2");
                    //discount.txtDiscount3_NoDiscountItem.Text = oProdSupp.VipDiscount_NoDiscountItem.ToString("n2");
                    //discount.txtStaff.Text = oProdSupp.StaffDiscount.ToString("n2");
                }
            }
        }

        // Remarks
        private void LoadProductRemarks()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + _ProductId.ToString() + "'";
                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == _ProductId).AsNoTracking().FirstOrDefault();
                if (oRemarks != null)
                {
                    general.txtBin_X.Text = oRemarks.BinX;
                    general.txtBin_Y.Text = oRemarks.BinY;
                    general.txtBin_Z.Text = oRemarks.BinZ;

                    general.chkRetailItem.Checked = oRemarks.DownloadToShop;
                    general.chkOffDisplayItem.Checked = oRemarks.OffDisplayItem;
                    general.chkCounterItem.Checked = oRemarks.DownloadToCounter;

                    general.txtRemarks1.Text = oRemarks.REMARK1;
                    general.txtRemarks2.Text = oRemarks.REMARK2;
                    general.txtRemarks3.Text = oRemarks.REMARK3;
                    general.txtRemarks4.Text = oRemarks.REMARK4;
                    general.txtRemarks5.Text = oRemarks.REMARK5;
                    general.txtRemarks6.Text = oRemarks.REMARK6;

                    /**
                    misc.txtMemo.Text = oRemarks.Notes;

                    // 2009.12.29 david: 如果为网络路径，则直接显示。
                    string photoPath = Path.Combine(Path.Combine(Context.Config.GetDirectory("RTImages"), "Product"), oRemarks.Photo);
                    try
                    {
                        Uri uri = new Uri(oRemarks.Photo);
                        if (uri.IsUnc)
                        {
                            misc.imgProductPic.ImageName = uri.LocalPath;
                        }
                        else
                        {
                            misc.imgProductPic.ImageName = photoPath;
                        }
                    }
                    catch { }
                    finally
                    {
                        misc.imgProductPic.ImageName = photoPath;
                    }

                    misc.txtPicFileName.Text = oRemarks.Photo;
                    */
                }
            }
        }
        #endregion

        #region Delete a product
        private void Delete()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oProduct = ctx.Product.Find(this.ProductId);
                        if (oProduct != null)
                        {
                            string sql = "ProductId = '" + oProduct.ProductId.ToString() + "'";

                            #region DeleteRemarks(sql);
                            var oRemarksList = ctx.ProductRemarks.Where(x => x.ProductId == oProduct.ProductId);
                            foreach (var oRemarks in oRemarksList)
                            {
                                ctx.ProductRemarks.Remove(oRemarks);

                            }
                            #endregion

                            #region DeleteWorkplace(sql);
                            var oWorkplaceList = ctx.ProductWorkplace.Where(x => x.ProductId == oProduct.ProductId);
                            foreach (var oWorkplace in oWorkplaceList)
                            {
                                ctx.ProductWorkplace.Remove(oWorkplace);
                            }
                            #endregion

                            #region DeleteBarcode(sql);
                            var oBarcodeList = ctx.ProductBarcode.Where(x => x.ProductId == oProduct.ProductId);
                            foreach (var oBarcode in oBarcodeList)
                            {
                                ctx.ProductBarcode.Remove(oBarcode);
                            }
                            #endregion

                            #region DeleteLineOfOperation(sql);
                            var oPrice_LineOfOperationList = ctx.ProductPrice_LineOfOperation.Where(x => x.ProductId == oProduct.ProductId);
                            foreach (var oPrice_LineOfOperation in oPrice_LineOfOperationList)
                            {
                                ctx.ProductPrice_LineOfOperation.Remove(oPrice_LineOfOperation);
                            }
                            #endregion

                            #region DeleteSupplement(sql);
                            var oSupplementList = ctx.ProductSupplement.Where(x => x.ProductId == oProduct.ProductId);
                            foreach (var oSupplement in oSupplementList)
                            {
                                ctx.ProductSupplement.Remove(oSupplement);
                            }
                            #endregion

                            #region DeletePrice(sql);
                            var oPriceList = ctx.ProductPrice.Where(x => x.ProductId == oProduct.ProductId);
                            foreach (var oPrice in oPriceList)
                            {
                                ctx.ProductPrice.Remove(oPrice);
                            }
                            #endregion

                            #region DeleteProductCode(sql);
                            var oCodeList = ctx.ProductCode.Where(x => x.ProductId == oProduct.ProductId);
                            foreach (var oCode in oCodeList)
                            {
                                ctx.ProductCode.Remove(oCode);
                            }
                            #endregion

                            ctx.Product.Remove(oProduct);

                            scope.Commit();

                            // log activity
                            RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, oProduct.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }
        #endregion

        private void tabProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTabPage(tabProduct.SelectedIndex);
        }

        //private void ProductWizard_Closing(object sender, CancelEventArgs e)
        //{
        //    if (tabProduct.SelectedIndex == 0 && this.ProductId == System.Guid.Empty)
        //    {
        //        MessageBox.Show("Save the changes?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
        //    }
        //}

        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    ProductWizard wizard = new ProductWizard();
                    wizard.EditMode = EnumHelper.EditMode.Edit;
                    wizard.ProductId = _ProductId;
                    wizard.ShowDialog();
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                    this.Close();
                    ProductWizard wizard = new ProductWizard();
                    wizard.EditMode = EnumHelper.EditMode.Add;
                    wizard.ShowDialog();
                }
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                    this.Close();
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                this.Close();
            }
        }

        private void cboAppendix3_LostFocus(object sender, EventArgs e)
        {
            general.txtProductName.Focus();
        }
    }
}