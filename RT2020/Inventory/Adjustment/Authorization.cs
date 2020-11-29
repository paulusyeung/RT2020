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

namespace RT2020.Inventory.Adjustment
{
    public partial class Authorization : Form
    {
        private RT2020.Controls.InvtUtility.PostingStatus postStatus = RT2020.Controls.InvtUtility.PostingStatus.Ready;
        DataTable oTable;

        public Authorization()
        {
            InitializeComponent();
            InitComboBox();
            SetAttributes();
            BindingHoldingList();
            BindingPostingList();
        }

        private void SetAttributes()
        {
            lvPostTxList.ListViewItemSorter = new ListViewItemSorter(lvPostTxList);
            lvHoldingTxList.ListViewItemSorter = new ListViewItemSorter(lvHoldingTxList);
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
        private void BindingHoldingList()
        {
            lvHoldingTxList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString(Common.Enums.Status.Draft.ToString("d"), false);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvHoldingTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                    objItem.SubItems.Add(string.Empty);
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // TxNumber
                    objItem.SubItems.Add(reader.GetString(1)); // Type
                    objItem.SubItems.Add(reader.GetString(5)); // Location
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                    objItem.SubItems.Add(reader.GetString(4)); // StaffNumber
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(8), false)); // Modified On

                    iCount++;
                }
            }
        }

        private void BindingPostingList()
        {
            lvPostTxList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString(Common.Enums.Status.Active.ToString("d"), true);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvPostTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                    objItem.SubItems.Add(new IconResourceHandle("16x16.16_progress.gif").ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // TxNumber
                    objItem.SubItems.Add(reader.GetString(1)); // Type
                    objItem.SubItems.Add(reader.GetString(5)); // Location
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                    objItem.SubItems.Add(reader.GetString(4)); // StaffNumber
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(8), false)); // Modified On
                    objItem.BackColor = CheckTxDate(reader.GetDateTime(3)) ? Color.Transparent : RT2020.SystemInfo.ControlBackColor.DisabledBox;

                    iCount++;
                }
            }
        }

        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT HeaderId, TxType, TxNumber, TxDate, StaffNumber, Location, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, PostedOn, PostedBy ");
            sql.Append(" FROM vwDraftADJList ");
            sql.Append(" WHERE (PostedBy IS NULL OR PostedBy = '").Append(System.Guid.Empty.ToString()).Append("') AND TxType = 'ADJ' AND STATUS = ").Append(status);

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
                case "Last Update (dd/MM/yyyy)":
                    colName = "ModifiedOn";
                    break;
                default:
                case "ADJ#":
                    colName = "TxNumber";
                    break;
            }
            return colName;
        }

        private bool VerifyDate()
        {
            bool isVerified = true;
            if (cboFieldName.Text.Contains("Date"))
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
                InvtBatchADJ_Header oBatchHeader = InvtBatchADJ_Header.Load(new Guid(headerId));
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

                    if (oBatchHeader.Status == (int)Common.Enums.Status.Active && oBatchHeader.PostedBy != System.Guid.Empty)
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

                    InvtBatchADJ_DetailsCollection detailList = InvtBatchADJ_Details.LoadCollection("HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'");
                    foreach (InvtBatchADJ_Details detail in detailList)
                    {
                        bool retired = false;
                        string stk = string.Empty, a1 = string.Empty, a2 = string.Empty, a3 = string.Empty;

                        RT2020.DAL.Product oProduct = RT2020.DAL.Product.Load(detail.ProductId);
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

                        decimal qty = GetCDQty(detail.ProductId, oBatchHeader.WorkplaceId);
                        if ((qty + detail.Qty) < 0)
                        {
                            DataRow row = errorTable.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = stk;
                            row["APPENDIX1"] = a1;
                            row["APPENDIX2"] = a2;
                            row["APPENDIX3"] = a3;
                            row["ErrorReason"] = "Product does not have enough on-hand qty!";
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

                    InvtLedgerHeader oInvtLedger = InvtLedgerHeader.LoadWhere("TxNumber = '" + oBatchHeader.TxNumber + "' AND TxType = 'ADJ'");
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

        private int CreateADJTx()
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
                            CreateADJTx(oItem);

                            oItem.SubItems[1].Text = new IconResourceHandle("16x16.16_succeeded.png").ToString();

                            iCount++;
                        }
                    }
                }
            }

            return iCount;
        }

        private void CreateADJTx(ListViewItem listItem)
        {
            if (Common.Utility.IsGUID(listItem.Text))
            {
                InvtBatchADJ_Header oBatchHeader = InvtBatchADJ_Header.Load(new Guid(listItem.Text));
                if (oBatchHeader != null)
                {
                    // Update Product Info
                    UpdateProduct(oBatchHeader.HeaderId, oBatchHeader.WorkplaceId);

                    // Create ADJ SubLedger
                    string txNumber_SubLedger = oBatchHeader.TxNumber;
                    System.Guid subLedgerHeaderId = CreateADJSubLedgerHeader(txNumber_SubLedger, oBatchHeader.TxDate, oBatchHeader.WorkplaceId, oBatchHeader.StaffId, oBatchHeader.Remarks, oBatchHeader.Reference + "\t" + oBatchHeader.TxNumber);
                    CreateADJSubLedgerDetail(txNumber_SubLedger, oBatchHeader.HeaderId, subLedgerHeaderId);

                    // Create Ledger for TxType 'ADJ'
                    string txNumber_Ledger = oBatchHeader.TxNumber;
                    System.Guid ledgerHeaderId = CreateLedgerHeader(txNumber_Ledger, oBatchHeader.TxDate, subLedgerHeaderId, oBatchHeader.WorkplaceId, oBatchHeader.StaffId, oBatchHeader.Reference + "\t" + txNumber_SubLedger, oBatchHeader.Remarks);
                    CreateLedgerDetails(txNumber_Ledger, subLedgerHeaderId, ledgerHeaderId, oBatchHeader);

                    oBatchHeader.PostedBy = Common.Config.CurrentUserId;
                    oBatchHeader.PostedOn = DateTime.Now;
                    oBatchHeader.ModifiedBy = Common.Config.CurrentUserId;
                    oBatchHeader.ModifiedOn = DateTime.Now;
                    oBatchHeader.Save();

                    ClearBatchTransaction(oBatchHeader);
                }
            }
        }

        #region Clear Batch

        /// <summary>
        /// Clears the batch transaction.
        /// </summary>
        private void ClearBatchTransaction(InvtBatchADJ_Header oBatchHeader)
        {
            string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
            InvtBatchADJ_DetailsCollection detailList = InvtBatchADJ_Details.LoadCollection(query);
            for (int i = 0; i < detailList.Count; i++)
            {
                detailList[i].Delete();
            }

            oBatchHeader.Delete();
        }

        #endregion

        #region SubLedger
        private Guid CreateADJSubLedgerHeader(string txnumber, DateTime txDate, Guid workplaceId, Guid staffId, string remarks, string reference)
        {
            InvtSubLedgerADJ_Header oSubADJ = new InvtSubLedgerADJ_Header();
            oSubADJ.TxNumber = txnumber;
            oSubADJ.TxType = Common.Enums.TxType.ADJ.ToString();
            oSubADJ.WorkplaceId = workplaceId;
            oSubADJ.TxDate = txDate;
            oSubADJ.Reference = reference;
            oSubADJ.Remarks = remarks;
            oSubADJ.StaffId = staffId;
            oSubADJ.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));

            oSubADJ.CreatedBy = Common.Config.CurrentUserId;
            oSubADJ.CreatedOn = DateTime.Now;
            oSubADJ.ModifiedBy = Common.Config.CurrentUserId;
            oSubADJ.ModifiedOn = DateTime.Now;

            oSubADJ.Save();

            return oSubADJ.HeaderId;
        }

        private void CreateADJSubLedgerDetail(string txnumber, Guid batchHeaderId, Guid subledgerHeaderId)
        {
            decimal ttlAmt = 0;
            string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
            string[] orderBy = new string[] { "LineNumber" };
            InvtBatchADJ_DetailsCollection oBatchDetails = InvtBatchADJ_Details.LoadCollection(sql, orderBy, true);
            foreach (InvtBatchADJ_Details oBDetail in oBatchDetails)
            {
                InvtSubLedgerADJ_Details oSubLedgerDetail = new InvtSubLedgerADJ_Details();
                oSubLedgerDetail.HeaderId = subledgerHeaderId;
                oSubLedgerDetail.LineNumber = oBDetail.LineNumber;
                oSubLedgerDetail.ProductId = oBDetail.ProductId;
                oSubLedgerDetail.Qty = oBDetail.Qty;
                oSubLedgerDetail.TxNumber = txnumber;
                oSubLedgerDetail.TxType = Common.Enums.TxType.ADJ.ToString();
                oSubLedgerDetail.AverageCost = oBDetail.AverageCost;
                oSubLedgerDetail.ReasonCode = oBDetail.ReasonCode;
                oSubLedgerDetail.Remarks = oBDetail.Remarks;

                oSubLedgerDetail.Save();

                ttlAmt += oSubLedgerDetail.Qty * oSubLedgerDetail.AverageCost;
            }

            InvtSubLedgerADJ_Header oSubLedgerHeader = InvtSubLedgerADJ_Header.Load(subledgerHeaderId);
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
        private Guid CreateLedgerHeader(string txnumber, DateTime txDate, Guid subLedgerHeaderId, Guid workplaceId, Guid staffId, string reference, string remarks)
        {
            InvtLedgerHeader oLedgerHeader = new InvtLedgerHeader();
            oLedgerHeader.TxNumber = txnumber;
            oLedgerHeader.TxType = Common.Enums.TxType.ADJ.ToString();
            oLedgerHeader.TxDate = txDate;
            oLedgerHeader.SubLedgerHeaderId = subLedgerHeaderId;
            oLedgerHeader.WorkplaceId = workplaceId;
            oLedgerHeader.StaffId = staffId;
            oLedgerHeader.Reference = reference;
            oLedgerHeader.Remarks = remarks;
            oLedgerHeader.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));
            oLedgerHeader.CreatedBy = Common.Config.CurrentUserId;
            oLedgerHeader.CreatedOn = DateTime.Now;
            oLedgerHeader.ModifiedBy = Common.Config.CurrentUserId;
            oLedgerHeader.ModifiedOn = DateTime.Now;
            oLedgerHeader.Save();

            return oLedgerHeader.HeaderId;
        }

        private void CreateLedgerDetails(string txnumber, Guid subledgerHeaderId, Guid ledgerHeaderId, InvtBatchADJ_Header oBatchHeader)
        {
            string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
            string[] orderBy = new string[] { "LineNumber" };
            InvtSubLedgerADJ_DetailsCollection oSubLedgerDetails = InvtSubLedgerADJ_Details.LoadCollection(sql, orderBy, true);
            foreach (InvtSubLedgerADJ_Details oSDetail in oSubLedgerDetails)
            {
                InvtLedgerDetails oLedgerDetail = new InvtLedgerDetails();
                oLedgerDetail.HeaderId = ledgerHeaderId;
                oLedgerDetail.SubLedgerDetailsId = oSDetail.DetailsId;
                oLedgerDetail.LineNumber = oSDetail.LineNumber;
                oLedgerDetail.ProductId = oSDetail.ProductId;
                oLedgerDetail.Qty = oSDetail.Qty;
                oLedgerDetail.TxNumber = txnumber;
                oLedgerDetail.TxType = Common.Enums.TxType.ADJ.ToString();
                oLedgerDetail.TxDate = oBatchHeader.TxDate;
                oLedgerDetail.Amount = oLedgerDetail.Qty * oLedgerDetail.AverageCost;
                oLedgerDetail.Notes = string.Empty;
                oLedgerDetail.SerialNumber = string.Empty;
                oLedgerDetail.SHOP = ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId);
                oLedgerDetail.OPERATOR = this.GetStaffCode(oBatchHeader.StaffId);

                // Product Info
                RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(oSDetail.ProductId);
                if (oItem != null)
                {
                    oLedgerDetail.BasicPrice = oItem.RetailPrice;
                    oLedgerDetail.UnitAmount = this.GetAverageCost(oItem.ProductId);
                    oLedgerDetail.Discount = oItem.NormalDiscount;
                    oLedgerDetail.Amount = oLedgerDetail.UnitAmount * oLedgerDetail.Qty;
                    oLedgerDetail.AverageCost = this.GetAverageCost(oItem.ProductId);

                    sql = "ProductId = '" + oSDetail.ProductId.ToString() + "' AND PriceTypeId = '" + GetPriceType(Common.Enums.ProductPriceType.VPRC.ToString()).ToString() + "'";
                    ProductPrice oPrice = ProductPrice.LoadWhere(sql);
                    if (oPrice != null)
                    {
                        oLedgerDetail.VendorRef = oPrice.CurrencyCode;
                    }
                }

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
            InvtBatchADJ_DetailsCollection detailsList = InvtBatchADJ_Details.LoadCollection(sql);
            for (int i = 0; i < detailsList.Count; i++)
            {
                InvtBatchADJ_Details detail = detailsList[i];
                UpdateProductCurrentSummary(detail.ProductId, detail.Qty);
                UpdateProductQty(detail.ProductId, workplaceId, detail.Qty);
            }
        }

        private void UpdateProductCurrentSummary(Guid productId, decimal qty)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";
            ProductCurrentSummary currProd = ProductCurrentSummary.LoadWhere(sql);
            if (currProd == null)
            {
                currProd = new ProductCurrentSummary();
                currProd.ProductId = productId;
            }
            currProd.CDQTY += qty;
            currProd.Save();
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
                BindingPostingList();
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

                int result = CreateADJTx();
                if (result > 0)
                {
                    MessageBox.Show(result.ToString() + " succeed!", "Posting result", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No Record Selected!");
            }
        }

        private void txtTxNumber_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTxNumber_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return && e.KeyData == Keys.Enter)
            {
                BindingPostingList();
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