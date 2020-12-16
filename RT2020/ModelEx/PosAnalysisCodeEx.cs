﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

using Gizmox.WebGUI.Forms;

using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class PosAnalysisCodeEx
    {
        public static EF6.PosAnalysisCode Get(Guid analuysisCodeId)
        {
            EF6.PosAnalysisCode result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.PosAnalysisCode.Where(x => x.AnalysisCodeId == analuysisCodeId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        public static EF6.PosAnalysisCode Get(string analuysisCode)
        {
            EF6.PosAnalysisCode result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.PosAnalysisCode.Where(x => x.AnalysisCode == analuysisCode).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        public static bool IsAnalysisCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.PosAnalysisCode.Where(x => x.AnalysisCode == code).FirstOrDefault();
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
            //string[] textField = { TextField };
            //LoadCombo(ref ddList, textField, "{0}", SwitchLocale, BlankLine, BlankLineText, ParentFilter, WhereClause, OrderBy);
            ddList.DataSource = null;
            ddList.Items.Clear();

            #region 轉換 orderby：方便 SQL Server 做 sorting，中文字排序可參考：https://dotblogs.com.tw/jamesfu/2013/06/04/collation
            //if (SwitchLocale && TextField[0] == OrderBy[0] && OrderBy.Length == 1)
            if (SwitchLocale && TextField == OrderBy[0] && OrderBy.Length == 1)
            {
                OrderBy[0] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "CodeName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "CodeName_Chs" :
                    "CodeName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.PosAnalysisCode.SqlQuery(
                    String.Format(
                        "Select * from PosAnalysisCode Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.PosAnalysisCode()
                    {
                        AnalysisCodeId = Guid.Empty,
                        AnalysisCode = "",
                        CodeName = BlankLineText,
                        CodeName_Chs = BlankLineText,
                        CodeName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "AnalysisCodeId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "CodeName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "CodeName_Chs" :
                    "CodeName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        public static void LoadCombo(ref ComboBox ddList, string[] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause, string[] OrderBy)
        {
        //    LoadCombo(ref ddList, TextField, TextFormatString, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, OrderBy);
        //}

        //public static void LoadCombo(ref ComboBox ddList, string[] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string ParentFilter, string WhereClause, string[] OrderBy)
        //{
            ddList.DataSource = null;
            ddList.Items.Clear();

            #region 轉換 orderby：方便 SQL Server 做 sorting，中文字排序可參考：https://dotblogs.com.tw/jamesfu/2013/06/04/collation
            if (SwitchLocale && OrderBy.Length > 0)
            {
                for (int i = 0; i < TextField.Length; i++)
                {
                    if (TextField[i] == "TxNumber")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "CodeName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "CodeName_Chs" :
                            "CodeName";
                    }
                }
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            #region 轉換 TextField language
            if (SwitchLocale && OrderBy.Length > 0)
            {
                for (int i = 0; i < OrderBy.Length; i++)
                {
                    if (OrderBy[i] == "CodeName")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "CodeName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "CodeName_Chs" :
                            "CodeName";
                    }
                }
            }
            var textField = String.Join(",", TextField.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.PosAnalysisCode.SqlQuery(
                    String.Format(
                        "Select * from PosAnalysisCode Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.PosAnalysisCode()
                    {
                        AnalysisCodeId = Guid.Empty,
                        AnalysisCode = "",
                        CodeName = BlankLineText,
                        CodeName_Chs = BlankLineText,
                        CodeName_Cht = BlankLineText,
                    });
                }
                #endregion

                Dictionary<Guid, string> data = new Dictionary<Guid, string>();
                foreach (var item in list)
                {
                    var text = GetFormatedText(item, TextField, TextFormatString);
                    data.Add(item.AnalysisCodeId, text);
                }

                ddList.DataSource = data;
                ddList.ValueMember = "Value";
                ddList.DisplayMember = "Key";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion

        private static string GetFormatedText(EF6.PosAnalysisCode target, string[] textField, string textFormatString)
        {
            for (int i = 0; i < textField.Length; i++)
            {
                PropertyInfo pi = target.GetType().GetProperty(textField[i]);
                textFormatString = textFormatString.Replace("{" + i.ToString() + "}", pi != null ? pi.GetValue(target, null).ToString() : string.Empty);
            }
            return textFormatString;
        }
    }
}