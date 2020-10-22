#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;


using System.Windows.Forms;

using RT2020.DAL;
using RT2020.Client.Common;

#endregion

namespace RT2020.Client.Products.Wizard
{
    public partial class ProductWizard : WizardWithTabsBase
    {
        ProductWizard_General general;
        ProductWizard_Barcode barcode;
        ProductWizard_Quantity quantity;
        ProductWizard_Misc misc;
        ProductWizard_Order order;
        ProductWizard_Discount discount;

        private Guid _ProductId = System.Guid.Empty;

        #region Public Properties
        public Guid ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
            }
        }
        #endregion

        public ProductWizard()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                FormChanged = Modified.Clean;

                TabCtrl();
                SetCtrlEditable();
                FillAppendixes();

                SetSystemLabels();
            }
        }

        public ProductWizard(System.Guid productId)
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                this.ProductId = productId;

                TabCtrl();
                SetCtrlEditable();
                //LoadProductInfo();

                SetSystemLabels();
            }
        }

        private void ProductWizard_Load(object sender, EventArgs e)
        {
            ShowHeaderInfo();
            txtStkCode.Select();
            Cursor.Current = Cursors.Default;
        }

        #region Set System label
        private void SetSystemLabels()
        {
            lblStkCode.Text = Utility.GetSystemLabelByKey("STKCODE");
            lblAppendix1.Text = Utility.GetSystemLabelByKey("APPENDIX1");
            lblAppendix2.Text = Utility.GetSystemLabelByKey("APPENDIX2");
            lblAppendix3.Text = Utility.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion

        #region Controls

        #region STKCODE / Appendix
        private void SetCtrlEditable()
        {
            txtStkCode.BackColor = (this.ProductId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtStkCode.Enabled = (this.ProductId == System.Guid.Empty);

            cboAppendix1.BackColor = (this.ProductId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            cboAppendix1.Enabled = (this.ProductId == System.Guid.Empty);

            cboAppendix2.BackColor = (this.ProductId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            cboAppendix2.Enabled = (this.ProductId == System.Guid.Empty);

            cboAppendix3.BackColor = (this.ProductId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            cboAppendix3.Enabled = (this.ProductId == System.Guid.Empty);
        }
        #endregion

        #region Tab
        private void TabCtrl()
        {
            // General
            general = new ProductWizard_General(this.ProductId);
            general.Dock = DockStyle.Fill;
            tpGeneral.Controls.Add(general);

            //// Barcode
            //barcode = new ProductWizard_Barcode(this.ProductId);

            //// Quantity
            //quantity = new ProductWizard_Quantity(this.ProductId);

            //// Misc
            //misc = new ProductWizard_Misc(this.ProductId);

            //// Order
            //order = new ProductWizard_Order(this.ProductId);

            //// Discount
            //discount = new ProductWizard_Discount(this.ProductId);
        }
        #endregion

        #endregion

        #region Appendix
        private void FillAppendixes()
        {
            FillAppendixe1();
            FillAppendixe2();
            FillAppendixe3();
        }

        private void FillAppendixe1()
        {
            //cboAppendix1.Items.Clear();

            //string[] orderBy = new string[] { "Appendix1Code" };
            //ProductAppendix1Collection oA1List = ProductAppendix1.LoadCollection(orderBy, true);
            //oA1List.Add(new ProductAppendix1());
            //cboAppendix1.DataSource = oA1List;
            //cboAppendix1.DisplayMember = "Appendix1Code";
            //cboAppendix1.ValueMember = "Appendix1Id";
            Common.ComboBox.LoadAppendix1(ref cboAppendix1, false);
            cboAppendix1.SelectedIndex = 0;
            cboAppendix1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void FillAppendixe2()
        {
            //cboAppendix2.Items.Clear();

            //string[] orderBy = new string[] { "Appendix2Code" };
            //ProductAppendix2Collection oA2List = ProductAppendix2.LoadCollection(orderBy, true);
            //oA2List.Add(new ProductAppendix2());
            //cboAppendix2.DataSource = oA2List;
            //cboAppendix2.DisplayMember = "Appendix2Code";
            //cboAppendix2.ValueMember = "Appendix2Id";
            Common.ComboBox.LoadAppendix2(ref cboAppendix2, false);
            cboAppendix2.SelectedIndex = 0;
            cboAppendix1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void FillAppendixe3()
        {
            //cboAppendix3.Items.Clear();

            //string[] orderBy = new string[] { "Appendix3Code" };
            //ProductAppendix3Collection oA3List = ProductAppendix3.LoadCollection(orderBy, true);
            //oA3List.Add(new ProductAppendix3());
            //cboAppendix3.DataSource = oA3List;
            //cboAppendix3.DisplayMember = "Appendix3Code";
            //cboAppendix3.ValueMember = "Appendix3Id";
            Common.ComboBox.LoadAppendix3(ref cboAppendix3, false);
            cboAppendix3.SelectedIndex = 0;
            cboAppendix1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        #endregion

        #region Verifications
        private bool VerifyAppendix1()
        {
            if (cboAppendix1.Text.Trim().Length > 0)
            {
                string sql = "Appendix1Code = '" + cboAppendix1.Text.Trim() + "'";
                ProductAppendix1 a1 = ProductAppendix1.LoadWhere(sql);
                if (a1 == null)
                {
                    errorProvider.SetError(cboAppendix1, "The code is invalid! Try to select a value from the list!");
                    return false;
                }
                else
                {
                    errorProvider.SetError(cboAppendix1, string.Empty);
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool VerifyAppendix2()
        {
            if (cboAppendix2.Text.Trim().Length > 0)
            {
                string sql = "Appendix2Code = '" + cboAppendix2.Text.Trim() + "'";
                ProductAppendix2 a2 = ProductAppendix2.LoadWhere(sql);
                if (a2 == null)
                {
                    errorProvider.SetError(cboAppendix2, "The code is invalid! Try to select a value from the list!");
                    return false;
                }
                else
                {
                    errorProvider.SetError(cboAppendix2, string.Empty);
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool VerifyAppendix3()
        {
            if (cboAppendix3.Text.Trim().Length > 0)
            {
                string sql = "Appendix3Code = '" + cboAppendix3.Text.Trim() + "'";
                ProductAppendix3 a3 = ProductAppendix3.LoadWhere(sql);
                if (a3 == null)
                {
                    errorProvider.SetError(cboAppendix3, "The code is invalid! Try to select a value from the list!");
                    return false;
                }
                else
                {
                    errorProvider.SetError(cboAppendix3, string.Empty);
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool VerifyAppendix()
        {
            bool result = true;

            result = result & VerifyAppendix1();
            result = result & VerifyAppendix2();
            result = result & VerifyAppendix3();
            if (_ProductId == Guid.Empty) result = !VerifyDuplicated();
            return result;
        }

        private bool Verify()
        {
            if (txtStkCode.Text == string.Empty)
            {
                errorProvider.SetError(txtStkCode, "Can not be blank!");
                return false;
            }
            else if (!VerifyAppendix())
            {
                return false;
            }
            else
            {
                errorProvider.SetError(txtStkCode, string.Empty);
                return true;
            }
        }

        private bool VerifyDuplicated()
        {
            string sql = "STKCODE = '" + txtStkCode.Text + "' AND APPENDIX1 = '" + cboAppendix1.Text + "' AND APPENDIX2 = '" + cboAppendix2.Text + "' AND APPENDIX3 = '" + cboAppendix3.Text + "'";
            RT2020.DAL.Product oItem = RT2020.DAL.Product.LoadWhere(sql);
            if (oItem != null)
            {
                MessageBox.Show("Duplicated Code (Stock Code + Appendix 1 + Appendix 2 + Appendix 3)!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Save Product Info
        private bool Save()
        {
            bool result = false;

            if (Verify())
            {
                Cursor.Current = Cursors.WaitCursor;
                #region 2013.12.22 paulus: 舊 code，唔再用
                //this.ProductId = SaveGeneralInfo();
                //if (this.ProductId != System.Guid.Empty)
                //{
                //    SaveProductCurrentSummary(this.ProductId);

                //    SaveQtyInfo();
                //    SaveOrderInfo();
                //    SaveDiscountInfo();

                //    result = true;
                //}
                #endregion
                if (_ProductId == Guid.Empty)
                {
                    SaveAsNewProduct();
                }
                else
                {
                    DAL.Product oProduct = DAL.Product.Load(_ProductId);
                    oProduct.Status = Convert.ToInt32(RT2020.DAL.Common.Enums.Status.Modified.ToString("d"));
                    oProduct.ModifiedBy = RT2020.DAL.Common.Config.CurrentUserId;
                    oProduct.ModifiedOn = DateTime.Now;
                    oProduct.Save();
                }
                if (_ProductId != Guid.Empty)
                {
                    general.SaveRec(_ProductId);

                    if (tpQty.Contains(quantity)) quantity.SaveRec(_ProductId);
                    if (tpMisc.Contains(misc)) misc.SaveRec(_ProductId);
                    if (tpOrder.Contains(order)) order.SaveRec(_ProductId);
                    if (tpDiscount.Contains(discount)) discount.SaveRec(_ProductId);
                    result = true;
                }
                Cursor.Current = Cursors.Default;
            }

            return result;
        }

        private bool SaveAsNewProduct()
        {
            bool result = true;

            #region prepare dbo.Product
            DAL.Product oProduct = new Product();

            oProduct.ProductId = Guid.NewGuid();
            oProduct.STKCODE = txtStkCode.Text.Trim();
            oProduct.APPENDIX1 = cboAppendix1.Text.Trim();
            oProduct.APPENDIX2 = cboAppendix2.Text.Trim();
            oProduct.APPENDIX3 = cboAppendix3.Text.Trim();

            oProduct.Status = (int)RT2020.DAL.Common.Enums.Status.Active;
            oProduct.CreatedBy = RT2020.DAL.Common.Config.CurrentUserId;
            oProduct.CreatedOn = DateTime.Now;

            oProduct.Save();
            #endregion

            #region prepare dbo.ProductCode
            DAL.ProductCode oProductCode = new DAL.ProductCode();
            oProductCode.ProductId = oProduct.ProductId;
            oProductCode.Appendix1Id = (Guid)cboAppendix1.SelectedValue;
            oProductCode.Appendix2Id = (Guid)cboAppendix2.SelectedValue;
            oProductCode.Appendix3Id = (Guid)cboAppendix3.SelectedValue;
            oProductCode.Save();
            #endregion

            _ProductId = oProduct.ProductId;

            return result;
        }

        private Guid SaveGeneralInfo()
        {
            bool isNew = false;

            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(this.ProductId);
            if (oItem == null)
            {
                oItem = new RT2020.DAL.Product();

                oItem.STKCODE = txtStkCode.Text.Trim();
                oItem.APPENDIX1 = cboAppendix1.Text.Trim();
                oItem.APPENDIX2 = cboAppendix2.Text.Trim();
                oItem.APPENDIX3 = cboAppendix3.Text.Trim();

                oItem.Status = (int)RT2020.DAL.Common.Enums.Status.Active;
                isNew = true;

                oItem.CreatedBy = RT2020.DAL.Common.Config.CurrentUserId;
                oItem.CreatedOn = DateTime.Now;

                if (VerifyDuplicated())
                {
                    return System.Guid.Empty;
                }
            }

            oItem.CLASS1 = general.cboClass1.Text;
            oItem.CLASS2 = general.cboClass2.Text;
            oItem.CLASS3 = general.cboClass3.Text;
            oItem.CLASS4 = general.cboClass4.Text;
            oItem.CLASS5 = general.cboClass5.Text;
            oItem.CLASS6 = general.cboClass6.Text;

            oItem.ProductName = general.txtProductName.Text;
            oItem.ProductName_Chs = general.txtProductNameChs.Text;
            oItem.ProductName_Cht = general.txtProductNameCht.Text;
            oItem.Remarks = general.txtRemarks.Text;

            oItem.NormalDiscount = Convert.ToDecimal((general.txtRetailDiscount.Text == string.Empty) ? "0" : general.txtRetailDiscount.Text);
            oItem.UOM = general.txtUnit.Text;
            oItem.NatureId = new Guid(general.cboNature.SelectedValue.ToString());

            oItem.FixedPriceItem = discount.chkFixedPrice.Checked;

            // Price 
            oItem.RetailPrice = Convert.ToDecimal((general.txtCurrentRetailPrice.Text == string.Empty) ? "0" : general.txtCurrentRetailPrice.Text);
            oItem.WholesalePrice = Convert.ToDecimal((general.txtWholesalesPrice.Text == string.Empty) ? "0" : general.txtWholesalesPrice.Text);
            oItem.OriginalRetailPrice = Convert.ToDecimal((general.txtOriginalRetailPrice.Text == string.Empty) ? "0" : general.txtOriginalRetailPrice.Text);
            //oItem.Markup = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);

            // Download Packets
            oItem.DownloadToPOS = general.chkRetailItem.Checked;
            oItem.DownloadToCounter = general.chkCounterItem.Checked;

            // If the item existed, change the status to Modified.
            if (!isNew)
            {
                oItem.Status = Convert.ToInt32(RT2020.DAL.Common.Enums.Status.Modified.ToString("d"));
            }

            oItem.ModifiedBy = RT2020.DAL.Common.Config.CurrentUserId;
            oItem.ModifiedOn = DateTime.Now;
            oItem.Save();

            SaveProductBarcode(oItem);

            // Appendix / Class
            System.Guid a1Id = (cboAppendix1.SelectedValue != null) ? new Guid(cboAppendix1.SelectedValue.ToString()) : System.Guid.Empty;
            System.Guid a2Id = (cboAppendix2.SelectedValue != null) ? new Guid(cboAppendix2.SelectedValue.ToString()) : System.Guid.Empty;
            System.Guid a3Id = (cboAppendix3.SelectedValue != null) ? new Guid(cboAppendix3.SelectedValue.ToString()) : System.Guid.Empty;

            System.Guid c1Id = (general.cboClass1.SelectedValue != null) ? new Guid(general.cboClass1.SelectedValue.ToString()) : System.Guid.Empty;
            System.Guid c2Id = (general.cboClass2.SelectedValue != null) ? new Guid(general.cboClass2.SelectedValue.ToString()) : System.Guid.Empty;
            System.Guid c3Id = (general.cboClass3.SelectedValue != null) ? new Guid(general.cboClass3.SelectedValue.ToString()) : System.Guid.Empty;
            System.Guid c4Id = (general.cboClass4.SelectedValue != null) ? new Guid(general.cboClass4.SelectedValue.ToString()) : System.Guid.Empty;
            System.Guid c5Id = (general.cboClass5.SelectedValue != null) ? new Guid(general.cboClass5.SelectedValue.ToString()) : System.Guid.Empty;
            System.Guid c6Id = (general.cboClass6.SelectedValue != null) ? new Guid(general.cboClass6.SelectedValue.ToString()) : System.Guid.Empty;
            SaveProductCode(oItem.ProductId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);

            // Product Barcode
            barcode.AddBarcode();

            // Product Price
            SaveProductSupplement(oItem.ProductId);
            SaveProductPrice(oItem.ProductId);

            // Remarks
            SaveProductRemarks(oItem.ProductId);

            return oItem.ProductId;
        }

        private void SaveProductCurrentSummary(Guid productId)
        {
            string where = "ProductId = '" + productId.ToString() + "'";
            ProductCurrentSummary oCurrSummary = ProductCurrentSummary.LoadWhere(where);
            if (oCurrSummary == null)
            {
                oCurrSummary = new ProductCurrentSummary();
                oCurrSummary.ProductId = productId;
                oCurrSummary.CDQTY = 0;
                oCurrSummary.LastPurchasedOn = new DateTime(1900, 1, 1);
                oCurrSummary.LastSoldOn = new DateTime(1900, 1, 1);
                oCurrSummary.Save();
            }
        }

        private void SaveProductBarcode(RT2020.DAL.Product oItem)
        {
            string stkcode = oItem.STKCODE;

            if (oItem.STKCODE.Length > 10)
            {
                stkcode = oItem.STKCODE.Remove(10);
            }

            string barcode = stkcode + oItem.APPENDIX1 + oItem.APPENDIX2 + oItem.APPENDIX3;
            string sql = "ProductId = '" + oItem.ProductId.ToString() + "' AND Barcode = '" + barcode + "'";
            ProductBarcode oBarcode = ProductBarcode.LoadWhere(sql);
            if (oBarcode == null)
            {
                oBarcode = new ProductBarcode();
                oBarcode.ProductId = oItem.ProductId;
                oBarcode.Barcode = barcode;
                oBarcode.BarcodeType = "INTER";
                oBarcode.PrimaryBarcode = true;
                oBarcode.DownloadToPOS = general.chkRetailItem.Checked;
                oBarcode.DownloadToCounter = general.chkCounterItem.Checked;

                oBarcode.Save();
            }
        }

        private void SaveQtyInfo()
        {
            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(this.ProductId);
            if (oItem != null)
            {
                oItem.MaxOnLoanQty = Convert.ToDecimal((quantity.txtMaxOLNQty.Text == string.Empty) ? "0" : quantity.txtMaxOLNQty.Text);

                oItem.ModifiedBy = RT2020.DAL.Common.Config.CurrentUserId;
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

                oItem.ModifiedBy = RT2020.DAL.Common.Config.CurrentUserId;
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
            string sql = "ProductId = '" + productId.ToString() + "'";
            ProductCode oCode = ProductCode.LoadWhere(sql);
            if (oCode == null)
            {
                oCode = new ProductCode();

                oCode.ProductId = productId;
                oCode.Appendix1Id = a1Id;
                oCode.Appendix2Id = a2Id;
                oCode.Appendix3Id = a3Id;
            }
            oCode.Class1Id = c1Id;
            oCode.Class2Id = c2Id;
            oCode.Class3Id = c3Id;
            oCode.Class4Id = c4Id;
            oCode.Class5Id = c5Id;
            oCode.Class6Id = c6Id;
            oCode.Save();
        }

        private void SaveProductSupplement(Guid productId)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";
            ProductSupplement oProdSupp = ProductSupplement.LoadWhere(sql);
            if (oProdSupp == null)
            {
                oProdSupp = new ProductSupplement();

                oProdSupp.ProductId = productId;
            }
            oProdSupp.VendorCurrencyCode = general.cboVendorCurrency.Text;
            oProdSupp.VendorPrice = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);
            oProdSupp.ProductName_Memo = general.txtMemo.Text;
            oProdSupp.ProductName_Pole = general.txtPole.Text;

            oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((discount.txtDiscount1_FixPriceItem.Text == string.Empty) ? "0" : discount.txtDiscount1_FixPriceItem.Text);
            oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((discount.txtDiscount2_DiscountItem.Text == string.Empty) ? "0" : discount.txtDiscount2_DiscountItem.Text);
            oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((discount.txtDiscount3_NoDiscountItem.Text == string.Empty) ? "0" : discount.txtDiscount3_NoDiscountItem.Text);
            oProdSupp.StaffDiscount = Convert.ToDecimal((discount.txtStaff.Text == string.Empty) ? "0" : discount.txtStaff.Text);

            oProdSupp.Save();
        }

        private void SaveProductPrice(Guid productId)
        {
            SaveProductPrice(productId, RT2020.DAL.Common.Enums.ProductPriceType.BASPRC.ToString(), general.txtCurrentRetailCurrency.Text, general.txtCurrentRetailPrice.Text);
            SaveProductPrice(productId, RT2020.DAL.Common.Enums.ProductPriceType.ORIPRC.ToString(), general.txtOriginalRetailCurrency.Text, general.txtOriginalRetailPrice.Text);
            SaveProductPrice(productId, RT2020.DAL.Common.Enums.ProductPriceType.VPRC.ToString(), general.cboVendorCurrency.Text, general.txtVendorPrice.Text);
            SaveProductPrice(productId, RT2020.DAL.Common.Enums.ProductPriceType.WHLPRC.ToString(), general.txtWholesalesCurrency.Text, general.txtWholesalesPrice.Text);
        }

        private void SaveProductPrice(Guid productId, string priceType, string currencyCode, string price)
        {
            string sql = "ProductId = '" + productId.ToString() + "' AND PriceTypeId = '" + GetPriceType(priceType).ToString() + "'";
            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice == null)
            {
                oPrice = new ProductPrice();

                oPrice.ProductId = productId;
            }
            oPrice.PriceTypeId = GetPriceType(priceType);
            oPrice.CurrencyCode = currencyCode;
            oPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
            oPrice.Save();
        }

        private Guid GetPriceType(string priceType)
        {
            string sql = "PriceType = '" + priceType + "'";
            DAL.ProductPriceType oType = DAL.ProductPriceType.LoadWhere(sql);
            if (oType == null)
            {
                oType = new DAL.ProductPriceType();

                oType.PriceType = priceType;
                oType.CurrencyCode = "HKD";
                oType.CoreSystemPrice = false;

                oType.Save();
            }
            return oType.PriceTypeId;
        }

        private void SaveProductRemarks(Guid productId)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";
            ProductRemarks oRemarks = ProductRemarks.LoadWhere(sql);
            if (oRemarks == null)
            {
                oRemarks = new ProductRemarks();

                oRemarks.ProductId = productId;
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

            oRemarks.Save();
        }
        #endregion

        private void ShowHeaderInfo()
        {
            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(_ProductId);
            if (oItem != null)
            {
                txtStkCode.Text = oItem.STKCODE;
                cboAppendix1.Text = oItem.APPENDIX1;
                cboAppendix2.Text = oItem.APPENDIX2;
                cboAppendix3.Text = oItem.APPENDIX3;
            }
        }

        //2013.12.22 paulus: 唔再用，改用每個 tab 入面自己嘅 code，當 user 點選時才 show 啲資料，增快 Wizard 嘅 loading time
        #region Loading Product Info
        private void LoadProductInfo()
        {
            LoadGeneralInfo();
            LoadProductRemarks();
            LoadProductSupplement();
        }

        private void LoadGeneralInfo()
        {
            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(this.ProductId);
            if (oItem != null)
            {
                txtStkCode.Text = oItem.STKCODE;
                cboAppendix1.Text = oItem.APPENDIX1;
                cboAppendix2.Text = oItem.APPENDIX2;
                cboAppendix3.Text = oItem.APPENDIX3;

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

                general.txtRetailDiscount.Text = oItem.NormalDiscount.ToString("n2");
                general.txtUnit.Text = oItem.UOM;
                general.cboNature.SelectedValue = oItem.NatureId;

                //discount.chkFixedPrice.Checked = oItem.FixedPriceItem;

                general.txtStatus_Counter.Text = "";
                general.txtStatus_Office.Text = "";
                general.txtCreatedOn.Text = DateTimeHelper.DateTimeToString(oItem.CreatedOn, false);
                general.txtModifiedOn.Text = DateTimeHelper.DateTimeToString(oItem.ModifiedOn, false);
                general.txtModifiedBy.Text = GetStaffName(oItem.ModifiedBy);

                // Quantity Info
                //quantity.txtMaxOLNQty.Text = oItem.MaxOnLoanQty.ToString("n0");

                // Order Info
                //order.txtVendorItemNum.Text = oItem.AlternateItem; // Vendor Item Number
                //order.txtReorderLevel.Text = oItem.ReorderLevel.ToString("n0");
                //order.txtReorderQuantity.Text = oItem.ReorderQty.ToString("n0");

                // Product Price
                LoadProductPrice();

                general.txtCurrentRetailPrice.Text = oItem.RetailPrice.ToString("n2");
            }
        }

        private string GetStaffName(Guid staffId)
        {
            RT2020.DAL.Staff oStaff = RT2020.DAL.Staff.Load(staffId);
            if (oStaff != null)
            {
                return oStaff.StaffNumber;
            }
            else
            {
                return string.Empty;
            }
        }

        // Product Price
        private void LoadProductSupplement()
        {
            string sql = "ProductId = '" + _ProductId.ToString() + "'";
            ProductSupplement oProdSupp = ProductSupplement.LoadWhere(sql);
            if (oProdSupp != null)
            {
                general.cboVendorCurrency.Text = oProdSupp.VendorCurrencyCode;
                general.txtVendorPrice.Text = oProdSupp.VendorPrice.ToString("n2");
                general.txtMemo.Text = oProdSupp.ProductName_Memo;
                general.txtPole.Text = oProdSupp.ProductName_Pole;

                //discount.txtDiscount1_FixPriceItem.Text = oProdSupp.VipDiscount_FixedItem.ToString("n2");
                //discount.txtDiscount2_DiscountItem.Text = oProdSupp.VipDiscount_DiscountItem.ToString("n2");
                //discount.txtDiscount3_NoDiscountItem.Text = oProdSupp.VipDiscount_NoDiscountItem.ToString("n2");
                //discount.txtStaff.Text = oProdSupp.StaffDiscount.ToString("n2");
            }
        }

        private void LoadProductPrice()
        {
            LoadProductBasicPrice();
            LoadProductOriginalPrice();
            LoadProductVendorPrice();
            LoadProductWholesalesPrice();
        }

        private void LoadProductBasicPrice()
        {
            string sql = "ProductId = '" + this.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(DAL.Common.Enums.ProductPriceType.BASPRC.ToString()) + "'";
            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice != null)
            {
                general.txtCurrentRetailCurrency.Text = oPrice.CurrencyCode;
                general.txtCurrentRetailPrice.Text = oPrice.Price.ToString("n2");
            }
        }

        private void LoadProductOriginalPrice()
        {
            string sql = "ProductId = '" + this.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(DAL.Common.Enums.ProductPriceType.ORIPRC.ToString()) + "'";
            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice != null)
            {
                general.txtOriginalRetailCurrency.Text = oPrice.CurrencyCode;
                general.txtOriginalRetailPrice.Text = oPrice.Price.ToString("n2");
            }
        }

        private void LoadProductVendorPrice()
        {
            string sql = "ProductId = '" + this.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(DAL.Common.Enums.ProductPriceType.VPRC.ToString()) + "'";
            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice != null)
            {
                general.cboVendorCurrency.Text = oPrice.CurrencyCode;
                general.txtVendorPrice.Text = oPrice.Price.ToString("n2");
            }
        }

        private void LoadProductWholesalesPrice()
        {
            string sql = "ProductId = '" + this.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(DAL.Common.Enums.ProductPriceType.WHLPRC.ToString()) + "'";
            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice != null)
            {
                general.txtWholesalesCurrency.Text = oPrice.CurrencyCode;
                general.txtWholesalesPrice.Text = oPrice.Price.ToString("n2");
            }
        }

        // Remarks
        private void LoadProductRemarks()
        {
            string sql = "ProductId = '" + _ProductId.ToString() + "'";
            ProductRemarks oRemarks = ProductRemarks.LoadWhere(sql);
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

                //misc.txtMemo.Text = oRemarks.Notes;

                // 2009.12.29 david: 如果为网络路径，则直接显示。
                //string photoPath = Path.Combine(Path.Combine(Context.Config.GetDirectory("RTImages"), "Product"), oRemarks.Photo);
                //try
                //{
                //    Uri uri = new Uri(oRemarks.Photo);
                //    if (uri.IsUnc)
                //    {
                //        misc.imgProductPic.ImageName = uri.LocalPath;
                //    }
                //    else
                //    {
                //        misc.imgProductPic.ImageName = photoPath;
                //    }
                //}
                //catch { }
                //finally
                //{
                //    misc.imgProductPic.ImageName = photoPath;
                //}

                //misc.txtPicFileName.Text = oRemarks.Photo;
            }
        }
        #endregion

        #region Delete a product
        private void Delete()
        {
            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(this.ProductId);
            if (oItem != null)
            {
                string sql = "ProductId = '" + oItem.ProductId.ToString() + "'";

                DeleteRemarks(sql);
                DeleteWorkplace(sql);
                DeleteBarcode(sql);
                DeleteLineOfOperation(sql);
                DeleteSupplement(sql);
                DeletePrice(sql);
                DeleteProductCode(sql);

                oItem.Delete();
            }
            else
            {
                MessageBox.Show("Please sure the product info you want to delete is valid!");
            }
        }

        private void DeleteRemarks(string sql)
        {
            ProductRemarksCollection oRemarksList = ProductRemarks.LoadCollection(sql);
            foreach (ProductRemarks oRemarks in oRemarksList)
            {
                oRemarks.Delete();
            }
        }

        private void DeleteWorkplace(string sql)
        {
            ProductWorkplaceCollection oWorkplaceList = ProductWorkplace.LoadCollection(sql);
            foreach (ProductWorkplace oWorkplace in oWorkplaceList)
            {
                oWorkplace.Delete();
            }
        }

        private void DeleteBarcode(string sql)
        {
            ProductBarcodeCollection oBarcodeList = ProductBarcode.LoadCollection(sql);
            foreach (ProductBarcode oBarcode in oBarcodeList)
            {
                oBarcode.Delete();
            }
        }

        private void DeleteLineOfOperation(string sql)
        {
            ProductPrice_LineOfOperationCollection oPrice_LineOfOperationList = ProductPrice_LineOfOperation.LoadCollection(sql);
            foreach (ProductPrice_LineOfOperation oPrice_LineOfOperation in oPrice_LineOfOperationList)
            {
                oPrice_LineOfOperation.Delete();
            }
        }

        private void DeleteSupplement(string sql)
        {
            ProductSupplementCollection oSupplementList = ProductSupplement.LoadCollection(sql);
            foreach (ProductSupplement oSupplement in oSupplementList)
            {
                oSupplement.Delete();
            }
        }

        private void DeletePrice(string sql)
        {
            ProductPriceCollection oPriceList = ProductPrice.LoadCollection(sql);
            foreach (ProductPrice oPrice in oPriceList)
            {
                oPrice.Delete();
            }
        }

        private void DeleteProductCode(string sql)
        {
            ProductCodeCollection oCodeList = ProductCode.LoadCollection(sql);
            foreach (ProductCode oCode in oCodeList)
            {
                oCode.Delete();
            }
        }
        #endregion

        private void tabProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //2013.12.18 paulus: Opera 要求准許輸入其他資料才 Save
            //if (tabProduct.SelectedIndex != 0 && this.ProductId == System.Guid.Empty)
            //{
            //    MessageBox.Show("Please save new record before you go to other tab!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tabProduct.SelectedIndex = 0;
            //}

            switch (tabProduct.SelectedIndex)
            {
                case 0: break;
                case 1: // Barcode
                    if (!(tpBarcode.Contains(barcode)))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        barcode = new ProductWizard_Barcode(this.ProductId); 
                        barcode.Dock = DockStyle.Fill;
                        tpBarcode.Controls.Add(barcode);
                        Cursor.Current = Cursors.Default;
                    }
                    break;
                case 2: // Quantity
                    if (!(tpQty.Contains(quantity)))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        quantity = new ProductWizard_Quantity(this.ProductId);
                        quantity.Dock = DockStyle.Fill;
                        //quantity.ProductId = this.ProductId;
                        tpQty.Controls.Add(quantity);
                        Cursor.Current = Cursors.Default;
                    }
                    break;
                case 3: // Misc
                    if (!(tpMisc.Contains(misc)))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        misc = new ProductWizard_Misc(this.ProductId);
                        misc.Dock = DockStyle.Fill;
                        //misc.ProductId = this.ProductId;
                        tpMisc.Controls.Add(misc);
                        Cursor.Current = Cursors.Default;
                    }
                    break;
                case 4: // Order
                    if (!(tpOrder.Contains(order)))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        order = new ProductWizard_Order(this.ProductId);
                        order.Dock = DockStyle.Fill;
                        //order.ProductId = this.ProductId;
                        tpOrder.Controls.Add(order);
                        Cursor.Current = Cursors.Default;
                    }
                    break;
                case 5: // Discount
                    if (!(tpDiscount.Contains(discount)))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        discount = new ProductWizard_Discount(this.ProductId);
                        discount.Dock = DockStyle.Fill;
                        //discount.ProductId = this.ProductId;
                        tpDiscount.Controls.Add(discount);
                        Cursor.Current = Cursors.Default;
                    }
                    break;
            }
        }

        #region Form Toolbar Events

        protected override void cmdDelete_Click(object sender, EventArgs e)
        {
            //base.cmdDelete_Click(sender, e);
            if (MessageBox.Show("Delete Record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Delete();

                FormChanged = Modified.Clean;

                this.Close();
            }
        }

        protected override void cmdSave_Click(object sender, EventArgs e)
        {
            //base.cmdSave_Click(sender, e);
            if (MessageBox.Show("Save Record ?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (Save())
                    {
                        FormChanged = Modified.Clean;

                        MessageBox.Show("Successfully Save", "Result");

                        this.SetCtrlEditable();
                        //this.LoadProductInfo();
                    }
                }
                else
                {
                    MessageBox.Show("Readonly transaction cannot be modified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected override void cmdSaveClose_Click(object sender, EventArgs e)
        {
            //base.cmdSaveClose_Click(sender, e);
            if (MessageBox.Show("Save Record, then close the wizard?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (Save())
                    {
                        FormChanged = Modified.Clean;

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Readonly transaction cannot be modified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected override void cmdSaveNew_Click(object sender, EventArgs e)
        {
            //base.cmdSaveNew_Click(sender, e);
            if (MessageBox.Show("Save Record, then open a new wizard?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (Save())
                    {
                        FormChanged = Modified.Clean;

                        this.Close();
                        ProductWizard wizard = new ProductWizard();
                        wizard.ProductId = Guid.Empty;
                        wizard.EditMode = Mode.New;
                        wizard.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Readonly transaction cannot be modified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion
    }
}