using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RT2020.Staff.Reports
{
    public partial class StaffListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        private string _frmCode = string.Empty;
        private string _toCode = string.Empty;
       
        public StaffListRpt_Pdf()
        {
            InitializeComponent();
        }

        

        private void StaffListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtFm.Text = _frmCode;
            this.txtTo.Text = _toCode;
            this.txtStaffNo.DataBindings.Add("Text", DataSource, "StaffNumber");
            this.txtName.DataBindings.Add("Text", DataSource, "FullName");
            this.txtInitial.DataBindings.Add("Text", DataSource, "StaffCode");
            this.txtAddress.DataBindings.Add("Text", DataSource, "Address");
            this.txtDateCreate.DataBindings.Add("Text", DataSource, "CreatedOn", "{0:" + RT2020.SystemInfo.Settings.GetDateTimeFormat() + "}");
            this.txtDatelChg.DataBindings.Add("Text", DataSource, "ModifiedOn", "{0:" + RT2020.SystemInfo.Settings.GetDateTimeFormat() + "}");
            this.txtUserlChg.DataBindings.Add("Text", DataSource, "ModifiedBy");
            this.txtTel.DataBindings.Add("Text", DataSource, "Phone");
            this.txtDeptNo.DataBindings.Add("Text",DataSource,"DeptCode");
            this.txtGrade.DataBindings.Add("Text",DataSource,"GradeName");
            this.txtStatus.DataBindings.Add("Text",DataSource,"Status");
            this.txtPrint.Text = RT2020.SystemInfo.Settings.DateTimeToString(System.DateTime.Now, true);
            this.txtPost.DataBindings.Add("Text",DataSource,"PostalCode");
            this.txtBirthday.DataBindings.Add("Text", DataSource, "Birthdate", "{0:" + RT2020.SystemInfo.Settings.GetDateFormat() + "}");
            this.txtIDNO.DataBindings.Add("Text",DataSource,"IdNo");
            
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
