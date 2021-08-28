using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT2020.Reports.ModelEx
{
    public partial class InOutHistoryEx
    {
        [Table(Name = "Product")]
        public class Product
        {
            public Product()
            {
                this.Tx = new List<InOutHistoryEx.Tx>();
            }

            [PrimaryKey]
            public Guid Id { get; set; }
            public string STKCODE { get; set; }
            public string APPENDIX1 { get; set; }
            public string APPENDIX2 { get; set; }
            public string APPENDIX3 { get; set; }
            public string CLASS1 { get; set; }
            public string CLASS2 { get; set; }
            public string CLASS3 { get; set; }
            public string CLASS4 { get; set; }
            public string CLASS5 { get; set; }
            public string CLASS6 { get; set; }
            public decimal BFQTY { get; set; }
            public decimal BFAMT { get; set; }
            public decimal CDQTY { get; set; }
            public decimal CDAMT { get; set; }
            public List<Tx> Tx { get; set; }
        }

        [Table(Name = "Transaction")]
        public class Tx
        {
            [PrimaryKey]
            public Guid Id { get; set; }
            public string STKCODE { get; set; }
            public string APPENDIX1 { get; set; }
            public string APPENDIX2 { get; set; }
            public string APPENDIX3 { get; set; }
            public string CLASS1 { get; set; }
            public string CLASS2 { get; set; }
            public string CLASS3 { get; set; }
            public string CLASS4 { get; set; }
            public string CLASS5 { get; set; }
            public string CLASS6 { get; set; }
            public DateTime TxDate { get; set; }
            public string TxType { get; set; }
            public string TxNumber { get; set; }
            public decimal QTYIN { get; set; }
            public decimal QTYOUT { get; set; }
            public decimal Price { get; set; }
            public decimal AverageCost { get; set; }
            public string Reference { get; set; }
            public string FromLocation { get; set; }
            public string ToLocation { get; set; }
            public string SupplierCode { get; set; }
            public string Remarks { get; set; }
        }

        /** deprecated
        public partial class Journal
        {
            public Journal()
            {
                this.Tx = new List<InOutHistoryEx.Tx>();
            }

            [Association(ThisKey = "Id", OtherKey = "Id")]
            public Product Product { get; set; }
            [Association(ThisKey = "Id", OtherKey = "Id")]
            public List<Tx> Tx { get; set; }
        }
        */
    }
}
