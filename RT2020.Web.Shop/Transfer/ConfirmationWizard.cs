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
    public partial class ConfirmationWizard : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InTransitWizard"/> class.
        /// </summary>
        public ConfirmationWizard()
        {
            InitializeComponent();
        }

        #region Properties
        private System.Guid headerId = System.Guid.Empty;
        private string inTransitType = string.Empty;
        private System.Guid fromLoc = System.Guid.Empty;

        /// <summary>
        /// Gets or sets the header id.
        /// </summary>
        /// <value>The header id.</value>
        public System.Guid HeaderId
        {
            get
            {
                return headerId;
            }
            set
            {
                headerId = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the in transit.
        /// </summary>
        /// <value>The type of the in transit.</value>
        public string InTransitType
        {
            get
            {
                return inTransitType;
            }
            set
            {
                this.txtType.Text = value;
                inTransitType = value;
            }
        }

        /// <summary>
        /// Gets or sets the tx number.
        /// </summary>
        /// <value>The tx number.</value>
        public string TxNumber
        {
            get
            {
                return this.txtTxNumber.Text;
            }
            set
            {
                this.txtTxNumber.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets from location.
        /// </summary>
        /// <value>From location.</value>
        public string FromLocation
        {
            get
            {
                return this.txtFromLocation.Text;
            }
            set
            {
                ShowWorkplaceCode(value);
            }
        }
        #endregion

        /// <summary>
        /// Handles the Load event of the InTransitWizard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void InTransitWizard_Load(object sender, EventArgs e)
        {
            this.GetSystemLabels();
            this.BindData();
        }

        #region Bind Data

        /// <summary>
        /// Gets the system labels.
        /// </summary>
        private void GetSystemLabels()
        {
            // Header Text
            dataGridViewTextBoxColumn1.HeaderText = "HeaderId";
            dataGridViewTextBoxColumn2.HeaderText = "SEQ#";
            dataGridViewTextBoxColumn3.HeaderText = Common.Utility.GetSystemLabelByKey("STKCODE");
            dataGridViewTextBoxColumn4.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX1");
            dataGridViewTextBoxColumn5.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX2");
            dataGridViewTextBoxColumn6.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX3");
            dataGridViewTextBoxColumn7.HeaderText = "C/D QTY";
            dataGridViewTextBoxColumn8.HeaderText = "REQ QTY";
            dataGridViewTextBoxColumn9.HeaderText = "Confirm Qty";

            // Bound Fields
            dataGridViewTextBoxColumn1.DataPropertyName = "DetailsId";
            dataGridViewTextBoxColumn2.DataPropertyName = "LineNumber";
            dataGridViewTextBoxColumn3.DataPropertyName = "STKCODE";
            dataGridViewTextBoxColumn4.DataPropertyName = "APPENDIX1";
            dataGridViewTextBoxColumn5.DataPropertyName = "APPENDIX2";
            dataGridViewTextBoxColumn6.DataPropertyName = "APPENDIX3";
            dataGridViewTextBoxColumn7.DataPropertyName = "CDQTY";
            dataGridViewTextBoxColumn8.DataPropertyName = "QtyRequested";
            dataGridViewTextBoxColumn9.DataPropertyName = "QtyConfirmed";

            // Width
            dataGridViewTextBoxColumn2.Width = 50;
            dataGridViewTextBoxColumn3.Width = 80;
            dataGridViewTextBoxColumn4.Width = 60;
            dataGridViewTextBoxColumn5.Width = 60;
            dataGridViewTextBoxColumn6.Width = 60;
            dataGridViewTextBoxColumn7.Width = 80;
            dataGridViewTextBoxColumn8.Width = 80;
            dataGridViewTextBoxColumn9.Width = 80;

            // Readonly
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn8.ReadOnly = true;

            // Alignment
            dataGridViewTextBoxColumn7.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewTextBoxColumn8.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewTextBoxColumn9.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Format
            dataGridViewTextBoxColumn7.CellTemplate.Style.Format = "n0";
            dataGridViewTextBoxColumn8.CellTemplate.Style.Format = "n0";
            dataGridViewTextBoxColumn9.CellTemplate.Style.Format = "n0";
        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData()
        {
            string query = BuildQuery();
            
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                dgvConfirmationList.AutoGenerateColumns = false;
                dgvConfirmationList.DataSource = dataset.Tables[0];
            }
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        private string BuildQuery()
        {
            string query = string.Empty;

            switch (this.txtType.Text.Trim())
            {
                case "SHOP":
                    query = @"
SELECT     fd.DetailsId, fd.HeaderId, fd.LineNumber, fd.ProductId, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, 
            (SELECT CDQTY FROM ProductWorkplace WHERE WorkplaceId = '" + fromLoc.ToString() + @"' AND ProductId = p.ProductId) AS CDQTY, fd.QTY AS QtyRequested, CONFIRM_TRF_QTY AS QtyConfirmed
FROM         dbo.FepBatchDetail AS fd LEFT OUTER JOIN dbo.Product AS p ON fd.ProductId = p.ProductId
WHERE       fd.HeaderId = '" + this.HeaderId.ToString() + "' ORDER BY fd.LineNumber";
                    break;

                case "WH":
                    query = @"
SELECT     td.DetailsId, td.HeaderId, td.LineNumber, td.ProductId, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, 
            (SELECT CDQTY FROM ProductWorkplace WHERE WorkplaceId = '" + fromLoc.ToString() + @"' AND ProductId = p.ProductId) AS CDQTY, td.QtyRequested, QtyConfirmed
FROM         dbo.InvtBatchTXF_Details AS td LEFT OUTER JOIN dbo.Product AS p ON td.ProductId = p.ProductId
WHERE       td.HeaderId = '" + this.HeaderId.ToString() + "' ORDER BY td.LineNumber";
                    break;

                case "WH A":
                    query = @"
SELECT     td.DetailsId, td.HeaderId, td.LineNumber, td.ProductId, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, 
            (SELECT CDQTY FROM ProductWorkplace WHERE WorkplaceId = '" + fromLoc.ToString() + @"' AND ProductId = p.ProductId) AS CDQTY, td.QtyRequested, QtyConfirmed
FROM         dbo.InvtSubLedgerTXF_Details AS td LEFT OUTER JOIN dbo.Product AS p ON td.ProductId = p.ProductId
WHERE       td.HeaderId = '" + this.HeaderId.ToString() + "' ORDER BY td.LineNumber";
                    break;
            }

            return query;
        }
        #endregion

        /// <summary>
        /// Shows the workplace code.
        /// </summary>
        /// <param name="value">The value.</param>
        private void ShowWorkplaceCode(string value)
        {
            string code = string.Empty;
            string query = "WorkplaceCode = '" + value.Trim() + "'";
            Workplace oWp = Workplace.LoadWhere(query);
            if (oWp != null)
            {
                fromLoc = oWp.WorkplaceId;
                code = oWp.WorkplaceCode + " - " + oWp.WorkplaceName;
            }

            this.txtFromLocation.Text = code;
        }

        /// <summary>
        /// Handles the Click event of the btnFillAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnFillAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvConfirmationList.Rows.Count; i++)
            {
                DataGridViewRow oRow = dgvConfirmationList.Rows[i];

                oRow.Cells[8].Value = "1";
            }
        }

        /// <summary>
        /// Handles the ButtonClick event of the toolBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs"/> instance containing the event data.</param>
        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Name.ToLower())
            {
                case "tbtnsuspend":
                    this.Save(false);
                    this.BindData();

                    MessageBox.Show("Save Successfully!", "Message");
                    break;
                case "tbtnconfirm":
                    this.Save(true);
                    this.Close();
                    break;
                case "tbtnprint":
                    break;
            }
        }

        #region Save

        /// <summary>
        /// Saves the specified b confirmed.
        /// </summary>
        /// <param name="bConfirmed">if set to <c>true</c> [b confirmed].</param>
        private void Save(bool bConfirmed)
        {
            switch (this.txtType.Text.Trim())
            {
                case "SHOP":
                    SaveFEP(bConfirmed);
                    break;
                case "WH":
                    SaveTXFB(bConfirmed);
                    break;
                case "WH A":
                    SaveTXFS(bConfirmed);
                    break;
            }
        }

        /// <summary>
        /// Saves the FEP.
        /// </summary>
        /// <param name="bConfirmed">if set to <c>true</c> [b confirmed].</param>
        private void SaveFEP(bool bConfirmed)
        {
            string sheaderid = string.Empty;
            for (int i = 0; i < dgvConfirmationList.Rows.Count; i++)
            {
                DataGridViewRow oRow = dgvConfirmationList.Rows[i];
                if (RT2020.DAL.Common.Utility.IsGUID(oRow.Cells[0].Value.ToString()))
                {
                    System.Guid detailId = new Guid(oRow.Cells[0].Value.ToString());

                    FepBatchDetail oDetail = FepBatchDetail.Load(detailId);
                    if (oDetail != null)
                    {
                        oDetail.CONFIRM_TRF_QTY = Convert.ToDecimal(oRow.Cells[8].Value);
                        oDetail.Save();
                    }
                }
            }

            FepBatchHeader oHeader = FepBatchHeader.Load(this.HeaderId);
            if (oHeader != null)
            {
                if (bConfirmed)
                {
                    oHeader.CONFIRM_TRF = "C";
                    oHeader.CONFIRM_TRF_LASTUPDATE = DateTime.Now;
                    oHeader.CONFIRM_TRF_LASTUSER = GetStaffNumber();
                }

                oHeader.ModifiedBy = Common.Utility.CurrentUserId;
                oHeader.ModifiedOn = DateTime.Now;
                oHeader.Save();

                // Update Ledger
            }
        }

        /// <summary>
        /// Saves the TXF Batch.
        /// </summary>
        /// <param name="bConfirmed">if set to <c>true</c> [b confirmed].</param>
        private void SaveTXFB(bool bConfirmed)
        {
            string sheaderid = string.Empty;
            for (int i = 0; i < dgvConfirmationList.Rows.Count; i++)
            {
                DataGridViewRow oRow = dgvConfirmationList.Rows[i];
                if (RT2020.DAL.Common.Utility.IsGUID(oRow.Cells[0].Value.ToString()))
                {
                    System.Guid detailId = new Guid(oRow.Cells[0].Value.ToString());

                    InvtBatchTXF_Details oDetail = InvtBatchTXF_Details.Load(detailId);
                    if (oDetail != null)
                    {
                        oDetail.QtyConfirmed = Convert.ToDecimal(oRow.Cells[8].Value);
                        oDetail.Save();
                    }
                }
            }

            InvtBatchTXF_Header oHeader = InvtBatchTXF_Header.Load(this.HeaderId);
            if (oHeader != null)
            {
                if (bConfirmed)
                {
                    oHeader.CONFIRM_TRF = "C";
                    oHeader.CONFIRM_TRF_LASTUSER = Common.Utility.CurrentUserId;
                    oHeader.CONFIRM_TRF_LASTUPDATE = DateTime.Now;
                }

                oHeader.ModifiedBy = Common.Utility.CurrentUserId;
                oHeader.ModifiedOn = DateTime.Now;
                oHeader.Save();
            }
        }

        /// <summary>
        /// Saves the TXF SubLedger.
        /// </summary>
        /// <param name="bConfirmed">if set to <c>true</c> [b confirmed].</param>
        private void SaveTXFS(bool bConfirmed)
        {
            string sheaderid = string.Empty;
            for (int i = 0; i < dgvConfirmationList.Rows.Count; i++)
            {
                DataGridViewRow oRow = dgvConfirmationList.Rows[i];
                if (RT2020.DAL.Common.Utility.IsGUID(oRow.Cells[0].Value.ToString()))
                {
                    System.Guid detailId = new Guid(oRow.Cells[0].Value.ToString());

                    InvtSubLedgerTXF_Details oDetail = InvtSubLedgerTXF_Details.Load(detailId);
                    if (oDetail != null)
                    {
                        oDetail.QtyConfirmed = Convert.ToDecimal(oRow.Cells[8].Value);
                        oDetail.Save();

                        if (bConfirmed)
                        {
                            // Update Ledger
                            string query = "SubLedgerHeaderId = '" + oDetail.HeaderId.ToString() + "'";
                            InvtLedgerHeader oLedgerHeader = InvtLedgerHeader.LoadWhere(query);
                            if (oLedgerHeader != null)
                            {
                                //Details
                                query = "HeaderId = '" + oLedgerHeader.HeaderId + "' AND ProductId = '" + oDetail.ProductId.ToString() + "'";
                                InvtLedgerDetails oLedgerDetail = InvtLedgerDetails.LoadWhere(query);
                                if (oLedgerDetail != null)
                                {
                                    //oLedgerDetail.QtyConfirmed = Convert.ToDecimal(oRow.Cells[9].Value);
                                    //oLedgerDetail.Save();
                                }
                            }
                        }
                    }
                }
            }

            InvtSubLedgerTXF_Header oHeader = InvtSubLedgerTXF_Header.Load(this.HeaderId);
            if (oHeader != null)
            {
                if (bConfirmed)
                {
                    oHeader.CONFIRM_TRF = "C";
                    oHeader.CONFIRM_TRF_LASTUSER = Common.Utility.CurrentUserId;
                    oHeader.CONFIRM_TRF_LASTUPDATE = DateTime.Now;
                }

                oHeader.ModifiedBy = Common.Utility.CurrentUserId;
                oHeader.ModifiedOn = DateTime.Now;
                oHeader.Save();

                // Update Ledger
                string query = "SubLedgerHeaderId = '" + oHeader.HeaderId.ToString() + "'";
                InvtLedgerHeader oLedgerHeader = InvtLedgerHeader.LoadWhere(query);
                if (oLedgerHeader != null)
                {
                    if (bConfirmed)
                    {
                    //    oLedgerHeader.CONFIRM_TRF = "C";
                    //    oLedgerHeader.CONFIRM_TRF_LASTUSER = Common.Utility.CurrentUserId;
                    //    oLedgerHeader.CONFIRM_TRF_LASTUPDATE = DateTime.Now;
                    }

                    oLedgerHeader.ModifiedBy = Common.Utility.CurrentUserId;
                    oLedgerHeader.ModifiedOn = DateTime.Now;
                    oLedgerHeader.Save();
                }
            }
        }

        /// <summary>
        /// Gets the staff number.
        /// </summary>
        /// <returns></returns>
        private string GetStaffNumber()
        {
            Staff oStaff = Staff.Load(Common.Utility.CurrentUserId);
            if (oStaff != null)
            {
                return oStaff.StaffNumber;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}