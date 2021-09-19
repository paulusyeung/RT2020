using RT2020.Common.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;

namespace RT2020.ModelEx
{
    public class ProductEx
    {
        public static EF6.Product Get(Guid id)
        {
            EF6.Product result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.Product.Where(x => x.ProductId == id).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        public static EF6.Product Get(string queryString, string orderBy = "STKCODE")
        {
            EF6.Product result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.Product
                    .SqlQuery(string.Format("Select * from Product Where {0} Order By {1}", queryString, orderBy))
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            return result;
        }

        public static string GetSTKCODE(Guid id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Product.Where(x => x.ProductId == id).AsNoTracking().FirstOrDefault();
                if (item != null) result = item.STKCODE;
            }

            return result;
        }

        public static int Count(string queryString)
        {
            int result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.Product
                    .SqlQuery(string.Format("Select * from Product Where {0}", queryString))
                    .AsNoTracking()
                    .Count();
            }

            return result;
        }

        public static decimal GetRetailPrice(Guid id)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Product.Where(x => x.ProductId == id).AsNoTracking().FirstOrDefault();
                if (item != null) result = item.RetailPrice.Value;
            }

            return result;
        }

        public static string GetProductNameBySTKCODE(string stkcode, bool switchLocale = false)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Product.Where(x => x.STKCODE == stkcode).AsNoTracking().FirstOrDefault();
                if (item != null) result = !switchLocale ?
                    item.ProductName : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    item.ProductName_Chs : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    item.ProductName_Cht : item.ProductName;
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
                    "ProductName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "ProductName_Chs" :
                    "ProductName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Product.SqlQuery(
                    String.Format(
                        "Select * from Product Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.Product()
                    {
                        ProductId = Guid.Empty,
                        STKCODE = "",
                        ProductName = BlankLineText,
                        ProductName_Chs = BlankLineText,
                        ProductName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "ProductId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "ProductName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "ProductName_Chs" :
                    "ProductName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}