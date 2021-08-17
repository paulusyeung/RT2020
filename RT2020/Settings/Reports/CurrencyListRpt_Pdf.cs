using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Helper;

namespace RT2020.Settings.Reports
{
    public partial class CurrencyListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public CurrencyListRpt_Pdf()
        {
            InitializeComponent();
        }

        private void CurrencyListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtCurr.DataBindings.Add("Text", DataSource, "CurrencyCode");
            this.txtCountry.DataBindings.Add("Text", DataSource, "CountryName");
            this.txtDESC.DataBindings.Add("Text", DataSource, "CurrencyName");
            this.txtDateCreate.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtDateLchg.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtUserLchg.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.txtXChgRate.DataBindings.Add("Text", DataSource, "ExchangeRate", "{0:n4}");
            this.txtPrint.Text = DateTimeHelper.DateTimeToString(DateTime.Now, true);
        }

        #region Attribute
        public string FrmCode
        {
            get
            {
                return _frmCode;
            }
            set
            {
                _frmCode = value;
            }
        }

        public string toCode
        {
            get
            {
                return _toCode;
            }
            set
            {
                _toCode = value;
            }
        }

        #endregion

    }
}
