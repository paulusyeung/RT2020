using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Product.Reports
{
    public partial class Appendix2CombinRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public Appendix2CombinRpt_Xls()
        {
            InitializeComponent();

            this.lblCaption.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") + " Combin List";
            this.lblAppendix2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") + " Combin#";
        }
      
        private void ColorCombinListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrfrApp11.Text = _frmCode;
            this.hdrtoApp11.Text = _toCode;
            this.ID1.DataBindings.Add("Text", DataSource, "APPENDIX2");
            this.lblAppendix2.DataBindings.Add("Text", DataSource, "DimCode");
            this.DATECREATE1.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.DATELCHG1.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.USERLCHG1.DataBindings.Add("Text", DataSource, "StaffName");
            this.PrintDate1.Text = DateTimeHelper.DateTimeToString(System.DateTime.Now, true);
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
