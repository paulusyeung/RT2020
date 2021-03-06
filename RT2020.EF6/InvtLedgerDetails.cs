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
    
    public partial class InvtLedgerDetails
    {
        public System.Guid DetailsId { get; set; }
        public System.Guid HeaderId { get; set; }
        public string TxType { get; set; }
        public string TxNumber { get; set; }
        public Nullable<System.DateTime> TxDate { get; set; }
        public string SHOP { get; set; }
        public string TERMINAL { get; set; }
        public string OPERATOR { get; set; }
        public Nullable<int> LineNumber { get; set; }
        public Nullable<System.Guid> SubLedgerDetailsId { get; set; }
        public Nullable<System.Guid> ProductId { get; set; }
        public string Barcode { get; set; }
        public Nullable<decimal> CONFIRM_TRF_QTY { get; set; }
        public Nullable<int> Replenish { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> UnitAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AverageCost { get; set; }
        public Nullable<decimal> BasicPrice { get; set; }
        public string SerialNumber { get; set; }
        public string VendorRef { get; set; }
        public string Notes { get; set; }
    
        public virtual InvtLedgerHeader InvtLedgerHeader { get; set; }
        public virtual Product Product { get; set; }
    }
}
