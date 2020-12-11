using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class PosTenderTypeEx
    {
        public static EF6.PosTenderType Get(Guid id)
        {
            EF6.PosTenderType result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.PosTenderType.Where(x => x.TypeId == id).AsNoTracking().FirstOrDefault();
                if (item != null) result = item;
            }

            return result;
        }

        public static EF6.PosTenderType Get(string typeCode, string currencyCode)
        {
            EF6.PosTenderType result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.PosTenderType.Where(x => x.TypeCode == typeCode && x.CurrencyCode == currencyCode).AsNoTracking().FirstOrDefault();
                if (item != null) result = item;
            }

            return result;
        }

        public static Guid GetId(string typeCode, string currencyCode)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.PosTenderType.Where(x => x.TypeCode == typeCode && x.CurrencyCode == currencyCode).AsNoTracking().FirstOrDefault();
                if (item != null) result = item.TypeId;
            }

            return result;
        }

        public static decimal GetExchageRte(string typeCode, string currencyCode)
        {
            decimal result = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.PosTenderType.Where(x => x.TypeCode == typeCode && x.CurrencyCode == currencyCode).AsNoTracking().FirstOrDefault();
                if (item != null) result = item.ExchangeRate.Value;
            }

            return result;
        }

        public static bool IsTypeCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.PosTenderType.Where(x => x.TypeCode == code).AsNoTracking().FirstOrDefault();
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
                    "TypeName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TypeName_Chs" :
                    "TypeName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PosTenderType.SqlQuery(
                    String.Format(
                        "Select * from PosTenderType Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.PosTenderType()
                    {
                        TypeId = Guid.Empty,
                        TypeCode = "",
                        TypeName = BlankLineText,
                        TypeName_Chs = BlankLineText,
                        TypeName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "TypeId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "TypeName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TypeName_Chs" :
                    "TypeName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}