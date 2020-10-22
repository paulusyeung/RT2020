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
    public partial class ProdCare_FindProd : Form
    {
        public ProdCare_FindProd()
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

            colStockCode.HeaderText = Utility.GetSystemLabelByKey("STKCODE");
            colAppendix1.HeaderText = Utility.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.HeaderText = Utility.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.HeaderText = Utility.GetSystemLabelByKey("APPENDIX3");
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

        private Guid productId = System.Guid.Empty;
        public Guid ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }
        #endregion

        #region Bind Product List

        private void BindProductList()
        {
            this.lvProductList.AutoGenerateColumns = false;

            string sql = BuildSqlQueryString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);

            this.lvProductList.DataSource = ds.Tables[0];
        }

        #region Build Sql Query String
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ProductId,  ROW_NUMBER() OVER (ORDER BY STKCODE) AS rownum, ");
            sql.Append(" STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName ");
            sql.Append(" FROM vwProductList ");
            sql.Append(" WHERE ");

            if (!string.IsNullOrEmpty(txtStockCode.Text))
            {
                sql.Append(" STKCODE LIKE '%").Append(txtStockCode.Text.Replace("*", "")).Append("%'");
            }
            if (!string.IsNullOrEmpty(txtAppendix1.Text))
            {
                sql.Append(" AND APPENDIX1 LIKE '%").Append(txtAppendix1.Text.Replace("*", "")).Append("%'");
            }
            if (!string.IsNullOrEmpty(txtAppendix2.Text))
            {
                sql.Append(" AND APPENDIX2 LIKE '%").Append(txtAppendix2.Text.Replace("*", "")).Append("%'");
            }
            if (!string.IsNullOrEmpty(txtAppendix3.Text))
            {
                sql.Append(" AND APPENDIX3 LIKE '%").Append(txtAppendix3.Text.Replace("*", "")).Append("%'");
            }
            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                sql.Append(" AND ProductName LIKE '%").Append(txtProductName.Text.Replace("*", "")).Append("%'");
            }

            sql.Append(" ORDER BY STKCODE, APPENDIX1, APPENDIX2, APPENDIX3");

            return sql.ToString();
        }
        #endregion

        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            BindProductList();
        }

        void lvProductList_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = this.lvProductList.Rows[e.RowIndex];
            if (DAL.Common.Utility.IsGUID(selectedRow.Cells[0].Value.ToString()))
            {
                this.IsCompleted = true;
                this.ProductId = new Guid(selectedRow.Cells[0].Value.ToString());
                this.Close();
            }
        }
    }
}