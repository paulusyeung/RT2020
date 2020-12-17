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
using RT2020.DAL;
using System.Text.RegularExpressions;
using System.Configuration;

#endregion

namespace RT2020.Inventory.Replenishment
{
    public partial class Confirmation : Form
    {
        public Confirmation()
        {
            InitializeComponent();
            InitComboBox();
            BindingHoldingList();
        }

        #region Init
        private void InitComboBox()
        {
            cboFieldName.SelectedIndex = 0;
            cboOperator.SelectedIndex = 0;
            cboOrdering.SelectedIndex = 0;
        }
        #endregion

        #region Bind Methods

        private void BindingHoldingList()
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
                    objItem.SubItems.Add(string.Empty);
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(1)); // TxNumber
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(2), false)); // TxDate
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(2), false)); // TxferDate
                    objItem.SubItems.Add(string.Empty); // CompletedDate
                    objItem.SubItems.Add(reader.GetString(4)); // From Location
                    objItem.SubItems.Add(reader.GetString(5)); // To Location
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(13), false) + " " + ModelEx.StaffEx.GetStaffNumberById(reader.GetGuid(14))); // Last Update

                    iCount++;
                }
            }
        }

        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT HeaderId, TxNumber, TxDate, StaffNumber, ");
            sql.Append(" FromLocation, ToLocation, CompletedOn, Confirmed, ConfirmedOn, ConfirmedBy, Remarks, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy ");
            sql.Append(" FROM vwDraftRPLList ");
            sql.Append(" WHERE Confirmed = 0 AND STATUS = ").Append(status);
            sql.Append(" AND YEAR(CompletedOn) <> 1900 AND YEAR(TXFOn) <> 1900 ");

            if (chkSortAndFilter.Checked && withConditions)
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
                case "Tx Date":
                    colName = "TxDate";
                    break;
                case "Txfer Date":
                    colName = "TransferredOn";
                    break;
                case "Complete Date":
                    colName = "CompletedOn";
                    break;
                case "From Loc#":
                    colName = "FromLocation";
                    break;
                case "To Loc#":
                    colName = "ToLocation";
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

        #region Confirmation
        private int SelectedColumnsCounting()
        {
            int iCount = 0;

            foreach (ListViewItem objItem in this.lvPostTxList.Items)
            {
                if (objItem.Checked)
                {
                    iCount++;
                }
            }

            return iCount;
        }

        private int ConfirmTx()
        {
            int iCount = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                foreach (ListViewItem objItem in this.lvPostTxList.Items)
                {
                    if (objItem.Checked)
                    {
                        var oHeader = ctx.InvtBatchRPL_Header.Find(new Guid(objItem.Text));
                        if (oHeader != null)
                        {
                            oHeader.Confirmed = true;
                            oHeader.ConfirmedBy = Common.Config.CurrentUserId;
                            oHeader.ConfirmedOn = DateTime.Now;

                            oHeader.ModifiedBy = Common.Config.CurrentUserId;
                            oHeader.ModifiedOn = DateTime.Now;

                            ctx.SaveChanges();

                            iCount++;
                        }
                    }
                }
            }

            return iCount;
        }
        #endregion

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (SelectedColumnsCounting() > 0)
            {
                int result = ConfirmTx();
                if (result > 0)
                {
                    MessageBox.Show(result.ToString() + " succeed!", "Confirmation result", MessageBoxButtons.OK, new EventHandler(ConfirmationMessageHandler));
                }
                else
                {
                    MessageBox.Show(result.ToString() + " succeed!", "Confirmation result", MessageBoxButtons.OK, MessageBoxIcon.Warning, new EventHandler(ConfirmationMessageHandler));
                }
            }
            else
            {
                MessageBox.Show("No Record Selected!");
            }
        }

        private void ConfirmationMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                BindingHoldingList();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (VerifyDate())
            {
                BindingHoldingList();
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

        private void chkSortAndFilter_CheckedChanged(object sender, EventArgs e)
        {
            cboFieldName.Enabled = chkSortAndFilter.Checked;
            cboOperator.Enabled = chkSortAndFilter.Checked;
            cboOrdering.Enabled = chkSortAndFilter.Checked;
            txtData.Enabled = chkSortAndFilter.Checked;
            btnReload.Enabled = chkSortAndFilter.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvPostTxList_Click(object sender, EventArgs e)
        {
            if (lvPostTxList.Items != null && lvPostTxList.SelectedIndex >= 0)
            {
                this.lvPostTxList.Items[lvPostTxList.SelectedIndex].Checked = true;
                this.Update();
            }
        }

        private void txtTxNumber_TextChanged(object sender, EventArgs e)
        {
            BindingHoldingList();
        }
    }
}