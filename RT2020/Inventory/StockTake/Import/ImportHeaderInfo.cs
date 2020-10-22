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
    public sealed class ImportHeaderInfo
    {
        [FieldTrim(TrimMode.Both)]
        public String RecordType;

        [FieldTrim(TrimMode.Both)]
        public String ShelfId;

        [FieldTrim(TrimMode.Both)]
        public String ShelfName;

        [FieldTrim(TrimMode.Both)]
        [FieldConverter(ConverterKind.Decimal)]
        public Decimal Qty;

        [FieldTrim(TrimMode.Both)]
        [FieldConverter(ConverterKind.Decimal)]
        public Decimal TotalLine;

        [FieldTrim(TrimMode.Both)]
        public String LastUpdatedOn;
    }
}
