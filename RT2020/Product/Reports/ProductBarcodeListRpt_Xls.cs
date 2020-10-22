using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Product.Reports
{
    public partial class ProductBarcodeListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public ProductBarcodeListRpt_Xls()
        {
            InitializeComponent();

            SetSystemLabels();
        }

        private void ProductBarcodeListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.PHFrom1.Text = _frmCode;
            this.PHTo1.Text = _toCode;
            this.STKCODE1.DataBindings.Add("Text", DataSource, "STKCODE");
            this.APPENDIX11.DataBindings.Add("Text", DataSource, "APPENDIX1");
            this.APPENDIX21.DataBindings.Add("Text", DataSource, "APPENDIX2");
            this.APPENDIX31.DataBindings.Add("Text", DataSource, "APPENDIX3");
            this.BARCODE1.DataBindings.Add("Text", DataSource, "Barcode");
            this.TYPE1.DataBindings.Add("Text", DataSource, "BarcodeType");
            this.DESC1.DataBindings.Add("Text", DataSource, "ProductName");
            this.DefFlag1.DataBindings.Add("Text", DataSource, "PrimaryBarcode");
            this.PrintDate1.Text = RT2020.SystemInfo.Settings.DateTimeToString(System.DateTime.Now, true);
           
        }

        #region Set System label
        private void SetSystemLabels()
        {
            hdrStkCode1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            hdrAppendix11.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            hdrAppendix21.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            hdrAppendix31.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion

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
