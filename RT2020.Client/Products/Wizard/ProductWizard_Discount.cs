#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


using System.Windows.Forms;

#endregion

namespace RT2020.Client.Products .Wizard
{
    public partial class ProductWizard_Discount : UserControl
    {
        private Guid _ProductId = System.Guid.Empty;

        #region Public Properties
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

        public ProductWizard_Discount(Guid productId)
        {
            InitializeComponent();

            if (productId != System.Guid.Empty)
            {
                this.ProductId = productId;
                ShowRec();
            }
        }

        private void ShowRec()
        {
            DAL.Product oProduct = DAL.Product.Load(_ProductId);
            if (oProduct != null)
            {
                chkFixedPrice.Checked = oProduct.FixedPriceItem;
            }

            string sql = "ProductId = '" + _ProductId.ToString() + "'";
            DAL.ProductSupplement oProdSupp = DAL.ProductSupplement.LoadWhere(sql);
            if (oProdSupp != null)
            {
                this.txtDiscount1_FixPriceItem.Text = oProdSupp.VipDiscount_FixedItem.ToString("n2");
                this.txtDiscount2_DiscountItem.Text = oProdSupp.VipDiscount_DiscountItem.ToString("n2");
                this.txtDiscount3_NoDiscountItem.Text = oProdSupp.VipDiscount_NoDiscountItem.ToString("n2");
                this.txtStaff.Text = oProdSupp.StaffDiscount.ToString("n2");
            }
        }

        public bool SaveRec(Guid productId)
        {
            bool result = false;

            DAL.Product oProduct = DAL.Product.Load(productId);
            if (oProduct != null)
            {
                oProduct.FixedPriceItem = chkFixedPrice.Checked;
                oProduct.Save();

                string sql = "ProductId = '" + productId.ToString() + "'";
                DAL.ProductSupplement oProdSupp = DAL.ProductSupplement.LoadWhere(sql);
                if (oProdSupp == null)
                {
                    oProdSupp = new DAL.ProductSupplement();

                    oProdSupp.ProductId = productId;
                }

                oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((txtDiscount1_FixPriceItem.Text == string.Empty) ? "0" : txtDiscount1_FixPriceItem.Text);
                oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((txtDiscount2_DiscountItem.Text == string.Empty) ? "0" : txtDiscount2_DiscountItem.Text);
                oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((txtDiscount3_NoDiscountItem.Text == string.Empty) ? "0" : txtDiscount3_NoDiscountItem.Text);
                oProdSupp.StaffDiscount = Convert.ToDecimal((txtStaff.Text == string.Empty) ? "0" : txtStaff.Text);
                oProdSupp.Save();

                _ProductId = productId;
                result = true;
            }
            return result;
        }
    }
}