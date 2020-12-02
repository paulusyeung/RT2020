using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class StaffGroupEx
    {
        public static EF6.StaffGroup GetById(Guid id)
        {
            EF6.StaffGroup result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sg = ctx.StaffGroup.Where(x => x.GroupId == id).FirstOrDefault();
                if (sg != null) result = sg;
            }

            return result;
        }

        public static string GetGradeCodeById(Guid id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var sg = ctx.StaffGroup.Where(x => x.GroupId == id).FirstOrDefault();
                if (sg != null) result = sg.GradeCode;
            }

            return result;
        }

        public static bool IsGradeCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sg = ctx.StaffGroup.Where(x => x.GradeCode == code).FirstOrDefault();
                if (sg != null) result = true;
            }

            return result;
        }

        public static bool Delete(Guid id)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sg = ctx.StaffGroup.Find(id);
                if (sg != null)
                {
                    ctx.StaffGroup.Remove(sg);
                    result = true;
                }
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
                    "GradeName_Cht" :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "GradeName_Chs" :
                    "GradeName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.StaffGroup.SqlQuery(
                    String.Format(
                        "Select * from StaffGroup Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                        ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.StaffGroup()
                    {
                        GroupId = Guid.Empty,
                        GradeCode = "",
                        GradeName = BlankLineText,
                        GradeName_Chs = BlankLineText,
                        GradeName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "GroupId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "GradeName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "GradeName_Chs" :
                    "GradeName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}