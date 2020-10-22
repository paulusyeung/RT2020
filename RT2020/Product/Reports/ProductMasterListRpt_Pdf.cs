using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Product.Reports
{
    public partial class ProductMasterListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public ProductMasterListRpt_Pdf()
        {
            InitializeComponent();
            SetSystemLabels();
        }

        private void ProductMasterListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtSTKCODE.DataBindings.Add("Text", DataSource, "STKCODE");
            this.txtAppendix1.DataBindings.Add("Text", DataSource, "APPENDIX1");
            this.txtAppendix2.DataBindings.Add("Text", DataSource, "APPENDIX2");
            this.txtAppendix3.DataBindings.Add("Text", DataSource, "APPENDIX3");
            this.txtClass1.DataBindings.Add("Text", DataSource, "CLASS1");
            this.txtClass2.DataBindings.Add("Text", DataSource, "CLASS2");
            this.txtClass3.DataBindings.Add("Text", DataSource, "CLASS3");
            this.txtClass4.DataBindings.Add("Text", DataSource, "CLASS4");
            this.txtClass5.DataBindings.Add("Text", DataSource, "CLASS5");
            this.txtClass6.DataBindings.Add("Text", DataSource, "CLASS6");
            this.txtVprc.DataBindings.Add("Text", DataSource, "VendorPrice", "{0:n2}");
            this.txtVcurr.DataBindings.Add("Text", DataSource, "VendorCurrencyCode", "{0:n2}");
            this.txtORIPRC.DataBindings.Add("Text", DataSource, "OriginalRetailPrice", "{0:n2}");
            this.txtPrint.Text = RT2020.SystemInfo.Settings.DateTimeToString(System.DateTime.Now, true);
            this.txtDesc.DataBindings.Add("Text", DataSource, "ProductName");
            this.txtBasPrc.DataBindings.Add("Text", DataSource, "RetailPrice", "{0:n2}");
           
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
            lblSTK.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            lblA1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            lblA2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            lblA3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");

            lblClass1.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1");
            lblClass2.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS2");
            lblClass3.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS3");
            lblClass4.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS4");
            lblClass5.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS5");
            lblClass6.Text = "C1 : " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS6");
        }
        #endregion
    }
}
