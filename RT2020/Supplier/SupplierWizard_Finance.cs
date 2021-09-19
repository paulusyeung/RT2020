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
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierWizard_Finance : UserControl
    {
        #region Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _SupplierId = System.Guid.Empty;
        public Guid SupplierId
        {
            get { return _SupplierId; }
            set { _SupplierId = value; }
        }
        #endregion

        public SupplierWizard_Finance()
        {
            InitializeComponent();
        }

        private void SupplierWizard_Finance_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            FillComboList();
        }

        #region SetCaptions, SetAttributes & SetSmartTags
        private void SetCaptions()
        {
            lblCreditLimit.Text = WestwindHelper.GetWordWithColon("supplierFinance.creditLimit", "Model");
            lblTerms.Text = WestwindHelper.GetWordWithColon("supplierFinance.terms", "Model");
            lblCurrency.Text = WestwindHelper.GetWordWithColon("supplierFinance.currency", "Model");
            lblBFAmount.Text = WestwindHelper.GetWordWithColon("supplierFinance.bfAmount", "Model");
            lblCDAmount.Text = WestwindHelper.GetWordWithColon("supplierFinance.cdAmount", "Model");
            lblLastPurchasedOn.Text = WestwindHelper.GetWordWithColon("supplierFinance.lastPurchase", "Model");
            lblLastPaidOn.Text = WestwindHelper.GetWordWithColon("supplierFinance.lastPay", "Model");
            lblLastReturnedOn.Text = WestwindHelper.GetWordWithColon("supplierFinance.lastReturned", "Model");

            gbDiscount.Text = WestwindHelper.GetWord("supplierFinance.discount", "Model");
            lblNormalDiscount.Text = WestwindHelper.GetWordWithColon("supplierFinance.discount.regular", "Model");
            lblWholesalesDiscount.Text = WestwindHelper.GetWordWithColon("supplierFinance.discount.wholesale", "Model");
            lblQuotaDiscount.Text = WestwindHelper.GetWordWithColon("supplierFinance.discount.quota", "Model");
            lblYearEndBonus.Text = WestwindHelper.GetWordWithColon("supplierFinance.discount.yearend", "Model");
            lblCashDiscount.Text = WestwindHelper.GetWordWithColon("supplierFinance.discount.cash", "Model");
            lblOthersDiscount.Text = WestwindHelper.GetWordWithColon("supplierFinance.discount.others", "Model");
        }

        private void SetAttributes()
        {
            #region 設定 clickable Currency label
            lblCurrency.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblCurrency.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblCurrency.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.CurrencyWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillCurrencyList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Terms label
            lblTerms.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblTerms.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblTerms.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new SupplierTermsWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillTermsList();
                };
                dialog.ShowDialog();
            };
            #endregion
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillTermsList();
            FillCurrencyList();
        }

        private void FillTermsList()
        {
            SupplierTermsEx.LoadCombo(ref cboTerms, "TermsCode", false, true, String.Empty, String.Empty);
        }

        private void FillCurrencyList()
        {
            CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false, true, String.Empty, String.Empty);
        }
        #endregion

        #region LoadFinanceData & SaveFinanceData
        public void LoadFinanceData()
        {
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    if (_SupplierId != Guid.Empty)
                    {
                        LoadFinance();
                    }
                    break;
            }
        }

        private void LoadFinance()
        { 
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Supplier.Find(_SupplierId);
                if (item != null)
                {
                    cboTerms.SelectedValue = item.TermsId;
                    txtCreditLimit.Text = item.CreditAmount.ToString("n2");
                    txtNormalDiscount.Text = item.NormalDiscount.ToString("n2");
                    txtWholesalesDiscount.Text = item.WholesaleDiscount.ToString("n2");
                    txtQuotaDiscount.Text = item.QuotaDiscount.ToString("n2");
                    txtYearEndBonus.Text = item.YearEndDiscount.ToString("n2");
                    txtCashDiscount.Text = item.CashDiscount.ToString("n2");
                    txtOthersDiscount.Text = item.OtherDiscount.ToString("n2");
                    cboCurrency.Text = item.CurrencyCode;
                    txtBFAmount.Text = item.BFBAL.ToString("n2");
                    txtCDAmount.Text = item.CDBAL.ToString("n2");
                    if (item.DateLastPurchase.HasValue) datLastPurchased.Value = item.DateLastPurchase.Value;
                    if (item.DateLastPay.HasValue) datLastPaid.Value = item.DateLastPay.Value;
                    if (item.DateLastReturn.HasValue) datLastReturned.Value = item.DateLastReturn.Value;
                }
            }
        }

        public bool SaveFinanceData()
        {
            var result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Supplier.Find(_SupplierId);
                if (item != null)
                {
                    #region prepare the decimal input fields
                    decimal bfAmount = 0, cdAmount = 0;
                    decimal creditLimit = 0, normalDiscount = 0, wholesaleDiscount = 0, quotaDiscount = 0, yearendDiscount = 0, cashDiscount = 0, othersDiscount = 0;

                    decimal.TryParse(txtCreditLimit.Text, out creditLimit);
                    decimal.TryParse(txtBFAmount.Text, out bfAmount);
                    decimal.TryParse(txtCDAmount.Text, out cdAmount);

                    decimal.TryParse(txtNormalDiscount.Text, out normalDiscount);
                    decimal.TryParse(txtWholesalesDiscount.Text, out wholesaleDiscount);
                    decimal.TryParse(txtQuotaDiscount.Text, out quotaDiscount);
                    decimal.TryParse(txtYearEndBonus.Text, out yearendDiscount);
                    decimal.TryParse(txtCashDiscount.Text, out cashDiscount);
                    decimal.TryParse(txtOthersDiscount.Text, out othersDiscount);
                    #endregion

                    item.CreditAmount = creditLimit;
                    item.CurrencyCode = cboCurrency.Text;
                    if ((Guid)cboTerms.SelectedValue != Guid.Empty) item.TermsId = (Guid)cboTerms.SelectedValue;

                    item.BFBAL = bfAmount;
                    item.CDBAL = cdAmount;
                    if (datLastPurchased.Checked) item.DateLastPurchase = datLastPurchased.Value;
                    if (datLastPaid.Checked) item.DateLastPay = datLastPaid.Value;
                    if (datLastReturned.Checked) item.DateLastReturn = datLastReturned.Value;

                    item.NormalDiscount = normalDiscount;
                    item.WholesaleDiscount = wholesaleDiscount;
                    item.QuotaDiscount = quotaDiscount;
                    item.YearEndDiscount = yearendDiscount;
                    item.CashDiscount = cashDiscount;
                    item.OtherDiscount = othersDiscount;

                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
        #endregion
    }
}