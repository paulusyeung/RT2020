using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RT2020.Helper
{
    public class DecimalHelper
    {
        /// <summary>
        /// Convert string to decimal
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal StringToDecimal(string source)
        {
            decimal result = 0;

            decimal.TryParse(source, NumberStyles.Any, CultureInfo.InvariantCulture, out result);

            return result;
        }
    }
}