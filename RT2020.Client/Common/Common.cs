using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using RT2020.DAL;

namespace RT2020.Client.Common
{
    class Utility
    {
        static public bool IsGuid(string value)
        {
            string regExPattern = @"^[{|\(]?[0-9a-fA-F]{8}[-]?([0-9a-fA-F]{4}[-]?){3}[0-9a-fA-F]{12}[\)|}]?$";
            Regex oRegex = new Regex(regExPattern);
            return oRegex.IsMatch(value);
        }

        /// <summary>
        /// Command Timeout value used in SqlCommand
        /// </summary>
        /// <returns> if CommandTimeoutValue is not set in the app.config, default to 20 seconds 
        /// </returns>
        public static int CommandTimeoutValue()
        {
            int result = 20;

            if (ConfigurationManager.AppSettings["CommandTimeoutValue"] != null)
            {
                result = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeoutValue"]);
            }

            return result;
        }

        /// <summary>
        /// Get Next TxNumber from dbo.SysSettings, or set the first record to dbo.SysSettings
        /// </summary>
        /// <returns>Next TxNumber to be used</returns>
        public static string GetNextTxNumber()
        {
            return QueuingTxNumber(DAL.Common.Enums.TxType.CAP);
        }

        /// <summary>
        /// Queuings the tx number.
        /// </summary>
        /// <param name="txType">Type of the transactions.</param>
        /// <returns></returns>
        public static string QueuingTxNumber(DAL.Common.Enums.TxType txType)
        {
            return QueuingTxNumber<DAL.Common.Enums.TxType>(txType);
        }

        /// <summary>
        /// Queuings the tx number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName">Name of the type. Enums: Common.Enums.TxType, Common.Enums.POType</param>
        /// <returns>TxNumber</returns>
        public static string QueuingTxNumber<T>(T typeName)
        {
            string query = " 1 = 1 ";
            string queuingType = string.Empty;

            switch (typeName.GetType().Name)
            {
                case "TxType":
                    DAL.Common.Enums.TxType txType = (DAL.Common.Enums.TxType)Convert.ChangeType(typeName, typeof(DAL.Common.Enums.TxType));
                    query = "QueuingType = '" + txType.ToString() + "'";
                    queuingType = txType.ToString();
                    break;
                case "POType":
                    DAL.Common.Enums.POType poType = (DAL.Common.Enums.POType)Convert.ChangeType(typeName, typeof(DAL.Common.Enums.POType));
                    query = "QueuingType = '" + poType.ToString() + "'";
                    queuingType = poType.ToString();
                    break;
            }

            long queuedTxNumber = 1;

            SystemQueue oQueue = SystemQueue.LoadWhere(query);
            if (oQueue == null)
            {
                oQueue = new SystemQueue();
                oQueue.QueuingType = queuingType;
                oQueue.LastNumber = "000000000000";
            }

            queuedTxNumber = Convert.ToInt64(oQueue.LastNumber) + 1;

            oQueue.LastNumber = queuedTxNumber.ToString();
            oQueue.Save();

            return queuedTxNumber.ToString().PadLeft(12, '0');
        }

        /// <summary>
        /// Gets the system label by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetSystemLabelByKey(string key)
        {
            String result = key;
            String lang = "en-US";

            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "zh-HK":
                case "zh-CHT":
                    lang = "zh-CHT";
                    break;
                case "zh-CHS":
                    lang = "zh-CHS";
                    break;
                case "en-US":
                default:
                    lang = "en-US";
                    break;
            }

            String sql = String.Format("LanguageCode = '{0}'", lang);

            //string sql = "LanguageCode = '" + (string)System.Web.HttpContext.Current.Session["UserLanguage"] + "'";

            SystemLabel oLabel = SystemLabel.LoadWhere(sql);
            if (oLabel != null)
            {
                PropertyInfo pi = oLabel.GetType().GetProperty(key.Trim().ToUpper());
                if (pi != null)
                {
                    result = pi.GetValue(oLabel, null).ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the Folder Name of the Apllication
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationRoot()
        {
            return GetApplicationRootRecursive(Application.StartupPath);
        }

        private static string GetApplicationRootRecursive(string path)
        {
            if (Directory.GetParent(path) != null)
            {
                if (new DirectoryInfo(path).Name == Application.ProductName)
                    return path;
                else
                    return GetApplicationRootRecursive(Directory.GetParent(path).FullName);
            }
            else
            {
                return Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            }
            //return null;
        }

        public static bool CheckSqlConnection()
        {
            int errorNumber = 0;

            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.SysDb);
            try
            {
                sqlConn.Open();
            }
            catch (SqlException sqlExc)
            {
                errorNumber = sqlExc.Number;
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }

            if (errorNumber >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Verify the single/double quote and remove it

        public static string VerifyQuotes(string valueToBeVerified)
        {
            if (valueToBeVerified.Contains("'"))
            {
                valueToBeVerified = valueToBeVerified.Replace("'", "");
            }

            if (valueToBeVerified.Contains("\""))
            {
                valueToBeVerified = valueToBeVerified.Replace("\"", "");
            }

            return valueToBeVerified;
        }

        public static bool StringBetween(String source, String min, String max)
        {
            bool result = false;

            if (
                (String.CompareOrdinal(source, min) == 0) || (String.CompareOrdinal(source, max) == 0) ||
                ((String.CompareOrdinal(source, min) > 0) && (String.CompareOrdinal(source, max) < 0))
                )
            {
                result = true;
            }
            return result;
        }
    }

    #region Enums
    public enum State
    {
        Loading,
        Loaded,
        Closing
    }

    public enum Modified
    {
        Clean,
        Dirty
    }

    public enum HandleEvents
    {
        Default,
        Busy,
        Noise
    }

    public enum Mode
    {
        New,
        Edit,
        Read
    }
    #endregion

    class UserLog
    {
        public enum Action { Login, InsRec, UpdRec, DelRec, Print, Backup, Restore }

        public static void Write(Action action, string notes)
        {
            //P_Control oUser = P_Control.Load(HKeDAL.Common.Config.CurrentUserId);
            //User_Log oLog = new User_Log();
            //oLog.LogDate    = DateTime.Now;
            //oLog.SecurityId = HKeDAL.Common.Config.CurrentUserId;
            //oLog.User_Code  = oUser.User_code;
            //if (notes.Trim() == String.Empty)
            //{
            //    oLog.ActionLog = action.ToString();
            //}
            //else
            //{
            //    oLog.ActionLog = action.ToString() + " - " + notes;
            //}
            //oLog.Save();
        }
    }

    class ComboBox
    {
        public static void FillView(ref System.Windows.Forms.ComboBox oBox)
        {
            oBox.Items.Clear();
            oBox.Items.Add("Last 7 days");
            oBox.Items.Add("Last 14 days");
            oBox.Items.Add("Last 30 days");
            oBox.Items.Add("Last 60 days");
            oBox.Items.Add("Last 90 days");
            oBox.Items.Add("All");
        }

        public static void FillStatus(ref System.Windows.Forms.ComboBox oBox)
        {
            string[] statusList = new string[] { "HOLD", "POST" };

            oBox.Items.Clear();

            for (int i = 0; i < statusList.Length; i++)
            {
                oBox.Items.Add(statusList[i]);
            }

            oBox.SelectedIndex = 0;
        }

        public static void LoadAppendix1(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Appendix1Code], [Appendix1Id] FROM [ProductAppendix1] WHERE [Retired] = 0 ORDER BY [Appendix1Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void LoadAppendix2(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Appendix2Code], [Appendix2Id] FROM [ProductAppendix2] WHERE [Retired] = 0 ORDER BY [Appendix2Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void LoadAppendix3(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Appendix3Code], [Appendix3Id] FROM [ProductAppendix3] WHERE [Retired] = 0 ORDER BY [Appendix3Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void LoadClass1(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Class1Code], [Class1Id] FROM [ProductClass1] WHERE [Retired] = 0 ORDER BY [Class1Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void LoadClass2(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Class2Code], [Class2Id] FROM [ProductClass2] WHERE [Retired] = 0 ORDER BY [Class2Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void LoadClass3(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Class3Code], [Class3Id] FROM [ProductClass3] WHERE [Retired] = 0 ORDER BY [Class3Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void LoadClass4(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Class4Code], [Class4Id] FROM [ProductClass4] WHERE [Retired] = 0 ORDER BY [Class4Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void LoadClass5(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Class5Code], [Class5Id] FROM [ProductClass5] WHERE [Retired] = 0 ORDER BY [Class5Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void LoadClass6(ref System.Windows.Forms.ComboBox cbo, bool NeedBlankItem)
        {
            string sql = "SELECT [Class6Code], [Class6Id] FROM [ProductClass6] WHERE [Retired] = 0 ORDER BY [Class6Code]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DAL.Common.ComboList comboList = new DAL.Common.ComboList();

            if (NeedBlankItem) comboList.Add(new DAL.Common.ComboItem(String.Empty, System.Guid.Empty));
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DAL.Common.ComboItem cboItem = new DAL.Common.ComboItem(reader.GetString(0), reader.GetGuid(1));

                    comboList.Add(cboItem);
                }
            }

            cbo.Items.Clear();
            cbo.DataSource = comboList;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Code";
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
    }

    class Config
    {
        public static void SetSqlConnectionString(string connString)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            // 如果从未建立, 就要采用 Add, 在这里并不需要
            //ConnectionStringSettings connStringSettings = new ConnectionStringSettings("myConnString", connString);
            //config.ConnectionStrings.ConnectionStrings.Add(connStringSettings);

            // 把新建的 Connection String 写进 SCMP.exe.config
            config.ConnectionStrings.ConnectionStrings["RT2020.Client.Properties.Settings.SysDb"].ConnectionString = connString;
            config.Save();

            // force refresh, 立即采用新建的 Connection String
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }

    #region Barcode

    public class BarcodeUtility
    {
        /// <summary>
        /// Generate Barcode (EAN-8[GTIN-8]/UPC-12[GTIN-12]/EAN-13[GTIN-13]/ITF-14[GTIN-14]/SSCC) Check Digit
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetCheckCode(string value)
        {
            char ch;
            int init = 0;

            for (int index = value.Length - 1; index >= 0; index -= 2)
            {
                ch = value[index];
                init += int.Parse(ch.ToString());
            }

            init *= 3;
            for (int index = value.Length - 2; index >= 0; index -= 2)
            {
                ch = value[index];
                init += int.Parse(ch.ToString());
            }

            init = 10 - (init % 10);
            if (init == 10)
            {
                init = 0;
            }

            return init.ToString();
        }
    }

    #endregion Barcode

    #region Date Time Helper
    public class DateTimeHelper
    {
        /// <summary>
        /// Convert the datetime value to string with time or without.
        /// If the value is equaled to 1900-01-01, it would return a emty value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="withTime"></param>
        /// <returns></returns>
        public static string DateTimeToString(DateTime value, bool withTime)
        {
            string formatString = GetDateFormat();
            if (withTime)
            {
                formatString = GetDateTimeFormat();
            }

            if (!value.Equals(new DateTime(1900, 1, 1)))
            {
                return value.ToString(formatString);
            }
            else
            {
                return string.Empty;
            }
        }
        public static string DateTimeToString(string value, bool withTime)
        {
            string result = String.Empty;
            string formatString = GetDateFormat();
            if (withTime)
            {
                formatString = GetDateTimeFormat();
            }
            try
            {
                DateTime source = DateTime.Parse(value);
                if (!source.Equals(new DateTime(1900, 1, 1)))
                {
                    result = source.ToString(formatString);
                }
            }
            catch { }
            return result;
        }

        public static string GetDateFormat()
        {
            string result = String.Empty;
            result = "yyyy-MM-dd";

            return result;
        }

        public static string GetDateTimeFormat()
        {
            string result = String.Empty;
            result = "yyyy-MM-dd HH:mm";

            return result;
        }
    }
    #endregion

    class Staff
    {
        public static String GetStaffNumber(Guid staffId)
        {
            String result = String.Empty;

            DAL.Staff oStaff = DAL.Staff.Load(staffId);
            if (oStaff != null)
            {
                result = oStaff.StaffNumber;
            }

            return result;
        }
    }

    class ProductPriceType
    {
        public static Guid GetTypeId(String priceType)
        {
            string sql = "PriceType = '" + priceType + "'";
            DAL.ProductPriceType oType = DAL.ProductPriceType.LoadWhere(sql);
            if (oType == null)
            {
                oType = new DAL.ProductPriceType();

                oType.PriceType = priceType;
                oType.CurrencyCode = "HKD";
                oType.CoreSystemPrice = false;

                oType.Save();
            }
            return oType.PriceTypeId;
        }
    }
}
