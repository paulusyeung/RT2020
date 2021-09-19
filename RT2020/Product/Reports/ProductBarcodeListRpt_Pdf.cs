using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Product.Reports
{
    public partial class ProductBarcodeListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public ProductBarcodeListRpt_Pdf()
        {
            InitializeComponent();

            SetSystemLabels();
        }

        private void ProductBarcodeListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtSTKCODE.DataBindings.Add("Text", DataSource, "STKCODE");
            this.txtAPPENDIX1.DataBindings.Add("Text", DataSource, "APPENDIX1");
            this.txtAPPENDIX2.DataBindings.Add("Text", DataSource, "APPENDIX2");
            this.txtAPPENDIX3.DataBindings.Add("Text", DataSource, "APPENDIX3");
            this.txtBARCODE.DataBindings.Add("Text", DataSource, "Barcode");
            this.txtTYPE.DataBindings.Add("Text", DataSource, "BarcodeType");
            this.txtDEFAULT.DataBindings.Add("Text", DataSource, "PrimaryBarcode");
            this.txtDesc.DataBindings.Add("Text", DataSource, "ProductName");
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

        #region Set System label
        private void SetSystemLabels()
        {
            lblSTK.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE");
            lblA1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            lblA2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2");
            lblA3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion
    }
}
