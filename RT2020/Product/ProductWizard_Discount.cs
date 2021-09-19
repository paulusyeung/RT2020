#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_Discount : UserControl
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

        public ProductWizard_Discount()
        {
            InitializeComponent();
        }

        private void ProductWizard_Discount_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

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

        #region SetCaptions
        private void SetCaptions()
        {
            lblFixedPrice.Text = WestwindHelper.GetWordWithColon("discount.fixedPrice", "Product");
            gbxDiscounts.Text = WestwindHelper.GetWord("discount.discounts", "Product");
            lblFixPriceItem.Text = WestwindHelper.GetWordWithColon("discount.fixedPriceItem", "Product");
            lblDiscountItem.Text = WestwindHelper.GetWordWithColon("discount.discountItem", "Product");
            lblNoDiscountItem.Text = WestwindHelper.GetWordWithColon("discount.noDiscountItem", "Product");
            lblStaff.Text = WestwindHelper.GetWordWithColon("staff", "Model");
        }

        private void SetAttributes()
        {

        }
        #endregion

        #region Load Data
        public void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductSupplement.Where(x => x.ProductId == this._ProductId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    chkFixedPrice.Checked = item.Product.FixedPriceItem;
                    txtFixPriceItem.Text = item.VipDiscount_FixedItem.ToString("n2");
                    txtDiscountItem.Text = item.VipDiscount_DiscountItem.ToString("n2");
                    txtNoDiscountItem.Text = item.VipDiscount_NoDiscountItem.ToString("n2");
                    txtStaffDiscount.Text = item.StaffDiscount.ToString("n2");
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
                var item = ctx.ProductSupplement.Where(x => x.ProductId == this._ProductId).FirstOrDefault();
                if (item == null)
                {
                    item = new EF6.ProductSupplement();

                    item.SupplementId = Guid.NewGuid();
                    item.ProductId = _ProductId;

                    ctx.ProductSupplement.Add(item);
                }
                item.Product.FixedPriceItem = chkFixedPrice.Checked;

                item.VipDiscount_FixedItem = DecimalHelper.StringToDecimal(txtFixPriceItem.Text);
                item.VipDiscount_DiscountItem = DecimalHelper.StringToDecimal(txtDiscountItem.Text);
                item.VipDiscount_NoDiscountItem = DecimalHelper.StringToDecimal(txtNoDiscountItem.Text);
                item.StaffDiscount = DecimalHelper.StringToDecimal(txtStaffDiscount.Text);

                ctx.SaveChanges();
            }

            return result;
        }
        #endregion
    }
}