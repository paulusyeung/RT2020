using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FileHelpers;

namespace RT2020.Inventory
{
    /// <summary>
    /// Txt Import or Export Details info
    /// </summary>
    [DelimitedRecord("	")]
    public class CAPTxtIEDetails
    {
        public String RecType;

        public String StockCode;

        public String Appendix1;

        public String Appendix2;

        public String Appendix3;

        [FieldConverter(ConverterKind.Int32)]
        public int ReceivedQty;

        [FieldConverter(typeof(MoneyConverter))]
        public decimal ReceivedUnitAmount;

    }

    public class MoneyConverter : ConverterBase
    {
        private int mDecimals = 2;

        public override object StringToField(string from)
        {
            // 2013.09.14 paulus: 唔明掂解要 / (10 ^ mDecimals)？　^ 係 bitwise exclusive-OR，冇咁複雜嘛？
            //return Convert.ToDecimal(Decimal.Parse(from) / (10 ^ mDecimals));
            return Decimal.Parse(from);
        }

        public override string FieldToString(object fieldValue)
        {
            Decimal v = Convert.ToDecimal(fieldValue);

            string res = v.ToString("#.##00");

            return res;
        }
    }
}
