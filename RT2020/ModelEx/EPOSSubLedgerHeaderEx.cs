﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using Gizmox.WebGUI.Forms;

using RT2020.Helper;

namespace RT2020.ModelEx
{
    /// <summary>
    /// This extension provides access to the EF6 entity dbo.EPOSSubLedgerHeader.
    /// Date Created:   2020-12-18 07:04:39
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v2020.12.12.cst
    /// </summary>
    public class EPOSSubLedgerHeaderEx
    {
        public static bool DeleteChildToo(Guid headerId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oHeader = ctx.EPOSSubLedgerHeader.Find(headerId);
                if (oHeader != null)
                {
                    var details = ctx.EPOSSubLedgerDetails.Where(x => x.HeaderId == headerId);
                    foreach (var detail in details)
                    {
                        ctx.EPOSSubLedgerDetails.Remove(detail);
                    }
                    var tenders = ctx.EPOSSubLedgerTender.Where(x => x.HeaderId == headerId);
                    foreach (var tender in tenders)
                    {
                        ctx.EPOSSubLedgerTender.Remove(tender);
                    }

                    ctx.EPOSSubLedgerHeader.Remove(oHeader);
                    ctx.SaveChanges();

                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.EPOSSubLedgerHeader object from the database using the given HeaderId
        /// </summary>
        /// <param name="headerId">The primary key value</param>
        /// <returns>A EF6.EPOSSubLedgerHeader object</returns>
        public static EF6.EPOSSubLedgerHeader Get(Guid headerId)
        {
            EF6.EPOSSubLedgerHeader result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.EPOSSubLedgerHeader.Where(x => x.HeaderId == headerId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.EPOSSubLedgerHeader object from the database using the given QueryString
        /// </summary>
        /// <param name="headerId">The primary key value</param>
        /// <returns>A EF6.EPOSSubLedgerHeader object</returns>
        public static EF6.EPOSSubLedgerHeader Get(string whereClause)
        {
            EF6.EPOSSubLedgerHeader result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.EPOSSubLedgerHeader
                    .SqlQuery(string.Format("Select * from EPOSSubLedgerHeader Where {0}", whereClause))
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a list of EPOSSubLedgerHeader objects from the database
        /// </summary>
        /// <returns>A list containing all of the EPOSSubLedgerHeader objects in the database.</returns>
        public static List<EF6.EPOSSubLedgerHeader> GetList()
        {
            var whereClause = "1 = 1";
            return GetList(whereClause);
        }

        /// <summary>
        /// Get a list of EPOSSubLedgerHeader objects from the database
        /// ordered by primary key
        /// </summary>
        /// <returns>A list containing all of the EPOSSubLedgerHeader objects in the database ordered by the columns specified.</returns>
        public static List<EF6.EPOSSubLedgerHeader> GetList(string whereClause)
        {
            var orderBy = new string[] { "HeaderId" };
            return GetList(whereClause, orderBy);
        }

        /// <summary>
        /// Get a list of EPOSSubLedgerHeader objects from the database.
        /// ordered accordingly, example { "FieldName1", "FieldName2 DESC" }
        /// </summary>
        /// <returns>A list containing all of the EPOSSubLedgerHeader objects in the database.</returns>
        public static List<EF6.EPOSSubLedgerHeader> GetList(string whereClause, string[] orderBy)
        {
            List<EF6.EPOSSubLedgerHeader> result = new List<EF6.EPOSSubLedgerHeader>();

            var orderby = String.Join(",", orderBy.Select(x => x));

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.EPOSSubLedgerHeader
                    .SqlQuery(string.Format("Select * from EPOSSubLedgerHeader Where {0} Order By {1}", whereClause, orderby))
                    .AsNoTracking()
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Deletes a EF6.EPOSSubLedgerHeader object from the database.
        /// </summary>
        /// <param name="headerId">The primary key value</param>
        public static bool Delete(Guid headerId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.EPOSSubLedgerHeader.Find(headerId);
                if (item != null)
                {
                    ctx.EPOSSubLedgerHeader.Remove(item);
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
            //if (SwitchLocale && TextField[0] == OrderBy[0] && OrderBy.Length == 1)
            if (SwitchLocale && TextField == OrderBy[0] && OrderBy.Length == 1)
            {
                OrderBy[0] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "TxNumber" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TxNumber" :
                    "TxNumber";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.EPOSSubLedgerHeader.SqlQuery(
                    String.Format(
                        "Select * from EPOSSubLedgerHeader Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.EPOSSubLedgerHeader()
                    {
                        HeaderId = Guid.Empty,
                        TxType = "",
                        TxNumber = BlankLineText,
                        //CodeName_Chs = BlankLineText,
                        //CodeName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "HeaderId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "TxNumber" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TxNumber" :
                    "TxNumber";
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
                for (int i = 0; i < TextField.Length; i++)
                {
                    if (TextField[i] == "TxType")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "TxNumber" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "TxNumber" :
                            "TxNumber";
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
                    if (OrderBy[i] == "TxNumber")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "TxNumber" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "TxNumber" :
                            "TxNumber";
                    }
                }
            }
            var textField = String.Join(",", TextField.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.EPOSSubLedgerHeader.SqlQuery(
                    String.Format(
                        "Select * from EPOSSubLedgerHeader Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.EPOSSubLedgerHeader()
                    {
                        HeaderId = Guid.Empty,
                        TxType = "",
                        TxNumber = BlankLineText,
                        //CodeName_Chs = BlankLineText,
                        //CodeName_Cht = BlankLineText,
                    });
                }
                #endregion

                Dictionary<Guid, string> data = new Dictionary<Guid, string>();
                foreach (var item in list)
                {
                    var text = GetFormatedText(item, TextField, TextFormatString);
                    data.Add(item.HeaderId, text);
                }

                ddList.DataSource = data;
                ddList.ValueMember = "Value";
                ddList.DisplayMember = "Key";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        private static string GetFormatedText(EF6.EPOSSubLedgerHeader target, string[] textField, string textFormatString)
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