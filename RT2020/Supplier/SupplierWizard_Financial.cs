#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierWizard_Financial : UserControl
    {
        public SupplierWizard_Financial()
        {
            InitializeComponent();
            FillComboList();
        }

        #region Properties
        private Guid supplierId = System.Guid.Empty;
        public Guid SupplierId
        {
            get
            {
                return supplierId;
            }
            set
            {
                supplierId = value;
            }
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
            cboTerms.Items.Clear();

            ModelEx.SupplierTermsEx.LoadCombo(ref cboTerms, "TermsCode", false, true, String.Empty, String.Empty);
            cboTerms.SelectedIndex = 0;
        }

        private void FillCurrencyList()
        {
            cboCurrency.Items.Clear();

            ModelEx.CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false, true, String.Empty, String.Empty);
            cboCurrency.SelectedIndex = 0;
        }
        #endregion
    }
}