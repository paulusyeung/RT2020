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

namespace RT2020.Inventory.Transfer
{
    /// <summary>
    /// Txfer Import or Export Txt Details
    /// </summary>
    [DelimitedRecord("	")]
    public class TxferTxtIEDetails
    {
        public String RecType;

        public String StockCode;

        public String Appendix1;

        public String Appendix2;

        public String Appendix3;

        [FieldConverter(ConverterKind.Int32)]
        public int RequiredQty;

        [FieldConverter(ConverterKind.Int32)]
        public int TxferQty;

        public String Remarks;

    }
}
