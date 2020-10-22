using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Product.Reports
{
    public partial class DimensionListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        public string FromDimCode = string.Empty;
        public string ToDimCode = string.Empty;

        public DimensionListRpt_Pdf()
        {
            InitializeComponent();

            lblA1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            lblA2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            lblA3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
        }

        private void DimensionListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = FromDimCode;
            this.txtTo.Text = ToDimCode;
            this.txtCombin_No.DataBindings.Add("Text", DataSource, "DimCode");
            this.txtAppendix1.DataBindings.Add("Text", DataSource, "Appendix1");
            this.txtAppendix2.DataBindings.Add("Text", DataSource, "Appendix2");
            this.txtAppendix3.DataBindings.Add("Text", DataSource, "Appendix3");
            this.txtgfCT.DataBindings.Add("Text", DataSource, "DimCode");
            this.txtPrint.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, true);
        }

    }
}
