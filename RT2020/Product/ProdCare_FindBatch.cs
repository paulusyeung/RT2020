#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;
using RT2020.DAL;
using System.Configuration;
using RT2020.Helper;

#endregion

namespace RT2020.Product
{
    public partial class ProdCare_FindBatch : Form
    {
        public ProdCare_FindBatch()
        {
            InitializeComponent();
        }

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
            this.lvProductBatchList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvProductBatchList.Items.Add(reader.GetGuid(0).ToString()); // ProductId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // ProductCode
                    objItem.SubItems.Add(reader.GetString(3)); // APPENDIX1
                    objItem.SubItems.Add(reader.GetString(4)); // APPENDIX2
                    objItem.SubItems.Add(reader.GetString(5)); // APPENDIX3
                    objItem.SubItems.Add(reader.GetString(6)); // Product name

                    iCount++;
                }
            }
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

        private void lvProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProductBatchList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvProductBatchList.SelectedItem.Text))
                {
                    this.IsCompleted = true;
                    this.ProductBatchId = new Guid(lvProductBatchList.SelectedItem.Text);
                    this.Close();
                }
            }
        }
    }
}