////RT2020.Purchasing
namespace RT2020.Purchasing
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;

    /// <summary>
    /// 数据处理类 PurchasingUtils
    /// </summary>
    public class PurchasingUtils
    {
        #region 数据类型的处理
        /// <summary>
        /// Gens the safe chars.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The safe chars.</returns>
        public static string GenSafeChars(string value)
        {
            if (value != null)
            {
                value = value.Replace("'", "''");
            }
            else
            {
                value = string.Empty;
            }

            return value;
        }
        #endregion

        #region 数据转换处理
        /// <summary>
        /// 数据处理类 Convert
        /// </summary>
        public class Convert
        {
            /// <summary>
            /// Converts the boolean.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>The boolean.</returns>
            public static bool ToBoolean(int value)
            {
                bool result = false;

                try
                {
                    result = System.Convert.ToBoolean(value);
                }
                catch
                {
                }

                return result;
            }

            /// <summary>
            /// Toes the boolean.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>The boolean.</returns>
            public static bool ToBoolean(string value)
            {
                bool result = false;
                if (value != string.Empty)
                {
                    try
                    {
                        result = System.Convert.ToBoolean(value);
                    }
                    catch
                    {
                    }
                }

                return result;
            }

            /// <summary>
            /// Toes the boolean.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>The boolean.</returns>
            public static bool ToBoolean(object value)
            {
                bool result = false;
                if (!(value is DBNull))
                {
                    try
                    {
                        result = System.Convert.ToBoolean(value);
                    }
                    catch
                    {
                    }
                }

                return result;
            }

            /// <summary>
            /// Toes the string.
            /// </summary>
            /// <param name="value">if set to <c>true</c> [value].</param>
            /// <returns>The string.</returns>
            public static string ToString(bool value)
            {
                string result = "0";
                int name = 0;
                try
                {
                    name = System.Convert.ToInt32(value);
                    result = System.Convert.ToString(name);
                }
                catch
                {
                }

                return result;
            }

            /// <summary>
            /// Toes the string.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>The string.</returns>
            public static string ToString(int value)
            {
                string result = "0";
                int name = 0;
                try
                {
                    name = System.Convert.ToInt32(value);
                    result = System.Convert.ToString(name);
                }
                catch
                {
                }

                return result;
            }

            /// <summary>
            /// Toes the int32.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>The int32.</returns>
            public static int ToInt32(string value)
            {
                int result = 0;
                try
                {
                    result = System.Convert.ToInt32(value);
                }
                catch
                {
                }

                return result;
            }

            /// <summary>
            /// Toes the decimal.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>The decimal.</returns>
            public static decimal ToDecimal(string value)
            {
                decimal result = 0;
                if (value == string.Empty)
                {
                    return 0;
                }

                try
                {
                    result = System.Convert.ToDecimal(value);
                }
                catch
                {
                }

                return result;
            }

            /// <summary>
            /// Toes the GUID.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>The is GUID.</returns>
            public static Guid ToGuid(object value)
            {
                Guid result = Guid.Empty;

                try
                {
                    result = new Guid(value.ToString());
                }
                catch
                {
                }

                return result;
            }
        }
        #endregion
    }
}
