using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;

namespace RT2020.Common.ModelEx
{
    public class SupplierEx
    {
        public static EF6.Supplier GetBySupplierId(Guid supplierId)
        {
            EF6.Supplier result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.Supplier.Find(supplierId);
            }

            return result;
        }

        public static EF6.Supplier GetBySupplierCode(string code)
        {
            EF6.Supplier result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.Supplier.Where(x => x.SupplierCode == code).FirstOrDefault();
            }

            return result;
        }

        public static Guid GetSupplierIdBySupplierCode(string code)
        {
            var result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Supplier.Where(x => x.SupplierCode == code).FirstOrDefault();
                if (item != null) result = item.SupplierId;
            }

            return result;
        }

        public static string GetSupplierNameById(Guid id, bool switchLanguage = false)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Supplier.Find(id);
                if (item != null)
                {
                    result = !switchLanguage ?
                        item.SupplierName : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                        item.SupplierName_Cht : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                        item.SupplierName_Chs :
                        item.SupplierName;
                }
            }

            return result;
        }

        public static string GetSupplierCodeById(Guid id)
        {
            string result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Supplier.Find(id);
                if (item != null) result = item.SupplierCode;
            }

            return result;
        }

        public static bool IsSupplierCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Supplier.Where(x => x.SupplierCode == code && x.Retired == false).FirstOrDefault();
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
                    "SupplierName_Cht" :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "SupplierName_Chs" :
                    "SupplierName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Supplier.SqlQuery(
                    String.Format(
                        "Select * from Supplier Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.Supplier()
                    {
                        SupplierId = Guid.Empty,
                        SupplierCode = "",
                        SupplierName = BlankLineText,
                        SupplierName_Chs = BlankLineText,
                        SupplierName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "SupplierId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "SupplierName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "SupplierName_Chs" :
                    "SupplierName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}