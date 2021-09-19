using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Supplier.Reports
{
    public partial class SupplierListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public SupplierListRpt_Xls()
        {
            InitializeComponent();
        }


        private void SupplierListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrFm1.Text = _frmCode;
            this.hdrTo1.Text = _toCode;
            this.SUPPNUM1.DataBindings.Add("Text", DataSource, "SupplierCode");
            this.NAME1.DataBindings.Add("Text", DataSource, "SupplierName");
            this.INITIAL1.DataBindings.Add("Text", DataSource, "SupplierInitial");
            this.ADDRESS.DataBindings.Add("Text", DataSource, "Address");
            this.TERMS1.DataBindings.Add("Text", DataSource, "TermsCode");
            this.MKTCODE1.DataBindings.Add("Text", DataSource, "MarketSectorCode");
            this.DATECREATE1.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.DATELCHG1.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.USERLCHG1.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.TEL1.DataBindings.Add("Text", DataSource, "Phone");
           // this.PSN1.DataBindings.Add("Text",DataSource,"");
            this.TLX1.DataBindings.Add("Text", DataSource, "Tlx");
            this.FAX1.DataBindings.Add("Text", DataSource, "Fax");
           // this.ALTERNATESUPPNUM1.DataBindings.Add("Text",DataSource,"");
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
