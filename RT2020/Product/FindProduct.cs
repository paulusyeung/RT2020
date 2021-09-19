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
using System.Linq;

#endregion

namespace RT2020.Product
{
    public partial class FindProduct : Form
    {
        #region public Properties
        private bool isCompleted = false;
        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }

        private Guid productId = System.Guid.Empty;
        public Guid ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        #endregion

        public FindProduct()
        {
            InitializeComponent();
        }

        private void FindProd_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            txtStockCode.Focus();
            txtStockCode.SelectAll();
        }

        #region SetCaptions, SetAttributes
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("general.findProduct", "Product");

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
            colProductName.Text = WestwindHelper.GetWord("general.name", "Product");
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
            colProductName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colProductName.TextAlign = HorizontalAlignment.Left;
            #endregion
        }
        #endregion

        #region Bind Product List

        private void BindProductList()
        {
            this.lvProductList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();
            /**
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
            */
            using (var ctx = new EF6.RT2020Entities())
            {
                var where = sql.Substring(sql.IndexOf("WHERE"));
                var list = ctx.Product
                    .SqlQuery(string.Format("Select * from Product {0}", where))
                    .AsNoTracking()
                    .ToList();
                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvProductList.Items.Add(item.ProductId.ToString()); // ProductId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.STKCODE); // ProductCode
                    objItem.SubItems.Add(item.APPENDIX1); // APPENDIX1
                    objItem.SubItems.Add(item.APPENDIX2); // APPENDIX2
                    objItem.SubItems.Add(item.APPENDIX3); // APPENDIX3
                    objItem.SubItems.Add(item.ProductName); // Product name

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

            if (lvProductList.Items.Count == 0)
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