#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


using System.Windows.Forms;
using RT2020.DAL;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace RT2020.Client.Products .Wizard
{
    /// <summary>
    /// Part of Product Wizard: Order
    /// </summary>
    public partial class ProductWizard_Order : UserControl
    {
        private Guid _ProductId = System.Guid.Empty;

        #region Properties
        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>The product id.</value>
        public Guid ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
            }
        }
        #endregion

        public ProductWizard_Order(Guid productId)
        {
            InitializeComponent();

            if (productId != System.Guid.Empty)
            {
                _ProductId = productId;

                ShowRec();
                BindPOHistory();
            }
        }

        private void ShowRec()
        {
            DAL.Product oProduct = DAL.Product.Load(_ProductId);
            if (oProduct != null)
            {
                txtVendorItemNum.Text   = oProduct.AlternateItem; // Vendor Item Number
                txtReorderLevel.Text    = oProduct.ReorderLevel.ToString("n0");
                txtReorderQuantity.Text = oProduct.ReorderQty.ToString("n0");
            }
        }

        public bool SaveRec(Guid productId)
        {
            bool result = false;

            RT2020.DAL.Product oProduct = RT2020.DAL.Product.Load(productId);
            if (oProduct != null)
            {
                oProduct.AlternateItem = txtVendorItemNum.Text; // Vendor Item Number
                oProduct.ReorderLevel  = Convert.ToDecimal((txtReorderLevel.Text == String.Empty) ? "0" : txtReorderLevel.Text);
                oProduct.ReorderQty    = Convert.ToDecimal((txtReorderQuantity.Text == String.Empty) ? "0" : txtReorderQuantity.Text);

                oProduct.ModifiedBy = RT2020.DAL.Common.Config.CurrentUserId;
                oProduct.ModifiedOn = DateTime.Now;
                oProduct.Save();

                _ProductId = productId;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Binds the PO history.
        /// </summary>
        private void BindPOHistory()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = BuildQueryString();
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);

            this.lvPurchaseHistory.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// Builds the query string.
        /// </summary>
        /// <returns></returns>
        private string BuildQueryString()
        {
            string query = @"SELECT [TxDate],[SupplierCode],[SupplierName],[TxNumber],[OrderNumber],[UnitCost],[NetUnitCost]
                            FROM [vwProductPOHistory]
                            WHERE ProductId = '" + this.ProductId.ToString() + @"'
                            ORDER BY [TxDate]";

            return query;
        }
    }
}