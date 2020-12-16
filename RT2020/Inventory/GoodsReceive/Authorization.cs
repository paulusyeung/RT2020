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
    using System.Linq;

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

                        var oProduct = ModelEx.ProductEx.Get(detail.ProductId);
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

                    var oStaff = ModelEx.StaffEx.GetByStaffId(oBatchHeader.StaffId);
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
                    Guid headerId = Guid.Empty;
                    if (Guid.TryParse(oItem.Text, out headerId) && oItem.Checked)
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
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oBatchHeader = ctx.InvtBatchCAP_Header.Find(headerId);
                        if (oBatchHeader != null)
                        {
                            //if (postStatus == RT2020.Controls.InvtUtility.PostingStatus.Postable)
                            //{
                            // Update Product Info
                            #region UpdateProduct(oBatchHeader.HeaderId, oBatchHeader.WorkplaceId);
                            Guid txHeaderId = oBatchHeader.HeaderId;
                            Guid workplaceId = oBatchHeader.WorkplaceId;

                            //string sql = "HeaderId = '" + txHeaderId.ToString() + "'";

                            var detailsList = ctx.InvtBatchCAP_Details.Where(x => x.HeaderId == txHeaderId);
                            foreach (var detail in detailsList)
                            {
                                Guid productId = detail.ProductId;
                                decimal qty = detail.Qty.Value, unitAmount = detail.UnitAmount.Value;

                                #region UpdateProductQty(detail.ProductId, workplaceId, detail.Qty);
                                var wpProd = ctx.ProductWorkplace.Where(x => x.ProductId == productId && x.WorkplaceId == workplaceId).FirstOrDefault();
                                if (wpProd == null)
                                {
                                    wpProd = new EF6.ProductWorkplace();
                                    wpProd.ProductWorkplaceId = Guid.NewGuid();
                                    wpProd.ProductId = productId;
                                    wpProd.WorkplaceId = workplaceId;

                                    ctx.ProductWorkplace.Add(wpProd);
                                }
                                wpProd.CDQTY += qty;
                                #endregion

                                #region UpdateProductSummary(detail.ProductId, detail.Qty, detail.UnitAmount);
                                var oSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oSummary == null)
                                {
                                    oSummary = new EF6.ProductCurrentSummary();
                                    oSummary.CurrentSummaryId = Guid.NewGuid();
                                    oSummary.ProductId = productId;
                                    oSummary.AverageCost = unitAmount;

                                    ctx.ProductCurrentSummary.Add(oSummary);
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
                                #endregion

                                ctx.SaveChanges();
                            }
                            #endregion

                            // Create CAP SubLedger
                            string txNumber_SubLedger = oBatchHeader.TxNumber;
                            #region Guid subLedgerHeaderId = CreateCAPSubLedgerHeader(oBatchHeader);
                            var oSubCAP = new EF6.InvtSubLedgerCAP_Header();
                            oSubCAP.HeaderId = Guid.NewGuid();
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

                            ctx.InvtSubLedgerCAP_Header.Add(oSubCAP);

                            Guid subLedgerHeaderId = oSubCAP.HeaderId;
                            #endregion

                            #region CreateCAPSubLedgerDetail(txNumber_SubLedger, oBatchHeader.HeaderId, subLedgerHeaderId);
                            string txnumber = txNumber_SubLedger;
                            Guid batchHeaderId = oBatchHeader.HeaderId;

                            decimal ttlAmt = 0;
                            string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
                            string[] orderBy = new string[] { "LineNumber" };
                            var oBatchDetails = ctx.InvtBatchCAP_Details.Where(x => x.HeaderId == batchHeaderId).OrderBy(x => x.LineNumber);
                            foreach (var oBDetail in oBatchDetails)
                            {
                                var oSubLedgerDetail = new EF6.InvtSubLedgerCAP_Details();
                                oSubLedgerDetail.DetailsId = Guid.NewGuid();
                                oSubLedgerDetail.HeaderId = subLedgerHeaderId;
                                oSubLedgerDetail.LineNumber = oBDetail.LineNumber;
                                oSubLedgerDetail.ProductId = oBDetail.ProductId;
                                oSubLedgerDetail.Qty = oBDetail.Qty;
                                oSubLedgerDetail.TxNumber = txnumber;
                                oSubLedgerDetail.TxType = Common.Enums.TxType.CAP.ToString();
                                oSubLedgerDetail.UnitAmount = oBDetail.UnitAmount;
                                oSubLedgerDetail.UnitAmountInForeignCurrency = oBDetail.UnitAmountInForeignCurrency;

                                ctx.InvtSubLedgerCAP_Details.Add(oSubLedgerDetail);

                                ttlAmt += oSubLedgerDetail.Qty.Value * oSubLedgerDetail.UnitAmount.Value;
                            }

                            var oSubLedgerHeader = ctx.InvtSubLedgerCAP_Header.Find(subLedgerHeaderId);
                            if (oSubLedgerHeader != null)
                            {
                                oSubLedgerHeader.TotalAmount = ttlAmt;

                                oSubLedgerHeader.ModifiedOn = DateTime.Now;
                                oSubLedgerHeader.ModifiedBy = Common.Config.CurrentUserId;
                            }
                            ctx.SaveChanges();
                            #endregion

                            // Create Ledger for TxType 'CAP'
                            string txNumber_Ledger = oBatchHeader.TxNumber;
                            #region Guid ledgerHeaderId = CreateLedgerHeader(oBatchHeader, subLedgerHeaderId);
                            var oLedgerHeader = new EF6.InvtLedgerHeader();
                            oLedgerHeader.HeaderId = Guid.NewGuid();
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

                            ctx.InvtLedgerHeader.Add(oLedgerHeader);

                            Guid ledgerHeaderId = oLedgerHeader.HeaderId;
                            #endregion

                            #region CreateLedgerDetails(txNumber_Ledger, subLedgerHeaderId, ledgerHeaderId, oBatchHeader.TxDate, ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId), ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.StaffId));
                            txnumber = txNumber_Ledger;
                            //Guid subLedgerHeaderId = subLedgerHeaderId;
                            //Guid ledgerHeaderId = ledgerHeaderId;
                            DateTime txDate = oBatchHeader.TxDate.Value;
                            string shop = ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId);
                            string staffNumber = ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.StaffId);

                            var oSubLedgerDetails = ctx.InvtSubLedgerCAP_Details
                            .Where(x => x.HeaderId == subLedgerHeaderId)    //sql, orderBy, true);
                            .OrderBy(x => x.LineNumber)
                            .ToList();
                            foreach (var oSDetail in oSubLedgerDetails)
                            {
                                var oLedgerDetail = new EF6.InvtLedgerDetails();

                                oLedgerDetail.DetailsId = Guid.NewGuid();
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
                                var oItem = ctx.Product.Find(oSDetail.ProductId);
                                if (oItem != null)
                                {
                                    oLedgerDetail.BasicPrice = oItem.RetailPrice;
                                    oLedgerDetail.Discount = oItem.NormalDiscount;
                                    oLedgerDetail.AverageCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);

                                    var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(Common.Enums.ProductPriceType.VPRC.ToString());
                                    //sql = "ProductId = '" + oSDetail.ProductId.ToString() + "' AND PriceTypeId = '" + priceTypeId.ToString() + "'";

                                    var oPrice = ctx.ProductPrice.Where(x => x.ProductId == oSDetail.ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                    if (oPrice != null)
                                    {
                                        oLedgerDetail.VendorRef = oPrice.CurrencyCode;
                                    }
                                }

                                oLedgerDetail.Amount = oLedgerDetail.Qty * (oLedgerDetail.UnitAmount * ((100 - oLedgerDetail.Discount) * (decimal)0.01));

                                ctx.InvtLedgerDetails.Add(oLedgerDetail);

                                var oLedgerHeader2 = ctx.InvtLedgerHeader.Find(ledgerHeaderId);
                                if (oLedgerHeader2 != null)
                                {
                                    oLedgerHeader2.TotalAmount += oLedgerDetail.Amount;

                                    //oLedgerHeader.Save();
                                }
                                ctx.SaveChanges();
                            }
                            #endregion

                            // Update Batch Header Info
                            oBatchHeader.ReadOnly = true;
                            oBatchHeader.ModifiedBy = Common.Config.CurrentUserId;
                            oBatchHeader.ModifiedOn = DateTime.Now;
                            ctx.SaveChanges();

                            iCount++;

                            #region ClearBatchTransaction(oBatchHeader);
                            //string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
                            var detailList = ctx.InvtBatchCAP_Details.Where(x => x.HeaderId == oBatchHeader.HeaderId);
                            foreach (var detail in detailList)
                            {
                                ctx.InvtBatchCAP_Details.Remove(detail);
                            }

                            ctx.InvtBatchCAP_Header.Remove(oBatchHeader);
                            #endregion
                        }
                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }

        #region Clear Batch
        /**
        /// <summary>
        /// Clears the batch transaction.
        /// </summary>
        ///
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
        */
        #endregion

        #region SubLedger
        /**
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
        */
        #endregion

        #region Ledger
        /**
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
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
                        string[] orderBy = new string[] { "LineNumber" };
                        var oSubLedgerDetails = ctx.InvtSubLedgerCAP_Details
                            .Where(x => x.HeaderId == subledgerHeaderId)    //sql, orderBy, true);
                            .OrderBy(x => x.LineNumber)
                            .ToList();
                        foreach (var oSDetail in oSubLedgerDetails)
                        {
                            var oLedgerDetail = new EF6.InvtLedgerDetails();

                            oLedgerDetail.DetailsId = Guid.NewGuid();
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
                            var oItem = ctx.Product.Find(oSDetail.ProductId);
                            if (oItem != null)
                            {
                                oLedgerDetail.BasicPrice = oItem.RetailPrice;
                                oLedgerDetail.Discount = oItem.NormalDiscount;
                                oLedgerDetail.AverageCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);

                                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(Common.Enums.ProductPriceType.VPRC.ToString());
                                //sql = "ProductId = '" + oSDetail.ProductId.ToString() + "' AND PriceTypeId = '" + priceTypeId.ToString() + "'";

                                var oPrice = ctx.ProductPrice.Where(x => x.ProductId == oSDetail.ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oPrice != null)
                                {
                                    oLedgerDetail.VendorRef = oPrice.CurrencyCode;
                                }
                            }

                            oLedgerDetail.Amount = oLedgerDetail.Qty * (oLedgerDetail.UnitAmount * ((100 - oLedgerDetail.Discount) * (decimal)0.01));

                            ctx.InvtLedgerDetails.Add(oLedgerDetail);

                            var oLedgerHeader = ctx.InvtLedgerHeader.Find(ledgerHeaderId);
                            if (oLedgerHeader != null)
                            {
                                oLedgerHeader.TotalAmount += oLedgerDetail.Amount;

                                //oLedgerHeader.Save();
                            }
                            ctx.SaveChanges();
                        }
                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }
        */
        #endregion

        #region Product
        /**
        private void UpdateProduct(Guid txHeaderId, Guid workplaceId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        string sql = "HeaderId = '" + txHeaderId.ToString() + "'";

                        var detailsList = ctx.InvtBatchCAP_Details.Where(x => x.HeaderId == txHeaderId);
                        foreach (var detail in detailsList)
                        {
                            Guid productId = detail.ProductId;
                            decimal qty = detail.Qty.Value, unitAmount = detail.UnitAmount.Value;

                            #region UpdateProductQty(detail.ProductId, workplaceId, detail.Qty);
                            var wpProd = ctx.ProductWorkplace.Where(x => x.ProductId == productId && x.WorkplaceId == workplaceId).FirstOrDefault();
                            if (wpProd == null)
                            {
                                wpProd = new EF6.ProductWorkplace();
                                wpProd.ProductWorkplaceId = Guid.NewGuid();
                                wpProd.ProductId = productId;
                                wpProd.WorkplaceId = workplaceId;

                                ctx.ProductWorkplace.Add(wpProd);
                            }
                            wpProd.CDQTY += qty;
                            #endregion

                            #region UpdateProductSummary(detail.ProductId, detail.Qty, detail.UnitAmount);
                            var oSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                            if (oSummary == null)
                            {
                                oSummary = new EF6.ProductCurrentSummary();
                                oSummary.CurrentSummaryId = Guid.NewGuid();
                                oSummary.ProductId = productId;
                                oSummary.AverageCost = unitAmount;

                                ctx.ProductCurrentSummary.Add(oSummary);
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
                            #endregion

                            ctx.SaveChanges();
                        }

                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }
        */
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