using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Inventory.Transfer.Reports
{
    public partial class HistoryRpt : DevExpress.XtraReports.UI.XtraReport
    {
        private string _TxNumberFrom = string.Empty;
        private string _TxNumberTo = string.Empty;
        private DateTime _TxDateFrom = DateTime.Now;
        private DateTime _TxDateTo = DateTime.Now;

        public HistoryRpt()
        {
            InitializeComponent();
        }

        #region Attribute
        public string TxNumberFrom
        {
            get
            {
                return TxNumberFrom;
            }
            set
            {
                _TxNumberFrom = value;
            }
        }

        public string TxNumberTo
        {
            get
            {
                return _TxNumberTo;
            }
            set
            {
                _TxNumberTo = value;
            }
        }

        public DateTime TxDateFrom
        {
            get
            {
                return _TxDateFrom;
            }
            set
            {
                _TxDateFrom = value;
            }
        }

        public DateTime TxDateTo
        {
            get
            {
                return _TxDateTo;
            }
            set
            {
                _TxDateTo = value;
            }
        }
        #endregion

        private void HistoryRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // ph
            this.txtTxNumberFrom.Text = _TxNumberFrom;
            this.txtTxNumberTo.Text = _TxNumberTo;
            this.txtTxDateFrom.Text = _TxDateFrom.ToString(DateTimeHelper.GetDateFormat());
            this.txtTxDateTo.Text = _TxDateTo.ToString(DateTimeHelper.GetDateFormat());

            this.phStkCode.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE");
            this.phAppendix1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            this.phAppendix2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2");
            this.phAppendix3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3");

            this.phDateTime.Format = "{0:" + DateTimeHelper.GetDateTimeFormat() + "}";
            // gh1
            this.txtHeaderId.DataBindings.Add("Text", DataSource, "HeaderId");
            this.txtTxNumber.DataBindings.Add("Text", DataSource, "TxNumber");
            this.txtTxDate.DataBindings.Add("Text", DataSource, "TxDate", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtOperatorCode.DataBindings.Add("Text", DataSource, "OperatorCode");
            this.txtOperatorName.DataBindings.Add("Text", DataSource, "OperatorName");
            this.txtFmLocationCode.DataBindings.Add("Text", DataSource, "FmLocationCode");
            this.txtFmLocationName.DataBindings.Add("Text", DataSource, "FmLocationName");
            this.txtToLocationCode.DataBindings.Add("Text", DataSource, "ToLocationCode");
            this.txtToLocationName.DataBindings.Add("Text", DataSource, "ToLocationName");
            this.txtTransferredOn.DataBindings.Add("Text", DataSource, "TransferredOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtCompletedOn.DataBindings.Add("Text", DataSource, "CompletedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtRemarks.DataBindings.Add("Text", DataSource, "Remarks");
            this.txtModifiedBy.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.txtModifiedOn.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");

            this.GroupHeader1.GroupFields.Add(new GroupField("TxNumber"));      // HACK: 唔知掂解, 如果用 HeaderId 會影響 順序.
            // gf1
            this.gfTotalQty.DataBindings.Add("Text", DataSource, "TotalQty", "{0:n" + SystemInfoHelper.Settings.GetQtyDecimalPoint().ToString() + "}");
            this.gfTotalAmount.DataBindings.Add("Text", DataSource, "TotalAmount", "{0:n2}");
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.GetCurrentColumnValue("HeaderId") != null)
            {
                DataTable dt = Reports.DataSource.HistoryDetails(this.GetCurrentColumnValue("HeaderId").ToString());

                if (dt.Rows.Count > 0)
                {
                    HistoryRptDetails subReport = new HistoryRptDetails();
                    subReport.DataSource = dt;
                    rptDetails.ReportSource = subReport;
                }
                else
                {
                    rptDetails.ReportSource = null;
                }
            }
        }

    }
}
