#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;

using Gizmox.WebGUI.Common.Interfaces;
using System.Web;
using System.Configuration;
using System.Linq;
using RT2020.Helper;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_Authorization : Form, IGatewayComponent
    {
        public ProductWizard_Authorization()
        {
            InitializeComponent();
            BindingBatchList();

            SetSystemLabels();
        }

        #region Set System label
        private void SetSystemLabels()
        {
            colPLU.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            colSeason.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            colColor.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            colSize.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion

        #region Bind Methods
        private void BindingBatchList()
        {
            lvHoldBatchList.Items.Clear();

            int iCount = 0;
            string sql = BuildSqlQueryString();
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvHoldBatchList.Items.Add(reader.GetGuid(0).ToString()); // ProductId
                    objItem.SubItems.Add(string.Empty);
                    objItem.SubItems.Add(reader.GetValue(1).ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // ProductCode
                    objItem.SubItems.Add(reader.GetString(3)); // Product Name
                    objItem.SubItems.Add(reader.GetString(4)); // Product Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // Product name Cht
                    objItem.SubItems.Add(reader.GetString(6)); // Nature
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(7), false)); // CreatedOn

                    iCount++;
                }
            }

            lblRecords.Text = string.Format("Rec: {0}", iCount.ToString());
        }

        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT BatchId,  ROW_NUMBER() OVER (ORDER BY STKCODE) AS rownum, ");
            sql.Append(" STKCODE, APP1_COMBIN, APP2_COMBIN, APP3_COMBIN, Description, DATECREATE");
            sql.Append(" FROM ProductBatch ");
            sql.Append(" WHERE STATUS = 'POST' ");

            if (chkSortAndFilter.Checked)
            {
                if (cboSortColumn.Text.Length > 0 && cboOperator.Text != "None")
                {
                    sql.Append(" AND ");
                    sql.Append(ColumnName()).Append(" ");

                    if (cboSortColumn.Text.Contains("Date"))
                    {
                        sql.Append("BETWEEN '");
                        sql.Append(txtData.Tag.ToString()).Append(" 00:00:00'");
                        sql.Append(" AND '");
                        sql.Append(txtData.Tag.ToString()).Append(" 23:59:59'");
                    }
                    else
                    {
                        sql.Append((cboOperator.Text == "=") ? "= '" : "LIKE '%");
                        sql.Append(txtData.Text).Append((cboOperator.Text == "=") ? "'" : "%'");
                    }

                    sql.Append(" ORDER BY ");
                    sql.Append(ColumnName());
                    sql.Append((cboOrdering.Text == "Ascending") ? " ASC" : " DESC");
                }
            }

            return sql.ToString();
        }

        private string ColumnName()
        {
            string colName = string.Empty;
            switch (cboSortColumn.Text)
            {
                case "Season":
                    colName = "APP1_COMBIN";
                    break;
                case "Color":
                    colName = "APP2_COMBIN";
                    break;
                case "Size":
                    colName = "APP3_COMBIN";
                    break;
                case "Description":
                    colName = "Description";
                    break;
                case "Date Create(dd/MM/yyyy)":
                    colName = "DATECREATE";
                    break;
                default:
                case "PLU":
                    colName = "STKCODE";
                    break;
            }
            return colName;
        }

        private bool VerifyDate()
        {
            bool isVerified = true;
            if (cboSortColumn.Text.Contains("Date"))
            {
                string pattern = @"^\d{1,2}\/\d{1,2}\/\d{4}$";
                Regex rex = new Regex(pattern);
                Match match = rex.Match(txtData.Text);
                if (!match.Success)
                {
                    errorProvider.SetError(txtData, "Incorrect Date Format! (Date Format:dd/MM/yyyy)");
                    isVerified = false;
                }
                else
                {
                    errorProvider.SetError(txtData, string.Empty);
                    FormatDate();
                }
            }
            return isVerified;
        }

        private void FormatDate()
        {
            string[] dateValue = txtData.Text.Split('/');
            txtData.Tag = dateValue[2] + "-" + dateValue[1] + "-" + dateValue[0];
        }
        #endregion

        #region IGatewayComponent Members

        /// <summary>
        /// Provides a way to custom handle requests.
        /// </summary>
        /// <param name="objContext">The request context.</param>
        /// <param name="strAction">The request action.</param>
        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            RT2020.Product.Reports.ProductBatchList_Pdf report = new RT2020.Product.Reports.ProductBatchList_Pdf();

            report.DataSource = BindData();
            HttpResponse objResponse = this.Context.HttpContext.Response;

            System.IO.MemoryStream memStream = new System.IO.MemoryStream();

            objResponse.Clear();
            objResponse.ClearHeaders();

            // Export the report to PDF.
            report.ExportToPdf(memStream);
            objResponse.ContentType = "application/pdf";
            objResponse.AddHeader("content-disposition", "attachment; filename=ProductBatchList.pdf");

            objResponse.BinaryWrite(memStream.ToArray());
            objResponse.Flush();
            objResponse.End();
        }

        private DataTable BindData()
        {
            string sql = @"SELECT  
                               STKCODE, APP1_COMBIN, APP2_COMBIN, APP3_COMBIN, CLASS1,  
                               CLASS2, CLASS3, CLASS4, CLASS5, CLASS6, [Description], MAINUNIT,  
                               ALTITEM, REMARKS, MARKUP, BASPRC, WHLPRC, VCURR, VPRC, ORIPRC,  
                               NRDISC, REORDLVL, REORDQTY, SERIALFLAG, NATURE, REMARK1,  
                               REMARK2, REMARK3, REMARK4, PHOTO, STK_MEMO, [STATUS] AS STATUSDESC, CONVERT(VARCHAR(10), DATEPOST, 103) AS DATEPOST,  
                               RETAILITEM, BINX, BINY, BINZ, DESC_MEMO, DESC_POLE,  
                               CONVERT(VARCHAR(10), DATECREATE, 103) AS DATECREATE, CONVERT(VARCHAR(10), DATELCHG, 103) AS DATELCHG, USERLCHG  
                           FROM ProductBatch
                           WHERE STATUS = 'POST' ";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        #endregion

        #region Posting Batch

        #region Combination
        private ListView Combin()
        {
            ListView oList = null;

            oList = new ListView();

            foreach (ListViewItem oItem in this.lvHoldBatchList.Items)
            {
                if (oItem.SubItems[1].Text == "*")
                {
                    CombinA1(oItem, ref oList);
                }
            }

            return oList;
        }

        private void CombinA1(ListViewItem oItem, ref ListView oList)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "DimCode = '" + oItem.SubItems[4].Text + "'";
                var oDim = ctx.ProductDim.Where(x => x.DimCode == oItem.SubItems[4].Text).FirstOrDefault();
                if (oDim != null)
                {
                    //sql = "DimensionId = '" + oDim.DimensionId.ToString() + "'";
                    var detailList = ctx.ProductDim_Details.Where(x => x.DimensionId == oDim.DimensionId).ToList();
                    foreach (var detail in detailList)
                    {
                        if (!string.IsNullOrEmpty(detail.APPENDIX1))
                        {
                            CombinA2(oItem, ref oList, oItem.SubItems[0].Text, oItem.SubItems[3].Text, detail.APPENDIX1);
                        }
                    }
                }
            }
        }

        private void CombinA2(ListViewItem oItem, ref ListView oList, string batchId, string stk, string a1)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "DimCode = '" + oItem.SubItems[5].Text + "'";
                var oDim = ctx.ProductDim.Where(x => x.DimCode == oItem.SubItems[4].Text).FirstOrDefault();
                if (oDim != null)
                {
                    //sql = "DimensionId = '" + oDim.DimensionId.ToString() + "'";
                    var detailList = ctx.ProductDim_Details.Where(x => x.DimensionId == oDim.DimensionId).ToList();
                    foreach (var detail in detailList)
                    {
                        if (!string.IsNullOrEmpty(detail.APPENDIX2))
                        {
                            CombinA3(oItem, ref oList, batchId, stk, a1, detail.APPENDIX2);
                        }
                    }

                    if (detailList.Count == 0)
                    {
                        AddToList(ref oList, batchId, stk, a1, string.Empty, string.Empty);
                    }
                }
                else
                {
                    AddToList(ref oList, batchId, stk, a1, string.Empty, string.Empty);
                }
            }
        }

        private void CombinA3(ListViewItem oItem, ref ListView oList, string batchId, string stk, string a1, string a2)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "DimCode = '" + oItem.SubItems[6].Text + "'";
                var oDim = ctx.ProductDim.Where(x => x.DimCode == oItem.SubItems[4].Text).FirstOrDefault();
                if (oDim != null)
                {
                    //sql = "DimensionId = '" + oDim.DimensionId.ToString() + "'";
                    var detailList = ctx.ProductDim_Details.Where(x => x.DimensionId == oDim.DimensionId).ToList();
                    foreach (var detail in detailList)
                    {
                        if (!string.IsNullOrEmpty(detail.APPENDIX3))
                        {
                            AddToList(ref oList, batchId, stk, a1, a2, detail.APPENDIX3);
                        }
                    }

                    if (detailList.Count == 0)
                    {
                        AddToList(ref oList, batchId, stk, a1, a2, string.Empty);
                    }
                }
                else
                {
                    AddToList(ref oList, batchId, stk, a1, a2, string.Empty);
                }
            }
        }

        private void AddToList(ref ListView oList, string batchId, string stk, string a1, string a2, string a3)
        {
            ListViewItem objItem = oList.Items.Add((oList.Items.Count + 1).ToString());
            objItem.SubItems.Add(batchId);
            objItem.SubItems.Add(stk);
            objItem.SubItems.Add(a1);
            objItem.SubItems.Add(a2);
            objItem.SubItems.Add(a3);
            objItem.SubItems.Add(ModelEx.ProductAppendix1Ex.GetIdByInitial(a1).ToString());
            objItem.SubItems.Add(ModelEx.ProductAppendix2Ex.GetIdByInitial(a2).ToString());
            objItem.SubItems.Add(ModelEx.ProductAppendix3Ex.GetIdByInitial(a3).ToString());
        }
        #endregion

        private int SelectedColumnsCounting()
        {
            int iCount = 0;

            foreach (ListViewItem objItem in this.lvHoldBatchList.Items)
            {
                if (objItem.SubItems[1].Text == "*")
                {
                    iCount++;
                }
            }

            return iCount;
        }

        private bool IsValid()
        {
            return true;
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
            using (var ctx = new EF6.RT2020Entities())
            {
                // Check BatchId(listItem.SubItems[1].Text) and Stock Code(listItem.SubItems[2].Text)
                Guid batchId = Guid.Empty;
                if (IsValid() && Guid.TryParse(listItem.SubItems[1].Text, out batchId) && listItem.SubItems[2].Text.Length > 0)
                {
                    var oBatch = ctx.ProductBatch.Find(batchId);
                    if (oBatch != null)
                    {
                        string a1 = listItem.SubItems[3].Text.Trim();
                        string a2 = listItem.SubItems[4].Text.Trim();
                        string a3 = listItem.SubItems[5].Text.Trim();

                        Guid a1Id = Guid.Empty, a2Id = Guid.Empty, a3Id = Guid.Empty;
                        Guid.TryParse(listItem.SubItems[6].Text, out a1Id);
                        Guid.TryParse(listItem.SubItems[7].Text, out a2Id);
                        Guid.TryParse(listItem.SubItems[8].Text, out a3Id);

                        string prodCode = listItem.SubItems[2].Text + a1 + a2 + a3;
                        if (prodCode.Length <= 22)
                        {
                            var stkcode = listItem.SubItems[2].Text.Trim();

                            StringBuilder sql = new StringBuilder();
                            sql.Append(" STKCODE = '").Append(listItem.SubItems[2].Text.Trim()).Append("' ");
                            sql.Append(" AND APPENDIX1 = '").Append(a1.Trim()).Append("' ");
                            sql.Append(" AND APPENDIX2 = '").Append(a2.Trim()).Append("' ");
                            sql.Append(" AND APPENDIX3 = '").Append(a3.Trim()).Append("' ");

                            var oItem = ctx.Product.Where(x => x.STKCODE == stkcode && x.APPENDIX1 == a1 && x.APPENDIX2 == a2 && x.APPENDIX3 == a3).FirstOrDefault();
                            if (oItem == null)
                            {
                                #region add new Product
                                oItem = new EF6.Product();
                                oItem.ProductId = Guid.NewGuid();
                                oItem.STKCODE = listItem.SubItems[2].Text;
                                oItem.APPENDIX1 = a1;
                                oItem.APPENDIX2 = a2;
                                oItem.APPENDIX3 = a3;

                                oItem.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                                oItem.CLASS1 = oBatch.CLASS1;
                                oItem.CLASS2 = oBatch.CLASS2;
                                oItem.CLASS3 = oBatch.CLASS3;
                                oItem.CLASS4 = oBatch.CLASS4;
                                oItem.CLASS5 = oBatch.CLASS5;
                                oItem.CLASS6 = oBatch.CLASS6;

                                oItem.ProductName = oBatch.Description;
                                oItem.ProductName_Chs = oBatch.Description;
                                oItem.ProductName_Cht = oBatch.Description;
                                oItem.Remarks = oBatch.REMARKS;

                                oItem.NormalDiscount = oBatch.NRDISC.Value;
                                oItem.UOM = oBatch.MAINUNIT;
                                oItem.NatureId = ModelEx.ProductNatureEx.GetIdByCode(oBatch.NATURE);

                                oItem.FixedPriceItem = false;

                                oItem.CreatedBy = ConfigHelper.CurrentUserId;
                                oItem.CreatedOn = DateTime.Now;
                                oItem.ModifiedBy = ConfigHelper.CurrentUserId;
                                oItem.ModifiedOn = DateTime.Now;

                                ctx.Product.Add(oItem);

                                var productId = oItem.ProductId;
                                #endregion

                                #region SaveProductBarcode(oBatch, productId, prodCode);
                                var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oBarcode == null)
                                {
                                    oBarcode = new EF6.ProductBarcode();
                                    oBarcode.ProductBarcodeId = Guid.NewGuid();
                                    oBarcode.ProductId = productId;
                                    oBarcode.Barcode = prodCode;
                                    oBarcode.BarcodeType = "INTER";
                                    oBarcode.PrimaryBarcode = true;
                                    oBarcode.DownloadToPOS = (oBatch.RETAILITEM == "F") ? false : true;
                                    oBarcode.DownloadToCounter = (oBatch.COUNTER_ITEM == "F") ? false : true;

                                    ctx.ProductBarcode.Add(oBarcode);
                                    ctx.SaveChanges();
                                }
                                #endregion

                                #region Appendix / Class
                                System.Guid c1Id = ModelEx.ProductClass1Ex.GetClassIdByCode(oBatch.CLASS1);
                                System.Guid c2Id = ModelEx.ProductClass2Ex.GetClassIdByCode(oBatch.CLASS2);
                                System.Guid c3Id = ModelEx.ProductClass3Ex.GetClassIdByCode(oBatch.CLASS3);
                                System.Guid c4Id = ModelEx.ProductClass4Ex.GetClassIdByCode(oBatch.CLASS4);
                                System.Guid c5Id = ModelEx.ProductClass5Ex.GetClassIdByCode(oBatch.CLASS5);
                                System.Guid c6Id = ModelEx.ProductClass6Ex.GetClassIdByCode(oBatch.CLASS6);
                                // SaveProductCode(productId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);
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

                                // Product Price
                                #region SaveProductSupplement(oBatch, oItem.ProductId);
                                //string sql = "ProductId = '" + productId.ToString() + "'";
                                var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oProdSupp == null)
                                {
                                    oProdSupp = new EF6.ProductSupplement();
                                    oProdSupp.SupplementId = Guid.NewGuid();
                                    oProdSupp.ProductId = productId;

                                    ctx.ProductSupplement.Add(oProdSupp);
                                }
                                oProdSupp.VendorCurrencyCode = oBatch.VCURR;
                                oProdSupp.VendorPrice = oBatch.VPRC;
                                oProdSupp.ProductName_Memo = oBatch.DESC_MEMO;
                                oProdSupp.ProductName_Pole = oBatch.DESC_POLE;

                                ctx.SaveChanges();
                                #endregion

                                #region SaveProductPrice(oBatch, oItem.ProductId);
                                SaveProductPrice(productId, ProductHelper.Prices.BASPRC.ToString(), "HKD", oBatch.BASPRC.ToString());
                                SaveProductPrice(productId, ProductHelper.Prices.ORIPRC.ToString(), "HKD", oBatch.ORIPRC.ToString());
                                SaveProductPrice(productId, ProductHelper.Prices.VPRC.ToString(), oBatch.VCURR, oBatch.VPRC.ToString());
                                SaveProductPrice(productId, ProductHelper.Prices.WHLPRC.ToString(), "HKD", oBatch.WHLPRC.ToString());
                                #endregion

                                // Remarks
                                #region SaveProductRemarks(oBatch, oItem.ProductId);
                                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oRemarks == null)
                                {
                                    oRemarks = new EF6.ProductRemarks();
                                    oRemarks.ProductRemarksId = Guid.NewGuid();
                                    oRemarks.ProductId = productId;

                                    ctx.ProductRemarks.Add(oRemarks);
                                }
                                oRemarks.Photo = oBatch.PHOTO;

                                oRemarks.BinX = oBatch.BINX;
                                oRemarks.BinY = oBatch.BINY;
                                oRemarks.BinZ = oBatch.BINZ;

                                oRemarks.DownloadToShop = (oBatch.RETAILITEM == "F") ? false : true;
                                oRemarks.OffDisplayItem = (oBatch.OFF_DISPLAY_ITEM == "F") ? false : true;
                                oRemarks.DownloadToCounter = (oBatch.COUNTER_ITEM == "F") ? false : true;

                                oRemarks.REMARK1 = oBatch.REMARK1;
                                oRemarks.REMARK2 = oBatch.REMARK2;
                                oRemarks.REMARK3 = oBatch.REMARK3;
                                oRemarks.REMARK4 = oBatch.REMARK4;
                                oRemarks.REMARK5 = oBatch.REMARK5;
                                oRemarks.REMARK6 = oBatch.REMARK6;

                                ctx.SaveChanges();
                                #endregion

                                oBatch.STATUS = "OK";
                                ctx.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        private void SaveProductPrice(Guid productId, string priceType, string currencyCode, string price)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                //string sql = "ProductId = '" + productId.ToString() + "' AND PriceTypeId = '" + priceTypeId.ToString() + "'";

                var oPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.ProductPriceId == priceTypeId).FirstOrDefault();
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

        private void SaveProductBarcode(EF6.ProductBatch oBatch, Guid productid, string barcode)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + productid.ToString() + "' AND Barcode = '" + barcode + "'";
                var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == productid).FirstOrDefault();
                if (oBarcode == null)
                {
                    oBarcode = new EF6.ProductBarcode();
                    oBarcode.ProductBarcodeId = Guid.NewGuid();
                    oBarcode.ProductId = productid;
                    oBarcode.Barcode = barcode;
                    oBarcode.BarcodeType = "INTER";
                    oBarcode.PrimaryBarcode = true;
                    oBarcode.DownloadToPOS = (oBatch.RETAILITEM == "F") ? false : true;
                    oBarcode.DownloadToCounter = (oBatch.COUNTER_ITEM == "F") ? false : true;

                    ctx.ProductBarcode.Add(oBarcode);
                    ctx.SaveChanges();
                }
            }
        }
        /**
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
        
        private void SaveProductSupplement(ProductBatch oBatch, Guid productId)
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
                oProdSupp.VendorCurrencyCode = oBatch.VCURR;
                oProdSupp.VendorPrice = oBatch.VPRC;
                oProdSupp.ProductName_Memo = oBatch.DESC_MEMO;
                oProdSupp.ProductName_Pole = oBatch.DESC_POLE;

                ctx.SaveChanges();
            }
        }

        private void SaveProductPrice(ProductBatch oBatch, Guid productId)
        {
            SaveProductPrice(productId, ProductHelper.Prices.BASPRC.ToString(), "HKD", oBatch.BASPRC.ToString());
            SaveProductPrice(productId, ProductHelper.Prices.ORIPRC.ToString(), "HKD", oBatch.ORIPRC.ToString());
            SaveProductPrice(productId, ProductHelper.Prices.VPRC.ToString(), oBatch.VCURR, oBatch.VPRC.ToString());
            SaveProductPrice(productId, ProductHelper.Prices.WHLPRC.ToString(), "HKD", oBatch.WHLPRC.ToString());
        }

        private void SaveProductRemarks(ProductBatch oBatch, Guid productId)
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
                oRemarks.Photo = oBatch.PHOTO;

                oRemarks.BinX = oBatch.BINX;
                oRemarks.BinY = oBatch.BINY;
                oRemarks.BinZ = oBatch.BINZ;

                oRemarks.DownloadToShop = (oBatch.RETAILITEM == "F") ? false : true;
                oRemarks.OffDisplayItem = (oBatch.OFF_DISPLAY_ITEM == "F") ? false : true;
                oRemarks.DownloadToCounter = (oBatch.COUNTER_ITEM == "F") ? false : true;

                oRemarks.REMARK1 = oBatch.REMARK1;
                oRemarks.REMARK2 = oBatch.REMARK2;
                oRemarks.REMARK3 = oBatch.REMARK3;
                oRemarks.REMARK4 = oBatch.REMARK4;
                oRemarks.REMARK5 = oBatch.REMARK5;
                oRemarks.REMARK6 = oBatch.REMARK6;

                ctx.SaveChanges();
            }
        }
        */
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (VerifyDate())
            {
                BindingBatchList();
            }
        }

        private void chkSortAndFilter_Click(object sender, EventArgs e)
        {
            cboSortColumn.Enabled = chkSortAndFilter.Checked;
            cboSortColumn.SelectedIndex = 0;

            cboOrdering.Enabled = chkSortAndFilter.Checked;
            cboOrdering.SelectedIndex = 0;

            cboOperator.Enabled = chkSortAndFilter.Checked;
            cboOperator.SelectedIndex = 0;

            txtData.Enabled = chkSortAndFilter.Checked;
            btnReload.Enabled = chkSortAndFilter.Checked;
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem objItem in this.lvHoldBatchList.Items)
            {
                if (btnMarkAll.Text.Contains("Mark") && !objItem.SubItems[1].Text.Contains("*"))
                {
                    objItem.SubItems[1].Text = "*";
                }
                else if (btnMarkAll.Text.Contains("Unmark"))
                {
                    objItem.SubItems[1].Text = string.Empty;
                }
            }
            this.Update();

            btnMarkAll.Text = (btnMarkAll.Text == "Mark All") ? "Unmark All" : "Mark All";
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (SelectedColumnsCounting() > 0)
            {
                int result = CreateProducts();
                if (result > 0)
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                    MessageBox.Show(result.ToString() + " succeed!", "Posting result", MessageBoxButtons.OK, new EventHandler(PostingMessageHandler));
                }
                else
                {
                    MessageBox.Show(result.ToString() + " succeed!", "Posting result", MessageBoxButtons.OK, MessageBoxIcon.Warning, new EventHandler(PostingMessageHandler));
                }
            }
            else
            {
                MessageBox.Show("No Record Selected!");
            }
        }

        private void PostingMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                BindingBatchList();
            }
        }

        private void lvHoldBatchList_Click(object sender, EventArgs e)
        {
            if (lvHoldBatchList.Items != null && lvHoldBatchList.SelectedIndex >= 0)
            {
                int index = lvHoldBatchList.SelectedIndex;
                this.lvHoldBatchList.Items[index].SubItems[1].Text = (this.lvHoldBatchList.Items[index].SubItems[1].Text.Length == 0) ? "*" : string.Empty;
                //this.Update();
            }
        }
    }
}