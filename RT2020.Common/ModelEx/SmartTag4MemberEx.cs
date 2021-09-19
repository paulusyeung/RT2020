using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;
using System.Data.Entity;

namespace RT2020.Common.ModelEx
{
    public class SmartTag4MemberEx
    {
        public static bool IsTagCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var tag = ctx.SmartTag4Member.Where(x => x.TagCode == code).FirstOrDefault();
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
                        var item = ctx.SmartTag4Member.Find(tagId);
                        if (item != null)
                        {
                            #region remove Options
                            var options = ctx.SmartTag4Member_Options.Where(x => x.TagId == item.TagId);
                            if (options.Count() > 0)
                            {
                                foreach (var option in options)
                                {
                                    ctx.SmartTag4Member_Options.Remove(option);
                                }
                            }
                            #endregion

                            #region remove in use by parents
                            var used = ctx.MemberSmartTag.Where(x => x.TagId == item.TagId);
                            if (used.Count() > 0)
                            {
                                foreach (var use in used)
                                {
                                    ctx.MemberSmartTag.Remove(use);
                                }
                            }
                            #endregion

                            ctx.SmartTag4Member.Remove(item);
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
                var item = ctx.SmartTag4Member.Where(x => x.Priority == priority).FirstOrDefault();
                if (item != null) result = item.TagId;
            }

            return result;
        }

        public static Guid GetIdByTagCodeAndPriority(string code, int priority)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SmartTag4Member.Where(x => x.TagCode == code && x.Priority == priority).FirstOrDefault();
                if (item != null) result = item.TagId;
            }

            return result;
        }

        public static EF6.SmartTag4Member GetByTagCode(string code)
        {
            EF6.SmartTag4Member result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Member.Where(x => x.TagCode == code).FirstOrDefault();
            }

            return result;
        }

        public static List<EF6.SmartTag4Member> GetListOrderBy(string[] orderBy, bool switchLocale = false)
        {
            List<EF6.SmartTag4Member> result = new List<EF6.SmartTag4Member>();

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

                result = ctx.SmartTag4Member.SqlQuery(
                    String.Format(
                        "Select * from SmartTag4Member Order By {0}",
                        order
                    ))
                    .AsNoTracking()
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.SmartTag4Member object from the database using the given TagId
        /// </summary>
        /// <param name="tagId">The primary key value</param>
        /// <returns>A EF6.SmartTag4Member object</returns>
        public static EF6.SmartTag4Member Get(Guid tagId)
        {
            EF6.SmartTag4Member result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Member.Where(x => x.TagId == tagId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.SmartTag4Member object from the database using the given QueryString
        /// </summary>
        /// <param name="tagId">The primary key value</param>
        /// <returns>A EF6.SmartTag4Member object</returns>
        public static EF6.SmartTag4Member Get(string whereClause)
        {
            EF6.SmartTag4Member result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Member
                    .SqlQuery(string.Format("Select * from SmartTag4Member Where {0}", whereClause))
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a list of SmartTag4Member objects from the database
        /// </summary>
        /// <returns>A list containing all of the SmartTag4Member objects in the database.</returns>
        public static List<EF6.SmartTag4Member> GetList()
        {
            var whereClause = "1 = 1";
            return GetList(whereClause);
        }

        /// <summary>
        /// Get a list of SmartTag4Member objects from the database
        /// ordered by primary key
        /// </summary>
        /// <returns>A list containing all of the SmartTag4Member objects in the database ordered by the columns specified.</returns>
        public static List<EF6.SmartTag4Member> GetList(string whereClause)
        {
            var orderBy = new string[] { "TagId" };
            return GetList(whereClause, orderBy);
        }

        /// <summary>
        /// Get a list of SmartTag4Member objects from the database.
        /// ordered accordingly, example { "FieldName1", "FieldName2 DESC" }
        /// </summary>
        /// <returns>A list containing all of the SmartTag4Member objects in the database.</returns>
        public static List<EF6.SmartTag4Member> GetList(string whereClause, string[] orderBy)
        {
            List<EF6.SmartTag4Member> result = new List<EF6.SmartTag4Member>();

            var orderby = String.Join(",", orderBy.Select(x => x));

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SmartTag4Member
                    .SqlQuery(string.Format("Select * from SmartTag4Member Where {0} Order By {1}", whereClause, orderby))
                    .AsNoTracking()
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Deletes a EF6.SmartTag4Member object from the database.
        /// </summary>
        /// <param name="tagId">The primary key value</param>
        public static bool Delete(Guid tagId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SmartTag4Member.Find(tagId);
                if (item != null)
                {
                    ctx.SmartTag4Member.Remove(item);
                    ctx.SaveChanges();
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
                    "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TagName_Chs" :
                    "TagName";
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.SmartTag4Member.SqlQuery(
                    String.Format(
                        "Select * from SmartTag4Member Where {0} Order By {1}",
                        String.IsNullOrEmpty(WhereClause) ? "1 = 1" : WhereClause,
                        orderby
                    ))
                    .AsNoTracking()
                    .ToList();

                #region BlankLine? 加個 blank item，置頂
                if (BlankLine)
                {
                    list.Insert(0, new EF6.SmartTag4Member()
                    {
                        TagId = Guid.Empty,
                        TagCode = "",
                        TagName = BlankLineText,
                        TagName_Chs = BlankLineText,
                        TagName_Cht = BlankLineText,
                    });
                }
                #endregion

                ddList.DataSource = list;
                ddList.ValueMember = "TagId";
                ddList.DisplayMember = !SwitchLocale ? TextField :
                    CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "TagName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "TagName_Chs" :
                    "TagName";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        #endregion
    }
}