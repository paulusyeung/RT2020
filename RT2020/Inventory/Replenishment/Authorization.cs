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

using Gizmox.WebGUI.Common.Resources;
using System.Configuration;
using System.Linq;
using RT2020.Helper;
using RT2020.ModelEx;

#endregion

namespace RT2020.Inventory.Replenishment
{
    public partial class Authorization : Form
    {
        private RT2020.Controls.InvtUtility.PostingStatus postStatus = RT2020.Controls.InvtUtility.PostingStatus.Ready;
        DataTable oTable;

        public Authorization()
        {
            InitializeComponent();
            InitForm();
            FillComboBox();
            BindingPostingList();
        }

        #region Init
        private void InitForm()
        {
            txtPostedOn.Text = DateTimeHelper.DateTimeToString(DateTime.Now, true);
            txtSysMonth.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth;
            txtSysYear.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear;

            cboFieldName.SelectedIndex = 0;
            cboOperator.SelectedIndex = 0;
            cboOrdering.SelectedIndex = 0;
        }

        private void FillComboBox()
        {
            ModelEx.StaffEx.LoadCombo(ref cboStaff, "StaffNumber", false);
            cboStaff.SelectedValue = ConfigHelper.CurrentUserId;
        }
        #endregion

        #region Bind Methods
        private void BindingPostingList()
        {
            lvPostTxList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString(EnumHelper.Status.Active.ToString("d"), true);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvPostTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                    objItem.SubItems.Add(new IconResourceHandle("16x16.16_progress.gif").ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(1)); // TxNumber
                    objItem.SubItems.Add(reader.GetString(4)); // From Location
                    objItem.SubItems.Add(reader.GetString(5)); // To Location
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(2), false)); // TxDate
                    objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(10), false) + " " + ModelEx.StaffEx.GetStaffNumberById(reader.GetGuid(11))); // Last Update
                    objItem.BackColor = CheckTxDate(reader.GetDateTime(2)) ? Color.Transparent : SystemInfoHelper.ControlBackColor.DisabledBox;

                    iCount++;
                }
            }
        }

        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT HeaderId, TxNumber, TxDate, StaffNumber, ");
            sql.Append(" FromLocation, ToLocation, CompletedOn, Remarks, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy ");
            sql.Append(" FROM vwDraftRPLList ");
            sql.Append(" WHERE Confirmed = 1 AND Posted = 0 AND STATUS = ").Append(status);

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
            else if (txtTxNumber.Text.Trim().Length > 0)
            {
                sql.Append(" AND TxNumber LIKE '%").Append(txtTxNumber.Text.Trim()).Append("%'");
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
                case "RPL#":
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

        #region Finding TxNumber
        private void FindingTxNumber()
        {
            errorProvider.SetError(txtTxNumber, string.Empty);
            if (txtTxNumber.Text.Trim().Length > 0)
            {
                string sql = "TxNumber LIKE '%" + txtTxNumber.Text.Trim() + "%'";
                var oHeader = ModelEx.InvtBatchRPL_HeaderEx.Get(sql);
                if (oHeader != null)
                {
                    EnumHelper.Status oStatus = (EnumHelper.Status)Enum.Parse(typeof(EnumHelper.Status), oHeader.Status.ToString());
                    switch (oStatus)
                    {
                        case EnumHelper.Status.Draft: // Holding
                            tabREJAuthorization.SelectedIndex = 1;
                            break;
                        case EnumHelper.Status.Active: // Posting
                            tabREJAuthorization.SelectedIndex = 0;
                            break;
                    }
                    errorProvider.SetError(txtTxNumber, string.Empty);

                    BindingPostingList();
                }
                else
                {
                    errorProvider.SetError(txtTxNumber, "Replenishment Number field does not exist!");
                }
            }
            else
            {
                errorProvider.SetError(txtTxNumber, "Replenishment Number field cannot be blank!");
            }
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

            Guid id = Guid.Empty;
            if (Guid.TryParse(headerId, out id))
            {
                var oBatchHeader = ModelEx.InvtBatchRPL_HeaderEx.Get(id);
                if (oBatchHeader != null)
                {
                    if (!CheckTxDate(oBatchHeader.TxDate.Value))
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

                    if (!oBatchHeader.Confirmed)
                    {
                        DataRow row = errorTable.NewRow();
                        row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                        row["TxNumber"] = oBatchHeader.TxNumber;
                        row["STKCODE"] = string.Empty;
                        row["APPENDIX1"] = string.Empty;
                        row["APPENDIX2"] = string.Empty;
                        row["APPENDIX3"] = string.Empty;
                        row["ErrorReason"] = "Transaction had not been confirmed! Cannot post now!";
                        row["PostDate"] = DateTime.Now;

                        errorTable.Rows.Add(row);

                        isPostable = isPostable & false;
                    }

                    if (oBatchHeader.Posted && oBatchHeader.Status == (int)EnumHelper.Status.Active)
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

                    var detailList = ModelEx.InvtBatchRPL_DetailsEx.GetList("HeaderId = '" + oBatchHeader.HeaderId.ToString() + "' AND TxType = 'RPL'");
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

            isChecked = (txDate.Year.ToString() == SystemInfoEx.CurrentInfo.Default.CurrentSystemYear);
            isChecked = isChecked & (txDate.Month.ToString().PadLeft(2, '0') == SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth);

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

        private int CreateRPLTx()
        {
            int iCount = 0;
            if (lvPostTxList.Items.Count > 0)
            {
                if (chkConsolidate.Checked)
                {
                    iCount = ConsolidateRPL();
                }
                else
                {
                    foreach (ListViewItem oItem in lvPostTxList.CheckedItems)
                    {
                        Guid id = Guid.Empty;
                        if (Guid.TryParse(oItem.Text, out id) && oItem.Checked)
                        {
                            if (!HasError(oItem.Text))
                            {
                                CreateRPLTx(oItem, false);

                                iCount++;

                                oItem.SubItems[1].Text = new IconResourceHandle("16x16.16_succeeded.png").ToString();
                            }
                        }
                    }
                }
            }

            return iCount;
        }

        private string[] CreateRPLTx(ListViewItem listItem, bool IsConsolidation)
        {
            string[] result = new string[2];

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var headerId = Guid.Empty;
                        Guid.TryParse(listItem.Text, out headerId);

                        var oBatchHeader = ctx.InvtBatchRPL_Header.Find(headerId);
                        if (oBatchHeader != null)
                        {
                            #region Update Batch Header Info
                            oBatchHeader.Posted = true;
                            oBatchHeader.PostedBy = ConfigHelper.CurrentUserId;
                            oBatchHeader.PostedOn = DateTime.Now;
                            oBatchHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                            oBatchHeader.ModifiedOn = DateTime.Now;
                            #endregion

                            ctx.SaveChanges();

                            // Create RPL SubLedger
                            string txNumber_SubLedger = oBatchHeader.TxNumber;

                            #region Guid subLedgerHeaderId = CreateRPLSubLedgerHeader(txNumber_SubLedger, oBatchHeader);
                            var txnumber = txNumber_SubLedger;
                            var oSubRPL = new EF6.InvtSubLedgerRPL_Header();
                            oSubRPL.TxNumber = txnumber;
                            oSubRPL.TxDate = oBatchHeader.TxDate;
                            oSubRPL.FromLocation = oBatchHeader.FromLocation;
                            oSubRPL.ToLocation = oBatchHeader.ToLocation;
                            oSubRPL.Remarks = oBatchHeader.Remarks + " \t " + oBatchHeader.TxNumber;
                            oSubRPL.StaffId = oBatchHeader.StaffId;
                            oSubRPL.Status = (int)EnumHelper.Status.Active;
                            oSubRPL.CompletedOn = oBatchHeader.CompletedOn;
                            oSubRPL.SpecialRequest = oBatchHeader.SpecialRequest;
                            oSubRPL.TXFNumber = oBatchHeader.TXFNumber;
                            oSubRPL.TXFOn = oBatchHeader.TXFOn;
                            oSubRPL.Confirmed = oBatchHeader.Confirmed;
                            oSubRPL.ConfirmedBy = oBatchHeader.ConfirmedBy;
                            oSubRPL.ConfirmedOn = oBatchHeader.ConfirmedOn;
                            oSubRPL.Posted = oBatchHeader.Posted;
                            oSubRPL.PostedBy = oBatchHeader.PostedBy;
                            oSubRPL.PostedOn = oBatchHeader.PostedOn;

                            oSubRPL.CreatedBy = ConfigHelper.CurrentUserId;
                            oSubRPL.CreatedOn = DateTime.Now;
                            oSubRPL.ModifiedBy = ConfigHelper.CurrentUserId;
                            oSubRPL.ModifiedOn = DateTime.Now;

                            ctx.InvtSubLedgerRPL_Header.Add(oSubRPL);

                            Guid subLedgerHeaderId = oSubRPL.HeaderId;
                            #endregion

                            #region CreateRPLSubLedgerDetail(txNumber_SubLedger, oBatchHeader.HeaderId, subLedgerHeaderId);
                            var batchHeaderId = oBatchHeader.HeaderId;

                            //string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
                            //string[] orderBy = new string[] { "LineNumber" };
                            var oBatchDetails = ctx.InvtBatchRPL_Details.Where(x => x.HeaderId == batchHeaderId).OrderBy(x => x.LineNumber);
                            foreach (var oBDetail in oBatchDetails)
                            {
                                var oSubLedgerDetail = new EF6.InvtSubLedgerRPL_Details();
                                oSubLedgerDetail.DetailsId = Guid.NewGuid();
                                oSubLedgerDetail.HeaderId = subLedgerHeaderId;
                                oSubLedgerDetail.LineNumber = oBDetail.LineNumber;
                                oSubLedgerDetail.ProductId = oBDetail.ProductId.Value;
                                oSubLedgerDetail.TxNumber = txnumber;
                                oSubLedgerDetail.QtyIssued = oBDetail.QtyIssued.Value;
                                oSubLedgerDetail.QtyRequested = oBDetail.QtyRequested.Value;
                                oSubLedgerDetail.Remarks = oBDetail.Remarks;

                                ctx.InvtSubLedgerRPL_Details.Add(oSubLedgerDetail);
                            }
                            #endregion

                            if (IsConsolidation)
                            {
                                result[0] = oBatchHeader.HeaderId.ToString();
                                result[1] = oBatchHeader.TxNumber;
                            }
                            else
                            {
                                // Created Transfer Record
                                #region string txfNumber = CreateTXFBatchHeader(oBatchHeader);
                                var oHeader = new EF6.InvtBatchTXF_Header();
                                oHeader.HeaderId = Guid.NewGuid();
                                oHeader.TxNumber = SystemInfoHelper.Settings.QueuingTxNumber(EnumHelper.TxType.TXF);
                                oHeader.TxType = EnumHelper.TxType.TXF.ToString();

                                oHeader.Status = (int)EnumHelper.Status.Active;

                                oHeader.FromLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(oBatchHeader.FromLocation);
                                oHeader.ToLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(oBatchHeader.ToLocation);
                                oHeader.StaffId = oBatchHeader.StaffId;
                                oHeader.TxDate = oBatchHeader.TxDate;
                                oHeader.TransferredOn = oBatchHeader.TXFOn;
                                oHeader.CompletedOn = oBatchHeader.CompletedOn;
                                oHeader.Remarks = "REPLENISH";
                                oHeader.Reference = oBatchHeader.TxNumber;
                                oHeader.ReadOnly = true;

                                oHeader.CreatedBy = ConfigHelper.CurrentUserId;
                                oHeader.CreatedOn = DateTime.Now;

                                oHeader.ModifiedBy = oBatchHeader.ModifiedBy;
                                oHeader.ModifiedOn = oBatchHeader.ModifiedOn;

                                ctx.InvtBatchTXF_Header.Add(oHeader);

                                #region CreateTXFBatchDetails(oBatchHeader, oHeader);
                                int iCount = 1;
                                //string sql = "TxNumber = '" + oBatchHeader.TxNumber + "'";
                                //string[] orderBy = new string[] { "LineNumber" };

                                var rplDetailList = ctx.InvtBatchRPL_Details.Where(x => x.TxNumber == txNumber_SubLedger);
                                foreach (var rplDetail in rplDetailList)
                                {
                                    var oDetail = new EF6.InvtBatchTXF_Details();
                                    oDetail.HeaderId = oHeader.HeaderId;
                                    oDetail.TxNumber = oHeader.TxNumber;
                                    oDetail.TxType = oHeader.TxType;
                                    oDetail.LineNumber = iCount;

                                    oDetail.ProductId = rplDetail.ProductId;
                                    oDetail.QtyRequested = rplDetail.QtyRequested;
                                    oDetail.QtyConfirmed = 0;
                                    oDetail.QtyHHT = 0;
                                    oDetail.QtyManualInput = 0;
                                    oDetail.QtyReceived = rplDetail.QtyRequested;
                                    oDetail.Remarks = rplDetail.Remarks;

                                    ctx.InvtBatchTXF_Details.Add(oDetail);

                                    iCount++;
                                }
                                #endregion

                                var txfNumber = oHeader.TxNumber;
                                #endregion

                                #region Update Txfer Number to RPL SubLedger
                                var rplSubLedger = ctx.InvtSubLedgerRPL_Header.Find(subLedgerHeaderId);
                                if (rplSubLedger != null)
                                {
                                    rplSubLedger.TXFNumber = txfNumber;

                                    ctx.SaveChanges();
                                }
                                #endregion

                                // Clear Batch
                                #region ClearBatchTransaction(oBatchHeader);
                                string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
                                var detailList = ctx.InvtBatchRPL_Details.Where(x => x.HeaderId == oBatchHeader.HeaderId);
                                foreach (var detail in detailList)
                                {
                                    ctx.InvtBatchRPL_Details.Remove(detail);
                                }

                                ctx.InvtBatchRPL_Header.Remove(oBatchHeader);
                                #endregion
                            }
                            scope.Commit();
                        }
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
        private void ClearBatchTransaction(InvtBatchRPL_Header oBatchHeader)
        {
            string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
            InvtBatchRPL_DetailsCollection detailList = InvtBatchRPL_Details.LoadCollection(query);
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
        private Guid CreateRPLSubLedgerHeader(string txnumber, InvtBatchRPL_Header oBatchHeader)
        {
            InvtSubLedgerRPL_Header oSubRPL = new InvtSubLedgerRPL_Header();
            oSubRPL.TxNumber = txnumber;
            oSubRPL.TxDate = oBatchHeader.TxDate;
            oSubRPL.FromLocation = oBatchHeader.FromLocation;
            oSubRPL.ToLocation = oBatchHeader.ToLocation;
            oSubRPL.Remarks = oBatchHeader.Remarks + " \t " + oBatchHeader.TxNumber;
            oSubRPL.StaffId = oBatchHeader.StaffId;
            oSubRPL.Status = (int)EnumHelper.Status.Active;
            oSubRPL.CompletedOn = oBatchHeader.CompletedOn;
            oSubRPL.SpecialRequest = oBatchHeader.SpecialRequest;
            oSubRPL.TXFNumber = oBatchHeader.TXFNumber;
            oSubRPL.TXFOn = oBatchHeader.TXFOn;
            oSubRPL.Confirmed = oBatchHeader.Confirmed;
            oSubRPL.ConfirmedBy = oBatchHeader.ConfirmedBy;
            oSubRPL.ConfirmedOn = oBatchHeader.ConfirmedOn;
            oSubRPL.Posted = oBatchHeader.Posted;
            oSubRPL.PostedBy = oBatchHeader.PostedBy;
            oSubRPL.PostedOn = oBatchHeader.PostedOn;

            oSubRPL.CreatedBy = ConfigHelper.CurrentUserId;
            oSubRPL.CreatedOn = DateTime.Now;
            oSubRPL.ModifiedBy = ConfigHelper.CurrentUserId;
            oSubRPL.ModifiedOn = DateTime.Now;

            oSubRPL.Save();

            return oSubRPL.HeaderId;
        }
        
        private void CreateRPLSubLedgerDetail(string txnumber, Guid batchHeaderId, Guid subledgerHeaderId)
        {
            string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
            string[] orderBy = new string[] { "LineNumber" };
            InvtBatchRPL_DetailsCollection oBatchDetails = InvtBatchRPL_Details.LoadCollection(sql, orderBy, true);
            foreach (InvtBatchRPL_Details oBDetail in oBatchDetails)
            {
                InvtSubLedgerRPL_Details oSubLedgerDetail = new InvtSubLedgerRPL_Details();
                oSubLedgerDetail.HeaderId = subledgerHeaderId;
                oSubLedgerDetail.LineNumber = oBDetail.LineNumber;
                oSubLedgerDetail.ProductId = oBDetail.ProductId;
                oSubLedgerDetail.TxNumber = txnumber;
                oSubLedgerDetail.QtyIssued = oBDetail.QtyIssued;
                oSubLedgerDetail.QtyRequested = oBDetail.QtyRequested;
                oSubLedgerDetail.Remarks = oBDetail.Remarks;

                oSubLedgerDetail.Save();
            }
        }
        */
        #endregion

        #region Transfer Records
        /**
        private string CreateTXFBatchHeader(InvtBatchRPL_Header oBatchHeader)
        {
            InvtBatchTXF_Header oHeader = new InvtBatchTXF_Header();

            oHeader.TxNumber = SystemInfoHelper.Settings.QueuingTxNumber(EnumHelper.TxType.TXF);
            oHeader.TxType = EnumHelper.TxType.TXF.ToString();

            oHeader.Status = (int)EnumHelper.Status.Active;

            oHeader.FromLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(oBatchHeader.FromLocation);
            oHeader.ToLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(oBatchHeader.ToLocation);
            oHeader.StaffId = oBatchHeader.StaffId;
            oHeader.TxDate = oBatchHeader.TxDate;
            oHeader.TransferredOn = oBatchHeader.TXFOn;
            oHeader.CompletedOn = oBatchHeader.CompletedOn;
            oHeader.Remarks = "REPLENISH";
            oHeader.Reference = oBatchHeader.TxNumber;
            oHeader.ReadOnly = true;

            oHeader.CreatedBy = ConfigHelper.CurrentUserId;
            oHeader.CreatedOn = DateTime.Now;

            oHeader.ModifiedBy = oBatchHeader.ModifiedBy;
            oHeader.ModifiedOn = oBatchHeader.ModifiedOn;

            oHeader.Save();

            CreateTXFBatchDetails(oBatchHeader, oHeader);

            return oHeader.TxNumber;
        }
        
        private void CreateTXFBatchDetails(InvtBatchRPL_Header oBatchHeader, InvtBatchTXF_Header txfHeader)
        {
            int iCount = 1;
            string sql = "TxNumber = '" + oBatchHeader.TxNumber + "'";
            string[] orderBy = new string[] { "LineNumber" };
            InvtBatchRPL_DetailsCollection rplDetailList = InvtBatchRPL_Details.LoadCollection(sql, orderBy, true);
            foreach (InvtBatchRPL_Details rplDetail in rplDetailList)
            {
                InvtBatchTXF_Details oDetail = new InvtBatchTXF_Details();
                oDetail.HeaderId = txfHeader.HeaderId;
                oDetail.TxNumber = txfHeader.TxNumber;
                oDetail.TxType = txfHeader.TxType;
                oDetail.LineNumber = iCount;

                oDetail.ProductId = rplDetail.ProductId;
                oDetail.QtyRequested = rplDetail.QtyRequested;
                oDetail.QtyConfirmed = 0;
                oDetail.QtyHHT = 0;
                oDetail.QtyManualInput = 0;
                oDetail.QtyReceived = rplDetail.QtyRequested;
                oDetail.Remarks = rplDetail.Remarks;
                oDetail.Save();

                iCount++;
            }
        }
        */
        #endregion

        #region Consolidate

        #region Checking

        private bool ConsolidateChecking(Guid headerId)
        {
            bool isPostable = true;
            string message = string.Empty;

            if (oTable == null)
            {
                oTable = ErrorMessageTable();
            }

            var oBatchHeader = ModelEx.InvtBatchRPL_HeaderEx.Get(headerId);
            if (oBatchHeader != null)
            {
                if (dtpTxDate.Value == null || dtpTxDate.Value.Year <= 1900)
                {
                    message = "Transaction date CANNOT be blank!";
                    errorProvider.SetError(dtpTxDate, message);

                    DataRow row = oTable.NewRow();
                    row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                    row["TxNumber"] = oBatchHeader.TxNumber;
                    row["STKCODE"] = string.Empty;
                    row["APPENDIX1"] = string.Empty;
                    row["APPENDIX2"] = string.Empty;
                    row["APPENDIX3"] = string.Empty;
                    row["ErrorReason"] = "[Consolidate]: " + message;
                    row["PostDate"] = DateTime.Now;

                    oTable.Rows.Add(row);

                    isPostable = isPostable & false;
                }
                else
                {
                    errorProvider.SetError(dtpTxDate, string.Empty);
                }

                if (dtpTxferDate.Value.ToString("yyyy-MM-dd").CompareTo(DateTime.Now.ToString("yyyy-MM-dd")) < 0)
                {
                    message = "Transfer date CANNOT be earlier than today!";
                    errorProvider.SetError(dtpTxferDate, message);

                    DataRow row = oTable.NewRow();
                    row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                    row["TxNumber"] = oBatchHeader.TxNumber;
                    row["STKCODE"] = string.Empty;
                    row["APPENDIX1"] = string.Empty;
                    row["APPENDIX2"] = string.Empty;
                    row["APPENDIX3"] = string.Empty;
                    row["ErrorReason"] = "[Consolidate]: " + message;
                    row["PostDate"] = DateTime.Now;

                    oTable.Rows.Add(row);

                    isPostable = isPostable & false;
                }
                else
                {
                    errorProvider.SetError(dtpTxferDate, string.Empty);
                }

                if (dtpCompletedDate.Value.ToString("yyyy-MM-dd").CompareTo(dtpTxferDate.Value.ToString("yyyy-MM-dd")) < 0)
                {
                    message = "Completion date CANNOT be earlier than transfer date!";
                    errorProvider.SetError(dtpCompletedDate, message);

                    DataRow row = oTable.NewRow();
                    row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                    row["TxNumber"] = oBatchHeader.TxNumber;
                    row["STKCODE"] = string.Empty;
                    row["APPENDIX1"] = string.Empty;
                    row["APPENDIX2"] = string.Empty;
                    row["APPENDIX3"] = string.Empty;
                    row["ErrorReason"] = "[Consolidate]: " + message;
                    row["PostDate"] = DateTime.Now;

                    oTable.Rows.Add(row);

                    isPostable = isPostable & false;
                }
                else
                {
                    errorProvider.SetError(dtpCompletedDate, string.Empty);
                }

                if (cboStaff.SelectedValue == null)
                {
                    message = "Staff CANNOT be blank!";
                    errorProvider.SetError(cboStaff, message);

                    DataRow row = oTable.NewRow();
                    row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                    row["TxNumber"] = oBatchHeader.TxNumber;
                    row["STKCODE"] = string.Empty;
                    row["APPENDIX1"] = string.Empty;
                    row["APPENDIX2"] = string.Empty;
                    row["APPENDIX3"] = string.Empty;
                    row["ErrorReason"] = "[Consolidate]: " + message;
                    row["PostDate"] = DateTime.Now;

                    oTable.Rows.Add(row);

                    isPostable = isPostable & false;
                }
                else
                {
                    var staff = ModelEx.StaffEx.GetByStaffId((Guid)cboStaff.SelectedValue);
                    if (staff != null)
                    {
                        if (staff.Retired)
                        {
                            message = "Staff was retired!";
                            errorProvider.SetError(cboStaff, message);

                            DataRow row = oTable.NewRow();
                            row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                            row["TxNumber"] = oBatchHeader.TxNumber;
                            row["STKCODE"] = string.Empty;
                            row["APPENDIX1"] = string.Empty;
                            row["APPENDIX2"] = string.Empty;
                            row["APPENDIX3"] = string.Empty;
                            row["ErrorReason"] = "[Consolidate]: " + message;
                            row["PostDate"] = DateTime.Now;

                            oTable.Rows.Add(row);

                            isPostable = isPostable & false;
                        }
                        else
                        {
                            errorProvider.SetError(cboStaff, string.Empty);
                        }
                    }
                    else
                    {
                        message = "Staff DOES NOT exist!";
                        errorProvider.SetError(cboStaff, message);

                        DataRow row = oTable.NewRow();
                        row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                        row["TxNumber"] = oBatchHeader.TxNumber;
                        row["STKCODE"] = string.Empty;
                        row["APPENDIX1"] = string.Empty;
                        row["APPENDIX2"] = string.Empty;
                        row["APPENDIX3"] = string.Empty;
                        row["ErrorReason"] = "[Consolidate]: " + message;
                        row["PostDate"] = DateTime.Now;

                        oTable.Rows.Add(row);

                        isPostable = isPostable & false;
                    }
                }
            }
            else
            {
                DataRow row = oTable.NewRow();
                row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                row["TxNumber"] = oBatchHeader.TxNumber;
                row["STKCODE"] = string.Empty;
                row["APPENDIX1"] = string.Empty;
                row["APPENDIX2"] = string.Empty;
                row["APPENDIX3"] = string.Empty;
                row["ErrorReason"] = "[Consolidate]: Transaction does not exist!";
                row["PostDate"] = DateTime.Now;

                oTable.Rows.Add(row);

                return false;
            }

            return isPostable;
        }

        #endregion

        // Consolidate all of the marked RPL transaction into one txfer transaction
        private int ConsolidateRPL()
        {
            List<string> consolidatedList = new List<string>();
            string consolidatedTxNumber = string.Empty;
            string fromLoc = string.Empty, toLoc = string.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        #region loop thro lvItem
                        foreach (ListViewItem lvItem in lvPostTxList.Items)
                        {
                            Guid headerId = Guid.Empty;

                            if (Guid.TryParse(lvItem.Text, out headerId) && lvItem.Checked)
                            {
                                if (ConsolidateChecking(headerId))
                                {
                                    string[] result = CreateRPLTx(lvItem, true);
                                    consolidatedList.Add(result[0]);
                                    consolidatedTxNumber += result[1] + ";";

                                    fromLoc = lvItem.SubItems[4].Text;
                                    toLoc = lvItem.SubItems[5].Text;

                                    lvItem.SubItems[1].Text = new IconResourceHandle("16x16.16_succeeded.png").ToString();
                                }
                                else
                                {
                                    postStatus = RT2020.Controls.InvtUtility.PostingStatus.Error;
                                    lvItem.SubItems[1].Text = new IconResourceHandle("16x16.16_error.gif").ToString();
                                }
                            }
                        }
                        #endregion

                        if (consolidatedList.Count > 0)
                        {
                            string txNumber = SystemInfoHelper.Settings.QueuingTxNumber(EnumHelper.TxType.TXF);
                            var headerId = Guid.Empty;
                            #region Guid headerId = ConsolidatedTXFBatchHeader(txNumber, fromLoc, toLoc, consolidatedTxNumber);
                            var fromLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(fromLoc);
                            var toLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(toLoc);
                            var staffId = Guid.Empty;
                            if (Guid.TryParse(cboStaff.SelectedValue.ToString(), out staffId) && fromLocation != Guid.Empty && toLocation != Guid.Empty)
                            {
                                var oHeader = new EF6.InvtBatchTXF_Header();
                                oHeader.HeaderId = Guid.NewGuid();
                                oHeader.TxNumber = txNumber;
                                oHeader.TxType = EnumHelper.TxType.TXF.ToString();

                                oHeader.Status = (int)EnumHelper.Status.Active;

                                oHeader.FromLocation = fromLocation;
                                oHeader.ToLocation = toLocation;
                                oHeader.StaffId = staffId;
                                oHeader.TxDate = dtpTxDate.Value;
                                oHeader.TransferredOn = dtpTxferDate.Value;
                                oHeader.CompletedOn = dtpCompletedDate.Value;
                                oHeader.Remarks = "RPL: " + ((consolidatedTxNumber.Length <= (100 - 4)) ? consolidatedTxNumber : consolidatedTxNumber.Substring(0, (100 - 4 - 3)) + "...");
                                oHeader.Reference = string.Empty;
                                oHeader.ReadOnly = true;

                                oHeader.CreatedBy = ConfigHelper.CurrentUserId;
                                oHeader.CreatedOn = DateTime.Now;

                                oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                                oHeader.ModifiedOn = DateTime.Now;

                                ctx.InvtBatchTXF_Header.Add(oHeader);
                                ctx.SaveChanges();

                                headerId = oHeader.HeaderId;
                            }
                            #endregion

                            if (headerId != Guid.Empty)
                            {
                                foreach (string consolidatedId in consolidatedList)
                                {
                                    Guid rplHeaderId = Guid.Empty;
                                    if (Guid.TryParse(consolidatedId, out rplHeaderId))
                                    {
                                        #region ConsolidatedTXFBatchDetails(consolidatedId, headerId, txNumber);
                                        Guid txfHeaderId = headerId;
                                        string txfTxNumber = txNumber;
                                        //string sql = "HeaderId = '" + rplHeaderId + "'";
                                        //string[] orderBy = new string[] { "LineNumber" };
                                        var rplDetailList = ctx.InvtBatchRPL_Details.Where(x => x.HeaderId == rplHeaderId);
                                        foreach (var rplDetail in rplDetailList)
                                        {
                                            //sql = "HeaderId = '" + txfHeaderId + "' AND ProductId = '" + rplDetail.ProductId.ToString() + "'";
                                            var oDetail = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == txfHeaderId && x.ProductId == rplDetail.ProductId).FirstOrDefault();
                                            if (oDetail == null)
                                            {
                                                oDetail = new EF6.InvtBatchTXF_Details();
                                                oDetail.DetailsId = Guid.NewGuid();
                                                oDetail.HeaderId = txfHeaderId;
                                                oDetail.TxNumber = txfTxNumber;
                                                oDetail.TxType = EnumHelper.TxType.TXF.ToString();
                                                oDetail.LineNumber = 1;
                                                oDetail.ProductId = rplDetail.ProductId;

                                                ctx.InvtBatchTXF_Details.Add(oDetail);
                                            }

                                            oDetail.QtyRequested += rplDetail.QtyRequested;
                                            oDetail.QtyConfirmed = 0;
                                            oDetail.QtyHHT = 0;
                                            oDetail.QtyManualInput = 0;
                                            oDetail.QtyReceived += rplDetail.QtyRequested;
                                            oDetail.Remarks = txtItemRemarks.Text;

                                            ctx.SaveChanges();
                                        }
                                        #endregion

                                        #region Update Txfer Number to RPL SubLedger
                                        var oBatchHeader = ctx.InvtBatchRPL_Header.Find(new Guid(consolidatedId));
                                        if (oBatchHeader != null)
                                        {
                                            var rplSubLedger = ctx.InvtSubLedgerRPL_Header.Where(x => x.TxNumber == oBatchHeader.TxNumber + "'").FirstOrDefault();
                                            if (rplSubLedger != null)
                                            {
                                                rplSubLedger.TXFNumber = txNumber;
                                                rplSubLedger.TXFOn = dtpTxferDate.Value;

                                                ctx.SaveChanges();
                                            }

                                            // Clear Batch
                                            #region ClearBatchTransaction(oBatchHeader);
                                            //string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
                                            var detailList = ctx.InvtBatchRPL_Details.Where(x => x.HeaderId == oBatchHeader.HeaderId);
                                            foreach (var detail in detailList)
                                            {
                                                ctx.InvtBatchRPL_Details.Remove(detail);
                                            }

                                            ctx.InvtBatchRPL_Header.Remove(oBatchHeader);
                                            #endregion
                                        }
                                        #endregion
                                    }
                                }

                                #region UpdateLineNumbersInTXFBatchDetails(headerId);
                                int iCount = 1;
                                //string sql = "HeaderId = '" + txfHeaderId + "'";
                                var oDetailList = ctx.InvtBatchTXF_Details.Where(x => x.HeaderId == headerId);
                                foreach (var oDetail in oDetailList)
                                {
                                    oDetail.LineNumber = iCount;
                                    ctx.SaveChanges();

                                    iCount++;
                                }
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

            return consolidatedList.Count;
        }
        /**
        private Guid ConsolidatedTXFBatchHeader(string txNumber, string fromLoc, string toLoc, string consolidatedTxNumber)
        {
            System.Guid fromLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(fromLoc);
            System.Guid toLocation = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(toLoc);

            if (Common.Utility.IsGUID(cboStaff.SelectedValue.ToString()) && fromLocation != System.Guid.Empty && toLocation != System.Guid.Empty)
            {
                InvtBatchTXF_Header oHeader = new InvtBatchTXF_Header();

                oHeader.TxNumber = txNumber;
                oHeader.TxType = EnumHelper.TxType.TXF.ToString();

                oHeader.Status = (int)EnumHelper.Status.Active;

                oHeader.FromLocation = fromLocation;
                oHeader.ToLocation = toLocation;
                oHeader.StaffId = new Guid(cboStaff.SelectedValue.ToString());
                oHeader.TxDate = dtpTxDate.Value;
                oHeader.TransferredOn = dtpTxferDate.Value;
                oHeader.CompletedOn = dtpCompletedDate.Value;
                oHeader.Remarks = "RPL: " + ((consolidatedTxNumber.Length <= (100 - 4)) ? consolidatedTxNumber : consolidatedTxNumber.Substring(0, (100 - 4 - 3)) + "...");
                oHeader.Reference = string.Empty;
                oHeader.ReadOnly = true;

                oHeader.CreatedBy = ConfigHelper.CurrentUserId;
                oHeader.CreatedOn = DateTime.Now;

                oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                oHeader.ModifiedOn = DateTime.Now;

                oHeader.Save();

                return oHeader.HeaderId;
            }

            return System.Guid.Empty;
        }
        
        private void ConsolidatedTXFBatchDetails(string rplHeaderId, System.Guid txfHeaderId, string txfTxNumber)
        {
            string sql = "HeaderId = '" + rplHeaderId + "'";
            string[] orderBy = new string[] { "LineNumber" };
            InvtBatchRPL_DetailsCollection rplDetailList = InvtBatchRPL_Details.LoadCollection(sql, orderBy, true);
            foreach (InvtBatchRPL_Details rplDetail in rplDetailList)
            {
                sql = "HeaderId = '" + txfHeaderId + "' AND ProductId = '" + rplDetail.ProductId.ToString() + "'";
                InvtBatchTXF_Details oDetail = InvtBatchTXF_Details.LoadWhere(sql);
                if (oDetail == null)
                {
                    oDetail = new InvtBatchTXF_Details();
                    oDetail.HeaderId = txfHeaderId;
                    oDetail.TxNumber = txfTxNumber;
                    oDetail.TxType = EnumHelper.TxType.TXF.ToString();
                    oDetail.LineNumber = 1;
                    oDetail.ProductId = rplDetail.ProductId;
                }

                oDetail.QtyRequested += rplDetail.QtyRequested;
                oDetail.QtyConfirmed = 0;
                oDetail.QtyHHT = 0;
                oDetail.QtyManualInput = 0;
                oDetail.QtyReceived += rplDetail.QtyRequested;
                oDetail.Remarks = txtItemRemarks.Text;
                oDetail.Save();
            }
        }
        
        private void UpdateLineNumbersInTXFBatchDetails(System.Guid txfHeaderId)
        {
            int iCount = 1;
            string sql = "HeaderId = '" + txfHeaderId + "'";
            InvtBatchTXF_DetailsCollection oDetailList = InvtBatchTXF_Details.LoadCollection(sql);
            foreach (InvtBatchTXF_Details oDetail in oDetailList)
            {
                oDetail.LineNumber = iCount;
                oDetail.Save();

                iCount++;
            }
        }
        */
        #endregion

        #endregion

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
            MessageBox.Show("Confirm Proceed?", "Confirm Posting", MessageBoxButtons.OK, new EventHandler(ConfirmPostingMessageHandler));
        }

        private void ConfirmPostingMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                if (lvPostTxList.CheckedItems.Count > 0)
                {
                    SelectedColumnsCounting();

                    int result = CreateRPLTx();
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
                lvPostTxList.Items[e.Index].Checked = !(lvPostTxList.Items[e.Index].BackColor == SystemInfoHelper.ControlBackColor.DisabledBox);
            }
        }
    }
}