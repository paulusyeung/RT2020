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
using RT2020.DAL;
using System.Linq;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_Batch : Form
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
            FillComboList();
            SetToolBar();
            TabCtrl();
            SetCtrlEditable();

            SetSystemLabels();
        }

        private void ProductWizard_Batch_Load(object sender, EventArgs e)
        {
            txtStkCode.Focus();
        }

        #region Set System label
        private void SetSystemLabels()
        {
            lblStkCode.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");

            string combinNum = Resources.Common.AppendixCombinNum;

            lnkAppendix1.Text = string.Format(combinNum, RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1"));
            lnkAppendix2.Text = string.Format(combinNum, RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2"));
            lnkAppendix3.Text = string.Format(combinNum, RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3"));
        }
        #endregion

        #region STKCODE
        private void SetCtrlEditable()
        {
            txtStkCode.BackColor = Color.LightSkyBlue;
            cboItemStatus.BackColor = Color.LightSkyBlue;
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
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", "Save & New");
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", "Save & Close");
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");

            this.tbWizardAction.Buttons.Add(cmdSaveClose);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        //int result = CreateProducts();

                        //if (result > 0)
                        //{
                        //    MessageBox.Show(result.ToString() + " Succeed!", "Create Result", MessageBoxButtons.OK, new EventHandler(SaveMessageHandler));
                        //}
                        //else
                        //{
                        //    MessageBox.Show(result.ToString() + " Succeed!", "Create Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        if (IsValidEntries())
                        {
                            SaveProductBatch();
                            if (this.ProductBatchId != System.Guid.Empty)
                            {
                                MessageBox.Show("Save Successfully!", "Create Result", MessageBoxButtons.OK, new EventHandler(SaveMessageHandler));
                            }
                        }
                        break;
                    case "save & new":
                        if (IsValidEntries())
                        {
                            SaveProductBatch();
                            if (this.ProductBatchId != System.Guid.Empty)
                            {
                                MessageBox.Show("Save Successfully! Want to add new batch?", "Create Result", MessageBoxButtons.YesNo, new EventHandler(SaveNewMessageHandler));
                            }
                        }
                        break;
                    case "save & close":
                        if (IsValidEntries())
                        {
                            SaveProductBatch();
                            if (this.ProductBatchId != System.Guid.Empty)
                            {
                                MessageBox.Show("Save Successfully! Want to close wizard", "Create Result", MessageBoxButtons.YesNo, new EventHandler(SaveCloseMessageHandler));
                            }
                        }
                        break;
                }
            }
        }
        #endregion

        #region Tab
        private void TabCtrl()
        {
            // General
            general = new ProductWizard_General();
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
            string sql = "SELECT DISTINCT DimensionId, DimCode FROM vwDimensionList Where DimType = 'A1'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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
            string sql = "SELECT DISTINCT DimensionId, DimCode FROM vwDimensionList Where DimType = 'A2'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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
            string sql = "SELECT DISTINCT DimensionId, DimCode FROM vwDimensionList Where DimType = 'A3'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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
            Guid id = Guid.Empty;
            if (Guid.TryParse(cboAppendix1.SelectedValue.ToString(), out id))
            {
                var detailList = ModelEx.ProductDim_DetailsEx.GetListByDimensionId(id);
                foreach (var detail in detailList)
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
            Guid id = Guid.Empty;
            if (Guid.TryParse(cboAppendix2.SelectedValue.ToString(), out id))
            {
                var detailList = ModelEx.ProductDim_DetailsEx.GetListByDimensionId(id);
                foreach (var detail in detailList)
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
            Guid id = Guid.Empty;
            if (Guid.TryParse(cboAppendix3.SelectedValue.ToString(), out id))
            {
                var detailList = ModelEx.ProductDim_DetailsEx.GetListByDimensionId(id);
                foreach (var detail in detailList)
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
            objItem.SubItems.Add(ModelEx.ProductAppendix1Ex.GetIdByInitial(a1).ToString());
            objItem.SubItems.Add(ModelEx.ProductAppendix2Ex.GetIdByInitial(a2).ToString());
            objItem.SubItems.Add(ModelEx.ProductAppendix3Ex.GetIdByInitial(a3).ToString());
        }
        #endregion

        #region Create Products
        private bool IsStockCodeExist()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "STKCODE = '" + txtStkCode.Text + "'";
                var oProd = ctx.Product.Where(x => x.STKCODE == txtStkCode.Text).FirstOrDefault();
                if (oProd != null)
                {
                    result = true;
                }

                //sql += " AND APP1_COMBIN = '" + cboAppendix1.Text + "' AND APP2_COMBIN = '" + cboAppendix2.Text + "' AND APP3_COMBIN = '" + cboAppendix3.Text + "'";
                var oProdB = ctx.ProductBatch.Where(x => x.STKCODE == txtStkCode.Text && x.APP1_COMBIN == cboAppendix1.Text && x.APP2_COMBIN == cboAppendix2.Text && x.APP3_COMBIN == cboAppendix3.Text).FirstOrDefault();
                if (oProdB != null)
                {
                    result = true;
                }

                if (this.ProductBatchId != System.Guid.Empty)
                {
                    result = false;
                }
            }

            return result;
        }

        private bool IsValidEntries()
        {
            bool result = true;

            errorProvider.SetError(txtStkCode, string.Empty);
            errorProvider.SetError(cboItemStatus, string.Empty);

            if (cboAppendix1.Text.Length == 0 && cboAppendix2.Text.Length == 0 && cboAppendix3.Text.Length == 0)
            {
                MessageBox.Show("You should add one appendix at least or select one combination number!");
                result = false;
            }

            if (txtStkCode.Text.Length == 0)
            {
                errorProvider.SetError(txtStkCode, "Can not be blank!");
                result = false;
            }
            if (IsStockCodeExist())
            {
                errorProvider.SetError(txtStkCode, "Stock Code exists!");
                result = false;
            }
            if (cboItemStatus.Text.Length == 0)
            {
                errorProvider.SetError(cboItemStatus, "Please specified the status!");
                result = false;
            }

            return result;
        }
        /**
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
            if (IsValidEntries())
            {
                string a1 = listItem.SubItems[1].Text;
                string a2 = listItem.SubItems[2].Text;
                string a3 = listItem.SubItems[3].Text;

                System.Guid a1Id = (Common.Utility.IsGUID(listItem.SubItems[4].Text)) ? new Guid(listItem.SubItems[4].Text) : System.Guid.Empty;
                System.Guid a2Id = (Common.Utility.IsGUID(listItem.SubItems[5].Text)) ? new Guid(listItem.SubItems[5].Text) : System.Guid.Empty;
                System.Guid a3Id = (Common.Utility.IsGUID(listItem.SubItems[6].Text)) ? new Guid(listItem.SubItems[6].Text) : System.Guid.Empty;

                string prodCode = txtStkCode.Text.Trim() + a1 + a2 + a3;
                if (prodCode.Length <= 22)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" STKCODE = '").Append(txtStkCode.Text.Trim()).Append("' ");
                    sql.Append(" AND APPENDIX1 = '").Append(a1.Trim()).Append("' ");
                    sql.Append(" AND APPENDIX2 = '").Append(a2.Trim()).Append("' ");
                    sql.Append(" AND APPENDIX3 = '").Append(a3.Trim()).Append("' ");

                    var oProduct = RT2020.DAL.Product.LoadWhere(sql.ToString());
                    if (oProduct == null)
                    {
                        oProduct = new RT2020.DAL.Product();

                        oProduct.STKCODE = txtStkCode.Text;
                        oProduct.APPENDIX1 = a1;
                        oProduct.APPENDIX2 = a2;
                        oProduct.APPENDIX3 = a3;

                        if (cboItemStatus.Text == "HOLD")
                        {
                            oProduct.Status = Convert.ToInt32(Common.Enums.Status.Draft.ToString("d"));
                        }
                        else if (cboItemStatus.Text == "POST")
                        {
                            oProduct.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));
                        }

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

                        oProduct.FixedPriceItem = false;

                        // Download Packets
                        oProduct.DownloadToPOS = general.chkRetailItem.Checked;
                        oProduct.DownloadToCounter = general.chkCounterItem.Checked;

                        oProduct.CreatedBy = Common.Config.CurrentUserId;
                        oProduct.CreatedOn = DateTime.Now;
                        oProduct.ModifiedBy = Common.Config.CurrentUserId;
                        oProduct.ModifiedOn = DateTime.Now;

                        oProduct.Save();

                        SaveProductBarcode(oProduct.ProductId, prodCode);

                        // Appendix / Class
                        System.Guid c1Id = (general.cboClass1.SelectedValue != null) ? new Guid(general.cboClass1.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c2Id = (general.cboClass2.SelectedValue != null) ? new Guid(general.cboClass2.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c3Id = (general.cboClass3.SelectedValue != null) ? new Guid(general.cboClass3.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c4Id = (general.cboClass4.SelectedValue != null) ? new Guid(general.cboClass4.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c5Id = (general.cboClass5.SelectedValue != null) ? new Guid(general.cboClass5.SelectedValue.ToString()) : System.Guid.Empty;
                        System.Guid c6Id = (general.cboClass6.SelectedValue != null) ? new Guid(general.cboClass6.SelectedValue.ToString()) : System.Guid.Empty;
                        SaveProductCode(oProduct.ProductId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);

                        // Product Price
                        SaveProductSupplement(oProduct.ProductId);
                        SaveProductPrice(oProduct.ProductId);

                        // Remarks
                        SaveProductRemarks(oProduct.ProductId);

                        SaveCurrentSummary(oProduct.ProductId);
                    }
                }
            }
        }
        
        private void SaveCurrentSummary(Guid productId)
        {
            string where = "ProductId = '" + productId.ToString() + "'";

            using (var ctx = new EF6.RT2020Entities())
            {
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

        private void SaveProductBarcode(Guid productid, string barcode)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "ProductId = '" + productid.ToString() + "' AND Barcode = '" + barcode + "'";
                var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == productid && x.Barcode == barcode).FirstOrDefault();
                if (oBarcode == null)
                {
                    oBarcode = new EF6.ProductBarcode();
                    oBarcode.ProductBarcodeId = Guid.NewGuid();
                    oBarcode.ProductId = productid;
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
        
        private void SaveProductCode(Guid productId, Guid a1Id, Guid a2Id, Guid a3Id, Guid c1Id, Guid c2Id, Guid c3Id, Guid c4Id, Guid c5Id, Guid c6Id)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "ProductId = '" + productId.ToString() + "'";
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
                string sql = "ProductId = '" + productId.ToString() + "'";
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

                //oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((txtDiscount1_FixPriceItem.Text == string.Empty) ? "0" : txtDiscount1_FixPriceItem.Text);
                //oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((txtDiscount2_DiscountItem.Text == string.Empty) ? "0" : txtDiscount2_DiscountItem.Text);
                //oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((txtDiscount3_NoDiscountItem.Text == string.Empty) ? "0" : txtDiscount3_NoDiscountItem.Text);
                //oProdSupp.StaffDiscount = Convert.ToDecimal((txtStaffDiscount.Text == string.Empty) ? "0" : txtStaffDiscount.Text);

                ctx.SaveChanges();
            }
        }
        
        private void SaveProductPrice(Guid productId)
        {
            SaveProductPrice(productId, Common.Enums.ProductPriceType.BASPRC.ToString(), general.txtCurrentRetailCurrency.Text, general.txtCurrentRetailPrice.Text);
            SaveProductPrice(productId, Common.Enums.ProductPriceType.ORIPRC.ToString(), general.txtOriginalRetailCurrency.Text, general.txtOriginalRetailPrice.Text);
            SaveProductPrice(productId, Common.Enums.ProductPriceType.VPRC.ToString(), general.cboVendorCurrency.Text, general.txtVendorPrice.Text);
            SaveProductPrice(productId, Common.Enums.ProductPriceType.WHLPRC.ToString(), general.txtWholesalesCurrency.Text, general.txtWholesalesPrice.Text);
        }
        
        private void SaveProductPrice(Guid productId, string priceType, string currencyCode, string price)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                //string sql = "ProductId = '" + productId.ToString() + "' AND PriceTypeId = '" + GetPriceType(priceType).ToString() + "'";

                var oPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                if (oPrice == null)
                {
                    oPrice = new EF6.ProductPrice();
                    oPrice.ProductPriceId = Guid.NewGuid();
                    oPrice.ProductId = productId;

                    ctx.ProductPrice.Add(oPrice);
                }
                oPrice.PriceTypeId = priceTypeId;
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

                ctx.SaveChanges();
            }
        }
        */
        #endregion

        #region Save Product Batch
        private void SaveProductBatch()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oBatch = ctx.ProductBatch.Find(this.ProductBatchId);
                if (oBatch == null)
                {
                    oBatch = new EF6.ProductBatch();
                    oBatch.BatchId = Guid.NewGuid();
                    ctx.ProductBatch.Add(oBatch);
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
                oBatch.USERLCHG = ModelEx.StaffEx.GetStaffNumberById(Common.Config.CurrentUserId);
                oBatch.RETAILITEM = general.chkRetailItem.Checked.ToString();
                oBatch.BINX = general.txtBin_X.Text;
                oBatch.BINY = general.txtBin_Y.Text;
                oBatch.BINZ = general.txtBin_Z.Text;
                oBatch.DESC_MEMO = general.txtMemo.Text;
                oBatch.DESC_POLE = general.txtPole.Text;
                oBatch.OFF_DISPLAY_ITEM = general.chkOffDisplayItem.Checked.ToString();
                oBatch.COUNTER_ITEM = general.chkCounterItem.Checked.ToString();
                oBatch.ORIPRC = (general.txtOriginalRetailPrice.Text.Length == 0) ? 0 : Convert.ToDecimal(general.txtOriginalRetailPrice.Text);

                ctx.SaveChanges();

                this.ProductBatchId = oBatch.BatchId;
            }
        }

        #endregion

        #region Load Product Batch
        private void LoadProductBatch()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oBatch = ctx.ProductBatch.Find(this.ProductBatchId);
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
                    general.txtCurrentRetailPrice.Text = oBatch.BASPRC.Value.ToString("n2");
                    general.txtWholesalesPrice.Text = oBatch.WHLPRC.Value.ToString("n2");
                    general.cboVendorCurrency.Text = oBatch.VCURR;
                    general.txtVendorPrice.Text = oBatch.VPRC.Value.ToString("n2");
                    order.txtReorderLevel.Text = oBatch.REORDLVL.Value.ToString("n0");
                    order.txtReorderQuantity.Text = oBatch.REORDQTY.Value.ToString("n0");
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
                    general.txtOriginalRetailPrice.Text = oBatch.ORIPRC.Value.ToString("n2");
                }
            }
        }
        #endregion

        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                LoadProductBatch();
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                this.Close();

                ProductWizard_Batch oBatch = new ProductWizard_Batch();
                oBatch.ShowDialog();
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lnkAppendix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductWizard_Combination wizCombin = null;
            LinkLabel lnk = sender as LinkLabel;
            switch (lnk.Name.ToLower())
            {
                case "lnkappendix1":
                    wizCombin = new ProductWizard_Combination(ProductWizard_Combination.FormLayoutType.Appendix1);
                    wizCombin.ShowDialog();
                    break;
                case "lnkappendix2":
                    wizCombin = new ProductWizard_Combination(ProductWizard_Combination.FormLayoutType.Appendix2);
                    wizCombin.ShowDialog();
                    break;
                case "lnkappendix3":
                    wizCombin = new ProductWizard_Combination(ProductWizard_Combination.FormLayoutType.Appendix3);
                    wizCombin.ShowDialog();
                    break;
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

        private void cboAppendix3_LostFocus(object sender, EventArgs e)
        {
            general.txtProductName.Focus();
        }
    }
}