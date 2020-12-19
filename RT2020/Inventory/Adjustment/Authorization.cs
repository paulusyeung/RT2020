﻿#region Using

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

using Gizmox.WebGUI.Common.Resources;
using System.Configuration;
using RT2020.Helper;
using System.Linq;
using System.Data.Entity;

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
            string sql = BuildSqlQueryString(EnumHelper.Status.Draft.ToString("d"), false);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
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
            string sql = BuildSqlQueryString(EnumHelper.Status.Active.ToString("d"), true);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
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

            using (var ctx = new EF6.RT2020Entities())
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(headerId, out id))
                {
                    var oBatchHeader = ModelEx.InvtBatchADJ_HeaderEx.Get(id);
                    if (oBatchHeader != null)
                    {
                        if (!CheckTxDate(oBatchHeader.TxDate.Value))
                        {
                            #region 加一行
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
                            #endregion
                            isPostable = isPostable & false;
                        }

                        if (oBatchHeader.Status == (int)EnumHelper.Status.Active && oBatchHeader.PostedBy != System.Guid.Empty)
                        {
                            #region 加一行
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
                            #endregion
                            isPostable = isPostable & false;
                        }

                        var detailList = ctx.InvtBatchADJ_Details.Where(x => x.HeaderId == oBatchHeader.HeaderId).AsNoTracking().ToList();
                        foreach (var detail in detailList)
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
                                #region 加一行
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
                                #endregion
                                isPostable = isPostable & false;
                            }

                            decimal qty = ProductHelper.GetOnHandQtyByWorkplaceId(detail.ProductId, oBatchHeader.WorkplaceId);
                            if ((qty + detail.Qty) < 0)
                            {
                                #region 加一行
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
                                #endregion
                                isPostable = isPostable & false;
                            }
                        }

                        var oStaff = ModelEx.StaffEx.GetByStaffId(oBatchHeader.StaffId);
                        if (oStaff != null)
                        {
                            if (oStaff.Retired)
                            {
                                #region 加一行
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
                                #endregion
                                isPostable = isPostable & false;
                            }
                        }

                        var oInvtLedger = ctx.InvtLedgerHeader.Where(x => x.TxNumber == oBatchHeader.TxNumber && x.TxType == "ADJ").AsNoTracking().FirstOrDefault();
                        if (oInvtLedger != null)
                        {
                            #region 加一行
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
                            #endregion
                            isPostable = isPostable & false;
                        }
                    }
                    else
                    {
                        return false;
                    }
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

        private int CreateADJTx()
        {
            int iCount = 0;
            if (lvPostTxList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvPostTxList.CheckedItems)
                {
                    Guid id = Guid.Empty;
                    if (Guid.TryParse(oItem.Text, out id) && oItem.Checked)
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
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        Guid headerId = Guid.Empty;
                        if (Guid.TryParse(listItem.Text, out headerId))
                        {
                            var oBatchHeader = ctx.InvtBatchADJ_Header.Find(headerId);
                            if (oBatchHeader != null)
                            {
                                // Update Product Info
                                #region UpdateProduct(oBatchHeader.HeaderId, oBatchHeader.WorkplaceId);
                                Guid txHeaderId = oBatchHeader.HeaderId;
                                Guid workplaceId = oBatchHeader.WorkplaceId;

                                var detailsList = ctx.InvtBatchADJ_Details.Where(x => x.HeaderId == txHeaderId);
                                foreach (var item in detailsList)
                                {
                                    Guid productId = item.ProductId;
                                    decimal qty = item.Qty.Value;

                                    #region UpdateProductCurrentSummary(item.ProductId, item.Qty.Value);
                                    var currProd = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                                    if (currProd == null)
                                    {
                                        currProd = new EF6.ProductCurrentSummary();
                                        currProd.CurrentSummaryId = Guid.NewGuid();
                                        currProd.ProductId = productId;
                                        ctx.ProductCurrentSummary.Add(currProd);
                                    }
                                    currProd.CDQTY += qty;
                                    #endregion

                                    #region UpdateProductQty(item.ProductId, workplaceId, item.Qty.Value);
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

                                    ctx.SaveChanges();
                                }
                                #endregion

                                // Create ADJ SubLedger
                                string txNumber_SubLedger = oBatchHeader.TxNumber;
                                #region Guid subLedgerHeaderId = CreateADJSubLedgerHeader(txNumber_SubLedger, oBatchHeader.TxDate, oBatchHeader.WorkplaceId, oBatchHeader.StaffId, oBatchHeader.Remarks, oBatchHeader.Reference + "\t" + oBatchHeader.TxNumber);
                                string txnumber = txNumber_SubLedger;
                                DateTime txDate = oBatchHeader.TxDate.Value;
                                //Guid workplaceId = oBatchHeader.WorkplaceId;
                                Guid staffId = oBatchHeader.StaffId;
                                string remarks = oBatchHeader.Remarks;
                                string reference = oBatchHeader.Reference + "\t" + oBatchHeader.TxNumber;

                                var oSubADJ = new EF6.InvtSubLedgerADJ_Header();
                                oSubADJ.HeaderId = Guid.NewGuid();
                                oSubADJ.TxNumber = txnumber;
                                oSubADJ.TxType = EnumHelper.TxType.ADJ.ToString();
                                oSubADJ.WorkplaceId = workplaceId;
                                oSubADJ.TxDate = txDate;
                                oSubADJ.Reference = reference;
                                oSubADJ.Remarks = remarks;
                                oSubADJ.StaffId = staffId;
                                oSubADJ.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                                oSubADJ.CreatedBy = ConfigHelper.CurrentUserId;
                                oSubADJ.CreatedOn = DateTime.Now;
                                oSubADJ.ModifiedBy = ConfigHelper.CurrentUserId;
                                oSubADJ.ModifiedOn = DateTime.Now;

                                ctx.InvtSubLedgerADJ_Header.Add(oSubADJ);
                                ctx.SaveChanges();

                                Guid subLedgerHeaderId = oSubADJ.HeaderId;
                                #endregion

                                #region CreateADJSubLedgerDetail(txNumber_SubLedger, oBatchHeader.HeaderId, subLedgerHeaderId);
                                //string txnumber = txNumber_SubLedger;
                                Guid batchHeaderId = oBatchHeader.HeaderId;

                                decimal ttlAmt = 0;
                                string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
                                string[] orderBy = new string[] { "LineNumber" };
                                var oBatchDetails = ctx.InvtBatchADJ_Details.Where(x => x.HeaderId == batchHeaderId).OrderBy(x => x.LineNumber);
                                foreach (var oBDetail in oBatchDetails)
                                {
                                    var oSubLedgerDetail = new EF6.InvtSubLedgerADJ_Details();
                                    oSubLedgerDetail.DetailsId = Guid.NewGuid();
                                    oSubLedgerDetail.HeaderId = subLedgerHeaderId;
                                    oSubLedgerDetail.LineNumber = oBDetail.LineNumber.Value;
                                    oSubLedgerDetail.ProductId = oBDetail.ProductId;
                                    oSubLedgerDetail.Qty = oBDetail.Qty.Value;
                                    oSubLedgerDetail.TxNumber = txnumber;
                                    oSubLedgerDetail.TxType = EnumHelper.TxType.ADJ.ToString();
                                    oSubLedgerDetail.AverageCost = oBDetail.AverageCost.Value;
                                    oSubLedgerDetail.ReasonCode = oBDetail.ReasonCode;
                                    oSubLedgerDetail.Remarks = oBDetail.Remarks;

                                    ctx.InvtSubLedgerADJ_Details.Add(oSubLedgerDetail);

                                    ttlAmt += oSubLedgerDetail.Qty.Value * oSubLedgerDetail.AverageCost.Value;
                                }

                                var oSubLedgerHeader = ctx.InvtSubLedgerADJ_Header.Find(subLedgerHeaderId);
                                if (oSubLedgerHeader != null)
                                {
                                    oSubLedgerHeader.TotalAmount = ttlAmt;

                                    oSubLedgerHeader.ModifiedOn = DateTime.Now;
                                    oSubLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                                }
                                ctx.SaveChanges();
                                #endregion

                                // Create Ledger for TxType 'ADJ'
                                string txNumber_Ledger = oBatchHeader.TxNumber;
                                #region Guid ledgerHeaderId = CreateLedgerHeader(txNumber_Ledger, oBatchHeader.TxDate, subLedgerHeaderId, oBatchHeader.WorkplaceId, oBatchHeader.StaffId, oBatchHeader.Reference + "\t" + txNumber_SubLedger, oBatchHeader.Remarks);
                                //string txnumber = txNumber_Ledger;
                                //DateTime txDate = oBatchHeader.TxDate.Value;
                                //Guid subLedgerHeaderId = subLedgerHeaderId;
                                //Guid workplaceId = oBatchHeader.WorkplaceId;
                                //Guid staffId = oBatchHeader.StaffId;
                                //string reference = oBatchHeader.Reference + "\t" + txNumber_SubLedger;
                                //string remarks = oBatchHeader.Remarks;

                                var oLedgerHeader = new EF6.InvtLedgerHeader();
                                oLedgerHeader.HeaderId = Guid.NewGuid();
                                oLedgerHeader.TxNumber = txnumber;
                                oLedgerHeader.TxType = EnumHelper.TxType.ADJ.ToString();
                                oLedgerHeader.TxDate = txDate;
                                oLedgerHeader.SubLedgerHeaderId = subLedgerHeaderId;
                                oLedgerHeader.WorkplaceId = workplaceId;
                                oLedgerHeader.StaffId = staffId;
                                oLedgerHeader.Reference = reference;
                                oLedgerHeader.Remarks = remarks;
                                oLedgerHeader.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));
                                oLedgerHeader.CreatedBy = ConfigHelper.CurrentUserId;
                                oLedgerHeader.CreatedOn = DateTime.Now;
                                oLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                                oLedgerHeader.ModifiedOn = DateTime.Now;

                                ctx.InvtLedgerHeader.Add(oLedgerHeader);
                                ctx.SaveChanges();

                                Guid ledgerHeaderId = oLedgerHeader.HeaderId;
                                #endregion

                                #region CreateLedgerDetails(txNumber_Ledger, subLedgerHeaderId, ledgerHeaderId, oBatchHeader);
                                //string txnumber = txNumber_Ledger;
                                //Guid subledgerHeaderId = subLedgerHeaderId;
                                //Guid ledgerHeaderId = ledgerHeaderId;
                                //InvtBatchADJ_Header oBatchHeader

                                //string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
                                //string[] orderBy = new string[] { "LineNumber" };

                                var oSubLedgerDetails = ctx.InvtSubLedgerADJ_Details.Where(x => x.HeaderId == subLedgerHeaderId).OrderBy(x => x.LineNumber);
                                foreach (var oSDetail in oSubLedgerDetails)
                                {
                                    var oLedgerDetail = new EF6.InvtLedgerDetails();
                                    oLedgerDetail.DetailsId = Guid.NewGuid();
                                    oLedgerDetail.HeaderId = ledgerHeaderId;
                                    oLedgerDetail.SubLedgerDetailsId = oSDetail.DetailsId;
                                    oLedgerDetail.LineNumber = oSDetail.LineNumber.Value;
                                    oLedgerDetail.ProductId = oSDetail.ProductId;
                                    oLedgerDetail.Qty = oSDetail.Qty.Value;
                                    oLedgerDetail.TxNumber = txnumber;
                                    oLedgerDetail.TxType = EnumHelper.TxType.ADJ.ToString();
                                    oLedgerDetail.TxDate = oBatchHeader.TxDate.Value;
                                    oLedgerDetail.Amount = oLedgerDetail.Qty * oLedgerDetail.AverageCost;
                                    oLedgerDetail.Notes = string.Empty;
                                    oLedgerDetail.SerialNumber = string.Empty;
                                    oLedgerDetail.SHOP = ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId);
                                    oLedgerDetail.OPERATOR = ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.StaffId);

                                    // Product Info
                                    var oItem = ctx.Product.Find(oSDetail.ProductId);
                                    if (oItem != null)
                                    {
                                        oLedgerDetail.BasicPrice = oItem.RetailPrice.Value;
                                        oLedgerDetail.UnitAmount = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);
                                        oLedgerDetail.Discount = oItem.NormalDiscount;
                                        oLedgerDetail.Amount = oLedgerDetail.UnitAmount * oLedgerDetail.Qty;
                                        oLedgerDetail.AverageCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);

                                        var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(EnumHelper.ProductPriceType.VPRC.ToString());
                                        //sql = "ProductId = '" + oSDetail.ProductId.ToString() + "' AND PriceTypeId = '" + priceTypeId.ToString() + "'";

                                        var oPrice = ctx.ProductPrice.Where(x => x.ProductId == oSDetail.ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                        if (oPrice != null)
                                        {
                                            oLedgerDetail.VendorRef = oPrice.CurrencyCode;
                                        }
                                    }
                                    ctx.InvtLedgerDetails.Add(oLedgerDetail);

                                    var oLedgerHeader2 = ctx.InvtLedgerHeader.Find(ledgerHeaderId);
                                    if (oLedgerHeader2 != null)
                                    {
                                        oLedgerHeader2.TotalAmount += oLedgerDetail.Amount;
                                    }

                                    ctx.SaveChanges();
                                }
                                #endregion

                                oBatchHeader.PostedBy = ConfigHelper.CurrentUserId;
                                oBatchHeader.PostedOn = DateTime.Now;
                                oBatchHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                                oBatchHeader.ModifiedOn = DateTime.Now;
                                ctx.SaveChanges();

                                #region ClearBatchTransaction(oBatchHeader);
                                string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
                                var detailList = ctx.InvtBatchADJ_Details.Where(x => x.HeaderId == oBatchHeader.HeaderId);
                                foreach (var detail in detailList)
                                {
                                    ctx.InvtBatchADJ_Details.Remove(detail);
                                }

                                ctx.InvtBatchADJ_Header.Remove(oBatchHeader);
                                ctx.SaveChanges();
                                #endregion
                            }
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
        */
        #endregion

        #region SubLedger
        /**
        private Guid CreateADJSubLedgerHeader(string txnumber, DateTime txDate, Guid workplaceId, Guid staffId, string remarks, string reference)
        {
            InvtSubLedgerADJ_Header oSubADJ = new InvtSubLedgerADJ_Header();
            oSubADJ.TxNumber = txnumber;
            oSubADJ.TxType = EnumHelper.TxType.ADJ.ToString();
            oSubADJ.WorkplaceId = workplaceId;
            oSubADJ.TxDate = txDate;
            oSubADJ.Reference = reference;
            oSubADJ.Remarks = remarks;
            oSubADJ.StaffId = staffId;
            oSubADJ.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

            oSubADJ.CreatedBy = ConfigHelper.CurrentUserId;
            oSubADJ.CreatedOn = DateTime.Now;
            oSubADJ.ModifiedBy = ConfigHelper.CurrentUserId;
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
                oSubLedgerDetail.TxType = EnumHelper.TxType.ADJ.ToString();
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
                oSubLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;

                oSubLedgerHeader.Save();
            }
        }
        */
        #endregion

        #region Ledger
        /**
        private Guid CreateLedgerHeader(string txnumber, DateTime txDate, Guid subLedgerHeaderId, Guid workplaceId, Guid staffId, string reference, string remarks)
        {
            InvtLedgerHeader oLedgerHeader = new InvtLedgerHeader();
            oLedgerHeader.TxNumber = txnumber;
            oLedgerHeader.TxType = EnumHelper.TxType.ADJ.ToString();
            oLedgerHeader.TxDate = txDate;
            oLedgerHeader.SubLedgerHeaderId = subLedgerHeaderId;
            oLedgerHeader.WorkplaceId = workplaceId;
            oLedgerHeader.StaffId = staffId;
            oLedgerHeader.Reference = reference;
            oLedgerHeader.Remarks = remarks;
            oLedgerHeader.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));
            oLedgerHeader.CreatedBy = ConfigHelper.CurrentUserId;
            oLedgerHeader.CreatedOn = DateTime.Now;
            oLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;
            oLedgerHeader.ModifiedOn = DateTime.Now;
            oLedgerHeader.Save();

            return oLedgerHeader.HeaderId;
        }

        private void CreateLedgerDetails(string txnumber, Guid subledgerHeaderId, Guid ledgerHeaderId, InvtBatchADJ_Header oBatchHeader)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        //string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
                        //string[] orderBy = new string[] { "LineNumber" };

                        var oSubLedgerDetails = ctx.InvtSubLedgerADJ_Details.Where(x => x.HeaderId == subledgerHeaderId).OrderBy(x => x.LineNumber);
                        foreach (var oSDetail in oSubLedgerDetails)
                        {
                            InvtLedgerDetails oLedgerDetail = new InvtLedgerDetails();
                            oLedgerDetail.HeaderId = ledgerHeaderId;
                            oLedgerDetail.SubLedgerDetailsId = oSDetail.DetailsId;
                            oLedgerDetail.LineNumber = oSDetail.LineNumber.Value;
                            oLedgerDetail.ProductId = oSDetail.ProductId;
                            oLedgerDetail.Qty = oSDetail.Qty.Value;
                            oLedgerDetail.TxNumber = txnumber;
                            oLedgerDetail.TxType = EnumHelper.TxType.ADJ.ToString();
                            oLedgerDetail.TxDate = oBatchHeader.TxDate;
                            oLedgerDetail.Amount = oLedgerDetail.Qty * oLedgerDetail.AverageCost;
                            oLedgerDetail.Notes = string.Empty;
                            oLedgerDetail.SerialNumber = string.Empty;
                            oLedgerDetail.SHOP = ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId);
                            oLedgerDetail.OPERATOR = ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.StaffId);

                            // Product Info
                            var oItem = ctx.Product.Find(oSDetail.ProductId);
                            if (oItem != null)
                            {
                                oLedgerDetail.BasicPrice = oItem.RetailPrice.Value;
                                oLedgerDetail.UnitAmount = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);
                                oLedgerDetail.Discount = oItem.NormalDiscount;
                                oLedgerDetail.Amount = oLedgerDetail.UnitAmount * oLedgerDetail.Qty;
                                oLedgerDetail.AverageCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);

                                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(EnumHelper.ProductPriceType.VPRC.ToString());
                                //sql = "ProductId = '" + oSDetail.ProductId.ToString() + "' AND PriceTypeId = '" + priceTypeId.ToString() + "'";

                                var oPrice = ctx.ProductPrice.Where(x => x.ProductId == oSDetail.ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oPrice != null)
                                {
                                    oLedgerDetail.VendorRef = oPrice.CurrencyCode;
                                }
                            }

                            InvtLedgerHeader oLedgerHeader = InvtLedgerHeader.Load(ledgerHeaderId);
                            if (oLedgerHeader != null)
                            {
                                oLedgerHeader.TotalAmount += oLedgerDetail.Amount;
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
                        var detailsList = ctx.InvtBatchADJ_Details.Where(x => x.HeaderId == txHeaderId);
                        foreach (var item in detailsList)
                        {
                            Guid productId = item.ProductId;
                            decimal qty = item.Qty.Value;

                            #region UpdateProductCurrentSummary(item.ProductId, item.Qty.Value);
                            var currProd = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                            if (currProd == null)
                            {
                                currProd = new EF6.ProductCurrentSummary();
                                currProd.CurrentSummaryId = Guid.NewGuid();
                                currProd.ProductId = productId;
                                ctx.ProductCurrentSummary.Add(currProd);
                            }
                            currProd.CDQTY += qty;
                            #endregion

                            #region UpdateProductQty(item.ProductId, workplaceId, item.Qty.Value);
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