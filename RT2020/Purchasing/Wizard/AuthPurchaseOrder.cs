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

    
    using System.Linq;
    using System.Data.Entity;
    using RT2020.Common.Helper;

    /// <summary>
    /// Documentation for the second part of AuthPurchaseOrder.
    /// </summary>
    public partial class AuthPurchaseOrder : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthPurchaseOrder"/> class.
        /// </summary>
        public AuthPurchaseOrder()
        {
            this.InitializeComponent();
            this.InitComboBox();
            this.BindingList(EnumHelper.Status.Active); //// Posting
            this.BindingList(EnumHelper.Status.Draft); //// Holding
        }

        #region Init
        /// <summary>
        /// Inits the combo box.
        /// </summary>
        private void InitComboBox()
        {
            this.txtPostedOn.Text = DateTimeHelper.DateTimeToString(DateTime.Now, true);
            this.txtSysMonth.Text = DateTime.Now.Month.ToString().PadLeft(2, '0');
            this.txtSysYear.Text = DateTime.Now.Year.ToString();

            this.cboFieldName.SelectedIndex = 0;
            this.cboOperator.SelectedIndex = 0;
            this.cboOrdering.SelectedIndex = 0;
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the BtnReload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnReload_Click(object sender, EventArgs e)
        {
            if (this.VerifyDate())
            {
                this.BindingList(EnumHelper.Status.Active); //// Posting
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
        /// Handles the Click event of the BtnPost control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (this.SelectedColumnsCounting() > 0)
            {
                int result = this.CreatePurchaseOrder();
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
                this.BindingList(EnumHelper.Status.Active); //// Posting
            }
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
        /// Handles the TextChanged event of the TxtOrderNumber control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            this.FindingOrderNumber();
        }

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

        #region Posting Batch

        /// <summary>
        /// Creates the purchase order.
        /// </summary>
        /// <returns>The purchase order</returns>
        private int CreatePurchaseOrder()
        {
            int iCount = 0;
            if (this.lvPostTxList.Items.Count > 0)
            {
                foreach (ListViewItem objItem in this.lvPostTxList.Items)
                {
                    this.CreatePurchaseOrder(objItem, ref iCount);
                }
            }
            
            return iCount;
        }

        /// <summary>
        /// Creates the purchase order.
        /// </summary>
        /// <param name="listItem">The list item.</param>
        /// <param name="iCount">The i count.</param>
        private void CreatePurchaseOrder(ListViewItem listItem, ref int iCount)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                Guid headerId = Guid.Empty;

                if (Guid.TryParse(listItem.Text, out headerId) && listItem.SubItems[1].Text == "*")
                {
                    var objHeader = ctx.PurchaseOrderHeader.Find(headerId);
                    if (objHeader != null)
                    {
                        objHeader.PostedOn = DateTime.Now;
                        objHeader.PostedBy = ConfigHelper.CurrentUserId;

                        objHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                        objHeader.ModifiedOn = DateTime.Now;
                        ctx.SaveChanges();

                        iCount++;
                    }
                }
            }
        }
               
        #endregion

        #endregion

        #region Finding OrderNumber
        /// <summary>
        /// Findings the order number.
        /// </summary>
        private void FindingOrderNumber()
        {
            this.errorProvider.SetError(this.txtOrderNumber, string.Empty);
            if (this.txtOrderNumber.Text.Trim().Length > 0)
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    var objHeader = ctx.PurchaseOrderHeader.Where(x => x.OrderNumber.Contains(this.txtOrderNumber.Text.Trim())).AsNoTracking().FirstOrDefault();
                    if (objHeader != null)
                    {
                        EnumHelper.Status objStatus = (EnumHelper.Status)Enum.Parse(typeof(EnumHelper.Status), objHeader.Status.ToString());
                        switch (objStatus)
                        {
                            case EnumHelper.Status.Draft: // Holding
                                this.tabREJAuthorization.SelectedIndex = 1;
                                break;
                            case EnumHelper.Status.Active: // Posting
                                this.tabREJAuthorization.SelectedIndex = 0;
                                break;
                        }

                        this.BindingList(objStatus);
                    }
                    else
                    {
                        this.errorProvider.SetError(this.txtOrderNumber, "Cash Purchase Number field does not exist!");
                    }
                }
            }
            else
            {
                this.errorProvider.SetError(this.txtOrderNumber, "Cash Purchase Number field cannot be blank!");
            }
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
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd);
            
            return reader;
            
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
                case EnumHelper.Status.Draft: //// Holding
                    reader = this.DataSource(EnumHelper.Status.Draft.ToString("d"), false);
                    this.BindingHoldingList(reader);
                    break;
                case EnumHelper.Status.Active: //// Posting
                    reader = this.DataSource(EnumHelper.Status.Active.ToString("d"), true);
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

            while (reader.Read())
            {
                string orderType = string.Empty;
                switch (reader.GetInt32(1))
                {
                    case 0:
                        orderType = EnumHelper.POType.FPO.ToString();
                        break;
                    case 1:
                        orderType = EnumHelper.POType.LPO.ToString();
                        break;
                    case 2:
                        orderType = EnumHelper.POType.OPO.ToString();
                        break;
                }

                ListViewItem objItem = this.lvHoldingTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                objItem.SubItems.Add(string.Empty);
                objItem.SubItems.Add(iCount.ToString()); //// Line Number
                objItem.SubItems.Add(reader.GetString(2)); //// OrderNumber
                objItem.SubItems.Add(orderType); //// Type
                objItem.SubItems.Add(reader.GetString(4)); //// Location
                objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(3), false)); //// OrderDate
                objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(7), false)); //// LastUpdate

                iCount++;
            }

            if (!reader.IsClosed)
            {
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

            while (reader.Read())
            {
                string orderType = string.Empty;
                switch (reader.GetInt32(1))
                {
                    case 0:
                        orderType = EnumHelper.POType.FPO.ToString();
                        break;
                    case 1:
                        orderType = EnumHelper.POType.LPO.ToString();
                        break;
                    case 2:
                        orderType = EnumHelper.POType.OPO.ToString();
                        break;
                }

                ListViewItem objItem = this.lvPostTxList.Items.Add(reader.GetGuid(0).ToString()); // TxId
                objItem.SubItems.Add(string.Empty);
                objItem.SubItems.Add(iCount.ToString()); // Line Number
                objItem.SubItems.Add(reader.GetString(2)); // OrderNumber
                objItem.SubItems.Add(orderType); // Type
                objItem.SubItems.Add(reader.GetString(4)); // Location
                objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(3), false)); // OrderDate
                objItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(7), false)); // LastUpdate

                iCount++;
            }

            if (!reader.IsClosed)
            {
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
            sql.Append("SELECT OrderHeaderId, OrderType, OrderNumber, OrderOn, Location,  ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, PostedBy ");
            sql.Append(" FROM vwPurchaseOrderList ");
            sql.Append(" WHERE STATUS = ").Append(status);

            if (this.txtOrderNumber.Text.Trim().Length > 0)
            {
                sql.Append(" AND OrderNumber LIKE '%").Append(this.txtOrderNumber.Text.Trim()).Append("%'");
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
                    colName = "OrderType";
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
                case "Order Number":
                    colName = "OrderNumber";
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
                    this.errorProvider.SetError(this.lblData, "Purchase Order Date Format! (Date Format:dd/MM/yyyy)");
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

        /// <summary>
        /// Handles the KeyUp event of the txtOrderNumber control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void TxtOrderNumber_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyData == Keys.Enter && objArgs.KeyData == Keys.Return)
            {
                this.FindingOrderNumber();
            }
        }
    }
}