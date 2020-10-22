using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Product.Reports
{
    public partial class Appendix2ListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public Appendix2ListRpt_Xls()
        {
            InitializeComponent();

            this.lblCaption.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") + " List";
        }

        private void ColorListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrFm1.Text = _frmCode;
            this.hdrTo1.Text = _toCode;
            this.ID1.DataBindings.Add("Text", DataSource, "Appendix2Code");
            this.DESC1.DataBindings.Add("Text", DataSource, "Appendix2Initial");
            this.DESCLONG1.DataBindings.Add("Text", DataSource, "Appendix2Name");
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
