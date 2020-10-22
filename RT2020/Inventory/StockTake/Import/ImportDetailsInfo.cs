using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace RT2020.Inventory.StockTake.Import
{
    [IgnoreFirst(1)]
    [IgnoreLast(1)]
    [DelimitedRecord("	")]
    public sealed class ImportDetailsInfo
    {
        [FieldTrim(TrimMode.Both)]
        public String RecordType;

        [FieldTrim(TrimMode.Both)]
        public String LocId;

        [FieldTrim(TrimMode.Both)]
        public String HHTId;

        [FieldTrim(TrimMode.Both)]
        public String HHTTxNumber;

        [FieldTrim(TrimMode.Both)]
        public String ShelfId;

        [FieldTrim(TrimMode.Both)]
        public String SeqNum;

        [FieldTrim(TrimMode.Both)]
        public String Barcode;

        [FieldTrim(TrimMode.Both)]
        [FieldConverter(ConverterKind.Decimal)]
        public Decimal Qty;

        [FieldTrim(TrimMode.Both)]
        public String KeyIn;

        [FieldTrim(TrimMode.Both)]
        public String LastUpdatedOn;
    }
}