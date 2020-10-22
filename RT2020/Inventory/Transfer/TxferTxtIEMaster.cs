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
    /// Txfer Import or Export Txt master
    /// </summary>
    [DelimitedRecord("	")]
    public class TxferTxtIEMaster
    {
        public String RecType;

        public String FromLocation;

        public String ToLocation;

        public String Operator;

        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime TxDate;

        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime TxferDate;

        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime CompletionDate;

        public String RefNumber;

        public String Remarks;


    }
}