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
using RT2020.Common.Helper;

#endregion

namespace RT2020.Product
{
    public partial class FindBatch : Form
    {
        #region public Properties
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

        public FindBatch()
        {
            InitializeComponent();
        }

        private void FindBatch_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            txtStockCode.Focus();
            txtStockCode.SelectAll();
        }

        #region SetCaptions, SetAttributes
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("general.findBatch", "Product");

            lblStkCode.Text = WestwindHelper.GetWordWithColon("general.STKCODE", "Product");
            lblAppendix1.Text = WestwindHelper.GetWordWithColon("appendix.appendix1", "Product");
            lblAppendix2.Text = WestwindHelper.GetWordWithColon("appendix.appendix2", "Product");
            lblAppendix3.Text = WestwindHelper.GetWordWithColon("appendix.appendix3", "Product");
            lblProductName.Text = WestwindHelper.GetWordWithColon("general.name", "Product");

            btnFind.Text = WestwindHelper.GetWord("glossary.find", "General");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colStockCode.Text = WestwindHelper.GetWord("general.STKCODE", "Product");
            colAppendix1.Text = WestwindHelper.GetWord("appendix.appendix1", "Product");
            colAppendix2.Text = WestwindHelper.GetWord("appendix.appendix2", "Product");
            colAppendix3.Text = WestwindHelper.GetWord("appendix.appendix3", "Product");
            colDescription.Text = WestwindHelper.GetWord("general.name", "Product");
        }

        private void SetAttributes()
        {
            #region listview layout
            colLN.ContentAlign = ExtendedHorizontalAlignment.Center;
            colLN.TextAlign = HorizontalAlignment.Center;
            colStockCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStockCode.TextAlign = HorizontalAlignment.Left;
            colAppendix1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colAppendix1.TextAlign = HorizontalAlignment.Left;
            colAppendix2.ContentAlign = ExtendedHorizontalAlignment.Center;
            colAppendix2.TextAlign = HorizontalAlignment.Left;
            colAppendix3.ContentAlign = ExtendedHorizontalAlignment.Center;
            colAppendix3.TextAlign = HorizontalAlignment.Left;
            colDescription.ContentAlign = ExtendedHorizontalAlignment.Center;
            colDescription.TextAlign = HorizontalAlignment.Left;
            #endregion
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
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

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

            if (lvProductBatchList.Items.Count == 0)
            {
                MessageBox.Show(
                    WestwindHelper.GetWordWithQuestionMark("dialog.noRecordFound", "General"),
                    WestwindHelper.GetWord("dialog.information", "General"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }

        private void lvProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProductBatchList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvProductBatchList.SelectedItem.Text, out id))
                {
                    this.IsCompleted = true;
                    this.ProductBatchId = id;
                    this.Close();
                }
            }
        }
    }
}