﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;
using System.Reflection;
using System.ComponentModel;
using System.Data.Entity;

namespace RT2020.Common.ModelEx
{
    public class ProductAppendix1Ex
    {
        public static bool IsAppendixCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductAppendix1.Where(x => x.Appendix1Code == code).FirstOrDefault();
                if (item != null) result = true;
            }

            return result;
        }

        public static Guid GetIdByInitial(string initial)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductAppendix1.Where(x => x.Appendix1Initial == initial).FirstOrDefault();
                if (item != null) result = item.Appendix1Id;
            }

            return result;
        }

        public static Guid GetIdByCode(string code)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductAppendix1.Where(x => x.Appendix1Code == code).FirstOrDefault();
                if (item != null) result = item.Appendix1Id;
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.ProductAppendix1 object from the database using the given Appendix1Id
        /// </summary>
        /// <param name="appendix1Id">The primary key value</param>
        /// <returns>A EF6.ProductAppendix1 object</returns>
        public static EF6.ProductAppendix1 Get(Guid appendix1Id)
        {
            EF6.ProductAppendix1 result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.ProductAppendix1.Where(x => x.Appendix1Id == appendix1Id).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.ProductAppendix1 object from the database using the given QueryString
        /// </summary>
        /// <param name="appendix1Id">The primary key value</param>
        /// <returns>A EF6.ProductAppendix1 object</returns>
        public static EF6.ProductAppendix1 Get(string whereClause)
        {
            EF6.ProductAppendix1 result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.ProductAppendix1
                    .SqlQuery(string.Format("Select * from ProductAppendix1 Where {0}", whereClause))
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a list of ProductAppendix1 objects from the database
        /// </summary>
        /// <returns>A list containing all of the ProductAppendix1 objects in the database.</returns>
        public static List<EF6.ProductAppendix1> GetList()
        {
            var whereClause = "1 = 1";
            return GetList(whereClause);
        }

        /// <summary>
        /// Get a list of ProductAppendix1 objects from the database
        /// ordered by primary key
        /// </summary>
        /// <returns>A list containing all of the ProductAppendix1 objects in the database ordered by the columns specified.</returns>
        public static List<EF6.ProductAppendix1> GetList(string whereClause)
        {
            var orderBy = new string[] { "Appendix1Id" };
            return GetList(whereClause, orderBy);
        }

        /// <summary>
        /// Get a list of ProductAppendix1 objects from the database.
        /// ordered accordingly, example { "FieldName1", "FieldName2 DESC" }
        /// </summary>
        /// <returns>A list containing all of the ProductAppendix1 objects in the database.</returns>
        public static List<EF6.ProductAppendix1> GetList(string whereClause, string[] orderBy)
        {
            List<EF6.ProductAppendix1> result = new List<EF6.ProductAppendix1>();

            var orderby = String.Join(",", orderBy.Select(x => x));

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.ProductAppendix1
                    .SqlQuery(string.Format("Select * from ProductAppendix1 Where {0} Order By {1}", whereClause, orderby))
                    .AsNoTracking()
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Deletes a EF6.ProductAppendix1 object from the database.
        /// </summary>
        /// <param name="appendix1Id">The primary key value</param>
        public static bool Delete(Guid appendix1Id)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductAppendix1.Find(appendix1Id);
                if (item != null)
                {
                    ctx.ProductAppendix1.Remove(item);
                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }

        #region Load ComboBox
        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale)
        {
            LoadCombo(ref ddList, TextField, SwitchLocale, false, string.Empty, string.Empty, new string[] { TextField });
        }

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
        public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, string[] OrderBy)
        {
            LoadCombo(ref ddList, TextField, SwitchLocale, false, string.Empty, string.Empty, OrderBy);
        }

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
		public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause)
        {
            LoadCombo(ref ddList, TextField, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, new String[] { TextField });
        }

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
		public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause, string[] OrderBy)
        {
            LoadCombo(ref ddList, TextField, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, OrderBy);
        }

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="ParentFilter">e.g. "ForeignFieldName = 'value'"</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
		public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string ParentFilter, string WhereClause, string[] OrderBy)
        {
            ddList.DataSource = null;
            ddList.Items.Clear();

            #region 轉換 orderby：方便 SQL Server 做 sorting，中文字排序可參考：https://dotblogs.com.tw/jamesfu/2013/06/04/collation
            if (SwitchLocale)
            {
                for (int i = 0; i < OrderBy.Length; i++)
                {
                    if (OrderBy[i] == "Appendix1Name")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "Appendix1Name_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "Appendix1Name_Chs" :
                            "Appendix1Name";
                    }
                }
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var displayField = !SwitchLocale ?
                    TextField : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "Appendix1Name_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "Appendix1Name_Chs" :
                    "Appendix1Name";
                var kvpList = ctx.Database.SqlQuery<ComboBoxHelper.ComboBoxItem>(
                    string.Format(
                        "Select Appendix1Id as [Key], {0} as [Value] from ProductAppendix1 Where {1} Order By {2}",
                        displayField, string.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .ToDictionary(x => x.Key, x => x.Value)
                    .ToList();
                if (BlankLine) kvpList.Insert(0, new KeyValuePair<Guid, string>(Guid.Empty, ""));
                ddList.DataSource = kvpList;
                ddList.ValueMember = "Key";
                ddList.DisplayMember = "Value";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. new string[]{"FieldName1", "FieldName2", ...}</param>
        /// <param name="TextFormatString">e.g. "{0} - {1}"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
		public static void LoadCombo(ref ComboBox ddList, string[] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause, string[] OrderBy)
        {
            ddList.DataSource = null;
            ddList.Items.Clear();

            #region 轉換 orderby：方便 SQL Server 做 sorting，中文字排序可參考：https://dotblogs.com.tw/jamesfu/2013/06/04/collation
            if (SwitchLocale && OrderBy.Length > 0)
            {
                for (int i = 0; i < OrderBy.Length; i++)
                {
                    if (OrderBy[i] == "Appendix1Name")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "Appendix1Name_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "Appendix1Name_Chs" :
                            "Appendix1Name";
                    }
                }
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            #region 轉換 TextField language
            if (SwitchLocale && TextField.Length > 0)
            {
                for (int i = 0; i < TextField.Length; i++)
                {
                    if (TextField[i] == "Appendix1Name")
                    {
                        TextField[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "Appendix1Name_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "Appendix1Name_Chs" :
                            "Appendix1Name";
                    }
                }
            }
            var textField = String.Join(",", TextField.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.ProductAppendix1.SqlQuery(
                    String.Format(
                        "Select * from ProductAppendix1 Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                BindingList<KeyValuePair<Guid, string>> data = new BindingList<KeyValuePair<Guid, string>>();
                if (BlankLine) data.Insert(0, new KeyValuePair<Guid, string>(Guid.Empty, ""));

                foreach (var item in list)
                {
                    var text = GetFormatedText(item, TextField, TextFormatString);
                    data.Add(new KeyValuePair<Guid, string>(item.Appendix1Id, text));
                }

                ddList.DataSource = data.ToList();
                ddList.ValueMember = "Key";
                ddList.DisplayMember = "Value";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        private static string GetFormatedText(EF6.ProductAppendix1 target, string[] textField, string textFormatString)
        {
            for (int i = 0; i < textField.Length; i++)
            {
                PropertyInfo pi = target.GetType().GetProperty(textField[i]);
                textFormatString = textFormatString.Replace("{" + i.ToString() + "}", pi != null ? pi.GetValue(target, null).ToString() : string.Empty);
            }
            return textFormatString;
        }

        #endregion
    }
}