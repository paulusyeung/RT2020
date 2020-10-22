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

#endregion

namespace RT2020.Web.Shop.StockReplenishment
{
    public partial class Confirmation : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Confirmation"/> class.
        /// </summary>
        public Confirmation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Confirmation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Confirmation_Load(object sender, EventArgs e)
        {
            BindData();
        }

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

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.listView.Items.Add(reader.GetGuid(0).ToString());
                    objItem.SubItems.Add(reader.GetString(1)); // Tx Number
                    objItem.SubItems.Add(reader.GetString(2));
                    objItem.SubItems.Add(reader.GetDateTime(3).ToString(Common.Utility.GetDateFormat())); // 
                    objItem.SubItems.Add(reader.GetDateTime(4).ToString(Common.Utility.GetDateFormat()));
                    objItem.SubItems.Add(reader.GetString(5));
                }
            }
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        private string BuildQuery()
        {
            string query = @"SELECT     rh.HeaderId, rh.TxNumber, wp.WorkplaceCode AS FromLocation, rh.TxDate, rh.TXFOn AS TransferDate, CASE rh.SpecialRequest WHEN 1 THEN '*' ELSE '' END AS SpecialRequest
                                FROM         dbo.InvtBatchRPL_Header AS rh LEFT OUTER JOIN dbo.Workplace AS wp ON wp.WorkplaceCode = rh.FromLocation
                                WHERE    rh.Confirmed = 0 AND rh.[Status] = 1 AND rh.ToLocation = '" + GetLocationCode(Common.Utility.CurrentWorkplaceId) + "'";

            if (txtLookupTxNumber.Text.Trim().Length > 0)
            {
                query += " AND rh.TxNumber LIKE '%" + txtLookupTxNumber.Text + "%'";
            }

            query += " ORDER BY rh.TxNumber";

            return query;
        }

        /// <summary>
        /// Gets the location code.
        /// </summary>
        /// <param name="workplaceId">The workplace id.</param>
        /// <returns></returns>
        private string GetLocationCode(System.Guid workplaceId)
        {
            Workplace oWp = Workplace.Load(workplaceId);
            if (oWp != null)
            {
                return oWp.WorkplaceCode;
            }
            else
            {
                return string.Empty;
            }
        }

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
            //ConfirmationWizard wizConfirm = sender as ConfirmationWizard;
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