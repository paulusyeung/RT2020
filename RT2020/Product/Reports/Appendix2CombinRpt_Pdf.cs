using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Product.Reports
{
    public partial class Appendix2CombinRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public Appendix2CombinRpt_Pdf()
        {
            InitializeComponent();

            this.lblCaption.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") + " Combin List";
            this.lblAppendix2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") + " Combin#";
        }

        private void ColorCombinListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtID.DataBindings.Add("Text", DataSource, "APPENDIX2");
            this.txtghAPP.DataBindings.Add("Text", DataSource, "DimCode");
            this.txtDATECREATE.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + RT2020.SystemInfo.Settings.GetDateFormat() + "}");
            this.txtDATELCHG.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + RT2020.SystemInfo.Settings.GetDateFormat() + "}");
            this.txtUSERLCHG.DataBindings.Add("Text", DataSource, "StaffName");
            this.txtPrint.Text = RT2020.SystemInfo.Settings.DateTimeToString(System.DateTime.Now, true);            
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
