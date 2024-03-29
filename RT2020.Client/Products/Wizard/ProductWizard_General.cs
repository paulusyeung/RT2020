#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


using System.Windows.Forms;
using RT2020.DAL;
using RT2020.Client.Common;

#endregion

namespace RT2020.Client.Products .Wizard
{
    public partial class ProductWizard_General : UserControl
    {
        private Guid _ProductId = System.Guid.Empty;

        #region Properties
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

        public ProductWizard_General(Guid productId)
        {
            InitializeComponent();

            FillList();
            SetSystemLabels();

            if (productId != System.Guid.Empty)
            {
                this.ProductId = productId;
                ShowGeneralInfo();
            }
        }

        #region Set System label
        private void SetSystemLabels()
        {
            lblClass1.Text = Utility.GetSystemLabelByKey("CLASS1");
            lblClass2.Text = Utility.GetSystemLabelByKey("CLASS2");
            lblClass3.Text = Utility.GetSystemLabelByKey("CLASS3");
            lblClass4.Text = Utility.GetSystemLabelByKey("CLASS4");
            lblClass5.Text = Utility.GetSystemLabelByKey("CLASS5");
            lblClass6.Text = Utility.GetSystemLabelByKey("CLASS6");

            lblRemarks1.Text = Utility.GetSystemLabelByKey("REMARK1");
            lblRemarks2.Text = Utility.GetSystemLabelByKey("REMARK2");
            lblRemarks3.Text = Utility.GetSystemLabelByKey("REMARK3");
            lblRemarks4.Text = Utility.GetSystemLabelByKey("REMARK4");
            lblRemarks5.Text = Utility.GetSystemLabelByKey("REMARK5");
            lblRemarks6.Text = Utility.GetSystemLabelByKey("REMARK6");
        }
        #endregion

        #region Binding List
        private void FillList()
        {
            FillClasses();
            FillNatureList();
            FillCurrencyList();
        }

        #region Class
        private void FillClasses()
        {
            FillClass1();
            FillClass2();
            FillClass3();
            FillClass4();
            FillClass5();
            FillClass6();
        }

        private void FillClass1()
        {
            //cboClass1.Items.Clear();

            //string[] orderBy = new string[] { "Class1Code" };
            //ProductClass1Collection oC1List = ProductClass1.LoadCollection(orderBy, true);
            //oC1List.Add(new ProductClass1());
            //cboClass1.DataSource = oC1List;
            //cboClass1.DisplayMember = "Class1Code";
            //cboClass1.ValueMember = "Class1Id";
            Common.ComboBox.LoadClass1(ref cboClass1, false);
        }

        private void FillClass2()
        {
            //cboClass2.Items.Clear();

            //string[] orderBy = new string[] { "Class2Code" };
            //ProductClass2Collection oC2List = ProductClass2.LoadCollection(orderBy, true);
            //oC2List.Add(new ProductClass2());
            //cboClass2.DataSource = oC2List;
            //cboClass2.DisplayMember = "Class2Code";
            //cboClass2.ValueMember = "Class2Id";
            Common.ComboBox.LoadClass2(ref cboClass2, false);
        }

        private void FillClass3()
        {
            //cboClass3.Items.Clear();

            //string[] orderBy = new string[] { "Class3Code" };
            //ProductClass3Collection oC3List = ProductClass3.LoadCollection(orderBy, true);
            //oC3List.Add(new ProductClass3());
            //cboClass3.DataSource = oC3List;
            //cboClass3.DisplayMember = "Class3Code";
            //cboClass3.ValueMember = "Class3Id";
            Common.ComboBox.LoadClass3(ref cboClass3, false);
        }

        private void FillClass4()
        {
            //cboClass4.Items.Clear();

            //string[] orderBy = new string[] { "Class4Code" };
            //ProductClass4Collection oC4List = ProductClass4.LoadCollection(orderBy, true);
            //oC4List.Add(new ProductClass4());
            //cboClass4.DataSource = oC4List;
            //cboClass4.DisplayMember = "Class4Code";
            //cboClass4.ValueMember = "Class4Id";
            Common.ComboBox.LoadClass4(ref cboClass4, false);
        }
            
        private void FillClass5()
        {
            //cboClass5.Items.Clear();

            //string[] orderBy = new string[] { "Class5Code" };
            //ProductClass5Collection oC5List = ProductClass5.LoadCollection(orderBy, true);
            //oC5List.Add(new ProductClass5());
            //cboClass5.DataSource = oC5List;
            //cboClass5.DisplayMember = "Class5Code";
            //cboClass5.ValueMember = "Class5Id";
            Common.ComboBox.LoadClass5(ref cboClass5, false);
        }
        
        private void FillClass6()
        {
            //cboClass6.Items.Clear();

            //string[] orderBy = new string[] { "Class6Code" };
            //ProductClass6Collection oC6List = ProductClass6.LoadCollection(orderBy, true);
            //oC6List.Add(new ProductClass6());
            //cboClass6.DataSource = oC6List;
            //cboClass6.DisplayMember = "Class6Code";
            //cboClass6.ValueMember = "Class6Id";
            Common.ComboBox.LoadClass6(ref cboClass6, false);
        }
        #endregion

        private void FillNatureList()
        {
            ProductNatureList natureList = new ProductNatureList();
            cboNature.Items.Clear();

            string[] orderBy = new string[] { "NatureCode" };
            ProductNatureCollection oNatureList = ProductNature.LoadCollection(orderBy, true);
            foreach (ProductNature nature in oNatureList)
            {
                natureList.Add(new ProductNatureRec(nature.NatureId, nature.NatureCode + " - " + nature.NatureName));
            }

            cboNature.DataSource = natureList;
            cboNature.DisplayMember = "ProductNatureCode";
            cboNature.ValueMember = "ProductNatureId";

            cboNature.SelectedIndex = 1;    //default N - Normal
        }

        #region ComboBox Binding Class
        public class ProductNatureRec
        {
            Guid prodNatureId = System.Guid.Empty;
            string natureCode = string.Empty;

            public ProductNatureRec(Guid pNId, string sCode)
            {
                prodNatureId = pNId;
                natureCode = sCode;
            }

            public Guid ProductNatureId
            {
                get { return prodNatureId; }
                set { prodNatureId = value; }
            }

            public string ProductNatureCode
            {
                get { return natureCode; }
                set { natureCode = value; }
            }
        }

        public class ProductNatureList : BindingList<ProductNatureRec>
        {
        }
        #endregion

        #region Fill cboVendorCurrency
        private void FillCurrencyList()
        {
            cboVendorCurrency.Items.Clear();

            string[] orderBy = new string[] { "CurrencyCode" };
            CurrencyCollection oCnyList = Currency.LoadCollection(orderBy, true);

            //cboVendorCurrency.DataSource = oCnyList;
            //cboVendorCurrency.DisplayMember = "CurrencyCode";
            //cboVendorCurrency.ValueMember = "CurrencyId";

            if (oCnyList.Count > 0)
            {
                cboVendorCurrency.Items.Add(new ComboboxItem(String.Empty, String.Empty));
                foreach (Currency item in oCnyList)
                {
                    cboVendorCurrency.Items.Add(new ComboboxItem(item.CurrencyId.ToString(), item.CurrencyCode));
                }
            }
        }

        class ComboboxItem
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public ComboboxItem(string key, string value)
            {
                Key = key; Value = value;
            }
            public override string ToString()
            {
                return Value;
            }
        }
        #endregion
        #endregion

        #region Show General Info
        private void ShowGeneralInfo()
        {
            ShowProductInfo();
            ShowProductPrice();

            ShowProductSupplement();
            ShowProductRemarks();
        }

        private void ShowProductInfo()
        {
            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(_ProductId);
            if (oItem != null)
            {
                cboClass1.Text = oItem.CLASS1;
                cboClass2.Text = oItem.CLASS2;
                cboClass3.Text = oItem.CLASS3;
                cboClass4.Text = oItem.CLASS4;
                cboClass5.Text = oItem.CLASS5;
                cboClass6.Text = oItem.CLASS6;

                txtProductName.Text     = oItem.ProductName;
                txtProductNameChs.Text  = oItem.ProductName_Chs;
                txtProductNameCht.Text  = oItem.ProductName_Cht;

                txtRemarks.Text = oItem.Remarks;

                // 2013.12.24 paulus: dbo.Prodct 也有對應的 fields
                txtWholesalesPrice.Text = oItem.WholesalePrice.ToString("n2");
                txtOriginalRetailPrice.Text = oItem.OriginalRetailPrice.ToString("n2");
                txtCurrentRetailPrice.Text = oItem.RetailPrice.ToString("n2");

                txtRetailDiscount.Text  = oItem.NormalDiscount.ToString("n2");
                txtUnit.Text            = oItem.UOM;
                cboNature.SelectedValue = oItem.NatureId;

                txtStatus_Counter.Text  = "";
                txtStatus_Office.Text   = "";

                txtCreatedOn.Text   = DateTimeHelper.DateTimeToString(oItem.CreatedOn, false);
                txtModifiedOn.Text  = DateTimeHelper.DateTimeToString(oItem.ModifiedOn, false);
                txtModifiedBy.Text  = Common.Staff.GetStaffNumber(oItem.ModifiedBy);

                txtCurrentRetailPrice.Text = oItem.RetailPrice.ToString("n2");
            }
        }

        private void ShowProductSupplement()
        {
            string sql = "ProductId = '" + _ProductId.ToString() + "'";
            ProductSupplement oProdSupp = ProductSupplement.LoadWhere(sql);
            if (oProdSupp != null)
            {
                txtMemo.Text = oProdSupp.ProductName_Memo;
                txtPole.Text = oProdSupp.ProductName_Pole;

                cboVendorCurrency.Text  = oProdSupp.VendorCurrencyCode;
                txtVendorPrice.Text     = oProdSupp.VendorPrice.ToString("n2");
            }
        }

        private void ShowProductPrice()
        {
            ShowBasicPrice();
            ShowOriginalPrice();
            ShowVendorPrice();
            ShowWholesalesPrice();
        }

        private void ShowBasicPrice()
        {
            string sql = String.Format("ProductId = '{0}' AND PriceTypeId = '{1}'",
                _ProductId.ToString(),
                Common.ProductPriceType.GetTypeId(DAL.Common.Enums.ProductPriceType.BASPRC.ToString()));

            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice != null)
            {
                txtCurrentRetailCurrency.Text   = oPrice.CurrencyCode;
                txtCurrentRetailPrice.Text      = oPrice.Price.ToString("n2");
            }
        }

        private void ShowOriginalPrice()
        {
            string sql = String.Format("ProductId = '{0}' AND PriceTypeId = '{1}'",
                _ProductId.ToString(),
                Common.ProductPriceType.GetTypeId(DAL.Common.Enums.ProductPriceType.ORIPRC.ToString()));

            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice != null)
            {
                txtOriginalRetailCurrency.Text  = oPrice.CurrencyCode;
                txtOriginalRetailPrice.Text     = oPrice.Price.ToString("n2");
            }
        }

        private void ShowVendorPrice()
        {
            string sql = String.Format("ProductId = '{0}' AND PriceTypeId = '{1}'",
                _ProductId.ToString(),
                Common.ProductPriceType.GetTypeId(DAL.Common.Enums.ProductPriceType.VPRC.ToString()));

            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice != null)
            {
                cboVendorCurrency.Text  = oPrice.CurrencyCode;
                txtVendorPrice.Text     = oPrice.Price.ToString("n2");
            }
        }

        private void ShowWholesalesPrice()
        {
            string sql = String.Format("ProductId = '{0}' AND PriceTypeId = '{1}'",
                _ProductId.ToString(),
                Common.ProductPriceType.GetTypeId(DAL.Common.Enums.ProductPriceType.WHLPRC.ToString()));

            ProductPrice oPrice = ProductPrice.LoadWhere(sql);
            if (oPrice != null)
            {
                txtWholesalesCurrency.Text  = oPrice.CurrencyCode;
                txtWholesalesPrice.Text     = oPrice.Price.ToString("n2");
            }
        }

        private void ShowProductRemarks()
        {
            string sql = "ProductId = '" + _ProductId.ToString() + "'";
            ProductRemarks oRemarks = ProductRemarks.LoadWhere(sql);
            if (oRemarks != null)
            {
                txtBin_X.Text = oRemarks.BinX;
                txtBin_Y.Text = oRemarks.BinY;
                txtBin_Z.Text = oRemarks.BinZ;

                chkRetailItem.Checked = oRemarks.DownloadToShop;
                chkOffDisplayItem.Checked = oRemarks.OffDisplayItem;
                chkCounterItem.Checked = oRemarks.DownloadToCounter;

                txtRemarks1.Text = oRemarks.REMARK1;
                txtRemarks2.Text = oRemarks.REMARK2;
                txtRemarks3.Text = oRemarks.REMARK3;
                txtRemarks4.Text = oRemarks.REMARK4;
                txtRemarks5.Text = oRemarks.REMARK5;
                txtRemarks6.Text = oRemarks.REMARK6;
            }
        }
        #endregion

        public bool SaveRec(Guid productId)
        {
            bool result = false;

            DAL.Product oProduct = DAL.Product.Load(productId);
            if (oProduct != null)
            {
                SaveProduct(productId);
                SaveProductCode(productId);
                SaveBarcode(productId);
                SaveSupplement(oProduct.ProductId);
                SavePrices(oProduct.ProductId);
                SaveRemarks(oProduct.ProductId);
                SaveCurrentSummary(oProduct.ProductId);
            }

            return result;
        }

        private void SaveProduct(Guid productId)
        {
            RT2020.DAL.Product oProduct = RT2020.DAL.Product.Load(productId);
            if (oProduct != null)
            {
                oProduct.CLASS1 = cboClass1.Text;
                oProduct.CLASS2 = cboClass2.Text;
                oProduct.CLASS3 = cboClass3.Text;
                oProduct.CLASS4 = cboClass4.Text;
                oProduct.CLASS5 = cboClass5.Text;
                oProduct.CLASS6 = cboClass6.Text;

                oProduct.ProductName = txtProductName.Text;
                oProduct.ProductName_Chs = txtProductNameChs.Text;
                oProduct.ProductName_Cht = txtProductNameCht.Text;
                oProduct.Remarks = txtRemarks.Text;

                oProduct.NormalDiscount = Convert.ToDecimal((txtRetailDiscount.Text == string.Empty) ? "0" : txtRetailDiscount.Text);
                oProduct.UOM = txtUnit.Text;
                oProduct.NatureId = new Guid(cboNature.SelectedValue.ToString());

                // Price 
                oProduct.RetailPrice = Convert.ToDecimal((txtCurrentRetailPrice.Text == string.Empty) ? "0" : txtCurrentRetailPrice.Text);
                oProduct.WholesalePrice = Convert.ToDecimal((txtWholesalesPrice.Text == string.Empty) ? "0" : txtWholesalesPrice.Text);
                oProduct.OriginalRetailPrice = Convert.ToDecimal((txtOriginalRetailPrice.Text == string.Empty) ? "0" : txtOriginalRetailPrice.Text);
                //oItem.Markup = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);

                // Download Packets
                oProduct.DownloadToPOS = chkRetailItem.Checked;
                oProduct.DownloadToCounter = chkCounterItem.Checked;

                oProduct.ModifiedBy = RT2020.DAL.Common.Config.CurrentUserId;
                oProduct.ModifiedOn = DateTime.Now;
                oProduct.Save();
            }
        }

        private void SaveCurrentSummary(Guid productId)
        {
            string where = "ProductId = '" + productId.ToString() + "'";

            DAL.ProductCurrentSummary oCurrSummary = DAL.ProductCurrentSummary.LoadWhere(where);
            if (oCurrSummary == null)
            {
                oCurrSummary = new DAL.ProductCurrentSummary();
                oCurrSummary.ProductId = productId;
                oCurrSummary.CDQTY = 0;
                oCurrSummary.LastPurchasedOn = new DateTime(1900, 1, 1);
                oCurrSummary.LastSoldOn = new DateTime(1900, 1, 1);
                oCurrSummary.Save();
            }
        }

        private void SaveProductCode(Guid productId)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";
            DAL.ProductCode oCode = DAL.ProductCode.LoadWhere(sql);
            if (oCode != null)
            {
                // Class
                System.Guid c1Id = (cboClass1.SelectedValue != null) ? new Guid(cboClass1.SelectedValue.ToString()) : System.Guid.Empty;
                System.Guid c2Id = (cboClass2.SelectedValue != null) ? new Guid(cboClass2.SelectedValue.ToString()) : System.Guid.Empty;
                System.Guid c3Id = (cboClass3.SelectedValue != null) ? new Guid(cboClass3.SelectedValue.ToString()) : System.Guid.Empty;
                System.Guid c4Id = (cboClass4.SelectedValue != null) ? new Guid(cboClass4.SelectedValue.ToString()) : System.Guid.Empty;
                System.Guid c5Id = (cboClass5.SelectedValue != null) ? new Guid(cboClass5.SelectedValue.ToString()) : System.Guid.Empty;
                System.Guid c6Id = (cboClass6.SelectedValue != null) ? new Guid(cboClass6.SelectedValue.ToString()) : System.Guid.Empty;

                oCode.Class1Id = c1Id;
                oCode.Class2Id = c2Id;
                oCode.Class3Id = c3Id;
                oCode.Class4Id = c4Id;
                oCode.Class5Id = c5Id;
                oCode.Class6Id = c6Id;
                oCode.Save();
            }
        }

        private void SaveSupplement(Guid productId)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";

            DAL.ProductSupplement oProdSupp = DAL.ProductSupplement.LoadWhere(sql);
            if (oProdSupp == null)
            {
                oProdSupp = new DAL.ProductSupplement();

                oProdSupp.ProductId = productId;
            }
            oProdSupp.VendorCurrencyCode = cboVendorCurrency.Text;
            oProdSupp.VendorPrice = Convert.ToDecimal((txtVendorPrice.Text == string.Empty) ? "0" : txtVendorPrice.Text);
            oProdSupp.ProductName_Memo = txtMemo.Text;
            oProdSupp.ProductName_Pole = txtPole.Text;

            oProdSupp.Save();
        }

        private void SavePrices(Guid productId)
        {
            SavePrices(productId, RT2020.DAL.Common.Enums.ProductPriceType.BASPRC.ToString(), txtCurrentRetailCurrency.Text, txtCurrentRetailPrice.Text);
            SavePrices(productId, RT2020.DAL.Common.Enums.ProductPriceType.ORIPRC.ToString(), txtOriginalRetailCurrency.Text, txtOriginalRetailPrice.Text);
            SavePrices(productId, RT2020.DAL.Common.Enums.ProductPriceType.VPRC.ToString(), cboVendorCurrency.Text, txtVendorPrice.Text);
            SavePrices(productId, RT2020.DAL.Common.Enums.ProductPriceType.WHLPRC.ToString(), txtWholesalesCurrency.Text, txtWholesalesPrice.Text);
        }

        private void SavePrices(Guid productId, string priceType, string currencyCode, string price)
        {
            string sql = "ProductId = '" + productId.ToString() + "' AND PriceTypeId = '" + Common.ProductPriceType.GetTypeId(priceType).ToString() + "'";
            DAL.ProductPrice oPrice = DAL.ProductPrice.LoadWhere(sql);
            if (oPrice == null)
            {
                oPrice = new DAL.ProductPrice();

                oPrice.ProductId = productId;
            }
            oPrice.PriceTypeId = Common.ProductPriceType.GetTypeId(priceType);
            oPrice.CurrencyCode = currencyCode;
            oPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);
            oPrice.Save();
        }

        private void SaveRemarks(Guid productId)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";

            DAL.ProductRemarks oRemarks = DAL.ProductRemarks.LoadWhere(sql);
            if (oRemarks == null)
            {
                oRemarks = new DAL.ProductRemarks();

                oRemarks.ProductId = productId;
            }
            oRemarks.BinX = txtBin_X.Text;
            oRemarks.BinY = txtBin_Y.Text;
            oRemarks.BinZ = txtBin_Z.Text;

            oRemarks.DownloadToShop = chkRetailItem.Checked;
            oRemarks.OffDisplayItem = chkOffDisplayItem.Checked;
            oRemarks.DownloadToCounter = chkCounterItem.Checked;

            oRemarks.REMARK1 = txtRemarks1.Text;
            oRemarks.REMARK2 = txtRemarks2.Text;
            oRemarks.REMARK3 = txtRemarks3.Text;
            oRemarks.REMARK4 = txtRemarks4.Text;
            oRemarks.REMARK5 = txtRemarks5.Text;
            oRemarks.REMARK6 = txtRemarks6.Text;

            oRemarks.Save();
        }

        private void SaveBarcode(Guid productId)
        {
            DAL.Product oProduct = DAL.Product.Load(productId);
            if (oProduct != null)
            {
                string stkcode = oProduct.STKCODE;

                if (oProduct.STKCODE.Length > 10)
                {
                    stkcode = oProduct.STKCODE.Remove(10);
                }

                string barcode = stkcode + oProduct.APPENDIX1 + oProduct.APPENDIX2 + oProduct.APPENDIX3;
                string sql = "ProductId = '" + oProduct.ProductId.ToString() + "' AND Barcode = '" + barcode + "'";

                DAL.ProductBarcode oBarcode = DAL.ProductBarcode.LoadWhere(sql);
                if (oBarcode == null)
                {
                    oBarcode = new DAL.ProductBarcode();
                    oBarcode.ProductId = oProduct.ProductId;
                    oBarcode.Barcode = barcode;
                    oBarcode.BarcodeType = "INTER";
                    oBarcode.PrimaryBarcode = true;
                    oBarcode.DownloadToPOS = chkRetailItem.Checked;
                    oBarcode.DownloadToCounter = chkCounterItem.Checked;

                    oBarcode.Save();
                }
            }
        }

        private void chkMemoAsProductName_Click(object sender, EventArgs e)
        {
            if (chkMemoAsProductName.Checked)
            {
                txtMemo.Text = txtProductName.Text;
            }
        }

        private void chkPoleAsProductName_Click(object sender, EventArgs e)
        {
            if (chkPoleAsProductName.Checked)
            {
                txtPole.Text = txtProductName.Text;
            }
        }

        private void chkRemarksAsProductName_Click(object sender, EventArgs e)
        {
            if (chkRemarksAsProductName.Checked)
            {
                txtRemarks.Text = txtProductName.Text;
            }
        }

        private void lnkNature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ProductNatureWizard wizNature = new ProductNatureWizard();
            //wizNature.ShowDialog();
            //FillNatureList();
        }

        private void txtVendorPrice_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtVendorPrice.SelectAll();
            });
        }

        private void txtWholesalesPrice_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtWholesalesPrice.SelectAll();
            });
        }

        private void txtOriginalRetailPrice_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtOriginalRetailPrice.SelectAll();
            });
        }

        private void txtCurrentRetailPrice_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtCurrentRetailPrice.SelectAll();
            });
        }
    }
}