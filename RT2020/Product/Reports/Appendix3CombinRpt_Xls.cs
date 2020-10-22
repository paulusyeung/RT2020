using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Product.Reports
{
    public partial class Appendix3CombinRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public Appendix3CombinRpt_Xls()
        {
            InitializeComponent();

            this.lblCaption.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") + " Combin List";
            this.lblAppendix3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") + " Combin#";
        }

        private void SizeCombinListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrfrApp11.Text = _frmCode;
            this.hdrtoApp11.Text = _toCode;
            this.ID1.DataBindings.Add("Text", DataSource, "APPENDIX3");
            this.GroupNameAPP3COMBIN1.DataBindings.Add("Text", DataSource, "DimCode");
            this.DATECREATE1.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + RT2020.SystemInfo.Settings.GetDateFormat() + "}");
            this.DATELCHG1.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + RT2020.SystemInfo.Settings.GetDateFormat() + "}");
            this.USERLCHG1.DataBindings.Add("Text", DataSource, "StaffName");
            this.PrintDate1.Text = RT2020.SystemInfo.Settings.DateTimeToString(System.DateTime.Now, true);
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
