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
    
    public partial class InvtSubLedgerREC_Details
    {
        public System.Guid DetailsId { get; set; }
        public System.Guid HeaderId { get; set; }
        public string TxType { get; set; }
        public string TxNumber { get; set; }
        public Nullable<int> LineNumber { get; set; }
        public System.Guid ProductId { get; set; }
        public Nullable<decimal> QtyOrdered { get; set; }
        public Nullable<decimal> QtyReceived { get; set; }
        public Nullable<decimal> QtyReceivedSum { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> NetCost { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> NETRATECOST { get; set; }
        public Nullable<decimal> COEFCOST { get; set; }
        public Nullable<decimal> BILLQTY { get; set; }
        public Nullable<decimal> BILLUAMT { get; set; }
    
        public virtual InvtSubLedgerREC_Header InvtSubLedgerREC_Header { get; set; }
        public virtual Product Product { get; set; }
    }
}
