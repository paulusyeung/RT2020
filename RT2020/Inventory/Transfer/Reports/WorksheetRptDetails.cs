using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Inventory.Transfer.Reports
{
    public partial class WorksheetRptDetails : DevExpress.XtraReports.UI.XtraReport
    {
        public WorksheetRptDetails()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtStkCode.DataBindings.Add("Text", DataSource, "STKCODE");
            this.txtAppendix1.DataBindings.Add("Text", DataSource, "APPENDIX1");
            this.txtAppendix2.DataBindings.Add("Text", DataSource, "APPENDIX2");
            this.txtAppendix3.DataBindings.Add("Text", DataSource, "APPENDIX3");
            this.txtDescription.DataBindings.Add("Text", DataSource, "ProductName");
            this.txtQtyRequested.DataBindings.Add("Text", DataSource, "QtyRequested", "{0:n" + SystemInfoHelper.Settings.GetQtyDecimalPoint().ToString() + "}");
            this.txtUnitAmount.DataBindings.Add("Text", DataSource, "UnitAmount", "{0:n2}");
            this.txtAmount.DataBindings.Add("Text", DataSource, "Amount", "{0:n2}");
            this.txtNotes.DataBindings.Add("Text", DataSource, "Notes");
        }

    }
}
