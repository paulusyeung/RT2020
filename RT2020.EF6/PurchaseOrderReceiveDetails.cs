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
    
    public partial class PurchaseOrderReceiveDetails
    {
        public System.Guid ReceiveDetailsId { get; set; }
        public System.Guid ReceiveHeaderId { get; set; }
        public int LineNumber { get; set; }
        public Nullable<System.Guid> ProductId { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal UnitCost { get; set; }
        public decimal DiscountPcn { get; set; }
        public decimal NetUnitCost { get; set; }
        public decimal NetUnitCostCoefficient { get; set; }
        public decimal BillQty { get; set; }
        public decimal BillUnitAmount { get; set; }
        public string Notes { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual PurchaseOrderReceiveHeader PurchaseOrderReceiveHeader { get; set; }
    }
}