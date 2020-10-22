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
    public partial class Confirmation : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InTransit"/> class.
        /// </summary>
        public Confirmation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the InTransit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void InTransit_Load(object sender, EventArgs e)
        {
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
                    objItem.SubItems.Add(reader.GetDateTime(6).ToString(Common.Utility.GetDateFormat()) == DateTime.Now.ToString(Common.Utility.GetDateFormat()) ? string.Empty : reader.GetDateTime(6).ToString(Common.Utility.GetDateFormat()));
                    objItem.SubItems.Add(reader.GetString(1));
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
SELECT     txf.HeaderId, 'WH' AS TBL, txf.TxType, txf.TxNumber, txf.TxDate, w.WorkplaceCode AS FromLoaction, txf.TransferredOn
FROM         dbo.InvtBatchTXF_Header AS txf LEFT OUTER JOIN dbo.Workplace AS w ON txf.FromLocation = w.WorkplaceId
WHERE       txf.ToLocation = '" + Common.Utility.CurrentWorkplaceId.ToString() + @"' AND 
                            (txf.CONFIRM_TRF  = '' OR txf.CONFIRM_TRF IS NULL ) AND txf.Status= '1'";

            string subledgerQuery = @"
SELECT     txf.HeaderId, 'WH A' AS TBL, txf.TxType, txf.TxNumber, txf.TxDate, w.WorkplaceCode AS FromLoaction, txf.TransferredOn
FROM         dbo.InvtSubLedgerTXF_Header AS txf LEFT OUTER JOIN dbo.Workplace AS w ON txf.FromLocation = w.WorkplaceId
WHERE       txf.ToLocation = '" + Common.Utility.CurrentWorkplaceId.ToString() + @"' AND 
                            (txf.CONFIRM_TRF  = '' OR txf.CONFIRM_TRF IS NULL ) AND txf.Status= '1'";

            string fepQuery = @"
SELECT     HeaderId, 'SHOP' AS TBL, TxType, TxNumber, TxDate, SHOP AS FromLoaction, GETDATE() AS TransferredOn
FROM         dbo.FepBatchHeader
WHERE       FTSHOP = '" + GetWorkplaceCode() + @"' AND 
                            (CONFIRM_TRF  = '' OR CONFIRM_TRF IS NULL ) AND TxType='TXO'";

            query = "SELECT * FROM (" + batchQuery + " UNION " + subledgerQuery + " UNION " + fepQuery + ") AS TransitList ";

            if (txtLookupTxNumber.Text.Trim().Length > 0)
            {
                query += " WHERE TxNumber LIKE '%" + txtLookupTxNumber.Text + "%'";
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
                    ConfirmationWizard wizConfirm = new ConfirmationWizard();
                    wizConfirm.HeaderId = new System.Guid(listView.SelectedItem.Text);
                    wizConfirm.TxNumber = listView.SelectedItem.SubItems[1].Text;
                    wizConfirm.FromLocation = listView.SelectedItem.SubItems[2].Text;
                    wizConfirm.InTransitType = listView.SelectedItem.SubItems[5].Text;
                    wizConfirm.Closed += new EventHandler(Wizard_Closed);
                    wizConfirm.ShowDialog();
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
            //ConfirmationWizard wizConfirm = new ConfirmationWizard();
            //if (wizConfirm.HeaderId != System.Guid.Empty)
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
    }
}