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
    
    public partial class ProductPrice
    {
        public System.Guid ProductPriceId { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid PriceTypeId { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ProductPriceType ProductPriceType { get; set; }
    }
}
