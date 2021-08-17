using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Helper;

namespace RT2020.Workplace.Reports
{
    public partial class WorkplaceListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;

        public WorkplaceListRpt_Xls()
        {
            InitializeComponent();
        }     

        private void WorkplaceListRptc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.hdrFm1.Text = _frmCode;
            this.hdrTo1.Text = _toCode;
            this.LOCNO1.DataBindings.Add("Text", DataSource, "WorkplaceCode");
            this.INITIAL1.DataBindings.Add("Text", DataSource, "WorkplaceInitial");
            this.NAME1.DataBindings.Add("Text", DataSource, "WorkplaceName");
            this.txtAddress.DataBindings.Add("Text",DataSource,"Address");
            this.DATECREATE1.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.DATELCHG1.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.USERLCHG1.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.TEL1.DataBindings.Add("Text",DataSource,"Phone");
            this.PrintDate1.Text = DateTimeHelper.DateTimeToString(DateTime.Now, true);
            //this.PSN1.DataBindings.Add("Text",DataSource,"");
            //this.ALTERNATELOCNO1.DataBindings.Add("Text",DataSource,"");
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
