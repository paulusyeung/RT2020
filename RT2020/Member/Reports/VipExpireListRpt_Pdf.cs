using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Member.Reports
{
    public partial class VipExpireListRpt_Pdf : DevExpress.XtraReports.UI.XtraReport
    {
        public VipExpireListRpt_Pdf()
        {
            InitializeComponent();
        }

        #region Properties
        public string FromCode
        {
            get
            {
                return hdrFmVIP1.Text;
            }
            set
            {
                hdrFmVIP1.Text = value;
            }
        }

        public string ToCode
        {
            get
            {
                return hdrToVIP1.Text;
            }
            set
            {
                hdrToVIP1.Text = value;
            }
        }

        public string FromDate
        {
            get
            {
                return hdrFmDate1.Text;
            }
            set
            {
                hdrFmDate1.Text = value;
            }
        }

        public string ToDate
        {
            get
            {
                return hdrToDate1.Text;
            }
            set
            {
                hdrToDate1.Text = value;
            }
        }
        #endregion

        private void VipExpireListRpt_Pdf_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.PrintDate1.Text = DateTimeHelper.DateTimeToString(DateTime.Now, true);

            this.txtExpiry.DataBindings.Add("Text", DataSource, "CARD_EXPIRE", "{0:" + DateTimeHelper.GetDateFormat() + "}");
            this.txtVipNumber.DataBindings.Add("Text", DataSource, "VipNumber");
            this.txtStaffName.DataBindings.Add("Text", DataSource, "FullName");
            this.txtGroup.DataBindings.Add("Text", DataSource, "GROUP");
            this.txtGrade.DataBindings.Add("Text", DataSource, "GRADE");
            this.txtSex.DataBindings.Add("Text", DataSource, "Sex");
            this.txtRace.DataBindings.Add("Text", DataSource, "Race");
            this.txtNormalDiscount.DataBindings.Add("Text", DataSource, "NormalDiscount", "{0:n2}");
            this.txtPromotionDiscount.DataBindings.Add("Text", DataSource, "PromotionDiscount_Pcn", "{0:n2}");
            this.txtStatus.DataBindings.Add("Text", DataSource, "CARD_ACTIVE");
        }
    }
}
