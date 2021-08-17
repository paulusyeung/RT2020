using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Helper;

namespace RT2020.Supplier.Reports
{
    public partial class SupplierListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public SupplierListRpt_Pdf()
        {
            InitializeComponent();
        }

        private void SupplierListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtSuppnum.DataBindings.Add("Text", DataSource, "SupplierCode");
            this.txtName.DataBindings.Add("Text", DataSource, "SupplierName");
            this.txtInitial.DataBindings.Add("Text", DataSource, "SupplierInitial");
            this.txtAddress.DataBindings.Add("Text", DataSource, "Address");
            this.txtTERMS.DataBindings.Add("Text", DataSource, "TermsCode");
            this.txtMktCode.DataBindings.Add("Text", DataSource, "MarketSectorCode");
            this.txtDateCreate.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtDateLchg.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtUserLChg.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.txtTel.DataBindings.Add("Text", DataSource, "Phone");
           // this.txtPSN.DataBindings.Add("Text",DataSource,"");
            this.txtTLX.DataBindings.Add("Text", DataSource, "Tlx");
            this.txtFax.DataBindings.Add("Text", DataSource, "Fax");
           // this.txtALTERNATE_SUPPNUM.DataBindings.Add("Text",DataSource,"");
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
