using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class CountryEx
    {
        public static Guid GetCountryIdByName(string name)
        {
            var result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.Country.Where(x => x.CountryName == name).FirstOrDefault();
                if (p != null) result = p.CountryId;
            }

            return result;
        }

        public static bool IsCountryCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var country = ctx.Country.Where(x => x.CountryCode == code).FirstOrDefault();
                if (country != null) result = true;
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
            string[] textField = { TextField };
            LoadCombo(ref ddList, textField, "{0}", SwitchLocale, BlankLine, BlankLineText, ParentFilter, WhereClause, OrderBy);
        }

        public static void LoadCombo(ref ComboBox ddList, string[] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause, string[] OrderBy)
        {
            LoadCombo(ref ddList, TextField, TextFormatString, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, OrderBy);
        }

        public static void LoadCombo(ref ComboBox ddList, string[] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string ParentFilter, string WhereClause, string[] OrderBy)
        {
            ddList.DataSource = null;
            ddList.Items.Clear();

            #region 轉換 orderby：方便 SQL Server 做 sorting，中文字排序可參考：https://dotblogs.com.tw/jamesfu/2013/06/04/collation
            if (SwitchLocale && TextField[0] == OrderBy[0] && OrderBy.Length == 1)
            {
                OrderBy[0] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "CountryName_Cht" :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "CountryName_Chs" :
                    "CountryName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.Country.SqlQuery(
                    String.Format(
                        "Select * from Country Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.Country()
                    {
                        CountryId = Guid.Empty,
                        CountryCode = "",
                        CountryName = BlankLineText,
                        CountryName_Chs = BlankLineText,
                        CountryName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "CountryId";
                ddList.DisplayMember = !SwitchLocale ? "CountryName" :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "CountryName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "CountryName_Chs" :
                    "CountryName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}