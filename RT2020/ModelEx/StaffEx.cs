using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class StaffEx
    {
        public static EF6.Staff GetByStaffId(Guid staffId)
        {
            EF6.Staff result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.Staff.Find(staffId);
            }

            return result;
        }

        public static EF6.Staff GetByStaffNumber(string staffNumber)
        {
            EF6.Staff result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.Staff.Where(x => x.StaffNumber == staffNumber).FirstOrDefault();
            }

            return result;
        }

        public static Guid GetStaffIdByStaffNumber(string staffNumber)
        {
            var result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Staff.Where(x => x.StaffNumber == staffNumber).FirstOrDefault();
                if (item != null) result = item.StaffId;
            }

            return result;
        }

        public static string GetStaffNumberById(Guid id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Staff.Find(id);
                if (item != null) result = item.StaffNumber;
            }

            return result;
        }

        public static string GetStaffNameById(Guid id, bool switchLanguage = false)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Staff.Find(id);
                if (item != null)
                {
                    result = !switchLanguage ?
                        item.FullName : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                        item.FullName_Cht : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                        item.FullName_Chs :
                        item.FullName;
                }
            }

            return result;
        }

        public static string GetStaffCodeById(Guid staffId)
        {
            string result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Staff.Find(staffId);
                if (item != null) result = item.StaffCode;
            }

            return result;
        }

        public static bool IsStaffCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Staff.Where(x => x.StaffCode == code && x.Retired == false).FirstOrDefault();
                if (item != null) result = true;
            }

            return result;
        }

        public static bool IsStaffNumberInUse(string number)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Staff.Where(x => x.StaffNumber == number && x.Retired == false).FirstOrDefault();
                if (item != null) result = true;
            }

            return result;
        }

        #region LoadCombo

        public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale)
        {
            LoadCombo(ref ddList, TextField, SwitchLocale, false, string.Empty, string.Empty, new string[] { TextField });
        }

        public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, string[] OrderBy)
        {
            LoadCombo(ref ddList, TextField, SwitchLocale, false, string.Empty, string.Empty, OrderBy);
        }

        public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause)
        {
            LoadCombo(ref ddList, TextField, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, new String[] { TextField });
        }

        public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause, string[] OrderBy)
        {
            LoadCombo(ref ddList, TextField, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, OrderBy);
        }

        public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string ParentFilter, string WhereClause, string[] OrderBy)
        {
            //    string[] textField = { TextField };
            //    LoadCombo(ref ddList, textField, "{0}", SwitchLocale, BlankLine, BlankLineText, ParentFilter, WhereClause, OrderBy);
            //}

            //public static void LoadCombo(ref ComboBox ddList, string[] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause, string[] OrderBy)
            //{
            //    LoadCombo(ref ddList, TextField, TextFormatString, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, OrderBy);
            //}

            //public static void LoadCombo(ref ComboBox ddList, string[] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string ParentFilter, string WhereClause, string[] OrderBy)
            //{
            ddList.DataSource = null;
            ddList.Items.Clear();

            #region 轉換 orderby：方便 SQL Server 做 sorting，中文字排序可參考：https://dotblogs.com.tw/jamesfu/2013/06/04/collation
            //if (SwitchLocale && TextField[0] == OrderBy[0] && OrderBy.Length == 1)
            if (SwitchLocale && TextField == OrderBy[0] && OrderBy.Length == 1)
            {
                OrderBy[0] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "FullName_Cht" :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "FullName_Chs" :
                    "FullName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Staff.SqlQuery(
                    String.Format(
                        "Select * from Staff Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.Staff()
                    {
                        StaffId = Guid.Empty,
                        StaffCode = "",
                        FullName = BlankLineText,
                        FullName_Chs = BlankLineText,
                        FullName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "StaffId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "FullName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "FullName_Chs" :
                    "FullName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}