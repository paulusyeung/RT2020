using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Inventory.Replenishment.Reports
{
    public partial class WorksheetRptDetails : DevExpress.XtraReports.UI.XtraReport
    {
        public WorksheetRptDetails()
        {
            InitializeComponent();
        }

        private void WorksheetRptDetails_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtStkCode.DataBindings.Add("Text", DataSource, "STKCODE");
            this.txtAppendix1.DataBindings.Add("Text", DataSource, "APPENDIX1");
            this.txtAppendix2.DataBindings.Add("Text", DataSource, "APPENDIX2");
            this.txtAppendix3.DataBindings.Add("Text", DataSource, "APPENDIX3");
            this.txtDescription.DataBindings.Add("Text", DataSource, "ProductName");
            this.txtQtyRequested.DataBindings.Add("Text", DataSource, "QtyRequested", "{0:n" + RT2020.SystemInfo.Settings.GetQtyDecimalPoint().ToString() + "}");
            this.txtQtyIssued.DataBindings.Add("Text", DataSource, "QtyIssued", "{0:n" + RT2020.SystemInfo.Settings.GetQtyDecimalPoint().ToString() + "}");
            this.txtQtyOnhand.DataBindings.Add("Text", DataSource, "QtyOnhand", "{0:n" + RT2020.SystemInfo.Settings.GetQtyDecimalPoint().ToString() + "}");
        }

    }
}
