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
    
    public partial class ProductSupplement
    {
        public System.Guid SupplementId { get; set; }
        public System.Guid ProductId { get; set; }
        public string VendorCurrencyCode { get; set; }
        public Nullable<decimal> VendorPrice { get; set; }
        public string ProductName_Memo { get; set; }
        public string ProductName_Pole { get; set; }
        public decimal VipDiscount_FixedItem { get; set; }
        public decimal VipDiscount_DiscountItem { get; set; }
        public decimal VipDiscount_NoDiscountItem { get; set; }
        public decimal StaffDiscount { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
