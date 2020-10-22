using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Product.Reports
{
    public partial class DimensionListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        public string FromDimCode = string.Empty;
        public string ToDimCode = string.Empty;

        public DimensionListRpt_Xls()
        {
            InitializeComponent();

            this.hdrApp11.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            this.hdrApp21.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            this.hdrApp31.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
        }

        private void DimensionListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrFm1.Text = FromDimCode;
            this.hdrTo1.Text = ToDimCode;
            this.GroupNameCOMBINNO1.DataBindings.Add("Text", DataSource, "DimCode");
            this.APPENDIX11.DataBindings.Add("Text", DataSource, "Appendix1");
            this.APPENDIX21.DataBindings.Add("Text", DataSource, "Appendix2");
            this.APPENDIX31.DataBindings.Add("Text", DataSource, "Appendix3");
            this.GroupNameCOMBINNO2.DataBindings.Add("Text", DataSource, "DimCode");
            this.txtPrint.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, true);
        }

    }
}
