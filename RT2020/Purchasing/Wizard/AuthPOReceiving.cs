////RT2020.Purchasing.Wizard
namespace RT2020.Purchasing.Wizard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Text;
    using System.Text.RegularExpressions;

    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Forms;

    using RT2020.DAL;

    /// <summary>
    /// Documentation for the second part of AuthPOReceiving.
    /// </summary>
    public partial class AuthPOReceiving : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthPOReceiving"/> class.
        /// </summary>
        public AuthPOReceiving()
        {
            this.InitializeComponent();
            this.InitComboBox();
            this.BindingList(Common.Enums.Status.Active); //// Posting
            this.BindingList(Common.Enums.Status.Draft); //// Holding
        }

        /// <summary>
        /// Handles the Click event of the BtnReload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnReload_Click(object sender, EventArgs e)
        {
            if (this.VerifyDate())
            {
                this.BindingList(Common.Enums.Status.Active); //// Posting
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the BtnPost control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (this.SelectedColumnsCounting() > 0)
            {
                int result = this.CreateReceiving();
                if (result > 0)
                {
                    MessageBox.Show(result.ToString() + " succeed!", "Posting result", MessageBoxButtons.OK, new EventHandler(this.PostingMessageHandler));
                }
                else
                {
                    MessageBox.Show(result.ToString() + " succeed!", "Posting result", MessageBoxButtons.OK, MessageBoxIcon.Warning, new EventHandler(this.PostingMessageHandler));
                }
            }
            else
            {
                MessageBox.Show("No Record Selected!", "Failed");
            }
        }

        /// <summary>
        /// Postings the message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PostingMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                this.BindingList(Common.Enums.Status.Active); //// Posting
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the ChkSortAndFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ChkSortAndFilter_CheckedChanged(object sender, EventArgs e)
        {
            this.cboFieldName.Enabled = this.chkSortAndFilter.Checked;
            this.cboOperator.Enabled = this.chkSortAndFilter.Checked;
            this.cboOrdering.Enabled = this.chkSortAndFilter.Checked;
            this.txtData.Enabled = this.chkSortAndFilter.Checked;
            this.btnReload.Enabled = this.chkSortAndFilter.Checked;
        }

        /// <summary>
        /// Handles the Click event of the BtnMarkAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnMarkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem objItem in this.lvPostTxList.Items)
            {
                if (this.btnMarkAll.Text.Contains("Mark") && !objItem.SubItems[1].Text.Contains("*"))
                {
                    objItem.SubItems[1].Text = "*";
                }
                else if (this.btnMarkAll.Text.Contains("Unmark"))
                {
                    objItem.SubItems[1].Text = string.Empty;
                }
            }

            this.Update();

            this.btnMarkAll.Text = (this.btnMarkAll.Text == "Mark All") ? "Unmark All" : "Mark All";
        }

        /// <summary>
        /// Handles the Click event of the LvPostTxList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LvPostTxList_Click(object sender, EventArgs e)
        {
            if (this.lvPostTxList.Items != null && this.lvPostTxList.SelectedIndex >= 0)
            {
                int index = this.lvPostTxList.SelectedIndex;
                this.lvPostTxList.Items[index].SubItems[1].Text = (this.lvPostTxList.Items[index].SubItems[1].Text.Length == 0) ? "*" : string.Empty;
                this.Update();
            }
        }

        #region Init
        /// <summary>
        /// Inits the combo box.
        /// </summary>
        private void InitComboBox()
        {
            this.txtPostedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, true);
            this.txtSysMonth.Text = DateTime.Now.Month.ToString().PadLeft(2, '0');
            this.txtSysYear.Text = DateTime.Now.Year.ToString();

            this.cboFieldName.SelectedIndex = 0;
            this.cboOperator.SelectedIndex = 0;
            this.cboOrdering.SelectedIndex = 0;
        }
        #endregion

        #region Bind Methods
        /// <summary>
        /// Datas the source.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="conditions">if set to <c>true</c> [conditions].</param>
        /// <returns>The source</returns>
        private SqlDataReader DataSource(string status, bool conditions)
        {
            string sql = this.BuildSqlQueryString(status, conditions);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                return reader;
            }
        }

        /// <summary>
        /// Bindings the list.
        /// </summary>
        /// <param name="status">The status.</param>
        private void BindingList(Common.Enums.Status status)
        {
            SqlDataReader reader;
            switch (status)
            {
                case Common.Enums.Status.Draft: //// Holding
                    reader = this.DataSource(Common.Enums.Status.Draft.ToString("d"), false);
                    this.BindingHoldingList(reader);
                    break;
                case Common.Enums.Status.Active: //// Posting
                    reader = this.DataSource(Common.Enums.Status.Active.ToString("d"), true);
                    this.BindingPostingList(reader);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Bindings the holding list.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void BindingHoldingList(SqlDataReader reader)
        {
            this.lvHoldingTxList.Items.Clear();

            int iCount = 1;

            if (!reader.IsClosed)
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvHoldingTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                    objItem.SubItems.Add(string.Empty);
                    objItem.SubItems.Add(iCount.ToString()); //// Line Number
                    objItem.SubItems.Add(reader.GetString(2)); //// ReceivingNumber
                    objItem.SubItems.Add(reader.GetString(10)); // Ref PO No.
                    objItem.SubItems.Add(reader.GetString(1)); //// Type
                    objItem.SubItems.Add(reader.GetString(4)); //// Location
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); //// OrderDate
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(7), false)); //// LastUpdate

                    iCount++;
                }
                reader.Close();
            }
        }

        /// <summary>
        /// Bindings the posting list.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void BindingPostingList(SqlDataReader reader)
        {
            this.lvPostTxList.Items.Clear();

            int iCount = 1;

            if (!(reader.IsClosed))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvPostTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                    objItem.SubItems.Add(string.Empty);
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // ReceivingNumber
                    objItem.SubItems.Add(reader.GetString(10)); // Ref PO No.
                    objItem.SubItems.Add(reader.GetString(1)); // Type
                    objItem.SubItems.Add(reader.GetString(4)); // Location
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // OrderDate
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(7), false)); // LastUpdate

                    iCount++;
                }
                reader.Close();
            }
        }

        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="withConditions">if set to <c>true</c> [with conditions].</param>
        /// <returns>the SQL query string.</returns>
        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ReceiveHeaderId, TxType, TxNumber, TxDate, Location,  ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy,OrderHeaderId, OrderNumber ");
            sql.Append(" FROM vwReceivingList ");
            sql.Append(" WHERE STATUS = ").Append(status);

            if (this.txtReceivingNumber.Text.Trim().Length > 0)
            {
                sql.Append(" AND TxNumber LIKE '%").Append(this.txtReceivingNumber.Text.Trim()).Append("%'");
            }

            //// 查询字段status 为 POST 数据
            if (status == "1")
            {
                sql.Append(" AND PostedBy = '" + System.Guid.Empty + "'");
            }

            if (this.chkSortAndFilter.Checked && withConditions)
            {
                if (this.cboFieldName.Text.Length > 0 && this.cboOperator.Text != "None")
                {
                    sql.Append(" AND ");
                    sql.Append(ColumnName()).Append(" ");

                    if (this.cboFieldName.Text.Contains("Date"))
                    {
                        sql.Append("BETWEEN '");
                        sql.Append(this.txtData.Tag.ToString()).Append(" 00:00:00'");
                        sql.Append(" AND '");
                        sql.Append(this.txtData.Tag.ToString()).Append(" 23:59:59'");
                    }
                    else
                    {
                        sql.Append((this.cboOperator.Text == "=") ? "= '" : "LIKE '%");
                        sql.Append(this.txtData.Text).Append((this.cboOperator.Text == "=") ? "'" : "%'");
                    }
                }

                sql.Append(" ORDER BY ");
                sql.Append(this.ColumnName());
                sql.Append((this.cboOrdering.Text == "Ascending") ? " ASC" : " DESC");
            }

            return sql.ToString();
        }

        /// <summary>
        /// Columns the name.
        /// </summary>
        /// <returns>the is name.</returns>
        private string ColumnName()
        {
            string colName = string.Empty;
            switch (this.cboFieldName.Text)
            {
                case "Type":
                    colName = "TxType";
                    break;
                case "Location":
                    colName = "Location";
                    break;
                case "Receive Date (dd/MM/yyyy)":
                    colName = "OrderOn";
                    break;
                case "Last Update (dd/MM/yyyy)":
                    colName = "ModifiedOn";
                    break;
                default:
                case "Receiving Number":
                    colName = "TxNumber";
                    break;
            }

            return colName;
        }

        /// <summary>
        /// Verifies the date.
        /// </summary>
        /// <returns>The is date.</returns>
        private bool VerifyDate()
        {
            bool isVerified = true;
            if (this.cboFieldName.Text.Contains("Date") && this.cboOperator.Text != "None")
            {
                string pattern = @"^\d{1,2}\/\d{1,2}\/\d{4}$";
                Regex rex = new Regex(pattern);
                Match match = rex.Match(this.txtData.Text);
                if (!match.Success)
                {
                    this.errorProvider.SetError(this.lblData, "Incorrect Date Format! (Date Format:dd/MM/yyyy)");
                    isVerified = false;
                }
                else
                {
                    this.errorProvider.SetError(this.lblData, string.Empty);
                    this.FormatDate();
                }
            }

            return isVerified;
        }

        /// <summary>
        /// Formats the date.
        /// </summary>
        private void FormatDate()
        {
            string[] dateValue = this.txtData.Text.Split('/');
            this.txtData.Tag = dateValue[2] + "-" + dateValue[1] + "-" + dateValue[0];
        }
        #endregion

        #region Posting Batch

        /// <summary>
        /// Selecteds the columns counting.
        /// </summary>
        /// <returns>The columns counting</returns>
        private int SelectedColumnsCounting()
        {
            int iCount = 0;

            foreach (ListViewItem objItem in this.lvPostTxList.Items)
            {
                if (objItem.SubItems[1].Text == "*")
                {
                    iCount++;
                }
            }

            return iCount;
        }

        /// <summary>
        /// Creates the purchase order.
        /// </summary>
        /// <returns>The purchase order</returns>
        private int CreateReceiving()
        {
            int iCount = 0;
            if (this.lvPostTxList.Items.Count > 0)
            {
                foreach (ListViewItem objItem in this.lvPostTxList.Items)
                {
                    this.CreateReceiving(objItem, ref iCount);
                }
            }

            return iCount;
        }

        /// <summary>
        /// Creates the purchase order.
        /// </summary>
        /// <param name="listItem">The list item.</param>
        /// <param name="iCount">The i count.</param>
        private void CreateReceiving(ListViewItem listItem, ref int iCount)
        {
            Guid id = Guid.Empty;
            if (Guid.TryParse(listItem.Text, out id) && listItem.SubItems[1].Text == "*")
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    var objHeader = ctx.PurchaseOrderReceiveHeader.Find(id);
                    if (objHeader != null)
                    {
                        objHeader.PostedOn = DateTime.Now;
                        objHeader.PostedBy = Common.Config.CurrentUserId;

                        objHeader.ModifiedBy = Common.Config.CurrentUserId;
                        objHeader.ModifiedOn = DateTime.Now;

                        ctx.SaveChanges();

                        iCount++;
                    }
                }
            }
        }

        #endregion
    }
}