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
    
    public partial class InvtSubLedgerRPL_Details
    {
        public System.Guid DetailsId { get; set; }
        public System.Guid HeaderId { get; set; }
        public string TxNumber { get; set; }
        public int LineNumber { get; set; }
        public Nullable<System.Guid> ProductId { get; set; }
        public Nullable<decimal> QtyRequested { get; set; }
        public Nullable<decimal> QtyIssued { get; set; }
        public string Remarks { get; set; }
    
        public virtual InvtSubLedgerRPL_Header InvtSubLedgerRPL_Header { get; set; }
        public virtual Product Product { get; set; }
    }
}
