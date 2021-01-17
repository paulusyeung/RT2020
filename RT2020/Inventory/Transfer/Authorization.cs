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

namespace RT2020.Inventory.Transfer
{
    public partial class Authorization : Form
    {
        private String _NewEraBeginsOn = "2013-11-30 00:00:00";     //在這天之前的 Transactions 不會顯示
        private DataTable _ErrorPool;                               //存放有問題的 Tx 和相關的 Error Message
        private RT2020.Controls.InvtUtility.PostingStatus _PostStatus = RT2020.Controls.InvtUtility.PostingStatus.Ready;

        public Authorization()
        {
            InitializeComponent();
            InitComboBox();

            BindingList(EnumHelper.Status.Draft);
            BindingList(EnumHelper.Status.Active);
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
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            return SqlHelper.Default.ExecuteReader(cmd);
        }

        private void BindingList(EnumHelper.Status status)
        {
            SqlDataReader reader;
            switch (status)
            {
                case EnumHelper.Status.Draft: // Holding
                    reader = DataSource(EnumHelper.Status.Draft.ToString("d"), false);
                    BindingHoldingList(reader);
                    break;
                case EnumHelper.Status.Active: // Posting
                    reader = DataSource(EnumHelper.Status.Active.ToString("d"), true);
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
                objItem.SubItems.Add(reader.GetString(4)); // From Location
                objItem.SubItems.Add(reader.GetString(5)); // To Location
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(8), false)); // CreatedOn

                iCount++;
            }
            reader.Close();
        }

        private void BindingPostingList(SqlDataReader reader)
        {
            lvPostTxList.Items.Clear();

            int iCount = 1;

            while (reader.Read())
            {
                ListViewItem objItem = this.lvPostTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                objItem.SubItems.Add(new IconResourceHandle("16x16.16_progress.gif").ToString());
                objItem.SubItems.Add(iCount.ToString()); // Line Number
                objItem.SubItems.Add(reader.GetString(2)); // TxNumber
                objItem.SubItems.Add(reader.GetString(1)); // Type
                objItem.SubItems.Add(reader.GetString(4)); // From Location
                objItem.SubItems.Add(reader.GetString(5)); // To Location
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(8), false)); // CreatedOn
                objItem.BackColor = CheckTxDate(reader.GetDateTime(3)) ? Color.Transparent : RT2020.SystemInfo.ControlBackColor.DisabledBox;

                iCount++;
            }
            reader.Close();
        }

        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT HeaderId, TxType, TxNumber, TxDate, FromLocation, ToLocation, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy ");
            sql.Append(" FROM vwDraftTxferList ");
            sql.Append(" WHERE TxDate >= '").Append(_NewEraBeginsOn).Append("' AND STATUS = ").Append(status).Append(" AND ReadOnly = 0");
            sql.Append(" AND TxType = '").Append(EnumHelper.TxType.TXF.ToString()).Append("'");

            if (txtTxNumber.Text.Trim().Length > 0)
            {
                sql.Append(" AND TxNumber LIKE '%").Append(txtTxNumber.Text).Append("%'");
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
                case "From Loc#":
                    colName = "FromLocation";
                    break;
                case "To Loc#":
                    colName = "ToLocation";
                    break;
                case "Tx Date":
                    colName = "TxDate";
                    break;
                case "Last Update(dd/MM/yyyy)":
                    colName = "ModifiedOn";
                    break;
                case "Last Update":
                    colName = "ModifiedBy";
                    break;
                default:
                case "Tx#":
                    colName = "TxNumber";
                    break;
            }
            return colName;
        }

        private bool VerifyDate()
        {
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

        private DataTable InitErrorPool()
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

        #region Count 勾選咗嘅 items，同時 flag 有問題的 item，把問題存放喺 _ErrorPool
        private int ValidateSelectedTx()
        {
            int errorCounts = 0;
            _ErrorPool = InitErrorPool();

            foreach (ListViewItem objItem in this.lvPostTxList.Items)
            {
                if (objItem.Checked)
                {
                    if (!IsPostable(objItem.Text))
                    {
                        objItem.SubItems[1].Text = new IconResourceHandle("16x16.16_error.gif").ToString();
                        _PostStatus = RT2020.Controls.InvtUtility.PostingStatus.Error;
                        errorCounts++;
                    }

                    colPostingStatus.Visible = true;
                    this.Update();
                }
                else
                {
                    objItem.SubItems[1].Text = string.Empty;
                }
            }

            if (_PostStatus == RT2020.Controls.InvtUtility.PostingStatus.Ready)
            {
                _PostStatus = RT2020.Controls.InvtUtility.PostingStatus.Postable;
            }

            return errorCounts;
        }

        private bool IsPostable(string headerId)
        {
            bool isPostable = true;

            using (var ctx = new EF6.RT2020Entities())
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(headerId, out id))
                {
                    var oBatchHeader = ctx.InvtBatchTXF_Header.Find(id);
                    if (oBatchHeader != null)
                    {
                        if (!CheckTxDate(oBatchHeader.TxDate.Value))
                        {
                            DataRow row = _ErrorPool.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = string.Empty;
                            row["APPENDIX1"] = string.Empty;
                            row["APPENDIX2"] = string.Empty;
                            row["APPENDIX3"] = string.Empty;
                            row["ErrorReason"] = "Transaction date does not belong to current system month.";
                            row["PostDate"] = DateTime.Now;

                            _ErrorPool.Rows.Add(row);

                            isPostable = isPostable & false;
                        }

                        if (oBatchHeader.ReadOnly && oBatchHeader.Status == (int)EnumHelper.Status.Active)
                        {
                            DataRow row = _ErrorPool.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = string.Empty;
                            row["APPENDIX1"] = string.Empty;
                            row["APPENDIX2"] = string.Empty;
                            row["APPENDIX3"] = string.Empty;
                            row["ErrorReason"] = "Transaction already had been posted! Cannot post again!";
                            row["PostDate"] = DateTime.Now;

                            _ErrorPool.Rows.Add(row);

                            isPostable = isPostable & false;
                        }

                       var detailList = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == oBatchHeader.HeaderId).AsNoTracking().ToList();
                        foreach (var detail in detailList)
                        {
                            bool retired = false;
                            string stk = string.Empty, a1 = string.Empty, a2 = string.Empty, a3 = string.Empty;

                            var oProduct = ModelEx.ProductEx.Get(detail.ProductId.Value);
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
                                DataRow row = _ErrorPool.NewRow();
                                row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                                row["TxNumber"] = oBatchHeader.TxNumber;
                                row["STKCODE"] = stk;
                                row["APPENDIX1"] = a1;
                                row["APPENDIX2"] = a2;
                                row["APPENDIX3"] = a3;
                                row["ErrorReason"] = "Product does not exist or has been removed!";
                                row["PostDate"] = DateTime.Now;

                                _ErrorPool.Rows.Add(row);

                                isPostable = isPostable & false;
                            }

                            if (chkNegative.Checked)
                            {
                                decimal cdqty = ProductHelper.GetOnHandQtyByWorkplaceId(detail.ProductId.Value, oBatchHeader.FromLocation.Value);

                                if ((cdqty - detail.QtyRequested) < 0)
                                {
                                    DataRow row = _ErrorPool.NewRow();
                                    row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                                    row["TxNumber"] = oBatchHeader.TxNumber;
                                    row["STKCODE"] = stk;
                                    row["APPENDIX1"] = a1;
                                    row["APPENDIX2"] = a2;
                                    row["APPENDIX3"] = a3;
                                    row["ErrorReason"] = "Product does not have enough on-hand qty!";
                                    row["PostDate"] = DateTime.Now;

                                    _ErrorPool.Rows.Add(row);

                                    isPostable = isPostable & false;
                                }
                            }
                        }

                        var oStaff = ModelEx.StaffEx.GetByStaffId(oBatchHeader.StaffId);
                        if (oStaff != null)
                        {
                            if (oStaff.Retired)
                            {
                                DataRow row = _ErrorPool.NewRow();
                                row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                                row["TxNumber"] = oBatchHeader.TxNumber;
                                row["STKCODE"] = string.Empty;
                                row["APPENDIX1"] = string.Empty;
                                row["APPENDIX2"] = string.Empty;
                                row["APPENDIX3"] = string.Empty;
                                row["ErrorReason"] = "Staff has been removed!";
                                row["PostDate"] = DateTime.Now;

                                _ErrorPool.Rows.Add(row);

                                isPostable = isPostable & false;
                            }
                        }

                        var oInvtLedger = ctx.InvtLedgerHeader
                            .Where(x => x.TxNumber == oBatchHeader.TxNumber && (x.TxType == "TXI" || x.TxType == "TXO"))
                            .AsNoTracking()
                            .FirstOrDefault();
                        if (oInvtLedger != null)
                        {
                            DataRow row = _ErrorPool.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = string.Empty;
                            row["APPENDIX1"] = string.Empty;
                            row["APPENDIX2"] = string.Empty;
                            row["APPENDIX3"] = string.Empty;
                            row["ErrorReason"] = "Transaction existed in Inventory Ledger!";
                            row["PostDate"] = DateTime.Now;

                            _ErrorPool.Rows.Add(row);

                            isPostable = isPostable & false;
                        }

                        string message = string.Empty;
                        var fromLoc = ModelEx.WorkplaceEx.GetWorkplaceById(oBatchHeader.FromLocation.Value);
                        if (fromLoc == null)
                        {
                            message = "Transfer From location does existe!";
                        }
                        else if (fromLoc.Retired)
                        {
                            message = "Transfer From location has been removed!";
                        }

                        if (message.Length > 0)
                        {
                            DataRow row = _ErrorPool.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = string.Empty;
                            row["APPENDIX1"] = string.Empty;
                            row["APPENDIX2"] = string.Empty;
                            row["APPENDIX3"] = string.Empty;
                            row["ErrorReason"] = message;
                            row["PostDate"] = DateTime.Now;

                            _ErrorPool.Rows.Add(row);

                            isPostable = isPostable & false;
                        }

                        message = string.Empty;
                        var toLoc = ModelEx.WorkplaceEx.GetWorkplaceById(oBatchHeader.ToLocation.Value);
                        if (toLoc == null)
                        {
                            message = "Transfer To location does existe!";
                        }
                        else if (toLoc.Retired)
                        {
                            message = "Transfer To location has been removed!";
                        }

                        if (message.Length > 0)
                        {
                            DataRow row = _ErrorPool.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = string.Empty;
                            row["APPENDIX1"] = string.Empty;
                            row["APPENDIX2"] = string.Empty;
                            row["APPENDIX3"] = string.Empty;
                            row["ErrorReason"] = message;
                            row["PostDate"] = DateTime.Now;

                            _ErrorPool.Rows.Add(row);

                            isPostable = isPostable & false;
                        }
                    }
                    else
                    {
                        DataRow row = _ErrorPool.NewRow();
                        row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                        row["TxNumber"] = oBatchHeader.TxNumber;
                        row["STKCODE"] = string.Empty;
                        row["APPENDIX1"] = string.Empty;
                        row["APPENDIX2"] = string.Empty;
                        row["APPENDIX3"] = string.Empty;
                        row["ErrorReason"] = "Transaction does not existe!";
                        row["PostDate"] = DateTime.Now;

                        _ErrorPool.Rows.Add(row);

                        return false;
                    }
                }
            }

            return isPostable;
        }
        #endregion

        private bool CheckTxDate(DateTime txDate)
        {
            bool isChecked = false;

            isChecked = (txDate.Year.ToString() == RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear);
            isChecked = isChecked & (txDate.Month.ToString().PadLeft(2, '0') == RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth);

            return isChecked;
        }

        private bool FoundInErrorPool(string headerId)
        {
            if (_ErrorPool == null)
            {
                return false;
            }

            DataRow[] rows = _ErrorPool.Select("HeaderId = '" + headerId + "'");
            return rows.Length > 0;
        }

        #endregion

        #region Posting Batch

        private int PostSelectedTx()
        {
            int iCount = 0;
            if (lvPostTxList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvPostTxList.CheckedItems)
                {
                    Guid id = Guid.Empty;
                    if (Guid.TryParse(oItem.Text, out id) && oItem.Checked)
                    {
                        if (!(FoundInErrorPool(oItem.Text)))
                        {
                            if (PostThisTx(id))
                            {
                                oItem.SubItems[1].Text = new IconResourceHandle("16x16.16_succeeded.png").ToString();
                                ++iCount;
                            }
                        }
                    }
                }
            }
            return iCount;
        }

        private bool PostThisTx(Guid headerId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oBatchHeader = ctx.InvtBatchTXF_Header.Find(headerId);
                        if (oBatchHeader != null)
                        {
                            // Update Product Info
                            #region UpdateProduct(oBatchHeader);
                            var detailsList = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == headerId);
                            foreach (var detail in detailsList)
                            //for (int i = 0; i < detailsList.Count; i++)
                            {
                                //InvtBatchTXF_Details detail = detailsList[i];

                                //Out
                                #region UpdateProductQty(detail.ProductId, oBatchHeader.FromLocation, detail.QtyRequested * (-1));
                                var wpOut = ctx.ProductWorkplace.Where(x => x.ProductId == detail.ProductId.Value && x.WorkplaceId == oBatchHeader.FromLocation).FirstOrDefault();
                                if (wpOut == null)
                                {
                                    wpOut = new EF6.ProductWorkplace();
                                    wpOut.ProductWorkplaceId = Guid.Empty;
                                    wpOut.ProductId = detail.ProductId.Value;
                                    wpOut.WorkplaceId = oBatchHeader.FromLocation.Value;

                                    ctx.ProductWorkplace.Add(wpOut);
                                }

                                wpOut.CDQTY += detail.QtyRequested.Value * (-1);
                                #endregion

                                //In
                                #region UpdateProductQty(detail.ProductId, oBatchHeader.ToLocation, detail.QtyRequested);
                                var wpIn = ctx.ProductWorkplace.Where(x => x.ProductId == detail.ProductId.Value && x.WorkplaceId == oBatchHeader.ToLocation).FirstOrDefault();
                                if (wpIn == null)
                                {
                                    wpIn = new EF6.ProductWorkplace();
                                    wpIn.ProductWorkplaceId = Guid.NewGuid();
                                    wpIn.ProductId = detail.ProductId.Value;
                                    wpIn.WorkplaceId = oBatchHeader.ToLocation.Value;

                                    ctx.ProductWorkplace.Add(wpIn);
                                }

                                wpIn.CDQTY += detail.QtyRequested.Value;
                                #endregion

                                ctx.SaveChanges();
                            }
                            #endregion

                            // Create TXF SubLedger
                            string txNumber_SubLedger = oBatchHeader.TxNumber;

                            #region Guid subLedgerHeaderId = CreateTXFSubLedgerHeader(txNumber_SubLedger, oBatchHeader);
                            var oSubTXF = new EF6.InvtSubLedgerTXF_Header();
                            oSubTXF.HeaderId = Guid.NewGuid();
                            oSubTXF.TxNumber = txNumber_SubLedger;
                            oSubTXF.TxType = oBatchHeader.TxType;
                            oSubTXF.TxDate = oBatchHeader.TxDate;
                            oSubTXF.StaffId = oBatchHeader.StaffId;
                            oSubTXF.FromLocation = oBatchHeader.FromLocation;
                            oSubTXF.ToLocation = oBatchHeader.ToLocation;
                            oSubTXF.TransferredOn = oBatchHeader.TransferredOn;
                            oSubTXF.CompletedOn = oBatchHeader.CompletedOn;
                            oSubTXF.Reference = oBatchHeader.Reference + "\t" + oBatchHeader.TxNumber;
                            oSubTXF.DeliveryNoteRef = oBatchHeader.DeliveryNoteRef;
                            oSubTXF.Remarks = oBatchHeader.Remarks;
                            oSubTXF.PostedOn = DateTime.Now;
                            oSubTXF.PostedBy = ConfigHelper.CurrentUserId;
                            oSubTXF.POSTNEG = !chkNegative.Checked;
                            oSubTXF.ReadOnly = true;
                            oSubTXF.PickingNoteRef = oBatchHeader.PickingNoteRef;
                            oSubTXF.Picked = oBatchHeader.Picked;
                            oSubTXF.Status = (int)EnumHelper.Status.Active;
                            oSubTXF.CONFIRM_TRF = oBatchHeader.CONFIRM_TRF;
                            oSubTXF.CONFIRM_TRF_LASTUPDATE = oBatchHeader.CONFIRM_TRF_LASTUPDATE;
                            oSubTXF.CONFIRM_TRF_LASTUSER = oBatchHeader.CONFIRM_TRF_LASTUSER;

                            oSubTXF.CreatedBy = ConfigHelper.CurrentUserId;
                            oSubTXF.CreatedOn = DateTime.Now;
                            oSubTXF.ModifiedBy = ConfigHelper.CurrentUserId;
                            oSubTXF.ModifiedOn = DateTime.Now;

                            ctx.InvtSubLedgerTXF_Header.Add(oSubTXF);

                            var subLedgerHeaderId = oSubTXF.HeaderId;
                            #endregion

                            #region CreateTXFSubLedgerDetail(txNumber_SubLedger, oBatchHeader.HeaderId, subLedgerHeaderId);
                            string txnumber = txNumber_SubLedger;
                            Guid batchHeaderId = oBatchHeader.HeaderId;
                            //Guid subledgerHeaderId = subLedgerHeaderId;

                            var oBatchDetails = ctx.InvtBatchTXF_Details
                                .Where(x => x.HeaderId == batchHeaderId)
                                .OrderBy(x => x.LineNumber);
                            foreach (var oBDetail in oBatchDetails)
                            {
                                var oSubLedgerDetail = new EF6.InvtSubLedgerTXF_Details();
                                oSubLedgerDetail.HeaderId = subLedgerHeaderId;
                                oSubLedgerDetail.TxType = oBDetail.TxType;
                                oSubLedgerDetail.TxNumber = txnumber;
                                oSubLedgerDetail.LineNumber = oBDetail.LineNumber;
                                oSubLedgerDetail.ProductId = oBDetail.ProductId.Value;
                                oSubLedgerDetail.QtyRequested = oBDetail.QtyRequested;
                                oSubLedgerDetail.QtyReceived = oBDetail.QtyReceived;
                                oSubLedgerDetail.QtyManualInput = oBDetail.QtyManualInput;
                                oSubLedgerDetail.QtyHHT = oBDetail.QtyHHT;
                                oSubLedgerDetail.QtyConfirmed = oBDetail.QtyConfirmed;
                                oSubLedgerDetail.Remarks = oBDetail.Remarks;

                               ctx.InvtSubLedgerTXF_Details.Add(oSubLedgerDetail);
                            }

                            var oSubLedgerHeader = ctx.InvtSubLedgerTXF_Header.Find(subLedgerHeaderId);
                            if (oSubLedgerHeader != null)
                            {
                                oSubLedgerHeader.ModifiedOn = DateTime.Now;
                                oSubLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;

                                ctx.SaveChanges();
                            }
                            #endregion

                            // Create Ledger
                            CreateLedger(subLedgerHeaderId, oBatchHeader, txNumber_SubLedger);

                            #region Update Batch Header Info
                            oBatchHeader.PostedOn = DateTime.Now;
                            oBatchHeader.PostedBy = ConfigHelper.CurrentUserId;
                            oBatchHeader.POSTNEG = true;
                            oBatchHeader.ReadOnly = true;
                            oBatchHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                            oBatchHeader.ModifiedOn = DateTime.Now;
                            #endregion

                            ctx.SaveChanges();

                            result = true;

                            #region ClearBatchTransaction(oBatchHeader);
                            var batchHeader = ctx.InvtBatchTXF_Header.Find(headerId);
                            if (batchHeader != null)
                            {
                                var batchDetails = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == headerId);
                                foreach (var batchDetail in batchDetails)
                                {
                                    ctx.InvtBatchTXF_Details.Remove(batchDetail);
                                }

                                ctx.InvtBatchTXF_Header.Remove(batchHeader);
                                ctx.SaveChanges();
                            }
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
            return result;
        }

        #region Clear Batch
        /**
        /// <summary>
        /// Clears the batch transaction.
        /// </summary>
        private void ClearBatchTransaction(InvtBatchTXF_Header oBatchHeader)
        {
            string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
            InvtBatchTXF_DetailsCollection detailList = InvtBatchTXF_Details.LoadCollection(query);
            for (int i = 0; i < detailList.Count; i++)
            {
                detailList[i].Delete();
            }

            oBatchHeader.Delete();
        }
        */
        #endregion

        #region SubLedger
        private Guid CreateTXFSubLedgerHeader(string txnumber, EF6.InvtBatchTXF_Header oBatchHeader)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oSubTXF = new EF6.InvtSubLedgerTXF_Header();
                oSubTXF.TxNumber = txnumber;
                oSubTXF.TxType = oBatchHeader.TxType;
                oSubTXF.TxDate = oBatchHeader.TxDate;
                oSubTXF.StaffId = oBatchHeader.StaffId;
                oSubTXF.FromLocation = oBatchHeader.FromLocation;
                oSubTXF.ToLocation = oBatchHeader.ToLocation;
                oSubTXF.TransferredOn = oBatchHeader.TransferredOn;
                oSubTXF.CompletedOn = oBatchHeader.CompletedOn;
                oSubTXF.Reference = oBatchHeader.Reference + "\t" + oBatchHeader.TxNumber;
                oSubTXF.DeliveryNoteRef = oBatchHeader.DeliveryNoteRef;
                oSubTXF.Remarks = oBatchHeader.Remarks;
                oSubTXF.PostedOn = DateTime.Now;
                oSubTXF.PostedBy = ConfigHelper.CurrentUserId;
                oSubTXF.POSTNEG = !chkNegative.Checked;
                oSubTXF.ReadOnly = true;
                oSubTXF.PickingNoteRef = oBatchHeader.PickingNoteRef;
                oSubTXF.Picked = oBatchHeader.Picked;
                oSubTXF.Status = (int)EnumHelper.Status.Active;
                oSubTXF.CONFIRM_TRF = oBatchHeader.CONFIRM_TRF;
                oSubTXF.CONFIRM_TRF_LASTUPDATE = oBatchHeader.CONFIRM_TRF_LASTUPDATE;
                oSubTXF.CONFIRM_TRF_LASTUSER = oBatchHeader.CONFIRM_TRF_LASTUSER;

                oSubTXF.CreatedBy = ConfigHelper.CurrentUserId;
                oSubTXF.CreatedOn = DateTime.Now;
                oSubTXF.ModifiedBy = ConfigHelper.CurrentUserId;
                oSubTXF.ModifiedOn = DateTime.Now;

                ctx.InvtSubLedgerTXF_Header.Add(oSubTXF);
                ctx.SaveChanges();

                result = oSubTXF.HeaderId;
            }
            return result;
        }

        private void CreateTXFSubLedgerDetail(string txnumber, Guid batchHeaderId, Guid subledgerHeaderId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
                        string[] orderBy = new string[] { "LineNumber" };

                        var oBatchDetails = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == batchHeaderId).OrderBy(x => x.LineNumber);
                        foreach (var oBDetail in oBatchDetails)
                        {
                            var oSubLedgerDetail = new EF6.InvtSubLedgerTXF_Details();
                            oSubLedgerDetail.HeaderId = subledgerHeaderId;
                            oSubLedgerDetail.TxType = oBDetail.TxType;
                            oSubLedgerDetail.TxNumber = txnumber;
                            oSubLedgerDetail.LineNumber = oBDetail.LineNumber;
                            oSubLedgerDetail.ProductId = oBDetail.ProductId.Value;
                            oSubLedgerDetail.QtyRequested = oBDetail.QtyRequested;
                            oSubLedgerDetail.QtyReceived = oBDetail.QtyReceived;
                            oSubLedgerDetail.QtyManualInput = oBDetail.QtyManualInput;
                            oSubLedgerDetail.QtyHHT = oBDetail.QtyHHT;
                            oSubLedgerDetail.QtyConfirmed = oBDetail.QtyConfirmed;
                            oSubLedgerDetail.Remarks = oBDetail.Remarks;

                            ctx.InvtSubLedgerTXF_Details.Add(oSubLedgerDetail);
                        }

                        var oSubLedgerHeader = ctx.InvtSubLedgerTXF_Header.Find(subledgerHeaderId);
                        if (oSubLedgerHeader != null)
                        {
                            oSubLedgerHeader.ModifiedOn = DateTime.Now;
                            oSubLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;
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
        #endregion

        #region Ledger
        private void CreateLedger(Guid subLedgerHeaderId, EF6.InvtBatchTXF_Header oBatchHeader, string subLedgerTxNumber)
        {
            // Transfer In
            Guid ledgerHeaderId_In = CreateLedgerHeader(
                subLedgerHeaderId, 
                EnumHelper.TxType.TXI.ToString(), 
                oBatchHeader.ToLocation.Value, 
                oBatchHeader.FromLocation.Value, 
                oBatchHeader.StaffId, 
                oBatchHeader.Reference + "\t" + oBatchHeader.TxNumber,
                oBatchHeader.Remarks,
                oBatchHeader);
            CreateLedgerDetails(
                oBatchHeader, 
                EnumHelper.TxType.TXI.ToString(), 
                subLedgerHeaderId, 
                ledgerHeaderId_In,
                1,
                ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.FromLocation.Value), 
                ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.StaffId));

            // Transfer Out
            Guid ledgerHeaderId_Out = CreateLedgerHeader(subLedgerHeaderId, EnumHelper.TxType.TXO.ToString(), oBatchHeader.FromLocation.Value, oBatchHeader.ToLocation.Value, oBatchHeader.StaffId, oBatchHeader.Reference + "\t" + oBatchHeader.TxNumber, oBatchHeader.Remarks, oBatchHeader);
            CreateLedgerDetails(oBatchHeader, EnumHelper.TxType.TXO.ToString(), subLedgerHeaderId, ledgerHeaderId_Out, 1, ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.ToLocation.Value), ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.StaffId));

            // Update LedgerHeader
            UpdateVsLedgerHeader(ledgerHeaderId_In, ledgerHeaderId_Out);
        }

        private Guid CreateLedgerHeader(Guid subLedgerHeaderId, string txType, Guid workplaceId, Guid vsLocationId, Guid staffId, string reference, string remarks, EF6.InvtBatchTXF_Header oBatchHeader)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oLedgerHeader = new EF6.InvtLedgerHeader();
                oLedgerHeader.HeaderId = Guid.NewGuid();
                oLedgerHeader.TxNumber = oBatchHeader.TxNumber;
                oLedgerHeader.TxType = txType;
                oLedgerHeader.TxDate = oBatchHeader.TxDate.Value;
                oLedgerHeader.SubLedgerHeaderId = subLedgerHeaderId;
                oLedgerHeader.WorkplaceId = workplaceId;
                oLedgerHeader.VsLocationId = vsLocationId;
                oLedgerHeader.StaffId = staffId;
                oLedgerHeader.Staff1 = ConfigHelper.CurrentUserId;
                oLedgerHeader.Reference = reference;
                oLedgerHeader.Remarks = remarks;
                oLedgerHeader.Status = (int)EnumHelper.Status.Active;
                oLedgerHeader.CreatedBy = ConfigHelper.CurrentUserId;
                oLedgerHeader.CreatedOn = DateTime.Now;
                oLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                oLedgerHeader.ModifiedOn = DateTime.Now;
                oLedgerHeader.CONFIRM_TRF = oBatchHeader.CONFIRM_TRF;
                oLedgerHeader.CONFIRM_TRF_LASTUPDATE = oBatchHeader.CONFIRM_TRF_LASTUPDATE;
                oLedgerHeader.CONFIRM_TRF_LASTUSER = ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.CONFIRM_TRF_LASTUSER.Value);

                ctx.InvtLedgerHeader.Add(oLedgerHeader);
                ctx.SaveChanges();

                result = oLedgerHeader.HeaderId; ;
            }

            return result;
        }

        private void CreateLedgerDetails(EF6.InvtBatchTXF_Header oBatchHeader, string txType, Guid subledgerHeaderId, Guid ledgerHeaderId, decimal Direction, string shop, string staffNumber)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        //string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
                        //string[] orderBy = new string[] { "LineNumber" };
                        var oSubLedgerDetails = ctx.InvtSubLedgerTXF_Details.Where(x => x.HeaderId == subledgerHeaderId).OrderBy(x => x.LineNumber);
                        foreach (var oSDetail in oSubLedgerDetails)
                        {
                            var oLedgerDetail = new EF6.InvtLedgerDetails();
                            oLedgerDetail.DetailsId = Guid.NewGuid();
                            oLedgerDetail.HeaderId = ledgerHeaderId;
                            oLedgerDetail.SubLedgerDetailsId = oSDetail.DetailsId;
                            oLedgerDetail.LineNumber = oSDetail.LineNumber.Value;
                            oLedgerDetail.ProductId = oSDetail.ProductId;
                            oLedgerDetail.Qty = oSDetail.QtyRequested.Value * Direction;
                            oLedgerDetail.TxNumber = oBatchHeader.TxNumber;
                            oLedgerDetail.TxType = txType;
                            oLedgerDetail.TxDate = oBatchHeader.TxDate.Value;
                            oLedgerDetail.UnitAmount = 0;
                            oLedgerDetail.Amount = 0;
                            oLedgerDetail.AverageCost = 0;
                            oLedgerDetail.Notes = string.Empty;
                            oLedgerDetail.SerialNumber = string.Empty;
                            oLedgerDetail.SHOP = shop;
                            oLedgerDetail.OPERATOR = staffNumber;
                            oLedgerDetail.CONFIRM_TRF_QTY = oSDetail.QtyConfirmed.Value;

                            #region Product Info
                            var oItem = ctx.Product.Find(oSDetail.ProductId);
                            if (oItem != null)
                            {
                                oLedgerDetail.BasicPrice = oItem.RetailPrice.Value;
                                oLedgerDetail.Discount = oItem.NormalDiscount;
                                oLedgerDetail.AverageCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);

                                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.VPRC.ToString());
                                //sql = "ProductId = '" + oSDetail.ProductId.ToString() + "' AND PriceTypeId = '" + priceTypeId.ToString() + "'";
                                var oPrice = ctx.ProductPrice.Where(x => x.ProductId == oSDetail.ProductId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oPrice != null)
                                {
                                    oLedgerDetail.VendorRef = oPrice.CurrencyCode;
                                }
                            }
                            #endregion

                            var oLedgerHeader = ctx.InvtLedgerHeader.Find(ledgerHeaderId);
                            if (oLedgerHeader != null)
                            {
                                oLedgerHeader.TotalAmount += oLedgerDetail.Amount;
                            }

                            ctx.InvtLedgerDetails.Add(oLedgerDetail);
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

        private void UpdateVsLedgerHeader(Guid ledgerHeaderId, Guid vsLedgerHeaderId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var ledgerHeader = ctx.InvtLedgerHeader.Find(ledgerHeaderId);
                if (ledgerHeader != null)
                {
                    ledgerHeader.VsLeddgerHeaderId = vsLedgerHeaderId;
                    ctx.SaveChanges();
                }

                var vsLedgerHeader = ctx.InvtLedgerHeader.Find(vsLedgerHeaderId);
                if (vsLedgerHeader != null)
                {
                    vsLedgerHeader.VsLeddgerHeaderId = ledgerHeaderId;
                    ctx.SaveChanges();
                }
            }
        }
        #endregion

        #region Product
        /**
        private void UpdateProduct(InvtBatchTXF_Header oBatchHeader)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        //string sql = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
                        var detailsList = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == oBatchHeader.HeaderId);
                        foreach (var detail in detailsList)
                        //for (int i = 0; i < detailsList.Count; i++)
                        {
                            //InvtBatchTXF_Details detail = detailsList[i];

                            //Out
                            #region UpdateProductQty(detail.ProductId, oBatchHeader.FromLocation, detail.QtyRequested * (-1));
                            var wpOut = ctx.ProductWorkplace.Where(x => x.ProductId == detail.ProductId.Value && x.WorkplaceId == oBatchHeader.FromLocation).FirstOrDefault();
                            if (wpOut == null)
                            {
                                wpOut = new EF6.ProductWorkplace();
                                wpOut.ProductWorkplaceId = Guid.Empty;
                                wpOut.ProductId = detail.ProductId.Value;
                                wpOut.WorkplaceId = oBatchHeader.FromLocation;

                                ctx.ProductWorkplace.Add(wpOut);
                            }

                            wpOut.CDQTY += detail.QtyRequested.Value * (-1);
                            #endregion

                            //In
                            #region UpdateProductQty(detail.ProductId, oBatchHeader.ToLocation, detail.QtyRequested);
                            var wpIn = ctx.ProductWorkplace.Where(x => x.ProductId == detail.ProductId.Value && x.WorkplaceId == oBatchHeader.ToLocation).FirstOrDefault();
                            if (wpIn == null)
                            {
                                wpIn = new EF6.ProductWorkplace();
                                wpIn.ProductWorkplaceId = Guid.NewGuid();
                                wpIn.ProductId = detail.ProductId.Value;
                                wpIn.WorkplaceId = oBatchHeader.ToLocation;

                                ctx.ProductWorkplace.Add(wpIn);
                            }

                            wpIn.CDQTY += detail.QtyRequested.Value;
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
                using (var ctx = new EF6.RT2020Entities())
                {
                    string sql = "TxNumber LIKE '%" + txtTxNumber.Text.Trim() + "%'";
                    string txNumber = txtTxNumber.Text.Trim();
                    var oHeader = ctx.InvtBatchTXF_Header.Where(x => x.TxNumber.Contains(txNumber)).AsNoTracking().FirstOrDefault();
                    if (oHeader != null)
                    {
                        EnumHelper.Status oStatus = (EnumHelper.Status)Enum.Parse(typeof(EnumHelper.Status), oHeader.Status.ToString());
                        switch (oStatus)
                        {
                            case EnumHelper.Status.Draft: // Holding
                                tabTxfAuthorization.SelectedIndex = 1;
                                break;
                            case EnumHelper.Status.Active: // Posting
                                tabTxfAuthorization.SelectedIndex = 0;
                                break;
                        }

                        BindingList(oStatus);
                    }
                    else
                    {
                        errorProvider.SetError(txtTxNumber, "Transfer Number field does not exist!");
                    }
                }
            }
            else
            {
                errorProvider.SetError(txtTxNumber, "Transfer Number cannot be blank!");
            }
        }
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
            if (VerifyDate())
            {
                errorProvider.SetError(txtTxNumber, string.Empty);

                BindingList(EnumHelper.Status.Active);

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
                int errorCount = ValidateSelectedTx();

                if (errorCount == 0)
                {
                    btnMarkAll.Enabled = false;

                    int result = PostSelectedTx();
                    if (result > 0)
                    {
                        MessageBox.Show(String.Format("Number of record(s) posted = {0}", result.ToString()), "Posting result", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    string errorDetails = string.Empty;
                    if (_ErrorPool != null)
                    {
                        foreach (DataRow errorRow in _ErrorPool.Rows)
                        {
                            errorDetails += errorRow["ErrorReason"].ToString() + " : \n";
                            errorDetails += errorRow["TxNumber"].ToString() + ": " + errorRow["STKCODE"].ToString() + " " + errorRow["APPENDIX1"].ToString() + " " + errorRow["APPENDIX2"].ToString() + "\n";
                        }
                    }
                    MessageBox.Show(String.Format("Number of error(s) found = {0}...Job aborted\n{1}", errorCount.ToString(), errorDetails), "Warning");
                }
            }
            else
            {
                MessageBox.Show("No selected record...", "Warning");
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            chkNegative.Visible = !chkNegative.Visible;
        }

        private void txtTxNumber_TextChanged(object sender, EventArgs e)
        {
            FindingTxNumber();
        }

        private void txtTxNumber_KeyUp(object sender, KeyEventArgs e)
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

                if (_PostStatus != RT2020.Controls.InvtUtility.PostingStatus.Ready)
                {
                    string headerId = this.lvPostTxList.Items[index].Text;
                    if (_ErrorPool != null)
                    {
                        DataRow[] rows = _ErrorPool.Select("HeaderId = '" + headerId + "'");
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
                                if (_PostStatus == RT2020.Controls.InvtUtility.PostingStatus.Postable)
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