//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RT2020.EF6
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvtSubLedgerTXF_Details
    {
        public System.Guid DetailsId { get; set; }
        public System.Guid HeaderId { get; set; }
        public string TxType { get; set; }
        public string TxNumber { get; set; }
        public Nullable<int> LineNumber { get; set; }
        public Nullable<decimal> QtyRequested { get; set; }
        public Nullable<decimal> QtyReceived { get; set; }
        public Nullable<decimal> QtyManualInput { get; set; }
        public Nullable<decimal> QtyHHT { get; set; }
        public Nullable<decimal> QtyConfirmed { get; set; }
        public string Remarks { get; set; }
        public System.Guid ProductId { get; set; }
    
        public virtual InvtSubLedgerTXF_Header InvtSubLedgerTXF_Header { get; set; }
        public virtual Product Product { get; set; }
    }
}
