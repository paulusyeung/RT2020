using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;
using System.Data.Entity;

namespace RT2020.Common.ModelEx
{
    public class ProductPriceTypeEx
    {
        public static bool IsPriceTypeInUse(string type)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var priceType = ctx.ProductPriceType.Where(x => x.PriceType == type).FirstOrDefault();
                if (priceType != null) result = true;
            }

            return result;
        }

        public static EF6.ProductPriceType Get(Guid id)
        {
            EF6.ProductPriceType result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.ProductPriceType.Where(x => x.PriceTypeId == id).AsNoTracking().FirstOrDefault();
            }

            return result;
        }


        public static string GetPriceTypeById(Guid id)
        { 
            string result = string.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var priceType = ctx.ProductPriceType.Find(id);
                if (priceType != null)
                {
                    result = priceType.PriceType;
                }
            }

            return result;
        }

        public static Guid GetIdByPriceType(string type)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductPriceType.Where(x => x.PriceType == type).FirstOrDefault();
                if (item == null)
                {   //* 點解冇就 create ?
                    item = new EF6.ProductPriceType();
                    item.PriceTypeId = Guid.NewGuid();
                    item.PriceType = type;
                    item.CurrencyCode = "HKD";
                    item.CoreSystemPrice = false;

                    ctx.ProductPriceType.Add(item);
                    ctx.SaveChanges();
                }
                result = item.PriceTypeId;
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
                    "PriceType" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "PriceType" :
                    "PriceType";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.ProductPriceType.SqlQuery(
                    String.Format(
                        "Select * from ProductPriceType Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.ProductPriceType()
                    {
                        PriceTypeId = Guid.Empty,
                        PriceType = "",
                        //PhoneName = BlankLineText,
                        //PhoneName_Chs = BlankLineText,
                        //PhoneName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "PriceTypeId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "PriceType" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "PriceType" :
                    "PriceType";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}