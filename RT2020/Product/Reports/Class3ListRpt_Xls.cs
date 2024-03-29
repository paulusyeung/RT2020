using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Product.Reports
{
    public partial class Class3ListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public Class3ListRpt_Xls()
        {
            InitializeComponent();

            this.lblCaption.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS3") + " List";
        }
             
        private void CollectionListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrFm1.Text = _frmCode;
            this.hdrTo1.Text = _toCode;
            this.ID1.DataBindings.Add("Text", DataSource, "Class3Code");
            this.DESC1.DataBindings.Add("Text", DataSource, "Class3Initial");
            this.DESCLONG1.DataBindings.Add("Text", DataSource, "Class3Name");
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
