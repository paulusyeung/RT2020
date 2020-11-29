namespace RT2020.Inventory.GoodsReceive
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;

    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Forms;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;
    using RT2020.DAL;
    using Gizmox.WebGUI.Common.Resources;
    using System.Configuration;

    #endregion

    public partial class Authorization : Form
    {
        private RT2020.Controls.InvtUtility.PostingStatus postStatus = RT2020.Controls.InvtUtility.PostingStatus.Ready;
        DataTable oTable;

        public Authorization()
        {
            InitializeComponent();
            InitComboBox();

            BindingList(Common.Enums.Status.Active); // Posting
            BindingList(Common.Enums.Status.Draft); // Holding
        }

        #region Init

        private void InitComboBox()
        {
            txtPostedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, true);
            txtSysMonth.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth;
            txtSysYear.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear;

            cboFieldName.SelectedIndex = 0;
            cboOperator.SelectedIndex = 0;
            cboOrdering.SelectedIndex = 0;
        }

        #endregion

        #region Bind Methods
        private SqlDataReader DataSource(string status, bool conditions)
        {
            string sql = BuildSqlQueryString(status, conditions);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            return SqlHelper.Default.ExecuteReader(cmd);
        }

        private void BindingList(Common.Enums.Status status)
        {
            SqlDataReader reader;
            switch (status)
            {
                case Common.Enums.Status.Draft: // Holding
                    reader = DataSource(Common.Enums.Status.Draft.ToString("d"), false);
                    BindingHoldingList(reader);
                    break;
                case Common.Enums.Status.Active: // Posting
                    reader = DataSource(Common.Enums.Status.Active.ToString("d"), true);
                    BindingPostingList(reader);
                    break;
            }
        }

        private void BindingHoldingList(SqlDataReader reader)
        {
            lvHoldingTxList.Items.Clear();

            int iCount = 1;

            while (reader.Read())
            {
                ListViewItem objItem = this.lvHoldingTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                objItem.SubItems.Add(string.Empty);
                objItem.SubItems.Add(iCount.ToString()); // Line Number
                objItem.SubItems.Add(reader.GetString(2)); // TxNumber
                objItem.SubItems.Add(reader.GetString(1)); // Type
                objItem.SubItems.Add(reader.GetString(5)); // Location
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                objItem.SubItems.Add(reader.GetString(6)); // Supplier
                objItem.SubItems.Add(reader.GetString(4)); // StaffNumber
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(9), false)); // CreatedOn

                iCount++;
            }

            reader.Close();
        }

        private void BindingPostingList(SqlDataReader reader)
        {
            lvPostTxList.CheckBoxes = true;
            lvPostTxList.Items.Clear();

            int iCount = 1;

            while (reader.Read())
            {
                ListViewItem objItem = this.lvPostTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                objItem.SubItems.Add(new IconResourceHandle("16x16.16_progress.gif").ToString());
                objItem.SubItems.Add(iCount.ToString()); // Line Number
                objItem.SubItems.Add(reader.GetString(2)); // TxNumber
                objItem.SubItems.Add(reader.GetString(1)); // Type
                objItem.SubItems.Add(reader.GetString(5)); // Location
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                objItem.SubItems.Add(reader.GetString(6)); // Supplier
                objItem.SubItems.Add(reader.GetString(4)); // StaffNumber
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(9), false)); // CreatedOn
                objItem.BackColor = CheckTxDate(reader.GetDateTime(3)) ? Color.Transparent : RT2020.SystemInfo.ControlBackColor.DisabledBox;

                iCount++;
            }

            reader.Close();
        }

        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT HeaderId, TxType, TxNumber, TxDate, StaffNumber, Location, SupplierCode, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy ");
            sql.Append(" FROM vwDraftCAPList ");
            sql.Append(" WHERE STATUS = ").Append(status).Append(" AND TxType = 'CAP' AND ReadOnly = 0");

            if (txtTxNumber.Text.Trim().Length > 0)
            {
                sql.Append(" AND TxNumber LIKE '%").Append(txtTxNumber.Text.Trim()).Append("%'");
            }
            else if (chkSortAndFilter.Checked && withConditions)
            {
                if (cboFieldName.Text.Length > 0 && cboOperator.Text != "None")
                {
                    sql.Append(" AND ");
                    sql.Append(ColumnName()).Append(" ");

                    if (cboFieldName.Text.Contains("Date"))
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
                }

                sql.Append(" ORDER BY ");
                sql.Append(ColumnName());
                sql.Append((cboOrdering.Text == "Ascending") ? " ASC" : " DESC");
            }

            return sql.ToString();
        }

        private string ColumnName()
        {
            string colName = string.Empty;
            switch (cboFieldName.Text)
            {
                case "Type":
                    colName = "TxType";
                    break;
                case "LOC#":
                    colName = "Location";
                    break;
                case "Receive Date (dd/MM/yyyy)":
                    colName = "TxDate";
                    break;
                case "Supplier#":
                    colName = "SupplierCode";
                    break;
                case "Operator":
                    colName = "StaffNumber";
                    break;
                case "Last Update (dd/MM/yyyy)":
                    colName = "ModifiedOn";
                    break;
                default:
                case "CAP#":
                    colName = "TxNumber";
                    break;
            }
            return colName;
        }

        private bool VerifyDate()
        {
            errorProvider.SetError(txtTxNumber, string.Empty);

            bool isVerified = true;
            if (cboFieldName.Text.Contains("Date") && cboOperator.Text != "None")
            {
                string pattern = @"^\d{1,2}\/\d{1,2}\/\d{4}$";
                Regex rex = new Regex(pattern);
                Match match = rex.Match(txtData.Text);
                if (!match.Success)
                {
                    errorProvider.SetError(lblData, "Incorrect Date Format! (Date Format:dd/MM/yyyy)");
                    isVerified = false;
                }
                else
                {
                    errorProvider.SetError(lblData, string.Empty);
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

        #region Verify

        private DataTable ErrorMessageTable()
        {
            DataTable oTable = new DataTable();

            oTable.Columns.Add("HeaderId", typeof(string));
            oTable.Columns.Add("TxNumber", typeof(string));
            oTable.Columns.Add("STKCODE", typeof(string));
            oTable.Columns.Add("APPENDIX1", typeof(string));
            oTable.Columns.Add("APPENDIX2", typeof(string));
            oTable.Columns.Add("APPENDIX3", typeof(string));
            oTable.Columns.Add("ErrorReason", typeof(string));
            oTable.Columns.Add("PostDate", typeof(DateTime));

            return oTable;
        }

        private int SelectedColumnsCounting()
        {
            int iCount = 0;
            oTable = ErrorMessageTable();

            foreach (ListViewItem objItem in this.lvPostTxList.Items)
            {
                if (objItem.Checked)
                {
                    if (!IsPostable(objItem.Text, ref oTable))
                    {
                        objItem.SubItems[1].Text = new IconResourceHandle("16x16.16_error.gif").ToString();
                        postStatus = RT2020.Controls.InvtUtility.PostingStatus.Error;
                    }

                    colPostingStatus.Visible = true;
                    this.Update();

                    iCount++;
                }
                else
                {
                    objItem.SubItems[1].Text = string.Empty;
                }
            }

            if (postStatus == RT2020.Controls.InvtUtility.PostingStatus.Ready)
            {
                postStatus = RT2020.Controls.InvtUtility.PostingStatus.Postable;
            }

            return iCount;
        }

        private bool IsPostable(string headerId, ref DataTable errorTable)
        {
            bool isPostable = true;

            if (Common.Utility.IsGUID(headerId))
            {
                InvtBatchCAP_Header oBatchHeader = InvtBatchCAP_Header.Load(new Guid(headerId));
                if (oBatchHeader != null)
                {
                    if (!CheckTxDate(oBatchHeader.TxDate))
                    {
                        DataRow row = errorTable.NewRow();
                        row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                        row["TxNumber"] = oBatchHeader.TxNumber;
                        row["STKCODE"] = string.Empty;
                        row["APPENDIX1"] = string.Empty;
                        row["APPENDIX2"] = string.Empty;
                        row["APPENDIX3"] = string.Empty;
                        row["ErrorReason"] = "Transaction date does not belong to current system month.";
                        row["PostDate"] = DateTime.Now;

                        errorTable.Rows.Add(row);

                        isPostable = isPostable & false;
                    }

                    if (oBatchHeader.ReadOnly && oBatchHeader.Status == (int)Common.Enums.Status.Active)
                    {
                        DataRow row = errorTable.NewRow();
                        row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                        row["TxNumber"] = oBatchHeader.TxNumber;
                        row["STKCODE"] = string.Empty;
                        row["APPENDIX1"] = string.Empty;
                        row["APPENDIX2"] = string.Empty;
                        row["APPENDIX3"] = string.Empty;
                        row["ErrorReason"] = "Transaction already had been posted! Cannot post again!";
                        row["PostDate"] = DateTime.Now;

                        errorTable.Rows.Add(row);

                        isPostable = isPostable & false;
                    }

                    InvtBatchCAP_DetailsCollection detailList = InvtBatchCAP_Details.LoadCollection("HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'");
                    foreach (InvtBatchCAP_Details detail in detailList)
                    {
                        bool retired = false;
                        string stk = string.Empty, a1 = string.Empty, a2 = string.Empty, a3 = string.Empty;

                        Product oProduct = Product.Load(detail.ProductId);
                        if (oProduct != null)
                        {
                            stk = oProduct.STKCODE;
                            a1 = oProduct.APPENDIX1;
                            a2 = oProduct.APPENDIX2;
                            a3 = oProduct.APPENDIX3;
                            retired = oProduct.Retired;
                        }

                        if (retired)
                        {
                            DataRow row = errorTable.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = stk;
                            row["APPENDIX1"] = a1;
                            row["APPENDIX2"] = a2;
                            row["APPENDIX3"] = a3;
                            row["ErrorReason"] = "Product does not exist or has been removed!";
                            row["PostDate"] = DateTime.Now;

                            errorTable.Rows.Add(row);

                            isPostable = isPostable & false;
                        }
                    }

                    RT2020.DAL.Staff oStaff = RT2020.DAL.Staff.Load(oBatchHeader.StaffId);
                    if (oStaff != null)
                    {
                        if (oStaff.Retired)
                        {
                            DataRow row = errorTable.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = string.Empty;
                            row["APPENDIX1"] = string.Empty;
                            row["APPENDIX2"] = string.Empty;
                            row["APPENDIX3"] = string.Empty;
                            row["ErrorReason"] = "Staff does not exist or has been removed!";
                            row["PostDate"] = DateTime.Now;

                            errorTable.Rows.Add(row);

                            isPostable = isPostable & false;
                        }
                    }

                    InvtLedgerHeader oInvtLedger = InvtLedgerHeader.LoadWhere("TxNumber = '" + oBatchHeader.TxNumber + "' AND TxType = 'CAP'");
                    if (oInvtLedger != null)
                    {
                        DataRow row = errorTable.NewRow();
                        row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                        row["TxNumber"] = oBatchHeader.TxNumber;
                        row["STKCODE"] = string.Empty;
                        row["APPENDIX1"] = string.Empty;
                        row["APPENDIX2"] = string.Empty;
                        row["APPENDIX3"] = string.Empty;
                        row["ErrorReason"] = "Transaction existed in Inventory Ledger!";
                        row["PostDate"] = DateTime.Now;

                        errorTable.Rows.Add(row);

                        isPostable = isPostable & false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return isPostable;
        }

        private decimal GetCDQty(Guid productId, Guid workplaceId)
        {
            decimal cdQty = 0;
            string sql = "ProductId = '" + productId.ToString() + "' AND WorkplaceId = '" + workplaceId.ToString() + "'";
            ProductWorkplace wpProd = ProductWorkplace.LoadWhere(sql);
            if (wpProd != null)
            {
                cdQty = wpProd.CDQTY;
            }
            return cdQty;
        }

        private bool CheckTxDate(DateTime txDate)
        {
            bool isChecked = false;

            isChecked = (txDate.Year.ToString() == RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear);
            isChecked = isChecked & (txDate.Month.ToString().PadLeft(2, '0') == RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth);

            return isChecked;
        }

        private bool HasError(string headerId)
        {
            if (oTable == null)
            {
                return false;
            }

            DataRow[] rows = oTable.Select("HeaderId = '" + headerId + "'");
            return rows.Length > 0;
        }

        #endregion

        #region Posting Batch

        private int CreateCAPTx()
        {
            int iCount = 0;
            if (lvPostTxList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvPostTxList.CheckedItems)
                {
                    if (Common.Utility.IsGUID(oItem.Text) && oItem.Checked)
                    {
                        if (!HasError(oItem.Text))
                        {
                            CreateCAPTx(new Guid(oItem.Text), ref iCount);

                            oItem.SubItems[1].Text = new IconResourceHandle("16x16.16_succeeded.png").ToString();
                        }
                    }
                }
            }
            return iCount;
        }

        private void CreateCAPTx(Guid headerId, ref int iCount)
        {
            InvtBatchCAP_Header oBatchHeader = InvtBatchCAP_Header.Load(headerId);
            if (oBatchHeader != null)
            {
                //if (postStatus == RT2020.Controls.InvtUtility.PostingStatus.Postable)
                //{
                // Update Product Info
                UpdateProduct(oBatchHeader.HeaderId, oBatchHeader.WorkplaceId);

                // Create CAP SubLedger
                string txNumber_SubLedger = oBatchHeader.TxNumber;
                System.Guid subLedgerHeaderId = CreateCAPSubLedgerHeader(oBatchHeader);
                CreateCAPSubLedgerDetail(txNumber_SubLedger, oBatchHeader.HeaderId, subLedgerHeaderId);

                // Create Ledger for TxType 'CAP'
                string txNumber_Ledger = oBatchHeader.TxNumber;
                System.Guid ledgerHeaderId = CreateLedgerHeader(oBatchHeader, subLedgerHeaderId);
                CreateLedgerDetails(txNumber_Ledger, subLedgerHeaderId, ledgerHeaderId, oBatchHeader.TxDate, ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId), this.GetStaffCode(oBatchHeader.StaffId));

                // Update Batch Header Info
                oBatchHeader.ReadOnly = true;
                oBatchHeader.ModifiedBy = Common.Config.CurrentUserId;
                oBatchHeader.ModifiedOn = DateTime.Now;
                oBatchHeader.Save();

                iCount++;

                ClearBatchTransaction(oBatchHeader);
                //}
            }
        }

        #region Clear Batch

        /// <summary>
        /// Clears the batch transaction.
        /// </summary>
        private void ClearBatchTransaction(InvtBatchCAP_Header oBatchHeader)
        {
            string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
            InvtBatchCAP_DetailsCollection detailList = InvtBatchCAP_Details.LoadCollection(query);
            for (int i = 0; i < detailList.Count; i++)
            {
                detailList[i].Delete();
            }

            oBatchHeader.Delete();
        }

        #endregion

        #region SubLedger
        private Guid CreateCAPSubLedgerHeader(InvtBatchCAP_Header oBatchHeader)
        {
            InvtSubLedgerCAP_Header oSubCAP = new InvtSubLedgerCAP_Header();
            oSubCAP.TxNumber = oBatchHeader.TxNumber;
            oSubCAP.TxType = Common.Enums.TxType.CAP.ToString();
            oSubCAP.WorkplaceId = oBatchHeader.WorkplaceId;
            oSubCAP.TxDate = oBatchHeader.TxDate;
            oSubCAP.CurrencyCode = oBatchHeader.CurrencyCode;
            oSubCAP.ExchangeRate = oBatchHeader.ExchangeRate;
            oSubCAP.LinkToAP = oBatchHeader.LinkToAP;
            oSubCAP.ReadOnly = oBatchHeader.ReadOnly;
            oSubCAP.Reference = oBatchHeader.Reference;
            oSubCAP.Remarks = oBatchHeader.Remarks;
            oSubCAP.StaffId = oBatchHeader.StaffId;
            oSubCAP.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));
            oSubCAP.SupplierId = oBatchHeader.SupplierId;
            oSubCAP.SupplierRefernce = oBatchHeader.SupplierRefernce;

            oSubCAP.CreatedBy = Common.Config.CurrentUserId;
            oSubCAP.CreatedOn = DateTime.Now;
            oSubCAP.ModifiedBy = Common.Config.CurrentUserId;
            oSubCAP.ModifiedOn = DateTime.Now;

            oSubCAP.Save();

            return oSubCAP.HeaderId;
        }

        private void CreateCAPSubLedgerDetail(string txnumber, Guid batchHeaderId, Guid subledgerHeaderId)
        {
            decimal ttlAmt = 0;
            string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
            string[] orderBy = new string[] { "LineNumber" };
            InvtBatchCAP_DetailsCollection oBatchDetails = InvtBatchCAP_Details.LoadCollection(sql, orderBy, true);
            foreach (InvtBatchCAP_Details oBDetail in oBatchDetails)
            {
                InvtSubLedgerCAP_Details oSubLedgerDetail = new InvtSubLedgerCAP_Details();
                oSubLedgerDetail.HeaderId = subledgerHeaderId;
                oSubLedgerDetail.LineNumber = oBDetail.LineNumber;
                oSubLedgerDetail.ProductId = oBDetail.ProductId;
                oSubLedgerDetail.Qty = oBDetail.Qty;
                oSubLedgerDetail.TxNumber = txnumber;
                oSubLedgerDetail.TxType = Common.Enums.TxType.CAP.ToString();
                oSubLedgerDetail.UnitAmount = oBDetail.UnitAmount;
                oSubLedgerDetail.UnitAmountInForeignCurrency = oBDetail.UnitAmountInForeignCurrency;

                oSubLedgerDetail.Save();

                ttlAmt += oSubLedgerDetail.Qty * oSubLedgerDetail.UnitAmount;
            }

            InvtSubLedgerCAP_Header oSubLedgerHeader = InvtSubLedgerCAP_Header.Load(subledgerHeaderId);
            if (oSubLedgerHeader != null)
            {
                oSubLedgerHeader.TotalAmount = ttlAmt;

                oSubLedgerHeader.ModifiedOn = DateTime.Now;
                oSubLedgerHeader.ModifiedBy = Common.Config.CurrentUserId;

                oSubLedgerHeader.Save();
            }
        }
        #endregion

        #region Ledger
        private Guid CreateLedgerHeader(InvtBatchCAP_Header oBatchHeader, Guid subLedgerHeaderId)
        {
            InvtLedgerHeader oLedgerHeader = new InvtLedgerHeader();
            oLedgerHeader.TxNumber = oBatchHeader.TxNumber;
            oLedgerHeader.TxType = Common.Enums.TxType.CAP.ToString();
            oLedgerHeader.TxDate = oBatchHeader.TxDate;
            oLedgerHeader.SubLedgerHeaderId = subLedgerHeaderId;
            oLedgerHeader.WorkplaceId = oBatchHeader.WorkplaceId;
            oLedgerHeader.SupplierId = oBatchHeader.SupplierId;
            oLedgerHeader.StaffId = oBatchHeader.StaffId;
            oLedgerHeader.Reference = oBatchHeader.Reference;
            oLedgerHeader.Remarks = oBatchHeader.Remarks;
            oLedgerHeader.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));
            oLedgerHeader.CreatedBy = Common.Config.CurrentUserId;
            oLedgerHeader.CreatedOn = DateTime.Now;
            oLedgerHeader.ModifiedBy = Common.Config.CurrentUserId;
            oLedgerHeader.ModifiedOn = DateTime.Now;
            oLedgerHeader.Save();

            return oLedgerHeader.HeaderId;
        }

        private void CreateLedgerDetails(string txnumber, Guid subledgerHeaderId, Guid ledgerHeaderId, DateTime txDate, string shop, string staffNumber)
        {
            string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
            string[] orderBy = new string[] { "LineNumber" };
            InvtSubLedgerCAP_DetailsCollection oSubLedgerDetails = InvtSubLedgerCAP_Details.LoadCollection(sql, orderBy, true);
            foreach (InvtSubLedgerCAP_Details oSDetail in oSubLedgerDetails)
            {
                InvtLedgerDetails oLedgerDetail = new InvtLedgerDetails();
                oLedgerDetail.HeaderId = ledgerHeaderId;
                oLedgerDetail.SubLedgerDetailsId = oSDetail.DetailsId;
                oLedgerDetail.LineNumber = oSDetail.LineNumber;
                oLedgerDetail.ProductId = oSDetail.ProductId;
                oLedgerDetail.Qty = oSDetail.Qty;
                oLedgerDetail.TxNumber = txnumber;
                oLedgerDetail.TxType = Common.Enums.TxType.CAP.ToString();
                oLedgerDetail.TxDate = txDate;
                oLedgerDetail.UnitAmount = oSDetail.UnitAmount;
                oLedgerDetail.AverageCost = 0;
                oLedgerDetail.Notes = string.Empty;
                oLedgerDetail.SerialNumber = string.Empty;
                oLedgerDetail.SHOP = shop;
                oLedgerDetail.OPERATOR = staffNumber;

                // Product Info
                RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(oSDetail.ProductId);
                if (oItem != null)
                {
                    oLedgerDetail.BasicPrice = oItem.RetailPrice;
                    oLedgerDetail.Discount = oItem.NormalDiscount;
                    oLedgerDetail.AverageCost = this.GetAverageCost(oItem.ProductId);

                    sql = "ProductId = '" + oSDetail.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(Common.Enums.ProductPriceType.VPRC.ToString()).ToString() + "'";
                    ProductPrice oPrice = ProductPrice.LoadWhere(sql);
                    if (oPrice != null)
                    {
                        oLedgerDetail.VendorRef = oPrice.CurrencyCode;
                    }
                }

                oLedgerDetail.Amount = oLedgerDetail.Qty * (oLedgerDetail.UnitAmount * ((100 - oLedgerDetail.Discount) * (decimal)0.01));

                oLedgerDetail.Save();

                InvtLedgerHeader oLedgerHeader = InvtLedgerHeader.Load(ledgerHeaderId);
                if (oLedgerHeader != null)
                {
                    oLedgerHeader.TotalAmount += oLedgerDetail.Amount;

                    oLedgerHeader.Save();
                }
            }
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

        private string GetStaffCode(Guid staffId)
        {
            RT2020.DAL.Staff oStaff = RT2020.DAL.Staff.Load(staffId);
            if (oStaff != null)
            {
                return oStaff.StaffNumber;
            }

            return string.Empty;
        }

        private decimal GetAverageCost(Guid productId)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";
            ProductCurrentSummary oSummary = ProductCurrentSummary.LoadWhere(sql);
            if (oSummary != null)
            {
                return oSummary.AverageCost;
            }

            return 0;
        }
        #endregion

        #region Product
        private void UpdateProduct(Guid txHeaderId, Guid workplaceId)
        {
            string sql = "HeaderId = '" + txHeaderId.ToString() + "'";
            InvtBatchCAP_DetailsCollection detailsList = InvtBatchCAP_Details.LoadCollection(sql);
            for (int i = 0; i < detailsList.Count; i++)
            {
                InvtBatchCAP_Details detail = detailsList[i];
                UpdateProductQty(detail.ProductId, workplaceId, detail.Qty);
                UpdateProductSummary(detail.ProductId, detail.Qty, detail.UnitAmount);
            }
        }

        private void UpdateProductSummary(Guid productId, decimal qty, decimal unitAmount)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";
            ProductCurrentSummary oSummary = ProductCurrentSummary.LoadWhere(sql);
            if (oSummary == null)
            {
                oSummary = new ProductCurrentSummary();
                oSummary.ProductId = productId;
                oSummary.AverageCost = unitAmount;
            }

            if ((oSummary.CDQTY + qty) > 0)
            {
                oSummary.AverageCost = (oSummary.AverageCost * oSummary.CDQTY + unitAmount * qty) / (oSummary.CDQTY + qty);
            }
            else
            {
                oSummary.AverageCost = oSummary.LastCost;
            }

            oSummary.LastCost = unitAmount;

            oSummary.CDQTY += qty;
            oSummary.Save();
        }

        private void UpdateProductQty(Guid productId, Guid workplaceId, decimal qty)
        {
            string sql = "ProductId = '" + productId.ToString() + "' AND WorkplaceId = '" + workplaceId.ToString() + "'";
            ProductWorkplace wpProd = ProductWorkplace.LoadWhere(sql);
            if (wpProd == null)
            {
                wpProd = new ProductWorkplace();
                wpProd.ProductId = productId;
                wpProd.WorkplaceId = workplaceId;
            }
            wpProd.CDQTY += qty;
            wpProd.Save();
        }
        #endregion

        #endregion

        #region Finding TxNumber
        private void FindingTxNumber()
        {
            errorProvider.SetError(txtTxNumber, string.Empty);
            if (txtTxNumber.Text.Trim().Length > 0)
            {
                string sql = "TxNumber LIKE '%" + txtTxNumber.Text.Trim() + "%'";
                InvtBatchCAP_Header oHeader = InvtBatchCAP_Header.LoadWhere(sql);
                if (oHeader != null)
                {
                    Common.Enums.Status oStatus = (Common.Enums.Status)Enum.Parse(typeof(Common.Enums.Status), oHeader.Status.ToString());
                    switch (oStatus)
                    {
                        case Common.Enums.Status.Draft: // Holding
                            tabCAPAuthorization.SelectedIndex = 1;
                            break;
                        case Common.Enums.Status.Active: // Posting
                            tabCAPAuthorization.SelectedIndex = 0;
                            break;
                    }

                    BindingList(oStatus);
                }
                else
                {
                    errorProvider.SetError(txtTxNumber, "Cash Purchase Number field does not exist!");
                }
            }
            else
            {
                errorProvider.SetError(txtTxNumber, "Cash Purchase Number field cannot be blank!");
            }
        }
        #endregion

        private bool CheckTxDate(string dateToBeChecked)
        {
            bool canBeMark = false;

            string pattern = @"^\d{1,2}\/\d{1,2}\/\d{4}$";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(dateToBeChecked);
            if (match.Success)
            {
                string[] dates = dateToBeChecked.Split(new char[] { '/' });

                canBeMark = true;
                canBeMark = canBeMark & (dates[2] == txtSysYear.Text); // Check System Year
                canBeMark = canBeMark & (dates[1] == txtSysMonth.Text); // Check System Month
            }

            return canBeMark;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSortAndFilter_CheckedChanged(object sender, EventArgs e)
        {
            cboFieldName.Enabled = chkSortAndFilter.Checked;
            cboOperator.Enabled = chkSortAndFilter.Checked;
            cboOrdering.Enabled = chkSortAndFilter.Checked;
            txtData.Enabled = chkSortAndFilter.Checked;
            btnReload.Enabled = chkSortAndFilter.Checked;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtTxNumber, string.Empty);

            if (VerifyDate())
            {
                BindingList(Common.Enums.Status.Active); // Posting

                if (this.lvPostTxList.Items.Count == 0)
                {
                    MessageBox.Show("No record found!", "ATTENTION");
                }
            }
        }

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem objItem in this.lvPostTxList.Items)
            {
                if (btnMarkAll.Text.Contains("Mark"))
                {
                    objItem.Checked = true;
                }
                else if (btnMarkAll.Text.Contains("Unmark"))
                {
                    objItem.Checked = false;
                }
            }
            this.Update();

            btnMarkAll.Text = (btnMarkAll.Text == "Mark All") ? "Unmark All" : "Mark All";
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (lvPostTxList.CheckedItems.Count > 0)
            {
                SelectedColumnsCounting();

                btnMarkAll.Enabled = false;

                //if (postStatus == RT2020.Controls.InvtUtility.PostingStatus.Postable)
                //{
                int result = CreateCAPTx();
                if (result > 0)
                {
                    MessageBox.Show(result.ToString() + " Posted successfully!", "Posting result", MessageBoxButtons.OK);
                }
                //}
                //else
                //{
                //    MessageBox.Show("Error appears when verifying the marked transactions.\nDouble Click the error row to show more details about the error.", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else
            {
                MessageBox.Show("No Record Selected!", "Selection");
            }
        }

        private void txtTxNumber_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && e.KeyData == Keys.Return)
            {
                FindingTxNumber();
            }
        }

        private void lvPostTxList_DoubleClick(object sender, EventArgs e)
        {
            if (lvPostTxList.Items != null && lvPostTxList.SelectedIndex >= 0)
            {
                int index = lvPostTxList.SelectedIndex;

                if (postStatus != RT2020.Controls.InvtUtility.PostingStatus.Ready)
                {
                    string headerId = this.lvPostTxList.Items[index].Text;
                    if (oTable != null)
                    {
                        DataRow[] rows = oTable.Select("HeaderId = '" + headerId + "'");
                        if (rows.Length > 0)
                        {
                            RT2020.Controls.PostingMessageForm frmMessage = new RT2020.Controls.PostingMessageForm();
                            frmMessage.RowList = rows;
                            frmMessage.ShowDialog();
                        }
                        else
                        {
                            if (this.lvPostTxList.Items[index].Checked)
                            {
                                if (postStatus == RT2020.Controls.InvtUtility.PostingStatus.Postable)
                                {
                                    MessageBox.Show("Transaction is posted!", "Message");
                                }
                                else
                                {
                                    MessageBox.Show("Transaction is ready to be posted.", "Message");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void lvPostTxList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                lvPostTxList.Items[e.Index].Checked = !(lvPostTxList.Items[e.Index].BackColor == RT2020.SystemInfo.ControlBackColor.DisabledBox);
            }
        }
    }
}