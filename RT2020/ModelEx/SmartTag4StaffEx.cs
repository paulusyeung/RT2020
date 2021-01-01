using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class SmartTag4StaffEx
    {
        public static bool IsTagCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var tag = ctx.SmartTag4Staff.Where(x => x.TagCode == code).FirstOrDefault();
                if (tag != null) result = true;
            }

            return result;
        }

        public static Guid GetIdByPriority(int priority)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SmartTag4Staff.Where(x => x.Priority == priority).FirstOrDefault();
                if (item != null) result = item.TagId;
            }

            return result;
        }

        public static Guid GetIdByTagCodeAndPriority(string code, int priority)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SmartTag4Staff.Where(x => x.TagCode == code && x.Priority == priority).FirstOrDefault();
                if (item != null) result = item.TagId;
            }

            return result;
        }

        public static EF6.SmartTag4Staff GetByTagCode(string code)
        {
            EF6.SmartTag4Staff result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Staff.Where(x => x.TagCode == code).FirstOrDefault();
            }

            return result;
        }

        public static List<EF6.SmartTag4Staff> GetListOrderBy(string[] orderBy, bool switchLocale = false)
        {
            List<EF6.SmartTag4Staff> result = new List<EF6.SmartTag4Staff>();

            using (var ctx = new EF6.RT2020Entities())
            {
                #region 轉換 orderBy：方便 SQL Server 做 sorting，中文字排序可參考：https://dotblogs.com.tw/jamesfu/2013/06/04/collation
                //if (SwitchLocale && TextField[0] == OrderBy[0] && OrderBy.Length == 1)
                if (switchLocale)
                {
                    for (int i = 0; i < orderBy.Length; i++)
                    {
                        if (orderBy[i] == "TagName")
                        {
                            orderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                                "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                                "TagName_Chs" :
                                "TagName";
                        }
                    }
                }
                var order = String.Join(",", orderBy.Select(x => "[" + x + "]"));
                #endregion

                result = ctx.SmartTag4Staff.SqlQuery(
                    String.Format(
                        "Select * from SmartTag4Staff Order By {0}",
                        order
                    ))
                    .AsNoTracking()
                    .ToList();
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
                    "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TagName_Chs" :
                    "TagName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.SmartTag4Staff.SqlQuery(
                    String.Format(
                        "Select * from SmartTag4Staff Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.SmartTag4Staff()
                    {
                        TagId = Guid.Empty,
                        TagCode = "",
                        TagName = BlankLineText,
                        TagName_Chs = BlankLineText,
                        TagName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "TagId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TagName_Chs" :
                    "TagName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}