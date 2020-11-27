using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class LineOfOperationEx
    {
        public static Guid GetLineOfOperationIdByName(string name)
        {
            var result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.LineOfOperation.Where(x => x.LineOfOperationName == name).FirstOrDefault();
                if (p != null) result = p.LineOfOperationId;
            }

            return result;
        }

        public static bool IsLineOfOperationCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.LineOfOperation.Where(x => x.LineOfOperationCode == code).FirstOrDefault();
                if (p != null) result = true;
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
                    "LineOfOperationName_Cht" :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "LineOfOperationName_Chs" :
                    "LineOfOperationName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.LineOfOperation.SqlQuery(
                    String.Format(
                        "Select * from LineOfOperation Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.LineOfOperation()
                    {
                        LineOfOperationId = Guid.Empty,
                        LineOfOperationCode = "",
                        LineOfOperationName = BlankLineText,
                        LineOfOperationName_Chs = BlankLineText,
                        LineOfOperationName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "LineOfOperationId";
                ddList.DisplayMember = !SwitchLocale ? "LineOfOperationName" :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "LineOfOperationName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "LineOfOperationName_Chs" :
                    "LineOfOperationName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}