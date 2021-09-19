using System;
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
    public class SmartTag4SupplierEx
    {
        public static bool IsTagCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var tag = ctx.SmartTag4Supplier.Where(x => x.TagCode == code).FirstOrDefault();
                if (tag != null) result = true;
            }

            return result;
        }

        public static bool DeleteOptionsToo(Guid tagId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var item = ctx.SmartTag4Supplier.Find(tagId);
                        if (item != null)
                        {
                            #region remove Options
                            var options = ctx.SmartTag4Supplier_Options.Where(x => x.TagId == item.TagId);
                            if (options.Count() > 0)
                            {
                                foreach (var option in options)
                                {
                                    ctx.SmartTag4Supplier_Options.Remove(option);
                                }
                            }
                            #endregion

                            #region remove in use by parents
                            var used = ctx.SupplierSmartTag.Where(x => x.TagId == item.TagId);
                            if (used.Count() > 0)
                            {
                                foreach (var use in used)
                                {
                                    ctx.SupplierSmartTag.Remove(use);
                                }
                            }
                            #endregion

                            ctx.SmartTag4Supplier.Remove(item);
                            ctx.SaveChanges();

                            scope.Commit();
                            result = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }

            return result;
        }

        public static Guid GetIdByPriority(int priority)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SmartTag4Supplier.Where(x => x.Priority == priority).FirstOrDefault();
                if (item != null) result = item.TagId;
            }

            return result;
        }

        public static Guid GetIdByTagCodeAndPriority(string code, int priority)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SmartTag4Supplier.Where(x => x.TagCode == code && x.Priority == priority).FirstOrDefault();
                if (item != null) result = item.TagId;
            }

            return result;
        }

        public static EF6.SmartTag4Supplier GetByTagCode(string code)
        {
            EF6.SmartTag4Supplier result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Supplier.Where(x => x.TagCode == code).FirstOrDefault();
            }

            return result;
        }

        public static List<EF6.SmartTag4Supplier> GetListOrderBy(string[] orderBy, bool switchLocale = false)
        {
            List<EF6.SmartTag4Supplier> result = new List<EF6.SmartTag4Supplier>();

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

                result = ctx.SmartTag4Supplier.SqlQuery(
                    String.Format(
                        "Select * from SmartTag4Supplier Order By {0}",
                        order
                    ))
                    .AsNoTracking()
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.SmartTag4Supplier object from the database using the given TagId
        /// </summary>
        /// <param name="tagId">The primary key value</param>
        /// <returns>A EF6.SmartTag4Supplier object</returns>
        public static EF6.SmartTag4Supplier Get(Guid tagId)
        {
            EF6.SmartTag4Supplier result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Supplier.Where(x => x.TagId == tagId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.SmartTag4Supplier object from the database using the given QueryString
        /// </summary>
        /// <param name="tagId">The primary key value</param>
        /// <returns>A EF6.SmartTag4Supplier object</returns>
        public static EF6.SmartTag4Supplier Get(string whereClause)
        {
            EF6.SmartTag4Supplier result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Supplier
                    .SqlQuery(string.Format("Select * from SmartTag4Supplier Where {0}", whereClause))
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a list of SmartTag4Supplier objects from the database
        /// </summary>
        /// <returns>A list containing all of the SmartTag4Supplier objects in the database.</returns>
        public static List<EF6.SmartTag4Supplier> GetList()
        {
            var whereClause = "1 = 1";
            return GetList(whereClause);
        }

        /// <summary>
        /// Get a list of SmartTag4Supplier objects from the database
        /// ordered by primary key
        /// </summary>
        /// <returns>A list containing all of the SmartTag4Supplier objects in the database ordered by the columns specified.</returns>
        public static List<EF6.SmartTag4Supplier> GetList(string whereClause)
        {
            var orderBy = new string[] { "TagId" };
            return GetList(whereClause, orderBy);
        }

        /// <summary>
        /// Get a list of SmartTag4Supplier objects from the database.
        /// ordered accordingly, example { "FieldName1", "FieldName2 DESC" }
        /// </summary>
        /// <returns>A list containing all of the SmartTag4Supplier objects in the database.</returns>
        public static List<EF6.SmartTag4Supplier> GetList(string whereClause, string[] orderBy)
        {
            List<EF6.SmartTag4Supplier> result = new List<EF6.SmartTag4Supplier>();

            var orderby = String.Join(",", orderBy.Select(x => x));

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Supplier
                    .SqlQuery(string.Format("Select * from SmartTag4Supplier Where {0} Order By {1}", whereClause, orderby))
                    .AsNoTracking()
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Deletes a EF6.SmartTag4Supplier object from the database.
        /// </summary>
        /// <param name="tagId">The primary key value</param>
        public static bool Delete(Guid tagId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SmartTag4Supplier.Find(tagId);
                if (item != null)
                {
                    ctx.SmartTag4Supplier.Remove(item);
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
                    if (OrderBy[i] == "TagName")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "TagName_Chs" :
                            "TagName";
                    }
                }
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var displayField = !SwitchLocale ?
                    TextField : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TagName_Chs" :
                    "TagName";
                var kvpList = ctx.Database.SqlQuery<ComboBoxHelper.ComboBoxItem>(
                    string.Format(
                        "Select TagId as [Key], {0} as [Value] from SmartTag4Supplier Where {1} Order By {2}",
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
                    if (OrderBy[i] == "TagName")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "TagName_Chs" :
                            "TagName";
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
                    if (TextField[i] == "TagName")
                    {
                        TextField[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "TagName_Chs" :
                            "TagName";
                    }
                }
            }
            var textField = String.Join(",", TextField.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.SmartTag4Supplier.SqlQuery(
                    String.Format(
                        "Select * from SmartTag4Supplier Where {0} Order By {1}",
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
                    data.Add(new KeyValuePair<Guid, string>(item.TagId, text));
                }

                ddList.DataSource = data.ToList();
                ddList.ValueMember = "Key";
                ddList.DisplayMember = "Value";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        private static string GetFormatedText(EF6.SmartTag4Supplier target, string[] textField, string textFormatString)
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