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
    
    public partial class EPOSBatchHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EPOSBatchHeader()
        {
            this.EPOSBatchDetails = new HashSet<EPOSBatchDetails>();
            this.EPOSBatchTender = new HashSet<EPOSBatchTender>();
        }
    
        public System.Guid HeaderId { get; set; }
        public string TxNumber { get; set; }
        public string TxType { get; set; }
        public Nullable<System.DateTime> TxDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> DepositAmount { get; set; }
        public System.Guid StaffId { get; set; }
        public Nullable<System.Guid> Staff1 { get; set; }
        public Nullable<System.Guid> Staff2 { get; set; }
        public System.Guid WorkplaceId { get; set; }
        public Nullable<System.Guid> VsLocationId { get; set; }
        public Nullable<System.Guid> MemberId { get; set; }
        public Nullable<System.Guid> SupplierId { get; set; }
        public string Reference { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> PostedOn { get; set; }
        public Nullable<System.Guid> PostedBy { get; set; }
        public Nullable<bool> Posted { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> EXP_DELIVER { get; set; }
        public string CONFIRM_TRF { get; set; }
        public string SEX { get; set; }
        public string RACE { get; set; }
        public string AGE { get; set; }
        public string POSTNEG { get; set; }
        public string EVT_CODE { get; set; }
        public Nullable<decimal> TRNAMT_TTLSALES { get; set; }
        public Nullable<decimal> TRNAMT_NETSALES { get; set; }
        public Nullable<decimal> TRNAMT_TAX { get; set; }
        public Nullable<decimal> TAX_RATE { get; set; }
        public string PRICE_TYPE { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public string ANALYSIS_CODE01 { get; set; }
        public string ANALYSIS_CODE02 { get; set; }
        public string ANALYSIS_CODE03 { get; set; }
        public string ANALYSIS_CODE04 { get; set; }
        public string ANALYSIS_CODE05 { get; set; }
        public string ANALYSIS_CODE06 { get; set; }
        public string ANALYSIS_CODE07 { get; set; }
        public string ANALYSIS_CODE08 { get; set; }
        public string ANALYSIS_CODE09 { get; set; }
        public string ANALYSIS_CODE10 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPOSBatchDetails> EPOSBatchDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPOSBatchTender> EPOSBatchTender { get; set; }
        public virtual Member Member { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Workplace Workplace { get; set; }
    }
}
