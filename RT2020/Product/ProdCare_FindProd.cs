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

using System.Configuration;
using RT2020.Helper;

#endregion

namespace RT2020.Product
{
    public partial class ProdCare_FindProd : Form
    {
        public ProdCare_FindProd()
        {
            InitializeComponent();

            SetSystemLabels();
        }

        private void ProdCare_FindProd_Load(object sender, EventArgs e)
        {
            txtStockCode.Focus();
            txtStockCode.SelectAll();
        }

        #region System Labels
        /// <summary>
        /// Sets the system labels.
        /// </summary>
        private void SetSystemLabels()
        {
            lblStkCode.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            lblAppendix1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            lblAppendix2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            lblAppendix3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");

            colStockCode.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            colAppendix1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
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
            this.lvProductList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvProductList.Items.Add(reader.GetGuid(0).ToString()); // ProductId
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

        private void lvProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProductList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvProductList.SelectedItem.Text, out id))
                {
                    this.IsCompleted = true;
                    this.ProductId = id;
                    this.Close();
                }
            }
        }
    }
}