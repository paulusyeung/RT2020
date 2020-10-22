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

namespace RT2020.Web.Shop.Transfer
{
    public partial class InTransitWizard : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InTransitWizard"/> class.
        /// </summary>
        public InTransitWizard()
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
        /// <summary>
        /// Gets the system labels.
        /// </summary>
        private void GetSystemLabels()
        {
            colSTKCODE.Text = Common.Utility.GetSystemLabelByKey("STKCODE");
            colAppendix1.Text = Common.Utility.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.Text = Common.Utility.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.Text = Common.Utility.GetSystemLabelByKey("APPENDIX3");
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

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.listView.Items.Add(reader.GetGuid(0).ToString());
                    objItem.SubItems.Add(reader.GetInt32(2).ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(4));
                    objItem.SubItems.Add(reader.GetString(5));
                    objItem.SubItems.Add(reader.GetString(6));
                    objItem.SubItems.Add(reader.GetString(7));
                    objItem.SubItems.Add(reader.GetDecimal(8).ToString("n0"));
                    objItem.SubItems.Add(reader.GetDecimal(9).ToString("n0"));
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

            switch (this.txtType.Text.Trim())
            {
                case "SHOP":
                    query = @"
SELECT     fd.DetailsId, fd.HeaderId, fd.LineNumber, fd.ProductId, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, 
            (SELECT CDQTY FROM ProductWorkplace WHERE WorkplaceId = '" + fromLoc.ToString() + @"' AND ProductId = p.ProductId) AS CDQTY, fd.QTY
FROM         dbo.FepBatchDetail AS fd LEFT OUTER JOIN dbo.Product AS p ON fd.ProductId = p.ProductId
WHERE       fd.HeaderId = '" + this.HeaderId.ToString() + "' ORDER BY fd.LineNumber";
                    break;

                case "WH":
                    query = @"
SELECT     td.DetailsId, td.HeaderId, td.LineNumber, td.ProductId, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, 
            (SELECT CDQTY FROM ProductWorkplace WHERE WorkplaceId = '" + fromLoc.ToString() + @"' AND ProductId = p.ProductId) AS CDQTY, td.QtyRequested
FROM         dbo.InvtBatchTXF_Details AS td LEFT OUTER JOIN dbo.Product AS p ON td.ProductId = p.ProductId
WHERE       td.HeaderId = '" + this.HeaderId.ToString() + "' ORDER BY td.LineNumber";
                    break;

                case "WH A":
                    query = @"
SELECT     td.DetailsId, td.HeaderId, td.LineNumber, td.ProductId, p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, 
            (SELECT CDQTY FROM ProductWorkplace WHERE WorkplaceId = '" + fromLoc.ToString() + @"' AND ProductId = p.ProductId) AS CDQTY, td.QtyRequested
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
    }
}