#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


using System.Windows.Forms;
using System.Data.SqlClient;
using RT2020.DAL;
using System.Configuration;
using RT2020.Client.Common;

#endregion

namespace RT2020.Client.Products.Wizard
{
    public partial class ProdCare_FindBatch : Form
    {
        public ProdCare_FindBatch()
        {
            InitializeComponent();

            SetSystemLabels();
        }

        #region Set System label
        private void SetSystemLabels()
        {
            lblStkCode.Text = Utility.GetSystemLabelByKey("STKCODE");
            lblAppendix1.Text = Utility.GetSystemLabelByKey("APPENDIX1");
            lblAppendix2.Text = Utility.GetSystemLabelByKey("APPENDIX2");
            lblAppendix3.Text = Utility.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion

        #region Properties
        private bool isCompleted = false;
        public bool IsCompleted
        {
            get
            {
                return isCompleted;
            }
            set
            {
                isCompleted = value;
            }
        }

        private Guid productBatchId = System.Guid.Empty;
        public Guid ProductBatchId
        {
            get
            {
                return productBatchId;
            }
            set
            {
                productBatchId = value;
            }
        }
        #endregion

        #region Bind Product List

        private void BindProductList()
        {
            this.dgProductBatchList.AutoGenerateColumns = false;
            string sql = BuildSqlQueryString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);

            this.dgProductBatchList.DataSource = ds.Tables[0];
        }

        #region Build Sql Query String
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT BatchId,  ROW_NUMBER() OVER (ORDER BY STKCODE) AS rownum, ");
            sql.Append(" STKCODE, APP1_COMBIN, APP2_COMBIN, APP3_COMBIN, Description ");
            sql.Append(" FROM ProductBatch ");
            sql.Append(" WHERE STATUS = 'HOLD' ");
            sql.Append(" AND (STKCODE LIKE '%").Append(txtStockCode.Text.Replace("*", "")).Append("%'");
            sql.Append(" OR APP1_COMBIN LIKE '%").Append(txtAppendix1.Text.Replace("*", "")).Append("%'");
            sql.Append(" OR APP2_COMBIN LIKE '%").Append(txtAppendix2.Text.Replace("*", "")).Append("%'");
            sql.Append(" OR APP3_COMBIN LIKE '%").Append(txtAppendix3.Text.Replace("*", "")).Append("%'");
            sql.Append(" OR Description LIKE '%").Append(txtProductName.Text.Replace("*", "")).Append("%')");

            return sql.ToString();
        }
        #endregion

        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            BindProductList();
        }

        void dgProductBatchList_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.dgProductBatchList.Rows[e.RowIndex];
            if (DAL.Common.Utility.IsGUID(selectedRow.Cells[0].Value.ToString()))
            {
                this.IsCompleted = true;
                this.ProductBatchId = new Guid(selectedRow.Cells[0].Value.ToString());
                this.Close();
            }
        }
    }
}