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
    }
}