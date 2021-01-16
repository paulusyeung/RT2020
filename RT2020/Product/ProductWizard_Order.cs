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
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Product
{
    /// <summary>
    /// Part of Product Wizard: Order
    /// </summary>
    public partial class ProductWizard_Order : UserControl
    {
        #region Public Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _ProductId = Guid.Empty;
        public Guid ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductWizard_Order"/> class.
        /// </summary>
        /// <param name="productId">The product id.</param>
        public ProductWizard_Order()
        {
            InitializeComponent();
        }

        private void ProductWizard_Order_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            BindPOHistory();

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadData();
                    break;
            }
        }

        #region SetCaptions SetAttributes
        private void SetCaptions()
        {
            lblVendorItemNum.Text = WestwindHelper.GetWordWithColon("order.vendorItemNumber", "Product");
            lblReorderLevel.Text = WestwindHelper.GetWordWithColon("order.reorderLevel", "Product");
            lblReorderQuantity.Text = WestwindHelper.GetWordWithColon("order.reorderQty", "Product");
            lblPurchaseHistory.Text = WestwindHelper.GetWordWithColon("order.purchaseHistory", "Product");

            colRecDate.Text = WestwindHelper.GetWord("purchase.receivedOn", "Transaction");
            colSuppNumber.Text = WestwindHelper.GetWord("supplier.number", "Model");
            colSuppName.Text = WestwindHelper.GetWord("supplier.name", "Model");
            colTxNumber.Text = WestwindHelper.GetWord("transaction.number", "Transaction");
            colPONumber.Text = WestwindHelper.GetWord("purchase.orderNumber", "Transaction");
            colCost.Text = WestwindHelper.GetWord("purchase.cost", "Transaction");
            colNetCost.Text = WestwindHelper.GetWord("purchase.netCost", "Transaction");
        }

        private void SetAttributes()
        {
            colRecDate.TextAlign = HorizontalAlignment.Left;
            colRecDate.ContentAlign = ExtendedHorizontalAlignment.Center;
            colSuppNumber.TextAlign = HorizontalAlignment.Left;
            colSuppNumber.ContentAlign = ExtendedHorizontalAlignment.Center;
            colSuppName.TextAlign = HorizontalAlignment.Left;
            colSuppName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTxNumber.TextAlign = HorizontalAlignment.Left;
            colTxNumber.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPONumber.TextAlign = HorizontalAlignment.Left;
            colPONumber.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCost.TextAlign = HorizontalAlignment.Left;
            colCost.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNetCost.TextAlign = HorizontalAlignment.Left;
            colNetCost.ContentAlign = ExtendedHorizontalAlignment.Center;
        }
        #endregion

        #region Load Data
        public void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Product.Where(x => x.ProductId == _ProductId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    txtVendorItemNum.Text = item.AlternateItem; // Vendor Item Number
                    txtReorderLevel.Text = item.ReorderLevel.ToString("n0");
                    txtReorderQuantity.Text = item.ReorderQty.Value.ToString("n0");
                }
            }
        }
        #endregion

        #region Save Data
        public bool SaveData()
        {
            var result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Product.Where(x => x.ProductId == _ProductId).FirstOrDefault();
                if (item != null)
                {
                    item.AlternateItem = txtVendorItemNum.Text.Trim();
                    item.ReorderLevel = DecimalHelper.StringToDecimal(txtReorderLevel.Text);
                    item.ReorderQty = DecimalHelper.StringToDecimal(txtReorderQuantity.Text);

                    ctx.SaveChanges();
                }
            }

            return result;
        }
        #endregion

        /// <summary>
        /// Binds the PO history.
        /// </summary>
        private void BindPOHistory()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = BuildQueryString();
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvPurchaseHistory.Items.Add(reader.GetDateTime(0).ToString(RT2020.SystemInfo.Settings.GetDateFormat())); // TxDate
                    objItem.SubItems.Add(reader.GetString(1)); // Supplier Code
                    objItem.SubItems.Add(reader.GetString(2)); // Supplier Name
                    objItem.SubItems.Add(reader.GetString(3)); // TxNumber
                    objItem.SubItems.Add(reader.GetString(4)); // OrderNumber
                    objItem.SubItems.Add(reader.GetDecimal(5).ToString("n2")); // UnitCost
                    objItem.SubItems.Add(reader.GetDecimal(6).ToString("n2")); // NetUnitCost 
                }
            }
        }

        /// <summary>
        /// Builds the query string.
        /// </summary>
        /// <returns></returns>
        private string BuildQueryString()
        {
            string query = @"SELECT [TxDate],[SupplierCode],[SupplierName],[TxNumber],[OrderNumber],[UnitCost],[NetUnitCost]
                            FROM [vwProductPOHistory]
                            WHERE ProductId = '" + _ProductId.ToString() + @"'
                            ORDER BY [TxDate]";

            return query;
        }
    }
}