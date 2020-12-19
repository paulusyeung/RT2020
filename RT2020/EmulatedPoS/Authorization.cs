#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Text.RegularExpressions;
using Gizmox.WebGUI.Common.Resources;


using System.Configuration;
using RT2020.Helper;

#endregion

namespace RT2020.EmulatedPoS
{
    public partial class Authorization : Form
    {
        public EnumHelper.TxType SalesType { get; set; }
        private RT2020.Controls.InvtUtility.PostingStatus postStatus = RT2020.Controls.InvtUtility.PostingStatus.Ready;
        DataTable oTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization"/> class.
        /// </summary>
        public Authorization(EnumHelper.TxType salesType)
        {
            InitializeComponent();
            InitComboBox();

            this.SalesType = salesType;

            BindingList(EnumHelper.Status.Active); // Posting
            BindingList(EnumHelper.Status.Draft); // Holding
        }

        /// <summary>
        /// Inits the combo box.
        /// </summary>
        private void InitComboBox()
        {
            txtPostedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, true);
            lblSysMonth.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth;
            lblSysYear.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear;

            cboFieldName.SelectedIndex = 0;
            cboOperator.SelectedIndex = 0;
            cboOrdering.SelectedIndex = 0;
        }

        #region Bind Methods
        /// <summary>
        /// Datas the source.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="conditions">if set to <c>true</c> [conditions].</param>
        /// <returns></returns>
        private SqlDataReader DataSource(string status, bool conditions)
        {
            string sql = BuildSqlQueryString(status, conditions);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                return reader;
            }
        }

        /// <summary>
        /// Bindings the list.
        /// </summary>
        /// <param name="status">The status.</param>
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

        /// <summary>
        /// Bindings the holding list.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void BindingHoldingList(SqlDataReader reader)
        {
            lvHoldTransaction.Items.Clear();

            while (reader.Read())
            {
                ListViewItem objItem = this.lvHoldTransaction.Items.Add(reader.GetGuid(0).ToString()); // HeaderId
                objItem.SubItems.Add(string.Empty);
                objItem.SubItems.Add(reader.GetString(1)); // TxNumber
                objItem.SubItems.Add(reader.GetString(2)); // Type
                objItem.SubItems.Add(reader.GetDecimal(4).ToString("n2")); // Total Amount
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(5), false)); // ModifiedOn
            }

            reader.Close();
        }

        /// <summary>
        /// Bindings the posting list.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void BindingPostingList(SqlDataReader reader)
        {
            lvPostTransaction.CheckBoxes = true;
            lvPostTransaction.Items.Clear();

            while (reader.Read())
            {
                ListViewItem objItem = this.lvPostTransaction.Items.Add(reader.GetGuid(0).ToString()); // HeaderId
                objItem.SubItems.Add(string.Empty);
                objItem.SubItems.Add(reader.GetString(1)); // TxNumber
                objItem.SubItems.Add(reader.GetString(2)); // Type
                objItem.SubItems.Add(reader.GetDecimal(4).ToString("n2")); // Total Amount
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // TxDate
                objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(5), false)); // ModifiedOn
                objItem.BackColor = CheckTxDate(reader.GetDateTime(3)) ? Color.Transparent : RT2020.SystemInfo.ControlBackColor.DisabledBox;
            }

            reader.Close();
        }

        /// <summary>
        /// Bindings the posting result.
        /// </summary>
        /// <param name="objItem">The obj item.</param>
        private void BindingPostingResult(ListViewItem objItem)
        {                
            ListViewItem oItem = lvPostingResult.Items.Add(objItem.Text);
            oItem.SubItems.Add(new IconResourceHandle("16x16.16_succeeded.png").ToString());
            oItem.SubItems.Add(objItem.SubItems[2].Text);//TxNumber
            var detailList = ModelEx.EPOSBatchDetailsEx.GetList("HeaderId = '" + objItem.Text + "'");
            foreach (var detail in detailList)
            {
                var oProduct = ModelEx.ProductEx.Get(detail.ProductId);
                if (oProduct != null)
                {
                    oItem.SubItems.Add(oProduct.STKCODE);//StkCode(STYLE)
                    oItem.SubItems.Add(oProduct.APPENDIX1);//APPENDIX1(FABRICS)
                    oItem.SubItems.Add(oProduct.APPENDIX2);//APPENDIX2(COLOR)
                    oItem.SubItems.Add(oProduct.APPENDIX3);//APPENDIX3(SIZE)
                    oItem.SubItems.Add(string.Empty);//Reason
                }
            }              
        }

        /// <summary>
        /// Bindings the posting result.
        /// </summary>
        private void BindingPostingResult()
        {
            for (int i = 0; i < oTable.Rows.Count; i++)
            {
                ListViewItem oItem = lvPostingResult.Items.Add(oTable.Rows[i][0].ToString());
                oItem.SubItems.Add(new IconResourceHandle("16x16.16_error.gif").ToString());
                oItem.SubItems.Add(oTable.Rows[i][1].ToString());//TxNumber
                oItem.SubItems.Add(oTable.Rows[i][2].ToString());//StkCode(STYLE)
                oItem.SubItems.Add(oTable.Rows[i][3].ToString());//APPENDIX1(FABRICS)
                oItem.SubItems.Add(oTable.Rows[i][4].ToString());//APPENDIX2(COLOR)
                oItem.SubItems.Add(oTable.Rows[i][5].ToString());//APPENDIX3(SIZE)
                oItem.SubItems.Add(oTable.Rows[i][6].ToString());//Reason                
            }
        }

        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="withConditions">if set to <c>true</c> [with conditions].</param>
        /// <returns></returns>
        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT HeaderId, TxNumber, TxType, TxDate, TotalAmount, ModifiedOn, ModifiedBy ");
            sql.Append(" FROM [dbo].[EPOSBatchHeader] ");
            sql.Append(" WHERE STATUS = ").Append(status).Append(" AND TxType = '" + this.SalesType.ToString() + "'");

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

        /// <summary>
        /// Columns the name.
        /// </summary>
        /// <returns></returns>
        private string ColumnName()
        {
            string colName = string.Empty;
            switch (cboFieldName.Text)
            {
                case "Type":
                    colName = "TxType";
                    break;
                case "Total Amount":
                    colName = "TotalAmount";
                    break;
                case "Receive Date (dd/MM/yyyy)":
                    colName = "TxDate";
                    break;
                case "LastUpdate(dd/MM/yyyy)":
                    colName = "ModifiedOn";
                    break;
                default:
                case "Trn#":
                    colName = "TxNumber";
                    break;
            }
            return colName;
        }

        /// <summary>
        /// Verifies the date.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Formats the date.
        /// </summary>
        private void FormatDate()
        {
            string[] dateValue = txtData.Text.Split('/');
            txtData.Tag = dateValue[2] + "-" + dateValue[1] + "-" + dateValue[0];
        }
        #endregion

        #region Verify
        /// <summary>
        /// Errors the message table.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Selecteds the columns counting.
        /// </summary>
        /// <returns></returns>
        private int SelectedColumnsCounting()
        {
            int iCount = 0;
            oTable = ErrorMessageTable();

            foreach (ListViewItem objItem in lvPostTransaction.Items)
            {
                Guid headerId = Guid.Empty;
                if (objItem.Checked && Guid.TryParse(objItem.Text, out headerId))
                {
                    if (!IsPostable(headerId, ref oTable))
                    {
                        objItem.SubItems[1].Text = new IconResourceHandle("16x16.16_error.gif").ToString();
                        postStatus = RT2020.Controls.InvtUtility.PostingStatus.Error;
                    }

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

        /// <summary>
        /// Determines whether the specified header id is postable.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        /// <param name="errorTable">The error table.</param>
        /// <returns>
        /// 	<c>true</c> if the specified header id is postable; otherwise, <c>false</c>.
        /// </returns>
        private bool IsPostable(Guid headerId, ref DataTable errorTable)
        {
            bool isPostable = true;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oBatchHeader = ctx.EPOSBatchHeader.Find(headerId);
                if (oBatchHeader != null)
                {
                    if (!CheckTxDate(oBatchHeader.TxDate.Value))
                    {
                        #region errorTable add row
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
                        #endregion
                    }

                    if (oBatchHeader.Posted.Value)
                    {
                        #region errorTable add row
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
                        #endregion
                    }

                    var detailList = ctx.EPOSBatchDetails.Where(x => x.HeaderId == oBatchHeader.HeaderId).ToList();
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
                            #region errorTable add row
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
                            #endregion
                        }
                    }

                    var oLedger = ctx.PosLedgerHeader.Where(x => x.TxNumber == oBatchHeader.TxNumber && x.TxType == this.SalesType.ToString()).FirstOrDefault();
                    if (oLedger != null)
                    {
                        #region errorTable add row
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
                        #endregion
                    }
                }
                else
                {
                    return false;
                }
            }
            return isPostable;
        }

        /// <summary>
        /// Checks the tx date.
        /// </summary>
        /// <param name="txDate">The tx date.</param>
        /// <returns></returns>
        private bool CheckTxDate(DateTime txDate)
        {
            bool isChecked = false;

            isChecked = (txDate.Year.ToString() == RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear);
            isChecked = isChecked & (txDate.Month.ToString().PadLeft(2, '0') == RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth);

            return isChecked;
        }

        /// <summary>
        /// Determines whether the specified header id has error.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        /// <returns>
        /// 	<c>true</c> if the specified header id has error; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        /// Creates the pos tx.
        /// </summary>
        /// <returns></returns>
        private int CreatePosTx()
        {
            int iCount = 0;
            if (lvPostTransaction.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvPostTransaction.CheckedItems)
                {
                    Guid headerId = Guid.Empty;
                    if (Guid.TryParse(oItem.Text, out headerId) && oItem.Checked)
                    {
                        if (!HasError(oItem.Text))
                        {
                            colMark.Visible = true;
                            oItem.SubItems[1].Text = new IconResourceHandle("16x16.16_succeeded.png").ToString();

                            BindingPostingResult(oItem);

                            if (chkCheckQty.Visible)// option check qty
                            {
                                if (CheckQty(headerId))
                                {
                                    CreatePosTx(headerId, ref iCount);
                                }
                                else
                                {
                                    MessageBox.Show("Qty > CDQty. The item cannot be posting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                CreatePosTx(new Guid(oItem.Text), ref iCount);
                            }
                        }
                        else
                        {
                            BindingPostingResult();
                        }
                    }
                }
            }
            return iCount;
        }

        /// <summary>
        /// Creates the pos tx.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        /// <param name="iCount">The i count.</param>
        private void CreatePosTx(Guid headerId, ref int iCount)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oBatchHeader = ctx.EPOSBatchHeader.Find(headerId);
                        if (oBatchHeader != null)
                        {
                            Guid txHeaderId = oBatchHeader.HeaderId;
                            Guid workplaceId = oBatchHeader.WorkplaceId;
                            string txType = oBatchHeader.TxType;

                            #region UpdateProduct(oBatchHeader.HeaderId, oBatchHeader.WorkplaceId, oBatchHeader.TxType);
                            var detailsList = ctx.EPOSBatchDetails.Where(x => x.HeaderId == txHeaderId);
                            foreach (var detail in detailsList)
                            {
                                Guid productId = detail.ProductId;
                                decimal qty = detail.Qty.Value;

                                #region UpdateProductQty(detail.ProductId, workplaceId, detail.Qty, txType);
                                var item = ctx.ProductWorkplace.Where(x => x.ProductId == productId && x.WorkplaceId == workplaceId).FirstOrDefault();
                                if (item == null)
                                {
                                    item = new EF6.ProductWorkplace();
                                    item.ProductWorkplaceId = Guid.NewGuid();
                                    item.ProductId = productId;
                                    item.WorkplaceId = workplaceId;
                                    ctx.ProductWorkplace.Add(item);
                                }
                                if (txType == "CAS")
                                {
                                    item.CDQTY -= qty;
                                }
                                else
                                {
                                    item.CDQTY += qty;
                                }
                                ctx.SaveChanges();
                                #endregion

                                #region UpdateProductSummary(detail.ProductId, detail.Qty, detail.UnitAmount, txType);
                                var oSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oSummary == null)
                                {
                                    oSummary = new EF6.ProductCurrentSummary();
                                    oSummary.CurrentSummaryId = Guid.NewGuid();
                                    oSummary.ProductId = productId;
                                    //oSummary.AverageCost = unitAmount;

                                    ctx.ProductCurrentSummary.Add(oSummary);
                                }

                                if (txType == "CAS")
                                {
                                    oSummary.CDQTY -= qty;
                                }
                                else
                                {
                                    oSummary.CDQTY += qty;
                                }
                                ctx.SaveChanges();
                                #endregion
                            }
                            #endregion

                            // Create CAP SubLedger
                            string txNumber_SubLedger = oBatchHeader.TxNumber;

                            #region Guid subLedgerHeaderId = CreateEPOSSubLedgerHeader(oBatchHeader);
                            var oSubHeader = new EF6.EPOSSubLedgerHeader();
                            oSubHeader.HeaderId = Guid.NewGuid();
                            oSubHeader.TxNumber = oBatchHeader.TxNumber;
                            oSubHeader.TxType = oBatchHeader.TxType;
                            oSubHeader.TxDate = oBatchHeader.TxDate.Value;
                            oSubHeader.TotalAmount = oBatchHeader.TotalAmount.Value;
                            oSubHeader.DepositAmount = oBatchHeader.DepositAmount.Value;

                            oSubHeader.StaffId = oBatchHeader.StaffId;
                            oSubHeader.Staff1 = oBatchHeader.Staff1.Value;
                            oSubHeader.Staff2 = oBatchHeader.Staff2.Value;
                            oSubHeader.WorkplaceId = oBatchHeader.WorkplaceId;
                            oSubHeader.VsLocationId = oBatchHeader.VsLocationId.Value;
                            oSubHeader.MemberId = oBatchHeader.MemberId.Value;
                            oSubHeader.Reference = oBatchHeader.Reference;
                            oSubHeader.Remarks = oBatchHeader.Remarks;
                            oSubHeader.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                            oSubHeader.SEX = oBatchHeader.SEX;
                            oSubHeader.RACE = oBatchHeader.RACE;
                            oSubHeader.EVT_CODE = oBatchHeader.EVT_CODE;
                            oSubHeader.PRICE_TYPE = oBatchHeader.PRICE_TYPE;
                            oSubHeader.CurrencyCode = oBatchHeader.CurrencyCode;
                            oSubHeader.ExchangeRate = oBatchHeader.ExchangeRate.Value;
                            oSubHeader.ANALYSIS_CODE01 = oBatchHeader.ANALYSIS_CODE01;
                            oSubHeader.ANALYSIS_CODE02 = oBatchHeader.ANALYSIS_CODE02;
                            oSubHeader.ANALYSIS_CODE03 = oBatchHeader.ANALYSIS_CODE03;
                            oSubHeader.ANALYSIS_CODE04 = oBatchHeader.ANALYSIS_CODE04;
                            oSubHeader.ANALYSIS_CODE05 = oBatchHeader.ANALYSIS_CODE05;
                            oSubHeader.ANALYSIS_CODE06 = oBatchHeader.ANALYSIS_CODE06;
                            oSubHeader.ANALYSIS_CODE07 = oBatchHeader.ANALYSIS_CODE07;
                            oSubHeader.ANALYSIS_CODE08 = oBatchHeader.ANALYSIS_CODE08;
                            oSubHeader.ANALYSIS_CODE09 = oBatchHeader.ANALYSIS_CODE09;
                            oSubHeader.ANALYSIS_CODE10 = oBatchHeader.ANALYSIS_CODE10;

                            oSubHeader.CreatedBy = ConfigHelper.CurrentUserId;
                            oSubHeader.CreatedOn = DateTime.Now;
                            oSubHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                            oSubHeader.ModifiedOn = DateTime.Now;
                            oSubHeader.Posted = true;
                            oSubHeader.PostedBy = ConfigHelper.CurrentUserId;
                            oSubHeader.PostedOn = DateTime.Now;

                            ctx.EPOSSubLedgerHeader.Add(oSubHeader);
                            ctx.SaveChanges();

                            var subLedgerHeaderId = oSubHeader.HeaderId;
                            #endregion

                            string txnumber = txNumber_SubLedger;
                            Guid batchHeaderId = oBatchHeader.HeaderId;
                            //Guid subledgerHeaderId = subLedgerHeaderId;

                            #region CreateEPOSSubLedgerDetail(txNumber_SubLedger, oBatchHeader.HeaderId, subLedgerHeaderId);
                            string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
                            string[] orderBy = new string[] { "LineNumber" };
                            var oBatchDetails = ctx.EPOSBatchDetails.Where(x => x.HeaderId == batchHeaderId).OrderBy(x => x.LineNumber);
                            foreach (var oBDetail in oBatchDetails)
                            {
                                var oSubDetail = new EF6.EPOSSubLedgerDetails();
                                oSubDetail.DetailsId = Guid.NewGuid();
                                oSubDetail.HeaderId = subLedgerHeaderId;
                                oSubDetail.TxType = oBDetail.TxType;
                                oSubDetail.TxNumber = txnumber;
                                oSubDetail.TxDate = oBDetail.TxDate;
                                oSubDetail.LineNumber = oBDetail.LineNumber;
                                oSubDetail.ProductId = oBDetail.ProductId;
                                oSubDetail.Qty = oBDetail.Qty;
                                oSubDetail.UnitAmount = oBDetail.UnitAmount;
                                oSubDetail.Discount = oBDetail.Discount;
                                oSubDetail.Amount = oBDetail.Amount;
                                oSubDetail.BARCODE = oBDetail.BARCODE;
                                oSubDetail.SERIALNO = oBDetail.SERIALNO;
                                oSubDetail.VITEM = oBDetail.VITEM;
                                oSubDetail.COUPONNO = oBDetail.COUPONNO;
                                oSubDetail.UAMT_FCURR = oBDetail.UAMT_FCURR;
                                oSubDetail.AMOUNT_FCURR = oBDetail.AMOUNT_FCURR;

                                ctx.EPOSSubLedgerDetails.Add(oSubDetail);
                            }
                            #endregion

                            #region CreateEPOSSubLedgerTender(txNumber_SubLedger, oBatchHeader.HeaderId, subLedgerHeaderId);
                            var oBatchTender = ctx.EPOSBatchTender.Where(x => x.HeaderId == batchHeaderId);
                            foreach (var oBTender in oBatchTender)
                            {
                                var oSubTender = new EF6.EPOSSubLedgerTender();
                                oSubTender.TenderId = Guid.NewGuid();
                                oSubTender.HeaderId = subLedgerHeaderId;
                                oSubTender.TxType = oBTender.TxType;
                                oSubTender.TxNumber = txnumber;
                                oSubTender.TxDate = oBTender.TxDate.Value;
                                oSubTender.TypeId = oBTender.TypeId;
                                oSubTender.CurrencyCode = oBTender.CurrencyCode;
                                oSubTender.CardNumber = oBTender.CardNumber;
                                oSubTender.AuthorizationCode = oBTender.AuthorizationCode;
                                oSubTender.TenderAmount = oBTender.TenderAmount.Value;
                                oSubTender.ExchangeRate = oBTender.ExchangeRate.Value;
                                oSubTender.InLocalCurrency = oBTender.InLocalCurrency.Value;

                                ctx.EPOSSubLedgerTender.Add(oSubTender);
                            }
                            #endregion

                            #region Create Ledger for TxType 'CAP'

                            string txNumber_Ledger = oBatchHeader.TxNumber;
                            //var oBatchHeader = oBatchHeader;
                            //Guid subLedgerHeaderId = subLedgerHeaderId;
                            #region Guid ledgerHeaderId = CreatePosLedgerHeader(oBatchHeader, subLedgerHeaderId);
                            var oLedgerHeader = new EF6.PosLedgerHeader();
                            oLedgerHeader.HeaderId = Guid.NewGuid();
                            oLedgerHeader.TxNumber = oBatchHeader.TxNumber;
                            oLedgerHeader.TxType = oBatchHeader.TxType;
                            oLedgerHeader.TxDate = oBatchHeader.TxDate;
                            oLedgerHeader.TotalAmount = oBatchHeader.TotalAmount;
                            oLedgerHeader.DepositAmount = oBatchHeader.DepositAmount;

                            oLedgerHeader.StaffId = oBatchHeader.StaffId;
                            oLedgerHeader.Staff1 = oBatchHeader.Staff1;
                            oLedgerHeader.Staff2 = oBatchHeader.Staff2;
                            oLedgerHeader.WorkplaceId = oBatchHeader.WorkplaceId;
                            oLedgerHeader.VsLocationId = oBatchHeader.VsLocationId;
                            oLedgerHeader.MemberId = oBatchHeader.MemberId;
                            oLedgerHeader.Reference = oBatchHeader.Reference;
                            oLedgerHeader.Remarks = oBatchHeader.Remarks;
                            oLedgerHeader.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                            oLedgerHeader.SEX = oBatchHeader.SEX;
                            oLedgerHeader.RACE = oBatchHeader.RACE;
                            oLedgerHeader.EVT_CODE = oBatchHeader.EVT_CODE;

                            oLedgerHeader.CreatedBy = ConfigHelper.CurrentUserId;
                            oLedgerHeader.CreatedOn = DateTime.Now;
                            oLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                            oLedgerHeader.ModifiedOn = DateTime.Now;
                            oLedgerHeader.PostedBy = ConfigHelper.CurrentUserId;
                            oLedgerHeader.PostedOn = DateTime.Now;

                            ctx.PosLedgerHeader.Add(oLedgerHeader);

                            var ledgerHeaderId = oLedgerHeader.HeaderId;
                            #endregion

                            txnumber = txNumber_Ledger;
                            //Guid subledgerHeaderId = subLedgerHeaderId;
                            //Guid ledgerHeaderId = ledgerHeaderId;
                            string shop = ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId);
                            string staffNumber = ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.StaffId);

                            #region CreatePosLedgerDetails(txNumber_Ledger, subLedgerHeaderId, ledgerHeaderId, ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId), ModelEx.StaffEx.GetStaffNumberById(oBatchHeader.StaffId));
                            //string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
                            //string[] orderBy = new string[] { "LineNumber" };
                            var oSubDetails = ctx.EPOSSubLedgerDetails.Where(x => x.HeaderId == subLedgerHeaderId).OrderBy(x => x.LineNumber);
                            foreach (var oSDetail in oSubDetails)
                            {
                                var oLedgerDetail = new EF6.PosLedgerDetails();
                                oLedgerDetail.DetailsId = Guid.NewGuid();
                                oLedgerDetail.HeaderId = ledgerHeaderId;
                                oLedgerDetail.TxType = oSDetail.TxType;
                                oLedgerDetail.TxNumber = txnumber;
                                oLedgerDetail.TxDate = oSDetail.TxDate;
                                oLedgerDetail.LineNumber = oSDetail.LineNumber;
                                oLedgerDetail.ProductId = oSDetail.ProductId;
                                oLedgerDetail.Qty = oSDetail.Qty;
                                oLedgerDetail.UnitAmount = oSDetail.UnitAmount;
                                oLedgerDetail.Discount = oSDetail.Discount;
                                oLedgerDetail.Amount = oSDetail.Amount;
                                oLedgerDetail.Barcode = oSDetail.BARCODE;

                                oLedgerDetail.AverageCost = 0;
                                oLedgerDetail.SerialNumber = oSDetail.SERIALNO;
                                oLedgerDetail.VendorItemRef = oSDetail.VITEM;
                                oLedgerDetail.CouponNumber = oSDetail.COUPONNO;

                                oLedgerDetail.SHOP = shop;
                                oLedgerDetail.OPERATOR = staffNumber;

                                // Product Info
                                var oItem = ModelEx.ProductEx.Get(oSDetail.ProductId);
                                if (oItem != null)
                                {
                                    oLedgerDetail.BasicPrice = oItem.RetailPrice.Value;
                                    //oLedgerDetail.Discount = oItem.NormalDiscount;
                                    oLedgerDetail.AverageCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);
                                }

                                ctx.PosLedgerDetails.Add(oLedgerDetail);
                            }
                            #endregion

                            //string txnumber, Guid subledgerHeaderId, Guid ledgerHeaderId
                            #region CreatePosLedgerTender(txNumber_Ledger, subLedgerHeaderId, ledgerHeaderId);
                            //string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
                            var oSubTenders = ctx.EPOSSubLedgerTender.Where(x => x.HeaderId == subLedgerHeaderId);
                            foreach (var oSTender in oSubTenders)
                            {
                                var oLedgerTender = new EF6.PosLedgerTender();
                                oLedgerTender.TenderId = Guid.NewGuid();
                                oLedgerTender.HeaderId = ledgerHeaderId;
                                oLedgerTender.TxType = oSTender.TxType;
                                oLedgerTender.TxNumber = txnumber;
                                oLedgerTender.TxDate = oSTender.TxDate;
                                oLedgerTender.TypeId = oSTender.TypeId;
                                oLedgerTender.CurrencyCode = oSTender.CurrencyCode;
                                oLedgerTender.CardNumber = oSTender.CardNumber;
                                oLedgerTender.AuthorizationCode = oSTender.AuthorizationCode;
                                oLedgerTender.TenderAmount = oSTender.TenderAmount;
                                oLedgerTender.ExchangeRate = oSTender.ExchangeRate;
                                oLedgerTender.InLocalCurrency = oSTender.InLocalCurrency;

                                ctx.PosLedgerTender.Add(oLedgerTender);
                            }
                            #endregion

                            #endregion

                            // Update Batch Header Info
                            oBatchHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                            oBatchHeader.ModifiedOn = DateTime.Now;

                            ctx.SaveChanges();

                            iCount++;

                            #region ClearBatchTransaction(oBatchHeader);
                            //string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
                            var detailList = ctx.EPOSBatchDetails.Where(x => x.HeaderId == oBatchHeader.HeaderId);
                            foreach (var detail in detailList)
                            {
                                ctx.EPOSBatchDetails.Remove(detail);
                            }

                            var tenderList =ctx. EPOSBatchTender.Where(x => x.HeaderId == oBatchHeader.HeaderId);
                            foreach (var tender in tenderList)
                            {
                                ctx.EPOSBatchTender.Remove(tender);
                            }

                            ctx.EPOSBatchHeader.Remove(oBatchHeader);

                            ctx.SaveChanges();
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
        private void ClearBatchTransaction(EPOSBatchHeader oBatchHeader)
        {
            string query = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
            EPOSBatchDetailsCollection detailList = EPOSBatchDetails.LoadCollection(query);
            for (int i = 0; i < detailList.Count; i++)
            {
                detailList[i].Delete();
            }

            EPOSBatchTenderCollection tenderList = EPOSBatchTender.LoadCollection(query);
            for (int i = 0; i < tenderList.Count; i++)
            {
                tenderList[i].Delete();
            }

            oBatchHeader.Delete();
        }
        */
        #endregion

        #region SubLedger
        /**
        /// <summary>
        /// Creates the EPOS sub ledger header.
        /// </summary>
        /// <param name="oBatchHeader">The o batch header.</param>
        /// <returns></returns>
        private Guid CreateEPOSSubLedgerHeader(EPOSBatchHeader oBatchHeader)
        {
            EPOSSubLedgerHeader oSubHeader = new EPOSSubLedgerHeader();
            
            oSubHeader.TxNumber = oBatchHeader.TxNumber;
            oSubHeader.TxType = oBatchHeader.TxType;
            oSubHeader.TxDate = oBatchHeader.TxDate;
            oSubHeader.TotalAmount = oBatchHeader.TotalAmount;
            oSubHeader.DepositAmount = oBatchHeader.DepositAmount;

            oSubHeader.StaffId = oBatchHeader.StaffId;
            oSubHeader.Staff1 = oBatchHeader.Staff1;
            oSubHeader.Staff2 = oBatchHeader.Staff2;
            oSubHeader.WorkplaceId = oBatchHeader.WorkplaceId;
            oSubHeader.VsLocationId = oBatchHeader.VsLocationId;
            oSubHeader.MemberId = oBatchHeader.MemberId;
            oSubHeader.Reference = oBatchHeader.Reference;
            oSubHeader.Remarks = oBatchHeader.Remarks;
            oSubHeader.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

            oSubHeader.SEX = oBatchHeader.SEX;
            oSubHeader.RACE = oBatchHeader.RACE;
            oSubHeader.EVT_CODE = oBatchHeader.EVT_CODE;
            oSubHeader.PRICE_TYPE = oBatchHeader.PRICE_TYPE;
            oSubHeader.CurrencyCode = oBatchHeader.CurrencyCode;
            oSubHeader.ExchangeRate = oBatchHeader.ExchangeRate;
            oSubHeader.ANALYSIS_CODE01 = oBatchHeader.ANALYSIS_CODE01;
            oSubHeader.ANALYSIS_CODE02 = oBatchHeader.ANALYSIS_CODE02;
            oSubHeader.ANALYSIS_CODE03 = oBatchHeader.ANALYSIS_CODE03;
            oSubHeader.ANALYSIS_CODE04 = oBatchHeader.ANALYSIS_CODE04;
            oSubHeader.ANALYSIS_CODE05 = oBatchHeader.ANALYSIS_CODE05;
            oSubHeader.ANALYSIS_CODE06 = oBatchHeader.ANALYSIS_CODE06;
            oSubHeader.ANALYSIS_CODE07 = oBatchHeader.ANALYSIS_CODE07;
            oSubHeader.ANALYSIS_CODE08 = oBatchHeader.ANALYSIS_CODE08;
            oSubHeader.ANALYSIS_CODE09 = oBatchHeader.ANALYSIS_CODE09;
            oSubHeader.ANALYSIS_CODE10 = oBatchHeader.ANALYSIS_CODE10;

            oSubHeader.CreatedBy = ConfigHelper.CurrentUserId;
            oSubHeader.CreatedOn = DateTime.Now;
            oSubHeader.ModifiedBy = ConfigHelper.CurrentUserId;
            oSubHeader.ModifiedOn = DateTime.Now;
            oSubHeader.Posted = true;
            oSubHeader.PostedBy = ConfigHelper.CurrentUserId;
            oSubHeader.PostedOn = DateTime.Now;

            oSubHeader.Save();

            return oSubHeader.HeaderId;
        }

        /// <summary>
        /// Creates the EPOS sub ledger detail.
        /// </summary>
        /// <param name="txnumber">The txnumber.</param>
        /// <param name="batchHeaderId">The batch header id.</param>
        /// <param name="subledgerHeaderId">The subledger header id.</param>
        private void CreateEPOSSubLedgerDetail(string txnumber, Guid batchHeaderId, Guid subledgerHeaderId)
        {
            string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
            string[] orderBy = new string[] { "LineNumber" };
            EPOSBatchDetailsCollection oBatchDetails = EPOSBatchDetails.LoadCollection(sql,orderBy,true);
            foreach (EPOSBatchDetails oBDetail in oBatchDetails)
            {
                EPOSSubLedgerDetails oSubDetail = new EPOSSubLedgerDetails();
                oSubDetail.HeaderId = subledgerHeaderId;
                oSubDetail.TxType = oBDetail.TxType;
                oSubDetail.TxNumber = txnumber;
                oSubDetail.TxDate = oBDetail.TxDate;
                oSubDetail.LineNumber = oBDetail.LineNumber;
                oSubDetail.ProductId = oBDetail.ProductId;
                oSubDetail.Qty = oBDetail.Qty;
                oSubDetail.UnitAmount = oBDetail.UnitAmount;
                oSubDetail.Discount = oBDetail.Discount;
                oSubDetail.Amount = oBDetail.Amount;
                oSubDetail.BARCODE = oBDetail.BARCODE;
                oSubDetail.SERIALNO = oBDetail.SERIALNO;
                oSubDetail.VITEM = oBDetail.VITEM;
                oSubDetail.COUPONNO = oBDetail.COUPONNO;
                oSubDetail.UAMT_FCURR = oBDetail.UAMT_FCURR;
                oSubDetail.AMOUNT_FCURR = oBDetail.AMOUNT_FCURR;

                oSubDetail.Save();
            }
        }

        /// <summary>
        /// Creates the EPOS sub ledger tender.
        /// </summary>
        /// <param name="txnumber">The txnumber.</param>
        /// <param name="batchHeaderId">The batch header id.</param>
        /// <param name="subledgerHeaderId">The subledger header id.</param>
        private void CreateEPOSSubLedgerTender(string txnumber, Guid batchHeaderId, Guid subledgerHeaderId)
        {
            string sql = "HeaderId = '" + batchHeaderId.ToString() + "'";
            EPOSBatchTenderCollection oBatchTender = EPOSBatchTender.LoadCollection(sql);
            foreach (EPOSBatchTender oBTender in oBatchTender)
            {
                EPOSSubLedgerTender oSubTender = new EPOSSubLedgerTender();
                oSubTender.HeaderId = subledgerHeaderId;
                oSubTender.TxType = oBTender.TxType;
                oSubTender.TxNumber = txnumber;
                oSubTender.TxDate = oBTender.TxDate;
                oSubTender.TypeId = oBTender.TypeId;
                oSubTender.CurrencyCode = oBTender.CurrencyCode;
                oSubTender.CardNumber = oBTender.CardNumber;
                oSubTender.AuthorizationCode = oBTender.AuthorizationCode;
                oSubTender.TenderAmount = oBTender.TenderAmount;
                oSubTender.ExchangeRate = oBTender.ExchangeRate;
                oSubTender.InLocalCurrency = oBTender.InLocalCurrency;

                oSubTender.Save();
            }
        }    
        */
        #endregion

        #region Ledger
        /**
        /// <summary>
        /// Creates the pos ledger header.
        /// </summary>
        /// <param name="oBatchHeader">The o batch header.</param>
        /// <param name="subLedgerHeaderId">The sub ledger header id.</param>
        /// <returns></returns>
        private Guid CreatePosLedgerHeader(EPOSBatchHeader oBatchHeader, Guid subLedgerHeaderId)
        {
            PosLedgerHeader oLedgerHeader = new PosLedgerHeader();

            oLedgerHeader.TxNumber = oBatchHeader.TxNumber;
            oLedgerHeader.TxType = oBatchHeader.TxType;
            oLedgerHeader.TxDate = oBatchHeader.TxDate;
            oLedgerHeader.TotalAmount = oBatchHeader.TotalAmount;
            oLedgerHeader.DepositAmount = oBatchHeader.DepositAmount;

            oLedgerHeader.StaffId = oBatchHeader.StaffId;
            oLedgerHeader.Staff1 = oBatchHeader.Staff1;
            oLedgerHeader.Staff2 = oBatchHeader.Staff2;
            oLedgerHeader.WorkplaceId = oBatchHeader.WorkplaceId;
            oLedgerHeader.VsLocationId = oBatchHeader.VsLocationId;
            oLedgerHeader.MemberId = oBatchHeader.MemberId;
            oLedgerHeader.Reference = oBatchHeader.Reference;
            oLedgerHeader.Remarks = oBatchHeader.Remarks;
            oLedgerHeader.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

            oLedgerHeader.SEX = oBatchHeader.SEX;
            oLedgerHeader.RACE = oBatchHeader.RACE;
            oLedgerHeader.EVT_CODE = oBatchHeader.EVT_CODE;

            oLedgerHeader.CreatedBy = ConfigHelper.CurrentUserId;
            oLedgerHeader.CreatedOn = DateTime.Now;
            oLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;
            oLedgerHeader.ModifiedOn = DateTime.Now;
            oLedgerHeader.PostedBy = ConfigHelper.CurrentUserId;
            oLedgerHeader.PostedOn = DateTime.Now;

            oLedgerHeader.Save();

            return oLedgerHeader.HeaderId;
        }

        /// <summary>
        /// Creates the pos ledger details.
        /// </summary>
        /// <param name="txnumber">The txnumber.</param>
        /// <param name="subledgerHeaderId">The subledger header id.</param>
        /// <param name="ledgerHeaderId">The ledger header id.</param>
        /// <param name="shop">The shop.</param>
        /// <param name="staffNumber">The staff number.</param>
        private void CreatePosLedgerDetails(string txnumber, Guid subledgerHeaderId, Guid ledgerHeaderId, string shop, string staffNumber)
        {
            string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
            string[] orderBy = new string[] { "LineNumber" };
            EPOSSubLedgerDetailsCollection oSubDetails = EPOSSubLedgerDetails.LoadCollection(sql, orderBy, true);
            foreach (EPOSSubLedgerDetails oSDetail in oSubDetails)
            {
                PosLedgerDetails oLedgerDetail = new PosLedgerDetails();
                oLedgerDetail.HeaderId = ledgerHeaderId;
                oLedgerDetail.TxType = oSDetail.TxType;
                oLedgerDetail.TxNumber = txnumber;
                oLedgerDetail.TxDate = oSDetail.TxDate;
                oLedgerDetail.LineNumber = oSDetail.LineNumber;
                oLedgerDetail.ProductId = oSDetail.ProductId;
                oLedgerDetail.Qty = oSDetail.Qty;
                oLedgerDetail.UnitAmount = oSDetail.UnitAmount;
                oLedgerDetail.Discount = oSDetail.Discount;
                oLedgerDetail.Amount = oSDetail.Amount;
                oLedgerDetail.Barcode = oSDetail.BARCODE;

                oLedgerDetail.AverageCost = 0;
                oLedgerDetail.SerialNumber = oSDetail.SERIALNO;
                oLedgerDetail.VendorItemRef = oSDetail.VITEM;
                oLedgerDetail.CouponNumber = oSDetail.COUPONNO;
                
                oLedgerDetail.SHOP = shop;
                oLedgerDetail.OPERATOR = staffNumber;

                // Product Info
                var oItem = ModelEx.ProductEx.Get(oSDetail.ProductId);
                if (oItem != null)
                {
                    oLedgerDetail.BasicPrice = oItem.RetailPrice.Value;
                    //oLedgerDetail.Discount = oItem.NormalDiscount;
                    oLedgerDetail.AverageCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(oItem.ProductId);
                }

                oLedgerDetail.Save();
            }
        }

        /// <summary>
        /// Creates the pos ledger tender.
        /// </summary>
        /// <param name="txnumber">The txnumber.</param>
        /// <param name="subledgerHeaderId">The subledger header id.</param>
        /// <param name="ledgerHeaderId">The ledger header id.</param>
        private void CreatePosLedgerTender(string txnumber, Guid subledgerHeaderId, Guid ledgerHeaderId)
        {
            string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "'";
            EPOSSubLedgerTenderCollection oSubTenders = EPOSSubLedgerTender.LoadCollection(sql);
            foreach (EPOSSubLedgerTender oSTender in oSubTenders)
            {
                PosLedgerTender oLedgerTender = new PosLedgerTender();
                oLedgerTender.HeaderId = ledgerHeaderId;
                oLedgerTender.TxType = oSTender.TxType;
                oLedgerTender.TxNumber = txnumber;
                oLedgerTender.TxDate = oSTender.TxDate;
                oLedgerTender.TypeId = oSTender.TypeId;
                oLedgerTender.CurrencyCode = oSTender.CurrencyCode;
                oLedgerTender.CardNumber = oSTender.CardNumber;
                oLedgerTender.AuthorizationCode = oSTender.AuthorizationCode;
                oLedgerTender.TenderAmount = oSTender.TenderAmount;
                oLedgerTender.ExchangeRate = oSTender.ExchangeRate;
                oLedgerTender.InLocalCurrency = oSTender.InLocalCurrency;

                oLedgerTender.Save();
            }
        }
        */
        #endregion

        #region Product
        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="txHeaderId">The tx header id.</param>
        /// <param name="workplaceId">The workplace id.</param>
        /// <param name="txType">Type of the tx.</param>
        private void UpdateProduct(Guid txHeaderId, Guid workplaceId, string txType)
        {
            string sql = "HeaderId = '" + txHeaderId.ToString() + "'";
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var detailsList = ctx.EPOSBatchDetails.Where(x => x.HeaderId == txHeaderId);
                        foreach (var detail in detailsList)
                        {
                            Guid productId = detail.ProductId;
                            decimal qty = detail.Qty.Value;

                            #region UpdateProductQty(detail.ProductId, workplaceId, detail.Qty, txType);
                            var item = ctx.ProductWorkplace.Where(x => x.ProductId == productId && x.WorkplaceId == workplaceId).FirstOrDefault();
                            if (item == null)
                            {
                                item = new EF6.ProductWorkplace();
                                item.ProductWorkplaceId = Guid.NewGuid();
                                item.ProductId = productId;
                                item.WorkplaceId = workplaceId;
                                ctx.ProductWorkplace.Add(item);
                            }
                            if (txType == "CAS")
                            {
                                item.CDQTY -= qty;
                            }
                            else
                            {
                                item.CDQTY += qty;
                            }
                            ctx.SaveChanges();
                            #endregion

                            #region UpdateProductSummary(detail.ProductId, detail.Qty, detail.UnitAmount, txType);
                            var oSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                            if (oSummary == null)
                            {
                                oSummary = new EF6.ProductCurrentSummary();
                                oSummary.CurrentSummaryId = Guid.NewGuid();
                                oSummary.ProductId = productId;
                                //oSummary.AverageCost = unitAmount;

                                ctx.ProductCurrentSummary.Add(oSummary);
                            }

                            /**
                            if ((oSummary.CDQTY + qty) > 0)
                            {
                                oSummary.AverageCost = (oSummary.AverageCost * oSummary.CDQTY + unitAmount * qty) / (oSummary.CDQTY + qty);
                            }
                            else
                            {
                                oSummary.AverageCost = oSummary.LastCost;
                            }

                            oSummary.LastCost = unitAmount;
                            */

                            if (txType == "CAS")
                            {
                                oSummary.CDQTY -= qty;
                            }
                            else
                            {
                                oSummary.CDQTY += qty;
                            }
                            ctx.SaveChanges();
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

        #endregion

        #endregion

        #region Finding TxNumber
        /// <summary>
        /// Findings the tx number.
        /// </summary>
        private void FindingTxNumber()
        {
            errorProvider.SetError(txtTxNumber, string.Empty);
            if (txtTxNumber.Text.Trim().Length > 0)
            {
                string sql = "TxNumber LIKE '%" + txtTxNumber.Text.Trim() + "%'";
                var oHeader = ModelEx.EPOSBatchHeaderEx.Get(sql);                
                if (oHeader != null)
                {
                    EnumHelper.Status oStatus = (EnumHelper.Status)Enum.Parse(typeof(EnumHelper.Status), oHeader.Status.ToString());
                    switch (oStatus)
                    {
                        case EnumHelper.Status.Draft: // Holding
                            tabPosAuthorization.SelectedIndex = 1;
                            break;
                        case EnumHelper.Status.Active: // Posting
                            tabPosAuthorization.SelectedIndex = 0;
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

        /**
        /// <summary>
        /// Checks the tx date.
        /// </summary>
        /// <param name="dateToBeChecked">The date to be checked.</param>
        /// <returns></returns>
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
                canBeMark = canBeMark & (dates[2] == lblSysYear.Text); // Check System Year
                canBeMark = canBeMark & (dates[1] == lblSysMonth.Text); // Check System Month
            }

            return canBeMark;
        }
        */

        /// <summary>
        /// Handles the CheckedChanged event of the chkSortAndFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkSortAndFilter_CheckedChanged(object sender, EventArgs e)
        {
            cboFieldName.Enabled = chkSortAndFilter.Checked;
            cboOperator.Enabled = chkSortAndFilter.Checked;
            cboOrdering.Enabled = chkSortAndFilter.Checked;
            txtData.Enabled = chkSortAndFilter.Checked;
            btnReload.Enabled = chkSortAndFilter.Checked;
        }

        /// <summary>
        /// Handles the Click event of the btnReload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtTxNumber, string.Empty);

            if (VerifyDate())
            {
                BindingList(EnumHelper.Status.Active); // Posting

                if (this.lvPostTransaction.Items.Count == 0)
                {
                    MessageBox.Show("No record found!", "ATTENTION");
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnMarkAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem objItem in this.lvPostTransaction.Items)
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

        /// <summary>
        /// Handles the Click event of the btnPost control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnPost_Click(object sender, EventArgs e)
        {
            if (lvPostTransaction.CheckedItems.Count > 0)
            {
                SelectedColumnsCounting();

                btnMarkAll.Enabled = false;

                int result = CreatePosTx();
                if (result > 0)
                {
                    MessageBox.Show(result.ToString() + " Posted successfully!", "Posting result", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No Record Selected!", "Selection");
            }
        }

        /// <summary>
        /// Handles the EnterKeyDown event of the txtTxNumber control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void txtTxNumber_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && e.KeyData == Keys.Return)
            {
                FindingTxNumber();
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the lvPostTransaction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvPostTransaction_DoubleClick(object sender, EventArgs e)
        {
            if (lvPostTransaction.Items != null && lvPostTransaction.SelectedIndex >= 0)
            {
                int index = lvPostTransaction.SelectedIndex;

                if (postStatus != RT2020.Controls.InvtUtility.PostingStatus.Ready)
                {
                    string headerId = this.lvPostTransaction.Items[index].Text;
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
                            if (this.lvPostTransaction.Items[index].Checked)
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

        /// <summary>
        /// Handles the ItemCheck event of the lvPostTransaction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        private void lvPostTransaction_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                lvPostTransaction.Items[e.Index].Checked = !(lvPostTransaction.Items[e.Index].BackColor == RT2020.SystemInfo.ControlBackColor.DisabledBox);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOption_Click(object sender, EventArgs e)
        {
            if (chkCheckQty.Visible)
            {
                chkCheckQty.Visible = false;
            }
            else
            {
                chkCheckQty.Visible = true;
            }
        }

        /// <summary>
        /// Checks the qty.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        /// <returns></returns>
        private bool CheckQty(Guid headerId)
        {
            bool result = true;
            var oBatchHeader = ModelEx.EPOSBatchHeaderEx.Get(headerId);
            string sqlWhere = "HeaderId = '" + headerId.ToString() + "'";
            var oBatchDetails = ModelEx.EPOSBatchDetailsEx.GetList(sqlWhere);
            for (int i = 0; i < oBatchDetails.Count; i++)
            {
                var detail = oBatchDetails[i];
                result = CheckByProductWorkplace(detail.ProductId, oBatchHeader.WorkplaceId, detail.Qty.Value);
                if (!result)
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Checks the by product workplace.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <param name="workplaceId">The workplace id.</param>
        /// <param name="qty">The qty.</param>
        /// <returns></returns>
        private bool CheckByProductWorkplace(Guid productId, Guid workplaceId, decimal qty)
        {
            //string sql = "ProductId = '" + productId.ToString() + "' AND WorkplaceId = '" + workplaceId.ToString() + "'";
            //ProductWorkplace wpProd = ProductWorkplace.LoadWhere(sql);
            //if (qty > wpProd.CDQTY)

            if (qty > ProductHelper.GetOnHandQtyByWorkplaceId(productId, workplaceId))
            {
                return false;
            }
            return true;
        }
    }
}