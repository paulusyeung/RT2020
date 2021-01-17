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
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Inventory.StockTake
{
    public partial class Authorization : Form
    {
        private RT2020.Controls.InvtUtility.PostingStatus postStatus = RT2020.Controls.InvtUtility.PostingStatus.Ready;
        DataTable oTable;

        public Authorization()
        {
            InitializeComponent();
            InitComboBox();
            BindingHoldingList();
            BindingPostingList();
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
                    objItem.SubItems.Add(reader.GetString(1)); // TxNumber
                    objItem.SubItems.Add(reader.GetString(3)); // Location
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(2), false)); // TxDate
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(4), false)); // Modified On

                    iCount++;
                }
            }
        }

        private void BindingPostingList()
        {
            lvPostTxList.CheckBoxes = true;
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
                    objItem.SubItems.Add(reader.GetString(1)); // TxNumber
                    objItem.SubItems.Add(reader.GetString(3)); // Location
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(2), false)); // TxDate
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(4), false)); // Modified On
                    objItem.BackColor = CheckTxDate(reader.GetDateTime(2)) ? Color.Transparent : RT2020.SystemInfo.ControlBackColor.DisabledBox;

                    iCount++;
                }
            }
        }

        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT HeaderId,TxNumber,TxDate,WorkplaceCode, ");
            sql.Append(" ModifiedOn,ModifiedBy ");
            sql.Append(" FROM vwDraftSTKList");
            sql.Append(" WHERE STATUS = ").Append(status);
            sql.Append(" AND YEAR(PostedOn) = 1900 ");

            if (txtTxNumber.Text.Trim().Length > 0)
            {
                sql.Append(" AND TxNumber LIKE '%").Append(txtTxNumber.Text.Trim()).Append("%' ");
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
            else
            {
                sql.Append(" ORDER BY TxNumber");
            }

            return sql.ToString();
        }

        private string ColumnName()
        {
            string colName = string.Empty;
            switch (cboFieldName.Text)
            {
                case "LOC#":
                    colName = "WorkplaceCode";
                    break;
                case "Tx Date (dd/MM/yyyy)":
                    colName = "TxDate";
                    break;
                case "Last Update (dd/MM/yyyy)":
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

            Guid id = Guid.Empty;
            if (Guid.TryParse(headerId, out id))
            {
                
                var oBatchHeader = ModelEx.StockTakeHeaderEx.Get(id);
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

                    if (oBatchHeader.PostedOn.Value.Year > 1900)
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

                    var detailList = ModelEx.StockTakeDetailsEx.GetByHeaderIdr(oBatchHeader.HeaderId);
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

                        if (chkCheckVeQty.Checked && chkCheckVeQty.Visible)
                        {
                            decimal stkTtlQty = (detail.Book1Qty.Value + detail.Book2Qty.Value + detail.Book3Qty.Value + detail.Book4Qty.Value + detail.Book5Qty.Value + detail.HHTQty.Value) - detail.CapturedQty.Value;

                            //string sql = "ProductId = '" + detail.ProductId + "' AND WorkplaceId = '" + oBatchHeader.WorkplaceId.ToString() + "'";
                            var pw = ModelEx.ProductWorkplaceEx.Get(detail.ProductId.Value, oBatchHeader.WorkplaceId.Value);
                            if (pw != null)
                            {
                                if ((pw.CDQTY + stkTtlQty) < 0)
                                {
                                    DataRow row = errorTable.NewRow();
                                    row["HeaderId"] = oBatchHeader.HeaderId.ToString();
                                    row["TxNumber"] = oBatchHeader.TxNumber;
                                    row["STKCODE"] = stk;
                                    row["APPENDIX1"] = a1;
                                    row["APPENDIX2"] = a2;
                                    row["APPENDIX3"] = a3;
                                    row["ErrorReason"] = "Not enough stock for adjustment!";
                                    row["PostDate"] = DateTime.Now;

                                    errorTable.Rows.Add(row);

                                    isPostable = isPostable & false;
                                }
                            }
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
                foreach (ListViewItem oItem in lvPostTxList.Items)
                {
                    Guid id = Guid.Empty;
                    if (oItem.Checked && Guid.TryParse(oItem.Text, out id))
                    {
                        CreateADJTx(id);
                        oItem.SubItems[1].Text = new IconResourceHandle("16x16.16_succeeded.png").ToString();

                        iCount++;
                    }
                }
            }
            return iCount;
        }

        private void CreateADJTx(Guid headerId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oBatchHeader = ctx.StockTakeHeader.Find(headerId);
                if (oBatchHeader != null)
                {
                    oBatchHeader.PostedOn = DateTime.Now;
                    ctx.SaveChanges();

                    this.UpdateProduct(oBatchHeader.HeaderId, oBatchHeader.WorkplaceId.Value);

                    // Create Ledger for TxType 'STK'
                    string txNumber_Ledger = SystemInfo.Settings.QueuingTxNumber(EnumHelper.TxType.ADJ);
                    Guid ledgerHeaderId = CreateLedgerHeader(txNumber_Ledger, oBatchHeader);
                    CreateLedgerDetails(
                        txNumber_Ledger, ledgerHeaderId, oBatchHeader.HeaderId,
                        ModelEx.StaffEx.GetStaffNumberById(ConfigHelper.CurrentUserId),
                        ModelEx.WorkplaceEx.GetWorkplaceCodeById(oBatchHeader.WorkplaceId.Value)
                        );

                    oBatchHeader.ADJNUM = txNumber_Ledger;
                    ctx.SaveChanges();
                }
            }
        }

        #region Ledger
        private Guid CreateLedgerHeader(string txNumber, EF6.StockTakeHeader oBatchHeader)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oLedgerHeader = new EF6.InvtLedgerHeader();
                oLedgerHeader.HeaderId = Guid.NewGuid();
                oLedgerHeader.TxNumber = txNumber;
                oLedgerHeader.TxType = EnumHelper.TxType.ADJ.ToString();
                oLedgerHeader.TxDate = DateTime.Now;
                oLedgerHeader.SubLedgerHeaderId = oBatchHeader.HeaderId;
                oLedgerHeader.WorkplaceId = oBatchHeader.WorkplaceId.Value;
                oLedgerHeader.StaffId = ConfigHelper.CurrentUserId;
                oLedgerHeader.Reference = oBatchHeader.TxNumber;
                oLedgerHeader.Remarks = "Stock Take #: " + oBatchHeader.TxNumber;
                oLedgerHeader.Status = Convert.ToInt32(EnumHelper.Status.Draft.ToString("d"));
                oLedgerHeader.CreatedBy = ConfigHelper.CurrentUserId;
                oLedgerHeader.CreatedOn = DateTime.Now;
                oLedgerHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                oLedgerHeader.ModifiedOn = DateTime.Now;
                ctx.InvtLedgerHeader.Add(oLedgerHeader);
                ctx.SaveChanges();
                result= oLedgerHeader.HeaderId;
            }

            return result;
        }

        private void CreateLedgerDetails(string txnumber, Guid ledgerHeaderId, Guid stkHeaderId, string staff, string workplace)
        {
            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var stkDetailsList = ctx.StockTakeDetails.Where(x => x.HeaderId == stkHeaderId);
                        foreach (var stkDetail in stkDetailsList)
                        {
                            var oLedgerDetail = new EF6.InvtLedgerDetails();
                            oLedgerDetail.DetailsId = Guid.NewGuid();
                            oLedgerDetail.HeaderId = ledgerHeaderId;
                            oLedgerDetail.SubLedgerDetailsId = stkDetail.DetailsId;
                            oLedgerDetail.LineNumber = iCount;
                            oLedgerDetail.ProductId = stkDetail.ProductId.Value;
                            oLedgerDetail.Qty = (stkDetail.Book1Qty + stkDetail.Book2Qty + stkDetail.Book3Qty + stkDetail.Book4Qty + stkDetail.Book5Qty + stkDetail.HHTQty) - stkDetail.CapturedQty;
                            oLedgerDetail.TxNumber = txnumber;
                            oLedgerDetail.TxType = EnumHelper.TxType.ADJ.ToString();
                            oLedgerDetail.TxDate = DateTime.Now;
                            oLedgerDetail.Amount = 0;
                            oLedgerDetail.UnitAmount = 0;
                            oLedgerDetail.AverageCost = stkDetail.AverageCost.Value;
                            oLedgerDetail.Notes = string.Empty;
                            oLedgerDetail.SerialNumber = string.Empty;
                            oLedgerDetail.OPERATOR = staff;
                            oLedgerDetail.SHOP = workplace;

                            #region lookup & fill BasicPrice & VedorRef
                            var oItem = ctx.Product.Find(stkDetail.ProductId.Value);
                            if (oItem != null)
                            {
                                oLedgerDetail.BasicPrice = oItem.RetailPrice;

                                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.VPRC.ToString());
                                var oPrice = ctx.ProductPrice
                                        .Where(x => x.ProductId == stkDetail.ProductId && x.PriceTypeId == priceTypeId)
                                        .AsNoTracking()
                                        .FirstOrDefault();
                                if (oPrice != null)
                                {
                                    oLedgerDetail.VendorRef = oPrice.CurrencyCode;
                                }
                            }
                            #endregion

                            ctx.InvtLedgerDetails.Add(oLedgerDetail);
                            ctx.SaveChanges();

                            iCount++;
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

        #region Product
        private void UpdateProduct(Guid txHeaderId, Guid workplaceId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        //string sql = "HeaderId = '" + txHeaderId.ToString() + "'";
                        var detailsList = ctx.StockTakeDetails.Where(x => x.HeaderId == txHeaderId).AsNoTracking().ToList();
                        foreach (var detail in detailsList)
                        {
                            //StockTakeDetails detail = detailsList[i];
                            decimal stkTtlQty = (detail.Book1Qty.Value + detail.Book2Qty.Value + detail.Book3Qty.Value + detail.Book4Qty.Value + detail.Book5Qty.Value + detail.HHTQty.Value) - detail.CapturedQty.Value;
                            Guid productId = detail.ProductId.Value;
                            decimal qty = stkTtlQty;

                            #region UpdateProductCurrentSummary(detail.ProductId.Value, stkTtlQty);
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

                            #region UpdateProductQty(detail.ProductId.Value, workplaceId, stkTtlQty);
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
                    //string sql = "TxNumber LIKE '%" + txtTxNumber.Text.Trim() + "%'";
                    var oHeader = ctx.StockTakeHeader.Where(x => x.TxNumber.Contains(txtTxNumber.Text.Trim())).AsNoTracking().FirstOrDefault();
                    if (oHeader != null)
                    {
                        EnumHelper.Status oStatus = (EnumHelper.Status)Enum.Parse(typeof(EnumHelper.Status), oHeader.Status.ToString());
                        switch (oStatus)
                        {
                            case EnumHelper.Status.Draft: // Holding
                                tabSTKAuthorization.SelectedIndex = 1;
                                BindingHoldingList();
                                break;
                            case EnumHelper.Status.Active: // Posting
                                tabSTKAuthorization.SelectedIndex = 0;
                                BindingPostingList();
                                break;
                        }
                    }
                    else
                    {
                        errorProvider.SetError(txtTxNumber, "StockTake Number field does not exist!");
                    }
                }
            }
            else
            {
                errorProvider.SetError(txtTxNumber, "StockTake Number field cannot be blank!");
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
                BindingPostingList();

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
                int result = CreateADJTx();
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

        private void PostingMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                BindingPostingList();
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            chkCheckVeQty.Visible = !chkCheckVeQty.Visible;
            chkPerformTxProcess.Visible = !chkPerformTxProcess.Visible;
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

        private void txtTxNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && e.KeyData == Keys.Return)
            {
                FindingTxNumber();
            }
        }

        private void txtTxNumber_TextChanged(object sender, EventArgs e)
        {
            FindingTxNumber();
        }
    }
}