using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using RT2020.Helper;

namespace RT2020.Member.Reports
{
    public partial class VipCodeListRpt_Xls : DevExpress.XtraReports.UI.XtraReport
    {
        public VipCodeListRpt_Xls()
        {
            InitializeComponent();
        }

        #region Properties
        public string FromCode
        {
            get
            {
                return hdrFm1.Text;
            }
            set
            {
                hdrFm1.Text = value;
            }
        }

        public string ToCode
        {
            get
            {
                return hdrTo1.Text;
            }
            set
            {
                hdrTo1.Text = value;
            }
        }
        #endregion

        private void VipCodeListRpt_Xls_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.VIPNO1.DataBindings.Add("Text", DataSource, "VipNumber");
            this.GROUP1.DataBindings.Add("Text", DataSource, "Group");
            this.GRADE1.DataBindings.Add("Text", DataSource, "Grade");

            this.SALUTE1.DataBindings.Add("Text", DataSource, "Salute");
            this.NNAME1.DataBindings.Add("Text", DataSource, "NickName");
            this.FNAME1.DataBindings.Add("Text", DataSource, "FirstName");
            this.LNAME1.DataBindings.Add("Text", DataSource, "LastName");

            this.ADDRESS11.DataBindings.Add("Text", DataSource, "Address4");
            this.ADDRESS21.DataBindings.Add("Text", DataSource, "Address3");
            this.ADDRESS31.DataBindings.Add("Text", DataSource, "Address2");
            this.ADDRESS41.DataBindings.Add("Text", DataSource, "Address1");

            this.EMAIL1.DataBindings.Add("Text", DataSource, "Email");
            this.TELH1.DataBindings.Add("Text", DataSource, "Phone_H");
            this.TELW1.DataBindings.Add("Text", DataSource, "Phone_W");
            this.TELP1.DataBindings.Add("Text", DataSource, "Phone_P");
            this.FAX1.DataBindings.Add("Text", DataSource, "Fax");
            this.REMARKS1.DataBindings.Add("Text", DataSource, "Remarks");

            this.PYDISC1.DataBindings.Add("Text", DataSource, "PaymentDiscount");
            this.ACREDIT1.DataBindings.Add("Text", DataSource, "Allow Credit");
            this.TERMS1.DataBindings.Add("Text", DataSource, "Terms");

            this.DATECREATE1.DataBindings.Add("Text", DataSource, "Date Create");
            this.DATELCHG1.DataBindings.Add("Text", DataSource, "Last Update");
            this.USERLCHG1.DataBindings.Add("Text", DataSource, "Last User");

            this.MEMO1.DataBindings.Add("Text", DataSource, "Memo");

            this.SEX1.DataBindings.Add("Text", DataSource, "Sex");
            this.IDNO1.DataBindings.Add("Text", DataSource, "HKID");
            this.NATION1.DataBindings.Add("Text", DataSource, "Nationality");
            this.R11.DataBindings.Add("Text", DataSource, "Remark_1");
            this.R21.DataBindings.Add("Text", DataSource, "Remark_2");
            this.R31.DataBindings.Add("Text", DataSource, "Remark_3");

            this.DATEBIRTH1.DataBindings.Add("Text", DataSource, "DateOfBirth");
            this.DATEREGIS1.DataBindings.Add("Text", DataSource, "DateOfRegister");
            this.DATECOMM1.DataBindings.Add("Text", DataSource, "Date Commence");
            this.DATEMIGRATE1.DataBindings.Add("Text", DataSource, "Date Migrate");

            this.CARDNAME1.DataBindings.Add("Text", DataSource, "CARD_NAME");
            this.CARDISSUE1.DataBindings.Add("Text", DataSource, "CARD_ISSUE");
            this.CARDEXPIRE1.DataBindings.Add("Text", DataSource, "CARD_EXPIRE");
            this.CARDRECEIVE1.DataBindings.Add("Text", DataSource, "CARD_RECEIVE");
            this.CARDACTIVE1.DataBindings.Add("Text", DataSource, "CARD_ACTIVE");

            this.PrintDate1.Text = DateTimeHelper.DateTimeToString(System.DateTime.Now, true);
        }
    }
}
