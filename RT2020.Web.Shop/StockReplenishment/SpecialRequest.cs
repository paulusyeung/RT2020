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

namespace RT2020.Web.Shop.StockReplenishment
{
    public partial class SpecialRequest : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialRequest"/> class.
        /// </summary>
        public SpecialRequest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the SpecialRequest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SpecialRequest_Load(object sender, EventArgs e)
        {
            FillShopList();

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

            using (System.Data.SqlClient.SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.listView.Items.Add(reader.GetGuid(0).ToString());
                    objItem.SubItems.Add(reader.GetString(1)); // Tx Number
                    objItem.SubItems.Add(reader.GetString(2));
                    objItem.SubItems.Add(reader.GetDateTime(3).ToString(Common.Utility.GetDateFormat())); // 
                    objItem.SubItems.Add(reader.GetDateTime(4).ToString(Common.Utility.GetDateFormat()));
                }
            }
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        private string BuildQuery()
        {
            string query = @"SELECT     rh.HeaderId, rh.TxNumber, wp.WorkplaceCode AS FromLocation, rh.TxDate, rh.TXFOn AS TransferDate
                                FROM         dbo.InvtBatchRPL_Header AS rh LEFT OUTER JOIN dbo.Workplace AS wp ON wp.WorkplaceCode = rh.FromLocation
                                WHERE    rh.Confirmed = 0 AND rh.[Status] = 1 AND rh.SpecialRequest = 1 AND rh.ToLocation = '" + GetLocationCode(Common.Utility.CurrentWorkplaceId) + "'";

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
                    SpecialRequestWizard wizSR = new SpecialRequestWizard();
                    wizSR.HeaderId = new System.Guid(listView.SelectedItem.Text);
                    wizSR.Closed += new EventHandler(Wizard_Closed);
                    wizSR.ShowDialog();
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
            SpecialRequestWizard wizSR = sender as SpecialRequestWizard;
            if (wizSR.HeaderId != System.Guid.Empty)
            {
                BindData();
                this.Update();
            }
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
        /// Fills the shop list.
        /// </summary>
        public void FillShopList()
        {
            cboFromLocation.Items.Clear();

            Workplace.LoadCombo(ref cboFromLocation, new string[] { "WorkplaceCode", "WorkplaceName" }, "{0} - {1}", false, false, string.Empty, string.Empty, null);

            if (Common.Utility.CurrentWorkplaceId != System.Guid.Empty)
            {
                cboFromLocation.Items.Remove(Common.Utility.CurrentWorkplaceId);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAddNew control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (RT2020.DAL.Common.Utility.IsGUID(cboFromLocation.SelectedValue.ToString()))
            {
                SpecialRequestWizard wizSR = new SpecialRequestWizard();
                wizSR.FromLocation = new System.Guid(cboFromLocation.SelectedValue.ToString());
                wizSR.Closed += new EventHandler(Wizard_Closed);
                wizSR.ShowDialog();
            }
        }
    }
}