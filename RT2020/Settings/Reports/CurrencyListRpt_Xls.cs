using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Settings.Reports
{
    public partial class CurrencyListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;
        public CurrencyListRpt_Xls()
        {
            InitializeComponent();
        }

        private void CurrencyListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrFm1.Text = _frmCode;
            this.hdrTo1.Text = _toCode;
            this.CURR1.DataBindings.Add("Text", DataSource, "CurrencyCode");
            this.txtCountry.DataBindings.Add("Text", DataSource, "CountryName");
            this.DESC1.DataBindings.Add("Text", DataSource, "CurrencyName");   
            this.DATECREATE1.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.DATELCHG1.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.USERLCHG1.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.XCHGRATE1.DataBindings.Add("Text", DataSource, "ExchangeRate", "{0:n4}");
            this.PrintDate1.Text = DateTimeHelper.DateTimeToString(DateTime.Now, true);
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
