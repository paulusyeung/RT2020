using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class WorkplaceEx
    {
        public static EF6.Workplace GetWorkplaceById(Guid id)
        {
            EF6.Workplace result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.Workplace.Where(x => x.WorkplaceId == id).FirstOrDefault();
                if (p != null) result = p;
            }

            return result;
        }

        public static Guid GetWorkplaceIdByCode(string code)
        {
            var result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.Workplace.Where(x => x.WorkplaceCode == code).FirstOrDefault();
                if (p != null) result = p.WorkplaceId;
            }

            return result;
        }

        public static string GetWorkplaceCodeById(Guid id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.Workplace.Where(x => x.WorkplaceId == id).FirstOrDefault();
                if (p != null) result = p.WorkplaceCode;
            }

            return result;
        }

        public static string GetWorkplacePasswordById(Guid id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.Workplace.Where(x => x.WorkplaceId == id).FirstOrDefault();
                if (p != null) result = p.Password;
            }

            return result;
        }

        public static string GetWorkplaceNameById(Guid id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.Workplace.Where(x => x.WorkplaceId == id).FirstOrDefault();
                if (p != null) result = p.WorkplaceName;
            }

            return result;
        }

        public static bool IsWorkplaceCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var p = ctx.Workplace.Where(x => x.WorkplaceCode == code).FirstOrDefault();
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
                    "WorkplaceName_Cht" :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "WorkplaceName_Chs" :
                    "WorkplaceName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.Workplace.SqlQuery(
                    String.Format(
                        "Select * from Workplace Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.Workplace()
                    {
                        WorkplaceId = Guid.Empty,
                        WorkplaceCode = "",
                        WorkplaceName = BlankLineText,
                        WorkplaceName_Chs = BlankLineText,
                        WorkplaceName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "WorkplaceId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "WorkplaceName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "WorkplaceName_Chs" :
                    "WorkplaceName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}