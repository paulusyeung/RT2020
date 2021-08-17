using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Helper;

namespace RT2020.Staff.Reports
{
    public partial class StaffListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public StaffListRpt_Xls()
        {
            InitializeComponent();
        }       

        private void StaffListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrFm1.Text = _frmCode;
            this.hdrTo1.Text = _toCode;
            this.STAFFNO1.DataBindings.Add("Text", DataSource, "StaffCode");
            this.NAME1.DataBindings.Add("Text", DataSource, "FullName");
            //this.INITIAL1.DataBindings.Add("Text", DataSource, "WorkplaceInitial");
            //this.INITIAL2.DataBindings.Add("Text",DataSource,"WorkplaceInitial");
            this.ADDRESS.DataBindings.Add("Text", DataSource, "Address");
            this.DATECREATE1.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.DATELCHG1.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.USERLCHG1.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.TEL1.DataBindings.Add("Text", DataSource, "Phone");
            this.DEPTNO1.DataBindings.Add("Text", DataSource, "DeptCode");
            this.GRADE1.DataBindings.Add("Text", DataSource, "GradeName");
            this.STATUS1.DataBindings.Add("Text", DataSource, "Status");
            this.POST1.DataBindings.Add("Text", DataSource, "PostalCode");
            this.BIRTHDAY1.DataBindings.Add("Text", DataSource, "Birthdate", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.IDNO1.DataBindings.Add("Text", DataSource, "IdNo");
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
