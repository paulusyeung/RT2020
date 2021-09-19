using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Product.Reports
{
    public partial class Appendix3CombinRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {

        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public Appendix3CombinRpt_Pdf()
        {
            InitializeComponent();

            this.lblCaption.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3") + " Combin List";
            this.lblAppendix3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3") + " Combin#";
        }

        private void SizeCombinListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtID.DataBindings.Add("Text", DataSource, "APPENDIX3");
            this.txtghAPP.DataBindings.Add("Text", DataSource, "DimCode");
            this.txtDATECREATE.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtDATELCHG.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtUSERLCHG.DataBindings.Add("Text", DataSource, "StaffName");
            this.txtPrint.Text = DateTimeHelper.DateTimeToString(System.DateTime.Now, true);
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
