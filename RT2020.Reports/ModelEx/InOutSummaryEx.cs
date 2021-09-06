using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT2020.Reports.ModelEx
{
    public partial class InOutSummaryEx
    {
        [Table(Name = "ProductInOutSummary")]
        public class Product
        {
            [PrimaryKey]
            public Guid Id { get; set; }
            public string TxType { get; set; }
            public string TRRNO { get; set; }
            public string LOCNO { get; set; }
            public string STKCODE { get; set; }
            public string APPENDIX1 { get; set; }
            public string APPENDIX2 { get; set; }
            public string APPENDIX3 { get; set; }
            public int SEQNO { get; set; }
            public string DESCRIPTION { get; set; }
            public decimal PW_CDQTY { get; set; }
            public decimal BF_AVRCOST { get; set; }
            public decimal AVRCOST { get; set; }
            public decimal QTY { get; set; }
            public decimal PCS_BFQTY { get; set; }
            public decimal PW_BFQTY { get; set; }
            public decimal BFQTY { get; set; }
            public decimal BFAMT { get; set; }
            public decimal RECQTY { get; set; }
            public decimal RECAMT { get; set; }
            public decimal CAPQTY { get; set; }
            public decimal CAPAMT { get; set; }
            public decimal REJQTY { get; set; }
            public decimal REJAMT { get; set; }
            public decimal ADJQTY { get; set; }
            public decimal ADJAMT { get; set; }
            public decimal TXIQTY { get; set; }
            public decimal TXIAMT { get; set; }
            public decimal TXOQTY { get; set; }
            public decimal TXOAMT { get; set; }
            public decimal CASQTY { get; set; }
            public decimal CASAMT { get; set; }
            public decimal CRTQTY { get; set; }
            public decimal CRTAMT { get; set; }
            public decimal VODQTY { get; set; }
            public decimal VODAMT { get; set; }
            public decimal SALQTY { get; set; }
            public decimal SALAMT { get; set; }
            public decimal SRTQTY { get; set; }
            public decimal SRTAMT { get; set; }
            public decimal CDQTY { get; set; }
            public decimal CDAMT { get; set; }
            public decimal CAL_CDQTY { get; set; }
            public decimal CAL_CDAMT { get; set; }
            public decimal DIFF_CDQTY { get; set; }
            public decimal DIFF_CDAMT { get; set; }
        }
    }
}
