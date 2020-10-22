using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Workplace.Reports
{
    public partial class WorkplaceListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;
       
        public WorkplaceListRpt_Pdf()
        {
            InitializeComponent();
        }

        private void WorkplaceListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtLocNo.DataBindings.Add("Text", DataSource, "WorkplaceCode");
            this.txtName.DataBindings.Add("Text", DataSource, "WorkplaceName");
            this.txtInitial.DataBindings.Add("Text", DataSource, "WorkplaceInitial");
            this.txtAddress.DataBindings.Add("Text",DataSource,"Address");
            this.txtDateCreate.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + RT2020.SystemInfo.Settings.GetDateFormat() + "}");
            this.txtDatelChg.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + RT2020.SystemInfo.Settings.GetDateFormat() + "}");
            this.txtUserlChg.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.txtTel.DataBindings.Add("Text",DataSource,"Phone");
            //this.txtALTERNATE_LOCNO.DataBindings.Add("Text",DataSource,"");
            //this.txtPsn.DataBindings.Add("Text",DataSource,"");
            this.txtPrint.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, true);
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
