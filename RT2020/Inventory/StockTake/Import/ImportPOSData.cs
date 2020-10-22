using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace RT2020.Inventory.StockTake.Import
{
    [DelimitedRecord("|")]
    public sealed class ImportPOSData
    {
        [FieldTrim(TrimMode.Both)]
        public String STKCODE;

        [FieldTrim(TrimMode.Both)]
        public String APPENDIX1;

        [FieldTrim(TrimMode.Both)]
        public String APPENDIX2;

        [FieldTrim(TrimMode.Both)]
        public String APPENDIX3;

        [FieldTrim(TrimMode.Both)]
        [FieldConverter(ConverterKind.Int32)]
        public Int32 SeqNum;

        [FieldTrim(TrimMode.Both)]
        public String Shop;

        [FieldTrim(TrimMode.Both)]
        public String Terminal;

        [FieldTrim(TrimMode.Both)]
        public String Operator;

        [FieldTrim(TrimMode.Both)]
        [FieldConverter(ConverterKind.Decimal)]
        public Decimal Qty;

        [FieldTrim(TrimMode.Both)]
        public String Shelf;

        [FieldTrim(TrimMode.Both)]
        public String Barcode;

        [FieldTrim(TrimMode.Both)]
        public String HHT;

        [FieldTrim(TrimMode.Both)]
        public String Keyboard;

        [FieldTrim(TrimMode.Both)]
        public String TxDate;

        [FieldTrim(TrimMode.Both)]
        public String Exported;

        [FieldTrim(TrimMode.Both)]
        public String ExportedOn;

        [FieldTrim(TrimMode.Both)]
        public String ExportNum;
    }
}
