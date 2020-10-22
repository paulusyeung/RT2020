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

#endregion

namespace RT2020.Web.Shop.Transfer
{
    public partial class History : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InTransit"/> class.
        /// </summary>
        public History()
        {
            InitializeComponent();

            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
        }

        /// <summary>
        /// Handles the Load event of the History control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void History_Load(object sender, EventArgs e)
        {
            lblFrom.Enabled = chkIncludesDateRange.Checked;
            dtpFrom.Enabled = chkIncludesDateRange.Checked;
            lblTo.Enabled = chkIncludesDateRange.Checked;
            dtpTo.Enabled = chkIncludesDateRange.Checked;

            BindData();
        }

        #region Bind Data
        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData()
        {
            listView.Items.Clear();

            string query = BuildQuery();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (System.Data.SqlClient.SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.listView.Items.Add(reader.GetGuid(0).ToString());
                    objItem.SubItems.Add(reader.GetString(3)); // Tx Number
                    objItem.SubItems.Add(reader.GetString(5));
                    objItem.SubItems.Add(reader.GetDateTime(4).ToString(Common.Utility.GetDateFormat())); // 
                    objItem.SubItems.Add(reader.GetDateTime(6).ToString(Common.Utility.GetDateFormat()));
                    objItem.SubItems.Add(reader.GetString(1));
                    objItem.SubItems.Add(reader.GetDecimal(7).ToString("##"));
                }
            }
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        private string BuildQuery()
        {
            string query = string.Empty;

            string batchQuery = @"
SELECT     txf.HeaderId, 'WH' AS TBL, txf.TxType, txf.TxNumber, txf.TxDate, w.WorkplaceCode AS FromLoaction, txf.CONFIRM_TRF_LASTUPDATE, 
            (SELECT SUM(QtyConfirmed) FROM dbo.InvtBatchTXF_Details WHERE HeaderId = txf.HeaderId) AS QtyConfirmed
FROM         dbo.InvtBatchTXF_Header AS txf LEFT OUTER JOIN dbo.Workplace AS w ON txf.FromLocation = w.WorkplaceId
WHERE       txf.ToLocation = '" + Common.Utility.CurrentWorkplaceId.ToString() + @"' AND (txf.CONFIRM_TRF  = 'C') AND txf.Status= '1'";

            string subledgerQuery = @"
SELECT     txf.HeaderId, 'WH A' AS TBL, txf.TxType, txf.TxNumber, txf.TxDate, w.WorkplaceCode AS FromLoaction, txf.CONFIRM_TRF_LASTUPDATE, 
            (SELECT SUM(QtyConfirmed) FROM dbo.InvtSubLedgerTXF_Details WHERE HeaderId = txf.HeaderId) AS QtyConfirmed
FROM         dbo.InvtSubLedgerTXF_Header AS txf LEFT OUTER JOIN dbo.Workplace AS w ON txf.FromLocation = w.WorkplaceId
WHERE       txf.ToLocation = '" + Common.Utility.CurrentWorkplaceId.ToString() + @"' AND  (txf.CONFIRM_TRF  = 'C') AND txf.Status= '1'";

            string fepQuery = @"
SELECT     fh.HeaderId, 'SHOP' AS TBL, fh.TxType, fh.TxNumber, fh.TxDate, fh.SHOP AS FromLoaction, fh.CONFIRM_TRF_LASTUPDATE, 
            (SELECT SUM(CONFIRM_TRF_QTY) FROM dbo.FepBatchDetail WHERE HeaderId = fh.HeaderId) AS QtyConfirmed
FROM         dbo.FepBatchHeader fh
WHERE       fh.FTSHOP = '" + GetWorkplaceCode() + @"' AND (fh.CONFIRM_TRF  = 'C') AND fh.TxType='TXO'";

            query = @"SELECT * FROM ( " + batchQuery + " UNION " + subledgerQuery + " UNION " + fepQuery + @" ) AS TransitList ";

            if (txtLookupTxNumber.Text.Trim().Length > 0)
            {
                query += " WHERE TxNumber LIKE '%" + txtLookupTxNumber.Text + "%' ";
            }
            else
            {
                query += " WHERE 1 = 1 ";
            }

            if (chkIncludesDateRange.Checked)
            {
                query += " AND CONFIRM_TRF_LASTUPDATE >= CAST('" + dtpFrom.Value.ToString("yyyy-MM-dd") + @" 00:00:00' AS DATETIME) 
                           AND CONFIRM_TRF_LASTUPDATE <= CAST('" + dtpTo.Value.ToString("yyyy-MM-dd") + @" 23:59:59' AS DATETIME) ";
            }

            query += " ORDER BY TBL, TxNumber DESC";

            return query;
        }

        /// <summary>
        /// Gets the workplace code.
        /// </summary>
        /// <returns></returns>
        private string GetWorkplaceCode()
        {
            Workplace oWp = Workplace.Load(Common.Utility.CurrentWorkplaceId);
            if (oWp != null)
            {
                return oWp.WorkplaceCode;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        /// <summary>
        /// Handles the DoubleClick event of the listView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                if (RT2020.DAL.Common.Utility.IsGUID(listView.SelectedItem.Text))
                {
                    HistoryDetail wizHistory = new HistoryDetail();
                    wizHistory.HeaderId = new System.Guid(listView.SelectedItem.Text);
                    wizHistory.TxNumber = listView.SelectedItem.SubItems[1].Text;
                    wizHistory.FromLocation = listView.SelectedItem.SubItems[2].Text;
                    wizHistory.InTransitType = listView.SelectedItem.SubItems[5].Text;
                    wizHistory.Closed += new EventHandler(Wizard_Closed);
                    wizHistory.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Handles the Closed event of the Wizard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Wizard_Closed(object sender, EventArgs e)
        {
            //HistoryDetail wizHistory = new HistoryDetail();
            //if (wizHistory.HeaderId != System.Guid.Empty)
            //{
                BindData();
                this.Update();
            //}
        }

        /// <summary>
        /// Handles the Click event of the btnLookup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnLookup_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// Handles the Click event of the chkIncludesDateRange control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkIncludesDateRange_Click(object sender, EventArgs e)
        {
            lblFrom.Enabled = chkIncludesDateRange.Checked;
            dtpFrom.Enabled = chkIncludesDateRange.Checked;
            lblTo.Enabled = chkIncludesDateRange.Checked;
            dtpTo.Enabled = chkIncludesDateRange.Checked;
        }
    }
}