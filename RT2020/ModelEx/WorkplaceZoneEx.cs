using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;
using RT2020.EF6;

namespace RT2020.ModelEx
{
    public class WorkplaceZoneEx
    {
        public static bool IsZoneCodeInUse(string code)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var dept = ctx.WorkplaceZone.Where(x => x.ZoneCode == code).FirstOrDefault();
                if (dept != null) result = true;
            }

            return result;
        }

        public static string GetZoneNameById(Guid id)
        {
            string result = "";

            using (var ctx = new EF6.RT2020Entities())
            {
                var z = ctx.WorkplaceZone.Where(x => x.ZoneId == id).FirstOrDefault();
                if (z != null) result = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    z.ZoneName_Cht : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    z.ZoneName_Chs :
                    z.ZoneName;
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.WorkplaceZone object from the database using the given ZoneId
        /// </summary>
        /// <param name="zoneId">The primary key value</param>
        /// <returns>A EF6.WorkplaceZone object</returns>
        public static EF6.WorkplaceZone Get(Guid zoneId)
        {
            EF6.WorkplaceZone result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.WorkplaceZone.Where(x => x.ZoneId == zoneId).AsNoTracking().FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a EF6.WorkplaceZone object from the database using the given QueryString
        /// </summary>
        /// <param name="zoneId">The primary key value</param>
        /// <returns>A EF6.WorkplaceZone object</returns>
        public static EF6.WorkplaceZone Get(string whereClause)
        {
            EF6.WorkplaceZone result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.WorkplaceZone
                    .SqlQuery(string.Format("Select * from WorkplaceZone Where {0}", whereClause))
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            return result;
        }

        /// <summary>
        /// Get a list of WorkplaceZone objects from the database
        /// </summary>
        /// <returns>A list containing all of the WorkplaceZone objects in the database.</returns>
        public static List<EF6.WorkplaceZone> GetList()
        {
            var whereClause = "1 = 1";
            return GetList(whereClause);
        }

        /// <summary>
        /// Get a list of WorkplaceZone objects from the database
        /// ordered by primary key
        /// </summary>
        /// <returns>A list containing all of the WorkplaceZone objects in the database ordered by the columns specified.</returns>
        public static List<EF6.WorkplaceZone> GetList(string whereClause)
        {
            var orderBy = new string[] { "ZoneId" };
            return GetList(whereClause, orderBy);
        }

        /// <summary>
        /// Get a list of WorkplaceZone objects from the database.
        /// ordered accordingly, example { "FieldName1", "FieldName2 DESC" }
        /// </summary>
        /// <returns>A list containing all of the WorkplaceZone objects in the database.</returns>
        public static List<EF6.WorkplaceZone> GetList(string whereClause, string[] orderBy)
        {
            List<EF6.WorkplaceZone> result = new List<EF6.WorkplaceZone>();

            var orderby = String.Join(",", orderBy.Select(x => x));

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.WorkplaceZone
                    .SqlQuery(string.Format("Select * from WorkplaceZone Where {0} Order By {1}", whereClause, orderby))
                    .AsNoTracking()
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Deletes a EF6.WorkplaceZone object from the database.
        /// </summary>
        /// <param name="zoneId">The primary key value</param>
        public static bool Delete(Guid zoneId)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.WorkplaceZone.Find(zoneId);
                if (item != null)
                {
                    ctx.WorkplaceZone.Remove(item);
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
                    if (OrderBy[i] == "ZoneName")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "ZoneName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "ZoneName_Chs" :
                            "ZoneName";
                    }
                }
            }
            var orderby = String.Join(",", OrderBy.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var displayField = !SwitchLocale ?
                    TextField : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                    "ZoneName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                    "ZoneName_Chs" :
                    "ZoneName";
                var kvpList = ctx.Database.SqlQuery<ComboBoxHelper.ComboBoxItem>(
                    string.Format(
                        "Select ZoneId as [Key], {0} as [Value] from WorkplaceZone Where {1} Order By {2}",
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
                    if (OrderBy[i] == "ZoneName")
                    {
                        OrderBy[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "ZoneName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "ZoneName_Chs" :
                            "ZoneName";
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
                    if (TextField[i] == "ZoneName")
                    {
                        TextField[i] = CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                            "ZoneName_Cht" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                            "ZoneName_Chs" :
                            "ZoneName";
                    }
                }
            }
            var textField = String.Join(",", TextField.Select(x => "[" + x + "]"));
            #endregion

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.WorkplaceZone.SqlQuery(
                    String.Format(
                        "Select * from WorkplaceZone Where {0} Order By {1}",
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
                    data.Add(new KeyValuePair<Guid, string>(item.ZoneId, text));
                }

                ddList.DataSource = data.ToList();
                ddList.ValueMember = "Key";
                ddList.DisplayMember = "Value";
            }
            if (ddList.Items.Count > 0) ddList.SelectedIndex = 0;
        }

        private static string GetFormatedText(EF6.WorkplaceZone target, string[] textField, string textFormatString)
        {
            for (int i = 0; i < textField.Length; i++)
            {
                PropertyInfo pi = target.GetType().GetProperty(textField[i]);
                textFormatString = textFormatString.Replace("{" + i.ToString() + "}", pi != null ? pi.GetValue(target, null).ToString() : string.Empty);
            }
            return textFormatString;
        }

        #endregion

        #region 用 Json 代替 XML 嚟搞 MetadataXml
        /// <summary>
        /// 使用方法：
        /// var p = new ModelEx.WorkplaceZoneEx.Metadata();
        /// p.LoadJsondata(ZoneId);
        /// ...
        /// p.SaveJsondata();
        /// </summary>
        public class Metadata
        {
            Guid Id = Guid.Empty;
            JsonSchema JsonData { get; set; }

            public JsonSchema MetadataJson { get { return JsonData; } set { JsonData = value; } }

            /// <summary>
            /// Construct a new instance filled with defaults
            /// 要根據 Schema 修改
            /// </summary>
            public Metadata()
            {
                JsonData = new JsonSchema();

                #region 設定 defualt values
                JsonData.NextOrderNumber = "";
                JsonData.NextProductNumber = "";
                JsonData.NextQuotationNumber = "";
                JsonData.GmailAccount = "";
                JsonData.GmailPassword = "";
                JsonData.SimpleQueryIndex = 1;
                JsonData.CommonQueryIndex = 1;
                JsonData.CompletedQueryIndex = 1;
                JsonData.ScheduleQueryRange = 1;
                #endregion
            }

            public bool LoadJsondata(Guid id)
            {
                bool result = false;

                using (var ctx = new RT2020Entities())
                {
                    try
                    {
                        var item = ctx.WorkplaceZone.Find(id);
                        if (item != null)
                        {
                            this.Id = id;
                            this.JsonData = JsonConvert.DeserializeObject<JsonSchema>(item.MetadataXml);
                            result = true;
                        }
                    }
                    catch { }
                }

                return result;
            }

            public bool SaveJsondata()
            {
                bool result = false;

                if (this.Id != Guid.Empty)
                {
                    using (var ctx = new RT2020Entities())
                    {
                        try
                        {
                            var item = ctx.WorkplaceZone.Find(this.Id);
                            if (item != null)
                            {
                                item.MetadataXml = JsonConvert.SerializeObject(this.JsonData);
                                ctx.SaveChanges();
                                result = true;
                            }
                        }
                        catch { }
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 要根據 MetadataXml 內容修改呢個 Schema
        /// </summary>
        public class JsonSchema
        {
            public string NextOrderNumber { get; set; }
            public string NextProductNumber { get; set; }
            public string NextQuotationNumber { get; set; }
            public string GmailAccount { get; set; }
            public string GmailPassword { get; set; }
            public int SimpleQueryIndex { get; set; }
            public int CommonQueryIndex { get; set; }
            public int CompletedQueryIndex { get; set; }
            public int ScheduleQueryRange { get; set; }
        }
        #endregion
    }
}