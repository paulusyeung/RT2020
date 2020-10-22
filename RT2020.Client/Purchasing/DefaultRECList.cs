using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RT2020.DAL;
using System.Data.Common;

namespace RT2020.Client.Purchasing
{
    public partial class DefaultRECList : Form
    {
        public DefaultRECList()
        {
            InitializeComponent();

            FillcboCreateBy();
            dgvList.AutoGenerateColumns = false;
            Common.ComboBox.FillView(ref this.cboView);

            BindList();

            Cursor.Current = Cursors.Default;
        }

        #region Binding List
        private void BindList()
        {
            string sql = BuildSqlQueryString();
            DataSet ds = SqlHelper.Default.ExecuteDataSet(CommandType.Text,sql);

            if(ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns.Add("LN");
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    ds.Tables[0].Rows[i]["LN"] = Convert.ToString(i + 1);
                }

                dgvList.DataSource = ds.Tables[0];
            }
        }

        #endregion

        #region FillComboBox
        private void FillcboCreateBy()
        {
            string[] orderBy = new string[] { "StaffNumber" };
            RT2020.DAL.StaffCollection staffCol = RT2020.DAL.Staff.LoadCollection(orderBy, true);
            staffCol.Add(new RT2020.DAL.Staff());
            cboCreateBy.Items.Clear();
            cboCreateBy.DataSource = staffCol;
            cboCreateBy.DisplayMember = "StaffNumber";
            cboCreateBy.ValueMember = "StaffId";

            if (DAL.Common.Config.CurrentUserId != Guid.Empty)
            {
                cboCreateBy.SelectedValue = DAL.Common.Config.CurrentUserId;
            }
            else
            {
                cboCreateBy.SelectedIndex = cboCreateBy.Items.Count - 1;
            }
        }
        #endregion

        #region Build Sql Query String
        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <returns>The joined Sql</returns>
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
SELECT ReceiveHeaderId,
    (
    CASE
        WHEN Status = 0 THEN 'HOLD'
        WHEN Status = 1 THEN 'POST'
    END
    ) AS Status, TxNumber, TxDate, StaffNumber, ");
            sql.Append(" Location, SupplierCode, ");
            sql.Append(" CreatedOn, ModifiedOn ");
            sql.Append(" FROM vwReceivingList ");
            sql.Append(" WHERE 1 = 1 AND ");

            switch (cboView.SelectedIndex)
            {
                case 0: //// Last 7 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 1: //// Last 14 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-14).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 2: //// Last 30 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 3: //// Last 60 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-60).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 4: //// Last 90 days
                    sql.Append(" CreatedOn BETWEEN CAST('").Append(DateTime.Today.AddDays(-90).ToString("yyyy-MM-dd 00:00:00")).Append("' AS DATETIME)");
                    sql.Append(" AND CAST('").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("' AS DATETIME)");
                    break;
                case 5: //// All
                default:
                    sql.Append(" 1 = 1 ");
                    break;
            }

            if (!string.IsNullOrEmpty(txtLookup.Text))
            {
                sql.Append(" AND TxNumber LIKE '%").Append(txtLookup.Text).Append("%'");
            }

            if (cboCreateBy.SelectedValue != null && cboCreateBy.SelectedValue.ToString() != string.Empty)
            {
                sql.Append(" AND CreatedBy = '").Append(cboCreateBy.SelectedValue.ToString()).Append("'");
            }

            sql.Append("ORDER BY TxNumber");

            return sql.ToString();
        }

        #endregion

        #region ShowWizard
        private void ShowWizard(Guid orderHeaderId)
        {
            Wizard.Receiving oWizard = new Wizard.Receiving(orderHeaderId);
            //oWizard.OrderHeaderId = orderHeaderId;    2013.08.09 paulus: no need
            //oWizard.EditMode = orderHeaderId == Guid.Empty ? Mode.New : Mode.Edit;
            //oWizard.Closed += new EventHandler(oWizard_Closed);
            oWizard.ShowDialog();
        }

        #endregion

        private void ansAddNew_Click(object sender, EventArgs e)
        {
            Wizard.ReceivingFind wizard = new Wizard.ReceivingFind();
            wizard.ShowDialog();
        }

        private void ansRefresh_Click(object sender, EventArgs e)
        {
            txtLookup.Text = "";
            //cboCreateBy.SelectedValue = System.Guid.Empty;
            cboView.SelectedIndex = cboView.Items.Count - 1;
            BindList();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                System.Guid ledgerHeaderId = new System.Guid(dgvList.Rows[e.RowIndex].Cells[dgvList.Columns["colOrderHeaderId"].Index].Value.ToString());
                ShowWizard(ledgerHeaderId);
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            BindList();
        }

    }
}
