using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Helper;

namespace RT2020.Product.Reports
{
    public partial class Appendix2ListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public Appendix2ListRpt_Pdf()
        {
            InitializeComponent();

            this.lblCaption.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") + " List";
        }

        private void ColorListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtID.DataBindings.Add("Text", DataSource, "Appendix2Code");
            this.txtDESC.DataBindings.Add("Text", DataSource, "Appendix2Initial");
            this.txtDESC_LONG.DataBindings.Add("Text", DataSource, "Appendix2Name");
            this.txtDateCreate.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtDateLChg.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtUserLChg.DataBindings.Add("Text", DataSource, "StaffName");
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
