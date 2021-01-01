using Gizmox.WebGUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.Helper
{
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

            switch (VWGContext.Current.CurrentUICulture.ToString())
            {
                case "zh-CHS":
                    result = "yyyy-MM-dd";
                    break;
                case "zh-CHT":
                    result = "dd/MM/yyyy";
                    break;
                case "en-US":
                default:
                    result = "dd/MM/yyyy";
                    break;
            }
            result = "yyyy-MM-dd";

            return result;
        }

        public static string GetDateTimeFormat()
        {
            string result = String.Empty;

            switch (VWGContext.Current.CurrentUICulture.ToString())
            {
                case "zh-CHS":
                    result = "yyyy-MM-dd HH:mm";
                    break;
                case "zh-CHT":
                    result = "dd/MM/yyyy HH:mm";
                    break;
                case "en-US":
                default:
                    result = "dd/MM/yyyy HH:mm";
                    break;
            }
            result = "yyyy-MM-dd HH:mm";

            return result;
        }

        /// <summary>
        /// HACK: 喺度搞咩呢？似乎係將 dd/MM/yyyy or MM/dd/yyyy 轉為 yyyy-MM-dd
        ///       如果係 10/09/2020 會變成 10 月，其實係 9 月點算？
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReformatDateTime(string value)
        {
            int index = value.IndexOf(" ");
            if (index > 0)
            {
                value = value.Remove(index);
                index = value.IndexOf("/");
                if (index > 0)
                {
                    string[] values = value.Split('/');
                    if (values.Length == 3)
                    {
                        if (Convert.ToInt32(values[1]) > 12)
                        {
                            value = values[2].Trim() + "-" + values[0].Trim() + "-" + values[1].Trim();
                        }
                        else
                        {
                            value = values[2].Trim() + "-" + values[1].Trim() + "-" + values[0].Trim();
                        }
                    }
                }
            }
            return value;
        }
    }
}