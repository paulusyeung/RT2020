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
    
    public partial class FepBatchTender
    {
        public System.Guid TenderId { get; set; }
        public System.Guid HeaderId { get; set; }
        public string TxType { get; set; }
        public string TxNumber { get; set; }
        public Nullable<System.DateTime> TxDate { get; set; }
        public System.Guid TypeId { get; set; }
        public string CurrencyCode { get; set; }
        public string CardNumber { get; set; }
        public string AuthorizationCode { get; set; }
        public Nullable<decimal> TenderAmount { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<decimal> InLocalCurrency { get; set; }
        public string ECR_TRACENUM { get; set; }
        public string ECR_RESPONSE { get; set; }
    
        public virtual FepBatchHeader FepBatchHeader { get; set; }
        public virtual PosTenderType PosTenderType { get; set; }
    }
}
