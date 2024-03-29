#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


using System.Windows.Forms;

using RT2020.DAL;
using RT2020.Client.Products.Wizard;

#endregion

namespace RT2020.Client.Products.Wizard
{
    public partial class ProductWizard_Batch : WizardWithTabsBase
    {
        ProductWizard_General general;
        ProductWizard_Misc misc;
        ProductWizard_Order order;

        private Guid _ProductBatchId = System.Guid.Empty;

        #region Public Properties
        public Guid ProductBatchId
        {
            get
            {
                return _ProductBatchId;
            }
            set
            {
                _ProductBatchId = value;
            }
        }
        #endregion

        public ProductWizard_Batch()
        {
            InitializeComponent();

            base.ShowDeleteButton = false;

            FillComboList();
            TabCtrl();
            SetCtrlEditable();
        }

        private void ProductWizard_Batch_Load(object sender, EventArgs e)
        {
            txtStkCode.Select();
        }

        #region STKCODE
        private void SetCtrlEditable()
        {
            txtStkCode.BackColor = Color.LightSkyBlue;
            cboItemStatus.BackColor = Color.LightSkyBlue;
        }
        #endregion

        #region Tab
        private void TabCtrl()
        {
            // General
            general = new ProductWizard_General(System.Guid.Empty);
            general.Dock = DockStyle.Fill;
            tpGeneral.Controls.Add(general);

            // Misc
            misc = new ProductWizard_Misc(System.Guid.Empty);
            misc.Dock = DockStyle.Fill;
            tpMisc.Controls.Add(misc);

            // Order
            order = new ProductWizard_Order(System.Guid.Empty);
            order.Dock = DockStyle.Fill;
            order.gbPurchaseHistory.Visible = false;
            tpOrder.Controls.Add(order);
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillAppendix1List();
            FillAppendix2List();
            FillAppendix3List();
        }

        private void FillAppendix1List()
        {
            cboAppendix1.DataSource = null;
            string sql = "SELECT DISTINCT DimensionId, DimCode FROM vwDimensionList Where DimType = 'A1'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                dataset.Tables[0].Rows.Add(new object[] { System.Guid.Empty, string.Empty });

                cboAppendix1.DataSource = dataset.Tables[0].DefaultView;
                cboAppendix1.DisplayMember = "DimCode";
                cboAppendix1.ValueMember = "DimensionId";
                cboAppendix1.SelectedIndex = dataset.Tables[0].Rows.Count - 1;
            }
        }

        private void FillAppendix2List()
        {
            cboAppendix2.DataSource = null;
            string sql = "SELECT DISTINCT DimensionId, DimCode FROM vwDimensionList Where DimType = 'A2'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                dataset.Tables[0].Rows.Add(new object[] { System.Guid.Empty, string.Empty });

                cboAppendix2.DataSource = dataset.Tables[0].DefaultView;
                cboAppendix2.DisplayMember = "DimCode";
                cboAppendix2.ValueMember = "DimensionId";
                cboAppendix2.SelectedIndex = dataset.Tables[0].Rows.Count - 1;
            }
        }

        private void FillAppendix3List()
        {
            cboAppendix3.DataSource = null;
            string sql = "SELECT DISTINCT DimensionId, DimCode FROM vwDimensionList Where DimType = 'A3'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                dataset.Tables[0].Rows.Add(new object[] { System.Guid.Empty, string.Empty });

                cboAppendix3.DataSource = dataset.Tables[0].DefaultView;
                cboAppendix3.DisplayMember = "DimCode";
                cboAppendix3.ValueMember = "DimensionId";
                cboAppendix3.SelectedIndex = dataset.Tables[0].Rows.Count - 1;
            }
        }
        #endregion

        #region Combination
        private ListView Combin()
        {
            ListView oList = null;

            oList = new ListView();

            CombinA1(ref oList);

            return oList;
        }

        private void CombinA1(ref ListView oList)
        {
            if (DAL.Common.Utility.IsGUID(cboAppendix1.SelectedValue.ToString()))
            {
                string sql = "DimensionId = '" + cboAppendix1.SelectedValue.ToString() + "'";
                ProductDim_DetailsCollection detailList = ProductDim_Details.LoadCollection(sql);
                foreach (ProductDim_Details detail in detailList)
                {
                    if (!string.IsNullOrEmpty(detail.APPENDIX1))
                    {
                        CombinA2(ref oList, detail.APPENDIX1);
                    }
                }
            }
        }

        private void CombinA2(ref ListView oList, string a1)
        {
            if (DAL.Common.Utility.IsGUID(cboAppendix2.SelectedValue.ToString()))
            {
                string sql = "DimensionId = '" + cboAppendix2.SelectedValue.ToString() + "'";
                ProductDim_DetailsCollection detailList = ProductDim_Details.LoadCollection(sql);
                foreach (ProductDim_Details detail in detailList)
                {
                    if (!string.IsNullOrEmpty(detail.APPENDIX2))
                    {
                        CombinA3(ref oList, a1, detail.APPENDIX2);
                    }
                }
            }
        }

        private void CombinA3(ref ListView oList, string a1, string a2)
        {
            if (DAL.Common.Utility.IsGUID(cboAppendix3.SelectedValue.ToString()))
            {
                string sql = "DimensionId = '" + cboAppendix3.SelectedValue.ToString() + "'";
                ProductDim_DetailsCollection detailList = ProductDim_Details.LoadCollection(sql);
                foreach (ProductDim_Details detail in detailList)
                {
                    if (!string.IsNullOrEmpty(detail.APPENDIX3))
                    {
                        AddToList(ref oList, a1, a2, detail.APPENDIX3);
                    }
                }

                if (detailList.Count == 0)
                {
                    AddToList(ref oList, a1, a2, string.Empty);
                }
            }
        }

        private void AddToList(ref ListView oList, string a1, string a2, string a3)
        {
            ListViewItem objItem = oList.Items.Add((oList.Items.Count + 1).ToString());
            objItem.SubItems.Add(a1);
            objItem.SubItems.Add(a2);
            objItem.SubItems.Add(a3);
            objItem.SubItems.Add(GetAppendix1Id(a1).ToString());
            objItem.SubItems.Add(GetAppendix2Id(a2).ToString());
            objItem.SubItems.Add(GetAppendix3Id(a3).ToString());
        }

        private Guid GetAppendix1Id(string a1Code)
        {
            string sql = "Appendix1Initial = '" + a1Code + "'";
            ProductAppendix1 oA1 = ProductAppendix1.LoadWhere(sql);
            if (oA1 != null)
            {
                return oA1.Appendix1Id;
            }
            else
            {
                return System.Guid.Empty;
            }
        }

        private Guid GetAppendix2Id(string a2Code)
        {
            string sql = "Appendix2Initial = '" + a2Code + "'";
            ProductAppendix2 oA2 = ProductAppendix2.LoadWhere(sql);
            if (oA2 != null)
            {
                return oA2.Appendix2Id;
            }
            else
            {
                return System.Guid.Empty;
            }
        }

        private Guid GetAppendix3Id(string a3Code)
        {
            string sql = "Appendix3Initial = '" + a3Code + "'";
            ProductAppendix3 oA3 = ProductAppendix3.LoadWhere(sql);
            if (oA3 != null)
            {
                return oA3.Appendix3Id;
            }
            else
            {
                return System.Guid.Empty;
            }
        }
        #endregion

        #region Create Products
        private bool IsStockCodeExist()
        {
            bool result = false;

            string sql = "STKCODE = '" + txtStkCode.Text + "'";
            RT2020.DAL.Product oProd = RT2020.DAL.Product.LoadWhere(sql);
            if (oProd != null)
            {
                result = true;
            }

            sql += " AND APP1_COMBIN = '" + cboAppendix1.Text + "' AND APP2_COMBIN = '" + cboAppendix2.Text + "' AND APP3_COMBIN = '" + cboAppendix3.Text + "'";
            RT2020.DAL.ProductBatch oProdB = RT2020.DAL.ProductBatch.LoadWhere(sql);
            if (oProdB != null)
            {
                result = true;
            }

            if (this.ProductBatchId != System.Guid.Empty)
            {
                result = false;
            }

            return result;
        }

        private bool Verify()
        {
            bool isVerified = false;

            if (cboAppendix1.Text.Length == 0 && cboAppendix2.Text.Length == 0 && cboAppendix3.Text.Length == 0)
            {
                MessageBox.Show("You should add one appendix at least or select one combination number!");
            }
            else if (txtStkCode.Text.Length == 0)
            {
                errorProvider.SetError(txtStkCode, "Can not be blank!");
                isVerified = false;
            }
            else if (IsStockCodeExist())
            {
                errorProvider.SetError(txtStkCode, "Stock Code exists!");
                isVerified = false;
            }
            else if (cboItemStatus.Text.Length == 0)
            {
                errorProvider.SetError(cboItemStatus, "Please specified the status!");
                isVerified = false;
            }
            else
            {
                errorProvider.SetError(txtStkCode, string.Empty);
                errorProvider.SetError(cboItemStatus, string.Empty);
                isVerified = true;
            }

            return isVerified;
        }

        private int CreateProducts()
        {
            int iCount = 0;
            ListView combinList = Combin();
            if (combinList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in combinList.Items)
                {
                    CreateProducts(oItem);
                    iCount++;
                }
            }
            return iCount;
        }

        private void CreateProducts(ListViewItem listItem)
        {
            if (Verify())
            {
                string a1 = listItem.SubItems[1].Text;
                string a2 = listItem.SubItems[2].Text;
                string a3 = listItem.SubItems[3].Text;

                System.Guid a1Id = (DAL.Common.Utility.IsGUID(listItem.SubItems[4].Text)) ? new Guid(listItem.SubItems[4].Text) : System.Guid.Empty;
                System.Guid a2Id = (DAL.Common.Utility.IsGUID(listItem.SubItems[5].Text)) ? new Guid(listItem.SubItems[5].Text) : System.Guid.Empty;
                System.Guid a3Id = (DAL.Common.Utility.IsGUID(listItem.SubItems[6].Text)) ? new Guid(listItem.SubItems[6].Text) : System.Guid.Empty;

                string prodCode = txtStkCode.Text.Trim() + a1 + a2 + a3;
                if (prodCode.Length <= 22)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" STKCODE = '").Append(txtStkCode.Text.Trim()).Append("' ");
                    sql.Append(" AND APPENDIX1 = '").Append(a1.Trim()).Append("' ");
                    sql.Append(" AND APPENDIX2 = '").Append(a2.Trim()).Append("' ");
                    sql.Append(" AND APPENDIX3 = '").Append(a3.Trim()).Append("' ");

                    RT2020.DAL.Product oItem = RT2020.DAL.Product.LoadWhere(sql.ToString());
                    if (oItem == null)
                    {
                        oItem = new RT2020.DAL.Product();

                        oItem.STKCODE = txtStkCode.Text;
                        oItem.APPENDIX1 = a1;
                        oItem.APPENDIX2 = a2;
                        oItem.APPENDIX3 = a3;

                        if (cboItemStatus.Text == "HOLD")
                        {
                            oItem.Status = Convert.ToInt32(DAL.Common.Enums.Status.Draft.ToString("d"));
                        }
                        else if (cboItemStatus.Text == "POST")
                        {
                            oItem.Status = Convert.ToInt32(DAL.Common.Enums.Status.Active.ToString("d"));
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

                        oItem.FixedPriceItem = false;

                        // Download Packets
                        oItem.DownloadToPOS = general.chkRetailItem.Checked;
                        oItem.DownloadToCounter = general.chkCounterItem.Checked;

                        oItem.CreatedBy = DAL.Common.Config.CurrentUserId;
                        oItem.CreatedOn = DateTime.Now;
                        oItem.ModifiedBy = DAL.Common.Config.CurrentUserId;
                        oItem.ModifiedOn = DateTime.Now;

                        oItem.Save();

                        SaveProductBarcode(oItem.ProductId, prodCode);

                        // Appendix / Class
                        System.Guid c1Id = (general.cboClass1.SelectedValue != null) ? new Guid(general.cboClass1.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c2Id = (general.cboClass2.SelectedValue != null) ? new Guid(general.cboClass2.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c3Id = (general.cboClass3.SelectedValue != null) ? new Guid(general.cboClass3.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c4Id = (general.cboClass4.SelectedValue != null) ? new Guid(general.cboClass4.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c5Id = (general.cboClass5.SelectedValue != null) ? new Guid(general.cboClass5.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c6Id = (general.cboClass6.SelectedValue != null) ? new Guid(general.cboClass6.SelectedValue.ToString()) : System.Guid.Empty;
                        SaveProductCode(oItem.ProductId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);

                        // Product Price
                        SaveProductSupplement(oItem.ProductId);
                        SaveProductPrice(oItem.ProductId);

                        // Remarks
                        SaveProductRemarks(oItem.ProductId);

                        SaveCurrentSummary(oItem.ProductId);
                    }
                }
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

        private void SaveProductBarcode(Guid productid, string barcode)
        {
            string sql = "ProductId = '" + productid.ToString() + "' AND Barcode = '" + barcode + "'";
            ProductBarcode oBarcode = ProductBarcode.LoadWhere(sql);
            if (oBarcode == null)
            {
                oBarcode = new ProductBarcode();

                oBarcode.ProductId = productid;
                oBarcode.Barcode = barcode;
                oBarcode.BarcodeType = "INTER";
                oBarcode.PrimaryBarcode = true;
                oBarcode.DownloadToPOS = general.chkRetailItem.Checked;
                oBarcode.DownloadToCounter = general.chkCounterItem.Checked;

                oBarcode.Save();
            }
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

            //oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((txtDiscount1_FixPriceItem.Text == string.Empty) ? "0" : txtDiscount1_FixPriceItem.Text);
            //oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((txtDiscount2_DiscountItem.Text == string.Empty) ? "0" : txtDiscount2_DiscountItem.Text);
            //oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((txtDiscount3_NoDiscountItem.Text == string.Empty) ? "0" : txtDiscount3_NoDiscountItem.Text);
            //oProdSupp.StaffDiscount = Convert.ToDecimal((txtStaffDiscount.Text == string.Empty) ? "0" : txtStaffDiscount.Text);

            oProdSupp.Save();
        }

        private void SaveProductPrice(Guid productId)
        {
            SaveProductPrice(productId, DAL.Common.Enums.ProductPriceType.BASPRC.ToString(), general.txtCurrentRetailCurrency.Text, general.txtCurrentRetailPrice.Text);
            SaveProductPrice(productId, DAL.Common.Enums.ProductPriceType.ORIPRC.ToString(), general.txtOriginalRetailCurrency.Text, general.txtOriginalRetailPrice.Text);
            SaveProductPrice(productId, DAL.Common.Enums.ProductPriceType.VPRC.ToString(), general.cboVendorCurrency.Text, general.txtVendorPrice.Text);
            SaveProductPrice(productId, DAL.Common.Enums.ProductPriceType.WHLPRC.ToString(), general.txtWholesalesCurrency.Text, general.txtWholesalesPrice.Text);
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
            ProductPriceType oType = ProductPriceType.LoadWhere(sql);
            if (oType == null)
            {
                oType = new ProductPriceType();

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

            oRemarks.Save();
        }
        #endregion

        #region Save Product Batch
        private bool Save()
        {
            if (Verify())
            {
                SaveProductBatch();
                return (this.ProductBatchId != System.Guid.Empty);
            }

            return false;
        }

        private void SaveProductBatch()
        {
            ProductBatch oBatch = ProductBatch.Load(this.ProductBatchId);
            if (oBatch == null)
            {
                oBatch = new ProductBatch();
            }
            oBatch.STKCODE = txtStkCode.Text;
            oBatch.APP1_COMBIN = cboAppendix1.Text;
            oBatch.APP2_COMBIN = cboAppendix2.Text;
            oBatch.APP3_COMBIN = cboAppendix3.Text;
            oBatch.CLASS1 = general.cboClass1.Text;
            oBatch.CLASS2 = general.cboClass2.Text;
            oBatch.CLASS3 = general.cboClass3.Text;
            oBatch.CLASS4 = general.cboClass4.Text;
            oBatch.CLASS5 = general.cboClass5.Text;
            oBatch.CLASS6 = general.cboClass6.Text;
            oBatch.Description = general.txtProductName.Text;
            oBatch.MAINUNIT = general.txtUnit.Text;
            oBatch.ALTITEM = string.Empty;
            oBatch.REMARKS = general.txtRemarks.Text;
            oBatch.MARKUP = 0;
            oBatch.BASPRC = (general.txtCurrentRetailPrice.Text.Length == 0) ? 0 : Convert.ToDecimal(general.txtCurrentRetailPrice.Text);
            oBatch.WHLPRC = (general.txtWholesalesPrice.Text.Length == 0) ? 0 : Convert.ToDecimal(general.txtWholesalesPrice.Text);
            oBatch.VCURR = general.cboVendorCurrency.Text;
            oBatch.VPRC = (general.txtVendorPrice.Text.Length == 0) ? 0 : Convert.ToDecimal(general.txtVendorPrice.Text);
            oBatch.NRDISC = 0;
            oBatch.REORDLVL = (order.txtReorderLevel.Text.Length == 0) ? 0 : Convert.ToDecimal(order.txtReorderLevel.Text);
            oBatch.REORDQTY = (order.txtReorderQuantity.Text.Length == 0) ? 0 : Convert.ToDecimal(order.txtReorderQuantity.Text);
            oBatch.SERIALFLAG = false;
            oBatch.NATURE = general.cboNature.Text;
            oBatch.REMARK1 = general.txtRemarks1.Text;
            oBatch.REMARK2 = general.txtRemarks2.Text;
            oBatch.REMARK3 = general.txtRemarks3.Text;
            oBatch.REMARK4 = general.txtRemarks4.Text;
            oBatch.REMARK5 = general.txtRemarks5.Text;
            oBatch.REMARK6 = general.txtRemarks6.Text;
            oBatch.PHOTO = misc.txtPicFileName.Text;
            oBatch.STK_MEMO = general.txtMemo.Text;
            oBatch.STATUS = cboItemStatus.Text;
            oBatch.DATEPOST = new DateTime(1900, 1, 1);
            oBatch.DATECREATE = DateTime.Now;
            oBatch.DATELCHG = DateTime.Now;
            oBatch.USERLCHG = GetStaffName(DAL.Common.Config.CurrentUserId);
            oBatch.RETAILITEM = general.chkRetailItem.Checked.ToString();
            oBatch.BINX = general.txtBin_X.Text;
            oBatch.BINY = general.txtBin_Y.Text;
            oBatch.BINZ = general.txtBin_Z.Text;
            oBatch.DESC_MEMO = general.txtMemo.Text;
            oBatch.DESC_POLE = general.txtPole.Text;
            oBatch.OFF_DISPLAY_ITEM = general.chkOffDisplayItem.Checked.ToString();
            oBatch.COUNTER_ITEM = general.chkCounterItem.Checked.ToString();
            oBatch.ORIPRC = (general.txtOriginalRetailPrice.Text.Length == 0) ? 0 : Convert.ToDecimal(general.txtOriginalRetailPrice.Text);

            oBatch.Save();

            this.ProductBatchId = oBatch.BatchId;
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
        #endregion

        #region Load Product Batch
        private void LoadProductBatch()
        {
            ProductBatch oBatch = ProductBatch.Load(this.ProductBatchId);
            if (oBatch != null)
            {
                txtStkCode.Text = oBatch.STKCODE;
                cboAppendix1.Text = oBatch.APP1_COMBIN;
                cboAppendix2.Text = oBatch.APP2_COMBIN;
                cboAppendix3.Text = oBatch.APP3_COMBIN;
                general.cboClass1.Text = oBatch.CLASS1;
                general.cboClass2.Text = oBatch.CLASS2;
                general.cboClass3.Text = oBatch.CLASS3;
                general.cboClass4.Text = oBatch.CLASS4;
                general.cboClass5.Text = oBatch.CLASS5;
                general.cboClass6.Text = oBatch.CLASS6;
                general.txtProductName.Text = oBatch.Description;
                general.txtUnit.Text = oBatch.MAINUNIT;
                general.txtRemarks.Text = oBatch.REMARKS;
                general.txtCurrentRetailPrice.Text = oBatch.BASPRC.ToString("n2");
                general.txtWholesalesPrice.Text = oBatch.WHLPRC.ToString("n2");
                general.cboVendorCurrency.Text = oBatch.VCURR;
                general.txtVendorPrice.Text = oBatch.VPRC.ToString("n2");
                order.txtReorderLevel.Text = oBatch.REORDLVL.ToString("n0");
                order.txtReorderQuantity.Text = oBatch.REORDQTY.ToString("n0");
                general.cboNature.Text = oBatch.NATURE;
                general.txtRemarks1.Text = oBatch.REMARK1;
                general.txtRemarks2.Text = oBatch.REMARK2;
                general.txtRemarks3.Text = oBatch.REMARK3;
                general.txtRemarks4.Text = oBatch.REMARK4;
                general.txtRemarks5.Text = oBatch.REMARK5;
                general.txtRemarks6.Text = oBatch.REMARK6;
                misc.txtPicFileName.Text = oBatch.PHOTO;
                cboItemStatus.Text = oBatch.STATUS;
                general.chkRetailItem.Checked = (oBatch.RETAILITEM == "F") ? false : true;
                general.txtBin_X.Text = oBatch.BINX;
                general.txtBin_Y.Text = oBatch.BINY;
                general.txtBin_Z.Text = oBatch.BINZ;
                general.txtMemo.Text = oBatch.DESC_MEMO;
                general.txtPole.Text = oBatch.DESC_POLE;
                general.chkOffDisplayItem.Checked = (oBatch.OFF_DISPLAY_ITEM == "F") ? false : true;
                general.chkCounterItem.Checked = (oBatch.COUNTER_ITEM == "F") ? false : true;
                general.txtOriginalRetailPrice.Text = oBatch.ORIPRC.ToString("n2");
            }
        }
        #endregion

        #region Form Toolbar Events

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

                        this.Close();
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
                        ProductWizard_Batch wizard = new ProductWizard_Batch();
                        wizard.ProductBatchId = Guid.Empty;
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

        private void lnkAppendix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductWizard_Combination wizCombin = null;
            ProductWizard_Combination.FormLayoutType formType = ProductWizard_Combination.FormLayoutType.All;
            LinkLabel lnk = sender as LinkLabel;
            switch (lnk.Name.ToLower())
            {
                case "lnkappendix1":
                    formType = ProductWizard_Combination.FormLayoutType.Appendix1;
                    break;
                case "lnkappendix2":
                    formType = ProductWizard_Combination.FormLayoutType.Appendix2;
                    break;
                case "lnkappendix3":
                    formType = ProductWizard_Combination.FormLayoutType.Appendix3;
                    break;
            }

            wizCombin = new ProductWizard_Combination(formType);
            wizCombin.FormClosed += new FormClosedEventHandler(wizCombin_FormClosed);
            wizCombin.ShowDialog();
        }

        void wizCombin_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProductWizard_Combination wizCombin = sender as ProductWizard_Combination;
            if (wizCombin != null)
            {
                switch (wizCombin.FormType)
                {
                    case ProductWizard_Combination.FormLayoutType.Appendix1:
                        FillAppendix1List();
                        break;
                    case ProductWizard_Combination.FormLayoutType.Appendix2:
                        FillAppendix2List();
                        break;
                    case ProductWizard_Combination.FormLayoutType.Appendix3:
                        FillAppendix3List();
                        break;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ProdCare_FindBatch wizBatch = new ProdCare_FindBatch();
            wizBatch.Closed += new EventHandler(wizBatch_Closed);
            wizBatch.ShowDialog();
        }

        private void wizBatch_Closed(object sender, EventArgs e)
        {
            ProdCare_FindBatch wizBatch = sender as ProdCare_FindBatch;
            if (wizBatch.IsCompleted)
            {
                this.ProductBatchId = wizBatch.ProductBatchId;
                LoadProductBatch();
            }
        }
    }
}