using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Common.Helper;

namespace RT2020.Member.Reports
{
    public partial class VipMatureListRpt : DevExpress.XtraReports.UI.XtraReport
    {
        public VipMatureListRpt()
        {
            InitializeComponent();
        }

        #region Properties
        public string FromCode
        {
            get
            {
                return hdFmVIPNo1.Text;
            }
            set
            {
                hdFmVIPNo1.Text = value;
            }
        }

        public string ToCode
        {
            get
            {
                return hdToVIPNo1.Text;
            }
            set
            {
                hdToVIPNo1.Text = value;
            }
        }

        public string TotalNetSalesAmount
        {
            get
            {
                return TotAMT1.Text;
            }
            set
            {
                TotAMT1.Text = value;
            }
        }
        #endregion

        private void VipMatureListRpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.VIPNO1.DataBindings.Add("Text", DataSource, "VipNumber");
            this.DATECOMM1.DataBindings.Add("Text", DataSource, "Date Commence");
            this.GROUP1.DataBindings.Add("Text", DataSource, "Group");
            this.NETSALES1.DataBindings.Add("Text", DataSource, "Amount Paid", "{0:n2}");
            this.CARDNAME1.DataBindings.Add("Text", DataSource, "CARD_NAME");
            this.RACE1.DataBindings.Add("Text", DataSource, "Race");
            this.NRDISC1.DataBindings.Add("Text", DataSource, "NormalDiscount", "{0:n2}");

            this.PrintDate1.Text = DateTimeHelper.DateTimeToString(DateTime.Now, true);
        }
    }
}
