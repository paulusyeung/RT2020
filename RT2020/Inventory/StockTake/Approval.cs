#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;

#endregion

namespace RT2020.Inventory.StockTake
{
    public partial class Approval : Form
    {
        public Approval()
        {
            InitializeComponent();
            InitComboBox();
            BindingList();
        }

        #region Init
        private void InitComboBox()
        {
            txtSysMonth.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth;
            txtSysYear.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear;

            cboFieldName.SelectedIndex = 0;
            cboOperator.SelectedIndex = 0;
            cboOrdering.SelectedIndex = 0;
        }
        #endregion

        #region Bind Methods

        private void BindingList()
        {
            lvPostTxList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString(Common.Enums.Status.Draft.ToString("d"));
            
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
                    objItem.SubItems.Add(reader.GetString(3)); // Location
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(2), false)); // TxDate
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(6), false) + " " + ModelEx.StaffEx.GetStaffNumberById(reader.GetGuid(7))); // Last Update
                    objItem.SubItems.Add(string.Empty);

                    iCount++;
                }
            }
        }

        private string BuildSqlQueryString(string status)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT HeaderId, TxNumber, TxDate, WorkplaceCode, ");
            sql.Append(" CreatedOn, CreatedBy, ModifiedOn, ModifiedBy ");
            sql.Append(" FROM vwDraftSTKList ");
            sql.Append(" WHERE PostedOn = '1900-01-01' AND STATUS = ").Append(status);

            if (txtTxNumber.Text.Length > 0)
            {
                sql.Append(" AND TxNumber LIKE '%").Append(txtTxNumber.Text).Append("%' ");
                sql.Append(" ORDER BY TxNumber ");
            }
            else if (chkSortAndFilter.Checked)
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
                sql.Append(" ORDER BY TxNumber ");
            }

            return sql.ToString();
        }

        private string ColumnName()
        {
            string colName = string.Empty;
            switch (cboFieldName.Text)
            {
                case "Tx Date":
                    colName = "TxDate";
                    break;
                case "Loc#":
                    colName = "WorkplaceCode";
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
        private bool VerifyTxDate(string value)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(value))
            {
                string[] txDate = value.Split('/');

                if (txDate[2].Equals(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear) && txDate[1].Equals(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth))
                {
                    result = true;
                }
            }

            return result;
        }

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

        private int ApproveTx()
        {
            int iCount = 0;
            using (var ctx = new EF6.RT2020Entities())
            {
                foreach (ListViewItem objItem in this.lvPostTxList.Items)
                {
                    Guid id = Guid.Empty;
                    if (objItem.Checked && Guid.TryParse(objItem.Text, out id))
                    {
                        var oHeader = ctx.StockTakeHeader.Find(id);
                        if (oHeader != null)
                        {
                            oHeader.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));

                            oHeader.ModifiedBy = Common.Config.CurrentUserId;
                            oHeader.ModifiedOn = DateTime.Now;

                            ctx.SaveChanges();
                            iCount++;

                            objItem.SubItems[1].Text = "OK";
                        }
                    }
                }
            }
            return iCount;
        }
        #endregion

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (VerifyDate())
            {
                BindingList();
            }
        }

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem objItem in this.lvPostTxList.Items)
            {
                if (VerifyTxDate(objItem.SubItems[5].Text.Trim()))
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
                else
                {
                    objItem.SubItems[7].Text = "Date does not belong to Current Month (Tx Date)";
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

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (SelectedColumnsCounting() > 0)
            {
                int result = ApproveTx();
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
                //BindingList();
            }
        }

        private void txtTxNumber_TextChanged(object sender, EventArgs e)
        {
            if (VerifyDate())
            {
                BindingList();
            }
        }

        private void lvPostTxList_Click(object sender, EventArgs e)
        {
            if (lvPostTxList.Items != null && lvPostTxList.SelectedIndex >= 0)
            {
                if (VerifyTxDate(this.lvPostTxList.Items[lvPostTxList.SelectedIndex].SubItems[5].Text.Trim()))
                {
                    this.lvPostTxList.Items[lvPostTxList.SelectedIndex].Checked = !this.lvPostTxList.Items[lvPostTxList.SelectedIndex].Checked;
                }
                else
                {
                    this.lvPostTxList.Items[lvPostTxList.SelectedIndex].SubItems[7].Text = "Date does not belong to Current Month (Tx Date)";
                }
            }
        }
    }
}