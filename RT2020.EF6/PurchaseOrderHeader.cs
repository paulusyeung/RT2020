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
    
    public partial class PurchaseOrderHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrderHeader()
        {
            this.PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
            this.PurchaseOrderHHTHeader = new HashSet<PurchaseOrderHHTHeader>();
            this.PurchaseOrderReceiveHeader = new HashSet<PurchaseOrderReceiveHeader>();
        }
    
        public System.Guid OrderHeaderId { get; set; }
        public string OrderNumber { get; set; }
        public int OrderType { get; set; }
        public Nullable<System.Guid> WorkplaceId { get; set; }
        public Nullable<System.Guid> StaffId { get; set; }
        public Nullable<System.Guid> SupplierId { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<System.Guid> TermsId { get; set; }
        public int CreditDays { get; set; }
        public decimal DepositPercentage { get; set; }
        public string PaymentRemarks { get; set; }
        public string ShipmentMethod { get; set; }
        public string ShipmentRemarks { get; set; }
        public bool PartialShipment { get; set; }
        public Nullable<System.DateTime> OrderOn { get; set; }
        public Nullable<System.DateTime> DeliverOn { get; set; }
        public Nullable<System.DateTime> CancellationOn { get; set; }
        public decimal GroupDiscount1 { get; set; }
        public decimal GroupDiscount2 { get; set; }
        public decimal GroupDiscount3 { get; set; }
        public string Source { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalQty { get; set; }
        public bool Settled { get; set; }
        public Nullable<System.DateTime> SettledOn { get; set; }
        public Nullable<System.DateTime> PostedOn { get; set; }
        public Nullable<System.Guid> PostedBy { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public decimal FreightChargePcn { get; set; }
        public decimal FreightChargeAmt { get; set; }
        public decimal HandlingChargePcn { get; set; }
        public decimal HandlingChargeAmt { get; set; }
        public decimal InsuranceChargePcn { get; set; }
        public decimal InsuranceChargeAmt { get; set; }
        public decimal OtherChargesPcn { get; set; }
        public decimal OtherChargesAmt { get; set; }
        public decimal ChargeCoefficient { get; set; }
        public bool StockReceiveAllocated { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string TYPEDTL { get; set; }
        public Nullable<System.Guid> RequestedBy { get; set; }
        public Nullable<bool> EXPORTFLAG { get; set; }
        public int Status { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public System.Guid ModifiedBy { get; set; }
        public bool Retired { get; set; }
        public Nullable<System.DateTime> RetiredOn { get; set; }
        public Nullable<System.Guid> RetiredBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderHHTHeader> PurchaseOrderHHTHeader { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderReceiveHeader> PurchaseOrderReceiveHeader { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual SupplierTerms SupplierTerms { get; set; }
        public virtual Workplace Workplace { get; set; }
    }
}
