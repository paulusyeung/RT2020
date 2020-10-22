#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;
using RT2020.Controls;
using FileHelpers;
using FileHelpers.DataLink;
using RT2020.DAL;
using System.Text.RegularExpressions;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web;

#endregion

namespace RT2020.Member.Export
{
    public partial class ExportMember : Form, IGatewayComponent
    {
        MemberTemplate[] res = null;
        SqlServerStorage storage = new SqlServerStorage(typeof(MemberTemplate));

        public ExportMember()
        {
            InitializeComponent();
            InitialColumnNameList();
            rbtnExportAllRecords.Checked = true;
        }

        #region Initial Column Name list
        private void InitialColumnNameList()
        {
            string[] fieldList = new string[] 
            {
                "VIP #",
                "Group",
                "Salute",
                "Last Name",
                "First Name",
                "Nick Name",
                "Address 1",
                "Address 2",
                "Address 3",
                "Address 4",
                "Phone(W)",
                "Phone(H)",
                "Phone(P)",
                "Fax",
                "E-Mail",
                "Sex",
                "Race",
                "Remark(s)",
                "Normal Disc%",
                "Grade",
                "ID #",
                "D.O.B.",
                "Date Register",
                "D.L. Flag",
                "Age",
                "Remark 1",
                "Remark 2",
                "Remark 3",
                "Nation",
                "Memo",
                "Photo",
                "Date Commence",
                "Date Migrate",
                "Card Issue",
                "Card Expire",
                "Card Name",
                "Receive",
                "Active",
                "PP #",
                "Allowed Credit$",
                "Terms",
                "Payment Disc%",
                "Nature",
                "Cust #",
                "Branch",
                "Promotion Disc%",
                "Date Create",
                "Last Update",
                "Last User",
                "Amount Purchased",
                "Amount Paid",
                "Amount Returned",
                "Amount Discounted",
                "Line Of Operation",
                "Code Card#",
                "Loyalty#",
                "Age Group",
                "Profile",
                "Mall#1",
                "Mall#2",
                "Mall#3",
                "Brand#1",
                "Brand#2",
                "Brand#3",
                "Magazine#1",
                "Magazine#2",
                "Magazine#3",
                "Card#1",
                "Card#2",
                "Card#3",
                "Name(Chin)",
                "Title",
                "Company",
                "Company(Chin)",
                "Address (Chin) 1",
                "Address (Chin) 2",
                "Address (Chin) 3",
                "Address (Chin) 4",
                "Phone(Other)",
                "Phonebook",
                "Staff Quota",
                "Add on Discount"
            };

            for (int i = 1; i <= fieldList.Length; i++)
            {
                ListViewItem listItem = lvColumnNameList.Items.Add(i.ToString().PadLeft(2, '0'));
                listItem.SubItems.Add(fieldList[i - 1]);

            }
        }
        #endregion

        #region IGatewayComponent Members

        /// <summary>
        /// Provides a way to custom handle requests.
        /// </summary>
        /// <param name="objContext">The request context.</param>
        /// <param name="strAction">The request action.</param>
        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            string path = Path.Combine(Context.Config.GetDirectory("Upload"), "Member");
            string fileName = "MemberExportList_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fullName = Path.Combine(path, fileName);

            FileDataLink.EasyExtractToFile(storage, fullName);

            HttpResponse objResponse = this.Context.HttpContext.Response;

            objResponse.Clear();
            objResponse.ClearHeaders();

            objResponse.ContentType = "application/txt";
            objResponse.AddHeader("content-disposition", "attachment; filename=" + fileName);
            objResponse.BinaryWrite(File.ReadAllBytes(fullName));
            objResponse.Flush();
            objResponse.End();
        }

        #endregion

        #region Events
        private void btnExport_Click(object sender, EventArgs e)
        {
            Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            LoadData();

            lvImportedList.Items.Clear();
            foreach (MemberTemplate member in res)
            {
                ListViewItem oItem = lvImportedList.Items.Add(member.VIPNO);
                oItem.SubItems.Add(member.GROUP);
                oItem.SubItems.Add(member.SALUTE);
                oItem.SubItems.Add(member.LNAME);
                oItem.SubItems.Add(member.FNAME);
                oItem.SubItems.Add(member.NNAME);
                oItem.SubItems.Add(member.ADDRESS1);
                oItem.SubItems.Add(member.ADDRESS2);
                oItem.SubItems.Add(member.ADDRESS3);
                oItem.SubItems.Add(member.ADDRESS4);
                oItem.SubItems.Add(member.TELW);
                oItem.SubItems.Add(member.TELH);
                oItem.SubItems.Add(member.TELP);
                oItem.SubItems.Add(member.FAX);
                oItem.SubItems.Add(member.EMAIL);
                oItem.SubItems.Add(member.SEX);
                oItem.SubItems.Add(member.RACE);
                oItem.SubItems.Add(member.REMARKS);
                oItem.SubItems.Add(member.NRDISC.ToString());
                oItem.SubItems.Add(member.GRADE);
            }

            lblTxCount.Text = res.Length.ToString();
        }

        private void LoadData()
        {
            storage.ConnectionString = Common.Config.ConnectionString;

            if (rbtnExportNewRecords.Checked)
            {
                storage.SelectSql = "SELECT * FROM vwVIP_MemberList WHERE [Date Create] = [Last Update]";
            }
            else
            {
                storage.SelectSql = "SELECT * FROM vwVIP_MemberList";
            }

            storage.FillRecordCallback = new FillRecordHandler(FillMemberRecord);

            res = storage.ExtractRecords() as MemberTemplate[];
        }

        protected void FillMemberRecord(object rec, object[] fields)
        {
            MemberTemplate record = (MemberTemplate)rec;

            record.MemberId = fields[0].ToString();

            record.VIPNO = fields[1].ToString();
            record.GROUP = fields[2].ToString();
            record.SALUTE = fields[3].ToString();
            record.LNAME = fields[4].ToString();
            record.FNAME = fields[5].ToString();
            record.NNAME = fields[6].ToString();
            record.ADDRESS1 = fields[7].ToString();
            record.ADDRESS2 = fields[8].ToString();
            record.ADDRESS3 = fields[9].ToString();
            record.ADDRESS4 = fields[10].ToString();
            record.TELW = fields[11].ToString();
            record.TELH = fields[12].ToString();
            record.TELP = fields[13].ToString();
            record.FAX = fields[14].ToString();
            record.EMAIL = fields[15].ToString();
            record.SEX = fields[16].ToString();
            record.RACE = fields[17].ToString();
            record.REMARKS = fields[18].ToString();
            record.NRDISC = (fields[19] == DBNull.Value || string.IsNullOrEmpty(fields[19].ToString())) ? 0 : Convert.ToDecimal(fields[19].ToString());
            record.GRADE = fields[20].ToString();
            record.ID_NO = fields[21].ToString();
            record.DATE_BIRTH = ConvertDate(fields[22]);
            record.DATE_REGIS = ConvertDate(fields[23]);
            record.DLFLAG = fields[24].ToString();
            record.AGE = fields[25].ToString();
            record.R1 = fields[26].ToString();
            record.R2 = fields[27].ToString();
            record.R3 = fields[28].ToString();
            record.NATION = fields[29].ToString();
            record.MEMO = fields[30].ToString();
            record.PHOTO = fields[31].ToString();
            record.DATE_COMM = ConvertDate(fields[32]);
            record.DATE_MIGRATE = ConvertDate(fields[33]);
            record.CARD_ISSUE = ConvertDate(fields[34]);
            record.CARD_EXPIRE = ConvertDate(fields[35]);
            record.CARD_NAME = fields[36].ToString();
            record.CARD_RECEIVE = fields[37].ToString();
            record.CARD_ACTIVE = fields[38].ToString();
            record.FORMER_PPNO = fields[39].ToString();
            record.ACREDIT = (fields[40] == DBNull.Value || string.IsNullOrEmpty(fields[40].ToString())) ? 0 : Convert.ToDecimal(fields[40].ToString());
            record.TERMS = fields[41].ToString();
            record.PYDISC = (fields[42] == DBNull.Value || string.IsNullOrEmpty(fields[42].ToString())) ? 0 : Convert.ToDecimal(fields[42].ToString());
            record.NATURE = fields[43].ToString();
            record.CUSTNUM = fields[44].ToString();
            record.BRANCH = fields[45].ToString();
            record.PRO_DISC = (fields[46] == DBNull.Value || string.IsNullOrEmpty(fields[46].ToString())) ? 0 : Convert.ToDecimal(fields[46].ToString());
            record.DATECREATE = ConvertDate(fields[47]);
            record.DATELCHG = ConvertDate(fields[48]);
            record.USERLCHG = fields[49].ToString();
            record.ATDAMTPUR = (fields[50] == DBNull.Value || string.IsNullOrEmpty(fields[50].ToString())) ? 0 : Convert.ToDecimal(fields[50].ToString());
            record.ATDAMTPAY = (fields[51] == DBNull.Value || string.IsNullOrEmpty(fields[51].ToString())) ? 0 : Convert.ToDecimal(fields[51].ToString());
            record.ATDAMTRET = (fields[52] == DBNull.Value || string.IsNullOrEmpty(fields[52].ToString())) ? 0 : Convert.ToDecimal(fields[52].ToString());
            record.ATDAMTDIS = (fields[53] == DBNull.Value || string.IsNullOrEmpty(fields[53].ToString())) ? 0 : Convert.ToDecimal(fields[53].ToString());
            record.LOOID = fields[54].ToString();
            record.CODENUM = fields[55].ToString();
            record.LOYALTYNUM = fields[56].ToString();
            record.AGE_GROUP = fields[57].ToString();
            record.PROFILE = fields[58].ToString();
            record.MALL1 = fields[59].ToString();
            record.MALL2 = fields[60].ToString();
            record.MALL3 = fields[61].ToString();
            record.BRAND1 = fields[62].ToString();
            record.BRAND2 = fields[63].ToString();
            record.BRAND3 = fields[64].ToString();
            record.MAGAZINE1 = fields[65].ToString();
            record.MAGAZINE2 = fields[66].ToString();
            record.MAGAZINE3 = fields[67].ToString();
            record.CARD1 = fields[68].ToString();
            record.CARD2 = fields[69].ToString();
            record.CARD3 = fields[70].ToString();
            record.CNAME = fields[71].ToString();
            record.TITLE = fields[73].ToString();
            record.COMPNAME = fields[74].ToString();
            record.COMPNAMEC = fields[75].ToString();
            record.ADDRESS1C = fields[76].ToString();
            record.ADDRESS2C = fields[77].ToString();
            record.ADDRESS3C = fields[78].ToString();
            record.ADDRESS4C = fields[79].ToString();
            record.TELOTHER = fields[80].ToString();
            record.PHONEBOOK = fields[81].ToString();
            record.STAFF_QUOTA = (fields[82] == DBNull.Value || string.IsNullOrEmpty(fields[82].ToString())) ? 0 : Convert.ToDecimal(fields[82].ToString());
            record.BADDONDISC = fields[83].ToString();
        }

        private bool VerifyDate(string value)
        {
            bool isVerified = true;

            string pattern = @"^\d{1,2}\/\d{1,2}\/\d{4}$";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(value);
            if (!match.Success)
            {
                isVerified = false;
            }

            return isVerified;
        }

        private DateTime ConvertDate(object value)
        {
            DateTime result = new DateTime(1900, 1, 1);
            if (!(value is DBNull))
            {
                if (VerifyDate(value.ToString()))
                {
                    string[] values = value.ToString().Split('/');

                    result = Convert.ToDateTime(values[2] + "-" + values[1] + "-" + values[0]);
                }
            }
            return result;
        }
        #endregion
    }
}