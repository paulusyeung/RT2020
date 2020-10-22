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
    public partial class ConfirmationWizard : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationWizard"/> class.
        /// </summary>
        public ConfirmationWizard()
        {
            InitializeComponent();
        }

        #region Properties
        /// <summary>
        /// Header id
        /// </summary>
        private Guid headerId = System.Guid.Empty;

        private Guid FromLocation = System.Guid.Empty;

        /// <summary>
        /// Gets or sets the header id.
        /// </summary>
        /// <value>The header id.</value>
        public Guid HeaderId
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
        #endregion

        private void ConfirmationWizard_Load(object sender, EventArgs e)
        {
            GetSystemLabels();
            LoadHeaderInfo();
            BindData();
            CalcAcutalQty();
        }

        /// <summary>
        /// Gets the system labels.
        /// </summary>
        private void GetSystemLabels()
        {
            dataGridViewTextBoxColumn1.HeaderText = Common.Utility.GetSystemLabelByKey("STKCODE");
            dataGridViewTextBoxColumn2.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX1");
            dataGridViewTextBoxColumn3.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX2");
            dataGridViewTextBoxColumn4.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX3");

            dataGridViewTextBoxColumn5.CellTemplate.Style.Format = "n0";
            dataGridViewTextBoxColumn6.CellTemplate.Style.Format = "n0";
            dataGridViewTextBoxColumn7.CellTemplate.Style.Format = "n0";
        }

        #region Bind data
        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData()
        {
            dgvConfirmationList.AutoGenerateColumns = false;

            string query = @"
SELECT     TOP (100) PERCENT rd.DetailsId, rd.HeaderId, rd.TxNumber, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, ISNULL
                          ((SELECT     CDQTY
                              FROM         dbo.ProductWorkplace AS frompw
                              WHERE     (ProductId = rd.ProductId) AND (WorkplaceId = '" + this.FromLocation.ToString() + @"')), 0) AS From_CDQTY, rd.QtyRequested, rd.QtyIssued AS ActualQty
FROM         dbo.InvtBatchRPL_Details AS rd LEFT OUTER JOIN dbo.Product AS p ON rd.ProductId = p.ProductId
WHERE     (rd.HeaderId = '" + this.HeaderId.ToString() + @"')
ORDER BY p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                dgvConfirmationList.DataSource = dataset.Tables[0];
            }
        }
        #endregion

        #region Load
        /// <summary>
        /// Loads the header info.
        /// </summary>
        private void LoadHeaderInfo()
        {
            InvtBatchRPL_Header oHeader = InvtBatchRPL_Header.Load(this.HeaderId);
            if (oHeader != null)
            {
                ShowFromLocation(oHeader.FromLocation);
                txtTxNumber.Text = oHeader.TxNumber;
            }
        }

        /// <summary>
        /// Shows from location.
        /// </summary>
        private void ShowFromLocation(string workplaceCode)
        {
            string query = "WorkplaceCode = '" + workplaceCode + "'";
            Workplace oWp = Workplace.LoadWhere(query);
            if (oWp != null)
            {
                this.FromLocation = oWp.WorkplaceId;
                txtFromLocation.Text = oWp.WorkplaceCode + " - " + oWp.WorkplaceName;
            }
            else
            {
                txtFromLocation.Text = string.Empty;
            }
        }

        /// <summary>
        /// Calcs the acutal qty.
        /// </summary>
        private void CalcAcutalQty()
        {
            decimal actualQty = 0;

            for (int i = 0; i < dgvConfirmationList.Rows.Count; i++)
            {
                DataGridViewRow oRow = dgvConfirmationList.Rows[i];

                actualQty += Convert.ToDecimal(oRow.Cells[9].Value);
            }

            txtTotalActualQty.Text = actualQty.ToString("n0");
        }
        #endregion

        #region Save
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save(bool bConfirmed)
        {
            string sheaderid = string.Empty;
            for (int i = 0; i < dgvConfirmationList.Rows.Count; i++)
            {
                DataGridViewRow oRow = dgvConfirmationList.Rows[i];
                if (RT2020.DAL.Common.Utility.IsGUID(oRow.Cells[0].Value.ToString()))
                {
                    System.Guid detailId = new Guid(oRow.Cells[0].Value.ToString());

                    InvtBatchRPL_Details oDetail = InvtBatchRPL_Details.Load(detailId);
                    if (oDetail != null)
                    {
                        oDetail.QtyIssued = Convert.ToDecimal(oRow.Cells[9].Value);
                        oDetail.Save();
                    }
                }
            }

            InvtBatchRPL_Header oHeader = InvtBatchRPL_Header.Load(this.HeaderId);
            if (oHeader != null)
            {
                if (bConfirmed)
                {
                    oHeader.Confirmed = true;
                    oHeader.ConfirmedBy = Common.Utility.CurrentUserId;
                    oHeader.ConfirmedOn = DateTime.Now;
                }

                oHeader.ModifiedBy = Common.Utility.CurrentUserId;
                oHeader.ModifiedOn = DateTime.Now;
                oHeader.Save();
            }
        }

        #endregion

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

                oRow.Cells[9].Value = "1";
            }

            CalcAcutalQty();
        }

        /// <summary>
        /// Handles the Click event of the btnRefresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CalcAcutalQty();
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
                    this.CalcAcutalQty();

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
    }
}