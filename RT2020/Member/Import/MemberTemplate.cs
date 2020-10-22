using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FileHelpers;

namespace RT2020.Member
{
    [DelimitedRecord(",")]
    public class MemberTemplate
    {
        /// <summary>
        ///  MemberId
        /// </summary>
        [FieldIgnored()]
        public string MemberId;

        /// <summary>
        ///  VIP #
        /// </summary>
        public string VIPNO;

        /// <summary>
        /// Group
        /// </summary>
        public string GROUP;

        /// <summary>
        /// Salute
        /// </summary>
        public string SALUTE;

        /// <summary>
        /// Last name
        /// </summary>
        public string LNAME;

        /// <summary>
        /// First Name
        /// </summary>
        public string FNAME;

        /// <summary>
        /// Nick name
        /// </summary>
        public string NNAME;

        /// <summary>
        /// Address 1
        /// </summary>
        public string ADDRESS1;

        /// <summary>
        /// Address 2
        /// </summary>
        public string ADDRESS2;

        /// <summary>
        /// Address 3
        /// </summary>
        public string ADDRESS3;

        /// <summary>
        /// Address 4
        /// </summary>
        public string ADDRESS4;

        /// <summary>
        /// Telephone Work
        /// </summary>
        public string TELW;

        /// <summary>
        /// Telephone Home
        /// </summary>
        public string TELH;

        /// <summary>
        /// Telephone Personal
        /// </summary>
        public string TELP;

        /// <summary>
        /// Fax
        /// </summary>
        public string FAX;

        /// <summary>
        /// E-Mail
        /// </summary>
        public string EMAIL;

        /// <summary>
        /// Sex
        /// </summary>
        public string SEX;

        /// <summary>
        /// Race
        /// </summary>
        public string RACE;

        /// <summary>
        /// Remarks
        /// </summary>
        public string REMARKS;

        /// <summary>
        /// Normal Discount %
        /// </summary>
        public Decimal NRDISC;

        /// <summary>
        /// Grade
        /// </summary>
        public string GRADE;

        /// <summary>
        /// ID #
        /// </summary>
        public string ID_NO;

        /// <summary>
        /// Date of Birth
        /// </summary>
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DATE_BIRTH;

        /// <summary>
        /// Date of Register
        /// </summary>
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DATE_REGIS;

        /// <summary>
        /// Download flag
        /// </summary>
        public string DLFLAG;

        /// <summary>
        /// Age
        /// </summary>
        public string AGE;

        /// <summary>
        /// Remarks 1
        /// </summary>
        public string R1;

        /// <summary>
        /// Remarks 2
        /// </summary>
        public string R2;

        /// <summary>
        /// Remarks 3
        /// </summary>
        public string R3;

        /// <summary>
        /// Nation
        /// </summary>
        public string NATION;

        /// <summary>
        /// Memo
        /// </summary>
        public string MEMO;

        /// <summary>
        /// Photo
        /// </summary>
        public string PHOTO;

        /// <summary>
        /// Date Commence
        /// </summary>
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DATE_COMM;

        /// <summary>
        /// Date Migrate
        /// </summary>
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DATE_MIGRATE;

        /// <summary>
        /// Card Issue
        /// </summary>
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime CARD_ISSUE;

        /// <summary>
        /// Card Expire
        /// </summary>
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime CARD_EXPIRE;

        /// <summary>
        /// Card Name
        /// </summary>
        public string CARD_NAME;

        /// <summary>
        /// Card Receive
        /// </summary>
        public string CARD_RECEIVE;

        /// <summary>
        /// Card Active
        /// </summary>
        public string CARD_ACTIVE;

        /// <summary>
        /// Former PP #
        /// </summary>
        public string FORMER_PPNO;

        /// <summary>
        /// Allowed Credit $
        /// </summary>
        public Decimal ACREDIT;

        /// <summary>
        /// Terms
        /// </summary>
        public string TERMS;

        /// <summary>
        /// Payment discount %
        /// </summary>
        public Decimal PYDISC;

        /// <summary>
        /// Nature
        /// </summary>
        public string NATURE;

        /// <summary>
        /// Customer #
        /// </summary>
        public string CUSTNUM;

        /// <summary>
        /// Branch
        /// </summary>
        public string BRANCH;

        /// <summary>
        /// Promotion Discount %
        /// </summary>
        public Decimal PRO_DISC;

        /// <summary>
        /// Created On
        /// </summary>
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DATECREATE;

        /// <summary>
        /// Modified On
        /// </summary>
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DATELCHG;

        /// <summary>
        /// Modified By
        /// </summary>
        public string USERLCHG;

        /// <summary>
        /// Amount Purchased
        /// </summary>
        public Decimal ATDAMTPUR;

        /// <summary>
        /// Amount Paid
        /// </summary>
        public Decimal ATDAMTPAY;

        /// <summary>
        /// Amount Returned
        /// </summary>
        public Decimal ATDAMTRET;

        /// <summary>
        /// Amount Discounted
        /// </summary>
        public Decimal ATDAMTDIS;

        /// <summary>
        /// Line of Operation
        /// </summary>
        public string LOOID;

        /// <summary>
        /// Code Card #
        /// </summary>
        public string CODENUM;

        /// <summary>
        /// Loyalty #
        /// </summary>
        public string LOYALTYNUM;

        /// <summary>
        /// Age Group
        /// </summary>
        public string AGE_GROUP;

        /// <summary>
        /// Profile
        /// </summary>
        public string PROFILE;

        /// <summary>
        /// Mail #1
        /// </summary>
        public string MALL1;

        /// <summary>
        /// Mail #2
        /// </summary>
        public string MALL2;

        /// <summary>
        /// Mail #3
        /// </summary>
        public string MALL3;

        /// <summary>
        /// Brand #1
        /// </summary>
        public string BRAND1;

        /// <summary>
        /// Brand #2
        /// </summary>
        public string BRAND2;

        /// <summary>
        /// Brand #3
        /// </summary>
        public string BRAND3;

        /// <summary>
        /// Magazine #1
        /// </summary>
        public string MAGAZINE1;

        /// <summary>
        /// Magazine #2
        /// </summary>
        public string MAGAZINE2;

        /// <summary>
        /// Magazine #3
        /// </summary>
        public string MAGAZINE3;

        /// <summary>
        /// Card #1
        /// </summary>
        public string CARD1;

        /// <summary>
        /// Card #2
        /// </summary>
        public string CARD2;

        /// <summary>
        /// Card #3
        /// </summary>
        public string CARD3;

        /// <summary>
        /// Chinese Name
        /// </summary>
        public string CNAME;

        /// <summary>
        /// Title
        /// </summary>
        public string TITLE;

        /// <summary>
        /// Company name
        /// </summary>
        public string COMPNAME;

        /// <summary>
        /// Chinese Company name
        /// </summary>
        public string COMPNAMEC;

        /// <summary>
        /// Chinese Address 1
        /// </summary>
        public string ADDRESS1C;

        /// <summary>
        /// Chinese Address 2
        /// </summary>
        public string ADDRESS2C;

        /// <summary>
        /// Chinese Address 3
        /// </summary>
        public string ADDRESS3C;

        /// <summary>
        /// Chinese Address 4
        /// </summary>
        public string ADDRESS4C;

        /// <summary>
        /// Telephone Other
        /// </summary>
        public string TELOTHER;

        /// <summary>
        /// Phonebook
        /// </summary>
        public string PHONEBOOK;

        /// <summary>
        /// Staff Quota
        /// </summary>
        public Decimal STAFF_QUOTA;

        /// <summary>
        /// Add on Discount
        /// </summary>
        public string BADDONDISC;
    }
}
