using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace RT2020.Inventory.Transfer.Import
{
    [DelimitedRecord("	")]
    public class AdvanceTxferImport
    {
        [FieldTrim(TrimMode.Both)]
        public String LocNo;

        [FieldTrim(TrimMode.Both)]
        public String HHTNo;

        [FieldTrim(TrimMode.Both)]
        public String TxNumber;

        [FieldTrim(TrimMode.Both)]
        public String Barcode;

        [FieldTrim(TrimMode.Both)]
        public String Quantity;

        [FieldTrim(TrimMode.Both)]
        public String Keyboard;

        [FieldTrim(TrimMode.Both)]
        public String EntryDate;
    }
}
