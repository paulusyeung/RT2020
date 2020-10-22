using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Product.Reports
{
    public partial class ProductMasterListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public ProductMasterListRpt_Xls()
        {
            InitializeComponent();

            SetSystemLabels();
        }

        private void ProductMasterListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrFm1.Text = _frmCode;
            this.hdrTo1.Text = _toCode;
            this.STKCODE1.DataBindings.Add("Text", DataSource, "STKCODE");
            this.APPENDIX11.DataBindings.Add("Text", DataSource, "APPENDIX1");
            this.APPENDIX21.DataBindings.Add("Text", DataSource, "APPENDIX2");
            this.APPENDIX31.DataBindings.Add("Text", DataSource, "APPENDIX3");
            this.CLASS11.DataBindings.Add("Text", DataSource, "CLASS1");
            this.CLASS21.DataBindings.Add("Text", DataSource, "CLASS2");
            this.CLASS31.DataBindings.Add("Text", DataSource, "CLASS3");
            this.CLASS41.DataBindings.Add("Text", DataSource, "CLASS4");
            this.CLASS51.DataBindings.Add("Text", DataSource, "CLASS5");
            this.CLASS61.DataBindings.Add("Text", DataSource, "CLASS6");
            this.VPRC1.DataBindings.Add("Text", DataSource, "VendorPrice", "{0:n2}");
            this.VCURR1.DataBindings.Add("Text", DataSource, "VendorCurrencyCode", "{0:n2}");
            this.ORIPRC1.DataBindings.Add("Text", DataSource, "OriginalRetailPrice", "{0:n2}");
            this.PrintDate1.Text = RT2020.SystemInfo.Settings.DateTimeToString(System.DateTime.Now, true);
            this.DESC1.DataBindings.Add("Text", DataSource, "ProductName");
            this.BASPRC1.DataBindings.Add("Text", DataSource, "RetailPrice", "{0:n2}");

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
            hdrStkCode1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            hdrAppendix11.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            hdrAppendix21.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            hdrAppendix31.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");

            hdrClass11.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1");
            hdrClass21.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS2");
            hdrClass31.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS3");
            hdrClass41.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS4");
            hdrClass51.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS5");
            hdrClass61.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS6");
        }
        #endregion
    }
}
