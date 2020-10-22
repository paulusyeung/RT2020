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
    /// Txt Import or Export Master info
    /// </summary>
    [DelimitedRecord("	")]
    public class CAPTxtIEMaster
    {
        public String RecType;

        public String Location;

        public String Operator;

        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime RecvDate;

        public String Supplier;

        public String RefNumber;

        public String Remarks;

        public String TxNumber;
    }
}