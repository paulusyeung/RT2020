using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Product.Reports
{
    public partial class PaymentListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public PaymentListRpt_Pdf()
        {
            InitializeComponent();
        }

        private void PayMentListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtCharge_Amount.DataBindings.Add("Text", DataSource, "ChargeAmount", "{0:n2}");
            this.txtDESC.DataBindings.Add("Text", DataSource, "TypeName");
            this.txtCharge_Month_Add.DataBindings.Add("Text", DataSource, "AdditionalMonthlyCharge", "{0:n2}");
            this.txtCharge_Month_Min.DataBindings.Add("Text", DataSource, "MinimumMonthlyCharge", "{0:n2}");
            this.txtCharge_Rate.DataBindings.Add("Text", DataSource, "ChargeRate", "{0:n2}");
            //this.txtChargeWay.DataBindings.Add("Text",DataSource,"");
            this.txtCurr.DataBindings.Add("Text", DataSource, "CurrencyCode");
            this.txtDateCreate.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtDateLchg.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtUserLchg.DataBindings.Add("Text", DataSource, "StaffName");
           // this.txtMonthCharge.DataBindings.Add("Text",DataSource,"");
            this.txtPayType.DataBindings.Add("Text", fDataBrowser, "TypeCode");     // refer: https://supportcenter.devexpress.com/ticket/details/q482879/xtrareport-databrowser-error-after-upgrading
            this.txtXChgRate.DataBindings.Add("Text", fDataBrowser, "ExchangeRate", "{0:n4}");
            this.txtPrint.Text = DateTimeHelper.DateTimeToString(System.DateTime.Now, true);
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
